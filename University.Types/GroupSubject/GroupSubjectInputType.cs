using GraphQL.Types;

namespace University.Types.GroupSubject {

    public class GroupSubjectInputType: InputObjectGraphType  {

        public GroupSubjectInputType() {
            Field<IntGraphType>("dayOfWeek");
            Field<IntGraphType>("orderNumber");
            Field<IntGraphType>("subjectId");
            Field<IntGraphType>("teacherId");
            Field<IntGraphType>("groupId");
        }

    }

}