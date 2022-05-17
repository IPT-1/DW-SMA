namespace SMA.Models {
    
    /// <summary>
    /// Descreve os dados do Medicamento.
    /// </summary>
    public class Medicamento {

        public Medicamento() {
            Receitas = new HashSet<Receita>();
        }

        /// <summary>
        /// Chave primária PK para o Medicamento na base de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Medicamento.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Dosagem do Medicamento.
        /// </summary>
        public string Dosagem { get; set; }

        /// <summary>
        /// Nome do Laboratório em que o Medicamento foi desenvolvido.
        /// </summary>
        public string Laboratorio { get; set; }

        /// <summary>
        /// Observações adicionais ao Medicamento (Facultativo).
        /// </summary>
        public string Observacoes { get; set; }

        /// <summary>
        /// Foto do Medicamento.
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Lista de Receitas em que o Medicamento está envolvido.
        /// </summary>
        public ICollection<Receita> Receitas { get; set; }

    }
}
