using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for ArrivalRequest
/// </summary>
[DataContract]
public class DepartureRequest
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
    public string Seal { get; set; }

    [DataMember]
    public string Carrier { get; set; }

    [DataMember]
    public string Comment { get; set; }

    [DataMember]
    public string RoutePool { get; set; }

    [DataMember]

    public string Result { get; set; }

    [DataMember]
    public string UserCode { get; set; }

}