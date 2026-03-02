using ClientesApi.Models;

namespace ClientesApi.Services
{
    public class ClienteService
    {
        private static List<Cliente> _clientes = new()
        {
            new Cliente { Id = 1, Nombre = "Sofia", Apellido = "Crisafulli", Direccion = "Neuquén" },
            new Cliente { Id = 2, Nombre = "Juan", Apellido = "Pérez", Direccion = "Buenos Aires" },
            new Cliente { Id = 3, Nombre = "María", Apellido = "Gómez", Direccion = "Córdoba" },
            new Cliente { Id = 4, Nombre = "Lucas", Apellido = "Fernández", Direccion = "Mendoza" }
        };

        private static int _nextId = 5;

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