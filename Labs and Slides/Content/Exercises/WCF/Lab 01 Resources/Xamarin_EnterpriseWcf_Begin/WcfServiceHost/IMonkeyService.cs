using System.Collections.Generic;
using System.ServiceModel;
using WcfServiceHost.Model;

namespace WcfServiceHost
{
    [ServiceContract]
    public interface IMonkeyService
    {
        //TODO: Step 1 - Define our service contract
        //[OperationContract]
        //string GetRandomMonkeyName();

        //[OperationContract]
        //IEnumerable<MonkeyInformation> GetMonkeyMatch(MonkeyQuery query);
    }
}
