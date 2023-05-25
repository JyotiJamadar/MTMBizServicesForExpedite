using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;


/// <summary>
/// Summary description for LocationTrailerResponseData
/// </summary>
[DataContract]
public class LocationTrailerResponseData
{
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string SequentialBarcode { get; set; }
    [DataMember]
    public string TrailerType { get; set; }
    [DataMember]
    public string IsInPool { get; set; }

    [DataMember]
    public string Flag { get; set; }

    [DataMember]
    public string Placard { get; set; }




}

