using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for SequenceRequestData
/// </summary>
[DataContract]
public class YardcheckSequenceRequestData
{
    [DataMember]
    public string Prefix { get; set; }
 [DataMember]
    public string Zone { get; set; }
[DataMember]
    public string UserCode { get; set; }
[DataMember]
    public string FacilityCode { get; set; }
    
}