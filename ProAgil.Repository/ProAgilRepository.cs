using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
          public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
           public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTO

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query =_context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query =_context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);
                            .where(c => c.tema.ToLower().Contains(tema.ToLower));
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
             IQueryable<Evento> query =_context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);
                            .where(c => c.id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        //PALESTRANTE

        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos =false)
        {
             IQueryable<Palestrante> query =_context.Palestrantes
          
            .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Nome);
            .where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

         public Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos = false)
        {
            
             IQueryable<Palestrante> query =_context.Palestrantes
          
            .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            query = query.where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.FirstOrDefaultAsync();
        }

     
    }
}