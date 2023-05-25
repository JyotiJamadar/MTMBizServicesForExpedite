using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DockDoorRequestData
/// </summary>
[DataContract]
public class DockDoorRequestData
{
    [DataMember]
    public string UserCode { get; set; }
    
}