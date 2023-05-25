using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for FetchCTPATResponseData
/// </summary>
public class FetchCTPATResponseData
{
    [DataMember]

    public string CTPATType { get; set; }

    [DataMember]
    public string Questions { get; set; }

}