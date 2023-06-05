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
using System.Windows.Shapes;

namespace Rgr___BinTree_
{
    /// <summary>
    /// Логика взаимодействия для CreateNewTerm.xaml
    /// </summary>
    public partial class CreateNewTerm : Window
    {
        ViewerModel viewerModel;
        public CreateNewTerm(ViewerModel viewerModel)
        {
            InitializeComponent();
            this.viewerModel = viewerModel;
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            viewerModel.Save(Termin.Text, Description.Text);
        }

        private void Termin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Description.Text != "") Create_Button.IsEnabled = true;
            if (Termin.Text == "") Create_Button.IsEnabled = false;
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Termin.Text != "") Create_Button.IsEnabled = true;
            if (Description.Text == "") Create_Button.IsEnabled= false;  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                
        }
    }
}
