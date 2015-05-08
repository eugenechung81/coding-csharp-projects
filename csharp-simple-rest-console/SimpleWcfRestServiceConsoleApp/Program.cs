using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWcfRestServiceConsoleApp
{
    public class InputData
    {
        public string FirstName;
        public string LastName;
    }

    [ServiceContract]
    public class MyService
    {
        [WebGet(UriTemplate = "say/{something}", ResponseFormat=WebMessageFormat.Json)]
        public string AnswerBack(string something)
        {
            return "You said: " + something;
        }

        [WebInvoke(UriTemplate = "say2", ResponseFormat = WebMessageFormat.Json)]
        public string AnswerBackComplex(InputData data)
        {
            return "test";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using(var serviceHost = new ServiceHost(typeof(MyService)))
            {
                serviceHost.Open();
                Console.WriteLine("Hit Enter when done.");
                Console.ReadLine();
            }
        }
    }
}
