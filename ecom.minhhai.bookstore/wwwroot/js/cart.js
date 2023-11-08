$(document).ready(function () {
    $(function () {
        $(".btn-cart").click(function () {
            var productId = $(this).data('product-id');
            var quantity = $(this).data('quantity');
            $.ajax({
                url: '/api/cart/add',
                type: "POST",
                data: {
                    productId: productId,
                    quantity: quantity
                },
                success: function (response) {
                    loadHeaderCart();
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });

    function loadHeaderCart() {
        $("#numberCart").load("AjaxContent/NumberCart");
    }
});