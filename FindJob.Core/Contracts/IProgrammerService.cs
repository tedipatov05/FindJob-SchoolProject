using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Contracts
{
    public interface IProgrammerService
    {
        Task Create(string userId, string abilities, string graduationSchool);
    }
}
