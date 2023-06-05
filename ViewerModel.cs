using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Rgr___BinTree_
{
   
    public class ViewerModel
    {
       Model model = new Model(); // модель 

       public SortedSet<ListBinTree> ListWord() // сортировка терминов 
       {
          model.SortedTree();

          return model.list;
       }

       public void Save(string termin,string description) // сохранение для интерфейса
        {
            try
            {
                model.Save(termin, description);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }
       public SortedSet<ListBinTree> Load() // загрузка для интерфейса
        {
            try
            {
               return model.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
