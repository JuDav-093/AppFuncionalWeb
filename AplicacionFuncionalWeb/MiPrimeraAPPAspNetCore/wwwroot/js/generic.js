function get(idControl)
{
    return document.getElementById(idControl).value;
}
function set(idControl,valor)
{
     return document.getElementById(idControl).value = valor;
}


async function fetchGet(url, tipoRespuesta, callback) {
    try {
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + url;
        let res = await fetch(urlCompleta)

        if (tipoRespuesta == "json")
            res = await res.json();
        else if (tipoRespuesta == "text")
            res = await res.text();

        callback(res)

    } catch (e) {
        alert("ERROR! Ocurre un problema.");
    }
}

//recibiremos como parametro el formulario
async function fetchPost(url, tipoRespuesta, frm, callback)
{
    try
    {
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + url;
        let res = await fetch(urlCompleta,
            {
                method: "POST",
                body: frm

            });
        if (tipoRespuesta == "json")
            res = await res.json();
        else if (tipoRespuesta == "text")
            res = await res.text();

        callback(res)
    } catch (e) {
        alert("Ocurrio un problema en el POST")
    }
}
let objConfiguracionGlobal;

//{url: "", cabeceras:[], propiedades:[]}
function pintar(objConfiguracion) {
    objConfiguracionGlobal = objConfiguracion;


    if (objConfiguracionGlobal.divContendeorTabla == undefined)
    {
        objConfiguracionGlobal.divContendeorTabla = "divContenedorTabla";
    }
    fetchGet(objConfiguracion.url, "json", function (res) {

        let contenido = "";

        contenido += "<div id='divContenedorTabla'>";

        contenido += generarTabla(res);

        contenido += "</div>";

        document.getElementById("divTabla").innerHTML = contenido;
    })
}

function generarTabla(res) {
    let contenido = "";

    //["Id tipo Medicamento", "Nombre", "Descripcion", "Stock"]
    let cabeceras = objConfiguracionGlobal.cabeceras;
    let propiedades = objConfiguracionGlobal.propiedades;

    contenido += "<table class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";

    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<th>" + cabeceras[i] + "</th>";
    }
    contenido += "</tr>";
    contenido += "</thead>";

    let nroRegistros = res.length;
    let obj;
    let propiedadActual;

    contenido += "<tbody>";

    for (let i = 0; i < nroRegistros; i++) {
        obj = res[i];
        contenido += "<tr>";
        for (let j = 0; j < propiedades.length; j++) {
            propiedadActual = propiedades[j];
            contenido += "<td>" + obj[propiedadActual] + "</td>";
        }
        contenido += "</tr>";
    }

    contenido += "</tbody>";
    contenido += "</table>";

    return contenido;
}

function LimpiarDatos() {
    let elementoName = document.querySelectorAll('#' + idFormulario + "[name]");
    console.log(elementoName);
}