using GraphQL.Types;

namespace University.Types.Mark {

    public class MarkInputType: InputObjectGraphType {

        public MarkInputType() {
            Field<StringGraphType>("markValue");
        }
    }

}