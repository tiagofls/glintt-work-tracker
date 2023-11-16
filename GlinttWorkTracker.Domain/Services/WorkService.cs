﻿using GlinttWorkTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Services
{
    public class WorkService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public WorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Work> UpserteWork(Work work)
        {
            Work createdWork = await _unitOfWork.WorkRepository.UpsertAsync(work);
            await _unitOfWork.SaveAsync();
            return createdWork;
        }
    }
}
