using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PromoCodesRepository : IPromoCodesRepository
    {
        private readonly ApplicationDbContext _context;

        public PromoCodesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public int GetPromoCodeId(string promocode)
        {
            var promoCode = _context.PromoCodes.Where(x => x.CodeName == promocode).FirstOrDefault();
            return promoCode.Id;
        }

    }
}
