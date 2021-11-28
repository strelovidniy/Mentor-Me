using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/propositions")]
    public class PropositionController : BaseApiController
    {
        private readonly IPropositionService _propositionService;

        public PropositionController(IPropositionService propositionService) => 
            _propositionService = propositionService;

        [HttpGet("offers"), AllowAnonymous]
        public async Task<IActionResult> GetOffers() =>
            Ok(await _propositionService.GetOffersPropositionsAsync());


        [HttpGet("requests"), AllowAnonymous]
        public async Task<IActionResult> GetRequests() =>
            Ok(await _propositionService.GetRequestsPropositionsAsync());[HttpGet("{propositionId:guid}")]

        [HttpGet("{propositionId:guid}"), AllowAnonymous]
        public async Task<IActionResult> GetPropositionById(Guid propositionId) =>
            Ok(await _propositionService.GetPropositionByIdAsync(propositionId));
        
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> AddProposition(Proposition proposition) =>
            Ok(await _propositionService.AddPropositionAsync(proposition));
    }
}