namespace OnlineStore.DBA.Contracts
{
    public interface IRepository<TType, TKey>
            where TType : class
            where TKey : struct
    {
        void Create(TType entity);

        TType GetById(TKey id);

        void Update(TType entity);

        void Delete(TType entity);

    }
}
