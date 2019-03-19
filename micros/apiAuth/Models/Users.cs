using System;
using System.Collections.Generic;

namespace apiAuth.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Organisation { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
