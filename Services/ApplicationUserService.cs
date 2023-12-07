using Core.Repository;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class ApplicationUserService : IApplicationUserService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public ApplicationUserService(IUnitOfWork UnitOfWork) 
        { 
            _unitOfWork = UnitOfWork;
        }

    }
}
