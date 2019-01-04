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
            string[] name = { "abc", "aaa", "bbb", "bade", "cca" };

            var query1 = from x in name
                         where x.Contains("a")
                         select x;


            foreach (var item in query1)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.ReadKey();




            int[] numList = { 10, 20, 30, 40, 11, 21,31,41};
            var query2 = from x in numList
                        where x % 2 == 0
                        select x;
            var query3 = numList.Where(x => x % 2 == 0).OrderBy(x => x).FirstOrDefault();

           
        }
    }
}
