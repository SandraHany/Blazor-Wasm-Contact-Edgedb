using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmContactDb.Shared
{
    public class ContactDisplay
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMarried { get; set; }
        public DateTime DateofBirth { get; set; } = DateTime.Now;
    }
}
