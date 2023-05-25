using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for DockDoorResponseData
/// </summary>
[DataContract]
public class DockDoorResponseData
{
    [DataMember]
    public bool Success { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
    [DataMember]
    public int ErrorCode { get; set; }
    [DataMember]
    public List<DockDoorResponse> LocationsDetails { get; set; }
}
[DataContract]
public class DockDoorResponse
{
   [DataMember]
    public string Location { get; set; }
    [DataMember]
    public string LocationCode { get; set; }
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string SequentialBarCode { get; set; }
    [DataMember]
    public string Scac { get; set; }
    [DataMember]
    public string Carrier { get; set; }
    [DataMember]
    public string TrailerNumber { get; set; }
 [DataMember]
    public string LoadType { get; set; }
[DataMember]
    public string TrailerStatus { get; set; }
[DataMember]
    public string Comment { get; set; }
[DataMember]
    public string Route { get; set; }
[DataMember]
    public string Run { get; set; }
[DataMember]
    public string Placard { get; set; }
[DataMember]
    public string UnloadStart { get; set; }
[DataMember]
    public string UnloadEnd { get; set; }
[DataMember]
    public string ReloadStart { get; set; }
[DataMember]
    public string ReloadEnd { get; set; }
[DataMember]
    public string YardPass { get; set; }
[DataMember]
    public string ULDate { get; set; }

[DataMember]
    public string ULStart{ get; set; }
[DataMember]
    public string ULEnd { get; set; }
[DataMember]
    public string TrailerType { get; set; }
[DataMember]
    public string PlannedReloadStart { get; set; }
[DataMember]
    public string PlannedReloadEnd { get; set; }
[DataMember]
    public string PlannedReloadDate { get; set; }
[DataMember]
    public string Period { get; set; }
[DataMember]
    public string LoadTypeCode { get; set; }
[DataMember]
    public string TrailerStatusCode { get; set; }
[DataMember]
    public string Container { get; set; }
[DataMember]
    public string IsMagnoliaDoor { get; set; }
[DataMember]
    public string LastAction { get; set; }
[DataMember]
    public string LastActionOn { get; set; }
[DataMember]
    public string ULCounter { get; set; }
[DataMember]
    public string RecordID { get; set; }
[DataMember]
    public string CTIID { get; set; }


}