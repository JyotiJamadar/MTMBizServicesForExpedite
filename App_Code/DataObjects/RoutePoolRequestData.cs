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
public class RoutePoolRequestData
{
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string Placard { get; set; }
   
}