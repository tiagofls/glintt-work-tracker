﻿using GlinttWorkTracker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkRepository WorkRepository { get; }
        Task SaveAsync();
    }
}
