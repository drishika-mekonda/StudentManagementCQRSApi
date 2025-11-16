using MediatR;

namespace StudentManagementCQRSApi.Application.DeleteStudent
{
    public record DeleteStudentCommand(int Id) : IRequest;
}
