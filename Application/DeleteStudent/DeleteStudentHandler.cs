using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRSApi.Application.DeleteStudent;
using StudentManagementCQRSApi.Data;

namespace StudentCqrsMediatRDemo.Application.Commands.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly AppDbContext _context;

        public DeleteStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (student == null)
                throw new KeyNotFoundException($"Student with Id {request.Id} not found.");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<DeleteStudentCommand>.Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}