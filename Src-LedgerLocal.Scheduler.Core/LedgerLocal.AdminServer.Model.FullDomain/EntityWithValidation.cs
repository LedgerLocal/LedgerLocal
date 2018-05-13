using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Model.FullDomain
{
    public class EntityWithValidation<T>
            where T : class
    {
        private T _entity;
        private IList<Tuple<string, string>> _errors;
        private bool _success;

        public EntityWithValidation(T entity)
        {
            _errors = new List<Tuple<string, string>>();
            _entity = entity;
        }

        public EntityWithValidation(T entity, bool errors)
        {
            _success = errors;
            _entity = entity;
        }

        public T Entity
        {
            get
            {
                return _entity;
            }
        }

        public IList<Tuple<string, string>> Errors
        {
            get
            {
                return _errors;
            }
        }

        public bool IsSuccess
        {
            get { return _success; }
        }
    }
}
