using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.User;

namespace University.Types.UserGroup {

    public class UserGroupType: ObjectGraphType<Database.Models.UserGroup> {

        public UserGroupType(GroupFacade groupFacade, UserFacade userFacade) {
            Field(x => x.Id);
            Field<GroupType>("group",
                resolve: context => groupFacade.GetById(context.Source.GroupId) 
            );
            Field<UserType>("user",
                resolve: context => userFacade.GetById(context.Source.UserId) 
            );
        }

    }

}