using System;
using System.Threading.Tasks;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IDealService
    {
        Task CreateDeal(Guid applyRequestId);
    }
}