using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get() 
        {
            Student[] sts = StudentsDBMock.students.ToArray();
            return sts;
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
        }

        [HttpPost]
        public int Post([FromBody] Student value)
        {
            
            int max = StudentsDBMock.students.Max(stu=> stu.ID);
            value.ID = max+1;
            StudentsDBMock.students.Add(value);
            return value.ID;
        }
    }
}
