﻿using HRMS.EFDb.Domain;
using HRMS.EFDb.Repositories.Interfaces;

namespace HRMS.EFDb.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(AppDbContext context) : base(context)
        {

        }
    }
}
