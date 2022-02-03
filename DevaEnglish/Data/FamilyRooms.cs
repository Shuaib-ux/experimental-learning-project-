using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevaEnglish.Data
{
    public class FamilyRooms
    { [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int FamilyRoomID { get; set; }

        public int RoomNumber { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [ForeignKey("FamilyID")]
        public int FamilyID { get; set; }

       
    }
}
