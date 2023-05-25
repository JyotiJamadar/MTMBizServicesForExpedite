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
public class InboundReportResponseData
{
    [DataMember]
    public string InboundAppointmentNumber { get; set; }
    [DataMember]
    public string ProNumber { get; set; }
    [DataMember]
    public string SapShipmentNumber { get; set; }
    [DataMember]
    public string InTrailer { get; set; }
    [DataMember]
    public string TimeIn { get; set; }
    [DataMember]
    public string PO { get; set; }
    [DataMember]
     public string LiveDrop { get; set; }
    [DataMember]
     public string TrailerID { get; set; }
    [DataMember]
      public string Comment { get; set; }
    [DataMember]
     public string Vendor { get; set; }
    [DataMember]
    public string OutboundAppointmentNumber { get; set; }
    [DataMember]
    public string OutTrailer { get; set; }
    [DataMember]
    public string AppointmentType { get; set; }
    [DataMember]
    public string AppointmentTime { get; set; }
    [DataMember]
    public string HasArrived { get; set; }
}