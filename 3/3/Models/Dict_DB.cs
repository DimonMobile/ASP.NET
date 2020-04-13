using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _3.Models
{
    public class Dict_DB
    {
        SortedSet<Data> database = null;

        public Dict_DB()
        {
            loadData();
        }

        public Data Find(int id)
        {
            loadData();
            Data readed;
            if (!this.database.TryGetValue(new Data() { Id = id }, out readed))
                throw new KeyNotFoundException();
            return readed;
        }

        public bool Insert(Data data)
        {
            loadData();
            if (this.database.Contains(data))
                return false;
            this.database.Add(data);
            saveData();
            return true;
        }

        public bool Update(Data data)
        {
            loadData();
            if (this.database.Contains(data))
            {
                this.database.Remove(data);
                this.database.Add(data);
            }
            saveData();
            return false;
        }

        public bool Delete(Data data)
        {
            loadData();
            if (this.database.Contains(data))
                this.database.Remove(data);
            saveData();

            return true;
        }

        public Data[] GetAll()
        {
            SortedSet<Data> objects = loadData();
            Data[] result = new Data[objects.Count];
            int i = 0;
            foreach (Data dt in objects)
                result[i++] = dt;

            return result;
        }

        private void saveData()
        {
            using (StreamWriter stream = new StreamWriter(@"D:\CodeProj\BSTU\ASP\ASP.NET\3\3\data.json"))
            {
                stream.Write(JsonConvert.SerializeObject(this.database));
            }
        }

        private SortedSet<Data> loadData()
        {
            Data[] objects;
            using (StreamReader stream = new StreamReader(@"D:\CodeProj\BSTU\ASP\ASP.NET\3\3\data.json"))
            {
                objects = JsonConvert.DeserializeObject<Data[]>(stream.ReadToEnd());
            }
            this.database = new SortedSet<Data>(objects, new DataComparer());
            return this.database;
        }
    }

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