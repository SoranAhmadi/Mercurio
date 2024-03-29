﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOverViewRepository : IRepository<OverView>
    {
        new Task Update(OverView overView);
    }
}
