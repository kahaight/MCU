using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MCUWebAPPTest.Models
{
    public class CharacterController : ApiController
    {
        private ClassesService CreateClassesService()
        {
            var classesService = new ClassesService();
            return classesService;
        }

        public IHttpActionResult GetCharacter(int id)
        {
            ClassesService classesService = CreateClassesService();
            var character = classesService.GetCharacterById(id);
            return Ok(character);
        }

    }
}
