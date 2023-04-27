using Demo_LA05.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Demo_LA05.ConFactory;
using Demo_LA05.Model;
using Dapper;

namespace Demo_LA05
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = ConnFactory.GetOpenConnection())
            {
                var users = connection.Query<UsersModel>("select * from [Users] where Active = 1");

                var _currentUser = users.FirstOrDefault(u => u.UserName == tbUser.Text.ToString());

                if (_currentUser != null)
                {
                    try
                    {
                        MainWindow mainWindow = new MainWindow();
                        this.Close();
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid ex " + ex.Message);

                    }
                }
                else
                {
                    tbUser.Text = "";
                    pbPwd.Password = "";

                    MessageBox.Show("Hibás felhasználói adatok", "Belépési hiba",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                }


            }
        }
    }
}
