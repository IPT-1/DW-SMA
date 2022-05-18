using System.ComponentModel.DataAnnotations;

namespace SMA.Models {
    
    /// <summary>
    /// Descreve os dados do Utente.
    /// </summary>
    public class Utente {

        public Utente() {
            Receitas = new HashSet<Receita>();
            Pacientes = new HashSet<Utente>();
        }

        /// <summary>
        /// Chave primária PK para o Utenta na base de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Utente.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais que {1} caracteres.")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "Só pode escrever letras no {0}")]
        public string Nome { get; set; }

        /// <summary>
        /// Número de telmóvel do Utente.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        /// <summary>
        /// Número de Utente de Saúde do Cartão de Cidadão do Utente.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Número de Utente de Saúde")]
        public string NumeroUtenteSaude { get; set; }

        /// <summary>
        /// Sexo do Utente. (M - Masculino / F - Feminino)
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter.")]
        [RegularExpression("[FM]", ErrorMessage = "No {0} só se aceitam as letras F ou M.")]
        public string Sexo { get; set; }

        /// <summary>
        /// Tipo de Utente. (P - Paciente / M - Médico)
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter.")]
        [RegularExpression("[PM]", ErrorMessage = "No {0} só se aceitam as letras P ou M.")]
        [Display(Name = "Paciente P / Médico M")]
        public string Tipo { get; set; }

        /// <summary>
        /// Lista de Receitas em que está envolvido.
        /// </summary>
        public ICollection<Receita> Receitas { get; set; }

        /// <summary>
        /// Lista dos seus Pacientes, se o Utente for Médico.
        /// </summary>
        public ICollection<Utente> Pacientes { get; set; }

    }
}
