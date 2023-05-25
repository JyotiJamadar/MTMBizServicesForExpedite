using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DispatchReplyData
/// </summary>
public class DunnageUpdateRequest
{
    [DataMember]
    public string SAPShipmentNumber { get; set; }
    [DataMember]
    public string LoaderName { get; set; }
    [DataMember]
    public string LoadStart { get; set; }
    [DataMember]
    public string LoadEnd { get; set; }
    [DataMember]
    public string AirBagNumber { get; set; }
    [DataMember]
    public string NumberOfVoids { get; set; }
    [DataMember]
    public string DriverName { get; set; }
    [DataMember]
    public string DriverSignatruePath { get; set; }
    [DataMember]
    public string NumberOfBlocks { get; set; }

  [DataMember]
    public string OutApptNumber { get; set; }

 [DataMember]
    public string NumberOfWalls { get; set; }

}