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

    public interface IRepository
    {
        //-----------------------------------------------------------------------------------------

        Task<IList<PrevisaoClima>> Get_Minimas();
        Task<IList<PrevisaoClima>> Get_Maximas();

        Task<IList<Cidade>> Get_Cidades();

        Task<IList<PrevisaoClima>> Get_7Dias(string cidade);

        //-----------------------------------------------------------------------------------------
    }

    //---------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------
