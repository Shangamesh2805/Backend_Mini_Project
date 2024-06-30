using System.ComponentModel.DataAnnotations;
using VideoStoreManagmentAPI.Models.DTOs;

namespace VideoStoreManagmentAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }
        public int Age {  get; set; }
        public Role Role {  get; set; }
        public UserType Membership {  get; set; }
        public int DeviceLimit { get; set; }
        public decimal DiscountFactor { get; set; }
        public ICollection<Orders>? Orders { get; set; }
        public Cart Cart { get; set; }
        public String Status {  get; set; }
        public ICollection<Videos> Videos { get; set; }
        public ICollection<FeedBack> FeedBack { get; set; }


        
    }
    public enum Role
    {
        Customer,
        Publisher
    }
    public enum UserType
    {
        NormalMember,
        GoldenMember
    }
}
