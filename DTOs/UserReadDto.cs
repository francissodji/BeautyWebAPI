using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class UserReadDto
    {
		public int IDUser { get; set; }

		[MaxLength(50)]
		public string Username { get; set; }

		[MaxLength(100)]


		public bool Connectstate { get; set; }

		public int IdProfil { get; set; }
	}
}
