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

namespace TestDemo.Client
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        demoEntities entities = new demoEntities(); 
        public Client()
        {
            InitializeComponent();
            foreach(var items in entities.request)
                ListRequest.Items.Add(items);
        }

        private void ListRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ListRequest.SelectedItem as request;
            if (select != null)
            {
                TextComment.Text = select.Comment.ToString();
            }
            else 
            {
                TextComment.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var select = ListRequest.SelectedItem as request;
            if (select == null) 
            {
                select = new request();
                entities.request.Add(select);
                ListRequest.Items.Add(select);
            }
                select.Comment = TextComment.Text;
            MessageBox.Show("Даннык сохранены", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
