using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for LoginResponse
/// </summary>
[DataContract]
public class LoginResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public LoginResponseData Data { get; set; }

}
public class LoginResponseData
{
    

    public string FacilityCode { get; set; }
    public string FacilityName { get; set; }
    public string UserName { get; set; }
    public string UserCode { get; set; }
    public int ProfileTemplateID { get; set; }
    public int RoleID { get; set; }
    public string LoginToken { get; set; }
}