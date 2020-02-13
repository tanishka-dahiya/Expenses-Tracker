using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IUserValidationRepository
    {
        Task IsUserValid(Guid userId);
    }
}
