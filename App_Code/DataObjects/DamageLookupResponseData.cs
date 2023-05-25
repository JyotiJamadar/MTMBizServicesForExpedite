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
public class DamageLookupResponseData
{
    [DataMember]
    public string TrailerID { get; set; }
   
 [DataMember]
    public string Flag { get; set; }
[DataMember]
    public string Picture { get; set; }
[DataMember]
    public string Issue { get; set; }
[DataMember]
    public string Area { get; set; }
[DataMember]
    public string Comment { get; set; }

[DataMember]
    public string ScannedOn { get; set; }
[DataMember]
    public string ScannedBy { get; set; }
[DataMember]
    public string Image1 { get; set; }
[DataMember]
    public string Image2 { get; set; }
[DataMember]
    public string Image3 { get; set; }

}