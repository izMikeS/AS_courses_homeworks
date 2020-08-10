namespace OnlineStore.DBA.Repositories
{
    public class BaseRepository
    {
        protected OnlineStoreEntities CreateContext()
        {
            return new OnlineStoreEntities();
        }
    }
}
