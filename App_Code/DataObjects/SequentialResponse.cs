using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for SequentialResponse
/// </summary>
[DataContract]
public class SequentialResponse
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public List<SequentialResponseData> Data { get; set; }

}
[DataContract]
public class SequentialResponseData
{
    
    [DataMember (Order=1)]
    public string Code { get; set; }
    [DataMember (Order=2)]
    public string Name { get; set; }
   // [DataMember (Order=3)]
    //public List<ValidData> Doors { get; set; }
[DataMember (Order=3)]
   public List<SequentialResponseDataData> Locations { get; set; }
}

public class SequentialResponseDataData
{
    
    [DataMember]
    public string Zone{ get; set; }
    [DataMember]
    public string LocationPrefix{ get; set; }
    [DataMember]
    public string Name{ get; set; }
   [DataMember]
    public string StartLocation{ get; set; }
[DataMember]
    public string EndLocation{ get; set; }
[DataMember]
    public string SortOrder{ get; set; }
   

}