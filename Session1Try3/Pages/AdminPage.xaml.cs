using Session1Try3.Data;
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
using System.Windows.Threading;
using static Session1Try3.Utils;

namespace Session1Try3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private DateTime End = DateTime.Now + TimeSpan.FromSeconds(21);
        private DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
        public AdminPage(User user)
        {
            InitializeComponent();
            AuthSp.DataContext = user;

            Global.Start();
        }

        private void Timer()
        {
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var remaing = End - DateTime.Now;


            TimerLab.Content = remaing.ToString(@"mm\:ss");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Timer();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
