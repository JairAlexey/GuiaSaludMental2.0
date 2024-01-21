window.onload = function () {
    mostrarVentanaEmergente();
};

function mostrarVentanaEmergente() {
    var ventanaEmergente = document.createElement('div');
    ventanaEmergente.innerHTML = `
                    <button onclick="cerrarVentanaEmergente()">Cerrar</button>
                    <iframe id="videoFrame" width="560" height="315" src="https://www.youtube.com/embed/0Ai8_SR8Ncw" frameborder="0" allowfullscreen></iframe>
                `;

    ventanaEmergente.style.position = 'fixed';
    ventanaEmergente.style.top = '50%';
    ventanaEmergente.style.left = '50%';
    ventanaEmergente.style.transform = 'translate(-50%, -50%)';
    ventanaEmergente.style.backgroundColor = 'white';
    ventanaEmergente.style.padding = '20px';
    ventanaEmergente.style.border = '2px solid #333';

    document.body.appendChild(ventanaEmergente);
}

function cerrarVentanaEmergente() {
    var ventanaEmergente = document.getElementById('videoFrame');
    if (ventanaEmergente) {
        document.body.removeChild(ventanaEmergente.parentElement);
    }
}