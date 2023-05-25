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
public class InboundReportDockResponseData
{
    [DataMember]
    public string AppointmentTime { get; set; }
    [DataMember]
    public string CheckInTime { get; set; }
    [DataMember]
    public string Trailernumber { get; set; }
[DataMember]
    public string ShipmentNumber { get; set; }
   
}