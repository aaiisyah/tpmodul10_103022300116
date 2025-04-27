using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300116.Models;

namespace tpmodul10_103022300116.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa {Nama = "Aisyah", Nim = "103022300116"},
            new Mahasiswa {Nama = "Apriliani", Nim = "103022300052"},
            new Mahasiswa {Nama = "Deswita Syaharani", Nim = "103022300004"},
            new Mahasiswa {Nama = "Nadya Aulia Salma", Nim = "103022300022"}
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }

        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> Get(int id)
        {
            if (id < 0 || id >= mahasiswaList.Count)
            {
                return NotFound();
            }
            return mahasiswaList[id];
        }

        [HttpPost]
        public IActionResult Post(Mahasiswa mhs)
        {
            mahasiswaList.Add(mhs);
            return CreatedAtAction(nameof(Get), new { id = mahasiswaList.Count - 1 }, mhs);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { 
            if (id < 0 || id >= mahasiswaList.Count)
            {
                return NotFound();
            }
            mahasiswaList.RemoveAt(id);
            return NoContent();

        }

    }
}
