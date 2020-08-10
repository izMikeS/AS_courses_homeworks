using System.Collections.Generic;

namespace OnlineStore.BLL.Contracts
{
    public interface IService<TType, TKey>
        where TType : class
        where TKey: struct
    {
        void Create(TType entity);

        TType GetById(TKey id);

        void Update(TType entity);

        void Delete(TKey entity);

        List<TType> GetAllAtPage(int page = 1, int countAtPage = 10);
    }
}
