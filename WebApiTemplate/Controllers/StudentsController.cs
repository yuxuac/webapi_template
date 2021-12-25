using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.BO;
using WebApiTemplate.Models;

namespace WebApiTemplate.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsBO studentsBO;
        public StudentsController(IStudentsBO studentsBO)
        {
            this.studentsBO = studentsBO;
        }

        // GET: v1/<StudentsController>
        [HttpGet("")]
        public IActionResult Get()
        {
            var resp = studentsBO.GetAllStudents();
            if (!resp.Success)
                return this.BadRequest();
            else
                return this.Ok(resp);
        }

        // GET v1/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resp = studentsBO.GetStudent(id);
            if (!resp.Success)
                return this.BadRequest(resp);
            else
                return this.Ok(resp);
        }

        // POST v1/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            var resp = studentsBO.AddAStudent(student);
            if (!resp.Success)
                return this.BadRequest(resp);
            else
                return this.Ok(resp);
        }

        // PUT v1/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            var resp = studentsBO.UpdateAStudent(id, value);
            if (!resp.Success)
                return this.BadRequest(resp);
            else
                return this.Ok(resp);
        }

        // DELETE v1/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resp = studentsBO.RemoveAStudent(id);
            if (!resp.Success)
                return this.BadRequest(resp);
            else
                return this.Ok(resp);
        }
    }
}
