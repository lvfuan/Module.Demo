using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Extend.Demo;

namespace UnitTest.Show
{
    [TestClass]
    public class ExtendTest
    {
        /// <summary>
        /// 测试StringExt
        /// </summary>
        [TestMethod]
        public void TestStringExt()
        {
            var b="dfg".IsInt();
        }
        /// <summary>
        /// 测试Student
        /// </summary>
        [TestMethod]
        public void TestStudent()
        {
            Student stu = new Student(1,"jack","lvfuan@163.com");
            var b= stu.isValidEmail();
        }
    }
}
