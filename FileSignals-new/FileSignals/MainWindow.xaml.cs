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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileSignals.Controller;
using FileSignals.Model;
namespace FileSignals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyBuffer _Buffer = new MyBuffer( );
        List<string> Queue = new List<string>( );
        int counter = 0, bufferLength = 0,writerInQueue = 0,readerInQueue=0;
        public MainWindow( )
        {
            InitializeComponent( );
            tb_buffer.Text = "";

        }

        private void btn_write_Click( object sender, RoutedEventArgs e )
        {

            if ( bufferLength + txt_write.Text.Length < 33 )
            {
                for ( int i = 0; i < txt_write.Text.Length; i++ )
                {
                    Rectangle r = new Rectangle( );
                    r.Width = r.Height = 28;
                    r.Fill = Brushes.Red;
                    r.StrokeThickness = 2;
                    r.Stroke = Brushes.Transparent;
                    Queue.Add( "W" + txt_write.Text.Substring( i, 1 ) );
                    stackPanel1.Children.Add( r );
                    bufferLength += txt_write.Text.Length;
                    writerInQueue++;

                }
            }
            else
            {
                MessageBox.Show(
                    "Write operation will exceeded from buffer limit \n Do Read operation first",
                    "Buffer is Full", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            txt_write.Text = "";
            if ( bufferLength > 31 )
            {
                txt_write.IsEnabled = false;
            }


        }

        private void btn_read_Click( object sender, RoutedEventArgs e )
        {

            if ( tb_buffer.Text == "" || writerInQueue !=0)
            {
                MessageBox.Show(
                       "Data is not present or can not read data while writing is in progress\n Finish writing process then do read",
                       "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            else if ( readerInQueue > tb_buffer.Text.Length-1 )
            {
                MessageBox.Show(
                       "Current read operations will empty the buffer can not add more read operation",
                       "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            else
            {
                for ( int i = 0; i < Int32.Parse( txt_read.Text ); i++ )
                {
                    Rectangle r = new Rectangle( );
                    r.Width = r.Height = 28;
                    r.Fill = Brushes.Green;
                    r.StrokeThickness = 2;
                    r.Stroke = Brushes.Transparent;
                    Queue.Add( "R" + 1 );
                    stackPanel1.Children.Add( r );
                    readerInQueue++;

                }

                bufferLength = bufferLength - Int32.Parse( txt_read.Text );

                if ( bufferLength < 33 )
                {
                    txt_write.IsEnabled = true;
                }
            }

        }

        private void txt_write_GotFocus( object sender, RoutedEventArgs e )
        {

            if ( bufferLength < 33 )
            {
                txt_write.MaxLength = 32 - bufferLength;
            }
            else
            {
                txt_write.IsEnabled = false;
            }
        }

        public void readQueue( )
        {
            if ( stackPanel1.Children.Count != 0 && Queue[0] != null )
            {
                string dataForWrite = Queue[counter], operation;
                operation = dataForWrite.Substring( 0, 1 );
                if ( dataForWrite.Substring( 0, 1 ) == "W" )
                {
                    op.Content = "Write";
                    if ( _Buffer.Write( dataForWrite.Substring( 1, dataForWrite.Length - 1 ) ) )
                    {
                        tb_buffer.Text = MyBuffer.Data;
                        writerInQueue--;
                    }
                    else
                    {
                        MessageBox.Show( "Write operation will exceeded from buffer limit \n Do Read operation first", "Buffer is Full", MessageBoxButton.OK, MessageBoxImage.Error );
                    }


                }
                else if ( dataForWrite.Substring( 0, 1 ) == "R" )
                {
                    op.Content = "Read";
                    string dataForRead = tb_buffer.Text, currentBuffer;
                    currentBuffer = tb_buffer.Text;
                    lb_read.Items.Add( _Buffer.Read( Int32.Parse( dataForWrite.Substring( 1, dataForWrite.Length - 1 ) ) ) );
                    tb_buffer.Text = MyBuffer.Data.Remove( 0, Int32.Parse( dataForWrite.Substring( 1, dataForWrite.Length - 1 ) ) );
                    MyBuffer.Data = MyBuffer.Data.Remove( 0, Int32.Parse( dataForWrite.Substring( 1, dataForWrite.Length - 1 ) ) );
                    readerInQueue--;
                }
                data.Content = dataForWrite.Substring( 1, dataForWrite.Length - 1 );
                stackPanel1.Children.RemoveAt( 0 );                
                counter++;
                bufferLength--;
                if ( bufferLength < 33 )
                {
                    txt_write.IsEnabled = true;
                }

            }
            else
                MessageBox.Show( "Queue is Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
        }

        private void button1_Click( object sender, RoutedEventArgs e )
        {
            readQueue( );
        }
        public void addChildrenToWrapPanel( )
        {

        }

        private void Help_Clicked( object sender, RoutedEventArgs e )
        {
            Help help = new Help( );
            help.Show( );
        }









    }
}
