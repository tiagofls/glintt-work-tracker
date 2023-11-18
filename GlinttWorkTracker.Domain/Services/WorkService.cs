using GlinttWorkTracker.Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
        public async Task<IEnumerable<Work>> GetAll()
        {
            var issuesList = await _unitOfWork.WorkRepository.GetAll();
            await _unitOfWork.SaveAsync();
            return issuesList;
        }
        public async Task<bool> AddWork(Work work)
        {
            var inserted = await _unitOfWork.WorkRepository.Add(work);
            await _unitOfWork.SaveAsync();
            return inserted;
        }
        public async Task<bool> UpdateWork(Work work)
        {
            var updated = await _unitOfWork.WorkRepository.Update_(work);
            await _unitOfWork.SaveAsync();
            return updated;
        }
        public async Task<bool> DeleteWork(Work work)
        {
            var deleted = await _unitOfWork.WorkRepository.Delete(work);
            await _unitOfWork.SaveAsync();
            return deleted;
        }
        public async Task<Work> FindById(string id)
        {
            var found = await _unitOfWork.WorkRepository.FindById(id);
            await _unitOfWork.SaveAsync();
            return found;
        }
    }
}
