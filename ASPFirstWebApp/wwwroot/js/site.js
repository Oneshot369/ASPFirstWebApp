$(function () {
    console.log("Document ready");
    $(document).on("click", ".edit-product-button", function () {
        console.log("you clicked button number " + $(this).val());
        var productID = $(this).val();
        $.ajax({
            type: 'json',
            data: {
                "id": productID
            },
            url: "/products/ShowOneJSON",
            success: function (data) {
                console.log(data);

                $("#model-input-id").val(data.id);
                $("#model-input-name").val(data.name);
                $("#model-input-price").val(data.price);
                $("#model-input-description").val(data.description);
            }
        })
    })
    $("#save-button").click(function () {
        //get the val of the input and make it JSON
        var p = {
            "Id": $("#model-input-id").val(),
            "Name": $("#model-input-name").val(),
            "Price": $("#model-input-price").val(),
            "Description": $("#model-input-description").val()
        }
        console.log("saved: ")
        console.log(p)
        $.ajax({
            type: 'json',
            data: p,
            url: "/products/ProcessEditReturnPartial",
            success: function (data) {
                console.log(data);

                $("#card-number-" + p.Id).html(data).hide().fadeIn(2000);
            }
        })
    })
})