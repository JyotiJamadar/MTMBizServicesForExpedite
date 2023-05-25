using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for LookupResponseData
/// </summary>
public class TotalUserMoveResponseData
{
    [DataMember]
    public string AcceptedCount { get; set; }
    [DataMember]
    public string HookedCount { get; set; }
    [DataMember]
    public string DroppedCount { get; set; }
    [DataMember]
    public string UserCode { get; set; }
  
    
}