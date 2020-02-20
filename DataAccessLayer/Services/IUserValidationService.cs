using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IUserValidationService
    {
        Task IsUserValid(int userId);
    }
}
