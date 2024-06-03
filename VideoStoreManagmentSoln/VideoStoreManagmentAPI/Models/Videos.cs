<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStoreManagmentAPI.Models
{
    public class Videos
    {
        [Key]
        public int VideoId { get; set; }

<<<<<<< HEAD
        public Genre Genre { get; set; }
=======
        public Genre Genre {  get; set; }
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Availability { get; set; }
        public VideoFormat VideoFormat { get; set; }
<<<<<<< HEAD
        public decimal Price { get; set; }

        public int VideoCount { get; set; } = 5;

        public int PublisherId { get; set; } 

        public ICollection<FeedBack>? Feedbacks { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }

        [ForeignKey("PublisherId")] 
        public virtual User Publisher { get; set; }
=======
        public decimal Price {  get; set; }
       
        public int VideoCount { get; set; } = 5;

        [ForeignKey("PublisherId")]
        public int PublisherId {  get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<FeedBack>? Feedbacks { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    }

    public enum VideoFormat
    {
        DVD,
        BlueRay
    }

    public enum Genre
    {
        Sci_Fic,
        Action,
        Comedy,
        Drama,
        Bio_pic,
        Animation,
        Marvel,
        Disney,
        DC,
        Historical,
        Horror,
        Thriller
    }

    public enum Genre
    {
        Sci_Fic,
        Action,
        Comedy,
        Drama,
        Bio_pic,
        Animation,
        Marvel,
        Disney,
        DC,
        Historical,
        Horror,
        Thriller

    }

}
