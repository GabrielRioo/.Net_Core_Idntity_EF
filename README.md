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
#### Arquitetura:
1. **Fonte de Dados(Data Source)** = Guarda os usuarios -> __SQL, MongoDB__
1. **Acesso aos Dados(Data Access Layer)** -> __Entity Framework__ 
1. **Fornecedor(Store)** = Manipula os usuarios dentro do Identity Framework -> __IUserStore__
1. **Gerenciadores(Managers)** = Core do Identity -> __UserManager__
1. **Aplicação** = Não lida com as aplicações do banco de dados -> __Forum ByteBank__

* Controller -> Model -> View
* **View**:
   * `@using (Html.BeginForm()) { <hrml> }` - Inicializa o formulario
   * `@Html.ValidationSummary("", new { @class = "text-danger" })` - Resultado da validação, mensagem de erro de parametros...
   * `@Html.EditorForModel()` - Formulario para preencher
   * `@Html.ActionLink("Mostrado ao usuario", "Action Controller", "Nome da Controller")`
* `ModelState.IsValid` - Valida se foi preenchido corretamente, campos obrigatorios, compo de email de acordo com formato esperado...
* `dbContext` - Entity Framework
* Aplicação .NET sempre dar preferencia para os metodos **Assincronos**

* Web.config
```
    <connectionStrings>
      		<add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Database=Bytebank.Forum;connection_trusted=true"/>
    </connectionStrings>
```
* name="DefaultConnection" - nom padrao para aplicações asp net utilizando entity framework
* providerName - Nome do Eniy Framework, localizando em:  `<providers>`
* connectionString
