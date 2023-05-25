using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for LookupRequest
/// </summary>
[DataContract]
public class PreDepartureRequest
{
    [DataMember]
    public string TrailerID { get; set; }

    [DataMember]
    public string PlaCard { get; set; }


[DataMember]
    public string YardPass { get; set; }
[DataMember]
    public string UserCode { get; set; }
    
}