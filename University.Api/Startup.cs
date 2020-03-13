using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using University.DataAccess.Facades;
using University.Database;
using University.Database.Models;
using University.Queries;
using University.Schema;
using University.Types.Group;
using University.Types.GroupSubject;
using University.Types.Mark;
using University.Types.Notification;
using University.Types.NotificationStudent;
using University.Types.Subject;
using University.Types.User;
using University.Types.UserGroup;
using University.Types.UserMark;
using University.Types.UserRole;

namespace University {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void AddTransients(ref IServiceCollection services) {
            services.AddTransient<GroupFacade>();
            services.AddTransient<GroupSubjectFacade>();
            services.AddTransient<MarkFacade>();
            services.AddTransient<NotificationFacade>();
            services.AddTransient<NotificationStudentFacade>();
            services.AddTransient<SubjectFacade>();
            services.AddTransient<UserFacade>();
            services.AddTransient<UserGroupFacade>();
            services.AddTransient<UserMarkFacade>();
            services.AddTransient<UserRoleFacade>();
        }

        public void AddSingletonTypes(ref IServiceCollection services) {
            services.AddSingleton<GroupType>();
            services.AddSingleton<GroupSubjectType>();
            services.AddSingleton<MarkType>();
            services.AddSingleton<NotificationType>();
            services.AddSingleton<NotificationStudentType>();
            services.AddSingleton<SubjectType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<UserGroupType>();
            services.AddSingleton<UserMarkType>();
            services.AddSingleton<UserRoleType>();
        }
        
        public void AddSingletonInputTypes(ref IServiceCollection services) {
            services.AddSingleton<GroupInputType>();
            services.AddSingleton<GroupSubjectInputType>();
            services.AddSingleton<MarkInputType>();
            services.AddSingleton<NotificationInputType>();
            services.AddSingleton<NotificationStudentInputType>();
            services.AddSingleton<SubjectInputType>();
            services.AddSingleton<UserInputType>();
            services.AddSingleton<UserGroupInputType>();
            services.AddSingleton<UserMarkInputType>();
            services.AddSingleton<UserRoleInputType>();
        }

        public void AddSingletonSchemas(ref IServiceCollection services) {
            
            var sp = services.BuildServiceProvider();

            services.AddSingleton<ISchema>(
                new UniversitySchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<UniversityContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("UniversityDb")));

            AddTransients(ref services);
            
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            
            services.AddSingleton<Queries.Queries>();
            
            services.AddSingleton<Mutations.Mutations>();
            
            AddSingletonTypes(ref services);
            
            AddSingletonInputTypes(ref services);
            
            AddSingletonSchemas(ref services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UniversityContext db) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();

            app.UseMvc();
            
            db.EnsureSeedData();
        }

    }

}