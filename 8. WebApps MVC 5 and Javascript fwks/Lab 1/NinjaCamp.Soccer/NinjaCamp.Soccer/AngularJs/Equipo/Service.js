app.service("equiposervice", function ($http) {
    //GetAll
    this.GetEquipos = function () {
        return $http.get("Equipo/GetEquipos");
    };
    //GetEquipo
    this.GetEquipo = function (Id) {
        var response = $http({
            method: "post",
            url: "Equipo/GetEquipo",
            params: {
                Id: JSON.stringify(Id)
            }
        });
        return response;
    }
    //UpdateEquipo
    this.UpdateEquipo = function (Equipo) {
        var response = $http({
            method: "post",
            url: "Equipo/UpdateEquipo",
            data: JSON.stringify(Equipo),
            dataType: "json"
        });
        return response;
    }
    //AddEquipo
    this.AddEquipo = function (Equipo) {
        var response = $http({
            method: "post",
            url: "Equipo/AddEquipo",
            data: JSON.stringify(Equipo),
            dataType: "json"
        });
        return response;
    }

    //DeleteEquipo
    this.DeleteEquipo = function (Id) {
        var response = $http({
            method: "post",
            url: "Equipo/DeleteEquipo",
            params: {
                Id: JSON.stringify(Id)
            }
        });
        return response;
    }
});