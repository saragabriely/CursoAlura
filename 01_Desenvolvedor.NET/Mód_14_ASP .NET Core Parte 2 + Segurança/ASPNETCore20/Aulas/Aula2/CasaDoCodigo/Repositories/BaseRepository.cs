using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    // O 'T' é uma entidade que herda do BaseModel
    public class BaseRepository<T> where T : BaseModel 
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet; // dbSet será generico!
                            // Qualquer classe poderá usá-lo

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;

            dbSet = contexto.Set<T>();
        }

    }
}
