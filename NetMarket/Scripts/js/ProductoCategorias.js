var idc=getParameterByName('idc');
var datos3 = { idCategoria: idc};
var _datosProductoCategoria;
//url: "/Producto/ListarProductosCategoria",
$.ajax({
    url: "http://localhost/ApiNet/api/producto/verproductos",
    cache: false,
    data: JSON.stringify(datos3),
    type: "POST",
    contentType: 'application/json; charset=utf-8',
    dataType: 'json'
}).done(function (respuestaMVC) {
    console.log(respuestaMVC.Mensaje);
    if (respuestaMVC.Codigo == 0) {
        _datosProductoCategoria = respuestaMVC.Data;
        console.log(_datosProductoCategoria);
        mostrarDatosCategorias();
    } else {
        MostrarMensaje(respuestaMVC.Mensaje);
    }
});
function mostrarDatosCategorias() { 
    $.each(_datosProductoCategoria, function (index, elemento) {
        var columna = $("#prods").prepend(" <div class='col-sm-12 col-md-6 col-lg-4 p-b-50'>"+
                        "<div class='block2'>"+
                            "<div class='block2-img wrap-pic-w of-hidden pos-relative block2-labelnew'>"+
                                "<img src='../images/"+elemento.rutaimagen+"' alt='IMG-PRODUCT'>"+
                                "<div class='block2-overlay trans-0-4'>"+
                                    "<a href='"+"#"+"' class='block2-btn-addwishlist hov-pointer trans-0-4'>"+
                                        "<i class='icon-wishlist icon_heart_alt' aria-hidden='true'></i>"+
                                        "<i class='icon-wishlist icon_heart dis-none' aria-hidden='true'></i>"+
                                    "</a>"+
                                    "<div class='block2-btn-addcart w-size1 trans-0-4'>"+
                                        "<button class='flex-c-m size1 bg4 bo-rad-23 hov1 s-text1 trans-0-4'>"+
                                            "Add al Carrito"+
                                        "</button>"+
                                    "</div>"+
                                "</div>"+
                            "</div>"+
                            "<div class='block2-txt p-t-20'>"+
                                "<a href='product-detail.html' class='block2-name dis-block s-text3 p-b-5'>"+
                                    ""+elemento.nombre+" "+elemento.descripcion+
                                "</a>"+
                                "<span class='block2-price m-text6 p-r-5'>"+
                                    "$75.00"+
                                "</span>"+
                            "</div>"+
                        "</div>"+
                    "</div>");
    });
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}