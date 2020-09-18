using Microsoft.Graph;
using Application = System.Windows.Application;

namespace src_backend
{
    public partial class App : Application
    {
        public static GraphServiceClient client;
        public static Authentiaction auth = new Authentiaction();
        public static MessageHandler messageHandler = new MessageHandler();
    }
}