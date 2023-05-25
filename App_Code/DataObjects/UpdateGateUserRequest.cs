using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

[DataContract]
public class UpdateGateUserRequest
{
    [DataMember]
    public string Gate { get; set; }

    [DataMember]
    public string ProfileTemplateID { get; set; }

    [DataMember]
    public string UserCode { get; set; }

}