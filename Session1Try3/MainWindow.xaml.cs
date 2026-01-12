using Session1Try3.Pages;
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
using static Session1Try3.Utils;

namespace Session1Try3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainMainFrame = MainFrame;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Content = new AuthPage();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Global.Tick += Utils.Global_Tick;
        }

        private void MainFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
           TitleLab.Content = (e.Content as Page).Title;
        }
    }
}
