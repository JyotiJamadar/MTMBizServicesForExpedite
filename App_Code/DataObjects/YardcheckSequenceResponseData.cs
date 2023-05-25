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
public class YardcheckSequenceResponseData
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public List<YardcheckSequence> LocationsDetails { get; set; }
}
[DataContract]
public class YardcheckSequence
{
   
   
    [DataMember]
    public string LocationCode { get; set; }
    [DataMember]
    public string Location { get; set; }
    [DataMember]
    public string LocationTypeCode { get; set; }
   



}