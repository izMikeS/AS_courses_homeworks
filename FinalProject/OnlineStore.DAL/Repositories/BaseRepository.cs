namespace OnlineStore.DAL.Repositories
{
    public class BaseRepository
    {
        protected StoreDbContext Context { get; }

        public BaseRepository(StoreDbContext s)
        {
            Context = s;
        }
    }
}
