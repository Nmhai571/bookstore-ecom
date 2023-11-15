$(document).ready(function () {
    $(function () {
        $(".btn-wishlist").click(function () {
            var productId = $(this).data('product-id');
            $.ajax({
                url: '/api/wish-list/add',
                type: "POST",
                data: {
                    productId: productId,
                },
                success: function (response) {
                    loadHeaderFavorite();
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });

    function loadHeaderFavorite() {
        $("#NumberFavorite").load("AjaxContent/NumberFavorites");
    }
});