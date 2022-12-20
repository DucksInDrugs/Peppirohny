using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Peppirohny.Models.User
{
    public class CustomUserIdentity : ClaimsIdentity
    {
		public int id { get; set; }

		public CustomUserIdentity(Entities.User user, string authenticationType = "Cookie") : base(GetUserClaims(user), authenticationType)
		{
			id = user.id;
		}

		private static List<Claim> GetUserClaims(Entities.User user)
		{
			var result = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.login),
				new Claim(ClaimTypes.Role, "Admin"),
			};

			return result;
		}
	}
}
