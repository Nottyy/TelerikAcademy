using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStory.Data;

namespace ToyStoryDataGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRandomDataGenerator randomGenerator = RandomGenerator.Instance;
            ToyStoreEntities db = new ToyStoreEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>()
            {
                new CategoryGenerator(randomGenerator,db, 100),
                new ManufacturerGenerator(randomGenerator,db, 50),
                new AgeRangeGenerator(randomGenerator,db, 100),
                new ToyStoreGenerator(randomGenerator,db, 1000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
