using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IReceiver
{

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetMasterData", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<List<ValidData>> getValidInfo(ValidRequestData ValidRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetDispatchStatus", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<DispatchStatusResponse> GetDispatchStatus(LookupRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/ConnectionTest", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat CheckConnection();


    [OperationContract]
    [WebInvoke(UriTemplate = "/Login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<LoginResponseData> CheckLogin(LoginRequestData LoginParams);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckPreDeparture", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<PreDepartureResponseData> getPreDepartureDetails(PreDepartureRequest placardRequest);


    [OperationContract]
    [WebInvoke(UriTemplate = "/Activate", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ActivateDevice(ActivationRequestData activationData);



    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckTrailerInPoolOrNot", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat checkTrailerInPool(CheckTrailerRequestdata checkTrailerdata);


    [OperationContract]
    [WebInvoke(UriTemplate = "/ScanProcessor", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ProcessScan(ScanData scanData);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GroupsForLoggedInUser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ProcessGroupForLoggedInUser(LoggedInUserGroupRequest scanData);

    [OperationContract]
    [WebInvoke(UriTemplate = "/UserGpsLoginDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat InsGPSUserLogin(UserGPSLoginDetails canData);

    [OperationContract]
    [WebInvoke(UriTemplate = "/Lookup", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<LookupResponseData> getTrailerDetails(LookupRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/LookupTrailerDetailsForDeparture", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<FetchDepartureResponseData> getDepartureDetails(DepartureRequest lookupRequest);


    [OperationContract]
    [WebInvoke(UriTemplate = "/FetchCheckSheetData", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<FetchArrivalResponseData> getArrivalDetails(ArrivalRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/Sequence", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<Sequence>> getDockSequence(SequenceRequestData sequenceRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetDockDoorReport", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<DockDoorResponse>> getDockDoor(DockDoorRequestData sequenceRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetDockDoorScheduleForDoor", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<DockDoorScheduleResponse>> getDockDoorSchedule(DockDoorScheduleRequestData sequenceRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/HelpCall", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat getHelpcall(HelpCallRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/UpdateBarcode", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat UpdSequential(UpdSequenceRequestData barcode);

    [OperationContract]
    [WebInvoke(UriTemplate = "/FetchSealByContainerNumber", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<FetchSealResponse> getSealByContainerNumber(FetchSealRequest lookupRequest);


    [OperationContract]
    [WebInvoke(UriTemplate = "/SequentialBarcodeCheck", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<LocationTrailerResponseData> CheckSequentialBarcode(LookupRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/DispatchData", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<DispatchResponseData>> GetDispatchData(PoolRequestData dispatchRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/DispatchReply", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat UpdateDispatchReply(DispatchReplyData dispatchReply);

    [OperationContract]
    [WebInvoke(UriTemplate = "/InsuranceStatus", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<InsuranceStatusResponseData> getInsuranceStatus(InsuranceStatusRequestData insuranceStatusRequestData);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetBadges", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<List<BadgeResponseData>> GetBadges();

    [OperationContract]
    [WebInvoke(UriTemplate = "/InsUpdVisitorLog", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat InsUpdVistor(UpdVisitorLogRequestData scanData);


    [OperationContract]
    [WebInvoke(UriTemplate = "/GetHookNotDrop", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<HookResponseData> getTrailerHookDetails(HookRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetGatePassDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<GatePassResponseData> getGatePassDetails(GatePassRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckPlacard", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<CheckPlacardResponseData> getCheckPlacardDetails(CheckPlacardRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetPlacardDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<PlacardResponseData> getPlacardDetails(PlacardRequest placardRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/Logout", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat Logout(LogoutRequest scanData);

    [OperationContract]
    [WebInvoke(UriTemplate = "/LoginRoles", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<LoginResponseDataRole> CheckLoginRole(LoginRequestData LoginParams);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckPreDepartureNew", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat CheckDepartureNewData(PreDepartureRequest CheckData);



    [OperationContract]
    [WebInvoke(UriTemplate = "/YardcheckSequence", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<SequentialResponseData>> GetSequentialDoorsComplete();



    [OperationContract]
    [WebInvoke(UriTemplate = "/LookupByLocation", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<LocationResponseData> getTrailerDetailsByLocation(LocationRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetLocationByPrefix", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<YardcheckSequence>> getYardcheckcheckSequence(YardcheckSequenceRequestData sequenceRequest);



    [OperationContract]
    [WebInvoke(UriTemplate = "/InsDispatchData", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat DispatchDataAndroid(DispatchData Data);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetLocationDetails", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<LocationDetails>> getLocationSequence(LocationDetailsRequest sequenceRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetDropLocation", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<List<DropLocation>> getDropLocationSequence(DropLocationRequest sequenceRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/ValidatePlacardRoute", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat RoutePoolValidation(RoutePoolRequestData RoutePoolRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/ValidateSeal", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat SealValidation(CheckSealRequestData RoutePoolRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/GetDamageTrailerDetails", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<DamageLookupResponseData> getDamageTrailerDetails(LookupRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckPlacardRegister", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat checkPlacardReg(PlacardRequest placardrequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/TotalMoveCount", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<TotalUserMoveResponseData> getTotalMoveDetails(TotalUserMoveRequestData lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/UnAccept", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat UnAcceptDispatchRequestSend(DispatchRequestForUnAccept dispatchRequest);


    [OperationContract]
    [WebInvoke(UriTemplate = "/ScanProcessorDrop", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ProcessScanDrop(ScanDataDrop scanData);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckDepartureEligibility", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat CheckDepartureEligibility(DepartureRequest depart);

    [OperationContract]
    [WebInvoke(UriTemplate = "/ProcessCTPAT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ProcessCTPATInterior(CTPATInteriorData Data);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckValidateForPlacard", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    GeneralResponse<FetchDepartureResponseData> getCheckRouteDeparture(DepartureRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/FetchContainerDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<FetchSealResponse> getContainerDetails(FetchSealRequest lookupRequest);

     [OperationContract]
    [WebInvoke(UriTemplate = "/FetchCTPATQuestions", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<List<FetchCTPATResponseData>> getCTPATQuestionDetails(CTPATQuestionsRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckRegPlacard", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat checkPlacardRegistration(CheckPlacardRequest checkPlacard);

    [OperationContract]
    [WebInvoke(UriTemplate = "/PictureRequestList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<List<PictureRequest>> GetPictureRequests(LookupRequest lookupRequest);

    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckPictureStatus", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat CheckPictureStatus(PictureRequest picture);

    [OperationContract]
    [WebInvoke(UriTemplate = "/UpdatePictures", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat UpdatePictures(PictureRequest picture);


   [OperationContract]
    [WebInvoke(UriTemplate = "/ScanProcessorHook", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ProcessScanHook(ScanDataHook scanData);

    //Update Gate for User
    [OperationContract]
    [WebInvoke(UriTemplate = "/UpdGateForLoggedInUsers", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat UpdGateForLoggedInUsers(UpdateGateUserRequest updateGateUserRequest);

[OperationContract]
    [WebInvoke(UriTemplate = "/GetRenbanAndLocationForOSEmptyContainer", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    GeneralResponse<FetchArrivalOSContainerData> getArrivalOSEmptyContainer();

 //ValidLocation

    [OperationContract]
    [WebInvoke(UriTemplate = "/ValidateLocation", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat CheckValidLocation(CheckLocationRequest checkLocation);

//Validate Wrong Gate
    [OperationContract]
    [WebInvoke(UriTemplate = "/CheckWrongGate", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ValidateGate(CheckWrongGateRequest checkRequest);


    [OperationContract]
    [WebInvoke(UriTemplate = "/ScanProcessorFoExpedite", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    ValidResponseFormat ProcessScanFoExpedite(ScanData scanData);


}
