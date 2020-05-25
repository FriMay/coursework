using GraphQL.Types;

namespace University.Types.UserRole {

    public class UserRoleInputType : InputObjectGraphType {

        public UserRoleInputType() {
            Field<StringGraphType>("roleName");
        }

    }

}