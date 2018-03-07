using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedToolBox.Web.Models
{
    public class FerramentaViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(500, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Selecione um sub tipo")]
        public SubtipoViewModel Subtipo { get; set; }

        [Required(ErrorMessage = "Selecione um sub tipo")]
        public int SubtipoCodigo { get; set; }

        [Required(ErrorMessage = "Selecione uma imagem")]
        [DisplayName("Imagem")]
        public byte[] Imagem { get; set; }

        [DisplayName("NomeArquivo")]
        public string NomeArquivo { get; set; }

        [DisplayName("ContentType")]
        public string ContentType { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string ManualInstrucoes { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string VideoExplicativo { get; set; }

        [Required(ErrorMessage = "Selecione uma marca")]
        public MarcaViewModel Marca { get; set; }

        [Required(ErrorMessage = "Selecione uma marca")]
        public int MarcaCodigo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataManipulacao { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public string LoginManipulacao { get; set; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         