using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Timezone
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //TimeZone is the elective Double API service for A6
        [OperationContract]
        string GetTimezone(string zipcode);//a service that provides the user with the time, date, and timezone of the entered zipcode
        
    }
}