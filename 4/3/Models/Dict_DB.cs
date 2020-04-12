using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace _3.Models
{
    public class Dict_DB
    {
        Dict_Entity context;

        public Dict_DB()
        {
            context = new Dict_Entity();
        }

        public Data Find(int id)
        {
            Data d = context.Dicts.Find(id);
            return d;
        }

        public bool Insert(Data data)
        {
            context.Dicts.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Update(Data data)
        {
            Data dat = context.Dicts.Find(data.Id);
            dat.Name = data.Name;
            dat.BDate = data.BDate;
            dat.Spec = data.Spec;
            dat.SYear = data.SYear;
            context.SaveChanges();
            return false;
        }

        public bool Delete(Data data)
        {
            Data dat = context.Dicts.Find(data.Id);
            context.Dicts.Remove(dat);

            context.SaveChanges();
            return true;
        }

        public Data[] GetAll()
        {
            return context.Dicts.ToArray();
        }

        private void saveData()
        {
            
        }

        private SortedSet<Data> loadData()
        {
            return new SortedSet<Data>();
        }
    }

    public class Data
    {
        [Key]
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