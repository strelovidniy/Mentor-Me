using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/apply-requests")]
    public class ApplyRequestController : ControllerBase
    {
        private readonly IApplyRequestService _applyRequestService;

        public ApplyRequestController(IApplyRequestService applyRequest) =>
            _applyRequestService = applyRequest;

        [HttpPost]
        public async Task<IActionResult> AddApplyRequestAsync(ApplyRequest applyRequest) =>
            Ok(await _applyRequestService.AddApplyRequestAsync(applyRequest));
        
        [HttpGet("{applyRequestGuid:guid}")]
        public async Task<IActionResult> GetApplyRequestByIdAsync(Guid applyRequestGuid) =>
            Ok(await _applyRequestService.GetApplyRequestById(applyRequestGuid));

        [HttpGet("{prepositionId:guid}")]
        public async Task<IActionResult> GetApplyRequestsByPrepositionAsync(Guid prepositionId) =>
            Ok(await _applyRequestService.GetApplyRequestForPropositionAsync(prepositionId));

        [HttpGet("by-user/{userId:guid}")]
        public async Task<IActionResult> GetApplyRequestsByUserIdAsync(Guid userId) =>
            Ok(await _applyRequestService.GetApplyRequestsByUserIdAsync(userId));
    }
}