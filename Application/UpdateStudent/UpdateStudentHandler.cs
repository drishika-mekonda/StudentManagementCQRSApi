using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRSApi.Data;

namespace StudentManagementCQRSApi.Application.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly AppDbContext _context;

        public UpdateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (student == null)
                throw new KeyNotFoundException($"Student with Id {request.Id} not found.");

            student.Name = request.Name;
            student.Age = request.Age;
            student.Branch = request.Branch;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateStudentCommand>.Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
