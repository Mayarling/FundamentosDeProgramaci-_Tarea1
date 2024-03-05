using Tarea.Modelo;

namespace Tarea.LogicaDeNegocio
{
    public class BSComputadora
    {
        /// <summary>
        /// Lista de las computadoras registradas.
        /// </summary>
        private static readonly List<Computadora> computadorasRegistradas = new List<Computadora>();


        /// <summary>
        /// Método para guardar una computadora en el repositorio de datos.
        /// </summary>
        /// <param name="computadora">La computadora que se va a guadar</param>
        /// <returns>La computadora que se guardo en el repositorio de datos</returns>
        private static Computadora Create(Computadora computadora)
        {
            int idComputadora = computadorasRegistradas.Count + 1;
            computadora.Id = idComputadora;
            computadorasRegistradas.Add(computadora);
            return computadora;
        }

        /// <summary>
        /// Método para obtener una computadora a través de un Id dado.
        /// </summary>
        /// <param name="id">El id con el que se va a buscar un plato</param>
        /// <returns>La computadora que se encontró con el Id</returns>
        private static Computadora? Retrieve(int id)
        {
            Computadora? computadora = null;
            foreach (Computadora computadoraSeleccionada in computadorasRegistradas)
            {
                if (id == computadoraSeleccionada.Id)
                {
                    computadora = computadoraSeleccionada;
                    break;
                }
            }
            return computadora;
        }

        /// <summary>
        /// Método para actualizar los valores de una computadora.
        /// </summary>
        /// <param name="computadoraActualizada">La computadora con los valores actualizados</param>
        private static void Update(Computadora computadoraActualizada)
        {
            for (int i = 0; i < computadorasRegistradas.Count; i++)
            {
                if (computadorasRegistradas[i].Id == computadoraActualizada.Id)
                {
                    computadorasRegistradas[i].Serial_Number = computadoraActualizada.Serial_Number;
                    computadorasRegistradas[i].Ano_Fabricacion = computadoraActualizada.Ano_Fabricacion;
                    computadorasRegistradas[i].Marca = computadoraActualizada.Marca;
                    computadorasRegistradas[i].Paises_venta = computadoraActualizada.Paises_venta;
                    computadorasRegistradas[i].Paises_Prohibida_venta = computadoraActualizada.Paises_Prohibida_venta;
                    break;
                }
            }

        }

        /// <summary>
        /// Método para borrar una computadora de la lista.
        /// </summary>
        /// <param name="computadora"></param>
        private static void Delete(Computadora computadora)
        {
            computadorasRegistradas.Remove(computadora);
        }

        /// <summary>
        /// Método para devolver todos los platos registrados
        /// </summary>
        /// <returns>La lista con todas la computadoras registradas</returns>
        private static List<Computadora> RetrieveAll()
        {
            return computadorasRegistradas;
        }

        /// <summary>
        /// Método para agregar una computadora.
        /// </summary>
        /// <param name="computadora"La computadora que se va agregar></param>
        /// <returns>La computadora agregada</returns>
        public Computadora Agregar (Computadora computadora)
        {
            return BSComputadora.Create(computadora);
        }

        /// <summary>
        /// Método para obtener una computadora 
        /// </summary>
        /// <param name="id">El id con l que se va a obtener una computadora</param>
        /// <returns>La computadoraque se obtuvo dado un id o null sino encuentra nada</returns>
        public Computadora Obtener (int id)
        {
            return BSComputadora.Retrieve(id);
        }

        /// <summary>
        ///  Metodo para actualizar una computadora.
        /// </summary>
        /// <param name="computadora">La computadora a actualizar</param>
        public void Actualizar(Computadora computadora)
        {
            BSComputadora.Update(computadora);
        }

        /// <summary>
        /// Método para borrar una computadora.
        /// </summary>
        /// <param name="id">La computadora a borra</param>
        public void Borrar(int id)
        {
            Computadora computadora = this.Obtener(id);
            BSComputadora.Delete(computadora);
        }

        /// <summary>
        /// Método para obtener todas las computadoras registradas.
        /// </summary>
        /// <returns>Todas las computadoras registradas</returns>
        public List<Computadora> ObtenerTodos()
        {
            return BSComputadora.RetrieveAll();
        }

        /// <summary>
        /// Método para agregar un país a la lista de ventas de una computadora.
        /// </summary>
        /// <param name="idComputadora">El ID de la computadora en venta</param>
        /// <param name="pais">El país donde se puede vender dicha computadora</param>
        public void AgregarPaisVenta(int idComputadora, Pais pais)
        {
            Computadora computadora = this.Obtener(idComputadora);
            computadora.Paises_venta.Add(pais);
            this.Actualizar(computadora);
        }

        /// <summary>
        /// Método para agregar un país donde esta prohibida la venta a la lista de una computadora.
        /// </summary>
        /// <param name="idComputadora">El id de la computadora en venta</param>
        /// <param name="pais">El país donde no se puede vender una computadora</param>
        public void AgregarPaisProhibido(int idComputadora, Pais pais)
        {
            Computadora computadora = this.Obtener(idComputadora);
            computadora.Paises_Prohibida_venta.Add(pais);
            this.Actualizar(computadora);
        }

        /// <summary>
        /// Método para actualizar un país a la lista de ventas de una computadora.
        /// </summary>
        /// <param name="idComputadora">El ID de la computadora en venta</param>
        /// <param name="pais">El país donde se puede vender dicha computadora</param>
        public void ActualizarPaisVenta(int idComputadora, Pais pais)
        {
            Computadora computadora = this.Obtener(idComputadora);
            for (int i = 0; i < computadora.Paises_venta.Count; i++)
            {
                if (computadora.Paises_venta[i].Id == pais.Id)
                {
                    computadora.Paises_venta[i].Descripcion = pais.Descripcion;
                    computadora.Paises_venta[i].Codigo_pais = pais.Codigo_pais;
                }
            }
            this.Actualizar(computadora);
        }

        /// <summary>
        /// Método para actualizar un país donde esta prohibida la venta a la lista de una computadora.
        /// </summary>
        /// <param name="idComputadora">El ID de la computadora en venta</param>
        /// <param name="pais">El país donde se puede vender dicha computadora</param>
        public void ActualizarPaisProhibido(int idComputadora, Pais pais)
        {
            Computadora computadora = this.Obtener(idComputadora);
            for (int i = 0; i < computadora.Paises_Prohibida_venta.Count; i++)
            {
                if (computadora.Paises_Prohibida_venta[i].Id == pais.Id)
                {
                    computadora.Paises_Prohibida_venta[i].Descripcion = pais.Descripcion;
                    computadora.Paises_Prohibida_venta[i].Codigo_pais = pais.Codigo_pais;
                }
            }
            this.Actualizar(computadora);
        }
    }
}
