using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
/// <summary>
/// Summary description for ResponseCustomError
/// </summary>
[DataContract]
public class ResponseCustomError
{
    [DataMember(Order = 2)]
    public string ErrorMessage { get; set; }
    [DataMember(Order = 1)]
    public bool Success { get; set; }
}