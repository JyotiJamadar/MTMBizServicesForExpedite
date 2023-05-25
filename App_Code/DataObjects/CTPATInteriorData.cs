using System.Runtime.Serialization;
using System.Collections.Generic;

/// <summary>
/// Summary description for CTPATInteriorData
/// </summary>
[DataContract]
public class CTPATInspectionData
{
    [DataMember]
    public string Identifier { get; set; }
    [DataMember]
    public bool Pass { get; set; }
    [DataMember]
    public string PicturePath { get; set; }
}
[DataContract]
public class CTPATInteriorData
{
    [DataMember]
    public List<CTPATInspectionData> InspectionData { get; set; }
    [DataMember]
    public string TrailerID { get; set; }

    [DataMember]
    public string UserCode { get; set; }

    [DataMember]
    public string CTPATType { get; set; }

    [DataMember]
    public string DriverName { get; set; }

    [DataMember]
    public string Employer { get; set; }

    [DataMember]
    public string Placard { get; set; }

    [DataMember]
    public string SealNumber { get; set; }
    [DataMember]
    public string ScanTime { get; set; }
}