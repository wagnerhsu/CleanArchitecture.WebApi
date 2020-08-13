﻿using Application.DTOs.Account;
using Application.Wrappers;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);

        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);

        Task ConfirmEmailAsync(string userId, string code);
    }
}