using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Net;
namespace NetworkAuthentication
{
	public class Security
	{
		public static string hostname;
		public static bool Authenticate(string username, string password){
			String domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
			bool isAuthenticated=false;
			using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainName))
			{
				isAuthenticated = pc.ValidateCredentials(username, password);
			}
			return isAuthenticated;
		}
		public static User GetUserByIpAddress(string ipAddress)
		{	
			System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(ipAddress);
			string userName = ip.HostName.Split('.')[0];
			Security.hostname = userName;
			return new User(userName);
		}
		public static User GetUserByUsername(string userName)
		{
			return new User(userName);
		}
	}
}
