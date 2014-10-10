using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.EnterpriseWcf.Client
{
    public static class MonkeyServiceClientHelper
    {
        //TODO: Step 3 - Define the service endpoint
        private static readonly EndpointAddress ServiceEndPoint = new EndpointAddress("http://developer.xamarin.com/xamu-wcf/MonkeyService.svc");

        //TODO: Step 4 - Create our binding
        private static BasicHttpBinding CreateBasicHttpBinding()
        {
            var binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            var timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;

            return binding;
        }

        //TODO: Step 5 - Create a method that provides a configured service client
        public static MonkeyServiceClient CreateMonkeyServiceClient()
        {
            return new MonkeyServiceClient(CreateBasicHttpBinding(), ServiceEndPoint);
        }
    }
}
