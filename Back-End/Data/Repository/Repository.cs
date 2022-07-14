//-------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Back_End.Models;

//-------------------------------------------------------------------------------------------------

namespace Back_End.Data
{
    //---------------------------------------------------------------------------------------------

    public class Repository : IRepository
    {        
        //-----------------------------------------------------------------------------------------

        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------
        
        public async Task<IList<PrevisaoClima>> Get_Minimas()
        {
            //-------------------------------------------------------------------------------------

            IQueryable<PrevisaoClima> query = _context.PrevisaoClima;

            //-------------------------------------------------------------------------------------

            query = query.Where(q => q.DataPrevisao == (DateTime.Today));

            query = query.OrderBy(q => q.TemperaturaMinima).Take(3);

            query = query.Include(q => q.Cidade.Estado);

            query = query.OrderBy(q => q.Cidade.Nome);
            query = query.OrderBy(q => q.Cidade.Estado.UF);

            query = query.AsTracking();

            //-------------------------------------------------------------------------------------

            return await query.ToListAsync();

            //-------------------------------------------------------------------------------------
        }

        public async Task<IList<PrevisaoClima>> Get_Maximas()
        {
            //-------------------------------------------------------------------------------------
            
            IQueryable<PrevisaoClima> query = _context.PrevisaoClima;

            //-------------------------------------------------------------------------------------
            
            query = query.Where(q => q.DataPrevisao == (DateTime.Today));

            query = query.OrderByDescending(q => q.TemperaturaMaxima).Take(3);

            query = query.Include(q => q.Cidade.Estado);

            query = query.OrderBy(q => q.Cidade.Nome);
            query = query.OrderBy(q => q.Cidade.Estado.UF);

            query = query.AsTracking();

            //-------------------------------------------------------------------------------------
            
            return await query.ToListAsync();
       
            //-------------------------------------------------------------------------------------
        }

        //-----------------------------------------------------------------------------------------  

        public async Task<IList<Cidade>> Get_Cidades()
        {
            //-------------------------------------------------------------------------------------
            
            IQueryable<Cidade> query = _context.Cidade;

            //-------------------------------------------------------------------------------------
            
            query = query.Include(q => q.Estado);

            query = query.OrderBy(q => q.Nome);

            query = query.AsTracking();

            //-------------------------------------------------------------------------------------
            
            return await query.ToListAsync();
        
            //-------------------------------------------------------------------------------------
        }

        public async Task<IList<PrevisaoClima>> Get_7Dias(string cidade)
        {
            //-------------------------------------------------------------------------------------
            
            IQueryable<PrevisaoClima> query = _context.PrevisaoClima;

            //-------------------------------------------------------------------------------------
            
            query = query.Include(q => q.Cidade.Estado);

            query = query.Where(q => q.Cidade.Nome.ToLower().Equals(cidade.ToLower()));
            
            query = query.Where(q => q.DataPrevisao > (DateTime.Today));

            query = query.OrderBy(q => q.DataPrevisao).Take(7);

            query = query.AsTracking();

            //-------------------------------------------------------------------------------------
            
            return await query.ToListAsync();
        
            //-------------------------------------------------------------------------------------
        }

        //-----------------------------------------------------------------------------------------   
    }

    //---------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------
