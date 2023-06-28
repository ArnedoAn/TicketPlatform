
using TicketPlatform.Core.Entities;

namespace TicketPlatform.Core.Interfaces
{
    public interface IAssignmentsRepository
    {
        Task<IEnumerable<Assignments>> GetAll();
        
        Task<Assignments> Get(int id);

        Task<Boolean> Create(Assignments assignment);

        Task<Boolean> Update(Assignments assignment);

        Task<Boolean> Delete(int id);
    }
}
