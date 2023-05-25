using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for SequenceResponseData
/// </summary>

[DataContract]
public class DropLocation
{


    [DataMember]
    public string Code { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Type { get; set; }





}