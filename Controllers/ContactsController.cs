using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsBackendDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContactsBackendDotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private static readonly List<Contact> contacts = new List<Contact>(){
            new Contact{FirstName= "Albert", LastName="Einstein", PhoneNumber="2222-1111"},
            new Contact{FirstName= "Mary", LastName="Curie", PhoneNumber="1111-1111"}
        };

        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return contacts;
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(string id)
        {
            var list = contacts.FirstOrDefault(l => l.Id == id);
            if (list == null)
                return NotFound();

            return list;
        }

        [HttpPost]
        public IActionResult Post(Contact value)
        {
            contacts.Add(value);

            return Created(string.Format("{0}/{1}", Request.Path, value.Id), value);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Contact value, string id)
        {
            var list = contacts.FirstOrDefault(l => l.Id == id);
            if (list == null)
                return NotFound();

            list = value;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var list = contacts.FirstOrDefault(l => l.Id == id);
            if (list == null)
                return NotFound();

            contacts.Remove(list);

            return NoContent();
        }
    }
}
