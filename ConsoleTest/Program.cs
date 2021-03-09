using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Model;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GeneratorCode("KL","A999"));

            Tuple<List<AdminModel>, int> tuple = new Tuple<List<AdminModel>, int>(
                new List<AdminModel> 
                {
                    new AdminModel{ AdminID = 1, UserName = Guid.NewGuid().ToString() },
                    new AdminModel{ AdminID = 2, UserName = Guid.NewGuid().ToString()
                }
            }, 100
            );

            //输出列表数据
            Console.WriteLine("-----列表-------");
            foreach (var item in tuple.Item1)
            {
                Console.WriteLine(item.UserName);
            }

            Console.WriteLine("-----总记录数-------");
            Console.WriteLine(tuple.Item2);


            Console.ReadLine();
        }

    }
}
