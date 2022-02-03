
let calendarEl = document.getElementById('calendar');

let calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
    events: eventsArray,
    });

calendar.render();

function filterCalendar() {
    var filterValue = document.getElementById("changeShowing").value;
    calendar.batchRendering(() => {
        calendar.getEvents().forEach(event => event.remove());
        if (filterValue.localeCompare("All") == 0) {
            eventsArray.forEach(event => calendar.addEvent(event));
        }
        else if (filterValue.localeCompare("Coaches") == 0) {
            coachEventsArray.forEach(event => calendar.addEvent(event));
        }
        else if (filterValue.localeCompare("Availability") == 0) {
            availabilityEventsArray.forEach(event => calendar.addEvent(event));
        };
    });
}