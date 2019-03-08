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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldMap.WorldInfo.ViewModels;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace WorldMap.WorldInfo.Views
{
    /// <summary>
    /// Interaction logic for WorldDetail.xaml
    /// </summary>
    public partial class WorldDetail : UserControl
    {
        public WorldDetail(WorldViewModel worldViewModel)
        {
            InitializeComponent();
            DataContext = worldViewModel;
        }
        
    }
}
