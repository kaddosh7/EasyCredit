var montoSolicitado = document.getElementById("montoSolicitado");
var cantidadCuotas = document.getElementById("cantidadCuotas");
var cuotaMensual = document.getElementById("cuotaMensual");
var interesMensual = document.getElementById("interesMensual");

cantidadCuotas.addEventListener("keyup", CalcularCuotas, true);

function CalcularCuotas() {
    cuotaMensual.value = montoSolicitado.value / cantidadCuotas.value;
}









// RESUMEN FINANCIACION
//var resumenCuotaMensual = document.getElementById("resuenCuotaMensual");
//var resumenNumCuotas = document.getElementById("resumenNumCuotas");

//var resumenInteresPagar = document.getElementById("resumenInteresPagar");
//var resumenMontoSolicitado = document.getElementById("resumenMontoSolicitado");
//var cuotasConIntereses = document.getElementById("cuotasConIntereses");

//cantidadCuotas.addEventListener("keyup", MontoCuotaMensual, true)
//function MontoCuotaMensual() {
//    var amountRequired = parseFloat(montoSolicitado.value) / parseFloat(cantidadCuotas.value);
//    resumenCuotaMensual.innerHTML = new Intl.NumberFormat('es-MX').format(amountRequired);
//    resumenNumCuotas.innerHTML = cantidadCuotas.value;
//}

//interesMensual.addEventListener("keyup", MontoInteresTotal, true)
//function MontoInteresTotal() {
//    var saldoInicial = ((parseFloat(montoSolicitado.value) * (parseFloat(interesMensual.value)) / 100)) * cantidadCuotas.value;
//    var montoSolicitud = montoSolicitado.value;
//    var result3 = (((parseFloat(montoSolicitado.value) * parseFloat(interesMensual.value)) / 100) * cantidadCuotas.value);
//    var montoPaga = montoSolicitado.value * (interesMensual.value / (1 - Math.pow(1 + interesMensual.value, -cuotaMensual)));

//    resumenInteresPagar.innerHTML = new Intl.NumberFormat('es-MX').format(saldoInicial);
//    resumenMontoSolicitado.innerHTML = new Intl.NumberFormat('es-MX').format(montoSolicitud);
//    cuotasConIntereses.innerHTML = new Intl.NumberFormat('es-MX').format(result3);
//}


////var btn_amortizar = getElementById("btn_amortizar");
//btn_amortizar.addEventListener("click", generarAmortizacion);

//function generarAmortizacion() {

//    var capital = document.getElementById("montoSolicitado");
//    var interes = document.getElementById("cuotasConIntereses");
//    var plazo = document.getElementById("cuotasConIntereses");
//    var amortizacion_prestamo = document.getElementById("amortizacion_prestamo");

//    var cuota = capital * (interes / Math.pow(1 + interes, plazo));

//    var interes_mensual = 0;
//    var amortizacion_ini = 0;
//    var amortizacion_fin = 0;
//    var i = 0;

//    for (i = 0; i <= plazo; i++) {
//        interes_mensual = Math.round((parseFloat(interes) * parseFloat(capital)), 2);
//        capital = Math.round(parseFloat(capital) - parseFloat(cuota) + parseFloat(interes_mensual), 2);

//        //Amortizaciones Totales y Principales
//        amortizacion_fin += Math.round(parseFloat(cuota) - parseFloat(interes_mensual), 2);
//        amortizacion_ini = parseFloat(cuota) - parseFloat(interes_mensual);

//        var output = "<td>" + Math.round(parseFloat(cuota)) + "</td>" +
//            "<td>" + Math.round(parseFloat(plazo)) + "</td>" +
//            "<td>" + Math.round(parseFloat(interes_mensual)) + "</td>" +
//            "<td>" + Math.round(parseFloat(amortizacion_ini)) + "</td>" +
//            "<td>" + Math.round(parseFloat(amortizacion_fin)) + "</td>" +
//            "<td>" + Math.round(parseFloat(capital)) + "</td>";
//        amortizacion_prestamo.innerHTML = output;
//    }
//}

