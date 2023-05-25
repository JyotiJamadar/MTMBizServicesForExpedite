using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DockDoorScheduleRequestData
/// </summary>
[DataContract]
public class DockDoorScheduleRequestData
{
    [DataMember]
    public string UserCode { get; set; }
   [DataMember]
    public string DoorCode { get; set; }
    
}