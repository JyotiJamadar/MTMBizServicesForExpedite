using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for CTPATData
/// </summary>

[DataContract]
public class UserGPSLoginDetails
{
    [DataMember]
    public string DeviceID { get; set; }
    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public string TimeStamp { get; set; }
    [DataMember]
    public string GPS_Latitude { get; set; }
    [DataMember]
    public string GPS_Longitude { get; set; }
    

}