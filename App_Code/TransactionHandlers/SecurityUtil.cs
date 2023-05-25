using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for SecurityUtil
/// </summary>
public static class SecurityUtil
{


    private const string SALT_CONSTANT = "ADA280FECD4DD34DDD3AE935C8487517FCF085371CACC344A0F0851BCFF98B4A55080F6ACA43A53DE6C8C619E831E75695057984C4D565D61BB793389E86003B";
   
    public static bool IsRequestAuthorized(string deviceID, string token)
    {
        try
        {
            return GenerateSHA512String(SALT_CONSTANT + deviceID) == token;
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }

    private static string GenerateSHA512String(string inputString)
    {
        try
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }

    private static string GetStringFromHash(byte[] hash)
    {
        try
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
      
    }

    public static bool IsDeviceIDVerified(string deviceID)
    {
        try
        {
            DBTransactionHandler db = new DBTransactionHandler();
            SqlConnection sqlcon = new SqlConnection();

            using (sqlcon)
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceConnection"].ToString();
                    sqlcon.Open();
                }
                string SQlQuery = "spCheckDeviceActivation";
                SqlCommand sqlcmd = new SqlCommand(SQlQuery, sqlcon);
                sqlcmd.Parameters.AddWithValue("@DeviceID", deviceID);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlcmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



}