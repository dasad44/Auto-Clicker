using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoClicker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Thread space;
        Thread numOne;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StartStopTextBox.Text == "Off")
            {
                StartStopTextBox.Text = "On";
                space = new Thread(autoSpaceClick);
                space.Start();
                numOne = new Thread(autoNumOneClick);
                numOne.Start();
            }
            else
            {
                StartStopTextBox.Text = "Off";
                space.Abort();
                numOne.Abort();
            }
        }
        public void autoSpaceClick()
        {
            for (; ; )
            {
                SendKeys.SendWait("1");
                Thread.Sleep(4000);
            }
        }

        public void autoNumOneClick()
        {
            for (; ; )
            {
                SendKeys.SendWait(" ");
                Thread.Sleep(1000);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            space.Abort();
            numOne.Abort();
        }
    }
}
