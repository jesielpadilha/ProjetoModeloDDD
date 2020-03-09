using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        [Range(typeof(decimal), "0", "999999999999")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Display(Name = "Disponível?")]
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        
        [Display(Name = "Cliente")]
        public virtual ClienteViewModel Cliente { get; set; }
    }
}