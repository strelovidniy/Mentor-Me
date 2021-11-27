﻿using System;
using System.Threading.Tasks;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/deals")]
    public class DealController : BaseApiController
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }
        [Route("createDeal")]
        public async Task<IActionResult> CreateDeal(Guid applyRequestId)
        {
            await _dealService.CreateDeal(applyRequestId);
            return Ok();
        }
    }
}