//-------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//-------------------------------------------------------------------------------------------------

namespace Back_End.Models
{
    //---------------------------------------------------------------------------------------------

    public class PrevisaoClima
    {
        //-----------------------------------------------------------------------------------------

        [Key]
        public int Id { get; set; }
        
        //-----------------------------------------------------------------------------------------

        [Required]
        public DateTime DataPrevisao { get; set; }

        [Required]
        [StringLength(15)]
	    public string Clima { get; set; }

        [Column(TypeName = "decimal(3, 1)")]
        public Decimal TemperaturaMinima { get; set; }
        
        [Column(TypeName = "decimal(3, 1)")]
	    public Decimal TemperaturaMaxima { get; set; }

        //-----------------------------------------------------------------------------------------

        [Required]
        public int CidadeId { get; set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

        //-----------------------------------------------------------------------------------------
    }

    //---------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------