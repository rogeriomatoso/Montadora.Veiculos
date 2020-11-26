using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.Identity
{
    public class MontadoraIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MontadoraIdentityDbContext()
            :base("MontadoraDbContext")
        {

        }
    }
}