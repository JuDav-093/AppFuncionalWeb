window.onload = function () {
    listarTipoMedicamento();

}

async function listarTipoMedicamento() {

    fetchGet("Medicamento/ListartipoMedicamento", "text", function (res) {
        alert(res);
    })

}