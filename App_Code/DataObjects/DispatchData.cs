using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DispatchRequest
/// </summary>
[DataContract]
public class DispatchData
{

[DataMember]
    public string DispatchID { get; set; }
[DataMember]
    public string DeviceID { get; set; }
    [DataMember]
    public string UserCode { get; set; }
   
    
}