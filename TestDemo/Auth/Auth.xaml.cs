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

namespace TestDemo.Auth
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        demoEntities entities = new demoEntities(); 
        public Auth()
        {
            InitializeComponent();
        }

        public void LoginUser() 
        {
            

            if (LoginUserText.Text == "" || PasswordUser.Password == "")
                MessageBox.Show("Заполните поля", "OK", MessageBoxButton.OK, MessageBoxImage.Error);
            else 
            {
                string login = LoginUserText.Text.Trim();
                string password = PasswordUser.Password.Trim();

                user user = new user();
                role role = new role();

                user = entities.user.Where(p => p.Name == login && p.Password == password).FirstOrDefault();
                
                if (user != null) 
                {
                    if (user.idRole == 1)
                    {
                        var window = new Request.Request();
                        window.Show();
                        this.Close();
                    }
                    else if (user.idRole == 2)
                    {
                        var window = new Client.Client();
                        window.Show();
                        this.Close();
                    }
                    else if (user.idRole == 3) 
                    {

                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }
    }
}
