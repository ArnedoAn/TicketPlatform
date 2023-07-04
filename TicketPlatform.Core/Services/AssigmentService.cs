using TicketPlatform.Core.Entities;
using TicketPlatform.Core.EntitiesS;
using TicketPlatform.Core.Interfaces;
using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.DTO;

namespace TicketPlatform.Core.Services
{
    public class AssigmentService : IAssignmentService
    {

        private readonly IAssignmentsRepository _assigmentRepository;

        public AssigmentService(IAssignmentsRepository assigmentRepository)
        {
            _assigmentRepository = assigmentRepository;
        }

        public async Task<bool> CreateAssigment(AssignmentsPostDto assignmentsDto)
        {
            var newAssignment = new Assignments
            {
                Estado = new Status { Id = assignmentsDto.idStatus },
                Ticket = new Ticket { Id = assignmentsDto.idTicket },
                User = new User { Id = assignmentsDto.idUser }

            };
            return await _assigmentRepository.Create(newAssignment);
        }

        public Task<bool> DeleteAssigment(int Id)
        {
            return _assigmentRepository.Delete(Id);
        }

        public async Task<Assignments> GetAssignment(int Id)
        {
            return await _assigmentRepository.Get(Id);
        }

        public async Task<IEnumerable<Assignments>> GetAssignments()
        {
            return await _assigmentRepository.GetAll();
        }

        public async Task<bool> UpdateAssigment(AssignmentsPutDto assignmentsDto)
        {
            var editedAssignment = new Assignments
            {
                Estado = new Status { Id =assignmentsDto.idStatus },
                Ticket = new Ticket { Id = assignmentsDto.idTicket },
                User = new User { Id = assignmentsDto.idUser },
                Id = assignmentsDto.Id

            };

            return await _assigmentRepository.Update(editedAssignment);
        }


    }
}
