using GraphQL.Types;
using University.Types.Group;
using University.Types.User;

namespace University.Types.UserGroup {

    public class UserGroupType: ObjectGraphType<Database.Models.UserGroup> {

        public UserGroupType() {
            Field(x => x.Id);
            Field<GroupType>("group",
                resolve: context => context.Source.Group
            );
            Field<UserType>("user",
                resolve: context => context.Source.User
            );
        }

    }

}