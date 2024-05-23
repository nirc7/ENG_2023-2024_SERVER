using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsRWController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Student[]> GetALL()
        {
            try
            {
                Student[] s = StudentsDBMock.students.ToArray();
                //throw new Exception("go 2 school!");
                return Ok(s);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id:int:min(2)}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Student stu2Ret = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Ret == null)
                {
                    return NotFound($"student with id = {id} was not found in the GET action!");
                }
                return Ok(stu2Ret);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpGet("{isAvi:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(bool isAvi)
        {
            try
            {
                IEnumerable<Student> stus2Ret = StudentsDBMock.students.Where(stu => stu.Name.ToLower() == (isAvi? "avi" : stu.Name.ToLower()) );
                if (stus2Ret == null)
                {
                    return NotFound($"empty in the GET action!");
                }
                return Ok(stus2Ret);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpGet]
        [Route("{id}/grade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGradeById(int id)
        {
            try
            {
                Student stu2Ret = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Ret == null)
                {
                    return NotFound($"student with id = {id} was not found in the GET GRADE action!");
                }
                return Ok(stu2Ret.Grade);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest(student);
                }
                else if (student.ID != 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                student.ID = StudentsDBMock.students.Max(stu => stu.ID) + 1;
                StudentsDBMock.students.Add(student);

                return CreatedAtAction(nameof(Get), new { id = student.ID }, student);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            try
            {
                if (student == null || student.ID != id)
                {
                    return BadRequest(student);
                }

                Student stu2Update = StudentsDBMock.students.FirstOrDefault(stu=>stu.ID == id);
                if (stu2Update != null)
                {
                    stu2Update.Name = student.Name;
                    stu2Update.Grade = student.Grade;
                    return NoContent();
                }
                
                return NotFound($"student with id = {id} was not found in the PUT action!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put2([FromBody]int id, [FromQuery] Student student)
        {
            try
            {
                if (student == null || student.ID != id)
                {
                    return BadRequest(student);
                }

                Student stu2Update = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Update != null)
                {
                    stu2Update.Name = student.Name;
                    stu2Update.Grade = student.Grade;
                    return NoContent();
                }

                return NotFound($"student with id = {id} was not found in the PUT action!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                Student stu2Del = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Del != null)
                {
                    StudentsDBMock.students.Remove(stu2Del);
                    return NoContent();
                }

                return NotFound($"student with id = {id} was not found in the Delete action!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("~/del/{id}")    ]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete2(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                Student stu2Del = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Del != null)
                {
                    StudentsDBMock.students.Remove(stu2Del);
                    return NoContent();
                }

                return NotFound($"student with id = {id} was not found in the Delete action!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






    }
}
