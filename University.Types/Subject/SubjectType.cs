using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.GroupSubject;

namespace University.Types.Subject {

    public class SubjectType: ObjectGraphType<Database.Models.Subject> {

        public SubjectType(GroupSubjectFacade groupSubjectFacade) {
            Field(x => x.Id);
            Field<StringGraphType>("subjectName"
                ,
                resolve:context=> context.Source.SubjectName);
            Field<ListGraphType<GroupSubjectType>>("groupSubjects",
                resolve: context => groupSubjectFacade.GetBySubjectId(context.Source.Id)
            );
        }
        

    }

}