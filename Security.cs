using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
namespace NetworkAuthentication
{
	public class Security
	{
		public static bool Authenticate(string userName, string Password){
			String domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
			bool isAuthenticated=false;
			using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainName))
			{
				isAuthenticated = pc.ValidateCredentials(userName, Password);
			}
			return isAuthenticated;
		}
	}
}
