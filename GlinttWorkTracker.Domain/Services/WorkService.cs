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
        public async Task<IEnumerable<Work>> GetAll()
        {
            var issuesList = await _unitOfWork.WorkRepository.GetAll();
            await _unitOfWork.SaveAsync();
            return issuesList;
        }
        public async Task<bool> AddWork(Work work)
        {
            var inserted = await _unitOfWork.WorkRepository.AddWork(work);
            await _unitOfWork.SaveAsync();
            return inserted;
        }
    }
}
