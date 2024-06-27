using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Application.Personel;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonelController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Personel>>> GetPersons()
        {

            return await Med.Send(new PersonList.Query());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> GetPerson(int id)
        {
            return await Med.Send(new PersonelDetail.Query { id_Person = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(Personel personel)
        {
            await Med.Send(new Create.Command { person = personel });
            return Ok();
        }
        [HttpPut("{Id_Person}")]
        public async Task<IActionResult> EditPerson(int Id_Person, Personel person)
        {
            person.Id_Person = Id_Person;
            await Med.Send(new EditPerson.Command { personel = person });
            return Ok();
        }
        [HttpDelete("{Id_Person}")]
        public async Task<IActionResult> DeletePersonel(int Id_Person)
        {

            await Med.Send(new DeletePer.Command { id = Id_Person });
            return Ok();
        }
    }
}