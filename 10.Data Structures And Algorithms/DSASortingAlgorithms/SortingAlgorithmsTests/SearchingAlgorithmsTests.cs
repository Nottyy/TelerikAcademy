using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;
using System.Collections.Generic;

namespace SortingAlgorithmsTests
{
    [TestClass]
    public class SearchingAlgorithmsTests
    {
        SortableCollection<int> collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

        [TestMethod]
        public void TestBinarySearchExistingElementShouldReturnTrue()
        {
            collection.Items = new List<int>() { 1, 2, 3, 4, 5, 101 };
            bool elementExists = collection.BinarySearch(101);

            Assert.IsTrue(elementExists);
        }

        [TestMethod]
        public void TestBinarySearchNonExistingElementShouldReturnFalse()
        {
            collection.Items = new List<int>() { 1, 2, 3, 4, 5, 101 };
            bool elementExists = collection.BinarySearch(555);

            Assert.IsFalse(elementExists);
        }

        [TestMethod]
        public void TestLinearSearchNonExistingElementShouldReturnFalse()
        {
            bool elementExists = collection.LinearSearch(555);

            Assert.IsFalse(elementExists);
        }

        [TestMethod]
        public void TestLinearSearchExistingElementShouldReturnTrue()
        {
            bool elementExists = collection.LinearSearch(101);

            Assert.IsTrue(elementExists);
        }
    }
}
