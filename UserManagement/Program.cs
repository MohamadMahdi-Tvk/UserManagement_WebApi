using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using UserManagement.Application.ExtentionMethods;
using UserManagement.Application.Services.UserRoles.Commands;
using UserManagement.Application.Services.UserRoles.Queries;
using UserManagement.Application.Services.Users.Commands;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.UnitOfWork;

namespace UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb")));

            //var serviceProvider = builder.Services.BuildServiceProvider();
            //var logger = serviceProvider.GetService<ILogger<CreateUserCommand>>();

            //builder.Services.AddSingleton(typeof(ILogger), logger);


            builder.Services.AddApplication();


            #region Mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>
                {
                    new MappingProfile(),
                });
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            #endregion

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
