using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NetworkAuthenticationApi
{
	/// <summary>
	/// Classe que gerencia autenticação e segurança via Active Directory
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService]//Javascript 
	public class Security : System.Web.Services.WebService
	{
		[WebMethod]
		public bool Authenticate(string username,string password)
		{
			return NetworkAuthentication.Security.Authenticate(username, password);
		}
	}
}
