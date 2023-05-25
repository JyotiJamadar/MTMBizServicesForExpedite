using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Net;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Receiver" in code, svc and config file together.
public class Receiver : IReceiver
{

    public GeneralResponse<List<ValidData>> getValidInfo(ValidRequestData ValidRequest)
    {

        if (HeaderValidates())
        {
            try
            {

                DataRetreiver retreiver = new DataRetreiver();

                return retreiver.RetreiveValidInfo(ValidRequest);


            }
            catch (Exception ex)
            {
                return GlobalUtility<List<ValidData>>.Throw_Global_Exception(ex.Message);

            }
        }
        else
        {
            return GlobalUtility<List<ValidData>>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat UpdatePictures(PictureRequest scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.UpdatePicturePath(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<List<PictureRequest>> GetPictureRequests(LookupRequest lookup)
    {
        if (HeaderValidates())
        {
            try
            {

                DataRetreiver dr = new DataRetreiver();
                return dr.GetPictureRequests(lookup);
            }
            catch (Exception ex)
            {
                return GlobalUtility<List<PictureRequest>>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<List<PictureRequest>>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat CheckPictureStatus(PictureRequest picture)
    {
        if (HeaderValidates())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.CheckPictureStatus(picture);
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat ActivateDevice(ActivationRequestData activationData)
    {
        if (HeaderValidatesWithoutActivation())
        {
            LoginTransact loginActivate = new LoginTransact();
            return loginActivate.ActivateDevice(activationData.ActivationKey, GetHeader);
        }
        else
        {
            return GlobalUtility<List<ValidData>>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat CheckDepartureEligibility(DepartureRequest depart)
    {
        if (HeaderValidatesWithoutActivation())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.CheckDepartureEligibility(depart);
        }
        else
        {
            return GlobalUtility<List<ValidData>>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<LoginResponseData> CheckLogin(LoginRequestData LoginParams)
    {
        if (HeaderValidatesWithoutActivation())
        {
            try
            {

                LoginTransact login = new LoginTransact();
                return login.getLogin(LoginParams.UserName, LoginParams.Password, (GetHeader));
            }
            catch (Exception ex)
            {
                return GlobalUtility<LoginResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<LoginResponseData>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat ProcessScan(ScanData scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.ProcessData(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<DispatchStatusResponse> GetDispatchStatus(LookupRequest lookup)
    {
        if (HeaderValidates())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.GetDispatchStatus(lookup);

        }
        else
        {
            return GlobalUtility<DispatchStatusResponse>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat ProcessGroupForLoggedInUser(LoggedInUserGroupRequest scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.ProcessLoggedInUserGroup(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }




    public ValidResponseFormat CheckConnection()
    {
        if (HeaderValidates())
        {
            return new ValidResponseFormat { Success = true };
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess("Problem with Connection", 700);
        }
    }


    private bool HeaderValidates()
    {
        IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
        WebHeaderCollection headers = request.Headers;
        if (headers["EXOTRAC-DEVICEID"] != null && headers["EXOTRAC-TOKEN"] != null)
        {
            GetHeader = headers["EXOTRAC-DEVICEID"].ToString();
            GetToken = headers["EXOTRAC-TOKEN"].ToString();
            return true;

        }
        else
        {
            return false;
        }
    }
    private bool HeaderValidatesWithoutActivation()
    {
        IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
        WebHeaderCollection headers = request.Headers;
        if (headers["EXOTRAC-DEVICEID"] != null && headers["EXOTRAC-TOKEN"] != null)
        {
            GetHeader = headers["EXOTRAC-DEVICEID"].ToString();
            GetToken = headers["EXOTRAC-TOKEN"].ToString();
            return SecurityUtil.IsRequestAuthorized(GetHeader, GetToken);
        }
        else
        {
            return false;
        }
    }

    private string GetHeader
    {
        get;
        set;
    }
    private string GetToken
    {
        get;
        set;
    }

    public GeneralResponse<LookupResponseData> getTrailerDetails(LookupRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getTrailerInfo(lookupRequest.TrailerID);
            }
            catch (Exception ex)
            {
                return GlobalUtility<LookupResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<LookupResponseData>.Throw_Unauthorized_Exception();
        }
    }

    //Arrival 
    public GeneralResponse<FetchArrivalResponseData> getArrivalDetails(ArrivalRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getArrivalInfo(lookupRequest);
            }
            catch (Exception ex)
            {
                return GlobalUtility<FetchArrivalResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<FetchArrivalResponseData>.Throw_Unauthorized_Exception();
        }
    }

    //End Arrival

    //Departure
    public GeneralResponse<FetchDepartureResponseData> getDepartureDetails(DepartureRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getDepartureInfo(lookupRequest.SequentialBarcode);
            }
            catch (Exception ex)
            {
                return GlobalUtility<FetchDepartureResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<FetchDepartureResponseData>.Throw_Unauthorized_Exception();
        }
    }

    //End Departure


    public GeneralResponse<FetchDepartureResponseData> getCheckRouteDeparture(DepartureRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.ValidateForPlacard(lookupRequest.Trailer_ContainerID, lookupRequest.Placard);
            }
            catch (Exception ex)
            {
                return GlobalUtility<FetchDepartureResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<FetchDepartureResponseData>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<List<Sequence>> getDockSequence(SequenceRequestData sequenceRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.getDockSequenceDetails(sequenceRequest.DoorGroupCode, sequenceRequest.FacilityCode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<List<Sequence>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<Sequence>>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat getHelpcall(HelpCallRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getHelpCall(lookupRequest);
            }

            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<FetchSealResponse> getSealByContainerNumber(FetchSealRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getSealnumberByContainerNumber(lookupRequest);
            }

            catch (Exception ex)
            {
                return GlobalUtility<FetchSealResponse>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<FetchSealResponse>.Throw_Unauthorized_Exception();
        }
    }

    /*Conatiner Details */
    public GeneralResponse<FetchSealResponse> getContainerDetails(FetchSealRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getSealnumberByContainerDetails(lookupRequest);
            }

            catch (Exception ex)
            {
                return GlobalUtility<FetchSealResponse>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<FetchSealResponse>.Throw_Unauthorized_Exception();
        }
    }
    /*End Container Details*/


    public GeneralResponse<LocationTrailerResponseData> CheckSequentialBarcode(LookupRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.CheckSequentialBarcode(lookupRequest.SequentialBarcode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<LocationTrailerResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<LocationTrailerResponseData>.Throw_Unauthorized_Exception();
        }
    }
    public ValidResponseFormat UpdateDispatchReply(DispatchReplyData dispatchReply)
    {
        if (HeaderValidates())
        {
            try
            {
                DataFunnel df = new DataFunnel();

                return df.UpdateDispatchReply(dispatchReply);
            }
            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<List<DispatchResponseData>> GetDispatchData(PoolRequestData dispatchRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                DispatchResponse dispatchResponse = new DispatchResponse();
                return dr.getDispatchData(dispatchRequest.UserCode, dispatchRequest.FacilityCode, dispatchRequest.GroupCode);
            }
            catch (Exception ex)
            {
                return GlobalUtility<List<DispatchResponseData>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<DispatchResponseData>>.Throw_Unauthorized_Exception();
        }

    }

    public GeneralResponse<InsuranceStatusResponseData> getInsuranceStatus(InsuranceStatusRequestData insuranceStatusRequestData)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getInsuranceStatus(insuranceStatusRequestData.ScacCode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<InsuranceStatusResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<InsuranceStatusResponseData>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat UpdSequential(UpdSequenceRequestData barcode)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.UpdSequentialBarcode(barcode);
            }

            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<List<BadgeResponseData>> GetBadges()
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.GetBadges();

            }
            catch (Exception ex)
            {
                return GlobalUtility<List<BadgeResponseData>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<BadgeResponseData>>.Throw_Unauthorized_Exception();
        }

    }

    public ValidResponseFormat InsUpdVistor(UpdVisitorLogRequestData scanData)
    {
        if (HeaderValidates())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.InsUpdVisitorLog(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }


    public GeneralResponse<HookResponseData> getTrailerHookDetails(HookRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getTrailerHookInfo(lookupRequest.TrailerID);

            }
            catch (Exception ex)
            {
                return GlobalUtility<HookResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<HookResponseData>.Throw_Unauthorized_Exception();
        }
    }

    public GeneralResponse<GatePassResponseData> getGatePassDetails(GatePassRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getGatePassInfo(lookupRequest.GatePass);

            }
            catch (Exception ex)
            {
                return GlobalUtility<GatePassResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<GatePassResponseData>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<CheckPlacardResponseData> getCheckPlacardDetails(CheckPlacardRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getCheckPlacardInfo(lookupRequest.TrailerID, lookupRequest.Placard);

            }
            catch (Exception ex)
            {
                return GlobalUtility<CheckPlacardResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<CheckPlacardResponseData>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<PlacardResponseData> getPlacardDetails(PlacardRequest placardRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getPlacardInfo(placardRequest.Placard);
            }
            catch (Exception ex)
            {
                return GlobalUtility<PlacardResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<PlacardResponseData>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat InsGPSUserLogin(UserGPSLoginDetails scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dr = new DataFunnel();
            return dr.ProcessUserLoginDetailsGPS(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<PreDepartureResponseData> getPreDepartureDetails(PreDepartureRequest placardRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getPreDepartureInfo(placardRequest.TrailerID, placardRequest.PlaCard, placardRequest.YardPass, placardRequest.UserCode);


            }
            catch (Exception ex)
            {
                return GlobalUtility<PreDepartureResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<PreDepartureResponseData>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat Logout(LogoutRequest scanData)
    {
        if (HeaderValidates())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.UpdLogoutInfo(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }
    public GeneralResponse<LoginResponseDataRole> CheckLoginRole(LoginRequestData LoginParams)
    {

        if (HeaderValidatesWithoutActivation())
        {
            try
            {
                LoginTransact login = new LoginTransact();
                return login.LoginWithRole(LoginParams.UserName, LoginParams.Password, (GetHeader));

            }
            catch (Exception ex)
            {
                return GlobalUtility<LoginResponseDataRole>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<LoginResponseDataRole>.Throw_Unauthorized_Exception();
        }
    }



    public GeneralResponse<List<DockDoorResponse>> getDockDoor(DockDoorRequestData sequenceRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.getDockDoorLocationDetails(sequenceRequest.UserCode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<List<DockDoorResponse>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<DockDoorResponse>>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<List<DockDoorScheduleResponse>> getDockDoorSchedule(DockDoorScheduleRequestData sequenceRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.getDockDoorScheduleLocationDetails(sequenceRequest.UserCode, sequenceRequest.DoorCode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<List<DockDoorScheduleResponse>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<DockDoorScheduleResponse>>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat checkTrailerInPool(CheckTrailerRequestdata checkTrailerdata)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.checkTrailer(checkTrailerdata.TrailerID);
            }
            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public ValidResponseFormat CheckDepartureNewData(PreDepartureRequest placardRequest)
    {
        if (HeaderValidates())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.CheckPreDepartureData(placardRequest.TrailerID, placardRequest.PlaCard, placardRequest.YardPass, placardRequest.UserCode);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

  //CTPAT Questions
    public GeneralResponse<List<FetchCTPATResponseData>> getCTPATQuestionDetails(CTPATQuestionsRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getCTPATQuestionsList(lookupRequest.CTPATType);
            }
            catch (Exception ex)
            {
                return GlobalUtility<List<FetchCTPATResponseData>>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<List<FetchCTPATResponseData>>.Throw_Unauthorized_Exception();
        }
    }

    //End CTPAT Questions


    public GeneralResponse<List<SequentialResponseData>> GetSequentialDoorsComplete()
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.GetSequentialCompleteInfo();
            }
            catch (Exception ex)
            {
                return GlobalUtility<List<SequentialResponseData>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<SequentialResponseData>>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<LocationResponseData> getTrailerDetailsByLocation(LocationRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getTrailerInfoByLocation(lookupRequest.LocationCode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<LocationResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<LocationResponseData>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<List<YardcheckSequence>> getYardcheckcheckSequence(YardcheckSequenceRequestData sequenceRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.getYardSequenceDetails(sequenceRequest.UserCode, sequenceRequest.Zone, sequenceRequest.Prefix, sequenceRequest.FacilityCode);

            }
            catch (Exception ex)
            {
                return GlobalUtility<List<YardcheckSequence>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<YardcheckSequence>>.Throw_Unauthorized_Exception();
        }
    }
    public ValidResponseFormat DispatchDataAndroid(DispatchData Data)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.DispatchDataFromAndroid(Data);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<List<LocationDetails>> getLocationSequence(LocationDetailsRequest sequenceRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.getLocationDetails(sequenceRequest.FacilityCode);
            }
            catch (Exception ex)
            {
                return GlobalUtility<List<LocationDetails>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<LocationDetails>>.Throw_Unauthorized_Exception();
        }
    }


    public GeneralResponse<List<DropLocation>> getDropLocationSequence(DropLocationRequest sequenceRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver dr = new DataRetreiver();
                return dr.getDropLocationDetails(sequenceRequest.FacilityCode);
            }
            catch (Exception ex)
            {
                return GlobalUtility<List<DropLocation>>.Throw_Global_Exception(ex.Message, 700);
            }

        }
        else
        {
            return GlobalUtility<List<DropLocation>>.Throw_Unauthorized_Exception();
        }
    }


    public ValidResponseFormat RoutePoolValidation(RoutePoolRequestData RoutePoolRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.ValidatePlacardRoute(RoutePoolRequest);
            }

            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public ValidResponseFormat SealValidation(CheckSealRequestData RoutePoolRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.CheckSealByTrailerID(RoutePoolRequest);
            }

            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public GeneralResponse<DamageLookupResponseData> getDamageTrailerDetails(LookupRequest lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getDamageTrailerInfo(lookupRequest.TrailerID);

            }
            catch (Exception ex)
            {
                return GlobalUtility<DamageLookupResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<DamageLookupResponseData>.Throw_Unauthorized_Exception();
        }
    }



    public ValidResponseFormat checkPlacardReg(PlacardRequest placardrequest)
    {
        if (HeaderValidates())
        {
            DataRetreiver dr = new DataRetreiver();
            return dr.checkPlacardRegistered(placardrequest);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }


    public GeneralResponse<TotalUserMoveResponseData> getTotalMoveDetails(TotalUserMoveRequestData lookupRequest)
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getTotalMoveInfo(lookupRequest.UserCode);
            }
            catch (Exception ex)
            {
                return GlobalUtility<TotalUserMoveResponseData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<TotalUserMoveResponseData>.Throw_Unauthorized_Exception();
        }
    }

    public ValidResponseFormat UnAcceptDispatchRequestSend(DispatchRequestForUnAccept dispatchRequest)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.UnAcceptDispatchRequest(dispatchRequest);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public ValidResponseFormat ProcessScanDrop(ScanDataDrop scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.ProcessDrop(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public ValidResponseFormat ProcessCTPATInterior(CTPATInteriorData Data)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.CTPATInterior(Data);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

   public  ValidResponseFormat checkPlacardRegistration(CheckPlacardRequest checkPlacard)
    {
        if (HeaderValidates())
        {
            DataRetreiver retreiver = new DataRetreiver();
            return retreiver.checkPlacardRegistration(checkPlacard.Placard);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

 public ValidResponseFormat ProcessScanHook(ScanDataHook scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.ProcessHook(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }
 //Update Gate
    public ValidResponseFormat UpdGateForLoggedInUsers(UpdateGateUserRequest updateGateUserRequest)
    {
        if (HeaderValidates())
        {
            DataRetreiver retreiver = new DataRetreiver();
            return retreiver.UpdGateForLoggedInUsersInfo(updateGateUserRequest);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

public GeneralResponse<FetchArrivalOSContainerData> getArrivalOSEmptyContainer()
    {
        if (HeaderValidates())
        {
            try
            {
                DataRetreiver retreiver = new DataRetreiver();
                return retreiver.getArrivalOSContainer();

            }
            catch (Exception ex)
            {
                return GlobalUtility<FetchArrivalOSContainerData>.Throw_Global_Exception(ex.Message, 700);
            }
        }
        else
        {
            return GlobalUtility<FetchArrivalOSContainerData>.Throw_Unauthorized_Exception();
        }
    }

// Valid Location
     public ValidResponseFormat CheckValidLocation(CheckLocationRequest checkLocation)
    {
        if (HeaderValidates())
        {
            DataRetreiver retreiver = new DataRetreiver();
            return retreiver.CheckValidLocation(checkLocation);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    } 
 //Validate Wrong Gate
    public ValidResponseFormat ValidateGate(CheckWrongGateRequest checkWrongGate)
    {
        if (HeaderValidates())
        {
            DataRetreiver retreiver = new DataRetreiver();
            return retreiver.ValidateGate(checkWrongGate);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    public ValidResponseFormat ProcessScanFoExpedite(ScanData scanData)
    {
        if (HeaderValidates())
        {
            DataFunnel dataFunnel = new DataFunnel();
            return dataFunnel.ProcessData(scanData);

        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

}








