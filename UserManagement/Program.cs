
using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Repositories;

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

            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IRoleRepository,RoleRepository>();
            builder.Services.AddScoped<IUserRoleRepository,UserRoleRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
