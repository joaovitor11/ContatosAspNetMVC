using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class ContatoViewModel
    {
        public int ContatoID { get; set; }
        public string Nome { get; set; }
        public string EmailProfissional { get; set; }

        public string NumeroTelefone { get; set; }
        public string TipoTelefone { get; set; }


    }
}
