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
public class LogoutRequest
{
    [DataMember]
    public string UserCode{ get; set; }
    [DataMember]
    public string LogoutTime{ get; set; }
   [DataMember]
    public string DeviceID{ get; set; }
    
}