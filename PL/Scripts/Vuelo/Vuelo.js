function limpiar() {
    $('#txtFechaInicio').val('');
    $('#txtFechaFin').val('');
}


function Busqueda() {  

    var vuelo = {
        FechaInicio: $('#txtFechaInicio').val(),
        FechaFin: $('#txtFechaFin').val()
    }
$.ajax({
    type: 'GET',
     url: 'http://localhost:27441/api/vuelo/busqueda/'+ vuelo.FechaInicio + '/' + vuelo.FechaFin,
    /*url:'http://localhost:27441/api/vuelo/busqueda/2018-05-28/2018-06-05',*/
    success: function (result) {
        console.log(result)
        limpiar()
       
        $('#tablaVuelo tbody').empty();

        $.each(result.Objects, function (i, vuelos) {
            var filas =
            '<tr>'
                + "<td  id='id' class='text-center'>" + vuelos.NumeroVuelo + "</td>"
                + "<td class='text-center'>" + vuelos.Origen + "</td>"
                + "<td class='text-center'>" + vuelos.Destino + "</ td>"
                + "<td class='text-center'>" + vuelos.FechaSalida + "</ td>"
                + "</tr>";
            $("#tablaVuelo tbody").append(filas);

        });
    },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage); //es un error de JSON, y es porque puede venir vacio o null
        }
   });
};