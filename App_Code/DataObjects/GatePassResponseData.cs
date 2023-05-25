using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for LookupResponseData
/// </summary>
public class GatePassResponseData
{
    [DataMember]
    public string DriverName { get; set; }
    [DataMember]
    public string TractorNumber { get; set; }

    [DataMember]
    public string Carrier { get; set; }
    
}