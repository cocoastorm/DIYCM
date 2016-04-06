var notifications; //stores content of notifications ( makes notifications small )
var acc;

// click on notifications
$("#notifications-container").click(function(e){
    var t = $(this);
    if (!$(event.target).hasClass("notifications-accordion")      && // click on button
        !$(event.target).hasClass("notifications-panel")          && // click on contents
        !$(event.target).parent().hasClass("notifications-panel") && // content child supports nest <p>
        !$(event.target).parent().parent().hasClass("notifications-panel")) // contents child's child <ul> <li>
        {// if not content of a notification
            if (t.width() != 20)
            {
                notifications = t.html(); // save html
                t.html(""); // clear
                t.animate({width: '20px'}, "slow"); // shrink
            }
            else
            {
                t.html(notifications); // restore html
                t.animate({width: '22%'}, "slow"); // grow
            }
        }
    else // content of a notification
    {
        /* Toggle between adding and removing the "active" and "show" classes when the user clicks on one of the "Section" buttons. The "active" class is used to add a background color to the current button when its belonging panel is open. The "show" class is used to open the specific accordion panel */
        acc = document.getElementsByClassName("notifications-accordion");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].onclick = function () {
                this.classList.toggle("active"); // highlights tab
                this.nextElementSibling.classList.toggle("show"); // shows content
            }
        }
    }
});
