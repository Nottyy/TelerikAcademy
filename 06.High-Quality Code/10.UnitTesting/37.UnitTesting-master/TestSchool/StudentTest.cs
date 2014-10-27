namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Schools;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestNewStudentConstructorName()
        {
            string name = "Ivan Ivanov";
            int id = 12233;
            Student student = new Student(name, id);
            Assert.AreEqual(student.Name, name);
        }

        [TestMethod]
        public void TestNewStudentConstructorId()
        {
            string name = "Ivan Ivanov";
            int id = 12233;
            Student student = new Student(name, id);
            Assert.AreEqual(student.StudentId, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNewStudentConstructorNullName()
        {
            string name = null;
            int id = 12233;
            Student student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNewStudentConstructorEmptyName()
        {
            string name = string.Empty;
            int id = 12233;
            Student student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewStudentConstructorZeroId()
        {
            string name = "Ivan Ivanov";
            int id = 0;
            Student student = new Student(name, id);
        }

        [TestMethod]
        public void TestNewStudentConstructorOnMinLimitId()
        {
            string name = "Ivan Ivanov";
            int id = 10000;
            Student student = new Student(name, id);
            Assert.AreEqual(id, student.StudentId);
        }

        [TestMethod]
        public void TestNewStudentConstructorOnMaxLimitId()
        {
            string name = "Ivan Ivanov";
            int id = 99999;
            Student student = new Student(name, id);
            Assert.AreEqual(id, student.StudentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewStudentConstructorBelowMinLimitId()
        {
            string name = "Ivan Ivanov";
            int id = 9999;
            Student student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewStudentConstructorAboveMaxLimitId()
        {
            string name = "Ivan Ivanov";
            int id = 100000;
            Student student = new Student(name, id);
            Assert.AreEqual(id, student.StudentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewStudentConstructorNegativeId()
        {
            string name = "Ivan Ivanov";
            int id = -1112;
            Student student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewStudentConstructorNegativeLimitOfIntId()
        {
            string name = "Ivan Ivanov";
            int id = int.MinValue;
            Student student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewStudentConstructorPositiveLimitOfIntId()
        {
            string name = "Ivan Ivanov";
            int id = int.MaxValue;
            Student student = new Student(name, id);
        }

        [TestMethod]
        public void TestStudentToString()
        {
            string name = "Ivan Ivanov";
            int id = 12233;
            Student student = new Student(name, id);
            string expected = "12233 Ivan Ivanov";
            string actual = student.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
