using Npgsql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Practic_Vasilev.@base;
using Practic_Vasilev.Pages;

namespace PracticeBetonNetV.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var login = UsernameTextBox.Text;
                var password = HashPassword(PasswordBox.Password); 
                Console.WriteLine(password);

                using (var context = new PracticAutoContext()) 
                {
                    var user = context.Useraccounts 
                        .Where(u => u.Username == login && u.Passwordhash == password) 
                        .Include(u => u.Role) 
                        .FirstOrDefault();

                    if (user != null)
                    {
                        
                        switch (user.Roleid)
                        {
                            case 1: 
                                NavigationService.Navigate(new ManagerPage());
                                break;
                            case 2: 
                                NavigationService.Navigate(new AdminPage());
                                break;
                            case 3: 
                                NavigationService.Navigate(new BossPage());
                                break;
                            case 4: 
                                NavigationService.Navigate(new ClientPage());
                                break;
                            
                            default:
                                MessageBox.Show("Недопустимая роль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль введены неверно.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Вычисление хеша
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Преобразование байтового массива в строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
