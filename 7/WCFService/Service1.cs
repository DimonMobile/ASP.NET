using BSTU.SqlServerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UtilsNET;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        Repository r = new Repository();

        public Data[] GetDict()
        {
            return r.GetAll();
        }

        public void AddDict(Data data)
        {
            r.Insert(data);
        }

        public void UdpDict(Data data)
        {
            r.Update(data);
        }

        public void DelDict(Data data)
        {
            r.Delete(data);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
