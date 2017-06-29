/*
 * NuGet  FluentScheduler
 * using  FluentScheduler
 * 新建操作class继承IJob
 * 新建class继承 Registry  在构造函数内执行操作类Class
 * 
 */


using System;
using FluentScheduler;

namespace Console.FluentScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            JobManager.Initialize(new Demo());
            System.Console.Read();
        }
    }
}
