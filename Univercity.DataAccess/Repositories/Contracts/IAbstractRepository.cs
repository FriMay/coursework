using System.Collections.Generic;

namespace University.DataAccess.Repositories.Contracts {

    public interface IAbstractRepository<out T> {

        IEnumerable<T> GetAll();

    }

}