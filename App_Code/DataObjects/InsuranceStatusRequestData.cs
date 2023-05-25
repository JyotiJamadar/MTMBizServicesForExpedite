using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for PoolRequestData
/// </summary>
public class InsuranceStatusRequestData
{
    [DataMember]
    public string ScacCode { get; set; }
    
}