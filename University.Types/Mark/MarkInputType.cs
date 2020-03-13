using GraphQL.Types;

namespace University.Types.Mark {

    public class MarkInputType: InputObjectGraphType {

        public MarkInputType() {
            Name = "MarkInputType";
            Field<NonNullGraphType<StringGraphType>>("markValue");
        }
    }

}