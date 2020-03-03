using System.Collections.Generic;
using University.Database;

namespace University.DataAccess.Facades {

    public abstract class AbstractFacade<T> where T : class  {

        protected UniversityContext GetContext { get; }

        protected AbstractFacade(UniversityContext context) {
            GetContext = context;
        }
        
        public abstract IEnumerable<T> GetAll();

    }

}