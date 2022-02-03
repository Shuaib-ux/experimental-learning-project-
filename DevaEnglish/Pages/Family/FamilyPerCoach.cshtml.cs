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
    public class FamilyPerCoachModel : PageModel
    {

        private readonly AppDbContext _db;
        public bool currentDateEqualOrGreaterThanDepatureDate { get; set; } //bool to record if a button is shown depending on current date

        public FamilyPerCoachModel(AppDbContext db) {
            currentDateEqualOrGreaterThanDepatureDate = false;
            _db = db;
        }
        //model variables 
        public IList<Link> CoachFamilyIDs { get; set; }
        public Plans Plans { get; private set; }
        public IList<CoachFamilyIDs> FamilyIDs { get; set; }
        public int CurrentGroupID { get; set; }
        
        public IList<Families> FamilyList; //List we iterate through
        public int FamilyFeedbackAmount { get; set; }
        public PlanID_FamilyID FeedbackObj { get; set; }
      
        public int planID { get; set; }

        
        public void OnGet(int groupID)
        { //overall code needs refactoring 
            CurrentGroupID = groupID;
            TempData["CoachName"] = _db.Groups.Where(x => x.GroupID == groupID).FirstOrDefault().Name;

            //connect familyIDs to respective families in the family table
            //produces a list from the families which can be iterated through in the model 

           
            Plans = _db.Plans.Where(x => x.GroupID == groupID && x.PlanLetter == 'A').FirstOrDefault();
            CoachFamilyIDs = _db.Links.Where(x => x.PlanID == Plans.PlanID && x.Status == 0).ToList(); //List needs to conform to the exact plan and family booking choices

            FamilyIDs = new List<CoachFamilyIDs>();
            foreach (var coach in CoachFamilyIDs)
            {
                FamilyIDs.Add(new CoachFamilyIDs() { FamilyID = coach.FamilyID });
            }

            FamilyList = FamilyIDtoFamilyNamesAsync(FamilyIDs); //returns a list of families in which we can now access in cshtml
            
        }

        private IList<Families> FamilyIDtoFamilyNamesAsync(IList<CoachFamilyIDs> FamilyIDs)
        {
            
            //function purpose is to match the familyIDs from the Links table with the entries of the family table, to ultimately then get the names of the family
            Families entry;
            IList<Families> newFamilyList = new List<Families>();
            foreach (var familyID in FamilyIDs)
            {   // Purpose: find respective IDs and add entries to list

                //Current problem: Not finding and adding to list in DB --> check if the families data class and table in DB aligns

                int ID = familyID.FamilyID;
                
                try
                    {
                        entry = _db.Families.Find(ID); 
                        newFamilyList.Add(entry);

                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("Unable to get entry from FamilyIDs with familyID: " + ID);

                    }
            }
      
            return newFamilyList; 
        }

        public int FeedbackAmount(int familyID) {
           //function calculates the amount of feedbacks due
            var family = CoachFamilyIDs.First(item => item.FamilyID == familyID);//finds the family entry in the list by ID
            return family.NoOfMales + family.NoOfFemales;
        }
        public bool departure_day(int groupID) {
            //produces a true or false depending if the calculate of current date is greater than or equal to the departure day
            DateTime departure_day  = (_db.Groups.Find(groupID).DepartureDate).Date;
            DateTime currentDate = (DateTime.Now).Date;
            return currentDate >= departure_day;
        }
        public int FeedbackEntries(int familyID) {
           int entries =   _db.FeedbackScores.Where(x => x.GroupID == CurrentGroupID && x.FamilyID == familyID).Count();
            
            return entries;
        }
    }        
        
} 

