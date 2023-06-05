using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace Rgr___BinTree_
{
    internal class Model
    {
        List<ListBinTree> listBinTrees = new List<ListBinTree>(); // список терминов 
        public SortedSet<ListBinTree> list = new SortedSet<ListBinTree>(); // отсортированный список терминов 
        XmlSerializer formatter = new XmlSerializer(typeof(List<ListBinTree>)); //  серриализатор 
        public void SortedTree() // сортировка списка терминов 
        {
            var sortedSet = new SortedSet<ListBinTree>(Comparer<ListBinTree>.Create((p1, p2) => String.Compare(p1.name,p2.name)));
            list = sortedSet;
        }
        public void Save(string termin , string description) // сохранение описание и термина 
        {
            // сохранение описание термина
            FileStream filestream = new FileStream($"TerminDesription\\{termin}.txt", FileMode.Create);

            StreamWriter streamWriter = new StreamWriter(filestream);

            streamWriter.WriteLine(description);

            streamWriter.Close();
            filestream.Close();

            // сохранение термина
            FileStream fileStream = new FileStream("Termins.xml", FileMode.OpenOrCreate);

            listBinTrees.Add(new ListBinTree { name = termin, link = $"TerminDesription\\{termin}.txt" });

            formatter.Serialize(fileStream, listBinTrees);
        }
        public SortedSet<ListBinTree> Load() // загрузка описания и термина
        {      
            var sortedSet = new SortedSet<ListBinTree>(Comparer<ListBinTree>.Create((p1, p2) => String.Compare(p1.name, p2.name)));
            List<ListBinTree> listBinTree;

            FileStream fileStream = new FileStream("Termins.xml", FileMode.Open);        

            listBinTree = formatter.Deserialize(fileStream) as List<ListBinTree>;

            if (listBinTree != null)
            {
                listBinTrees = listBinTree;
                foreach (var item in listBinTree)
                {
                    sortedSet.Add(item);
                }
            }
            list = sortedSet;
            return list;
        }
    }
}
