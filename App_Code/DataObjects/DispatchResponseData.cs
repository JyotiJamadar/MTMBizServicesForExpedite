using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DispatchResponseData
/// </summary>
public class DispatchResponseData
{
    [DataMember]
    public string DispatchID { get; set; }
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string FromLocation { get; set; }
   [DataMember]
    public string FromDoorCode { get; set; }
    [DataMember]
    public string ToLocation { get; set; }
    [DataMember]
    public string ToDoorCode { get; set; }
    [DataMember]
    public string DispatchStatus { get; set; }
    [DataMember]
    public string TrailerStatus { get; set; }
    [DataMember]
    public string DispatchMessage { get; set; }
    [DataMember]
    public string Priority { get; set; }
 [DataMember]
    public string PriorityCode { get; set; }
 [DataMember]
     public string LoadType { get; set; }
    [DataMember]
    public string Message { get; set; }
    [DataMember]
    public string Store { get; set; }
    [DataMember]
    public string Run { get; set; }
   [DataMember]
    public string DriverGroup { get; set; }
 [DataMember]
    public string Timestamp { get; set; }
 [DataMember]
    public string Flag { get; set; }


}

public class DispatchResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public List<DispatchResponseData> DispatchData { get; set; }
}