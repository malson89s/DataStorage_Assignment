using Business.Factories;
using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ConsoleApp.Dialogs;

var services = new ServiceCollection()

// Databasanslutning
.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DataStorageDB;Integrated Security=True;Connect Timeout=30;"))

// Repositories
.AddScoped<ICustomerRepository, CustomerRepository>()
.AddScoped<IProjectRepository, ProjectRepository>()
.AddScoped<IProductRepository, ProductRepository>()
.AddScoped<IStatusTypeRepository, StatusTypeRepository>()
.AddScoped<IUserRepository, UserRepository>()

// Services
.AddScoped<CustomerService>()
.AddScoped<ProjectService>()
.AddScoped<ProductService>()
.AddScoped<StatusTypeService>()
.AddScoped<UserService>()

// Dialogs
.AddScoped<MainDialog>()
.AddScoped<CustomerDialog>()
.AddScoped<ProjectDialog>()

// Factories
.AddScoped<ProjectFactory>()
.BuildServiceProvider();

// Starta huvudmenyn
var mainDialog = services.GetRequiredService<MainDialog>();
await mainDialog.MenuOptions();
