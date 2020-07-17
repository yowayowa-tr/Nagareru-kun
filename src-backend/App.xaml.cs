using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace src_backend
{
    public partial class App : Application
    {
        Authentiaction authentication = new Authentiaction();
        GetMessage getMessage = new GetMessage();
        SetMessage setMessage = new SetMessage();
        UpdatedMessage updatedMessage = new UpdatedMessage();
    }
}
