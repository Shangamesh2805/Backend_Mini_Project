using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age {  get; set; }
        public UserType Membership {  get; set; }
        public int DeviceLimit { get; set; }
        public decimal DiscountFactor { get; set; }
        public ICollection<Orders>? Orders { get; set; }
        public Cart Cart { get; set; }

        public ICollection<FeedBack> FeedBack { get; set; }


    }
    public enum UserType
    {
        NormalMember,
        GoldenMember
    }
}
