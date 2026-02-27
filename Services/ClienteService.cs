using ClientesApi.Models;

namespace ClientesApi.Services
{
    public class ClienteService
    {
        private static List<Cliente> _clientes = new();
        private static int _nextId = 1;

        public List<Cliente> GetAll() => _clientes;

        public Cliente? GetById(int id) =>
            _clientes.FirstOrDefault(c => c.Id == id);

        public Cliente Add(Cliente cliente)
        {
            cliente.Id = _nextId++;
            _clientes.Add(cliente);
            return cliente;
        }

        public bool Update(int id, Cliente clienteActualizado)
        {
            var cliente = GetById(id);
            if (cliente == null) return false;

            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Apellido = clienteActualizado.Apellido;
            cliente.Direccion = clienteActualizado.Direccion;

            return true;
        }

        public bool Delete(int id)
        {
            var cliente = GetById(id);
            if (cliente == null) return false;

            _clientes.Remove(cliente);
            return true;
        }
    }
}