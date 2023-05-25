using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for LocationDetailsRequest
/// </summary>
[DataContract]
public class DropLocationRequest
{

    [DataMember]
    public string FacilityCode { get; set; }
}