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
    /// Interaction logic for PageHotelAdd.xaml
    /// </summary>
    public partial class PageHotelAdd : Page
    {
        private PageHotel _page;
        public PageHotelAdd(PageHotel pageHotel)
        {
            InitializeComponent();

            cmbHotelCountry.ItemsSource = ConnectOdb.conObj.Country.ToList();

            _page = pageHotel;
        }

        private void btnHotelAdd_Click(object sender, RoutedEventArgs e)
        {
            ConnectOdb.conObj.Hotel.Add(new Hotel()
            {
                Name = tboxHotelName.Text,
                CountOfStars = Convert.ToInt32(tboxHotelStars.Text),
                Description = tboxHotelDescription.Text,
                Country = cmbHotelCountry.SelectedItem as Country
            });
            ConnectOdb.conObj.SaveChanges();

            _page.RefreshHotels();

            MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            FrameObj.frameMain.GoBack();
        }
    }
}
