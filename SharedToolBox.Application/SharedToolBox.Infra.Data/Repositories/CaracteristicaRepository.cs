﻿using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;

namespace SharedToolBox.Infra.Data.Repositories
{
    public class CaracteristicaRepository : RepositoryBase<Caracteristica>, ICaracteristicaRepository
    {
        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return Db.Produtos.Where(p => p.Nome == nome);
        //}
    }
}