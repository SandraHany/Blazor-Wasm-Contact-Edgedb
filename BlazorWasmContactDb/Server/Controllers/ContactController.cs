using BlazorWasmContactDb.Shared;
// ContactController.cs
using EdgeDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace BlazorWasmContactDb.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactController : ControllerBase
{
    EdgeDBClient client = new EdgeDBClient();

    [HttpPost("add")]
    public async Task<IActionResult> AddContact()
    {

        var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
        var contact = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactInput>(requestBody);
        var passwordHasher = new PasswordHasher<string>();
        contact.Password = passwordHasher.HashPassword(null, contact.Password);
        if (contact != null)
        {
            var query = @"
                INSERT Contact {
                    first_name := <str>$first_name,
                    last_name := <str>$last_name,
                    email := <str>$email,
                    username := <str>$username,
                    password := <str>$password,
                    role := <str>$role,
                    title := <str>$title,
                    description := <str>$description,
                    date_of_birth := cal::to_local_date(<str>$date_of_birth, 'MM dd yyyy'),
                    is_married := <bool>$is_married
                }
            ";

            var parameters = new Dictionary<string, object>
             {
                { "first_name", contact.FirstName },
                { "last_name", contact.LastName },
                { "email", contact.Email },
                { "username", contact.Username },
                { "password", contact.Password },
                { "role", contact.Role },
                { "title", contact.Title },
                { "description", contact.Description },
                { "date_of_birth", contact.DateofBirth.ToString("MM dd yyyy") },
                { "is_married", contact.IsMarried}
             };
            await client.ExecuteAsync(query, parameters);
        }
        return Ok(contact);
    }

    // PUT: api/contact/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact()
    {
        var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
        var updatedContact = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactInput>(requestBody);
        var passwordHasher = new PasswordHasher<string>();
        updatedContact.Password = passwordHasher.HashPassword(null, updatedContact.Password);
        var query = $@"
            UPDATE Contact 
                FILTER .id = <uuid>$id
                SET {{
                    first_name := <str>$first_name,
                    last_name := <str>$last_name,
                    email := <str>$email,
                    username := <str>$username,
                    password := <str>$password,
                    role := <str>$role,
                    title := <str>$title,
                    description := <str>$description,
                    date_of_birth := cal::to_local_date(<str>$date_of_birth, 'MM dd yyyy'),
                    is_married := <bool>$is_married
                }}

            ;";
        var parameters = new Dictionary<string, object>
        {
            { "id", updatedContact.Id },
            { "first_name", updatedContact.FirstName },
            { "last_name", updatedContact.LastName },
            { "email", updatedContact.Email },
            { "username", updatedContact.Username },
            { "role", updatedContact.Role },
            { "title", updatedContact.Title },
            { "description", updatedContact.Description },
            { "date_of_birth", updatedContact.DateofBirth },
            { "is_married", updatedContact.IsMarried }
        };
        try
        {
            await client.ExecuteAsync(query, parameters);
            return Ok(updatedContact);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the contact: " + ex.Message);
        }
    }

    [HttpGet("get-contact")]
    public async Task<IActionResult> GetContact([FromQuery] Guid id)
    {
        var query = $@"SELECT Contact {{
            Id :=.id,
            FirstName := .first_name,
            LastName := .last_name,
            Email := .email,
            Username := .username,
            Role := .role,
            Title := .title,
            Description := .description,
            DateofBirth :=  std::to_str(.date_of_birth, 'MM dd yyyy'), 
            IsMarried := .is_married
            }} FILTER .id = <uuid>$id;";
        var parameters = new Dictionary<string, object>
        {
            { "id", id }
        };
        var result = await client.QueryAsync<ContactInput>(query, parameters);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("all-contacts")]
    public async Task<IActionResult> GetAllContacts()
    {
        var query = @"
                SELECT Contact { 
                    Id := .id, 
                    FirstName := .first_name, 
                    LastName := .last_name, 
                    Email := .email, 
                    Role := .role, 
                    Title := .title, 
                    Description := .description, 
                    DateofBirth := std::to_str(.date_of_birth, 'MM dd yyyy'), 
                    IsMarried := .is_married 
                };
            ";

        var result = await client.QueryAsync<ContactDisplay>(query);
        var contacts = result.ToList();
        return Ok(contacts);
    }

}
