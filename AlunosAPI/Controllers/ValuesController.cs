using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [EnableCors]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> alunos = new List<string>();
            if (!System.IO.File.Exists("ArquivoDB/Alunos.txt"))
            {
                System.IO.Directory.CreateDirectory("ArquivoDB");
                System.IO.File.WriteAllText("ArquivoDB/Alunos.txt", "Fernando,Carol,João");
            }
                alunos = System.IO.File.ReadAllText("ArquivoDB/Alunos.txt").Split(",").ToList();

            return alunos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpGet("CadastrarAluno")]
        public ActionResult<string> CadastrarAluno(string nomeAluno)
        {
            StreamWriter streamWriter =  System.IO.File.AppendText("ArquivoDB/Alunos.txt");
            streamWriter.Write("," + nomeAluno);
            streamWriter.Close();
            return "Inserido com sucesso";
        }


        // POST api/values
        [HttpPost]
        public void Post([FromForm] ClasseKKKK value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
