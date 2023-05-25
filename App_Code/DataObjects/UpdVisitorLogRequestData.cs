using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
/// <summary>
/// Summary description for ActivationRequestData
/// </summary>
[DataContract]
public class UpdVisitorLogRequestData
{
    [DataMember]
    public string BadgeNumber;
    
    [DataMember]
    public string VisitType;

   [DataMember]
    public string DepartmentName;

   [DataMember]
    public string VisitorName;

   [DataMember]
    public string CompanyName;

   [DataMember]
    public string ContactPerson;

   [DataMember]
    public string UserCode;

   [DataMember]
    public string TimeStamp;

   [DataMember]
    public string ScanID;

   [DataMember]
    public string DeviceID;


}