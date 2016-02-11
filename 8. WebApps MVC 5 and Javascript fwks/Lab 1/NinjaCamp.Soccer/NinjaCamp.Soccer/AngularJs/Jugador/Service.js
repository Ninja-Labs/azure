app.service("jugadorservice", function ($http) {
    //GetAll
    this.GetJugadores = function () {
        return $http.get("Jugador/GetJugadores");
    };
    //GetJugador
    this.GetJugador = function (Id) {
        var response = $http({
            method: "post",
            url: "Jugador/GetJugador",
            params: {
                Id: JSON.stringify(Id)
            }
        });
        return response;
    }
    //UpdateJugador
    this.UpdateJugador = function (Jugador) {
        var response = $http({
            method: "post",
            url: "Jugador/UpdateJugador",
            data: JSON.stringify(Jugador),
            dataType: "json"
        });
        return response;
    }
    //AddJugador
    this.AddJugador = function (Jugador) {
        var response = $http({
            method: "post",
            url: "Jugador/AddJugador",
            data: JSON.stringify(Jugador),
            dataType: "json"
        });
        return response;
    }

    //DeleteJugador
    this.DeleteJugador = function (Id) {
        var response = $http({
            method: "post",
            url: "Jugador/DeleteJugador",
            params: {
                Id: JSON.stringify(Id)
            }
        });
        return response;
    }
});