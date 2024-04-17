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

namespace TestDemo.Request
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        demoEntities entities = new demoEntities();
        public Request()
        {
            InitializeComponent();
            foreach (var entity in entities.request)
                ListBoxRequest.Items.Add(entity);

            foreach (var entity in entities.Type)
                ComboType.Items.Add(entity);

            foreach (var entity in entities.client)
                ComboClient.Items.Add(entity);

            foreach (var entity in entities.status)
                ComboStatus.Items.Add(entity);

            foreach(var entity in entities.Implemetr)
                ComboIm.Items.Add(entity);

            foreach (var entity in entities.status)
                FilterCombo.Items.Add(entity);
        }

        private void ListBoxRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ListBoxRequest.SelectedItem as request;
            if (select != null)
            {
                TextOborud.Text = select.Oborud.ToString();
                TextDiscrip.Text = select.Discription.ToString();
                ComboType.SelectedItem = select.Type;
                ComboStatus.SelectedItem = select.status;
                ComboClient.SelectedItem = select.client;
                ComboIm.SelectedItem = select.Implemetr;
                DataText.Text = select.DateRequest.ToString();
            }
            else 
            {
                TextOborud.Text = "";
                TextDiscrip.Text = "";
                ComboType.SelectedItem = -1;
                ComboStatus.SelectedItem = -1;
                ComboClient.SelectedItem = -1;
                ComboClient.SelectedItem = -1;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var req = ListBoxRequest.SelectedItem as request;
            if (TextOborud.Text == "" || TextDiscrip.Text == "")
                MessageBox.Show("Заполните пустые поля", "OK", MessageBoxButton.OK, MessageBoxImage.Error);
            else 
            {
                if (req == null) 
                {
                    req = new request();
                    entities.request.Add(req);
                    ListBoxRequest.Items.Add(req);
                }
                req.Oborud = TextOborud.Text;
                req.Discription = TextDiscrip.Text;
                req.DateRequest = DateTime.Parse(DataText.Text);
                req.client = ComboClient.SelectedItem as client;
                req.status = ComboStatus.SelectedItem as status;
                req.Type = ComboType.SelectedItem as Type;
                req.Implemetr = ComboIm.SelectedItem as Implemetr;
                entities.SaveChanges();
                ListBoxRequest.Items.Refresh();
                MessageBox.Show("Даннык сохранены", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBoxRequest.Items.Clear();
            string con = SearchText.Text;
            if (!string.IsNullOrEmpty(con))
            {

                var found = entities.request.AsEnumerable().Where(att => att.Oborud.ToLower().Contains(con) || att.Id.ToString().Contains(con) ||
                        att.Implemetr.Name.ToLower().Contains(con) ||
                        att.status.StatusReq.ToLower().Contains(con));

                foreach (var c in found)
                {
                    ListBoxRequest.Items.Add(c);
                }
            }
            else
            {
                foreach (var lin in entities.request)
                {
                    ListBoxRequest.Items.Add(lin);
                }

            }
        }

        private void FilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStatus = FilterCombo.SelectedItem as status;

            if (selectedStatus != null)
            {
                // фильтруем запросы по выбранному статусу
                var filteredRequests = entities.request.Where(r => r.idStatus == selectedStatus.Id).ToList();

                // очищаем ListBox
                ListBoxRequest.Items.Clear();

                // добавляем отфильтрованные запросы в ListBox
                foreach (var request in filteredRequests)
                {
                    ListBoxRequest.Items.Add(request);
                }
            }
        }
    }
}
