using System;
using System.Collections.Generic;
using System.Text;

namespace UtilsNET
{
    public class Data
    {
        public Data()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BDate { get; set; }
        public string Spec { get; set; }
        public int SYear { get; set; }
        override public string ToString()
        {
            return $"{Id}. {Name}";
        }
    }

    public class DataComparer : IComparer<Data>
    {
        public int Compare(Data x, Data y)
        {
            return x.Id - y.Id;
        }
    }

    public class DataSorter : IComparer<Data>
    {
        public int Compare(Data x, Data y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}
