$(function () {
    $("#tblHata").on("click", ".Btn_hata_sil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Admin/Hata/Direk_Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        })
    });
});

//Sayfa yükleme barı
function ajax_loading() {
    var abc = document.getElementById("yukleme_durumu");
    abc.style.visibility = "visible";
}

// addToHomescreen.removeSession();     // use this to remove the localStorage variable
var ath = addToHomescreen({
    debug: 'android',           // activate debug mode in ios emulation
    skipFirstVisit: false,	// show at first access
    startDelay: 0,          // display the message right away
    lifespan: 0,            // do not automatically kill the call out
    displayPace: 0,         // do not obey the display pace
    privateModeOverride: true,	// show the message in private mode
    maxDisplayCount: 2     // do not obey the max display count
});
// ath.clearSession();      // reset the user session


window.addEventListener('beforeinstallprompt', function (e) {
    // beforeinstallprompt Event fired
    // e.userChoice will return a Promise.
    // For more details read: https://developers.google.com/web/fundamentals/getting-started/primers/promises
    e.userChoice.then(function (choiceResult) {
        console.log(choiceResult.outcome);
        if (choiceResult.outcome == 'dismissed') {
            console.log('Kullanıcı Home Screen eklemeyi iptal etti.');
        }

        else {
            console.log('Kullanıcı Home Screen ekledi');
        }
    });
});
//window.addEventListener("beforeinstallprompt", ev => {
//    // Stop Chrome from asking _now_
//    ev.preventDefault();
//    // Create your custom "add to home screen" button here if needed.
//    // Keep in mind that this event may be called multiple times, // so avoid creating multiple buttons!
//    myCustomButton.onclick = () => ev.prompt();
//});


//var deferredPrompt; window.addEventListener('beforeinstallprompt', function (e) {
//    console.log('beforeinstallprompt Event fired'); e.preventDefault();
//    // Stash the event so it can be triggered later.
//    deferredPrompt = e; return false;
//}); btnSave.addEventListener('click', function () {
//    if (deferredPrompt !== undefined) {
//        // The user has had a positive interaction with our app and Chrome
//        // has tried to prompt previously, so let's show the prompt.
//        deferredPrompt.prompt();
//        // Follow what the user has done with the prompt.
//        deferredPrompt.userChoice.then(function (choiceResult) {
//            console.log(choiceResult.outcome);
//            if (choiceResult.outcome == 'dismissed') {
//                console.log('User cancelled home screen install');
//            } else { console.log('User added to home screen'); }
//            // We no longer need the prompt. Clear it up.
//            deferredPrompt = null;
//        });
//    }
//});


/*SignalR*/
$(document).ready(function () {

    var name = document.getElementById('Yakala').textContent;
    $("#titleName").html("Hoş geldiniz - " + name);
    var hub = $.connection.hub;
    var chat = $.connection.chatHub;
    $.connection.hub.start();

    chat.client.getMessageOther = function (name, message) {
        var d = new Date();
        var dt = d.getTime();
        console.log('Mesaj Geldi');
        $("#chatList").append("<li style='width:100%;'><div class='msj-rta chatmacro'><div class='chattext' style='float: right; padding-left: 10px;'><a href=''>" + name + "</a ><h5>" + message + "</h5 ><small style='color:black'>" + dt + "</small></div><div style='padding:0px 0px 0px 10px; display: flex; justify-content: center; align-items: center; width: 25%; float: left; height:75px; padding-right: 10px;'><img class='rounded-circle' style='width:75px; height:75px' src='/Content/images/tux.jpg' alt='x'></div></div></li>");
    };

    chat.client.getMessageCaller = function (message) {
        var d = new Date();
        var dt = d.getTime();
        console.log('Mesaj Gitti');
        $("#chatList").append("<li style='width:100%'><div class='msj chatmacro'><div><img class='rounded-circle' style='width:75px; height:75px' src='/Content/images/m1.PNG' alt='x'></div><div class='chattext' style='float: left; padding-left: 10px;'><a href='' style='color:black'>Siz</a><h5>" + message + "</h5><small style='color:black'>" + dt + "</small></div></div></li>");
    };

    $("#btnSend").click(function () {
        console.log('Buton Çalıştı');
        var message = $("#txtMessage").val();
        chat.server.sendMessage(name, message);
    });
});
/*SignalR*/


//This is the service worker with the combined offline experience (Offline page + Offline copy of pages)
//Add this below content to your HTML page, or add the js file to your page at the very top to register sercie worker
if (navigator.serviceWorker.controller) {
    console.log('Onbellek Tamam')
} else {
    //Register the ServiceWorker
    navigator.serviceWorker.register('Pwabuilder-sw.js', {
        scope: './'
    }).then(function (reg) {
        console.log('Servis sunun icin kaydedildi ' + reg.scope);
    });
}

$(function () {
    $("#tblHata").DataTable(
        {
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        }
    );
});
$(function () {
    $("#tblDepartmanlar").DataTable(
        {
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        }
    );
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinize emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");
                //alert(id)
                $.ajax({
                    type: "GET",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                        //console.log("Silme işlemi başarılı.")
                    }
                });
            }
        })
        //if (confirm("Departmanı silmek istediğinize emin misiniz?")) {
        //}
    });
});
$(function () {
    $("#tblPersonel").DataTable(
        {
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        }
    );
    $("#tblPersonel").on("click", ".btnPersonelSil", function () {
        var btn = $(this);
        bootbox.confirm("Personeli silmek istediğinize emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Personel/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                        console.log("Silme işlemi başarılı.")
                    }
                });
            }
        })
    });
});