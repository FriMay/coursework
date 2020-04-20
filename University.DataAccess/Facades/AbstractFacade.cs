using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

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
            GetContext.EnsureSeedData();
            return value;
        }

        public T Update(T value) {
            GetContext.Update(value);
            GetContext.SaveChanges();
            GetContext.EnsureSeedData();

            return value;
        }

        public T Delete(T value) {
            GetContext.Remove(value);
            GetContext.SaveChanges();
            GetContext.EnsureSeedData();
            return value;
        }
        
        public void DeleteRange(IQueryable<NotificationStudent> value) {
            GetContext.RemoveRange(value);
            GetContext.SaveChanges();
            GetContext.EnsureSeedData();
        }

        public abstract T Edit(int id, T value);

    }

}