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

namespace CW_ChvalyukVA2307cb1
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Window
    {
        public authorization()
        {
            using (var db = new ChvalyukCwDbContext())
            {
                db.Database.EnsureCreated();
            }
                InitializeComponent();
        }

        private void Registration1_Click(object sender, RoutedEventArgs e)
        {
            registration reg= new registration();
            this.Hide();
            reg.ShowDialog();
            this.Show();
        }

        private void Enter1_Click(object sender, RoutedEventArgs e)
        {
            string login=Login.Text;
            string password = Passwordbox.Password;
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            try
            {
                using (var context = new ChvalyukCwDbContext())
                {
                    var user = context.Пользовательs.FirstOrDefault(e => e.Логин == login && e.Пароль == password);
                    if (user != null)
                    {
                        MainWindow main = new MainWindow();
                        this.Hide();
                        main.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:{ex.Message}");
            }
            
        }
    }
}
