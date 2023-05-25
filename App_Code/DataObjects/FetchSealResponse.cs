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
public class FetchSealResponse
{
    [DataMember]
    public string SealNumber { get; set; }
    [DataMember]
    public string RenbanNumber { get; set; }

    [DataMember]
    public string Carrier { get; set; }

    [DataMember]
    public string ParkingSlot { get; set; }

    [DataMember]
    public string Equipment { get; set; }

    [DataMember]
    public string Comment { get; set; }

    [DataMember]
    public string Location { get; set; }
    
   [DataMember]
    public string AvailableSlot { get; set; }

 [DataMember]
    public string Gate { get; set; }
}