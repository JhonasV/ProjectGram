const activitieUserInput = $('#actividad_user');
const body = $('body');
const activitieDiv = $('#actividad');

/*Cargar actividades en Actividad*/
const loadActividad = () => {
    let id = activitieUserInput.val();
    if (id) {
        body.loadingModal({ text: 'Cargando...', animation: 'wanderingCubes' });
        activitieDiv.load(`/Home/ActividadPartial`);
    }
};
window.onload = loadActividad();
/*Termina*/

const connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Debug)
    .withUrl("/Infraestructure/SignalRServer", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();
//const connection = new signalR.HubConnection("/signalServer")
//    .configureLogging(signalR.LogLevel.Debug)
//    .build();
connection.on("loadActivities", (data) => {
    loadActividad();
});


connection.start().then(() => console.log('connected')).catch(err => console.log(err.toString()));