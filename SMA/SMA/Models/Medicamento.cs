namespace SMA.Models {
    public class Medicamento {

        public Medicamento() {
            Receitas = new HashSet<Receita>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Dosagem { get; set; }

        public string Laboratorio { get; set; }

        public string Observacoes { get; set; }

        public string Foto { get; set; }

        public ICollection<Receita> Receitas { get; set; }

    }
}
