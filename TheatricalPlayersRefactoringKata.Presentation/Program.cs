using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Core.Rules;
using TheatricalPlayersRefactoringKata.Database;
using TheatricalPlayersRefactoringKata.Database.Interface;
using TheatricalPlayersRefactoringKata.Database.Repository;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Domain.Implementation.Interface;

namespace TheatricalPlayersRefactoringKata.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql().
                AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<StatementPrinterService>();
            builder.Services.AddScoped<StatementPrinterRules>();
            builder.Services.AddScoped<IStatementPrinter, StatementPrinterService>(); 
            builder.Services.AddScoped<IStatemnetRepository, StatementRepository>();
            builder.Services.AddScoped<PlayService>();
            builder.Services.AddScoped<PlayRepository>();
            builder.Services.AddScoped<IPlayService, PlayService>();

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
