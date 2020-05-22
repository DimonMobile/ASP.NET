using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BDate { get; set; }
        public string Spec { get; set; }
        public int SYear { get; set; }
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
