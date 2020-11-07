let cart = $("#cart");
let totalPrice = $("#totalPrice");
const swalWithBootstrapButtons = Swal.mixin();
$(document).ready(function () {
    getCart();
    $(".product").click(function () {
        var productId = $(this).attr("data-productid");
        addToCart(productId);
        console.log(productId);
    });
});

const getCart = () => {
    $.ajax({
        url: "/Products/GetCart",
        type: "GET",
        cache: false,
        async: true,
        success: function (response) {
            if (response.Success === true) {
                fillCart(response.Data);
            } else {
                cart.empty();
                totalPrice.empty();
                cart.html(response.Message);
            }
        },
        error: function (error) {
            console.error(error);
        }
    });
}
const fillCart = (data) => {
    cart.empty();
    totalPrice.empty();
    for (var i = 0; i < data.Cart.length; i++) {
        var cartProductHtml = '<div class="row">' +
            '                        <div class="col-md-4">' + data.Cart[i].Name + '</div>' +
            '                        <div class="col-md-3"><input class="form-control cart-product-counter" data-productid="' + data.Cart[i].ProductId + '" type="number" min="0" value="' + data.Cart[i].Quantity + '"/></div>' +
            '                        <div class="col-md-3">' + data.Cart[i].ProductTotalPrice + ' <span>&#8378;</span></div>' +
            '                        <div class="col-md-1"><i class="fas fa-trash-alt cart-product-delete" data-productid="' + data.Cart[i].ProductId + '"></i></div>' +
            '                    </div></br>';
        cart.append(cartProductHtml);

        $(".product").each(function () {
            var productId = $(this).attr("data-productid");
            if (productId == data.Cart[i].ProductId && data.Cart[i].QuantityEqualsStock == true) {
                $(this).prop("disabled", true);
            }
        });
    }

    totalPrice.html("Toplam Fiyat : " + data.TotalPrice + ' <span>&#8378;</span>');

    cartProductCounterEvent();
    cartProductDeleteEvent();
}
const cartProductDeleteEvent = () => {
    $(".cart-product-delete").click(function () {
        var productId = $(this).attr("data-productid");
        deleteFromCart(productId);
    });
}
const deleteFromCart = (productId) => {
    $.ajax({
        url: "/Products/DeleteFromCart/" + productId,
        type: "POST",
        success: function (response) {
            console.log(response);
            if (response.Success === true) {
                customFireAlert("success", "Başarılı", response.Message, 2000);
                getCart();
            } else {
                customFireAlert("warning", "Başarısız", response.Message, 2000);
            }
        },
        error: function (error) {
            console.error(error);
        }
    });
}
const cartProductCounterEvent = () => {
    $(".cart-product-counter").change(function () {
        var productId = $(this).attr("data-productid");
        var quantity = $(this).val();
        updateProductQuantity(productId, quantity);
    });
}
const updateProductQuantity = (productId, quantity) => {
    $.ajax({
        url: "/Products/UpdateCart",
        type: "POST",
        cache: false,
        async: true,
        data: {
            ProductId: parseInt(productId),
            Quantity: parseInt(quantity)
        },
        success: function (response) {
            getCart();
            if (response.Success === true) {

            } else {
                customFireAlert("warning", "Başarısız", response.Message, 2000);
            }
        },
        error: function (error) {
            console.error(error);
        }
    });
}
const addToCart = (productId) => {
    $.ajax({
        url: "/Products/AddToCart/" + productId,
        type: "POST",
        cache: false,
        async: true,
        success: function (response) {
            console.log(response);
            if (response.Success === true) {
                customFireAlert("success", "Başarılı", response.Message, 2000);
                getCart();
            } else {
                customFireAlert("warning", "Başarısız", response.Message, 2000);
            }
        },
        error: function (error) {
            console.error(error);
        }
    });
}


function customFireAlert(type, title, text, timer) {
    swalWithBootstrapButtons.fire({
        position: "top-end",
        icon: type,
        title: title,
        text: text,
        showConfirmButton: false,
        timer: timer
    });
}