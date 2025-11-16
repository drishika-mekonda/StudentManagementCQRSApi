using MediatR;

namespace StudentManagementCQRSApi.Application.UpdateStudent
{
    public record UpdateStudentCommand(int Id, string Name, int Age, string Branch) : IRequest;
}
