using FindJob.Core.Models.Programmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Core.Contracts
{
    public interface ICompanyService
    {
        Task Create(string userId);

        Task<bool> IsCompanyExist(string userId);

        Task<string> GetCompanyId(string userId);

        Task<List<ProgrammerViewModel>> GetCandidatesToOffer(string offerId);

        Task AcceptProgrammer(string id, string offerId, string companyId);
        Task RejectProgrammer(string id, string offerId);
    }
}
