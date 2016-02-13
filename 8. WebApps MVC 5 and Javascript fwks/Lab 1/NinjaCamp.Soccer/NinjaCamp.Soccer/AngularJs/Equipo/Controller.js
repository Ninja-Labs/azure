app.controller("equipocontroller", function ($scope, equiposervice) {
    GetEquipos();
    $scope.showAddUpdate = false;
    function GetEquipos() {
        var getData = equiposervice.GetEquipos();
        getData.then(function (response) {
            ClearFields();
            $scope.Equipos = response.data;
        }, function () {
            alert('Error GetEquipos');
        });
    }
    $scope.editEquipo = function (Equipo) {
        var getData = equiposervice.GetEquipo(Equipo.Id);
        getData.then(function (response) {
            $scope.Equipo = response.data;
            $scope.Id = response.data.Id;
            $scope.Nombre = response.data.Nombre;
            $scope.Apodo = response.data.Apodo;
            $scope.Presidente = response.data.Presidente;
            $scope.Entrenador = response.data.Entrenador;
            $scope.Estadio = response.data.Estadio;
            $scope.Action = "Update";
            $scope.showAddUpdate = true;
        },
        function () {
            alert('Error in GetEquipo');
        });
    }

    //UpdateEquipo && AddEquipo
    $scope.AddUpdateEquipo = function () {

        var Equipo = {
            Nombre: $scope.Nombre,
            Apodo: $scope.Apodo,
            Presidente: $scope.Presidente,
            Entrenador: $scope.Entrenador,
            Estadio: $scope.Estadio
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Equipo.Id = $scope.Id;

            var getData = equiposervice.UpdateEquipo(Equipo);
            getData.then(function (msg) {
                GetEquipos();
                alert(msg.data);
            }, function () {
                alert('Error in UpdateEquipo');
            });
        } else {
            var getData = equiposervice.AddEquipo(Equipo);
            getData.then(function (msg) {
                GetEquipos();
                alert(msg.data);
            }, function () {
                alert('Error in AddEquipo');
            });
        }
    }

    $scope.AddEquipoDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.showAddUpdate = true;
    }
    $scope.CancelAddEquipoDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.showAddUpdate = false;
    }

    //DeleteEquipo
    $scope.deleteEquipo = function (Equipo) {
        var getData = equiposervice.DeleteEquipo(Equipo.Id);
        getData.then(function (msg) {
            GetEquipos();
            alert(msg.data);
        }, function () {
            alert('Error in DeleteEquipo');
        });
    }

    //ClearFields
    function ClearFields() {
        $scope.Id = "";
        $scope.Nombre = "";
        $scope.Apodo = "";
        $scope.Presidente = "";
        $scope.Entrenador = "";
        $scope.Estadio = "";
        $scope.showAddUpdate = false;
    }
});