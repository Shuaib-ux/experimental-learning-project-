using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class Feedback
    {
        [Key]
        // auto generate feedback ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackID { get; set; }
        [ForeignKey("FamilyID")]
        public int FamilyID { get; set; }
        [ForeignKey("GroupID")]
        public int GroupID { get; set; }
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'Bed'")]
        public int Bed { get;set;}
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'Bedroom'")]
        public int Bedroom  {get;set;}
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'Breakfast'")]
        public int Breakfast {get;set;}
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'My family helped improve my English'")]
        public int English{ get; set; }
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'My family had time to speak to me'")]
        public int General { get; set; }
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'My host family's home'")]
        public int Home{ get; set; }
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'Evening Meal'")]
        public int EveningMeal { get; set; }
        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'The People in the host family's home'")]
        public int People { get;set;}

        [Range(1, 5, ErrorMessage = "Please enter a feedback score for 'Packed Lunch'")]
        public int Lunch { get; set; }
       
        public string Notes{ get; set; }
        
        public float Average { get; set; }


}
}
