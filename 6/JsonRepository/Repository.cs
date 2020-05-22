using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UtilsNET;

namespace BSTU.JsonRepository
{
    public class Repository : IPhoneDictionary
    {
        SortedSet<Data> database = null;

        public Repository()
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

        public void saveData()
        {
            using (StreamWriter stream = new StreamWriter(@"d:\MyFiles\BSTU\3rd\2nd\ASP\ASP.NET\6\3\data.json"))
            {
                stream.Write(JsonConvert.SerializeObject(this.database));
            }
        }

        public SortedSet<Data> loadData()
        {
            Data[] objects;
            using (StreamReader stream = new StreamReader(@"d:\MyFiles\BSTU\3rd\2nd\ASP\ASP.NET\6\3\data.json"))
            {
                objects = JsonConvert.DeserializeObject<Data[]>(stream.ReadToEnd());
            }
            this.database = new SortedSet<Data>(objects, new DataComparer());
            return this.database;
        }

        public void Dispose()
        {
            // Do nothing
        }
    }
}
