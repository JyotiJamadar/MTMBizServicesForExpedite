using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DispatchRequestForUnAccept
/// </summary>
[DataContract]
public class DispatchRequestForUnAccept
{
    [DataMember]
    public string DispatchID { get; set; }
   
    
}