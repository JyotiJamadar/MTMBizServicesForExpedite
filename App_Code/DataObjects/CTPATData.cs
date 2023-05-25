using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for CTPATData
/// </summary>

[DataContract]
public class CTPATData
{
    [DataMember]
    public string CarrierName { get; set; }
    [DataMember]
    public string TractorNumber { get; set; }
    [DataMember]
    public string ContainerNumber { get; set; }
    [DataMember]
    public string SealNumber { get; set; }
    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public bool IsHighSecuritySeal { get; set; }
   
    [DataMember]
    public bool IsSealIntact { get; set; }
    [DataMember]
    public bool IsSealDocumentMatch { get; set; }
    [DataMember]
    public bool UnderCarriageChassis { get; set; }
    [DataMember]
    public string UCCComment { get; set; }
    [DataMember]
    public bool DoorsLockingMechanism { get; set; }
    [DataMember]
    public string DLMComment { get; set; }
    [DataMember]
    public bool RightSide { get; set; }
   
    [DataMember]
    public string RightSideComment { get; set; }
    [DataMember]
    public bool LeftSide { get; set; }
    [DataMember]
    public string LeftSideComment { get; set; }
    [DataMember]
    public bool FrontWall { get; set; }
    [DataMember]
    public string FrontWallComment { get; set; }

    [DataMember]
    public bool CeilingRoof { get; set; }

    [DataMember]
    public string CeilingRoofComment { get; set; }
    [DataMember]
    public bool Floor { get; set; }
    [DataMember]
    public string FloorComment { get; set; }
    [DataMember]
    public string ScanID { get; set; }
   
    [DataMember]
    public string TimeStamp { get; set; }
    [DataMember]
    public string DeviceID { get; set; }

}