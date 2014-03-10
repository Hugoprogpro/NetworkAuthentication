using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using System.Net;
namespace WebApplication1
{
	public partial class _default : System.Web.UI.Page
	{
		private NetworkAuthentication.User currentUser;
		protected void Page_Load(object sender, EventArgs e)
		{
			;
			try
			{
				this.currentUser = NetworkAuthentication.Security.CurrentUser(System.Web.HttpContext.Current.Request.UserHostAddress);

			}
			catch (Exception exception)
			{

			}
			
			if (this.currentUser != null)
			{
				this.nomeUsuario.InnerHtml = currentUser.FirstName;
				this.usuario.Value = currentUser.UserName;
				this.labelUsuario.InnerHtml = String.Concat("Usuário ", currentUser.UserName.ToLower());
			}
			else
			{
				this.nomeUsuario.InnerHtml = String.Concat("Visitante");
				this.usuario.Value = "";
				this.usuario.Attributes.Remove("readonly");
				this.usuario.Attributes["type"] = "text";
				this.labelUsuario.InnerHtml = "<label>Usuário</label>";
			}
				
		}
	}
}