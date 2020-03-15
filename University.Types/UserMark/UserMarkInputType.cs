using GraphQL.Types;

namespace University.Types.UserMark {

    public class UserMarkInputType: InputObjectGraphType {


        public UserMarkInputType() {
            Field<DateTimeGraphType>("issueData");
            Field<IntGraphType>("markId");
            Field<IntGraphType>("studentId");
            Field<IntGraphType>("groupSubjectId");
        }
    }

}