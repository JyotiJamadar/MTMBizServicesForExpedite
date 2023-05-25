using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for ArrivalResponse
/// </summary>
[DataContract]
public class DepartureResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public FetchDepartureResponseData DepartureData { get; set; }
}