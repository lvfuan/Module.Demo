using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManager docM = new DocumentManager();
            ProcessDocument.Start(docM);
            for (int i = 0; i < 100; i++)
            {
                Document doc = new Document($"添加队列任务,标题:<<{i}>>", $"内容:<<{i}>>");
                docM.AddQueue(doc);
                Console.WriteLine(doc.Title,doc.Content);
                Thread.Sleep(new Random().Next(2000));
            }
            Console.Read();
        }
    }
}
