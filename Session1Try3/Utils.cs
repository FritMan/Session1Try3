using Session1Try3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Session1Try3
{
    public static class Utils
    {
        public static SessionsTry2DbEntities1 Db = new SessionsTry2DbEntities1 ();

        public static DispatcherTimer Global = new DispatcherTimer { Interval=TimeSpan.FromSeconds(60)};

        public static Frame MainMainFrame;

        public static int ExitCount = 0;

        public static void Global_Tick(object sender, EventArgs e)
        {
            if(ExitCount == 0)
            {
                MessageBox.Show("Осталось 60 секунд");
                ExitCount++;
            }
            else
            {
                MainMainFrame.Content = new Pages.AuthPage();
                ExitFlag=true;
                ExitCount = 0;
            }
        }

        public static bool ExitFlag = false;
    }
}
