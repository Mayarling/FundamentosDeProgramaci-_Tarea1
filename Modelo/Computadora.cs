namespace Tarea.Modelo
{
    /// <summary>
    /// Clase que representa una computadora.
    /// </summary>
    public class Computadora
    {
        public int Id { get; set; }
        public string Serial_Number { get; set; }
        public int Ano_Fabricacion { get; set; }
        public string Marca { get; set; }
        public List<Pais> Paises_venta { get; set; }
        public List<Pais> Paises_Prohibida_venta { get; set;}

        public Computadora()
        {
            this.Paises_venta = new List<Pais>();
            this.Paises_Prohibida_venta = new List<Pais>();
        }
    }
}
