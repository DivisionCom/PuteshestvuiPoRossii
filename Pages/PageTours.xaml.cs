using PuteshestvuiPoRossii.AppData;
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

namespace PuteshestvuiPoRossii.Pages
{
    /// <summary>
    /// Interaction logic for PageTours.xaml
    /// </summary>
    public partial class PageTours : Page
    {
        private List<Tour> _tours = new List<Tour>();
        private string _FindedName;
        private string _SelectedType;
        public PageTours()
        {
            InitializeComponent();
            listTours.ItemsSource = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();

            List<AppData.Type> types = new List<AppData.Type>();
            types.Add(new AppData.Type() { Name = "Все типы" });
            types.AddRange(ConnectOdb.conObj.Type.OrderBy(t => t.Name).ToList());

            CmbTypes.ItemsSource = types;

            List<AppData.Type> type = new List<AppData.Type>();
            type.Add(new AppData.Type() { Name = "Все типы" });
            type.AddRange(ConnectOdb.conObj.Type.OrderBy(t => t.Name).ToList());
            CmbTypes.ItemsSource = type;

            _tours = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();
        }

        private void CmbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tours = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();
            RefreshTours(); 
        }

        private void tboxFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            _FindedName = tboxFind.Text;
            _tours = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();
            RefreshTours();
        }

        private void RefreshTours()
        {
            if (CmbTypes.SelectedItem != null)
            {
                if ((CmbTypes.SelectedItem as AppData.Type).Name != "Все типы")
                {
                    AppData.Type type = CmbTypes.SelectedItem as AppData.Type;
                    _SelectedType = type.Name;
                    _tours = (from t in _tours
                              from tn in t.Type
                              where tn.Name == _SelectedType
                              select t).ToList();
                }
                else if ((CmbTypes.SelectedItem as AppData.Type).Name == "Все типы")
                {
                    _tours = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();
                }
            }

            if (tboxFind.Text != "")
                _tours = _tours.OrderBy(t => t.Name).Where(t => t.Name.ToLower().Contains(_FindedName)).ToList();

            if ((bool)ChbActual.IsChecked)
                _tours = _tours.OrderBy(t => t.Name).Where(t => t.IsActual == true).ToList();

            listTours.ItemsSource = _tours;
        }

        private void ChbActual_Checked(object sender, RoutedEventArgs e)
        {
            _tours = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();
            RefreshTours();
        }

        private void ChbActual_Unchecked(object sender, RoutedEventArgs e)
        {
            _tours = ConnectOdb.conObj.Tour.OrderBy(tour => tour.Name).ToList();
            RefreshTours();
        }
    }
}
