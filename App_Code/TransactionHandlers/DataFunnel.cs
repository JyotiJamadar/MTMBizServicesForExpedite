using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
/// <summary>
/// Summary description for DataFunnel
/// </summary>
public class DataFunnel
{
    SqlConnection sqlcon = new SqlConnection();
    DBTransactionHandler db = new DBTransactionHandler();

    public ValidResponseFormat ProcessData(ScanData scanData)
    {
        try
        {


            SqlCommand sqlcmd = new SqlCommand("InsProcessQueue", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@TrailerID", scanData.TrailerID);
            sqlcmd.Parameters.AddWithValue("@SequentialBarcode", scanData.SequentialBarcode);
            sqlcmd.Parameters.AddWithValue("@LoadType", scanData.LoadType);
            sqlcmd.Parameters.AddWithValue("@seal", scanData.Seal);
            sqlcmd.Parameters.AddWithValue("@LoginID", scanData.LoginId);
            sqlcmd.Parameters.AddWithValue("@employeeid", scanData.UserCode);
            sqlcmd.Parameters.AddWithValue("@Facility", scanData.FacilityCode);
            sqlcmd.Parameters.AddWithValue("@location", scanData.LocationCode);
            sqlcmd.Parameters.AddWithValue("@actioncode", scanData.ActionCode);
            sqlcmd.Parameters.AddWithValue("@DriverID", scanData.Driver);
            sqlcmd.Parameters.AddWithValue("@comment", scanData.Comment);
            sqlcmd.Parameters.AddWithValue("@issue", scanData.Issue);
            sqlcmd.Parameters.AddWithValue("@area", scanData.Area);
            sqlcmd.Parameters.AddWithValue("@PicturePath", scanData.PicturePath);
            sqlcmd.Parameters.AddWithValue("@bobtail", scanData.Bobtail);
            sqlcmd.Parameters.AddWithValue("@TruckNo", scanData.Truck);
            sqlcmd.Parameters.AddWithValue("@DriverName", scanData.DriverName);
            sqlcmd.Parameters.AddWithValue("@GPS_Latitude", scanData.GPS_Latitude);
            sqlcmd.Parameters.AddWithValue("@GPS_Longitude", scanData.GPS_Longitude);
            sqlcmd.Parameters.AddWithValue("@version", scanData.Version);
            sqlcmd.Parameters.AddWithValue("@deviceId", scanData.DeviceID);
            sqlcmd.Parameters.AddWithValue("@eventId", scanData.Version);
            sqlcmd.Parameters.AddWithValue("@tranId", scanData.ScanID);
            sqlcmd.Parameters.AddWithValue("@timestamp", scanData.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@RoutePool", scanData.RoutePool);

            //Application fields
            sqlcmd.Parameters.AddWithValue("@GatePass", scanData.Gatepass);
            sqlcmd.Parameters.AddWithValue("@TrailerandReceiptmatches", scanData.TrailerandReceiptTmatches);
            sqlcmd.Parameters.AddWithValue("@TareWeight", scanData.TareWeight);
            sqlcmd.Parameters.AddWithValue("@SealAttached", scanData.SealAttached);
            sqlcmd.Parameters.AddWithValue("@SealExited", scanData.SealExited);
            sqlcmd.Parameters.AddWithValue("@Status", scanData.Status);
            sqlcmd.Parameters.AddWithValue("@Carrier", scanData.Carrier);
            sqlcmd.Parameters.AddWithValue("@RenbanNumber", scanData.RenBanNumber);
            sqlcmd.Parameters.AddWithValue("@SealConfirm", scanData.SealConfirm);
            sqlcmd.Parameters.AddWithValue("@TrailerTypeBit", scanData.TrailerTypeBit);
            sqlcmd.Parameters.AddWithValue("@InspectionType", scanData.InspectionType);
            sqlcmd.Parameters.AddWithValue("@PlaCard", scanData.Placard);
            sqlcmd.Parameters.AddWithValue("@InsuranceStatus", scanData.InsuranceStatus);
            sqlcmd.Parameters.AddWithValue("@InsuranceVerified", scanData.InsuranceVerified);
            sqlcmd.Parameters.AddWithValue("@InboundCarrier", scanData.InboundCarrier);
            sqlcmd.Parameters.AddWithValue("@OutboundCarrier", scanData.OutboundCarrier);
            sqlcmd.Parameters.AddWithValue("@Order", scanData.Order);
            sqlcmd.Parameters.AddWithValue("@FreightIssue", scanData.FreightIssue);
            sqlcmd.Parameters.AddWithValue("@DispatchID", scanData.DispatchID == "null" || scanData.DispatchID == "" ? 0 : Convert.ToInt32(scanData.DispatchID));
            //sqlcmd.Parameters.AddWithValue("@@IsAuditYardCheck", scanData.AuditType);
            sqlcmd.Parameters.AddWithValue("@LicencePlateNo", scanData.LicencePlateNo);
            sqlcmd.Parameters.AddWithValue("@Phone", scanData.Phone);
            sqlcmd.Parameters.AddWithValue("@Destination", scanData.Destination);
            sqlcmd.Parameters.AddWithValue("@YardPass", scanData.YardPass);
            sqlcmd.Parameters.AddWithValue("@SafetyCheck", scanData.SafetyCheck);
            sqlcmd.Parameters.AddWithValue("@Emailbit", scanData.Emailbit);

            /*Code added - 1-06-2021*/
            sqlcmd.Parameters.AddWithValue("@CheckSheetScanPoint", scanData.CheckSheetScanPoint);
            sqlcmd.Parameters.AddWithValue("@ParkingSlot", scanData.ParkingSlot);
            sqlcmd.Parameters.AddWithValue("@PlacardType", scanData.PlacardType);
            sqlcmd.Parameters.AddWithValue("@ManualRoute", scanData.ManualRoute);
            sqlcmd.Parameters.AddWithValue("@EquipmentSize", scanData.EquipmentSize);

            sqlcmd.Parameters.AddWithValue("@BOLNumber", scanData.BOLNumber);
            sqlcmd.Parameters.AddWithValue("@HighVisVest", scanData.HighVisVest);
            sqlcmd.Parameters.AddWithValue("@DriverCellNumber", scanData.DriverCellNumber);
            sqlcmd.Parameters.AddWithValue("@AANumber", scanData.AANumber);
            sqlcmd.Parameters.AddWithValue("@VehicleType", scanData.VehicleType);
            sqlcmd.Parameters.AddWithValue("@CarrierETA", scanData.CarrierETA);
            sqlcmd.Parameters.AddWithValue("@DockNumber", scanData.DockNumber);
            sqlcmd.Parameters.AddWithValue("@PlannedULDate", scanData.PlannedULDate);
            sqlcmd.Parameters.AddWithValue("@PlannedULTime", scanData.PlannedULTime);
            sqlcmd.Parameters.AddWithValue("@EntryGate", scanData.EntryGate);

            sqlcmd.Parameters.AddWithValue("@Gate", scanData.Gate);
            /*End Code End*/


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }

            if (scanData.ActionCode == "00721")
            {
                SendWebPush webpush = new SendWebPush();
                webpush.SendPushForTrailerDamage("Issue", "", scanData.TrailerID, "Freight Damage");
            }
            if (scanData.ActionCode == "00705")
            {
                SendWebPush webpush = new SendWebPush();
                webpush.SendPushForTrailerDamage("Issue", "Area", scanData.TrailerID, "Trailer Damage");
            }
            if (scanData.ActionCode == "00717")
            {
                SqlCommand sqlcmd1 = new SqlCommand("InsDispatchRequestFromClose", sqlcon);
                sqlcmd1.Parameters.Clear();

                sqlcmd1.CommandType = CommandType.StoredProcedure;

                sqlcmd1.Parameters.AddWithValue("@TrailerID", scanData.TrailerID);
                sqlcmd1.Parameters.AddWithValue("@UserCode", scanData.UserCode);
                sqlcmd1.Parameters.AddWithValue("@TimeStamp", scanData.TimeStamp);

                SqlDataReader reader = null;
                db.OpenConnection(ref sqlcon);
                reader = sqlcmd1.ExecuteReader();

                Dictionary<string, string> DispatchData = new Dictionary<string, string>();
                string FC = "TY";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DispatchData.Add("TrailerID", reader["TrailerID"].ToString());
                        DispatchData.Add("DispatchID", reader["DispatchID"].ToString());
                        DispatchData.Add("FromLocation", reader["FromLocation"].ToString());
                        DispatchData.Add("ToLocation", reader["ToLocation"].ToString());
                        DispatchData.Add("DispatchStatus", reader["ReplyMessage"].ToString());
                        DispatchData.Add("TrailerStatus", reader["TrailerStatus"].ToString());
                        DispatchData.Add("DispatchMessage", reader["DispatchMessage"].ToString());
                        DispatchData.Add("Priority", reader["Priority"].ToString());

                    }
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string ReqTo = "All";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string key = "new";
                string jsonn;
                jsonn = jss.Serialize(DispatchData);
                CloudPush cp = new CloudPush();
                cp.SendGCM(jsonn, key, FC, ReqTo);
                //Response.Write(result);
                DispatchData.Clear();
            }


            if (scanData.ActionCode == "00716")
            {
                CloudPush cp = new CloudPush();
                cp.SendGCM("", "Refresh", "TY", "All");
            }
            if (scanData.ActionCode == "00712")
            {
                if (scanData.DispatchID != "0")
                {
                    SqlCommand sqlcmd1 = new SqlCommand("PushDispatchNotification", sqlcon);
                    sqlcmd1.Parameters.Clear();
                    sqlcmd1.CommandType = CommandType.StoredProcedure;

                    sqlcmd1.Parameters.AddWithValue("@DispatchID", scanData.DispatchID);
                    //sqlcmd1.Parameters.AddWithValue("@UserCode", scanData.UserCode);
                    // sqlcmd1.Parameters.AddWithValue("@TimeStamp", scanData.TimeStamp);
                    SqlDataReader reader = null;
                    db.OpenConnection(ref sqlcon);
                    reader = sqlcmd1.ExecuteReader();

                    Dictionary<string, string> DispatchData = new Dictionary<string, string>();
                    string FC = "TY";
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {


                            DispatchData.Add("TrailerID", reader["TrailerID"].ToString());
                            DispatchData.Add("DispatchID", reader["DispatchID"].ToString());
                            DispatchData.Add("FromLocation", reader["FromLocation"].ToString());
                            DispatchData.Add("ToLocation", reader["ToLocation"].ToString());
                            DispatchData.Add("DispatchStatus", reader["ReplyMessage"].ToString());
                            DispatchData.Add("DispatchMessage", reader["DispatchMessage"].ToString());
                            DispatchData.Add("Priority", reader["PriorityName"].ToString());
                            DispatchData.Add("PriorityCode", reader["Priority"].ToString());
                            DispatchData.Add("Run", reader["Route"].ToString());
                            DispatchData.Add("TrailerStatus", reader["TrailerStatus"].ToString());
                            DispatchData.Add("DriverGroup", reader["DriverGroup"].ToString());
                        }
                    }

                    if (reader.IsClosed == false)
                    {
                        reader.Close();
                    }
                    string ReqTo = "All";

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string key = "new";
                    string jsonn;
                    jsonn = jss.Serialize(DispatchData);
                    CloudPush cp = new CloudPush();
                    cp.SendGCM(jsonn, key, FC, ReqTo);
                    DispatchData.Clear();
                }
            }   //}

            return new ValidResponseFormat { Success = true };

        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }

    }

    public ValidResponseFormat ProcessCTPAT(CTPATData ctpatdata)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("spInsCTPATInspectionHistory", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;


            sqlcmd.Parameters.AddWithValue("@CarrierName", ctpatdata.CarrierName);
            sqlcmd.Parameters.AddWithValue("@TractorNumber", ctpatdata.TractorNumber);
            sqlcmd.Parameters.AddWithValue("@ContainerNumber", ctpatdata.ContainerNumber);
            sqlcmd.Parameters.AddWithValue("@SealNumber", ctpatdata.SealNumber);
            sqlcmd.Parameters.AddWithValue("@IsHighSecuritySeal", ctpatdata.IsHighSecuritySeal);
            sqlcmd.Parameters.AddWithValue("@IsSealIntact", ctpatdata.IsSealIntact);
            sqlcmd.Parameters.AddWithValue("@IsSealDocumentMatch", ctpatdata.IsSealDocumentMatch);
            sqlcmd.Parameters.AddWithValue("@UnderCarriageChassis", ctpatdata.UnderCarriageChassis);
            sqlcmd.Parameters.AddWithValue("@UCCComment", ctpatdata.UCCComment);
            sqlcmd.Parameters.AddWithValue("@DoorsLockingMechanism", ctpatdata.DoorsLockingMechanism);
            sqlcmd.Parameters.AddWithValue("@DLMComment", ctpatdata.DLMComment);
            sqlcmd.Parameters.AddWithValue("@RightSide", ctpatdata.RightSide);
            sqlcmd.Parameters.AddWithValue("@RightSideComment", ctpatdata.RightSideComment);
            sqlcmd.Parameters.AddWithValue("@LeftSide", ctpatdata.LeftSide);
            sqlcmd.Parameters.AddWithValue("@LeftSideComment", ctpatdata.LeftSideComment);
            sqlcmd.Parameters.AddWithValue("@FrontWall", ctpatdata.FrontWall);
            sqlcmd.Parameters.AddWithValue("@FrontWallComment", ctpatdata.FrontWallComment);
            sqlcmd.Parameters.AddWithValue("@CeilingRoof", ctpatdata.CeilingRoof);
            sqlcmd.Parameters.AddWithValue("@CeilingRoofComment", ctpatdata.CeilingRoofComment);
            sqlcmd.Parameters.AddWithValue("@Floor", ctpatdata.Floor);
            sqlcmd.Parameters.AddWithValue("@FloorComment", ctpatdata.FloorComment);
            sqlcmd.Parameters.AddWithValue("@ScanTime", ctpatdata.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@UserCode", ctpatdata.UserCode);
            sqlcmd.Parameters.AddWithValue("@ScanID", ctpatdata.ScanID);
            sqlcmd.Parameters.AddWithValue("@Source", "android");
            sqlcmd.Parameters.AddWithValue("@DeviceID", ctpatdata.DeviceID);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    public ValidResponseFormat UpdatePicturePath(PictureRequest updateData)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("UpdatePicture", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;



            sqlcmd.Parameters.AddWithValue("@PictureRequestID", updateData.PictureRequestID);
            sqlcmd.Parameters.AddWithValue("@PicturePath", updateData.PicturePath);
            sqlcmd.Parameters.AddWithValue("@UserCode", updateData.UserCode);
            sqlcmd.Parameters.AddWithValue("@ScanTime", updateData.TimeStamp);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    //CTPATInterior
    public ValidResponseFormat CTPATInterior(CTPATInteriorData ctpatdata)
    {
        int CTPATHistoryID;
        try
        {
            using (sqlcon)
            {
                using (SqlCommand sqlcmd = new SqlCommand("InsCTPATHistory", sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    sqlcmd.Parameters.AddWithValue("@TrailerID", ctpatdata.TrailerID);
                    sqlcmd.Parameters.AddWithValue("@UserCode", ctpatdata.UserCode);
                    sqlcmd.Parameters.AddWithValue("@CTPATType", ctpatdata.CTPATType);
                    sqlcmd.Parameters.AddWithValue("@ActivateTrigger", true);
                    sqlcmd.Parameters.AddWithValue("@DriverName", ctpatdata.DriverName);
                    sqlcmd.Parameters.AddWithValue("@Employer ", ctpatdata.Employer);
                    sqlcmd.Parameters.AddWithValue("@Placard ", ctpatdata.Placard);
                    sqlcmd.Parameters.AddWithValue("@SealNumber ", ctpatdata.SealNumber);
                    sqlcmd.Parameters.AddWithValue("@Source ", "android");
                    db.OpenConnection(ref sqlcon);
                    CTPATHistoryID = Convert.ToInt32(sqlcmd.ExecuteScalar());


                }
            }
            foreach (CTPATInspectionData inspectionData in ctpatdata.InspectionData)
            {
                using (sqlcon)
                {
                    using (SqlCommand sqlcmd = new SqlCommand("spInsCTPATDetails", sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        sqlcmd.Parameters.AddWithValue("@Question", inspectionData.Identifier);
                        sqlcmd.Parameters.AddWithValue("@PicturePath", inspectionData.PicturePath);
                        sqlcmd.Parameters.AddWithValue("@CTPATHistoryID", CTPATHistoryID);
                        sqlcmd.Parameters.AddWithValue("@Pass", inspectionData.Pass);
                        db.OpenConnection(ref sqlcon);
                        sqlcmd.ExecuteNonQuery();


                    }
                }
            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    //End CTPATInterior


    public ValidResponseFormat UpdateSequentialBarcode(LookupRequest updateData)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("spUpdateSequentialBarcode", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;



            sqlcmd.Parameters.AddWithValue("@TrailerID", updateData.TrailerID);
            sqlcmd.Parameters.AddWithValue("@SequentialBarcode", updateData.SequentialBarcode);
            sqlcmd.Parameters.AddWithValue("@UserCode", updateData.UserCode);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }
    public void SendAcceptPush(string DispatchID, string UserCode)
    {
        try
        {
            CloudPush push = new CloudPush();
            Dictionary<string, string> AcceptData = new Dictionary<string, string>();
            AcceptData.Add("DispatchID", DispatchID);
            AcceptData.Add("AcceptedBy", UserCode);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string key = "reply";
            string jsonn;
            jsonn = jss.Serialize(AcceptData);
            AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
            result = push.SendGCM(jsonn, key, "TY", "All");
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
    public ValidResponseFormat UpdateDispatchReply(DispatchReplyData dispatchReplyData)
    {
        try
        {
            string resultDecider = "";
            string ReqTo = "All";
            string FacCode = "TY";
            SqlCommand sqlcmd = new SqlCommand("UpdMoveRequestHistoryReplyCloud", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@RepliedBy", dispatchReplyData.UserCode);
            sqlcmd.Parameters.AddWithValue("@ReplyComment", dispatchReplyData.Reply);
            sqlcmd.Parameters.AddWithValue("@MoveRequestHistoryID ", dispatchReplyData.DispatchID);
            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                SqlDataReader reader = null;
                reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                    resultDecider = reader["ResultDecider"].ToString();
                    ReqTo = reader["RequestedTo"].ToString();

                }
                reader.Close();

            }
            if (resultDecider == "1")
            {
                if (dispatchReplyData.Reply == "Accept")
                {
                    CloudPush push = new CloudPush();
                    Dictionary<string, string> AcceptData = new Dictionary<string, string>();
                    AcceptData.Add("DispatchID", dispatchReplyData.DispatchID.ToString());
                    AcceptData.Add("AcceptedBy", dispatchReplyData.UserCode);
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string key = "reply";
                    string jsonn;
                    jsonn = jss.Serialize(AcceptData);
                    AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
                    result = push.SendGCM(jsonn, key, FacCode, ReqTo);

                }
                return new ValidResponseFormat { Success = true };
            }
            else
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("There is no pending request matching the details. It may have been deleted or accepted by someone else.", 715);
            }
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    public ValidResponseFormat CompleteMove(DispatchReplyData dispatchReplyData)
    {
        try
        {

            SqlCommand sqlcmd = new SqlCommand("UpdMoveRequestHistoryReplyCompleteCloud", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@RepliedBy", dispatchReplyData.UserCode);

            sqlcmd.Parameters.AddWithValue("@MoveRequestHistoryID", dispatchReplyData.DispatchID);
            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }

            return new ValidResponseFormat { Success = true };


        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    public ValidResponseFormat DispatchRequest(DispatchRequest dispatchRequest)
    {
        try
        {
            using (sqlcon)
            {
                SqlCommand sqlcmd = new SqlCommand("InsDispatchRequest", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@TrailerID", dispatchRequest.TrailerID);
                sqlcmd.Parameters.AddWithValue("@FromFacility", "TY");
                sqlcmd.Parameters.AddWithValue("@ToFacility", "TY");
                sqlcmd.Parameters.AddWithValue("@FromLocation", dispatchRequest.FromLocation);
                sqlcmd.Parameters.AddWithValue("@ToLocation", dispatchRequest.ToLocation);
                sqlcmd.Parameters.AddWithValue("@TrailerStatus", dispatchRequest.TrailerStatus);
                sqlcmd.Parameters.AddWithValue("@TimeStamp", dispatchRequest.TimeStamp);
                sqlcmd.Parameters.AddWithValue("@UserCode", dispatchRequest.UserCode);
                sqlcmd.Parameters.AddWithValue("@Comment", dispatchRequest.Comment);
                sqlcmd.Parameters.AddWithValue("@Priority", dispatchRequest.Priority);
                sqlcmd.Parameters.AddWithValue("@RequestedTo", "TR002");
                sqlcmd.Parameters.AddWithValue("@Route", "dispatchRequest.Route");
                sqlcmd.Parameters.AddWithValue("@SafeToMove", dispatchRequest.SafeToMove);
                //sqlcmd.Parameters.AddWithValue("@Run", dispatchRequest.Run);

                SqlDataReader reader = null;
                db.OpenConnection(ref sqlcon);
                reader = sqlcmd.ExecuteReader();

                Dictionary<string, string> DispatchData = new Dictionary<string, string>();
                string FC = "TY";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DispatchData.Add("TrailerID", reader["TrailerID"].ToString());
                        DispatchData.Add("DispatchID", reader["DispatchID"].ToString());
                        DispatchData.Add("FromLocation", reader["FromLocation"].ToString());
                        DispatchData.Add("ToLocation", reader["ToLocation"].ToString());
                        DispatchData.Add("DispatchStatus", reader["ReplyMessage"].ToString());
                        DispatchData.Add("TrailerStatus", reader["TrailerStatus"].ToString());
                        DispatchData.Add("DispatchMessage", reader["DispatchMessage"].ToString());
                        DispatchData.Add("Priority", reader["Priority"].ToString());
                        DispatchData.Add("Run", reader["Route"].ToString());
                    }
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string ReqTo = "All";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string key = "new";
                string jsonn;
                jsonn = jss.Serialize(DispatchData);
                CloudPush cp = new CloudPush();
                cp.SendGCM(jsonn, key, FC, ReqTo);
                //Response.Write(result);
                DispatchData.Clear();


                return new ValidResponseFormat { Success = true };

            }
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }

    }


    public ValidResponseFormat UpdateSignatureData(UpdateSignature updateSignature)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("spUpdateDriverSignatureANDR", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@DriverSignaturePath", updateSignature.DriverSignaturePath);
            sqlcmd.Parameters.AddWithValue("@UserCode", updateSignature.UserCode);
            sqlcmd.Parameters.AddWithValue("@ScanTime", updateSignature.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@DriverName", updateSignature.DriverName);
            sqlcmd.Parameters.AddWithValue("@ShipmentNumber", updateSignature.ShipmentNumber);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }


    public ValidResponseFormat ProcessUserLoginDetailsGPS(UserGPSLoginDetails ctpatdata)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("InsUserLoginDetails", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;



            sqlcmd.Parameters.AddWithValue("@DeviceID", ctpatdata.DeviceID);
            sqlcmd.Parameters.AddWithValue("@UserCode", ctpatdata.UserCode);
            sqlcmd.Parameters.AddWithValue("@TimeStamp", ctpatdata.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@GPS_Latitude", ctpatdata.GPS_Latitude);
            sqlcmd.Parameters.AddWithValue("@GPS_Longitude", ctpatdata.GPS_Longitude);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }


    public ValidResponseFormat ProcessLoggedInUserGroup(LoggedInUserGroupRequest LoggeInUserGroup)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("InsUPDGroupForLoggedInUsers", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;


            sqlcmd.Parameters.AddWithValue("@UserCode", LoggeInUserGroup.UserCode);
            sqlcmd.Parameters.AddWithValue("@GroupName", LoggeInUserGroup.GroupCode);



            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }


    public ValidResponseFormat DispatchDataFromAndroid(DispatchData data)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("InsDispatchData", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;



            sqlcmd.Parameters.AddWithValue("@DispatchID", data.DispatchID);
            sqlcmd.Parameters.AddWithValue("@DeviceID", data.DeviceID);
            sqlcmd.Parameters.AddWithValue("@CreatedBy", data.UserCode);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }


    public ValidResponseFormat UnAcceptDispatchRequest(DispatchRequestForUnAccept dispatchRequest)
    {
        try
        {
            using (sqlcon)
            {
                SqlCommand sqlcmd = new SqlCommand("UnAccpetedDispatch", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@DispatchID", dispatchRequest.DispatchID);


                SqlDataReader reader = null;
                db.OpenConnection(ref sqlcon);
                reader = sqlcmd.ExecuteReader();

                Dictionary<string, string> DispatchData = new Dictionary<string, string>();
                string FC = "TY";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DispatchData.Add("TrailerID", reader["TrailerID"].ToString());
                        DispatchData.Add("DispatchID", reader["DispatchID"].ToString());
                        DispatchData.Add("FromLocation", reader["FromLocation"].ToString());
                        DispatchData.Add("ToLocation", reader["ToLocation"].ToString());
                        DispatchData.Add("DispatchStatus", reader["ReplyMessage"].ToString());
                        DispatchData.Add("DispatchMessage", reader["DispatchMessage"].ToString());
                        DispatchData.Add("Priority", reader["PriorityName"].ToString());
                        DispatchData.Add("PriorityCode", reader["Priority"].ToString());
                        DispatchData.Add("Run", reader["Route"].ToString());
                        DispatchData.Add("TrailerStatus", reader["TrailerStatus"].ToString());
                        DispatchData.Add("DriverGroup", reader["DriverGroup"].ToString());

                    }
                }
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                string ReqTo = "All";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string key = "new";
                string jsonn;
                jsonn = jss.Serialize(DispatchData);
                CloudPush cp = new CloudPush();
                cp.SendGCM(jsonn, key, FC, ReqTo);
                //Response.Write(result);
                DispatchData.Clear();
                return new ValidResponseFormat { Success = true };
            }

        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    public ValidResponseFormat ProcessDrop(ScanDataDrop scandatadrop)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("InsManualDispatchDrop", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@TrailerID", scandatadrop.TrailerID);
            sqlcmd.Parameters.AddWithValue("@Seal", scandatadrop.Seal);
            sqlcmd.Parameters.AddWithValue("@LocationCode", scandatadrop.LocationCode);
            sqlcmd.Parameters.AddWithValue("@Status", scandatadrop.Status);
            sqlcmd.Parameters.AddWithValue("@PlaCard", scandatadrop.PlaCard);
            sqlcmd.Parameters.AddWithValue("@DispatchID", scandatadrop.DispatchID);
            sqlcmd.Parameters.AddWithValue("@InspectionType", scandatadrop.InspectionType);
            sqlcmd.Parameters.AddWithValue("@recordid", scandatadrop.recordid);
            sqlcmd.Parameters.AddWithValue("@SafetyCheck", scandatadrop.SafetyCheck);
            sqlcmd.Parameters.AddWithValue("@ActionCode", scandatadrop.ActionCode);
            sqlcmd.Parameters.AddWithValue("@UserCode", scandatadrop.UserCode);
            sqlcmd.Parameters.AddWithValue("@FacilityCode", scandatadrop.FacilityCode);
            sqlcmd.Parameters.AddWithValue("@TimeStamp", scandatadrop.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@ScanID", scandatadrop.ScanID);
            sqlcmd.Parameters.AddWithValue("@DeviceID", scandatadrop.DeviceID);
            sqlcmd.Parameters.AddWithValue("@Version", scandatadrop.Version);
            sqlcmd.Parameters.AddWithValue("@LoginId", scandatadrop.LoginId);
            sqlcmd.Parameters.AddWithValue("@GPS_Latitude", scandatadrop.GPS_Latitude);
            sqlcmd.Parameters.AddWithValue("@GPS_Longitude", scandatadrop.GPS_Longitude);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    public ValidResponseFormat ProcessHook(ScanDataHook scandatahook)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("InsManualAndDispatchHook", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@TrailerID", scandatahook.TrailerID);
            sqlcmd.Parameters.AddWithValue("@Seal", scandatahook.Seal);

            //sqlcmd.Parameters.AddWithValue("@Emailbit", scandatahook.Emailbit);
            sqlcmd.Parameters.AddWithValue("@PlaCard", scandatahook.PlaCard);
            sqlcmd.Parameters.AddWithValue("@DispatchID", scandatahook.DispatchID);

            sqlcmd.Parameters.AddWithValue("@ActionCode", scandatahook.ActionCode);
            sqlcmd.Parameters.AddWithValue("@UserCode", scandatahook.UserCode);
            sqlcmd.Parameters.AddWithValue("@FacilityCode", scandatahook.FacilityCode);
            sqlcmd.Parameters.AddWithValue("@TimeStamp", scandatahook.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@ScanID", scandatahook.ScanID);
            sqlcmd.Parameters.AddWithValue("@DeviceID", scandatahook.DeviceID);
            sqlcmd.Parameters.AddWithValue("@Version", scandatahook.Version);
            sqlcmd.Parameters.AddWithValue("@LoginId", scandatahook.LoginId);
            sqlcmd.Parameters.AddWithValue("@GPS_Latitude", scandatahook.GPS_Latitude);
            sqlcmd.Parameters.AddWithValue("@GPS_Longitude", scandatahook.GPS_Longitude);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }

            //Queue Logic Implemented If Request out Trailer is Hooked,RequestedIn trailer disaptch should go on.
            //--------------------------------------------------------------------------------------------------------------------------
            if (scandatahook.ActionCode == "00712")
            {
                if (scandatahook.DispatchID != "0" && scandatahook.DispatchID != null && scandatahook.DispatchID != "")
                {
                    using (sqlcon)
                    {
                        SqlCommand sqlcmd1 = new SqlCommand("PushDispatchNotification", sqlcon);
                        sqlcmd1.Parameters.Clear();
                        sqlcmd1.CommandType = CommandType.StoredProcedure;

                        sqlcmd1.Parameters.AddWithValue("@DispatchID", scandatahook.DispatchID);
                        //sqlcmd1.Parameters.AddWithValue("@UserCode", scanData.UserCode);
                        // sqlcmd1.Parameters.AddWithValue("@TimeStamp", scanData.TimeStamp);
                        SqlDataReader reader = null;
                        db.OpenConnection(ref sqlcon);
                        reader = sqlcmd1.ExecuteReader();

                        Dictionary<string, string> DispatchData = new Dictionary<string, string>();
                        string FC = "TY";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {



                                DispatchData.Add("TrailerID", reader["TrailerID"].ToString());
                                DispatchData.Add("DispatchID", reader["DispatchID"].ToString());
                                DispatchData.Add("FromLocation", reader["FromLocation"].ToString());
                                DispatchData.Add("ToLocation", reader["ToLocation"].ToString());
                                DispatchData.Add("DispatchStatus", reader["ReplyMessage"].ToString());
                                DispatchData.Add("DispatchMessage", reader["DispatchMessage"].ToString());
                                DispatchData.Add("Priority", reader["PriorityName"].ToString());
                                DispatchData.Add("PriorityCode", reader["Priority"].ToString());
                                DispatchData.Add("Run", reader["Route"].ToString());
                                DispatchData.Add("TrailerStatus", reader["TrailerStatus"].ToString());
                                DispatchData.Add("DriverGroup", reader["DriverGroup"].ToString());

                            }
                        }

                        if (reader.IsClosed == false)
                        {
                            reader.Close();
                        }
                        string ReqTo = "All";

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string key = "new";
                        string jsonn;
                        jsonn = jss.Serialize(DispatchData);
                        CloudPush cp = new CloudPush();
                        cp.SendGCM(jsonn, key, FC, ReqTo);
                        DispatchData.Clear();
                    }
                }
            }


            //----------------------------------------------------------------------------------------------------------------------------
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

}