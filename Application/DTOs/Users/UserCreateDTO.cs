﻿using Domain.Common.Enums;

namespace Application.DTOs.Users
{
    public class UserCreateDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public UserType UserType { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
