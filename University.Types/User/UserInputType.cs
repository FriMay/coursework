using GraphQL.Types;

namespace University.Types.User {

    public class UserInputType : InputObjectGraphType {

        public UserInputType() {
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("secondName");
            Field<StringGraphType>("lastName");
            Field<StringGraphType>("login");
            Field<StringGraphType>("password");
            Field<IntGraphType>("userRoleId");
        }

    }

}