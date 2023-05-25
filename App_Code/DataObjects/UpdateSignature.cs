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
public class UpdateSignature
{
   
    [DataMember]
    public string DriverSignaturePath;
    [DataMember]
    public string UserCode;
    [DataMember]
    public string TimeStamp;
    [DataMember]
    public string DriverName;
    [DataMember]
    public string ShipmentNumber;
   
    
}