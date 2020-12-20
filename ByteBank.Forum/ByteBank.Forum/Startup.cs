using ByteBank.Forum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

// o tipo que está sendo utilizado pela inicialização do owin é o metodo startup
[assembly: OwinStartup(typeof (ByteBank.Forum.Startup))]

namespace ByteBank.Forum
{
    public class Startup //Classe de inicialização
    {
        public void Configuration(IAppBuilder builder)
        {
            //como serão criado os:
            builder.CreatePerOwinContext<DbContext>(() =>
                new IdentityDbContext<UsuarioAplicacao>("DefaultConnection")); //a cada contexto do owin irá criar um tipo dbContext

            builder.CreatePerOwinContext<IUserStore<UsuarioAplicacao>>((opcoes, contextoOwin) => {
                var dbContext = contextoOwin.Get<DbContext>();
                return new UserStore<UsuarioAplicacao>(dbContext);
            });

            builder.CreatePerOwinContext<UserManager<UsuarioAplicacao>>((opcoes, contextoOwin) => {
                var userStore = contextoOwin.Get<IUserStore<UsuarioAplicacao>>();
                var userManager = new UserManager<UsuarioAplicacao>(userStore);
                var userValidator = new UserValidator<UsuarioAplicacao>(userManager);

                userValidator.RequireUniqueEmail = true;

                userManager.UserValidator = userValidator;

                return userManager;
            });
        }
    }
}