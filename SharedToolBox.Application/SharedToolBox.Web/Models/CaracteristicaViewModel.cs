using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedToolBox.Web.Models
{
    public class CaracteristicaViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        [MaxLength(1000, ErrorMessage = "Máximo {0} caracteres")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ferramenta")]
        public FerramentaViewModel Ferramenta { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ferramenta")]
        public int CodigoFerramenta { get; set; }

        [Required(ErrorMessage = "Preencha o campo Domínio")]
        public DominioViewModel Dominio { get; set; }

        [Required(ErrorMessage = "Preencha o campo Domínio")]
        public int CodigoDominio { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataManipulacao { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public string LoginManipulacao { get; set; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         