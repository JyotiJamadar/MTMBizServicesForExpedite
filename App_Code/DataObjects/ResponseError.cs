using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
/// <summary>
/// Summary description for ResponseError
/// </summary>
[DataContract]
public class ResponseError
{
    [DataMember(Order = 2)]
    public string ErrorMessage { get; set; }
    [DataMember(Order = 1)]
    public bool Success { get; set; }
    [DataMember(Order = 3)]
    public string ErrorCode { get; set; }
}