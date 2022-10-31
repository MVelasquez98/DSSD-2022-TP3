using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSD_2022_TP3.Model
{
    [Table("notas_comision")]
    public class NotaComision
    {
        [Key]
        [Column("idNotaComision")]
        public int Id { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("idTipoNota")]
        public int IdTipoNota { get; set; }
        [Column("nota")]
        public string Nota { get; set; }
        [Column("fecha")]
        public string Fecha { get; set; }
        [Column("idComision")]
        public int IdComision { get; set; }
        public Comision Comision { get; set; }
        public Usuario Usuario { get; set; }
        public TipoNota TipoNota { get; set; }

        public static implicit operator NotaComision(NotaComision v)
        {
            throw new NotImplementedException();
        }
    }
}
