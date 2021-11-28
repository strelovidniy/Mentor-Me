using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/propositions")]
    public class PropositionController : BaseApiController
    {
        private readonly IPropositionService _propositionService;

        public PropositionController(IPropositionService propositionService) => 
            _propositionService = propositionService;

        [HttpGet("offers")]
        public async Task<IActionResult> GetOffers() =>
            Ok(await _propositionService.GetOffersPropositionsAsync());


        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests() =>
            Ok(await _propositionService.GetRequestsPropositionsAsync());[HttpGet("{propositionId:guid}")]
        public async Task<IActionResult> GetPropositionById(Guid propositionId) =>
            Ok(await _propositionService.GetPropositionByIdAsync(propositionId));
        
        [HttpPost]
        public async Task<IActionResult> AddProposition(Proposition proposition) =>
            Ok(await _propositionService.AddPropositionAsync(proposition));
    }
}