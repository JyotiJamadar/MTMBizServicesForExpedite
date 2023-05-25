using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for CMInstanceUpdateData
/// </summary>
[DataContract]
public class CMInstanceUpdateData
{
    [DataMember]
    public string CMInstanceID { get; set; }
    
}