using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class UserCreateDto
    {


		[Required]
		[EmailAddress]
		public string Email { get; set; }


		[Required]
		[MinLength(5)]
		public string Username { get; set; }


		[Required]
		public string PasswordHash { get; set; }


		public DateTime? Dateuserexpire { get; set; }


		public bool? Connectstate { get; set; }


		public int IdProfil { get; set; }


		public string? TokenUser { get; set; }
	}
}
