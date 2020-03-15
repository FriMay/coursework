using System.Collections.Generic;
using University.Database;

namespace University.DataAccess.Facades {

    public abstract class AbstractFacade<T> where T : class  {

        protected UniversityContext GetContext { get; }

        protected AbstractFacade(UniversityContext context) {
            GetContext = context;
        }
        
        public abstract IEnumerable<T> GetAll();

        public T Add(T value) {
            GetContext.Add(value);
            GetContext.SaveChanges();
            return value;
        }

        public T Update(T value) {
            GetContext.Update(value);
            GetContext.SaveChanges();
            return value;
        }

        public T Delete(T value) {
            GetContext.Remove(value);
            GetContext.SaveChanges();
            return value;
        }

        public abstract T Edit(int id, T value);

    }

}