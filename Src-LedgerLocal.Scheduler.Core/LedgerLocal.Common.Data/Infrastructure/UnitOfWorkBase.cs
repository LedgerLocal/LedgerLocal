using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Common.Data.Infrastructure
{
    public class UnitOfWorkBase<D> : IUnitOfWork
        where D : DbContext
    {
        private D dataContext;
        private object syncObject = new object();

        public UnitOfWorkBase(IDatabaseFactory<D> databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory<D> DatabaseFactory
        {
            get;
            private set;
        }

        protected virtual D DataContext
        {
            get
            {
                if (dataContext == null)
                {
                    lock (syncObject)
                    {
                        if (dataContext == null)
                        {
                            dataContext = DatabaseFactory.Get();
                        }
                    }
                }

                return dataContext;
            }
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
