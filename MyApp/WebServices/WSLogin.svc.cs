using MyApp.Context;
using MyApp.Entities;
using MyApp.Models;
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
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "WSLogin" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez WSLogin.svc ou WSLogin.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class WSLogin : IWSLogin
    {
        public void DoWork()
        {
            
        }

        [WebMethod]
        public User Validate(string nickName, string password)
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                if (repo.CheckUser(nickName, password))
                {
                    User user = repo.getUser(nickName);
                    User userModel = new User()
                    {
                        nickName = user.nickName,
                        email = user.email,
                        firstName = user.firstName,
                        lastName = user.lastName,
                        UserPhoto = null
                    };
                    return userModel;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
