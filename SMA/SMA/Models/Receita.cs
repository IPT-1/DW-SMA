using System.ComponentModel.DataAnnotations.Schema;

namespace SMA.Models {
    public class Receita {

        public Receita() {
            Medicamentos = new HashSet<Medicamento>();
        }

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public DateTime Prescricao { get; set; }

        [ForeignKey(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Utente Medico { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int PacienteFK { get; set; }
        public Utente Paciente { get; set; }

        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
