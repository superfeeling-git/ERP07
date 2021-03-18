using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ERP.Model;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 3)
                    {
                        Console.WriteLine("服务器超时，要有对应的捕获机制");
                        throw new Exception("出错了");                        
                    }
                }
            }
            catch (Exception e)
            {
                ReTry();
            }
            finally
            {

            }

            Console.ReadLine();
        }

        static void ReTry()
        {
            Console.WriteLine("模拟重试5秒钟");
            Thread.Sleep(new TimeSpan(0, 0, 5));
            Console.WriteLine("重试成功");
        }
    }
}
