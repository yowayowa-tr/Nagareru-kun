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
        private static Authentiaction _authentication = new Authentiaction();
        private GetMessage _getMessage;
        private SetMessage _setMessage;
        private UpdatedMessage _updatedMessage;

        public static Authentiaction GetAuthentication { get { return _authentication; } }
    }
}
