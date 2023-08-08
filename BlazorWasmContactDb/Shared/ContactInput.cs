using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmContactDb.Shared
{
    public class ContactInput
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isMarried")]
        public bool IsMarried { get; set; }

        [JsonProperty("dateofBirth")]
        public DateTime DateofBirth { get; set; }= DateTime.Now;
    }
}
