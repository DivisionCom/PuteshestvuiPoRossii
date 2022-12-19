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
    /// Interaction logic for PageHotel.xaml
    /// </summary>
    public partial class PageHotel : Page
    {
        private Hotel _hotel;
        private int _currentPage = 1;
        private int _maxPage = 0;
        public PageHotel()
        {
            InitializeComponent();

            DataGridHotel.ItemsSource = ConnectOdb.conObj.Hotel.OrderBy(h => h.Name).ToList();
            RefreshHotels();
        }

        public void RefreshHotels()
        {
            DataGridHotel.ItemsSource = ConnectOdb.conObj.Hotel.OrderBy(h => h.Name).ToList();
            _maxPage = ConnectOdb.conObj.Hotel.OrderBy(h => h.Name).ToList().Count / 10;

            var listHotels = ConnectOdb.conObj.Hotel.OrderBy(h => h.Name).ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            tblockPageCount.Text = " из " + _maxPage.ToString();
            tboxPageNumber.Text = _currentPage.ToString();
            DataGridHotel.ItemsSource = listHotels;
        }

        private void btnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoFirstPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoBackPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoForwardPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoLastPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
