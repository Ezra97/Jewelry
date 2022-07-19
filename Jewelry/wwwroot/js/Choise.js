//$(document).ready(function () {
//    $("#Search").on(function () {
//        var $this = $(this);
//        // var url = $this.parent().data("submit-url") + "/" + $this.val();

//        if ($this.val().slice(0, 1) == "g") {
//            var url = "/Home/Index/" + $this.val().slice(1);
//            window.location.href = url;
//        }
//        else {
//            var url = "/Home/Details/" + $this.val().slice(1);
//            window.location.href = url;
//        }
//    });

//});
//$(document).ready(function () {
//    $("#Search").on("input", function () {
//        if ($("datalist").find('option[value="' + this.value + '"]')) {
//            //your code as per need
//            alert(this.value);
//        }
//    })
//})
//$(document).on("change", "datalist", (function () {

//    var $this = $(this);
//    // var url = $this.parent().data("submit-url") + "/" + $this.val();

//    if ($this.val().slice(0, 1) == "g") {
//        var url = "/Home/Index/" + $this.val().slice(1);
//        window.location.href = url;
//    }
//    else {
//        var url = "/Home/Details/" + $this.val().slice(1);
//        window.location.href = url;
//    }
//});



//$(document).ready(function () {
//    $("#Search").keyup(function () {
//        var $this = $(this).value;

//        var $select = $('#selectID');

//        for (var i = 0; i < $select.options.length; i++) {
//            if ($select.options[i].value.includes($this) == true) {
//                $select.options[i].css.display="";
//                else {
//                    $select.options[i].display = "none";
//                }
//            }
//        }
//    });
//});

function Change(input) {
   // var url = "/Home/Search/?search=תליונים";
    var url = "/Home/Search/?search=" + input.value;
    window.location.href = url;
}