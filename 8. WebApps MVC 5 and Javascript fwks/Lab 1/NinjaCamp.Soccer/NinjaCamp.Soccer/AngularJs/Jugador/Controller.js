app.controller("jugadorcontroller", function ($scope, jugadorservice) {
    GetJugadores();
    $scope.showAddUpdate = false;
    function GetJugadores() {
        var getData = jugadorservice.GetJugadores();
        getData.then(function (response) {
            ClearFields();
            $scope.Jugadors = response.data;
        }, function () {
            alert('Error GetJugadores');
        });
    }
    $scope.editJugador = function (Jugador) {
        var getData = jugadorservice.GetJugador(Jugador.Id);
        getData.then(function (response) {
            $scope.Jugador = response.data;
            $scope.Id = response.data.Id;
            $scope.Nombre = response.data.Nombre;
            $scope.Apodo = response.data.Apodo;
            $scope.Nacionalidad = response.data.Nacionalidad;
            $scope.Estatura = response.data.Estatura;
            $scope.Peso = response.data.Peso;
            $scope.Posicion = response.data.Posicion;
            $scope.IdEquipo = response.data.IdEquipo;
            $scope.Action = "Update";
            $scope.showAddUpdate = true;
        },
        function () {
            alert('Error in GetJugador');
        });
    }

    //UpdateJugador && AddJugador
    $scope.AddUpdateJugador = function () {

        var Jugador = {
            Nombre: $scope.Nombre,
            Apodo: $scope.Apodo,
            Nacionalidad: $scope.Nacionalidad,
            Estatura: $scope.Estatura,
            Peso: $scope.Peso,
            Posicion: $scope.Posicion,
            IdEquipo: $scope.IdEquipo,
        };

        var getAction = $scope.Action;

        if (getAction == "Update") {
            Jugador.Id = $scope.Id;

            var getData = jugadorservice.UpdateJugador(Jugador);
            getData.then(function (msg) {
                GetJugadores();
                alert(msg.data);
            }, function () {
                alert('Error in UpdateJugador');
            });
        } else {
            var getData = jugadorservice.AddJugador(Jugador);
            getData.then(function (msg) {
                GetJugadores();
                alert(msg.data);
            }, function () {
                alert('Error in AddJugador');
            });
        }
    }

    $scope.AddJugadorDiv = function () {
        $scope.templateUrl = 'PartialViews/Jugador/AddUpdate.html';
        ClearFields();
        $scope.Action = "Add";
        $scope.showAddUpdate = true;
    }
    $scope.CancelAddJugadorDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.showAddUpdate = false;
    }

    //DeleteJugador
    $scope.deleteJugador = function (Jugador) {
        var getData = jugadorservice.DeleteJugador(Jugador.Id);
        getData.then(function (msg) {
            GetJugadores();
            alert(msg.data);
        }, function () {
            alert('Error in DeleteJugador');
        });
    }

    //ClearFields
    function ClearFields() {
        $scope.Id = "";
        $scope.Nombre = "";
        $scope.Apodo = "";
        $scope.Nacionalidad = "";
        $scope.Estatura ="";
        $scope.Peso ="";
        $scope.Posicion = "";
        $scope.IdEquipo = "";
        $scope.showAddUpdate = false;
    }
});