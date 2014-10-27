namespace ToyStoryDataGenerator
{
    using System;
    using ToyStory.Data;
    public class CategoryGenerator : DataGenerator, IDataGenerator
    {
        public CategoryGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities db, int count)
            : base(randomGenerator, db, count)
        {
        }
        public override void Generate()
        {
            Console.WriteLine("Adding Cateories");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category
                {
                    Name = this.RandomDataGenerator.GetRandomStringWithRandomLength(5, 50),
                };

                this.Db.Categories.Add(category);

                if (i % 1000 == 0)
                {
                    Console.Write(".");
                    this.Db.SaveChanges();
                }
            }
            Console.WriteLine();
            Console.WriteLine("CategoriesAdded");
        }
    }
}
