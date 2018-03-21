using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedToolBox.Web.Models
{
    public class SubtipoViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione uma imagem")]
        [DisplayName("Imagem")]
        public byte[] Imagem { get; set; }

        [DisplayName("NomeArquivo")]
        public string NomeArquivo { get; set; }

        [DisplayName("ContentType")]
        public string ContentType { get; set; }

        [DisplayName("CodigoTipo")]
        public int CodigoTipo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataManipulacao { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public string LoginManipulacao { get; set; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         