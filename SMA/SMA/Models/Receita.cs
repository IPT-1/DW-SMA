using System.ComponentModel.DataAnnotations.Schema;

namespace SMA.Models {
    
    /// <summary>
    /// Descreve os dados da Receita.
    /// </summary>
    public class Receita {

        public Receita() {
            Medicamentos = new HashSet<Medicamento>();
        }

        /// <summary>
        /// Chave primária PK para a Receita na base de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de quando a Receita foi criada.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Data de Prescrição da Receita.
        /// </summary>
        public DateTime Prescricao { get; set; }

        ///////////////////////// <summary>
        ///////////////////////// Médico (FK) envolvente na Receita.
        ///////////////////////// </summary>
        //////////////////////[ForeignKey(nameof(Medico))]
        //////////////////////public int MedicoFK { get; set; }
        //////////////////////public Utente Medico { get; set; }

        ///////////////////////// <summary>
        ///////////////////////// Paciente (FK) envolvente na Receita.
        ///////////////////////// </summary>
        //////////////////////[ForeignKey(nameof(Paciente))]
        //////////////////////public int PacienteFK { get; set; }
        //////////////////////public Utente Paciente { get; set; }

        /// <summary>
        /// Lista de Utentes envolventes na Receita, um médico e um paciente.
        /// </summary>
        public ICollection<Utente> Utentes { get; set; }

        /// <summary>
        /// Lista de Medicamentos envolvidos na Receita.
        /// </summary>
        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
