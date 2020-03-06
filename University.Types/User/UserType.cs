using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.GroupSubject;
using University.Types.NotificationStudent;
using University.Types.UserGroup;
using University.Types.UserMark;
using University.Types.UserRole;

namespace University.Types.User {

    public class UserType : ObjectGraphType<Database.Models.User> {

        public UserType(UserGroupFacade userGroupFacade, UserMarkFacade userMarkFacade) {
            Field(x => x.Id);
            Field(x => x.Login);
            Field(x => x.Password);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.SecondName);
            Field<ListGraphType<GroupType>>("groupSubjects",
                resolve: context => userGroupFacade.GetByUserId(context.Source.Id));
            Field<ListGraphType<UserMarkType>>("userMarks",
                resolve: context => userMarkFacade.GetByUserId(context.Source.Id)
            );
            Field<UserRoleType>(
                "userRole",
                resolve: context => context.Source.UserRole
            );
        }

    }

}