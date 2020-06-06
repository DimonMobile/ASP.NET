using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilsNET;

namespace _8.Models
{
    public class Repository : IPhoneDictionary
    {
        Dict_Entity context;

        public Repository()
        {
            context = new Dict_Entity("Data Source=DESKTOP-F7FM35G\\SQLEXPRESS;Initial Catalog=ASP;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
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

        public void saveData()
        {

        }

        public SortedSet<Data> loadData()
        {
            return new SortedSet<Data>();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
