using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Interfaces.Validations;
using Application.Mappers;
using Application.UseCases;
using Application.Validations;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<MarketingCRMContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IGenericResponseMapper, GenericResponseMapper>();

builder.Services.AddScoped<IClientCommand, ClientCommand>();
builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IClientMapper, ClientMapper>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<ITaskStatusQuery, TaskStatusQuery>();
builder.Services.AddScoped<ITaskStatusService, TaskStatusService>();
builder.Services.AddScoped<ITaskMapper, TasksMapper>();

builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();
builder.Services.AddScoped<ICampaignTypeService, CampaignTypeService>();

builder.Services.AddScoped<IInteractionTypeQuery, InteractionsTypesQuery>();
builder.Services.AddScoped<IInteractionTypeService, InteractionTypeService>();


builder.Services.AddScoped<IInteractionCommand, InteracionCommand>();
builder.Services.AddScoped<IInteractionQuery, InteractionQuery>();
builder.Services.AddScoped<IInteractionService, InteractionService>();
builder.Services.AddScoped<IInteractionMapper, InteractionMapper>();

builder.Services.AddScoped<IProjectQuery, ProjectQuery>();
builder.Services.AddScoped<IProjectCommand, ProjectCommand>();
builder.Services.AddScoped<IProjectMapper, ProjectMapper>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskQuery, TaskQuery>();
builder.Services.AddScoped<ITaskCommand, TaskCommand>();

builder.Services.AddScoped<IProjectValidations, ProjectValidations>();
builder.Services.AddScoped<IClientValidations, ClientValidations>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
