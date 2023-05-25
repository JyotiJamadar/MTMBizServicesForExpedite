using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for BadgeResponse
/// </summary>

[DataContract]
public class BadgeResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public List<BadgeResponseData> ValidData { get; set; }

}
public class BadgeResponseData
{


    public string BadgeNumber { get; set; }
    public string VisitorName { get; set; }
public string DepartmentName { get; set; }
    public string Company { get; set; }
    public string ContactPerson { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

}
