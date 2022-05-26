using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                     ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        /// <summary>
        /// Data de Prescrição da Receita.
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                     ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Prescrição")]
        public DateTime Prescricao { get; set; }

        /* CRIAÇÃO DAS CHAVES ESTRANGEIRAS */

        /// <summary>
        /// Chave estrangeira para o médico.
        /// </summary>
        [ForeignKey(nameof(Medico))]
        [InverseProperty(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Utente Medico { get; set; }

        /// <summary>
        /// Chave estrangeira para o paciente.
        /// </summary>
        [ForeignKey(nameof(Paciente))]
        [InverseProperty(nameof(Paciente))]
        public int PacienteFK { get; set; }
        public Utente Paciente { get; set; }



        /* LISTAS */

        /// <summary>
        /// Lista de medicamentos.
        /// </summary>
        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
