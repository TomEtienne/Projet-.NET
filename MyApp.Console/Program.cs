using MyApp.Console.ExternalWebService;
using MyApp.Console.ExternalWebServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ExternalWebService.WSLoginClient webServiceLogin = new ExternalWebService.WSLoginClient();
            ExternalWebServiceMessage.WSMessageClient webServiceMessage = new ExternalWebServiceMessage.WSMessageClient();

            // WSLogin
            System.Console.Write("Entrez le pseudo :");
            String nickName = System.Console.ReadLine();

            System.Console.Write("Entrez le mot de passe :");
            String password = System.Console.ReadLine();

            webServiceLogin.DoWork();
            System.Console.Write("DoWork is ok \n");

            User u = webServiceLogin.Validate(nickName, password);
            System.Console.Write("Validate is ok \n");

            // WSMessage
            System.Console.Write("Entrez le pseudo :");
            String nickNameMessage = System.Console.ReadLine();
            Message[] messages = webServiceMessage.GetMessageFromUsersFollow(nickNameMessage);
            System.Console.Write("Messages récupérés depuis l utilisateur" + nickNameMessage);

            String msg = System.Console.ReadLine();
            String message = webServiceMessage.SendMessage(nickNameMessage, msg);
        }
    }
}
