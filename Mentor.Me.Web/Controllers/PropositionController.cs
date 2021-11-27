using System;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/propositions")]
    public class PropositionController : BaseApiController
    {
        private readonly IPropositionService _propositionService;

        public PropositionController(IPropositionService propositionService)
        {
            _propositionService = propositionService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPropositions() =>
            Ok(await _propositionService.GetAllPropositionsAsync());   
        
        [HttpGet]
        public async Task<IActionResult> GetPropositionById(Guid propositionId) =>
            Ok(await _propositionService.GetPropositionByIdAsync(propositionId));
        
        [HttpPost]
        public async Task<IActionResult> AddProposition(Proposition proposition) =>
            Ok(await _propositionService.AddPropositionAsync(proposition));
    }
}