using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for ArrivalResponse
/// </summary>
public class ArrivalResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }

    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public FetchArrivalResponseData ArrivalData { get; set; }
}