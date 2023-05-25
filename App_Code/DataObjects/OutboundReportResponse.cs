using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for OutboundReportResponse
/// </summary>
[DataContract]
public class OutboundReportResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public List<OutboundResponseData> OutboundReportData { get; set; }
}
public class OutboundResponseData
{

    public string OutboundAppointmentNumber { get; set; }
    public string WMSOrderNumber { get; set; }
    public string SAPShipmentNumber { get; set; }
    public string TrailerID { get; set; }
    public string PUDateTime { get; set; }
    public string SealNumber { get; set; }
    public string Comment { get; set; }
}