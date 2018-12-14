using MyApp.Context;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyApp.WebServices
{
    /// <summary>
    /// Description résumée de WSLogin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WSLogin : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /*public string Validate(string nickName, string password)
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                if (repo.CheckUser(nickName, password))
                {
                    
                }
                else
                {
                    return null;
                }
            }
        }*/
    }
}
