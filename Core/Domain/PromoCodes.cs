using Core.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Core.Domain
{
    public class PromoCodes
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        public string CodeName { get; set; }
        [Required(ErrorMessage = "Value is required.")]
        public int Value { get; set; }
        [EnumDataType(typeof(DiscountType))]
        [Required(ErrorMessage = "Discount Type is required.")]
        public DiscountType DiscountType { get; set; }
        [Required(ErrorMessage = "Minimum Required Requests is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum Required Requests must be greater than 0.")]
        public int MinimumRequiredRequests { get; set; }
        [DefaultValue(0)]
        public int NoOfTimesUsed { get; set; }
    }
}
