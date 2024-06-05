using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using VideoStoreManagmentAPI.Models.DTOs;
=======
<<<<<<< HEAD
using VideoStoreManagmentAPI.Models.DTOs;
=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74

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
<<<<<<< HEAD
        public String Status {  get; set; }
        public ICollection<Videos> Videos { get; set; }
=======
<<<<<<< HEAD
        public String Status {  get; set; }
        public ICollection<Videos> Videos { get; set; }
=======

>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
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
