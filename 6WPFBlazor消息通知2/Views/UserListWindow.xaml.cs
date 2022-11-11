using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WPFBlazorChat.Views;


    public partial class UserListWindow : Window
    {
        public UserListWindow()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddMasaBlazor();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }