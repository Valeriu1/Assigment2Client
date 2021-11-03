using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assigment1.Data
{
    public interface IPersonsService
    {
        Task<IList<Adult>> GetPersonsAsync();
        Task AddPersonAsync(Adult adult);
        Task RemovePersonAsync(int personId);
        Task UpdateAsync(Adult adult);
        Task<Adult> GetAsync(int id);
    }
}
