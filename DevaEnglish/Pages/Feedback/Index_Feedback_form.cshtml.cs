    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DevaEnglish.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;


namespace DevaEnglish.Pages.Feedback
{
    public class Index_Feedback_formModel : PageModel
    {


        [BindProperty]
        public DevaEnglish.Data.Feedback Scores { get; set; }
        private readonly AppDbContext _db;
         public List<Plans> PlansWithLetterA { get; set; }
        List<Families> familyList { get; set; }

        public Dictionary<int, string > FamilyNames { get; set; }
        public IDictionary<int?,string> CoachNames { get; set; }
       

    
        //feedback scores 1-5 int array 
        public int[] feedbackOptions = new[] { 1, 2, 3, 4, 5 };

            
        
                public Index_Feedback_formModel(Data.AppDbContext db)
                {
                    //variable holds our database
                    _db = db;
                    PlansWithLetterA = _db.Plans.Where(x => x.PlanLetter == 'A').ToList();
                    familyList = _db.Families.FromSqlRaw("Select * from families").ToList();
                    CoachNames = new Dictionary<int?, string>();
                }


                public void OnGet(int feedbackResponse)
                {
                        TempData["FeedbackResponse"] = feedbackResponse;
                        foreach (var plan in PlansWithLetterA) {
                            CoachNames.Add(plan.GroupID,
                                _db.Groups.Where(x => x.GroupID == plan.GroupID).FirstOrDefault().Name);
                        }
                       
                        FamilyNames = familyList.ToDictionary( x => x.FamilyID, x => x.FamilyName);//dictionary for familyID: familyName 

                }

                public void OnGetCoachFamilies(int GroupID) 
                { 
                    //
                }

                public async Task<IActionResult> OnPostFeedbackAsync()
                {
                    //converts the respective names to ids 
                    //Scores.GroupID = _db.Groups.Where(x => x.Name == GroupName).FirstOrDefault().GroupID;
                    //Scores.FamilyID = _db.Families.Where(x => x.FamilyName == FamilyName).FirstOrDefault().FamilyID;

                    Scores.FamilyID = 327;       

                    if (ModelState.IsValid)
                    {

                        Scores.Average =

                        ((float)(Scores.Bed + Scores.General + Scores.English + Scores.EveningMeal + Scores.Bedroom + Scores.Breakfast
                        + Scores.Lunch + Scores.People + Scores.Home)) / 9;



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

                                var groupID = Scores.GroupID;

                                return RedirectToPage("Index_Feedback_form", new { feedbackResponse = 1});
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



