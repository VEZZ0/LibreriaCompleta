document.addEventListener('DOMContentLoaded', getDati(), createDato());
function getDati() {
    fetch("/api/Libro/GetScaffale").then(x => x.text()).then(y => { document.getElementById("contenitore").innerHTML = y });
}

function createDato() {
    fetch("/api/Libro").then(x => x.text()).then(y => { document.getElementById("contenitore").innerHTML = "\n" + y });
}