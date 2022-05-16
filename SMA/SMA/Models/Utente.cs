namespace SMA.Models {
    public class Utente {

        public Utente() {
            Receitas = new HashSet<Receita>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telemovel { get; set; }

        public string NumeroUtenteSaude { get; set; }

        public string Sexo { get; set; }

        public string Tipo { get; set; }

        public ICollection<Receita> Receitas { get; set; }

    }
}
