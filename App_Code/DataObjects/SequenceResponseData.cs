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
public class SequenceResponseData
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public List<Sequence> LocationsDetails { get; set; }
}
[DataContract]
public class Sequence
{
   
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string TrailerStatusCode { get; set; }
    [DataMember]
    public string LocationCode { get; set; }
    [DataMember]
    public string Location { get; set; }
    [DataMember]
    public string LocationTypeCode { get; set; }
    [DataMember]
    public string LoadType { get; set; }
    [DataMember]
    public string SequentialBarcode { get; set; }
    [DataMember]
    public string Comment { get; set; }
 [DataMember]
    public string Placard { get; set; }



}