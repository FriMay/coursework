using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.Subject;
using University.Types.User;
using University.Types.UserMark;

namespace University.Types.GroupSubject {

    public class GroupSubjectType: ObjectGraphType<Database.Models.GroupSubject> {

        public GroupSubjectType(UserMarkFacade userMarkFacade) {
            Field(x => x.Id);
            Field(x => x.OrderNumber);
            Field(x => x.DayOfWeek);
            Field<ListGraphType<UserMarkType>>(
                "userMarks",
                resolve: context => userMarkFacade.GetByGroupSubjectId(context.Source.Id));
            
            Field<SubjectType>("subject",
                resolve: context => context.Source.Subject
            );
            
            Field<UserType>("teacher",
                resolve: context => context.Source.Teacher
            );
            
            Field<GroupType>("group",
                resolve: context => context.Source.Group
            );
        }

    }

}