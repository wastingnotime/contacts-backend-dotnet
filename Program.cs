using ContactsBackendDotnet.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ContactContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("contactsDb")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();