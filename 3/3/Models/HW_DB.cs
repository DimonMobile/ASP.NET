using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _3.Models
{
    public class HW_DB
    {
        SortedSet<Data> database = null;

        public HW_DB()
        {
            this.database = new SortedSet<Data>(
                new Data[]
                {
                    new Data {Id = 1, Name = "Петров П.П.", BDate = new DateTime(2000, 12, 2), Spec = "ИСиТ", SYear = 2018},
                    new Data {Id = 2, Name = "Иванов И.И.", BDate = new DateTime(2001, 11, 3), Spec = "ИСиТ", SYear = 2018},
                    new Data {Id = 3, Name = "Сидоров С.С.", BDate = new DateTime(2002, 10, 4), Spec = "ИСиТ", SYear = 2018},
                    new Data {Id = 4, Name = "Мерченев М.М", BDate = new DateTime(1999, 5, 5), Spec = "ИСиТ", SYear = 2018},
                }, new DataComparer()
            );
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
                return this.database.Add(data);
            }
            saveData();
            return false;
        }

        public bool Delete(Data data)
        {
            loadData();
            if (this.database.Contains(data))
                return this.database.Remove(data);
            saveData();

            return false;
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
            using (StreamWriter stream = new StreamWriter(@"d:\MyFiles\BSTU\3rd\2nd\ASP\ASP.NET\3\3\data.json"))
            {
                stream.Write(JsonConvert.SerializeObject(this.database));
            }
        }

        private SortedSet<Data> loadData()
        {
            Data[] objects;
            using (StreamReader stream = new StreamReader(@"d:\MyFiles\BSTU\3rd\2nd\ASP\ASP.NET\3\3\data.json"))
            {
                objects = JsonConvert.DeserializeObject<Data[]>(stream.ReadToEnd());
            }
            return new SortedSet<Data>(objects, new DataComparer());
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
}