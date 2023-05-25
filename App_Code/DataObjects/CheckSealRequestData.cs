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
[DataContract]
public class CheckSealRequestData
{
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string Seal { get; set; }
   
}