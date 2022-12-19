using PuteshestvuiPoRossii.AppData;
using PuteshestvuiPoRossii.Pages;
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

namespace PuteshestvuiPoRossii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectOdb.conObj = new TestEntities();
            FrameObj.frameMain = frmMain;
            //btnBack.Visibility = Visibility.Hidden;

            frmMain.Navigate(new PageMenu());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmMain.NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
