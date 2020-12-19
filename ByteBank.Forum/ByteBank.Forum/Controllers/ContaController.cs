using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(ContaRegistrarViewModel modelo)
        {
            if(ModelState.IsValid) //Valida se o campo obrigatorio foi preenchido
            {
                //Cria a conecxao com dbContext
                var dbContext = new IdentityDbContext<UsuarioAplicacao>("DefaultConnection");
                // Camada q conversa com nosso Db Context -> IuserStore
                var userStore = new UserStore<UsuarioAplicacao>(dbContext);
                var userManager = new UserManager<UsuarioAplicacao>(userStore);
                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                // Criar o novo usuario
                await userManager.CreateAsync(novoUsuario, modelo.Senha);

                //Podemos incluir o usuário
                return RedirectToAction("Index", "Home");
            }

            //Algo de errado aconteceu
            return View(modelo);
        }
    }
}