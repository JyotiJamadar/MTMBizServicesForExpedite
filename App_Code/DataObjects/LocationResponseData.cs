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
public class LocationResponseData
{
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string LocationCode { get; set; }
[DataMember]
    public string LocationTypeCode { get; set; }
    [DataMember]
    public string Location { get; set; }
    [DataMember]
    public string TrailerStatusCode { get; set; }
    [DataMember]
    public string TrailerStatus { get; set; }
    [DataMember]
    public string SequentialBarcode { get; set; }
    [DataMember]
    public string LoadType { get; set; }
    [DataMember]
    public string LoadTypeCode { get; set; }
    [DataMember]
    public string Placard { get; set; }
    
}