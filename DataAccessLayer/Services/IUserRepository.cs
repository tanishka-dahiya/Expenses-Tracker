using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<Entities.User>> getUsersAsync(Guid userId);
    }
}
