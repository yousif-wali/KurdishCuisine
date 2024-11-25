using KurdishCuisine.Views;
using Xamarin.Forms;

namespace KurdishCuisine
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(Setting), typeof(Setting));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Post), typeof(Post));
        }

    }
}

