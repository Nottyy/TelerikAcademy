namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();

            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>()))
                .Returns(this.FakeCarCollection.Where(c => c.Make == "BMW" && c.Model == "330d").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());
            mockedCarsRepository.Setup(x => x.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(x => x.Make).ToArray());
            mockedCarsRepository.Setup(x => x.SortedByYear())
               .Returns(this.FakeCarCollection.OrderBy(x => x.Year).ToArray());
            
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
