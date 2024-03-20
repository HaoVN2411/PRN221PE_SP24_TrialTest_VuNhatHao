using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private Eyeglasses2024DBContext context = new Eyeglasses2024DBContext();
        private GenericRepository<StoreAccount> _storeAccount;
        private GenericRepository<LensType> _lensType;
        private GenericRepository<Eyeglass> _eyeGlass;



        public GenericRepository<StoreAccount> StoreAccountRepository
        {
            get
            {
                if (this._storeAccount == null)
                {
                    this._storeAccount = new GenericRepository<StoreAccount>(context);
                }
                return _storeAccount;
            }
        }

        public GenericRepository<LensType> LensTypeRepository
        {
            get
            {
                if (this._lensType == null)
                {
                    this._lensType = new GenericRepository<LensType>(context);
                }
                return _lensType;
            }
        }

        public GenericRepository<Eyeglass> EyeglassRepository
        {
            get
            {
                if (this._eyeGlass == null)
                {
                    this._eyeGlass = new GenericRepository<Eyeglass>(context);
                }
                return _eyeGlass;
            }
        }




        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
