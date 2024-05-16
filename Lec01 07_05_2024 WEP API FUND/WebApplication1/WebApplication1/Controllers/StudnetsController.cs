using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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

            int max = StudentsDBMock.students.Max(stu => stu.ID);
            value.ID = max + 1;
            StudentsDBMock.students.Add(value);
            return value.ID;
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Student value)
        {
            Student stu2Update = StudentsDBMock.students.SingleOrDefault(stu => stu.ID == id);
            stu2Update.Name = value.Name;
            stu2Update.Grade = value.Grade;
            return "done:)";
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //foreach (string item in new[] {" 1,2,3,4", "bennt"})
            //{

            //}

            Student stu2Del = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
            StudentsDBMock.students.Remove(stu2Del);
            var v = new { Result = "Successfully Deleted!", Stam = true };
            //var v2 = new { Result2 = 7, Stam = 7, ba = 83.5 };
            return new JsonResult(v);


            //int[] nums = new int[] { 2, 7, 3, 8, 5 };

            //var evens = (from stu in StudentsDBMock.students
            //            where stu.ID % 2 == 0 && 3 < stu.Name.Length 
            //            orderby stu.Grade descending
            //            select new {tudatzehot =  stu.ID, g=stu.Grade}).ToArray();
            ////Console.WriteLine(evens[0]);
            //foreach (var stu in evens)
            //{
            //    Console.WriteLine(  stu.tudatzehot +  ", "+ stu.g);
            //}

        }

    }
}
