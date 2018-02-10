using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SharedToolBox.Web.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        //[MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        //[MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione uma imagem")]
        [DisplayName("Imagem")]
        public byte Imagem { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}