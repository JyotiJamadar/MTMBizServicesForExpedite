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
public class HookResponseData
{
    [DataMember]
    public string CreatedBy { get; set; }
    [DataMember]
    public string HookButNotDrop { get; set; }
     [DataMember]
    public string PlaCard { get; set; }

    [DataMember]
    public string TrailerStatus { get; set; }
   
}