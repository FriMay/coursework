using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.Subject;
using University.Types.User;
using University.Types.UserMark;

namespace University.Types.GroupSubject {

    public class GroupSubjectType : ObjectGraphType<Database.Models.GroupSubject> {

        public GroupSubjectType(UserMarkFacade userMarkFacade, SubjectFacade subjectFacade, UserFacade userFacade,
            GroupFacade groupFacade) {
            Field(x => x.Id);
            Field<IntGraphType>(
                "orderNumber",
                resolve: context => context.Source.OrderNumber);
            Field<IntGraphType>(
                "dayOfWeek",
                resolve: context => context.Source.DayOfWeek);
            Field<ListGraphType<UserMarkType>>(
                "userMarks",
                resolve: context => userMarkFacade.GetByGroupSubjectId(context.Source.Id));

            Field<SubjectType>("subject",
                resolve: context => subjectFacade.GetById(context.Source.SubjectId)
            );

            Field<UserType>("teacher",
                resolve: context => userFacade.GetById(context.Source.TeacherId)
            );

            Field<GroupType>("group",
                resolve: context => groupFacade.GetById(context.Source.GroupId)
            );
        }

    }

}