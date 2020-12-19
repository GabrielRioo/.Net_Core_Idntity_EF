# Estudo com .NET Core Identity

### Projeto
1. Projeto: ASP.NET Web Applicaion (.NET Framework)
1. MVC 
1. Nugget Package manager:
   * `Install-Package Microsoft.AspNet.Identity.Core -Version 2.2.1`
   * `Install-Package Microsoft.AspNet.Identity.EntityFramework -Version 2.2.1`
   
--- 
* Adornar: 
   * `[HttpPost]`
   * `[Required]`
   * `[Display (Name = "Nome Completo")]`
   * `[DataType (DataType.Password)]`
   * `[EmailAdress]`
---
### Informações
* Registrar:
   * Controller -> Model -> View
   * **View**:
      * `@using (Html.BeginForm()) { <hrml> }` - Inicializa o formulario
      * `@Html.ValidationSummary("", new { @class = "text-danger" })` - Resultado da validação, mensagem de erro de parametros...
      * `@Html.EditorForModel()` - Formulario para preencher
      * `@Html.ActionLink("Mostrado ao usuario", "Action Controller", "Nome da Controller")`
