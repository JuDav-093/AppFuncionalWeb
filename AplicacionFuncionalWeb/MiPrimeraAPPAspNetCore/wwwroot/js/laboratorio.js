window.onload = function () {
    listarLaboratorios();
    document.getElementById("btnLimpiar").addEventListener("click", LimpiarLaboratorio);
}

let objLaboratorio;
async function listarLaboratorios() {

    objLaboratorio = {
        url: "Laboratorio/ListarLaboratorios",
        cabeceras: ["Id Laboratorio", "Nombre", "Direccion", "Persona a Cargo"],
        propiedades: ["iddlaboratorio", "nombre", "direccion","personacontacto"],
        divContenedorTabla : "divContenedorTabla"
    }
   

    pintar(objLaboratorio);
}

function BuscarLaboratorio()
{
    let forma = document.getElementById("frmBusqueda");
    //Constructor que nos trae toda la informacion 
    let frm = new FormData(forma);

    fetchPost("Laboratorio/filtrarLaboratorios", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    });
}

function LimpiarLaboratorio() {
    listarLaboratorios();
    document.getElementById(listarLaboratorios).value = "";
}

