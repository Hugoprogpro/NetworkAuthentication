<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1._default" ClientIDMode="Static" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Teste API</title>
	<style type="text/css">
		body { font-family: "Segoe UI",Tahoma,Arial, sans-serif; margin: 20px; background: #f5f5f5; }
		label { display: inline-block;margin:8px 0px 0px 0px;background:#555;color:#fff;padding:2px 4px;width:auto; }
		input { display: block;height:30px;border-radius:0px 5px 5px 0px;line-height:30px;font-size:20px;border:1px solid #555;margin:0px;padding:0px 8px; }
		button {margin:10px 0px;color:#fff;border:0px; display: block;background:#009aff;text-transform:uppercase;font-size:18px;font-family:"Segoe UI",Tahoma,Arial, sans-serif;height:30px;padding:0px 15px;line-height:30px; }
		.success { display:none; border:2px solid #0c7c0b;background: #bdff9e; color: #2d4f00; padding: 10px; margin: 10px 0px; }
		.error   { display:none; border:2px solid #720c0c;background: #ef9494; color: #710000; padding: 10px; margin: 10px 0px; }
	</style>
	
	<script src="Scripts/jquery-2.1.0.js"></script>
</head>
<body>
	<form>		
		<h3>Olá <span runat="server" id="nomeUsuario"></span>.</h3>
		<h5>Por favor, informe sua senha para prosseguir com a autenticação.</h5>
		<div runat="server" id="labelUsuario"></div>
		<input type="hidden" name="user" id="usuario" runat="server" readonly="readonly"/>
		<label>Senha</label>
		<input type="password" name="password" class="button-sided" />
		<button type="submit" class="sided">Testar</button>
		<div class="success"></div>
		<div class="error"></div>
	</form>
	<script type="text/javascript">
		$("form").submit(function (e) {
			e.preventDefault();
			$.ajax({
				//url: "/Security.asmx/Authenticate",
				url: "Security.asmx/Authenticate",
				contentType: "application/json; charset=utf-8",
				dataType: "JSON",
				accepts: "application/json",
				type: "POST",
				crossDomain: true,
				data: "{ username: '" + $("#usuario").val() + "', password: '" + $("input[name=password]").val() + "' }",


				success: function (data) {

					if (data.d == true) {
						$(".error").hide();
						$(".success").html("A autenticação foi efetuada com sucesso").show();
					}
					else {
						$(".success").hide();
						$(".error").html("Não foi possível autenticar no AD. Verifique sua senha.").show();
					}
				}
			});
		});
	</script>
</body>
</html>
