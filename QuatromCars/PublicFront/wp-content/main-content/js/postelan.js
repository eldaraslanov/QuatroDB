//$(".telcontrol").on("keypress", function (e) {
//    if ((e.keyCode >= 48 && e.keyCode <= 57)) {
//        var inp = $(this).val();
//        if (inp.length == 7) {
//            return false;
//        }
//      }
//   else {
//    e.preventDefault()
// }
//});
$("[data-btn='car-add']").click(checkPass);

function checkPass() {
    var inputval = $(".telcontrol").val()

    inputval = inputval.slice(0, 4).split("(")[1]
    $.ajax({
        url: "/Elanpost/CheckPhone/",
        method: 'Post',
        data: {
            'PhoneType': inputval
        },
        success: function (res) {
            if (res.status == 200) {
                $("[data-btn='car-add']").on("click", function () {
                    checkPass()
                    $("#register").find(".reg-over").remove()
                    $(this).parent().slideUp(800)
                })
                $("[data-btn='car-partadd']").on("click", function () {
                    checkPass()
                    $("#register").hide()
                    $("#registerAvtoParths").removeClass("reg-active")
                    $(this).parent().slideUp(800)
                })
                console.log(res)
            } else {
                console.log(res)
            }
            

        }
    })

    
}
