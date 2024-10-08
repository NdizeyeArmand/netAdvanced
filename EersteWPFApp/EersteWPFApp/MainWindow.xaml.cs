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

namespace EersteWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Label1.Content = "Een nieuwe naam";
            //TextBox tb = new TextBox();
            //tb.Text = "Even testen";
            //tb.Visibility = Visibility.Visible;
            //tb.Height = 30;
            //tb.Width = 200;
            //tb.Margin = new Thickness(0, 100, 0, 0);
            //tb.HorizontalAlignment = HorizontalAlignment.Left;
            //MainGrid.Children.Add(tb);
            //MainGrid.Children.Add(new TextBox { Text="Even Testen", Height = 30, MaxWidth = 100, Margin = new Thickness(0, 100, 0, 0), HorizontalAlignment = HorizontalAlignment.Left });
            //int h = (int) TextBox.ActualHeight;
            //MainGrid.Children.Add(new StackPanel();

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Button1.Content == "Klik op mij")
            {
                Button1.Content = "Klik opnieuw!";
            }
            else
            {
                Button1.Content = "Klik op mij";
            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Button2.VerticalAlignment == VerticalAlignment.Top)
            {
                Button2.VerticalAlignment = VerticalAlignment.Bottom;
            }
            else
            {
                Button2.VerticalAlignment = VerticalAlignment.Top;
            }
        }
    }
}