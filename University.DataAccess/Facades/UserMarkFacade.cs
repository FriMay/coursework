using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserMarkFacade: AbstractFacade<UserMark> {

        public UserMarkFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<UserMark> GetAll() {
            return GetContext.UserMarks;
        }

        public IEnumerable<UserMark> GetByMarkId(int id) {
            return GetContext.UserMarks.Where(x => x.Mark.Id == id);
        }

    }

}