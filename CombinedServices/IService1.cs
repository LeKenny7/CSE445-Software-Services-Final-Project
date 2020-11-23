using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CombinedServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetFilteredData(string URLContent);

        [OperationContract]
        string GetTopWordsData(string filteredString);

        [OperationContract]
        string GetWeatherData(string zipcode);
    }
}
