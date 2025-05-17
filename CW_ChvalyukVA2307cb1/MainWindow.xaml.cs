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

namespace CW_ChvalyukVA2307cb1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_ord_Click(object sender, RoutedEventArgs e)
        {
            Add_order add = new Add_order();
            this.Hide();
            add.ShowDialog();
            this.Show();

        }

        private void editing_Click(object sender, RoutedEventArgs e)
        {
            Add_order add = new Add_order();
            this.Hide();
            add.ShowDialog();
            this.Show();
        }
    }
}