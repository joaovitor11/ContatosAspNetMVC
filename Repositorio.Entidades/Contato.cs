using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class Contato
    {
        public Contato()
        {
            this.Telefone = new HashSet<Telefone>();
        }

        public int ContatoID { get; set; }

        [Required(ErrorMessage = "Informe o seu nome")]
        public string Nome { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string EmailProfissional { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string EmailPessoal { get; set; }

        public virtual ICollection<Telefone> Telefone { get; set; }

    }
}
