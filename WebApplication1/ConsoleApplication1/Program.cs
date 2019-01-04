using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneList = new List<Phone>();

            Phone ph = new Phone();
            ph.Name = "iphone";
            ph.Price = 4000;

            phoneList.Add(ph);

            ph = new Phone();
            ph.Name = "华为";
            ph.Price = 3201;

            phoneList.Add(ph);

            foreach (var item in  phoneList)
            {
                Console.WriteLine("名称:{0}  价格:{1}", item.Name, item.Price);
            }
            Console.ReadLine();
        }



    }

}

