using BlazorWasmContactDb.Shared;
using EdgeDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BlazorWasmContactDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddEdgeDB(EdgeDBConnection.FromInstanceName("BlazorWasmContactDb"), config =>
            {
                config.SchemaNamingStrategy = INamingStrategy.SnakeCaseNamingStrategy;
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
            {
                c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
                c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience = builder.Configuration["Auth0:Audience"],
                    ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}"
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            //app.MapPost("/addcontact", async (HttpContext context, EdgeDBClient client, ContactInput contact) =>
            //{
            //    if (string.IsNullOrEmpty(contact.FirstName) || string.IsNullOrEmpty(contact.LastName) || string.IsNullOrEmpty(contact.Email) )
            //    {
            //        context.Response.StatusCode = 400;
            //        await context.Response.WriteAsync("All fields are required.");
            //        return;
            //    }
            //    var passwordHasher = new PasswordHasher<string>();
            //    contact.Password = passwordHasher.HashPassword(null, contact.Password);
            //    var query = @"
            //    INSERT Contact {
            //        first_name := <str>$first_name,
            //        last_name := <str>$last_name,
            //        email := <str>$email,
            //        username := <str>$username,
            //        password := <str>$password,
            //        role := <str>$role,
            //        title := <str>$title,
            //        description := <str>$description,
            //        date_of_birth := <str>$date_of_birth,
            //        is_married := <str>$is_married
            //    }
            //";

            //    var parameters = new Dictionary<string, object>
            // {
            //    { "first_name", contact.FirstName },
            //    { "last_name", contact.LastName },
            //    { "email", contact.Email },
            //    { "username", contact.Username },
            //    { "password", contact.Password },
            //    { "role", contact.Role },
            //    { "title", contact.Title },
            //    { "description", contact.Description },
            //    { "date_of_birth",contact.DateofBirth},
            //    { "is_married", contact.IsMarried}
            // };
            //   await client.ExecuteAsync(query, parameters);
            //});

            app.Run();
        }
    }
}