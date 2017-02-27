using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileSignals
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help( )
        {
            InitializeComponent( );
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            textBlock1.Text = " - Design the whole project in OOAD \n- Ideas regarding User Interface \n- Simulate Test cases \n- Provide Help regaring XAML";
            textBlock2.Text = "- Code all the design\n- Final the project\n- Implemented the OOAD in OOP";
            textBlock3.Text = "- User Interface \nCode the Buffer Class\n- Suggestions in making the project in OOAD";
            textBlock4.Text = "The project is to simulate the Producer Consumer Problem so called Bounded Buffer problem.\n- Project is made in Visual Studio 2010 SP1\n- Plateform depandancy is .Net Framework 4.0\n- C#(C Sharp) is used for support\n- XAML is used for creating User Interface\n- Buffer length is 32-bytes \n- It will allow only 32-characters to write in buffer\n- It will not support Read operation while writing operation is in the Queue.\n- Only one writer can write.\n- Write operation can be done while reading.\n- There is no support for Auto-Operation user have to initiate the process.";
        }

        
    }
}
