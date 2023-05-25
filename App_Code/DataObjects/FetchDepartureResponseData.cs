using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for FetchArrivalResponseData
/// </summary>
public class FetchDepartureResponseData
{

    [DataMember]
    public string SequentialBarcode { get; set; }
    [DataMember]
    public string Trailer_ContainerID { get; set; }

    [DataMember]
    public string TrailerTypeCode { get; set; }

    [DataMember]
    public string Placard { get; set; }

    [DataMember]
    public string YardPass { get; set; }

    [DataMember]
    public string SealNo { get; set; }

    [DataMember]
    public string Carrier { get; set; }

    [DataMember]
    public string Comment { get; set; }

    [DataMember]
    public string RoutePool { get; set; }

    [DataMember]
    public string  Result { get; set; }

    [DataMember]
    public string IsGenericPlacard { get; set; }
    
 

}