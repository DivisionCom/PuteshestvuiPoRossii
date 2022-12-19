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
            _maxPage = (int)Math.Ceiling(ConnectOdb.conObj.Hotel.OrderBy(h => h.Name).ToList().Count * 1.0 / 10);

            var listHotels = ConnectOdb.conObj.Hotel.OrderBy(h => h.Name).ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            tblockPageCount.Text = _currentPage.ToString() + " из " + _maxPage.ToString();
            DataGridHotel.ItemsSource = listHotels;
        }

        private void btnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageHotelEdit(sender ,this));
        }

        private void btnGoFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshHotels();
        }

        private void btnGoBackPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
                _currentPage--;
            else
                return;
            RefreshHotels();
        }

        private void btnGoForwardPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _maxPage)
                _currentPage++;
            else
                return;
            RefreshHotels();
        }

        private void btnGoLastPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshHotels();
        }

        private void btnHotelDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранный отель?" + _hotel.Name,
                "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                var hotelObj = DataGridHotel.SelectedItems.Cast<Hotel>().ToList();
                ConnectOdb.conObj.Hotel.RemoveRange(hotelObj);
                ConnectOdb.conObj.SaveChanges();

                RefreshHotels();
                MessageBox.Show("Данные успешно удалены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnHotelAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageHotelAdd(this));
        }
    }
}
