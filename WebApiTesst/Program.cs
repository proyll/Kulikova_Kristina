using System.Reflection;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace WebApiTesst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<OdezdaContext>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: "LAPTOP - OUBQPCO5; Database = Odezda; Integrated Security = True;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
        }
    }
}


//Server = LAPTOP - OUBQPCO5; Database = Odezda; Integrated Security = True;