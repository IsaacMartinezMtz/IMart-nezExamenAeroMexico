$(document).ready(function () { //click
    GetAll();
    GetAllUsuario();
    GetAllVuelos();

    
});
function showModal() {
    $('#modal').modal("show");
}

function modalClose() {
    $('#modal').modal("hide");
}
function GetAll() {
    $.ajax({
        url: 'http://localhost:27441/api/Reservaciones/Reservaciones',
        type: 'Get',
        success: function (result) {
            console.log(result)
            $('#tablaReservado tbody').empty();
            $.each(result.Objects, function (i, reservado) {
                var filas =
                    '<tr>'                    
                    + "<td  id='id' class='text-center'>" + reservado.Usuario.Nombre + "</td>"
                    + "<td class='text-center'>" + reservado.Usuario.ApelliodPaterno + "</td>"
                    + "<td class='text-center'>" + reservado.Vuelos.NumeroVuelo + "</ td>"
                    + "<td class='text-center'>" + reservado.Vuelos.Origen + "</ td>"
                    + "<td class='text-center'>" + reservado.Vuelos.Destino + "</td>"
                    + "<td class='text-center'>" + reservado.Vuelos.FechaSalida + "</td>"
                    + "</tr>";
                $("#tablaReservado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage); //es un error de JSON, y es porque puede venir vacio o null
        }
    });
};


function GetAllUsuario() {
    $.ajax({

        url: 'http://localhost:27441/api/Usuarios/Usuarios',
        type: 'GET',
        success: function (result) {
            console.log(result)
            $.each(result.Objects, function (i, usuario) {
                var filas =
                    '<option value="' + usuario.IdUsuario + '">' + usuario.Nombre + '</option>';
                $("#ddlUsuario").append(filas);
            });
        },
        error: function (result) {
            alert('Error .' + result.responseJSON.ErrorMessage);
        }
    });
}
function GetAllVuelos() {
    $.ajax({

        url: 'http://localhost:27441/api/vuelo/ListaVuelos',
        type: 'GET',
        success: function (result) {
            console.log(result)
            $.each(result.Objects, function (i, vuelos) {
                var filas =
                    '<option value="' + vuelos.IdVuelos + '">' + vuelos.Destino + '</option>';
                $("#ddlDestino").append(filas);
            });
        },
        error: function (result) {
            alert('Error .' + result.responseJSON.ErrorMessage);
        }
    });
}

function Add() {


    var json = {
        Usuario: {
            "IdUsuario": Math.floor($('#ddlUsuario').val())
        },
        Vuelos: {
            "IdVuelos": Math.floor($('#ddlDestino').val())
        }
    }
    $.ajax({

        url: 'http://localhost:27441/api/Reservaciones',
        type: 'POST',
        datatype: 'JSON',
        data: json,
        success: function (result) {
            alert("Vuelo Reservado");
            modalClose();
            limpiarModal();
            GetAll();
        },
        error: function (result) {
            console.log(result);
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage); //es un error de JSON, y es porque puede venir vacio o null
        }
    });

}
function limpiarModal() {
    $('#ddlUsuario option[value="0"]').attr("selected", true);
    $('#ddlDestino option[value="0"]').attr("selected", true);
}
//$("#ddlDestino").change(function () {
//    var json = {
//        "destino": Math.floor($('#ddlDestino').val())
        
//    }
//    $("ddlFecha").empty();
//    $.ajax({
//        url: 'http://localhost:18934/Usuario/GetByIdPais/' + json.destino,
//        type: "GET",
       
//        success: function (result) {
//            console.log(result)
//            $.each(result.Objects, function (i, vuelos) {
//                var filas =
//                    '<option value="' + vuelos.IdVuelos + '">' + vuelos. + '</option>';
//                $("#ddlDestino").append(filas);
//            });
//        },
//        error: function (result) {
//            alert('Error .' + result.responseJSON.ErrorMessage);
//        }
//    });
//});
