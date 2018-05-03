var datos3 = {};
var _datosCategoria;
$.ajax({
    url: "/Home/ListarCategorias",
    cache: false,
data: JSON.stringify(datos3),
type: "POST",
contentType: 'application/json; charset=utf-8',
dataType: 'json'
}).done(function (respuestaMVC) {
    console.log(respuestaMVC.Mensaje);
    if (respuestaMVC.Codigo == 0) {
        _datosCategoria = respuestaMVC.Data;
        console.log(_datosCategoria);
        mostrarDatosCategorias();
    } else {
        MostrarMensaje(respuestaMVC.Mensaje);
    }
});
function mostrarDatosCategorias() {
    var contador = 0;
    $.each(_datosCategoria, function (index, elemento) {
        contador = contador + 1;
        
        var columna = $("#colm" + contador).prepend("<div class='" + "block1 hov-img-zoom pos-relative m-b-30" + "'><img src='" + "../images/" + elemento.rutaimagen + "' alt='" + "IMG-BENNER" + "'><div class='" + "block1-wrapbtn w-size2" + "'><a href='" + "Producto/ProductosCategoria?idc=" + elemento.idCategoria + "' class='" + "flex-c-m size2 m-text2 bg3 hov1 trans-0-4 linkcate" + "'>" + elemento.nombre + "</a></div></div>");
        if (contador == 3) {
            contador = 0;
        }
    });
}