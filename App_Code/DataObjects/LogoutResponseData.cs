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
public class LogoutResponseData
{
    [DataMember]
    public DateTime LoggedoutTime { get; set; }
    
    
}