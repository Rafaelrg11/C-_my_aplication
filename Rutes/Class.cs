using MyAplication;
using MyAplication.Operation;

namespace MyAplication.Rutes
{
    public interface Users 
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task<Persona> GetDetails(int Id);
        Task<bool> InsertUsuario(Persona persona);
        Task<bool> UpdateUsuario(int id);
        Task<bool> DeleteUsuario(int id);
    }
}
