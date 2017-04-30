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
using System.Windows.Shapes;
using System.Diagnostics;

using System.Windows.Threading;

namespace WpfApplication1
{
    /*
    Class: LoadingPage
    Description: A window used as a graphical indicator for loading a windowed form.
    Parent: Window
    */
    public partial class LoadingPage : Window
    {
        //Timmers for thread and time frame to close window
        Stopwatch myWat = new Stopwatch();
        DispatcherTimer myTime;


        /*
        Method: LoadingPage
        Description: A Constructor toiitialize the components of the window
        */
        public LoadingPage()
        {
            InitializeComponent();
            myTime = new DispatcherTimer(DispatcherPriority.ContextIdle, Dispatcher); 
        }



        /*
        Method: OnAnimaTick
        Description: Code that executes on the DispatchTimer tick
        */
        private void OnAnimaTick(Object sender, EventArgs e)
        {
            
            SpinnerTransform.Angle += .10;

            if(myWat.ElapsedMilliseconds > 10000)
            {
                //Console.WriteLine("In If");
                myWat.Stop();
                myTime.Stop();
                MainWindow myWin = new MainWindow();
                this.Close();
                myWin.Show();
            }
        }


        /*
        Method: InitState
        Description: Called after the window has been loaded.
        */  
        private void InitState(object sender, RoutedEventArgs e)
        {
            myTime.Tick += OnAnimaTick;
            myWat.Start();
            myTime.Start();
        }

    }//End Class
}//End of namespace
