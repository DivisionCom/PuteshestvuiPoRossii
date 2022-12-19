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
    /// Interaction logic for PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void btnTours_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageTours());
        }

        private void btnHotels_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageHotel());
        }
    }
}
