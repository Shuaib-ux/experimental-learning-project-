using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevaEnglish.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevaEnglish.Pages.Family
{
    public class Feedback_formModel : PageModel
    {
        [BindProperty]
        public DevaEnglish.Data.Feedback Scores { get; set; }
        private readonly AppDbContext _db;
      
        

        //feedback scores 1-5 int array 
        public int[] feedbackOptions = new[] { 1, 2, 3, 4, 5 };


        public int ScoresFamilyID { get; set; }
        public int ScoresGroupID { get; set; }
        public Feedback_formModel(Data.AppDbContext db)
        {
            //variable holds our database
            _db = db;
        }


        public void OnGet(int feedbackResponse, int groupID, int familyID)
        {

                ScoresFamilyID = familyID;
                ScoresGroupID = groupID;
            TempData["FamilyName"] = _db.Families.Where(x => x.FamilyID == familyID).FirstOrDefault().FamilyName;;
            TempData["FeedbackResponse"] = feedbackResponse;
     

        }



        public async Task<IActionResult> OnPostFeedbackAsync()
        {
         
 
            if (ModelState.IsValid)
            {
                
                Scores.Average =
                
                ((float)(Scores.Bed + Scores.General + Scores.English + Scores.EveningMeal + Scores.Bedroom + Scores.Breakfast
                + Scores.Lunch + Scores.People + Scores.Home))/ 9;

                
                
                try
                {

                    Families familyEntry = await _db.Families.FindAsync(Scores.FamilyID);
                    if (familyEntry.AverageGrade >= 1)
                    {
                        familyEntry.AverageGrade = (familyEntry.AverageGrade + Scores.Average) / (2);
                    }
                    else
                    {
                        familyEntry.AverageGrade = Scores.Average;
                    }

                    familyEntry.NoOfFeedbacks += 1;
                    _db.Attach(familyEntry).State = EntityState.Modified;
                    // adds scores to the feedback scores table
                    _db.FeedbackScores.Add(Scores);//adds entry to db
                    await _db.SaveChangesAsync();

                    return RedirectToPage("Feedback_form", new { feedbackResponse= 1, groupID = Scores.GroupID, familyID = Scores.FamilyID });
                }
                catch (DbUpdateException e)
                {
                    throw new Exception($"Error SQL!", e);
                }
                
            }
            TempData["FeedbackResponse"] = 0;
            return Page();
        }

       
    }
}
