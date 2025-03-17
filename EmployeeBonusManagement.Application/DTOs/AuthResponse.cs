using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagement.Application.DTOs
{
    class AuthResponse
    {
	    public string AccessToken { get; set; }
	    public string RefreshToken { get; set; }
	    public DateTime Expiration { get; set; }
	    public string UserEmail { get; set; }
	    public IEnumerable<string> Roles { get; set; }
		public bool Success { get; set; }

		public AuthResponse(bool success)
		{
			Success = success;
		}
	 
	    public AuthResponse(bool success, string accessToken, string refreshToken, DateTime expiration, string userEmail, IEnumerable<string> roles)
	    {
		    Success = success;
		    AccessToken = accessToken;
		    RefreshToken = refreshToken;
		    Expiration = expiration;
		    UserEmail = userEmail;
		    Roles = roles;
	    }
	}
}
