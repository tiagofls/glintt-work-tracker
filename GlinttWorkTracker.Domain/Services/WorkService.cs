using GlinttWorkTracker.Domain.Models;
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
        public async Task<Work> CreateWork(Work work)
        {
            Work createdWork = await _unitOfWork.WorkRepository.CreateWorkAsync(work);
            await _unitOfWork.SaveAsync();
            return createdWork;
        }
        public async Task<Work> UpdateWork(Work work)
        {
            Work updatedWork = await _unitOfWork.WorkRepository.UpdateWorkAsync(work);
            await _unitOfWork.SaveAsync();
            return updatedWork;
        }
        public async Task<Work> DeleteWork(Work work)
        {
            Work deletedWork = await _unitOfWork.WorkRepository.DeleteWorkAsync(work);
            await _unitOfWork.SaveAsync();
            return deletedWork;
        }
    }
}
