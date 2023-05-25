using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for ScanData
/// </summary>
[DataContract]
public class ScanDataHook
{
   
    [DataMember]
    public string TrailerID;
    [DataMember]
    public string Emailbit;
    [DataMember]
    public string Seal;
    [DataMember]
    public string LoginId;
    [DataMember]
    public string UserCode;
    [DataMember]
    public string FacilityCode;
    [DataMember]
    public string LocationCode;
    [DataMember]
    public string ActionCode;
     [DataMember]
    public string DeviceID;
    [DataMember]
    public string GPS_Latitude;
    [DataMember]
    public string GPS_Longitude;
    [DataMember]
    public string Version;
    [DataMember]
    public string ScanID;
    [DataMember]
    public string TimeStamp;

[DataMember]
    public string PlaCard;

[DataMember]
  public string DispatchID;
[DataMember]
  public string recordid;



  
}