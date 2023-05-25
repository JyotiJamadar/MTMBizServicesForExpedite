using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
/// <summary>
/// Summary description for ValidRequestData
/// </summary>
[DataContract]
public class ValidRequestData
{
    [DataMember]
    public string ResourceType { get; set; }
    [DataMember]
    public string FacilityCode { get; set; }
    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public string CarrierCode { get; set; }
    [DataMember]
    public string CatalogType { get; set; }
    [DataMember]
    public string LocationGroupCode { get; set; }
    [DataMember]
    public string Placard { get; set; }
    [DataMember]
    public string Route { get; set; }


}

