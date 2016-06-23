$('#addQuote').click(function () {
    console.log("yes")
    var quantity = $('#newProductQuantity').val()
    var name = $('#productList :selected').text().split(" ")[0]
    var price = $('#productList :selected').text().split(" ")[1]
    var id = $('#productList :selected').val()
    var total = $('#total').html();
    console.log(total);
    total = parseFloat(total.replace(",", ".")) + parseFloat(price.replace(",", ".") * quantity);
    console.log(total);
    $('#total').html(total);
    console.log(name) //the text content of the selected option
    console.log(price)
    console.log(id)
    $('#selectedProducts tr:last').after('<tr><td style="display:none">' + id + '</td><td>' + name + '</td><td>' + price + '</td><td>x' + quantity + '</td><td><a href="#" class="removeProduct">Remove</a></td></tr>');
});

//when customer changes
$("#CustomerId").change(function () {
    var user = $('#CustomerId :selected').text();
    var country = user.split(" ")[2];
    var token
    //Ajax call to API for tax
    var body = {
        "grant_type": "password",
        "username": "developer",
        "password": "ineedcevapi"
    }
    console.log(JSON.stringify(body))
    $.ajax({
        url: 'https://cevapi2.azurewebsites.net/token',
        type: 'POST',
        dataType: "json",
        data: {'grant_type':'password','username':'developer','password':'ineedcevapi'},
        contentType: "application/x-www-form-urlencoded; ; charset=utf-8",
        crossDomain: true,
        success: function (data) {
            token = data.access_token.trim();
            var auth = "bearer ".concat(token.toString());
            console.log(auth)
            $.ajax({
                url: 'https://cevapi2.azurewebsites.net/countries?name='+country+'&showAll=true',
                dataType: "json",
                beforeSend: function (request) {
                    request.setRequestHeader("Authorization", auth);
                },
                type: 'GET',
                success: function (data) {
                    console.log(data)
                },
                error: function () {
                    //alert("error");
                }

            });
        },
        error: function () {
            alert("error");
        }

    });

    
});

$('#selectedProducts').on('click', 'tr a.removeProduct', function (e) {
    e.preventDefault();
    var total = $('#total').html();
    var price = $(this).closest('tr').children().eq(2).html()
    var quantity = $(this).closest('tr').children().eq(3).html().replace("x", "")
    total = parseFloat(total.replace(",", ".")) - parseFloat(price.replace(",", ".") * parseInt(quantity, 10));
    $('#total').html(total.toString());
    $(this).closest('tr').remove();
});

/*
$('#submitBtn').click(function (e) {
    e.preventDefault();
    console.log("sdasdda");
    var customerId = $('#CustomerId').val();
    console.log(customerId);
    // Loop through grabbing everything
    var products = [];
    var $headers = $("th");
    var $rows = $("#selectedProducts tbody tr").each(function (index) {
        $cells = $(this).find("td");
        products[index] = {};
        $cells.each(function (cellIndex) {
            products[index][$($headers[cellIndex]).html()] = $(this).html().trim();
        });
    });

    // Let's put this in the object like you want and convert to JSON (Note: jQuery will also do this for you on the Ajax request)
    var myObj = {};
    myObj.products = products;
    alert(JSON.stringify(myObj));

    $.ajax({
        url: '/Quotes/Create',
        type: 'POST',
        data: JSON.stringify({
            "prod": "yes"
      
        }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert(data);
        },
        error: function () {
            alert("error");
        }

    });
});
  */
