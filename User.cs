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
		public string EmailAddress { get; private set; }
		public string UserName { get; private set; }
		public string FullName { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Guid { get; private set; }
		public User(string userName)
		{
			UserPrincipal userPrincipal;
			String domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
			using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainName))
			{
				userPrincipal = UserPrincipal.FindByIdentity(pc, userName);
			}			
			this.FullName = userPrincipal.DisplayName;
			this.FirstName = userPrincipal.GivenName;
			this.LastName = userPrincipal.Surname;
			this.EmailAddress = userPrincipal.EmailAddress;
			this.UserName = userName;
			if (userPrincipal.Guid != null)
			{
				this.Guid = userPrincipal.Guid.Value.ToString();
			}
		}
	}
}
