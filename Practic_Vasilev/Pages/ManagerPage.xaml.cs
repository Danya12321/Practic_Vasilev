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
    
    public partial class ManagerPage : Page
    {
        private ObservableCollection<Car> CarsData = new ObservableCollection<Car>();

        public ManagerPage()
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new PracticAutoContext())
                {
                    
                    foreach (var car in CarsData)
                    {
                        if (car.IdAuto == 0) 
                        {
                            context.Cars.Add(car); 
                        }
                        else
                        {
                            var carToUpdate = context.Cars.Find(car.IdAuto);
                            if (carToUpdate != null)
                            {
                                carToUpdate.Brand = car.Brand;
                                carToUpdate.Model = car.Model;
                                carToUpdate.Year = car.Year;
                                carToUpdate.Vin = car.Vin; 
                                carToUpdate.Color = car.Color;
                                carToUpdate.Mileage = car.Mileage;
                                carToUpdate.Status = car.Status;
                                carToUpdate.Price = car.Price;
                                carToUpdate.Warranty = car.Warranty;
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


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCars = dataGrid.SelectedItems.Cast<Car>().ToList();
            if (selectedCars.Count > 0)
            {
                using (var context = new PracticAutoContext())
                {
                    foreach (var car in selectedCars)
                    {
                        var carToDelete = context.Cars.Find(car.IdAuto);
                        if (carToDelete != null)
                        {
                            context.Cars.Remove(carToDelete);
                        }
                    }
                    context.SaveChanges();
                }

                MessageBox.Show("Выбранные автомобили удалены.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автомобиль для удаления.");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PracticAutoContext())
            {
                foreach (var car in CarsData)
                {
                    var carToUpdate = context.Cars.Find(car.IdAuto);
                    if (carToUpdate != null)
                    {
                        
                        carToUpdate.Brand = car.Brand;
                        carToUpdate.Model = car.Model;
                        carToUpdate.Year = car.Year;
                        carToUpdate.Vin = car.Vin; 
                        carToUpdate.Color = car.Color;
                        carToUpdate.Mileage = car.Mileage;
                        carToUpdate.Status = car.Status;
                        carToUpdate.Price = car.Price;
                        carToUpdate.Warranty = car.Warranty;
                    }
                }
                context.SaveChanges();
            }

            MessageBox.Show("Изменения сохранены.");
            LoadData();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
