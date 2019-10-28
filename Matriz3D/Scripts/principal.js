function msg() {
    var tipo = $("#tipo").val();
    var msg = $("#msg").val();
    $("#tipo").val(0);

    if (tipo == 1) {
        swal({
            title: "Buen trabajo!",
            text: msg,
            type: "success",
            confirmButtonClass: "btn-success",
            confirmButtonText: "Aceptar"

        });
    } else if (tipo == 2) {
        swal({
            title: "Atención!",
            text: msg,
            type: "warning",
            confirmButtonClass: "btn-warning",
            confirmButtonText: "Aceptar"
        });
    } else if (tipo == 3) {
        swal({
            title: "Error!",
            text: msg,
            type: "error",
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar"
        });
    } else if (tipo == 4) {
        var titulo = $("#titulo").val();
        var icono = $("#icono").val();
        swal({
            title: titulo,
            text: msg,
            type: icono,
            confirmButtonClass: "btn-" + icono,
            confirmButtonText: "Aceptar"
        });
    }
}