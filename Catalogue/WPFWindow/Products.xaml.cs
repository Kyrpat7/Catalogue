using Stasiewski.Catalogue.BL;
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

namespace Stasiewski.Catalogue.WPFWindow
{
    /// <summary>
    /// Logika interakcji dla klasy Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        private static Query _globalQuery;
        public static Query GlobalQuery
        {
            get { return _globalQuery; }
        }
        public Products()
        {
            _globalQuery = new Query();
            InitializeComponent();
        }
    }
}
