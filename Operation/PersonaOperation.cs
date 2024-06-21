using Microsoft.EntityFrameworkCore;
using MyAplication.DTO;

namespace MyAplication.Operation
{
    public class PersonaOperation 
    {
        private NewDbContext _context;

        public PersonaOperation(NewDbContext db)
        {
            _context = db;
        }

        public async Task<List<Persona>> GetPersonas()
        {
            var persona = await _context.Personas.AsNoTracking().ToListAsync(); ;

            return persona;
        }

        public async Task <Persona> CreatePersona(Persona persona)
        {
            try
            {
                var result = await _context.Personas.AddAsync(persona);
                await _context.SaveChangesAsync();

                return persona;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdatePersona(PersonaDTO personadto)
        {
            Persona? persona  = await _context.Personas.FindAsync(personadto.Id);
            if (persona != null)
            {
                persona.Name = personadto.Name;
                persona.Lastname = personadto.Lastname;
                persona.Gmail = personadto.Gmail;
                persona.Dni = personadto.Dni;
                
                //_context.Personas.Update(persona);
                await _context.SaveChangesAsync();
             };
            return true;
        }

        public async Task<bool> DeletePersona(int id)
        {
            var result = await _context.Personas.FindAsync(id);

            if(result == null)
            {
                return false;
            }
            _context.Personas.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }

    
}
