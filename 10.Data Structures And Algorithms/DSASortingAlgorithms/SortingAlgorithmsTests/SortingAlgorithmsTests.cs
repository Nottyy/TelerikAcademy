using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;
using System.Linq;
using System.Collections.Generic;

namespace SortingAlgorithmsTests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        SortableCollection<int> collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

        [TestMethod]
        public void TestSelectionSortShouldReturnCorrectElements()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            collection.Sort(sorter);

            Assert.AreEqual(collection.Items[0], 0);
            Assert.AreEqual(collection.Items[2], 22);
            Assert.AreEqual(collection.Items[collection.Items.Count - 1], 101);
        }

        [TestMethod]
        public void TestSelectionSortWithOneElement()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            collection.Items = new List<int>() { 1 };
            collection.Sort(sorter);

            Assert.AreEqual(collection.Items[0], 1);
        }

        [TestMethod]
        public void TestQuickSortShouldReturnCorrectElements()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            collection.Sort(sorter);

            Assert.AreEqual(collection.Items[0], 0);
            Assert.AreEqual(collection.Items[2], 22);
            Assert.AreEqual(collection.Items[collection.Items.Count - 1], 101);
        }

        [TestMethod]
        public void TestQuickSortWithOneElement()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            collection.Items = new List<int>() { 1 };
            collection.Sort(sorter);

            Assert.AreEqual(collection.Items[0], 1);
        }

        [TestMethod]
        public void TestMergeSortShouldReturnCorrectElements()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            collection.Sort(sorter);

            Assert.AreEqual(collection.Items[0], 0);
            Assert.AreEqual(collection.Items[2], 22);
            Assert.AreEqual(collection.Items[collection.Items.Count - 1], 101);
        }

        [TestMethod]
        public void TestMergeSortWithOneElement()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            collection.Items = new List<int>() { 1 };
            collection.Sort(sorter);

            Assert.AreEqual(collection.Items[0], 1);
        }
    }
}
