using GraphQL.Types;

namespace University.Types.UserGroup {

    public class UserGroupInputType : InputObjectGraphType {

        public UserGroupInputType() {
            Field<IntGraphType>("userId");
            Field<IntGraphType>("groupId");
        }

    }

}