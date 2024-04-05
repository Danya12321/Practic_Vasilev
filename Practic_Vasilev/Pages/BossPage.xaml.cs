using Practic_Vasilev.@base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class BossPage : Page
    {
        private ObservableCollection<Employee> EmployeesData = new ObservableCollection<Employee>();

        public BossPage()
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
                    var employees = context.Employees.OrderBy(e => e.Employeeid).ToList();
                    EmployeesData = new ObservableCollection<Employee>(employees);
                }
                dataGrid.ItemsSource = EmployeesData;
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
                    foreach (var employee in EmployeesData)
                    {
                        if (employee.Employeeid == 0)
                        {
                            context.Employees.Add(employee);
                        }
                        else
                        {
                            var dbEntry = context.Employees.Find(employee.Employeeid);
                            if (dbEntry != null)
                            {
                                
                                dbEntry.Salary = employee.Salary;
                                
                            }
                        }
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Изменения сохранены.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        

       

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // Навигация обратно или закрытие текущей страницы
            NavigationService?.GoBack();
        }

    }
}
