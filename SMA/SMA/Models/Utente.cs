namespace SMA.Models {
    
    /// <summary>
    /// Descreve os dados do Utente.
    /// </summary>
    public class Utente {

        public Utente() {
            Receitas = new HashSet<Receita>();
        }

        /// <summary>
        /// Chave primária PK para o Utenta na base de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Utente.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Número de telmóvel do Utente.
        /// </summary>
        public string Telemovel { get; set; }

        /// <summary>
        /// Número de Utente de Saúde do Cartão de Cidadão do Utente.
        /// </summary>
        public string NumeroUtenteSaude { get; set; }

        /// <summary>
        /// Sexo do Utente. (M - Masculino / F - Feminino)
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Tipo de Utente. (P - Paciente / M - Médico)
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Lista de Receitas em que está envolvido.
        /// </summary>
        public ICollection<Receita> Receitas { get; set; }

    }
}
