using MyApp.Context;
using MyApp.Entities;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;

namespace MyApp.WebServices
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "WSMessage" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez WSMessage.svc ou WSMessage.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class WSMessage : IWSMessage
    {
        public void DoWork()
        {
        }

        [WebMethod]
        public List<Message> GetMessageFromUsersFollow(String nickName)
        {
            List<Message> finalList = new List<Message>();

            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                MessageRepository repoMessage = new MessageRepository(context);
                User userConnected = repo.getUser(nickName);

                if(userConnected != null)
                {
                    foreach (var user in userConnected.listUsersfollow)
                    {
                        List<Message> messages = repoMessage.getAllByName(user.nickName);
                        foreach (var message in messages)
                        {
                            finalList.Add(message);
                        }
                    }
                }
                else
                {
                    return null;
                }

                return finalList;
            }
        }

        public String SendMessage(String nickName, String msg)
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repoUser = new UserRepository(context);
                MessageRepository repoMessage = new MessageRepository(context);

                User user = repoUser.getUser(nickName);
                if(user != null && msg != null)
                {
                    Message message = new Message()
                    {
                        author = user.nickName,
                        text = msg
                    };
                    repoMessage.Add(message);
                    context.SaveChanges();
                    return "Message envoyé par l utilisateur " + user.nickName + ".";
                } else
                {
                    return "Le message ne s est pas envoyé";
                }
                
            }
        }
    }
}
