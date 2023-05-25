using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for PoolRequestData
/// </summary>
public class PoolRequestData
{

    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public string FacilityCode { get; set; }
    [DataMember]
    public string ProfileCode { get; set; }
    [DataMember]
    public string CarrierCode { get; set; }
[DataMember]
    public string GroupCode { get; set; }

}