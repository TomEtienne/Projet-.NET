﻿using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyApp.WebServices
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IWSLogin" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IWSLogin
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        User Validate(String nickName, String password);

    }
}
