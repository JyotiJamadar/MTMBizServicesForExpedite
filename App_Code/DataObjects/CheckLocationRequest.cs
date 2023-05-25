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
public class CheckLocationRequest
{
    [DataMember]
    public string Route { get; set; }

    [DataMember]
    public string Placard { get; set; }

    [DataMember]
    public string UserCode { get; set; }



}