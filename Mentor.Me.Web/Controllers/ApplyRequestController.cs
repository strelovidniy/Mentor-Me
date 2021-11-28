using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/applyRequests")]
    public class ApplyRequestController : ControllerBase
    {
        private readonly IApplyRequestService _applyRequest;

        public ApplyRequestController(IApplyRequestService applyRequest) => 
            _applyRequest = applyRequest;

        [HttpPost]
        public async Task<IActionResult> AddApplyRequestAsync(ApplyRequest applyRequest) =>
            Ok(await _applyRequest.AddApplyRequestAsync(applyRequest));
        
        [HttpGet("{applyRequestGuid:guid}")]
        public async Task<IActionResult> GetApplyRequestByIdAsync(Guid applyRequestGuid) =>
            Ok(await _applyRequest.GetApplyRequestById(applyRequestGuid));
        
        [HttpGet("{applyRequestGuid:guid}")]
        public async Task<IActionResult> GetApplyRequestsByPrepositionAsync(Guid prepositionId) =>
            Ok(await _applyRequest.GetApplyRequestForPropositionAsync(prepositionId));
        
    }
}