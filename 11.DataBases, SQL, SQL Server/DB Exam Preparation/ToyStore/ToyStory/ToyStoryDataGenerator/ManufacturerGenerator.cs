using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStory.Data;

namespace ToyStoryDataGenerator
{
    public class ManufacturerGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities db, int count)
            : base(randomGenerator, db, count)
        {
        }
        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();

            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.RandomDataGenerator.GetRandomStringWithRandomLength(5, 50));
            }

            var index = 0;

            Console.WriteLine("Adding manufacturers.");
            foreach (var manufacturerName in manufacturersToBeAdded)
            {
                var manufacturer = new Manufacturer
                {
                    Name = manufacturerName,
                    Country = this.RandomDataGenerator.GetRandomStringWithRandomLength(2,50)
                };

                this.Db.Manufacturers.Add(manufacturer);

                if (index % 1000 == 0)
                {
                    Console.Write(".");
                    this.Db.SaveChanges();
                }

                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Manufacturers added!");
        }
    }
}
