﻿using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository.Common;

namespace MvcMusicStore.Domain.Interfaces.Repository.ReadOnly
{
    public interface IOrderDetailReadOnlyRepository : IReadOnlyRepository<OrderDetail>
    {
         
    }
}