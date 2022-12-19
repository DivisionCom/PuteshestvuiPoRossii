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
    /// Interaction logic for PageHotelEdit.xaml
    /// </summary>
    public partial class PageHotelEdit : Page
    {
        private Hotel _hotel;
        private PageHotel _page;
        public PageHotelEdit(object o, PageHotel pageHotel)
        {
            InitializeComponent();
            _hotel = (o as Button).DataContext as Hotel;

            _page = pageHotel;

            cmbHotelCountry.ItemsSource = ConnectOdb.conObj.Country.ToList();

            tboxHotelName.Text = _hotel.Name;
            tboxHotelStars.Text = _hotel.CountOfStars.ToString();
            tboxHotelDescription.Text = _hotel.Description;
            cmbHotelCountry.SelectedItem = _hotel.Country;
        }

        private void btnHotelUpdate_Click(object sender, RoutedEventArgs e)
        {
            _hotel.Name = tboxHotelName.Text;
            _hotel.CountOfStars = Convert.ToInt32(tboxHotelStars.Text);
            _hotel.Description = tboxHotelDescription.Text;
            _hotel.Country = cmbHotelCountry.SelectedItem as Country;

            _page.RefreshHotels();
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Данные успешно редактированы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            FrameObj.frameMain.GoBack();
        }
    }
}
