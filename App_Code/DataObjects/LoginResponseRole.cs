using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Response
/// </summary>
[DataContract]
public class LoginResponseRole
{
    [DataMember]//Succes will be allowed to communicate with android
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public LoginResponseDataRole LoginDataRole { get; set; }

}



[DataContract]
public class LoginResponseDataRole
{
    
    [DataMember]  
    public List <string > ValidRoles { get; set; }
    [DataMember]
    public string FacilityCode { get; set; }
    [DataMember]
    public string FacilityName { get; set; }
    [DataMember]
    public string UserName { get; set; }
    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public int ProfileTemplateID { get; set; }
    [DataMember]
    public int RoleID { get; set; }
    [DataMember]
    public string LoginToken { get; set; }
    [DataMember]
    public bool SealRequired { get; set; }
    [DataMember]
    public bool DockDoorScanSettingRequired { get; set; }
    [DataMember]
    public bool DisplayDestinationDuringRequestAndAccept { get; set; }
[DataMember]
    public bool DockDoorDropBarcodeScan { get; set; }
[DataMember]
    public bool DockDoorDropPlacardScan { get; set; }
    [DataMember]
    public bool YardDropBarcodeScan { get; set; }
    [DataMember]
    public bool YardDropPlacardScan { get; set; }

}
