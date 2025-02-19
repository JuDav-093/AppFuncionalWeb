window.onload = function () {
    listarTipoMedicamento();
}
function filtrarTipoMedicamento() {
    let nombre = document.getElementById("txtNombreTipoMedicamento").value; 

    if (nombre === "") { 
        listarTipoMedicamento();
    } else { 
        objTipoMedicamento.url = "TipoMedicamento/FiltrartipoMedicamento/?nombre=" + nombre
        pintar(objTipoMedicamento);
    }
}


let objTipoMedicamento;

async function listarTipoMedicamento() {

    objTipoMedicamento = {
        url: "TipoMedicamento/ListartipoMedicamento",
        cabeceras: ["Id tipo Medicamento", "Nombre", "Descripcion"],
        propiedades: ["idTipoMedicamento", "nombre", "descripcion"]
    }

    pintar(objTipoMedicamento);
}


function Buscar() {
    //let nombreTipoMedicamento = document.getElementById("txtNombreTipoMedicamento").value;
    get("txtNombreTipoMedicamento");
    //objTipoMedicamento.url = "TipoMedicamento/FiltrartipoMedicamento/?nombre=" + nombreTipoMedicamento,
    //    pintar(objTipoMedicamento);
}

function Limpiar() {
    listarTipoMedicamento();
    set("txtNombreTipoMedicamento","");
    //document.getElementById("txtNombreTipoMedicamento").value = "";
}
