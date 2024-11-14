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

namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Lógica interna para Search_2.xaml
    /// </summary>
    public partial class Search_2 : Window
    {
        public Search_2()
        {
            InitializeComponent();
        }
        private void botão_filtro(object sender, RoutedEventArgs e)
        {
            panel_filtro.Visibility = panel_filtro.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

    }
}
