using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagementCQRSApi.Application.CreateStudent;
using StudentManagementCQRSApi.Application.DeleteStudent;
using StudentManagementCQRSApi.Application.GetAllStudents;
using StudentManagementCQRSApi.Application.UpdateStudent;

    namespace StudentCqrsMediatRDemo.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class StudentsController : ControllerBase
        {
            private readonly IMediator _mediator;
            private object id;

        public StudentsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            // POST - Adding new Student
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
            {
                var studentId = await _mediator.Send(command);
            return Ok(new { StudentId = studentId });
        }

            // GET - Retrieving all students
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var students = await _mediator.Send(new GetAllStudentsQuery());
                return Ok(students);
            }

            // PUT - Updating existing student
            [HttpPut("{id:int}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentCommand command)
            {
                // Ensuring route id and body id are same 
                if (id != command.Id)
                {
                    // if no then return BadRequest("Route id and body id must match.");

                    // yes override body Id from route:
                    command = command with { Id = id };
                }

                await _mediator.Send(command);
            return Ok(new { message = $"Student with ID {id} updated successfully" });
        }

            // DELETE - Removing a student
            [HttpDelete("{id:int}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _mediator.Send(new DeleteStudentCommand(id));
            return Ok(new { message = $"Student with ID {id} deleted successfully" });
        }
        }
    }


