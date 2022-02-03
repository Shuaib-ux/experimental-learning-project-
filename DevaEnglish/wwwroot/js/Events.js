

function filterAvailability(eventID) {
    var notesBoxID = "availabilityNotes_" + eventID;
    var dropdownID = "availabilityTable_" + eventID;
    var filterValue = document.getElementById(dropdownID).value;
    if (filterValue.localeCompare("Unavailable")) {
        document.getElementById(notesBoxID).style.display = "none";
    } else {
        document.getElementById(notesBoxID).style.display = "block";
    }
}
function filterBooking(eventID) {
    var bookingNotesID = "bookingNotes_" + eventID;
    var bookingSelectID = "bookingTable_" + eventID;
    var filterValue = document.getElementById(bookingSelectID).value;
    if (filterValue.localeCompare("CantHost")) {
        document.getElementById(bookingNotesID).style.display = "none";
    } else {
        document.getElementById(bookingNotesID).style.display = "block";
    }
}