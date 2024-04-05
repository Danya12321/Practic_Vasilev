using Practic_Vasilev.@base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Practic_Vasilev.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private ObservableCollection<Useraccount> UserAccountsData = new ObservableCollection<Useraccount>();

        public AdminPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new PracticAutoContext())
                {
                    var userAccounts = context.Useraccounts.OrderBy(ua => ua.Userid).ToList();
                    UserAccountsData.Clear();
                    foreach (var userAccount in userAccounts)
                    {
                        UserAccountsData.Add(userAccount);
                    }
                }
                dataGrid.ItemsSource = UserAccountsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new PracticAutoContext())
                {
                    foreach (var userAccount in UserAccountsData)
                    {
                        var userAccountInDb = context.Useraccounts.Find(userAccount.Userid);
                        if (userAccountInDb != null)
                        {
                            userAccountInDb.Username = userAccount.Username;
                            userAccountInDb.Roleid = userAccount.Roleid;
                            userAccountInDb.Isactive = userAccount.Isactive;
                        }
                        else
                        {
                            context.Useraccounts.Add(userAccount);
                        }
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Изменения сохранены.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
