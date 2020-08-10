using OnlineStore.DBA;
using System;

namespace OnlineStore.BL.ReportGenerators
{
    public abstract class ReportGeneratorBase : IDisposable
    {
        protected OnlineStoreEntities _dbContext = new OnlineStoreEntities();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
