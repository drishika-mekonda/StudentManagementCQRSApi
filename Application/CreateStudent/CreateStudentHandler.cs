using MediatR;
using StudentManagementCQRSApi.Data;
using StudentManagementCQRSApi.Models;

namespace StudentManagementCQRSApi.Application.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateStudentHandler(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreateStudentCommand request,CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Age = request.Age,
                Branch = request.Branch,
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return student.Id;
        }

    }
}
