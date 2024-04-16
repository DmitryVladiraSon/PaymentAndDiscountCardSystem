﻿
namespace PaymentAndDiscountCardSystemBLL.Auth
{
    public interface ILoginService
    {
        Task Register(string userName, string email, string password);
        Task<string> Login(string email, string password);
    }
}