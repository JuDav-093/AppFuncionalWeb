window.onload = function () {
    listarSucursal();
    document.getElementById("btnLimpiar").addEventListener("click", LimpiarSucursal);

}

let objSucursal;
async function listarSucursal() {
    
    objSucursal = {
        url: "Sucursal/ListarSucursal",
        cabeceras: ["Id Sucursal", "Nombre", "Direccion"],
        propiedades: ["idSucursal", "nombre", "direccion"]
        
    }

    pintar(objSucursal);
}

function BuscarSucursal() {
    let forma = document.getElementById("frmBusqueda");
    //Constructor que nos trae toda la informacion 
    let frm = new FormData(forma);

    fetchPost("Sucursal/filtrarSucursal", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    });
}

//function Buscar() {
//    let nombreSucursal = document.getElementById("txtNombreSucursal").value;
//    objSucursal.url = "Sucursal/FiltrarSucursal/?nombre=" + nombreSucursal,

//     pintar(objSucursal);
//}

function LimpiarSucursal() {
    listarSucursal();
    document.getElementById(listarSucursal).value = "";
}