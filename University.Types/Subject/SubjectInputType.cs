using GraphQL.Types;

namespace University.Types.Subject {

    public class SubjectInputType: InputObjectGraphType {

        public SubjectInputType() {
            Field<StringGraphType>("subjectName");
        }

    }

}