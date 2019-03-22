$(document).ready(function () {
    $('#calendar').fullCalendar({
        
        header:
        {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonText: {
            today: 'today',
            month: 'month',
            week: 'week',
            day: 'day'
        },

        events: function (start, end, timezone, callback) {
            console.log("inside events");
            $.ajax({
                url: '/Event/AllEvents',
                type: "GET",
                dataType: "JSON",
                
                success: function (result) {
                    var events = [];
                    //console.log("result",result);
                    $.each(result, function (i, data) {
                        console.log(data.id)
                        console.log(data)
                        events.push(
                            {
                                id: data.id,
                                title: data.name,
                                description: data.Desc,
                                date: data.date,
                                location: data.location,
                                startTime: data.timeStart,
                                endTime: data.timeEnd,
                                start: moment(data.date).format('YYYY-MM-DD hh:mm'),
                                allDay: false,
                                backgroundColor: "#01FCD9"
                            });
                    });

                    callback(events);
                }
            });
        },
        eventClick: function (calEvent, jsEvent, view) {
            console.log(calEvent.id);
            //UpdateEvent(calEvent.id);
            sessionStorage.setItem("e_id", calEvent.id);
            console.log(calEvent.id)
            console.log("click")
            $('#modalTitle').html(calEvent.title);
            $('#eventLoc').html(calEvent.location);
            $('#eventDate').html(calEvent.date);
            $('#eventSTime').html(calEvent.startTime);
            $('#eventETime').html(calEvent.endTime);
            $('#eventDesc').html(calEvent.description);
            $('#eventSID1').val(calEvent.id);
            $('#eventSID2').val(calEvent.id);
            $('#eventSID3').val(calEvent.id);
            //$('#RegButton').val(calEvent.id);
            $('#RegButton').attr('name', calEvent.id);
            $('#calendarModal').modal();
            $('#RegButton').show();
            console.log("Hello Id")
            console.log($('#RegButton').attr("id"))
            /*if ($('#RegButton').attr("id") != "RegButton" + calEvent.id) {
                $('#RegButton').attr("id", "RegButton");
                $('#RegButton').show();
            }*/
            var eventsDataArray = [];
            $('#events li').each(function () {
                eventsDataArray.push($(this).attr('data-store'));
            });
            var teamsDataArray = [];
            $('#teams li').each(function () {
                teamsDataArray.push($(this).attr('data-store'));
            });
            var userDataArray = [];
            $('#user li').each(function () {
                userDataArray.push($(this).attr('data-store'));
            });
            for (var i = 0; i < eventsDataArray.length; i++)
            {
                if (eventsDataArray[i] == calEvent.id && teamsDataArray[i] == userDataArray[0])
                {
                    if ($('#eventSID1').val() == calEvent.id) {
                        //$('#RegButton').attr("id", "RegButton" + calEvent.id);
                        //$('#RegButton' + calEvent.id).val(calEvent.id);
                        $('[name="' + calEvent.id + '"]').hide();
                    }
                }
            }
            //alert(calEvent.start);
            //alert('Event: ' + moment('29/02/2020T09:10:00.000').format('YYYY-MM-DD hh:mm'));

        },

        editable: false
    });
});  



//function UpdateEvent(EventID) {
//    function RegisterEvent(EventID) {
//        //var dataRow = {
//        //    'id': EventID,
//        //    'NewEventStart': EventStart,
//        //    'NewEventEnd': EventEnd
//        //}
//        console.log(EventID);
//        $.ajax({
//            type: 'POST',
//            //url: "@Url.Action("ViewEvent","Event")",
//            dataType: "json",
//            contentType: "application/json",
//            data: JSON.stringify({ id: EventID }),
//            success: function (data) {
//                console.log(data)

//            }

//        });
//    }
//}