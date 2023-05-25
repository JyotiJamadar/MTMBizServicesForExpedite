using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
/// <summary>
/// Summary description for ActivationRequestData
/// </summary>
[DataContract]
public class ActivationRequestData
{
    [DataMember]
    public string ActivationKey { get; set; }
}