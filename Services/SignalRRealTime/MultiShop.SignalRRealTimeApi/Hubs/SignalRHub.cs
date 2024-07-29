﻿using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;


        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;

        }
        public async Task SendStatisticCount()
        {  
            var getTotalCommentCount =await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("RecieveCommentCount", getTotalCommentCount);

        }
    }
}
