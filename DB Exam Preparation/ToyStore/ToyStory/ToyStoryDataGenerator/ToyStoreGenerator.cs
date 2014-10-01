using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStory.Data;

namespace ToyStoryDataGenerator
{
    public class ToyStoreGenerator : DataGenerator, IDataGenerator
    {
        public ToyStoreGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities db, int count)
            : base(randomGenerator, db, count)
        {
        }

        public override void Generate()
        {
            var manufactureIds = this.Db.Manufacturers.Select(m => m.Id).ToList();
            var ageRangesIds = this.Db.AgeRanges.Select(a => a.Id).ToList();
            var categoryIds = this.Db.Categories.Select(c => c.Id).ToList();

            Console.WriteLine("Adding toys");
            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Type = this.RandomDataGenerator.GetRandomStringWithRandomLength(5, 45),
                    Price = this.RandomDataGenerator.GetRandomNumber(5, 500),
                    Color = this.RandomDataGenerator.GetRandomNumber(1, 5) == 5 ? null : this.RandomDataGenerator.GetRandomStringWithRandomLength(3, 10),
                    ManufacturerId = manufactureIds[this.RandomDataGenerator.GetRandomNumber(0, manufactureIds.Count - 1)],
                    AgeRangesId = ageRangesIds[this.RandomDataGenerator.GetRandomNumber(0, ageRangesIds.Count - 1)],
                };

                if (categoryIds.Count > 1)
                {
                    var uniqueCateoryIds = new HashSet<int>();

                    var categoriesInToy = this.RandomDataGenerator.GetRandomNumber(1, Math.Min(10, categoryIds.Count));
                    while (uniqueCateoryIds.Count != categoriesInToy)
                    {
                        uniqueCateoryIds.Add(categoryIds[this.RandomDataGenerator.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }

                    foreach (var uniqueCategoryId in uniqueCateoryIds)
                    {
                        toy.Categories.Add(this.Db.Categories.Find(uniqueCategoryId));
                    }
                    this.Db.Toys.Add(toy);
                }

                if (i % 100 == 0 )
                {
                    Console.Write(".");
                    this.Db.SaveChanges();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Toys added");
        }
    }
}
