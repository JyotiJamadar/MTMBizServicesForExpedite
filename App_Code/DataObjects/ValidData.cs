using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for ValidData
/// </summary>
[DataContract]
public class ValidData
{
    [DataMember]
    public string Code { get; set; }
    [DataMember]
    public string Name { get; set; }
    public ValidData(string ValidCode, string ValidName)
    {
        this.Code = ValidCode;
        this.Name = ValidName;
    }
}


[DataContract]
public class ValidDataForLocation
{
    [DataMember]
    public string Code { get; set; }
    [DataMember]
    public string Name { get; set; }
     [DataMember]
    public string Type { get; set; }
    public ValidDataForLocation(string ValidCode, string ValidName, string ValidTypeCode)
    {
        this.Code = ValidCode;
        this.Name = ValidName;
         this.Type = ValidTypeCode;
    }
}