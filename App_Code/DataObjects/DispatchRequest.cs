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
public class DispatchRequest
{
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string FromLocation { get; set; }
    [DataMember]
    public string ToLocation { get; set; }
    [DataMember]
    public string TrailerStatus { get; set; }
    [DataMember]
    public string Priority { get; set; }
    [DataMember]
    public bool SafeToMove { get; set; }
    [DataMember]
    public string TimeStamp { get; set; }
    [DataMember]
    public string Comment { get; set; }
    [DataMember]
    public string UserCode { get; set; }
     [DataMember]
    public string Route { get; set; }

 [DataMember]
    public string Run{ get; set; }
    
    
}