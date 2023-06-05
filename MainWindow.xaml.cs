using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rgr___BinTree_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewerModel viewerModel = new ViewerModel();
        SortedSet<ListBinTree> list;
        public MainWindow()
        {
            InitializeComponent();            
            list = viewerModel.Load();
            if (list != null)
            {
                foreach (ListBinTree item in list)
                {
                    ListElements.Items.Add(item.name);
                }
            }
        }

        private void CreateNewTerm_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTerm window = new CreateNewTerm(viewerModel);
            window.Closing += ClosingEvent;
            window.Show();
            CreateNewTerm.IsEnabled = false;
           
        }

        private void ListElements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text;
            text = File.ReadAllText($"{list.ElementAt(ListElements.SelectedIndex).link}");
            Description.Text = text;
        }
        
        private void ClosingEvent(object sender, EventArgs e)
        {
            ListElements.Items.Clear();
            list = viewerModel.Load();
            if (list != null)
            {
                foreach (ListBinTree item in list)
                {
                    ListElements.Items.Add(item.name);
                }
            }
            CreateNewTerm.IsEnabled = true;
         
        }
    }
}
