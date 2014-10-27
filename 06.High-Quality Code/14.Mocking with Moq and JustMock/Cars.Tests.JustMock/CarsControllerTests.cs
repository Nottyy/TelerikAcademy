namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        //New Test Methods

        [TestMethod]
        public void SearchShouldReturnValidResultWithModelEquals330dAndMakeEqualsBMW()
        {
            var model = (ICollection<Car>)(this.controller.Search("").Model);
            
            Assert.AreEqual("330d", model.First().Model);
            Assert.AreEqual("BMW", model.First().Make);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingWithInvalidSortingParameterShouldThrowArgumentException()
        {
            var model = (ICollection<Car>)(this.controller.Sort("InvalidSortingParameter").Model);
        }

        [TestMethod]
        public void SortShouldReturnSortedCollectionByMake()
        {
            var model = (ICollection<Car>)(this.controller.Sort("make").Model);
            var expectedFirstCarMake = model.First().Make;
            var expectedLastCarMake = model.Last().Make;
            var actualFirstCarMake = "Audi";
            var actualLastCarMake = "Opel";

            Assert.AreEqual(expectedFirstCarMake, actualFirstCarMake);
            Assert.AreEqual(expectedLastCarMake, actualLastCarMake);
        }

        [TestMethod]
        public void SortShouldReturnSortedCollectionByYear()
        {
            var model = (ICollection<Car>)(this.controller.Sort("year").Model);
            var expectedFirstCarYear = model.First().Year;
            var expectedLastCarYear = model.Last().Year;
            var actualFirstCarYear = 2005;
            var actualLastCarYear = 2010;

            Assert.AreEqual(expectedFirstCarYear, actualFirstCarYear);
            Assert.AreEqual(expectedLastCarYear, actualLastCarYear);
        }

        

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
