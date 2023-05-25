using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for DataRetreiver
/// </summary>

public class DataRetreiver
{
    SqlConnection sqlcon = new SqlConnection();
    DBTransactionHandler db = new DBTransactionHandler();
    public GeneralResponse<List<ValidData>> RetreiveValidInfo(ValidRequestData ValidRequest)
    {
        try
        {
            List<ValidData> validInfo = new List<ValidData>();
            List<ValidDataForLocation> validInfoType = new List<ValidDataForLocation>();

            string SQLQuery;

            using (sqlcon)
            {

                if (ValidRequest.ResourceType == "Company")
                {
                    SQLQuery = "GetCompany";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        //sqlcmd.Parameters.AddWithValue("@UserCode", ValidRequest.ResourceType);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["CompanyCode"].ToString(), reader["CompanyName"].ToString()));

                        }
                    }
                }

                else if (ValidRequest.ResourceType == "PoolTrailers")
                {
                    SQLQuery = "GetPoolTrailers";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@UserCode", ValidRequest.UserCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["TrailerID"].ToString(), reader["TrailerID"].ToString()));

                        }
                    }
                }

                else if (ValidRequest.ResourceType == "OutboundPoolTrailers")
                {
                    SQLQuery = "GetOutboundGetPoolTrailers";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@UserCode", ValidRequest.UserCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["TrailerID"].ToString(), reader["TrailerID"].ToString()));

                        }
                    }
                }

                else if (ValidRequest.ResourceType == "PupTrailers")
                {
                    SQLQuery = "GetPupTrailers";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        //sqlcmd.Parameters.AddWithValue("@UserCode", ValidRequest.ResourceType);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["PupTrailer"].ToString(), reader["PupTrailer"].ToString()));

                        }
                    }
                }


                else if (ValidRequest.ResourceType == "GenericPlacard")
                {
                    SQLQuery = "GetGenericPlacardListForAndroid";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["Code"].ToString(), reader["Name"].ToString()));

                        }
                    }
                }

                else if (ValidRequest.ResourceType == "GenericYardPass")
                {
                    SQLQuery = "GetGenericYardPassForDeparture";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["CatalogCode"].ToString(), reader["CatalogName"].ToString()));

                        }
                    }
                }

                else if (ValidRequest.ResourceType == "YardCheckLocations")
                {
                    SQLQuery = "YardCheckLocations";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@FacilityCode", ValidRequest.FacilityCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                        }
                    }
                }

                else if (ValidRequest.ResourceType == "ContainerNumber")
                {
                    SQLQuery = "GetContainerNoFromVessel";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["ContainerNumber"].ToString(), reader["ContainerNumber"].ToString()));

                        }
                    }

                }

                else if (ValidRequest.ResourceType == "Locations")
                {
                    SQLQuery = "GetLocationsForFacility";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@FacilityCode", ValidRequest.FacilityCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfoType.Add(new ValidDataForLocation(reader["LocationCode"].ToString(), reader["Location"].ToString(), reader["LocationTypeCode"].ToString()));

                        }
                    }

                }

                else if (ValidRequest.ResourceType == "DropLocations")
                {
                    SQLQuery = "GetDropLocationsForFacility";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@FacilityCode", ValidRequest.FacilityCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                        }
                    }

                }


                else if (ValidRequest.ResourceType == "Groups")
                {
                    SQLQuery = "GetGroups";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        // sqlcmd.Parameters.AddWithValue("@FacilityCode", ValidRequest.FacilityCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["GroupCode"].ToString(), reader["GroupName"].ToString()));

                        }
                    }

                }

                else if (ValidRequest.ResourceType == "DockForYardCheck")
                {
                    SQLQuery = "GetDockForyardcheck";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        // sqlcmd.Parameters.AddWithValue("@FacilityCode", ValidRequest.FacilityCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["Code"].ToString(), reader["Name"].ToString()));

                        }
                    }

                }
                else if (ValidRequest.ResourceType == "Carrier")
                {
                    SQLQuery = "GetCarriers";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        // sqlcmd.Parameters.AddWithValue("@UserCode", ValidRequest.ResourceType);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["CarrierCode"].ToString(), reader["Carrier"].ToString()));

                        }
                    }

                }


                else if (ValidRequest.ResourceType == "OverflowGroup")
                {
                    SQLQuery = "GetOverflowslotsParking";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["CatalogCode"].ToString(), reader["CatalogName"].ToString()));

                        }
                    }

                }


                else if (ValidRequest.ResourceType == "OverflowLocationYardGroup")
                {
                    SQLQuery = "GetOverflowslotsforyardgroup";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Locationgrouptype", ValidRequest.LocationGroupCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                        }
                    }

                }


                else if (ValidRequest.ResourceType == "PlacardListForVerification")
                {
                    SQLQuery = "GetPlacardForHookAndDropVerification";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        //sqlcmd.Parameters.AddWithValue("@Locationgrouptype", ValidRequest.LocationGroupCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["Code"].ToString(), reader["Name"].ToString()));

                        }
                    }

                }


                else if (ValidRequest.ResourceType == "RoutePoolDI")
                {
                    SQLQuery = "GetDomesticInterNational";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        //sqlcmd.Parameters.AddWithValue("@Locationgrouptype", ValidRequest.LocationGroupCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["Code"].ToString(), reader["Name"].ToString()));

                        }
                    }

                }


                else if (ValidRequest.ResourceType == "ParkingSlotForPlacard")
                {
                    if (ValidRequest.Placard.StartsWith("MSPLRMT"))
                    {

                        SQLQuery = "GetArrivalParkingSpaceForTrailerAndContainer";
                        string route = GetRouteForPlacard(ValidRequest.Placard);
                        db.OpenConnection(ref sqlcon);
                        using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                        {
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Route", route);
                            SqlDataReader reader = sqlcmd.ExecuteReader();
                            while (reader.Read())
                            {
                                validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                            }
                        }
                    }
                    else
                    {
                        SQLQuery = "GetArrivalParkingSpaceForEmptyAndGeneric";
                        // SQLQuery = "GetArrivalParkingSpaceForTrailerAndContainer";
                        //Code comment by Deepak Because of Wrong gate logic ,We are ussing same SP like Web page
                        string route = GetRouteForPlacard(ValidRequest.Placard);
                        db.OpenConnection(ref sqlcon);
                        using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                        {
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Route", route);
                            sqlcmd.Parameters.AddWithValue("@UserCode", ValidRequest.UserCode);
                            SqlDataReader reader = sqlcmd.ExecuteReader();
                            while (reader.Read())
                            {
                                validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                            }
                        }
                    }

                    return new GeneralResponse<List<ValidData>>
                    {
                        Success = true,
                        Data = validInfo
                    };

                }



                else if (ValidRequest.ResourceType == "ParkingSlotForRoute")
                {
                    SQLQuery = "GetArrivalParkingSpaceForTrailerAndContainer";
                    string route = GetRouteForPlacard(ValidRequest.Placard);
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Route", route);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                        }
                    }

                    return new GeneralResponse<List<ValidData>>
                    {
                        Success = true,
                        Data = validInfo
                    };

                }


                else if (ValidRequest.ResourceType == "QuarantineParking")
                {
                    SQLQuery = "spGetQuarantineLocation";
                    string route = GetRouteForPlacard(ValidRequest.Placard);
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["LocationCode"].ToString(), reader["Location"].ToString()));

                        }
                    }

                    return new GeneralResponse<List<ValidData>>
                    {
                        Success = true,
                        Data = validInfo
                    };

                }

                //Wrong Gate 
                else if (ValidRequest.ResourceType == "Gate")
                {
                    SQLQuery = "GetGateInfo";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        //sqlcmd.Parameters.AddWithValue("@CatalogCode", ValidRequest.CatalogType);
                        sqlcmd.Parameters.AddWithValue("@CatalogType", ValidRequest.CatalogType);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["CatalogCode"].ToString(), reader["CatalogName"].ToString()));

                        }
                        reader.Close();
                    }

                    return new GeneralResponse<List<ValidData>>
                    {
                        Success = true,
                        Data = validInfo
                    };


                }


                else
                {
                    SQLQuery = "GetMasterDataWithName";
                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Catalogtype", ValidRequest.ResourceType);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validInfo.Add(new ValidData(reader["Code"].ToString(), reader["Name"].ToString()));

                        }
                    }


                }

                if (validInfo.Count < 1)
                {
                    return GlobalUtility<List<ValidData>>.Throw_Global_Exception("No data found in the database for the given resource type.", 702);
                }
                return new GeneralResponse<List<ValidData>>
                {
                    Success = true,
                    Data = validInfo
                };
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
    private string GetRouteForPlacard(string Placard)
    {
        try
        {
            string route = string.Empty;
            using (sqlcon)
            {
                string SQLQuery = "GetGenericRouteByPlacard";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Placard", string.IsNullOrEmpty(Placard) ? "" : Placard);
                    SqlDataReader reader = sqlcmd.ExecuteReader();


                    while (reader.Read())
                    {
                        route = reader["Route"].ToString();
                    }
                    reader.Close();

                    //Commented - Same as Web Application  
                    if (Placard.StartsWith("MSPLWI"))
                    {

                        route = "Warehouse";
                    }


                }

            }
            return route;
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

    public GeneralResponse<List<PictureRequest>> GetPictureRequests(LookupRequest lookup)
    {
        try
        {
            List<PictureRequest> pictureRequests = new List<PictureRequest>();
            using (sqlcon)
            {
                string SQLQuery = "spGetPictureRequests";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserCode", lookup.UserCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pictureRequests.Add(new PictureRequest
                        {
                            TrailerID = reader["TrailerID"].ToString(),
                            ReferenceKey = reader["ReferenceKey"].ToString(),
                            ActionType = reader["ActionType"].ToString(),
                            Location = reader["Location"].ToString(),
                            LocationCode = reader["LocationCode"].ToString(),
                            Placard = reader["Placard"].ToString(),
                            ScanTime = reader["ScanTime"].ToString(),
                            ActionDetails = reader["ActionDetails"].ToString(),
                            PictureCount = "1",
                            PictureRequestID = reader["PictureRequestID"].ToString()
                        });
                    }
                }
            }
            return new GeneralResponse<List<PictureRequest>> { Success = true, Data = pictureRequests };
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



    public ValidResponseFormat CheckPictureStatus(PictureRequest picture)
    {

        try
        {
            SqlCommand sqlcmd = new SqlCommand("CheckPictureStatus", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@PictureRequestID", picture.PictureRequestID);
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

    public GeneralResponse<LookupResponseData> getTrailerInfo(string TrailerID)
    {
        try
        {
            LookupResponseData response = new LookupResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetTrailerDetailsForTrailerID";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.TrailerID = reader["TrailerID"].ToString();
                            response.Comment = reader["Comment"].ToString();
                            response.FacilityCode = reader["FacilityCode"].ToString();
                            response.FacilityName = reader["FacilityName"].ToString();
                            response.LoadType = reader["LoadType"].ToString();
                            response.LoadTypeCode = reader["LoadTypeCode"].ToString();
                            response.Location = reader["Location"].ToString();
                            response.LocationCode = reader["LocationCode"].ToString();
                            response.LocationTypeCode = reader["LocationTypeCode"].ToString();
                            response.TrailerStatus = reader["TrailerStatus"].ToString();
                            response.TrailerStatusCode = reader["TrailerStatusCode"].ToString();
                            response.Placard = reader["Placard"].ToString();
                            response.YardPass = reader["YardPass"].ToString();
                            response.Flag = reader["FlagCode"].ToString();
                            response.RoutePool = reader["RoutePool"].ToString();
                            response.TrailerTypeCode = reader["TrailerTypeBit"].ToString();
                            response.TrailerType = reader["TrailerTypeCode"].ToString();
                        }

                    }
                }

            }
            if (response.TrailerID == null)
            {
                return GlobalUtility<LookupResponseData>.Throw_Global_Exception("TrailerID not found.", 700);
            }
            return new GeneralResponse<LookupResponseData>
            {
                Success = true,
                Data = response
            };
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
    public GeneralResponse<List<Sequence>> getDockSequenceDetails(string DoorGroupCode, string FacilityCode)
    {
        try
        {
            List<Sequence> sequence = new List<Sequence>();
            using (sqlcon)
            {
                string SQLQuery = "getLocationsForDoorType";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@DoorTypeCode", DoorGroupCode);
                    sqlcmd.Parameters.AddWithValue("@FacilityCode", FacilityCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sequence.Add(new Sequence { TrailerID = reader["TrailerID"].ToString(), SequentialBarcode = reader["Barcode"].ToString(), TrailerStatusCode = reader["TrailerStatusCode"].ToString(), Location = reader["Location"].ToString(), LocationTypeCode = reader["LocationTypeCode"].ToString(), LocationCode = reader["LocationCode"].ToString(), Placard = reader["Placard"].ToString() });
                    }
                }
            }
            return new GeneralResponse<List<Sequence>> { Success = true, Data = sequence };
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

    internal ValidResponseFormat getHelpCall(HelpCallRequest lookupRequest)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("InsHelpHistory", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Issue", lookupRequest.IssueCode);
            sqlcmd.Parameters.AddWithValue("@Description", lookupRequest.Description);
            sqlcmd.Parameters.AddWithValue("@UserCode", lookupRequest.UserCode);
            sqlcmd.Parameters.AddWithValue("@ScanID", lookupRequest.ScanID);
            sqlcmd.Parameters.AddWithValue("@ScanTime", lookupRequest.ScanTime);
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

    public GeneralResponse<DispatchStatusResponse> GetDispatchStatus(LookupRequest lookupRequest)
    {
        try
        {
            DispatchStatusResponse rf = new DispatchStatusResponse();
            SqlCommand sqlcmd = new SqlCommand("spCheckDispatchStatus", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;

            sqlcmd.Parameters.AddWithValue("@DispatchID", lookupRequest.DispatchID);
            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        rf.DispatchStatus = reader["DispatchStatus"].ToString();

                    }
                    else
                    {
                        return GlobalUtility<DispatchStatusResponse>.Throw_Global_Exception("DispatchID not found", 709);

                    }
                }

            }
            return new GeneralResponse<DispatchStatusResponse>
            {
                Success = true,
                Data = rf
            };

        }
        catch (Exception ex)
        {
            return GlobalUtility<DispatchStatusResponse>.Throw_Global_Exception(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    internal GeneralResponse<FetchSealResponse> getSealnumberByContainerNumber(FetchSealRequest lookupRequest)
    {
        try
        {


            using (sqlcon)
            {
                string SQLQuery = "GetSealNumByContainerNum";

                db.OpenConnection(ref sqlcon);
                FetchSealResponse response = new FetchSealResponse();
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@ContainerNumber", lookupRequest.ContainerNumber);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {

                            response.SealNumber = reader["SealNumber"].ToString();
                            response.RenbanNumber = reader["RenbanNumber"].ToString();
                        }
                    }
                    reader.Close();
                }
                if (response.SealNumber == null)
                {
                    return GlobalUtility<FetchSealResponse>.Throw_Global_Exception("No Seal Number Found.", 710);
                }


                return new GeneralResponse<FetchSealResponse> { Success = true, Data = response };
            }
        }

        catch (Exception ex)
        {
            return GlobalUtility<FetchSealResponse>.Throw_Global_Exception(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    /*Fetch Container*/
    internal GeneralResponse<FetchSealResponse> getSealnumberByContainerDetails(FetchSealRequest lookupRequest)
    {
        try
        {

            string route = "";
            string Location = "";
            using (sqlcon)
            {
                string SQLQuery = "GetSealNumByContainerNum";

                string SQLParkingSlot = "GetArrivalParkingSpaceForTrailerAndContainer";

                string SqlGate = "FetchGateByLocation";
                #region Container

                db.OpenConnection(ref sqlcon);
                FetchSealResponse response = new FetchSealResponse();
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@ContainerNumber", lookupRequest.ContainerNumber);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.SealNumber = reader["SealNumber"].ToString();
                            response.RenbanNumber = reader["RenbanNumber"].ToString();
                            response.Carrier = reader["Carrier"].ToString();
                            response.Equipment = reader["EquipmentSize"].ToString();
                            response.Location = reader["LocationCode"].ToString();
                            route = response.RenbanNumber.Substring(0, 1);
                        }
                    }
                    reader.Close();
                }
                db.CloseConnection(ref sqlcon);

                #endregion Container

                #region Location
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLParkingSlot, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Route", route);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.ParkingSlot = reader["Location"].ToString();
                            Location = reader["Location"].ToString();
                        }
                        else
                        {
                            return GlobalUtility<FetchSealResponse>.Throw_Global_Exception(" No parking Spot available. Contact your Yard LP." + response.ParkingSlot, 703);
                        }

                    }
                }
                db.CloseConnection(ref sqlcon);
                #endregion Location

                #region GateLocation
                db.OpenConnection(ref sqlcon);

                using (SqlCommand sqlcmd = new SqlCommand(SqlGate, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Location", Location);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.Gate = reader["Yard"].ToString();
                        }
                        else
                        {
                            return GlobalUtility<FetchSealResponse>.Throw_Global_Exception(" No parking Spot available. Contact your Yard LP." + response.AvailableSlot, 703);
                        }
                    }
                }
                db.CloseConnection(ref sqlcon);

                #endregion

                db.CloseConnection(ref sqlcon);

                if (response.SealNumber == null)
                {
                    return GlobalUtility<FetchSealResponse>.Throw_Global_Exception("Data not Found.", 710);
                }


                return new GeneralResponse<FetchSealResponse> { Success = true, Data = response };
            }
        }

        catch (Exception ex)
        {
            return GlobalUtility<FetchSealResponse>.Throw_Global_Exception(ex.Message, 700);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    /*End Fetch Container*/

    public GeneralResponse<LocationTrailerResponseData> CheckSequentialBarcode(string SequentialBarcode)
    {
        try
        {
            LocationTrailerResponseData response = new LocationTrailerResponseData();

            using (sqlcon)
            {
                string SQLQuery = "CheckSequenceTrailer";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@SequentialBarcode", SequentialBarcode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.TrailerID = reader["TrailerID"].ToString();
                            response.TrailerType = reader["TrailerTypeBit"].ToString();
                            response.IsInPool = reader["IsInPool"].ToString();
                            response.Flag = reader["Flagged"].ToString();
                            response.Placard = reader["Placard"].ToString();
                            response.SequentialBarcode = SequentialBarcode;

                        }

                    }
                }

            }
            if (response.TrailerID == null)
            {
                return GlobalUtility<LocationTrailerResponseData>.Throw_Global_Exception("No trailer found for barcode.", 711);
            }
            return new GeneralResponse<LocationTrailerResponseData> { Success = true, Data = response };
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

    public GeneralResponse<List<DispatchResponseData>> getDispatchData(string UserCode, string FacilityCode, string GroupCode)
    {
        try
        {
            List<DispatchResponseData> response = new List<DispatchResponseData>();

            using (sqlcon)
            {
                string SQLQuery = "MoveRequestForMobileCloud";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                    sqlcmd.Parameters.AddWithValue("@FacilityCode", FacilityCode);
                    sqlcmd.Parameters.AddWithValue("@GroupName", GroupCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.Add(new DispatchResponseData
                            {
                                DispatchID = reader["DispatchID"].ToString(),
                                TrailerID = reader["TrailerID"].ToString(),
                                FromLocation = reader["FromLocation"].ToString(),
                                ToLocation = reader["ToLocation"].ToString(),
                                Message = reader["DispatchMessage"].ToString(),
                                DispatchMessage = reader["DispatchMessage"].ToString(),
                                LoadType = reader["LoadType"].ToString(),
                                DispatchStatus = reader["DispatchStatus"].ToString(),
                                Priority = reader["DispatchPriority"].ToString(),
                                PriorityCode = reader["PriorityCode"].ToString(),
                                Store = reader["Store"].ToString(),
                                TrailerStatus = reader["TrailerStatus"].ToString(),
                                Run = reader["Run"].ToString(),
                                DriverGroup = reader["DriverGroup"].ToString(),
                                FromDoorCode = reader["FromDoorCode"].ToString(),
                                ToDoorCode = reader["ToDoorCode"].ToString(),
                                Timestamp = reader["Timestamp"].ToString(),
                                Flag = reader["Flag"].ToString()
                            });

                        }

                    }
                }

            }
            return new GeneralResponse<List<DispatchResponseData>> { Success = true, Data = response };
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

    public GeneralResponse<InsuranceStatusResponseData> getInsuranceStatus(string ScacCode)
    {
        try
        {
            InsuranceStatusResponseData response = new InsuranceStatusResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetInsuranceStatus";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@ScacCode", ScacCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.InsuranceStatus = reader["InsuranceStatus"].ToString();

                        }

                    }
                }

            }
            return new GeneralResponse<InsuranceStatusResponseData> { Success = true, Data = response };
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

    public ValidResponseFormat UpdSequentialBarcode(UpdSequenceRequestData updsequential)
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand("UpdBarcode", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@TrailerID", updsequential.TrailerID);
            sqlcmd.Parameters.AddWithValue("@SequentialBarcode", updsequential.SequentialBarcode);

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


    public ValidResponseFormat InsUpdVisitorLog(UpdVisitorLogRequestData updVisitorlogRequestData)
    {
        try
        {

            SqlCommand sqlcmd = new SqlCommand("InsVisitorsLog", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@DepartmentName", updVisitorlogRequestData.DepartmentName);
            sqlcmd.Parameters.AddWithValue("@VisitorName", updVisitorlogRequestData.VisitorName);
            sqlcmd.Parameters.AddWithValue("@BadgeNumber", updVisitorlogRequestData.BadgeNumber);
            sqlcmd.Parameters.AddWithValue("@CompanyName", updVisitorlogRequestData.CompanyName);
            sqlcmd.Parameters.AddWithValue("@ContactPerson", updVisitorlogRequestData.ContactPerson);
            sqlcmd.Parameters.AddWithValue("@UserCode", updVisitorlogRequestData.UserCode);
            sqlcmd.Parameters.AddWithValue("@ScanTime", updVisitorlogRequestData.TimeStamp);
            sqlcmd.Parameters.AddWithValue("@VisitType", updVisitorlogRequestData.VisitType);
            sqlcmd.Parameters.AddWithValue("@ScanID", updVisitorlogRequestData.ScanID);
            sqlcmd.Parameters.AddWithValue("@HandsetID ", updVisitorlogRequestData.DeviceID);
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

    public GeneralResponse<List<BadgeResponseData>> GetBadges()
    {
        try
        {
            List<BadgeResponseData> response = new List<BadgeResponseData>();

            using (sqlcon)
            {
                string SQLQuery = "GetBadgeNumbers";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.Add(new BadgeResponseData
                            {
                                BadgeNumber = reader["BadgeNumber"].ToString(),
                                ContactPerson = reader["ContactPerson"].ToString(),
                                VisitorName = reader["VisitorName"].ToString(),
                                DepartmentName = reader["Department"].ToString(),
                                Company = reader["CompanyName"].ToString(),
                                Code = reader["BadgeNumber"].ToString(),
                                Name = reader["BadgeNumber"].ToString()
                            });

                        }

                    }
                }

            }
            return new GeneralResponse<List<BadgeResponseData>> { Success = true, Data = response };
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


    public GeneralResponse<HookResponseData> getTrailerHookInfo(string TrailerID)
    {
        try
        {
            HookResponseData response = new HookResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetHookButNotDrop";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.CreatedBy = reader["CreatedBy"].ToString();
                            response.HookButNotDrop = reader["HookNotDrop"].ToString();
                            // response.PlaCard = reader["Placard"].ToString();
                            // response.TrailerStatus = reader["TrailerStatus"].ToString();
                        }
                        else
                        {
                            response.CreatedBy = "";
                            response.HookButNotDrop = "0";
                        }
                    }
                }

            }
            return new GeneralResponse<HookResponseData> { Success = true, Data = response };
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

    public GeneralResponse<GatePassResponseData> getGatePassInfo(string GatePass)
    {
        try
        {
            GatePassResponseData response = new GatePassResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetDriverNameForGatePass";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@GatePass", GatePass);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.DriverName = reader["DriverName"].ToString();
                            response.TractorNumber = reader["TractorNumber"].ToString();
                            response.Carrier = reader["InboundCarrier"].ToString();
                        }

                    }
                }

            }
            return new GeneralResponse<GatePassResponseData> { Success = true, Data = response };
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

    public GeneralResponse<CheckPlacardResponseData> getCheckPlacardInfo(string TrailerID, string Placard)
    {
        try
        {
            CheckPlacardResponseData response = new CheckPlacardResponseData();

            using (sqlcon)
            {
                string SQLQuery = "CheckPlacardWithTrailerID";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
                    sqlcmd.Parameters.AddWithValue("@Placard", Placard);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.CheckPlacard = reader["CheckPlacard"].ToString();
                        }

                    }
                }

            }
            return new GeneralResponse<CheckPlacardResponseData> { Success = true, Data = response };
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


    public GeneralResponse<PlacardResponseData> getPlacardInfo(string Placard)
    {
        try
        {
            PlacardResponseData response = new PlacardResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetPlacardDetailsForPlacardNew";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Placard", Placard);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.RouteRun = reader["Route"].ToString();


                        }

                    }
                }

            }
            return new GeneralResponse<PlacardResponseData> { Success = true, Data = response };
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

    public GeneralResponse<PreDepartureResponseData> getPreDepartureInfo(string TrailerID, string PlaCard, string YardPass, string UserCode)
    {
        try
        {
            PreDepartureResponseData response = new PreDepartureResponseData();

            using (sqlcon)
            {
                string SQLQuery = "CheckPreDeparture";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
                    sqlcmd.Parameters.AddWithValue("@Placard", PlaCard);
                    sqlcmd.Parameters.AddWithValue("@YardPass", YardPass);
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.CheckStatus = reader["Result"].ToString();

                        }

                    }
                }

            }
            return new GeneralResponse<PreDepartureResponseData>
            {
                Success = true,
                Data = response
            };
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

    public ValidResponseFormat UpdLogoutInfo(LogoutRequest logoutRequest)
    {
        try
        {

            SqlCommand sqlcmd = new SqlCommand("HandSetLogout", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@UserCode", logoutRequest.UserCode);
            sqlcmd.Parameters.AddWithValue("@LoggedOutTime", logoutRequest.LogoutTime);
            sqlcmd.Parameters.AddWithValue("@DeviceID", logoutRequest.DeviceID);

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

    // CTPAT Questions
    public GeneralResponse<List<FetchCTPATResponseData>> getCTPATQuestionsList(string CTPATType)
    {
        try
        {
            List<FetchCTPATResponseData> response = new List<FetchCTPATResponseData>();

            using (sqlcon)
            {
                string SQLQuery = "CTPATQuestionsList";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@CTPATType", CTPATType);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        response.Add(new FetchCTPATResponseData { Questions = reader["Questions"].ToString(), CTPATType = reader["CTPATtype"].ToString() });

                    }
                }

            }
            return new GeneralResponse<List<FetchCTPATResponseData>> { Success = true, Data = response };
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

    //End CTPAT Questions


    public GeneralResponse<List<DockDoorResponse>> getDockDoorLocationDetails(string UserCode)
    {
        try
        {
            List<DockDoorResponse> dockdoorresponse = new List<DockDoorResponse>();
            using (sqlcon)
            {
                string SQLQuery = "GetDockDoorReport";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dockdoorresponse.Add(new DockDoorResponse
                        {
                            Location = reader["Location"].ToString(),
                            LocationCode = reader["DoorCode"].ToString(),
                            TrailerID = reader["TrailerID"].ToString(),
                            SequentialBarCode = reader["SequentialBarcode"].ToString(),
                            Scac = reader["Scac"].ToString(),
                            Carrier = reader["Carrier"].ToString(),
                            TrailerNumber = reader["TrailerNumber"].ToString(),
                            TrailerStatus = reader["TrailerStatus"].ToString(),
                            LoadType = reader["LoadType"].ToString(),
                            Comment = reader["Comment"].ToString(),
                            Route = reader["Route"].ToString(),
                            Run = reader["Run"].ToString(),
                            Placard = reader["Placard"].ToString(),
                            UnloadStart = reader["UnloadStart"].ToString(),
                            UnloadEnd = reader["UnloadEnd"].ToString(),
                            ReloadStart = reader["ReloadStart"].ToString(),
                            ReloadEnd = reader["ReloadEnd"].ToString(),
                            YardPass = reader["YardPass"].ToString(),
                            ULDate = reader["ULDate"].ToString(),
                            ULStart = reader["ULStart"].ToString(),
                            ULEnd = reader["ULEnd"].ToString(),
                            PlannedReloadDate = reader["PlannedReloadDate"].ToString(),
                            PlannedReloadStart = reader["PlannedReloadStart"].ToString(),
                            PlannedReloadEnd = reader["PlannedReloadEnd"].ToString(),
                            Period = reader["Period"].ToString(),
                            LoadTypeCode = reader["LoadTypeCode"].ToString(),
                            TrailerStatusCode = reader["TrailerStatusCode"].ToString(),
                            TrailerType = reader["TrailerType"].ToString(),
                            Container = reader["Container"].ToString(),
                            // IsMagnoliaDoor = reader["IsMagnoliaDoor"].ToString(),
                            LastAction = reader["LastAction"].ToString(),
                            LastActionOn = reader["LastActionOn"].ToString(),
                            ULCounter = reader["ULCounter"].ToString(),
                            RecordID = reader["RecordId"].ToString(),
                            CTIID = reader["CTIID"].ToString()
                        });
                    }
                }
            }
            return new GeneralResponse<List<DockDoorResponse>> { Success = true, Data = dockdoorresponse };
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



    public GeneralResponse<List<DockDoorScheduleResponse>> getDockDoorScheduleLocationDetails(string UserCode, string DoorCode)
    {
        try
        {
            List<DockDoorScheduleResponse> dockdoorscheduleresponse = new List<DockDoorScheduleResponse>();
            using (sqlcon)
            {
                string SQLQuery = "GetDockDoorScheduleForDoor";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                    sqlcmd.Parameters.AddWithValue("@DoorCode", DoorCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dockdoorscheduleresponse.Add(new DockDoorScheduleResponse
                        {
                            Location = reader["Location"].ToString(),
                            LocationCode = reader["DoorCode"].ToString(),
                            TrailerID = reader["TrailerID"].ToString(),
                            SequentialBarCode = reader["SequentialBarcode"].ToString(),
                            Scac = reader["Scac"].ToString(),
                            Carrier = reader["Carrier"].ToString(),
                            TrailerNumber = reader["TrailerNumber"].ToString(),
                            TrailerStatus = reader["TrailerStatus"].ToString(),
                            LoadType = reader["LoadType"].ToString(),
                            Comment = reader["Comment"].ToString(),
                            Route = reader["Route"].ToString(),
                            Run = reader["Run"].ToString(),
                            Placard = reader["Placard"].ToString(),
                            // YardPass = reader["YardPass"].ToString(),
                            ULDate = reader["ULDate"].ToString(),
                            ULStart = reader["ULStart"].ToString(),
                            ULEnd = reader["ULEnd"].ToString(),
                            PlannedReloadDate = reader["PlannedReloadDate"].ToString(),
                            PlannedReloadStart = reader["PlannedReloadStart"].ToString(),
                            PlannedReloadEnd = reader["PlannedReloadEnd"].ToString(),
                            Period = reader["Period"].ToString(),
                            LastAction = reader["LastAction"].ToString(),
                            LastActionOn = reader["LastActionOn"].ToString(),
                            RecordID = reader["RecordId"].ToString(),
                            CTIID = reader["CTIID"].ToString()

                        });
                    }
                }
            }
            return new GeneralResponse<List<DockDoorScheduleResponse>> { Success = true, Data = dockdoorscheduleresponse };
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


    public ValidResponseFormat checkTrailer(string TrailerID)
    {
        try
        {
            string result = "";
            SqlCommand sqlcmd = new SqlCommand("CheckTrailerInPoolWithGeneralresponse", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                result = sqlcmd.ExecuteScalar().ToString();


            }
            if (string.IsNullOrEmpty(result))
            {
                return new ValidResponseFormat { Success = false };
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

    public ValidResponseFormat CheckPreDepartureData(string TrailerID, string PlaCard, string YardPass, string UserCode)
    {
        try
        {
            string result;
            SqlCommand sqlcmd = new SqlCommand("CheckPreDepartureNew", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
            sqlcmd.Parameters.AddWithValue("@Placard", PlaCard);
            sqlcmd.Parameters.AddWithValue("@YardPass", YardPass);
            sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                result = sqlcmd.ExecuteScalar().ToString();

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



    public GeneralResponse<List<SequentialResponseData>> GetSequentialCompleteInfo()
    {
        try
        {
            List<ValidData> validInfo = new List<ValidData>();

            using (sqlcon)
            {
                string SQLQuery = "GetYardcheckSequenceZone";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {

                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        validInfo.Add(new ValidData(reader["CatalogCode"].ToString(), reader["CatalogName"].ToString()));

                    }
                }

            }
            List<SequentialResponseData> Groups = new List<SequentialResponseData>();
            foreach (ValidData vd in validInfo)
            {
                SequentialResponseData seqRData = new SequentialResponseData();
                seqRData.Code = vd.Code;
                seqRData.Name = vd.Name;
                List<SequentialResponseDataData> validDoors = new List<SequentialResponseDataData>();
                using (sqlcon)
                {

                    string SQLQuery = "GetYardcheckSequenceLocation";

                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.Parameters.AddWithValue("@GroupCode", vd.Code);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            validDoors.Add(new SequentialResponseDataData
                            {
                                Zone = reader["Zone"].ToString()
                                             ,
                                LocationPrefix = reader["LocationPrefix"].ToString()
                                               ,
                                Name = reader["Name"].ToString()

                                                  ,
                                SortOrder = reader["SortOrder"].ToString()
                            });


                        }
                    }

                }
                seqRData.Locations = validDoors;

                Groups.Add(seqRData);
            }
            return new GeneralResponse<List<SequentialResponseData>> { Success = true, Data = Groups };

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

    public GeneralResponse<LocationResponseData> getTrailerInfoByLocation(string LocationCode)
    {
        try
        {
            LocationResponseData response = new LocationResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetTrailer_For_Location_For_SequenceYardcheck";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@LocationCode", LocationCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.Location = reader["Location"].ToString();
                            response.LocationCode = reader["LocationCode"].ToString();
                            response.LocationTypeCode = reader["LocationTypeCode"].ToString();

                        }

                    }
                }

            }
            if (response.Location == null)
            {
                return GlobalUtility<LocationResponseData>.Throw_Global_Exception("Location not found.", 703);
            }
            return new GeneralResponse<LocationResponseData> { Success = true, Data = response };
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

    //Arrival
    public GeneralResponse<FetchArrivalResponseData> getArrivalInfo(ArrivalRequest lookupRequest)
    {
        try
        {
            string Placard = lookupRequest.Placard, UserCode = lookupRequest.UserCode, TrailerID = lookupRequest.TrailerID;
            FetchArrivalResponseData response = new FetchArrivalResponseData();
            string route = "";
            string Location = "";

            using (sqlcon)
            {

                String ValidPlacard;


                string SqlPlacardValidate = "CheckValidPlacard";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SqlPlacardValidate, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
                    sqlcmd.Parameters.AddWithValue("@Placard", Placard);
                    ValidPlacard = sqlcmd.ExecuteScalar().ToString();
                }
                db.CloseConnection(ref sqlcon);

                if (ValidPlacard == "Valid")
                {
                    //return GlobalUtility<FetchArrivalResponseData>.Throw_Global_Exception("Data not found." + response.Route + response.AvailableSlot, 703);

                    string SqlGenericRoute = "GetGenericRouteByPlacard";

                    string SqlGenericLocation = "GetArrivalParkingSpaceForEmptyAndGeneric";

                    string SqlGateLocation = "FetchGateByLocation";

                    #region Route
                    db.OpenConnection(ref sqlcon);

                    using (SqlCommand sqlcmd = new SqlCommand(SqlGenericRoute, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Placard", Placard);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                response.Route = reader["Route"].ToString();
                            }
                        }
                    }
                    db.CloseConnection(ref sqlcon);

                    #endregion


                    #region Location
                    db.OpenConnection(ref sqlcon);

                    using (SqlCommand sqlcmd = new SqlCommand(SqlGenericLocation, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Route", route);
                        sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                response.AvailableSlot = reader["Location"].ToString();
                                Location = reader["Location"].ToString();
                            }
                        }
                    }
                    db.CloseConnection(ref sqlcon);

                    #endregion


                    #region GateLocation
                    db.OpenConnection(ref sqlcon);

                    using (SqlCommand sqlcmd = new SqlCommand(SqlGateLocation, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Location", Location);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                response.Gate = reader["Yard"].ToString();
                            }
                            else
                            {
                                return GlobalUtility<FetchArrivalResponseData>.Throw_Global_Exception(" No parking Spot available. Contact your Yard LP." + response.AvailableSlot, 703);
                            }
                        }
                    }
                    db.CloseConnection(ref sqlcon);

                    #endregion

                    if (Placard.ToString().ToUpper().StartsWith("MSPLEXPI"))
                    {
                        response.Redirect = "EXPEDITE INTERNATIONAL";
                        response.RoutePool = "International Route";
                    }
                    else
                    {
                        if (Placard.ToString().ToUpper().StartsWith("MSPLEXPD"))
                        {
                            response.RoutePool = "Domestic Routes";
                        }
                        response.Redirect = "GENERIC PLACARD";
                    }
                    return new GeneralResponse<FetchArrivalResponseData> { Success = true, Data = response };
                }
                else
                {


                    string SQLQuery = "GetCheckSheetScanPtData";

                    string SqlRoute = "GetRoutePoolUsingRoute";

                    string SqlSlot = "GetSingleArrivalParkingSpaceForTrailerAndContainer";

                    string SqlGate = "FetchGateByLocation";

                    #region sheetscanpt

                    db.OpenConnection(ref sqlcon);
                    using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@CheckSheetScanpt", Placard);
                        sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                route = reader["RTE"].ToString();

                                response.Placard = reader["ChecksheetScanpt"].ToString();
                                response.Route = reader["RTE"].ToString();
                                response.YardDate = reader["YardDate"].ToString();
                                response.YardTime = reader["YardTime"].ToString();
                                response.UnloadDoors = reader["ULDoors"].ToString();
                                response.UnloadStart = reader["ULStart"].ToString();
                                response.UnloadEnd = reader["ULEnd"].ToString();
                                response.ProductionDate = reader["PUD"].ToString();
                                response.UnloadDate = reader["ULDate"].ToString();
                                response.Comment = reader["ArrivalComment"].ToString();


                            }

                        }
                    }
                    db.CloseConnection(ref sqlcon);

                    #endregion

                    #region Route
                    db.OpenConnection(ref sqlcon);

                    using (SqlCommand sqlcmd = new SqlCommand(SqlRoute, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Route", route);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                response.RoutePool = reader["CatalogType"].ToString();
                            }
                        }
                    }
                    db.CloseConnection(ref sqlcon);

                    #endregion

                    #region availableslot
                    db.OpenConnection(ref sqlcon);

                    using (SqlCommand sqlcmd = new SqlCommand(SqlSlot, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Route", route);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                response.AvailableSlot = reader["Location"].ToString();
                                Location = reader["Location"].ToString();
                            }
                            else
                            {
                                return GlobalUtility<FetchArrivalResponseData>.Throw_Global_Exception(" No parking Spot available. Contact your Yard LP." + response.AvailableSlot, 703);
                            }
                        }
                    }
                    db.CloseConnection(ref sqlcon);
                    #endregion

                    #region GateLocation
                    db.OpenConnection(ref sqlcon);

                    using (SqlCommand sqlcmd = new SqlCommand(SqlGate, sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Location", Location);
                        SqlDataReader reader = sqlcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                response.Gate = reader["Yard"].ToString();
                            }
                            else
                            {
                                return GlobalUtility<FetchArrivalResponseData>.Throw_Global_Exception(" No parking Spot available. Contact your Yard LP." + response.AvailableSlot, 703);
                            }
                        }
                    }
                    db.CloseConnection(ref sqlcon);

                    #endregion
                    if (response.RoutePool == "International Route")
                    {
                        response.Redirect = "EXPEDITE INTERNATIONAL";
                        return new GeneralResponse<FetchArrivalResponseData> { Success = true, Data = response };
                    }


                }

                if (string.IsNullOrEmpty(response.Placard))
                {
                    return GlobalUtility<FetchArrivalResponseData>.Throw_Global_Exception("Data not found." + response.Route + response.AvailableSlot, 703);
                }
                return new GeneralResponse<FetchArrivalResponseData> { Success = true, Data = response };
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
    //End Arival

    //DepartureResponse
    public GeneralResponse<FetchDepartureResponseData> getDepartureInfo(string SequentialBarcode)
    {
        try
        {
            FetchDepartureResponseData response = new FetchDepartureResponseData();

            using (sqlcon)
            {
                string SQLQuery = "FetchDataForDeparture";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@SequentialBarcode", SequentialBarcode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.Trailer_ContainerID = reader["TrailerID"].ToString();
                            response.Placard = reader["Placard"].ToString();
                            response.YardPass = reader["YardPass"].ToString();
                            response.SealNo = reader["SealNumber"].ToString();
                            response.Carrier = reader["SCAC"].ToString();
                            response.Comment = reader["Comment"].ToString();
                            response.RoutePool = reader["RoutePool"].ToString();
                            response.TrailerTypeCode = reader["TrailerType"].ToString();

                        }

                    }
                }

            }
            using (sqlcon)
            {
                string SQLQuery = "CheckGenericPlacardInCheckSheet";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Placard", response.Placard);
                    response.IsGenericPlacard = sqlcmd.ExecuteScalar().ToString();
                }

            }
            if (response.Trailer_ContainerID == null)
            {
                return GlobalUtility<FetchDepartureResponseData>.Throw_Global_Exception("Location not found.", 703);
            }
            return new GeneralResponse<FetchDepartureResponseData> { Success = true, Data = response };
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

    //End Departure Response


    //Check Route 
    public GeneralResponse<FetchDepartureResponseData> ValidateForPlacard(string Trailer_ContainerID, string Placard)
    {
        try
        {
            FetchDepartureResponseData response = new FetchDepartureResponseData();
            using (sqlcon)
            {
                string SQLQuery = "CheckRoutePoolByPlacard";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", Trailer_ContainerID);
                    sqlcmd.Parameters.AddWithValue("@Placard", Placard);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.Result = reader["Result"].ToString();
                        }
                    }
                }
            }
            return new GeneralResponse<FetchDepartureResponseData> { Success = true, Data = response };
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

    //End Check Route 


    public ValidResponseFormat CheckDepartureEligibility(DepartureRequest depart)
    {
        try
        {
            if (depart.TrailerTypeCode == "Container" && depart.YardPass.StartsWith("MSYPWR"))
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Can not depart container using offsite yardpass.", 720);
            }
            bool routePoolCheck = true;
            using (sqlcon)
            {
                string SQLQuery = "CheckRoutePoolByPlacard";
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", depart.Trailer_ContainerID);
                    sqlcmd.Parameters.AddWithValue("@Placard", depart.Placard);
                    db.OpenConnection(ref sqlcon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            if (reader["Result"].ToString() == "0")
                            {
                                routePoolCheck = false;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            db.CloseConnection(ref sqlcon);
            if (routePoolCheck == false)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Pool group can only be changed by an admin.", 720);
            }
            using (SqlConnection con = new SqlConnection())
            {
                string SQLQuery = "CheckPreDeparture";
                using (SqlCommand sqlcmd1 = new SqlCommand(SQLQuery, con))
                {
                    sqlcmd1.CommandType = CommandType.StoredProcedure;
                    sqlcmd1.Parameters.AddWithValue("@YardPass", string.IsNullOrEmpty(depart.YardPass) ? "" : depart.YardPass);
                    sqlcmd1.Parameters.AddWithValue("@Placard", depart.Placard);
                    sqlcmd1.Parameters.AddWithValue("@TrailerID", depart.Trailer_ContainerID);
                    sqlcmd1.Parameters.AddWithValue("@UserCode", depart.UserCode);
                    sqlcmd1.Parameters.AddWithValue("@SealNumber", depart.Seal);
                    con.ConnectionString = db.GetConnectionString();
                    con.Open();
                    sqlcmd1.ExecuteScalar();
                }
            }

            int flag = 1;
            string ctpatDID = "0";
            string ctpatCID = "0";
            if (depart.Placard.StartsWith("MSPLEXPI") || depart.Placard.StartsWith("MSPLQA") || depart.RoutePool == "INTR" || depart.RoutePool == "International Route" || depart.Trailer_ContainerID.Substring(4, 1).ToUpper() == "U")
            {


                using (sqlcon)
                {
                    string SQLQuery = "CheckCTPATStatus";
                    using (SqlCommand sqlcmd2 = new SqlCommand(SQLQuery, sqlcon))
                    {
                        sqlcmd2.CommandType = CommandType.StoredProcedure;
                        sqlcmd2.Parameters.AddWithValue("@TrailerID", depart.Trailer_ContainerID);
                        db.OpenConnection(ref sqlcon);
                        SqlDataReader reader = sqlcmd2.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                ctpatDID = reader["CTPATDID"].ToString();
                                ctpatCID = reader["CTPATCID"].ToString();
                            }
                        }

                        reader.Close();
                    }
                }
                db.CloseConnection(ref sqlcon);

            }

            if (ctpatDID == "0" && depart.Placard.StartsWith("MSPLEXPI"))
            {
                flag = 0;
            }

            if ((ctpatDID == "0" && ctpatCID == "0") && (depart.Placard.StartsWith("MSPLQA") && depart.Placard.StartsWith("MSPLCQA")))
            {

                flag = 0;
            }
            if ((depart.RoutePool == "International Route" || depart.RoutePool == "INTR" || depart.Trailer_ContainerID.Substring(4, 1).ToUpper() == "U") && ctpatCID == "0" && ctpatDID == "0" && !depart.Placard.StartsWith("MSPLEXPI"))
            {
                flag = 0;
            }

            if ((flag == 0) && (!(depart.Placard.StartsWith("MSPLCQA"))))
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Conveyance CTPAT has not been performed for the trailer/container. Trailer/container cannot be departed.", 720);
            }
            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 720);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }





    public GeneralResponse<List<YardcheckSequence>> getYardSequenceDetails(string UserCode, string Zone, string Prefix, string FacilityCode)
    {
        try
        {
            List<YardcheckSequence> sequence = new List<YardcheckSequence>();
            using (sqlcon)
            {
                string SQLQuery = "GetLocationsByPrefixNew";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Prefix", Prefix);
                    sqlcmd.Parameters.AddWithValue("@Zone", Zone);
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                    sqlcmd.Parameters.AddWithValue("@FacilityCode", FacilityCode);

                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sequence.Add(new YardcheckSequence { Location = reader["Name"].ToString(), LocationTypeCode = reader["LocationTypeCode"].ToString(), LocationCode = reader["Code"].ToString() });
                    }
                }
            }
            return new GeneralResponse<List<YardcheckSequence>> { Success = true, Data = sequence };
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

    public GeneralResponse<List<LocationDetails>> getLocationDetails(string FacilityCode)
    {
        try
        {
            List<LocationDetails> sequence = new List<LocationDetails>();
            using (sqlcon)
            {
                string SQLQuery = "GetLocationsForFacility";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    //sqlcmd.Parameters.AddWithValue("@DoorTypeCode", DoorGroupCode);
                    sqlcmd.Parameters.AddWithValue("@FacilityCode", FacilityCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sequence.Add(new LocationDetails { Name = reader["Location"].ToString(), Type = reader["LocationTypeCode"].ToString(), Code = reader["LocationCode"].ToString() });
                    }
                }
            }
            return new GeneralResponse<List<LocationDetails>> { Success = true, Data = sequence };
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

    public GeneralResponse<List<DropLocation>> getDropLocationDetails(string FacilityCode)
    {
        try
        {
            List<DropLocation> sequence = new List<DropLocation>();
            using (sqlcon)
            {
                string SQLQuery = "GetDropLocationsForFacility";

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    //sqlcmd.Parameters.AddWithValue("@DoorTypeCode", DoorGroupCode);
                    sqlcmd.Parameters.AddWithValue("@FacilityCode", FacilityCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sequence.Add(new DropLocation { Name = reader["Location"].ToString(), Type = reader["LocationTypeCode"].ToString(), Code = reader["LocationCode"].ToString() });
                    }
                }
            }
            return new GeneralResponse<List<DropLocation>> { Success = true, Data = sequence };
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


    public ValidResponseFormat ValidatePlacardRoute(RoutePoolRequestData RoutePoolRequest)
    {
        try
        {

            string Result = "";

            SqlCommand sqlcmd = new SqlCommand("CheckRoutePoolByPlacard", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@TrailerID", RoutePoolRequest.TrailerID);
            sqlcmd.Parameters.AddWithValue("@Placard", RoutePoolRequest.Placard);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                Result = sqlcmd.ExecuteScalar().ToString(); ;
            }
            if (Result == "1")
            {
                return new ValidResponseFormat { Success = true };
            }
            else if (Result == "3")
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Wrong Placard", 769);
            }
            else
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Pool group can only be changed by an admin", 769);
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



    public ValidResponseFormat CheckSealByTrailerID(CheckSealRequestData RoutePoolRequest)
    {
        try
        {
            SqlDataReader reader;
            int flag = 0;
            SqlCommand sqlcmd = new SqlCommand("CheckSeal", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@TrailerID", RoutePoolRequest.TrailerID);
            sqlcmd.Parameters.AddWithValue("@Seal", RoutePoolRequest.Seal);

            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                reader = sqlcmd.ExecuteReader();
                if (reader.HasRows)
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                return new ValidResponseFormat { Success = true };
            }
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Seal Mismatch", 779);

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


    public GeneralResponse<DamageLookupResponseData> getDamageTrailerInfo(string TrailerID)
    {
        try
        {
            DamageLookupResponseData response = new DamageLookupResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetDamagedTrailerDetailsForTrailerID";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@TrailerID", TrailerID);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.TrailerID = reader["TrailerID"].ToString();
                            response.Area = reader["Area"].ToString();
                            response.Issue = reader["Issue"].ToString();
                            response.ScannedOn = reader["ScannedOn"].ToString();
                            response.ScannedBy = reader["ScannedBy"].ToString();
                            response.Comment = reader["Comment"].ToString();
                            response.Flag = reader["FlagCode"].ToString();
                            response.Picture = "https://mtm.exotrac.biz/InspectionImages/" + reader["PicturePath"].ToString();

                            string Pictures = reader["PicturePath"].ToString();
                            string URL = "https://mtm.exotrac.biz/InspectionImages/";
                            string[] imagesArray = Pictures.TrimEnd(',').Split(',');
                            string picturesPathWithURL = "";
                            for (int i = 0; i < imagesArray.Length; i++)
                            {
                                picturesPathWithURL = URL + imagesArray[i] + "," + picturesPathWithURL;
                            }


                            response.Picture = picturesPathWithURL.TrimEnd(',');

                        }

                    }
                }

            }
            if (response.TrailerID == null)
            {
                return GlobalUtility<DamageLookupResponseData>.Throw_Global_Exception("TrailerID not found.", 700);
            }
            return new GeneralResponse<DamageLookupResponseData> { Success = true, Data = response };
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


    public ValidResponseFormat checkPlacardRegistered(PlacardRequest placardrequest)
    {
        try
        {

            SqlCommand sqlcmd = new SqlCommand("CheckRegisteredPlacard", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Placard", placardrequest.Placard);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();

            }


            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 789);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    public GeneralResponse<TotalUserMoveResponseData> getTotalMoveInfo(string UserCode)
    {
        try
        {
            TotalUserMoveResponseData response = new TotalUserMoveResponseData();

            using (sqlcon)
            {
                string SQLQuery = "GetMoveDetailsByUser";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserCode", UserCode);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.AcceptedCount = reader["Accepted"].ToString();
                            response.HookedCount = reader["Hooked"].ToString();
                            response.DroppedCount = reader["Dropped"].ToString();

                            response.UserCode = reader["UserCode"].ToString();


                        }

                    }
                }

            }
            return new GeneralResponse<TotalUserMoveResponseData> { Success = true, Data = response };
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


    public ValidResponseFormat checkPlacardRegistration(string Placard)
    {
        try
        {
            string result = "";
            SqlCommand sqlcmd = new SqlCommand("CheckRegisteredPlacardForAndroid", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Placard", Placard);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                result = sqlcmd.ExecuteScalar().ToString();


            }
            if (result == "Invalid")
            {
                return new ValidResponseFormat { Success = false, ErrorMessage = "Placard is not registered with our system" };
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

    //Wrong Gate - Update Gate for Logged In User

    public ValidResponseFormat UpdGateForLoggedInUsersInfo(UpdateGateUserRequest updateGateUserRequest)
    {
        try
        {

            SqlCommand sqlcmd = new SqlCommand("UpdGateForLoggedInUsers", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Gate", updateGateUserRequest.Gate);
            sqlcmd.Parameters.AddWithValue("@ProfileTemplateID", updateGateUserRequest.ProfileTemplateID);
            sqlcmd.Parameters.AddWithValue("@UserCode", updateGateUserRequest.UserCode);


            using (sqlcon)
            {
                db.OpenConnection(ref sqlcon);
                sqlcmd.ExecuteNonQuery();
                db.CloseConnection(ref sqlcon);
            }


            return new ValidResponseFormat { Success = true };
        }
        catch (Exception ex)
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 789);
        }
        finally
        {
            db.CloseConnection(ref sqlcon);
        }
    }

    //Wrong Gate - Update User
    public GeneralResponse<FetchArrivalOSContainerData> getArrivalOSContainer()
    {
        try
        {
            FetchArrivalOSContainerData response = new FetchArrivalOSContainerData();

            string Renban = "";
            string FirstCharRenbanNumber = "";
            using (sqlcon)
            {


                string SqlSlot = "GetSingleArrivalParkingSpaceForTrailerAndContainer";

                string SqlRenban = "FetchDummyRenban";



                #region Route
                db.OpenConnection(ref sqlcon);

                using (SqlCommand sqlcmd = new SqlCommand(SqlRenban, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    //sqlcmd.Parameters.AddWithValue("@Route", route);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.RenbanNumber = reader["A"].ToString();
                            Renban = reader["A"].ToString();
                            FirstCharRenbanNumber = Renban.Substring(0, 1);
                        }
                    }
                }
                db.CloseConnection(ref sqlcon);

                #endregion

                #region availableslot
                db.OpenConnection(ref sqlcon);

                using (SqlCommand sqlcmd = new SqlCommand(SqlSlot, sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Route", FirstCharRenbanNumber);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            response.AvailableSlot = reader["Location"].ToString();

                        }
                        else
                        {
                            return GlobalUtility<FetchArrivalOSContainerData>.Throw_Global_Exception(" No parking Spot available. Contact your Yard LP." + response.AvailableSlot, 703);
                        }
                    }
                }
                db.CloseConnection(ref sqlcon);
                #endregion

            }

            return new GeneralResponse<FetchArrivalOSContainerData> { Success = true, Data = response };
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

    //ValidateLocation
    public ValidResponseFormat CheckValidLocation(CheckLocationRequest checkLocation)
    {

        try
        {
            string ValidPlacard = "";

            string result = "";
            string SQLQueryArrival = "", SQLGeneric = "";
            string SQLValidPlacard = "";

            SQLValidPlacard = "CheckValidPlacardLocation";
            SQLQueryArrival = "GetValidateArrivalParkingSpaceForTrailerAndContainer";
            SQLGeneric = "GetValidateArrivalParkingSpaceForEmptyAndGeneric";

            string route = GetRouteForPlacard(checkLocation.Placard);

            using (SqlCommand sqlcmdP = new SqlCommand(SQLValidPlacard, sqlcon))
            {
                sqlcmdP.CommandType = CommandType.StoredProcedure;
                sqlcmdP.Parameters.AddWithValue("@Placard", checkLocation.Placard);
                using (sqlcon)
                {
                    db.OpenConnection(ref sqlcon);
                    ValidPlacard = sqlcmdP.ExecuteScalar().ToString();
                }
            }

            #region
            if (ValidPlacard == "Valid")
            {
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmdP = new SqlCommand(SQLGeneric, sqlcon))
                {
                    sqlcmdP.CommandType = CommandType.StoredProcedure;
                    sqlcmdP.Parameters.AddWithValue("@Route", route);
                    sqlcmdP.Parameters.AddWithValue("@Usercode", checkLocation.UserCode);
                    using (sqlcon)
                    {
                        db.OpenConnection(ref sqlcon);
                        result = sqlcmdP.ExecuteScalar().ToString();

                    }
                }

            }
            else
            {

                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmdP = new SqlCommand(SQLQueryArrival, sqlcon))
                {
                    sqlcmdP.CommandType = CommandType.StoredProcedure;
                    sqlcmdP.Parameters.AddWithValue("@Route", route);
                    using (sqlcon)
                    {
                        db.OpenConnection(ref sqlcon);
                        result = sqlcmdP.ExecuteScalar().ToString();

                    }
                }
            }

            #endregion

            if (result == "Not Found")
            {
                return new ValidResponseFormat { Success = false, ErrorMessage = "No parking Spot available. Contact your Yard LP." };
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
    //Validate Gate
    public ValidResponseFormat ValidateGate(CheckWrongGateRequest checkRequest)
    {

        try
        {
            string Result;
            string route = GetRouteForPlacard(checkRequest.Placard);

            db.OpenConnection(ref sqlcon);
            SqlCommand cmd = new SqlCommand("CheckGateForArrival", sqlcon);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Location", checkRequest.Location);
            cmd.Parameters.AddWithValue("@UserCode", checkRequest.UserCode);
            cmd.Parameters.AddWithValue("@TrailerID", checkRequest.TrailerID);
            cmd.Parameters.AddWithValue("@Route", route);

            cmd.CommandType = CommandType.StoredProcedure;
            Result = cmd.ExecuteScalar().ToString();
            db.CloseConnection(ref sqlcon);

            if (Result == "FAIL")
            {
                return new ValidResponseFormat { Success = false, ErrorMessage = "Trailer arrived at wrong gate!!   Provide map and instructions for correct trailer yard parking.  Click ok to continue with printing the placard." };
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
}