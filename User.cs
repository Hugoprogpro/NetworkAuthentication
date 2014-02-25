using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
namespace NetworkAuthentication
{
	public class User
	{
		public string UserName { get; private set; }
		public string FullName { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public User()
		{
			UserPrincipal userPrincipal= UserPrincipal.Current;
			this.FullName = userPrincipal.DisplayName;
			this.FirstName = userPrincipal.GivenName;
			this.LastName = userPrincipal.Surname;
			this.UserName = userPrincipal.EmailAddress;
		}
	}
}
