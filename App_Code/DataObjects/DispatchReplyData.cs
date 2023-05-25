using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DispatchReplyData
/// </summary>
public class DispatchReplyData
{
    [DataMember]
    public int DispatchID { get; set; }
    [DataMember]
    public string Reply { get; set; }
    [DataMember]
    public string UserCode { get; set; }
}