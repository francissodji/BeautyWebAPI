using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class UserUpdateDto
    {

		[MaxLength(50)]
		public string Username { get; set; }

		[MaxLength(100)]
		public string Password { get; set; }

		public DateTime Dateuserexpire { get; set; }

		public bool Connectstate { get; set; }

		public int IdProfil { get; set; }
	}
}
