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
public class LookupResponseData
{
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string TrailerTypeCode { get; set; }
    [DataMember]
    public string TrailerType { get; set; }
    [DataMember]
    public string LocationCode { get; set; }
    [DataMember]
    public string Location { get; set; }
[DataMember]
    public string LocationTypeCode { get; set; }
    [DataMember]
    public string FacilityName { get; set; }
    [DataMember]
    public string FacilityCode { get; set; }
    [DataMember]
    public string AppointmentNumber { get; set; }
    [DataMember]
    public string SapShipmentNumber { get; set; }
    [DataMember]
    public string TrailerStatusCode { get; set; }
    [DataMember]
    public string TrailerStatus { get; set; }
    [DataMember]
    public string Comment { get; set; }
    [DataMember]
    public string LoadType { get; set; }
    [DataMember]
    public string LoadTypeCode { get; set; }
    [DataMember]
    public string Placard { get; set; }
    [DataMember]
    public string YardPass { get; set; }
 [DataMember]
    public string Flag { get; set; }
[DataMember]
    public string RoutePool { get; set; }
}