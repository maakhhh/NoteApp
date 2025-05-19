using Core;
using Core.Domain;
using NoteApp.Dto;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCore();

builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<Node, NodeInListDto>();
    config.CreateMap<NodeToCreateDto, Node>();
    config.CreateMap<Node, NodeDetailDto>();
    config.CreateMap<Node, NodeToEditDto>();
    config.CreateMap<NodeToEditDto, Node>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Node}/{action=Index}/{id?}");

app.Run();