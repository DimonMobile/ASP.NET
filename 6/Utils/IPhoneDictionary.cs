using System;
using System.Collections.Generic;

namespace Utils
{
    public interface IPhoneDictionary : IDisposable
    {
        Data Find(int id);
        bool Insert(Data data);
        bool Update(Data data);
        bool Delete(Data data);
        Data[] GetAll();
        void saveData();
        SortedSet<Data> loadData();
    }
}
