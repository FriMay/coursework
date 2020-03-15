using GraphQL.Types;

namespace University.Types.Group {

    public class GroupInputType : InputObjectGraphType {

        public GroupInputType() {
            Field<StringGraphType>("name");
        }

    }

}