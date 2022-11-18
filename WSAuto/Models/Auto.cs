using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAuto.Models
{
    [Table ("Vehiculo")]
    public class Auto
    {
        public Auto(int id, string marca, string modelo, string color, decimal precio)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Precio = precio;
        }
        public Auto()
        {

        }
        public int Id { get; set; }
        
        /*[Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]*/
        public string Marca { get; set; }
        
        /*[Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]*/
        public string Modelo { get; set; }
        
        /*[Column(TypeName = "varchar")]
        [StringLength(50)]*/
        public string Color { get; set; }

        //[Column(TypeName = "money")]
        public decimal Precio { get; set; }

    }
}
