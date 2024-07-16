using Blogs.Infrastucture.Extensions;
using Blogs.UI.ServicesExt;
using BlogsCore.Domain;
using BlogsCore.DTOs;
using BlogsCore.IRepository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsService();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDBContextService(configuration);
builder.Services.AddBlogRepo();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapGet("/GetBlog", (HttpContext httpContext, [FromServices] IRepository repo, [FromQuery] Guid id) =>
{
    return repo.GetBlog(id);

})
.WithOpenApi();

app.MapPost("/CreateBlog", (HttpContext httpContext,[FromServices] IRepository repo, [FromBody] BlogDto dto) =>
{
    Blog b = dto.ToBlog();

    return repo.CreateBlog(b);
})
.WithOpenApi();

app.MapPut("/UpdateBlog", (HttpContext httpContext, [FromServices] IRepository repo, [FromQuery] Guid id, [FromBody] BlogDto dto) =>
{
    Blog blog = new Blog();
    blog.ID = id;
    blog.Name = dto.Name;
    blog.Description = dto.Desc;

    repo.UpdateBlog(blog);
})
.WithOpenApi();

app.MapDelete("/DeleteBlog", (HttpContext httpContext, [FromServices] IRepository repo, [FromQuery] Guid id) =>
{
    repo.DeleteBlog(id);
})
.WithOpenApi();


app.Run();

