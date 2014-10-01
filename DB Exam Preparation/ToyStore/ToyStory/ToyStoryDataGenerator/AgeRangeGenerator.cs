using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStory.Data;

namespace ToyStoryDataGenerator
{
    public class AgeRangeGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities db, int count)
            : base(randomGenerator, db, count)
        {
        }
        public override void Generate()
        {
            int counter = 0;
            Console.WriteLine("Adding age ranges.");

            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < i + 5; j++)
                {
                    var ageRange = new AgeRanx
                    {
                        MinimumAge = i,
                        MaximumAge = j
                    };

                    this.Db.AgeRanges.Add(ageRange);

                    if (counter % 100 == 0)
                    {
                        Console.Write(".");
                        this.Db.SaveChanges();
                    }

                    counter++;
                    if (counter >= this.Count)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Age ranges added!");
                        return;
                    }
                }
            }

            
        }
    }
}
