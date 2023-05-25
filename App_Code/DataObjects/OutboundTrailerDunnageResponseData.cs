using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;


/// <summary>
/// Summary description for LocationTrailerResponseData
/// </summary>
[DataContract]
public class OutboundTrailerDunnageResponseData
{


   // [DataMember(Order = 3)]
   // public string ErrorMessage { get; set; }
   // [DataMember(Order = 2)]
   // public bool Success { get; set; }
   // [DataMember(Order=4)]
  //  public int ErrorCode { get; set; }
  //  [DataMember(Order=1)]

[DataMember]
    public string Carrier { get; set; }
    [DataMember]
    public string WMSOrderNumber { get; set; }
     [DataMember]
    public string SAPShipmentNumber { get; set; }
     [DataMember]
     public string TrailerNumber { get; set; }
     [DataMember]
     public string CustomerName { get; set; }
     [DataMember]
     public string CityState { get; set; }
     [DataMember]
     public string PalletCount { get; set; }
     [DataMember]
     public string NumberofChepPallets { get; set; }
     [DataMember]
     public string StagingBay { get; set; }
     [DataMember]
     public string DockNumber { get; set; }
     [DataMember]
     public string CheckInTime { get; set; }
     [DataMember]
     public string CheckOutTime { get; set; }
     [DataMember]
     public string OutApptTime { get; set; }
     [DataMember]
     public string DriverName { get; set; }
     [DataMember]
     public string SignaturePath { get; set; }
     [DataMember]
     public string SealNumber { get; set; }
	[DataMember]
     public string OpenTime { get; set; }
	[DataMember]
     public string CloseTime { get; set; }


     [DataMember]
     public string OutApptNumber { get; set; }

	[DataMember]
     public string LoaderNotes { get; set; }

	[DataMember]
     public string CSRName { get; set; }
	[DataMember]
     public string CSRComment { get; set; }
}

