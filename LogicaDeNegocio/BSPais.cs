using Tarea.Modelo;

namespace Tarea.LogicaDeNegocio
{
    public class BSPais
    {
        /// <summary>
        /// Lista de los paises registrados.
        /// </summary>
        private static readonly List<Pais> PaisesRegistrados = new();

        /// <summary>
        /// Atributo para tener acceso a la lógica de las computadoras.
        /// </summary>
        //private readonly BSComputadora ServicioComputadora = new();


        /// <summary>
        /// Método para guardar un pais en el repositorio de datos.
        /// </summary>
        /// <param name="pais">El país que se va a guardar</param>
        /// <returns>El país que se guardo en el repositorio de datos</returns>
        private static Pais Create (Pais pais)
        {
            int id_pais = PaisesRegistrados.Count + 1;
            pais.Id = id_pais;
            PaisesRegistrados.Add(pais);
            return pais;
        }

        /// <summary>
        /// Método para obtener un país a tra vés de un ID dado.
        /// </summary>
        /// <param name="id">El ID con el que se va a buscar un país</param>
        /// <returns>El país que se encontró con el ID</returns>
        private static Pais? Retrieve(int id)
        {
            Pais? pais = null;
            foreach (Pais paisSeleccionado in PaisesRegistrados)
            {
                if (id == paisSeleccionado.Id)
                {
                    pais = paisSeleccionado;
                    break;
                }
            }
            return pais;
        }

        /// <summary>
        /// Método para actualizar los valores de un país.
        /// </summary>
        /// <param name="paisActualizado">El país con los valores actaulizados</param>
        private static void Update(Pais paisActualizado)
        {
            for (int i = 0; i < PaisesRegistrados.Count; i++)
            {
                if (PaisesRegistrados[i].Id == paisActualizado.Id)
                {
                    PaisesRegistrados[i].Descripcion = paisActualizado.Descripcion;
                    PaisesRegistrados[i].Codigo_pais = paisActualizado.Codigo_pais;
                    break;
                }
            }
        }

        /// <summary>
        /// Método para borrar un país de la lista.
        /// </summary>
        /// <param name="pais"></param>
        private static void Delete(Pais pais)
        {
            PaisesRegistrados.Remove(pais);
        }

        /// <summary>
        /// Método para devolver todos los paises registrados
        /// </summary>
        /// <returns>La lista con todos los paises registrados</returns>
        private static List<Pais> RetrieveAll()
        {
            return PaisesRegistrados;
        } 

        /// <summary>
        /// Método para agregar un país.
        /// </summary>
        /// <param name="pais">El país que se va agregar</param>
        /// <returns>El país agregado</returns>
        public Pais Agregar(Pais pais)
        {
            return BSPais.Create(pais);
        }

        /// <summary>
        /// Método para obtener un país.
        /// </summary>
        /// <param name="id">El id con el que se va obtener el país</param>
        /// <returns>El país que se obtuvo dado un id o null sino se encuentra nada</returns>
        public Pais? Obtener(int id)
        {
            return BSPais.Retrieve(id);
        }

        /// <summary>
        /// Método para obtener todos los paises registrados.
        /// </summary>
        /// <returns>Todos los paises registrados</returns>
        public List<Pais> ObtenerTodos()
        {
            return BSPais.RetrieveAll();
        }

        /// <summary>
        /// Método para actualizar un apís
        /// </summary>
        /// <param name="pais">El país a actualizar</param>
        public void Actualizar(Pais pais)
        {
            BSPais.Update(pais);
        }

        /// <summary>
        /// Método para borrar un país.
        /// </summary>
        /// <param name="pais">El país que se va a borrar</param>
        public void Borrar(int id)
        {
            Pais pais = this.Obtener(id);
            BSPais.Delete(pais);
        }

        /// <summary>
        /// Método para agregar una computadora en venta en un país.
        /// </summary>
        /// <param name="idPais">El id del país en el que se puede vender la computadora</param>
        /// <param name="idComputadora">El id de la computadora que se puede vender</param>
        /*public void AgregarComputadoraEnVenta (int idPais, int idComputadora)
        {
            Computadora computadora = ServicioComputadora.Obtener(idComputadora);
            if (!BSPais.ComputadorasEnVenta.ContainsKey(idPais))
            {
                BSPais.ComputadorasEnVenta.Add(idPais, new List<Computadora>());
            }
            BSPais.ComputadorasEnVenta[idPais].Add(computadora);
        }

        /// <summary>
        /// Método para agregar una computadora prohibida en un país.
        /// </summary>
        /// <param name="idPais">El id del país en el que esta prohibida la venta de una computadora</param>
        /// <param name="idComputadora">El id de la computadora que esta prohibida</param>
        public void AgregarComputadoraProhibida(int idPais, int idComputadora)
        {
            Computadora computadora = ServicioComputadora.Obtener(idComputadora);
            if (!BSPais.ComputadorasProhibidad.ContainsKey(idPais))
            {
                BSPais.ComputadorasProhibidad.Add(idPais, new List<Computadora>());
            }
            BSPais.ComputadorasProhibidad[idPais].Add(computadora);
        }*/
    }
}
