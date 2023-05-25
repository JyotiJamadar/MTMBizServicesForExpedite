using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for ArrivalRequest
/// </summary>
[DataContract]
public class ArrivalRequest
{

    [DataMember]
    public string UserCode { get; set; }

    [DataMember]
    public string TrailerID { get; set; }

    [DataMember]
    public string SequentialBarcode { get; set; }

    [DataMember]
    public string Carrier { get; set; }

    [DataMember]
    public string SealNumber { get; set; }

    [DataMember]
    public string Placard { get; set; }

    [DataMember]
    public string Route { get; set; }

    [DataMember]
    public string YardDate { get; set; }

    [DataMember]
    public string YardTime { get; set; }

    [DataMember]
    public string UnloadDoors { get; set; }

    [DataMember]
    public string UnloadStart { get; set; }

    [DataMember]
    public string UnloadEnd { get; set; }

    [DataMember]
    public string ProductionDate { get; set; }

    [DataMember]
    public string UnloadDate { get; set; }

    [DataMember]
    public string AvailableSlot { get; set; }

    [DataMember]
    public string RoutePool { get; set; }

    [DataMember]
    public string Comment { get; set; }

    [DataMember]
    public string Redirect { get; set; }
}