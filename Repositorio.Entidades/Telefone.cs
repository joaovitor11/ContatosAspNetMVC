using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class Telefone
    {
        public int TelefoneID { get; set; }

        public int ContatoID { get; set; }

        [Required(ErrorMessage = "Informe um número de Telefone")]
        [RegularExpression("^(\\([0-9]{2}\\))\\s([9]{1})?([0-9]{4})-([0-9]{4})$", ErrorMessage = "Informe um telefone válido...")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "Informe um tipo de Telefone")]
        public string TipoTelefone { get; set; }
    }
}
