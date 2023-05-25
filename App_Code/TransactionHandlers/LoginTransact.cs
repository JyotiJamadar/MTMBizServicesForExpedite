using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for LoginTransact
/// </summary>
public class LoginTransact
{
    SqlConnection sqlcon = new SqlConnection();
    DBTransactionHandler db = new DBTransactionHandler();

    public GeneralResponse<LoginResponseData> getLogin(string UserName, string Password, string DeviceID)
    {
        try
        {

            using (sqlcon)
            {
                LoginResponseData lrd = new LoginResponseData();
                db.OpenConnection(ref sqlcon);
                string SQlQuery = "UserLogin";
                SqlCommand sqlcmd = new SqlCommand(SQlQuery, sqlcon);
                sqlcmd.Parameters.AddWithValue("@UserCode", UserName);
                sqlcmd.Parameters.AddWithValue("@Password", Password);
                sqlcmd.Parameters.AddWithValue("@DeviceID", DeviceID);
                sqlcmd.Parameters.AddWithValue("@LoginMode", "android");
                SqlDataReader reader = db.GetResultSet(ref sqlcmd, ref sqlcon);

                while (reader.Read())
                {
                    lrd.UserName = reader["UserName"].ToString();
                    lrd.FacilityName = reader["FacilityName"].ToString();
                    lrd.FacilityCode = reader["FacilityCode"].ToString();
                    lrd.UserCode = reader["UserCode"].ToString();
                    lrd.ProfileTemplateID = Convert.ToInt32(reader["ProfileTemplateID"].ToString());
                    lrd.RoleID = Convert.ToInt32(reader["RoleID"].ToString());

                }
                if (lrd.UserCode == "-1")
                {
                    return GlobalUtility<LoginResponseData>.Throw_Global_Exception("Device not activated.", 601);
                }
                else if (lrd.UserCode == "-2")
                {
                    return GlobalUtility<LoginResponseData>.Throw_Global_Exception("Duplicate login encountered. Please logout from the other logged in device to login using this device.", 605);
                }
                else if (lrd.UserCode != null)
                {
                    return new GeneralResponse<LoginResponseData>
                    {
                        Success = true,
                        Data = lrd,
                        ErrorMessage = "No Error"
                    };
                }
                else
                {
                    return GlobalUtility<LoginResponseData>.Throw_Global_Exception("Invalid UserName or Password", 600);
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }




    public GeneralResponse<LoginResponseDataRole> LoginWithRole(string UserName, string Password, string DeviceID)
    {
        List<string> RoleList = new List<string>();
        try
        {
            using (sqlcon)
            {
                string SQLQuery = "spGetRoles";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserName);

                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            RoleList.Add(reader["RoleCode"].ToString());

                        }

                    }
                    reader.Close();
                }

            }


            LoginResponseDataRole lrd = new LoginResponseDataRole();
            using (sqlcon)
            {

                db.OpenConnection(ref sqlcon);
                string SQlQuery = "UserLogin";
                SqlCommand sqlcmd = new SqlCommand(SQlQuery, sqlcon);
                sqlcmd.Parameters.AddWithValue("@UserCode", UserName);
                sqlcmd.Parameters.AddWithValue("@Password", Password);
                sqlcmd.Parameters.AddWithValue("@DeviceID", DeviceID);
                sqlcmd.Parameters.AddWithValue("@LoginMode", "android");
                SqlDataReader reader = db.GetResultSet(ref sqlcmd, ref sqlcon);

                while (reader.Read())
                {
                    lrd.UserName = reader["UserName"].ToString();
                    lrd.FacilityName = reader["FacilityName"].ToString();
                    lrd.FacilityCode = reader["FacilityCode"].ToString();
                    lrd.UserCode = reader["UserCode"].ToString();
                    lrd.ProfileTemplateID = Convert.ToInt32(reader["ProfileTemplateID"].ToString());
                    lrd.RoleID = Convert.ToInt32(reader["RoleID"].ToString());
                    lrd.ValidRoles = RoleList;
                    lrd.LoginToken = reader["LoginToken"].ToString();
                    lrd.SealRequired = Convert.ToBoolean(reader["SealRequired"]);
                    lrd.DockDoorScanSettingRequired = Convert.ToBoolean(reader["DockDoorScanSettingRequired"]);
                    lrd.DisplayDestinationDuringRequestAndAccept = Convert.ToBoolean(reader["DisplayDestinationDuringRequestAndAccept"]);
                    lrd.DockDoorDropBarcodeScan = Convert.ToBoolean(reader["DockDoorDropBarcodeScan"]);
                    lrd.DockDoorDropPlacardScan = Convert.ToBoolean(reader["DockDoorDropPlacardScan"]);
                    lrd.YardDropBarcodeScan = Convert.ToBoolean(reader["YardDropBarcodeScan"]);
                    lrd.YardDropPlacardScan = Convert.ToBoolean(reader["YardDropPlacardScan"]);
                }
                LoginResponseRole rf = new LoginResponseRole();

                if (lrd.UserCode == "-1")
                {
                    return GlobalUtility<LoginResponseDataRole>.Throw_Global_Exception("Device not activated.", 601);
                }
                else if (lrd.UserCode == "-2")
                {
                    return GlobalUtility<LoginResponseDataRole>.Throw_Global_Exception("Duplicate login encountered. Please logout from the other logged in device to login using this device.", 605);
                }
                else if (lrd.UserCode != null)
                {
                    return new GeneralResponse<LoginResponseDataRole>
                    {
                        Success = true,
                        Data = lrd,
                        ErrorMessage = "No Error"
                    };
                }
                else
                {
                    return GlobalUtility<LoginResponseDataRole>.Throw_Global_Exception("Invalid UserName or Password", 600);
                }


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }

    }

    public ValidResponseFormat ActivateDevice(string activationKey, string deviceID)
    {
        try
        {
            string response;
            SqlCommand sqlcmd = new SqlCommand("ActivateDevice", sqlcon);
            sqlcmd.Parameters.AddWithValue("@ActivationKey", activationKey);
            sqlcmd.Parameters.AddWithValue("@DeviceID", deviceID);
            using (sqlcon)
            {

                db.OpenConnection(ref sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                response = sqlcmd.ExecuteScalar().ToString();

            }
            if (response == "1")
            {
                return new ValidResponseFormat { Success = true };
            }
            else
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("The provided key is invalid. Please try again.", 603);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }


    }
}