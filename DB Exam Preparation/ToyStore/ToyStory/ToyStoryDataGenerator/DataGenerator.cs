namespace ToyStoryDataGenerator
{
    using ToyStory.Data;

    public abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator randomGenerator;
        private ToyStoreEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomGenerator, ToyStoreEntities db, int count)
        {
            this.randomGenerator = randomGenerator;
            this.db = db;
            this.count = count;
        }

        protected IRandomDataGenerator RandomDataGenerator
        {
            get { return this.randomGenerator;  }
        }

        protected ToyStoreEntities Db
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
