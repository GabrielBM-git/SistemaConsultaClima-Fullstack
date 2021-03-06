//-------------------------------------------------------------------------------------------------

using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//-------------------------------------------------------------------------------------------------

namespace Back_End.Models
{
    //---------------------------------------------------------------------------------------------

    public class Cidade
    {
        //-----------------------------------------------------------------------------------------

        [Key]
        public int Id { get; set; }

        //-----------------------------------------------------------------------------------------

        [Required]
        [StringLength(200)]
	    public string Nome { get; set; }
	    
        //-----------------------------------------------------------------------------------------

        [Required]
	    public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Estado Estado { get; set; }

        //-----------------------------------------------------------------------------------------
    }

    //---------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------