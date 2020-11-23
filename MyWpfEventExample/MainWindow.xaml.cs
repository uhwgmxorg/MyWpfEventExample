using System;
using System.Windows;

namespace MyWpfEventExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private delegate void TheCall();

        TheCall _theCall;

        private Window _toolWindow;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _toolWindow = CreateToolWindow();
            _theCall = new TheCall(MyBeep);
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Button_Click_ToolWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_ToolWindow(object sender, RoutedEventArgs e)
        {
            _toolWindow.Show();
            _toolWindow.Owner = this;
        }

        /// <summary>
        /// Button_Click_Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events
        
        /// <summary>
        /// BeepEventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeepEventHandler(object sender, EventArgs e)
        {
            _theCall();
        }
        private void MyBeep()
        {
            Console.Beep();
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// CreateToolWindow
        /// </summary>
        /// <returns></returns>
        private Window CreateToolWindow()
        {
            ToolWindow toolWindow = new ToolWindow();
            toolWindow.WindowStyle = WindowStyle.ToolWindow;
            toolWindow.ShowInTaskbar = false;
            toolWindow.BeepEvent += BeepEventHandler;

            return toolWindow;
        }

        #endregion

    }
}
