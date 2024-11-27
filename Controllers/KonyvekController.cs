using _9gyak.BookModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9gyak.Controllers
{
    [Route("api/konyvek")]
    [ApiController]
    public class KonyvekController : ControllerBase
    {
        // GET: api/<KonyvekController>
        [HttpGet]
        public IActionResult Get()
        {
            FunnyDatabaseContext context= new FunnyDatabaseContext();
            return Ok(context.Books.ToList());

        }

        // GET api/<KonyvekController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FunnyDatabaseContext context= new FunnyDatabaseContext();
            var keresettKonyv = (from x in context.Books
                                where x.Id == id
                                select x).FirstOrDefault();
            if (keresettKonyv == null)
            {
                return NotFound($"Nincs #{id} azonosítóval könyv");
            }
            else
            {
                return Ok(keresettKonyv);
            }
        }

        // POST api/<KonyvekController>
        [HttpPost]
        public void Post([FromBody] Book újKönyv)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            context.Books.Add(újKönyv);
            context.SaveChanges();
        }

        // PUT api/<KonyvekController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KonyvekController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var törlendőKönyv = (from x in context.Books
                                where x.Id == id
                                select x).FirstOrDefault();
            if (törlendőKönyv != null)
            {

                context.Remove(törlendőKönyv);
                context.SaveChanges();
                return Ok(new { Message = "Sikeres törlés" });

            }
            else
            {
                return NotFound(new { Message = "Nincs ilyen id" });
            }
        }
    }
}
