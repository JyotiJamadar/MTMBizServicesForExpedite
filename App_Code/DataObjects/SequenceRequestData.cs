using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for SequenceRequestData
/// </summary>
[DataContract]
public class SequenceRequestData
{
    [DataMember]
    public string DoorGroupCode { get; set; }
    [DataMember]
    public string FacilityCode { get; set; }
}