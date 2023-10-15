using System.Reflection;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TaskManagement.Context;
using TaskManagement.Contracts.Repository;
using TaskManagement.Repository;

namespace TaskManagement.App_Start
{
    public class ServicesConfiguration
    {
        public static ConfigurationManager Configuration { get; set; }


        public static void ServicesRegister(WebApplicationBuilder builder)
        {
            Configuration = builder.Configuration;

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddFluentValidation(v =>
                {
                    v.ImplicitlyValidateChildProperties = true;
                    v.ImplicitlyValidateRootCollectionElements = true;
                    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            builder.Services.AddDbContext<TaskManagementContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("TaskManageDB")));

             
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // add DI
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            builder.Services.AddScoped(typeof(IProfileUserRepository), typeof(ProfileUserRepository));
            builder.Services.AddScoped(typeof(IStatusRepository), typeof(StatusRepository));
            builder.Services.AddScoped(typeof(ISubjectRepository), typeof(SubjectRepository));
            builder.Services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));



        }
    }
}
