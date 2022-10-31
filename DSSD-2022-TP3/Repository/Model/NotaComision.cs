using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("notas_comision")]
    public class NotaComision
    {
        /// <summary>
        /// ID que refiere a un registro de nota correspondiente a una comision
        /// </summary>
        [Key]
        [Column("idNotaComision")]
        public int Id { get; set; }
        /// <summary>
        ///ID que refiere un usuario del tipo estudiante
        /// </summary>
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        /// <summary>
        /// ID que refiere a un tipo de nota
        /// </summary>
        [Column("idTipoNota")]
        public int IdTipoNota { get; set; }
        /// <summary>
        /// Cadena que almacena la nota
        /// </summary>
        [Column("nota")]
        public string Nota { get; set; }
        /// <summary>
        /// Cadena que almacena la fecha de carga de la nota
        /// </summary>
        [Column("fecha")]
        public string Fecha { get; set; }
        /// <summary>
        ///ID que refiere a una comision 
        /// </summary>
        [Column("idComision")]
        public int IdComision { get; set; }
        public Comision Comision { get; set; }
        public Usuario Usuario { get; set; }
        public TipoNota TipoNota { get; set; }
    }
}
