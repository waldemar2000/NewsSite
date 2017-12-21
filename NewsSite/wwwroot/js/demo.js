
$("#seedUsers button").click(function () {

    $.ajax({
        url: '/api/Seed/',
        method: 'GET',
        data: {

        }

    })
        .done(function (result) {

            alert(`Success`)
            console.log("Success!", result)

        })

        .fail(function (xhr, status, error) {

            alert("fail");
            console.log("Error", xhr, status, error);

        })

});


$("#signIn button").click(function () {

    $.ajax({
        url: '/check/login/',
        method: 'GET',
        data: {
            "EmailForm": $("#signIn [name=EmailForm]").val()
        }

    })
        .done(function (result) {
            alert("Inloggning lyckades, du är inloggad som: " + result.userName);
            $('#signedInAs').html("<p>Inloggad som: "+result.userName+"</p>");
            console.log("Success!", result)

        })

        .fail(function (xhr, status, error) {

            alert("fail");
            console.log("Error", xhr, status, error);

        })

});

$("#openNews button").click(function () {

    $.ajax({
        url: '/check/view/OpenNews/',
        method: 'GET',
        data: {
      
        }

    })
        .done(function () {
            alert("Denna användaren kan se Open News");
            console.log("Success!")

        })

        .fail(function (xhr, status, error) {

            alert("Denna användaren kan Inte se Open News");
            console.log("Error", xhr, status, error);

        })

});
$("#hiddenNews button").click(function () {

    $.ajax({
        url: '/check/view/hiddenNews/',
        method: 'GET',
        data: {

        }

    })
        .done(function () {
            alert("Denna användaren kan se Hidden News");
            console.log("Success!")

        })

        .fail(function (xhr, status, error) {

            alert("Denna användaren kan INTE se Hidden News");
            console.log("Error", xhr, status, error);

        })

});

$("#adultNews button").click(function () {

    $.ajax({
        url: '/check/view/AdultNews/',
        method: 'GET',
        data: {

        }
        
    })
        .done(function () {
            alert("Denna användaren kan se Adult News");
            console.log("Success!")

        })

        .fail(function (xhr, status, error) {

            alert("Denna användaren kan INTE se Adult News");
            console.log("Error", xhr, status, error);

        })

});