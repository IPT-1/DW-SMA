using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMA.Models {
    
    /// <summary>
    /// Descreve os dados da Receita.
    /// </summary>
    public class Receita {

        public Receita() {
            Medicamentos = new HashSet<Medicamento>();

            Paciente = new HashSet<Utente>();
            Medico = new HashSet<Utente>();
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

        /// <summary>
        /// Lista de Utentes envolventes na Receita, um médico e um paciente.
        /// </summary>
        public ICollection<Utente> Paciente { get; set; }

        /// <summary>
        /// Lista de Utentes envolventes na Receita, um médico e um paciente.
        /// </summary>
        public ICollection<Utente> Medico { get; set; }


        /// <summary>
        /// Lista de medicamentos.
        /// </summary>
        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
