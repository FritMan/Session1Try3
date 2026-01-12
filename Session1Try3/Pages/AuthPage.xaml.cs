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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Session1Try3.Utils;
namespace Session1Try3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private bool Flag = false;
        private int count = 0;
        private DispatcherTimer timerBlock = new DispatcherTimer { Interval = TimeSpan.FromSeconds(60) };
        DispatcherTimer dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };

        public AuthPage()
        {
            InitializeComponent();
            Generate();
        }

        private void Generate()
        {
            Random random = new Random();
            int x = random.Next(150);
            Canvas.SetLeft(InImg, x);
            CaptchaSlider.Value = x;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = Db.User.FirstOrDefault(el => el.Password == PwdPb.Password && el.Login == LogTb.Text);

            if(count == 0)
            {
                if (user != null)
                {
                    if (user.RoleId == 1)
                    {
                        NavigationService.Navigate(new AdminPage(user));
                    }
                    else if (user.RoleId == 2)
                    {
                        NavigationService.Navigate(new BuxPage(user));
                    }
                    else if (user.RoleId == 3)
                    {
                        NavigationService.Navigate(new LabPage(user));
                    }
                    else
                    {
                        NavigationService.Navigate(new LabResPage(user));
                    }

                    

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    CaptchaSp.Visibility = Visibility.Visible;
                    count++;
                }
            }
            else
            {

                if (user != null && Flag == true)
                {
                    if (user.RoleId == 1)
                    {
                        NavigationService.Navigate(new AdminPage(user));
                    }
                    else if (user.RoleId == 2)
                    {
                        NavigationService.Navigate(new BuxPage(user));
                    }
                    else if (user.RoleId == 3)
                    {
                        NavigationService.Navigate(new LabPage(user));
                    }
                    else
                    {
                        NavigationService.Navigate(new LabResPage(user));
                    }

                    count = 0;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль/ капча");
                    dispatcherTimer.Tick += DispatcherTimer_Tick;
                    dispatcherTimer.Start();
                    OkBtn.IsEnabled = false;
                }
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            OkBtn.IsEnabled = true;
            dispatcherTimer.Stop();
        }

        private void CaptchaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Canvas.SetLeft(InImg, CaptchaSlider.Value);

            if(CaptchaSlider.Value >= 205 && CaptchaSlider.Value <= 210)
            {
                Flag = true;
            }
            else
            {
                Flag = false;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Global.Stop();

            if(ExitFlag == true)
            {
                timerBlock.Tick += TimerBlock_Tick;
                timerBlock.Start();
                OkBtn.IsEnabled = false;
            }
        }

        private void TimerBlock_Tick(object sender, EventArgs e)
        {
            OkBtn.IsEnabled = true;
            timerBlock.Stop();
        }
    }
}
