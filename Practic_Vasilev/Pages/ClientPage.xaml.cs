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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private ObservableCollection<Car> CarsData = new ObservableCollection<Car>();

        public ClientPage()
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
                    var data = context.Cars.OrderBy(c => c.IdAuto).ToList();
                    CarsData.Clear();
                    foreach (var item in data)
                    {
                        CarsData.Add(item);
                    }
                }
                dataGrid.ItemsSource = CarsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
