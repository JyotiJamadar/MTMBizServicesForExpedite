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
public class BackoutAcceptedRequest
{
    [DataMember]
    public string DIspatchID { get; set; }
    [DataMember]
    public string Reason { get; set; }
    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public string TimeStamp { get; set; }

    
    
}