﻿using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/deals")]
    public class DealController : BaseApiController
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService) =>
            _dealService = dealService;

        [Route("create-deal")]
        public async Task<IActionResult> CreateDeal(Guid applyRequestId) =>
            Ok(await _dealService.CreateDeal(applyRequestId));

        [Route("{dealId:guid}")]
        public async Task<IActionResult> GetDealByIdAsync(Guid dealId) =>
            Ok(await _dealService.GetDealByIdAsync(dealId));

        [Route("by-user/{userId:guid}")]
        public async Task<IActionResult> GetDealsByUserIdAsync(Guid userId) =>
            Ok(await _dealService.GetDealsByUserIdAsync(userId));
    }
}