﻿vLaboralApp.controller('empleadoCtrl', function ($scope, $stateParams, $state, $filter, ngTableParams, empleadoDataFactory, rubroDataFactory, puestoDataFactory
    , listadoEmpleados, infoEmpleado, listadoRubros, listadoPuestos) {
    
    //#region Rubro/SubRubro

    $scope.rubros = listadoRubros; //Carga todos los rubros y subrubros existentes
    $scope.rubrosList = [];
    $scope.rubroSelect = [];
    $scope.subRubroSelect = [];

    $scope.AddRubro = function () {
        rubroTemp = {
            rId: $scope.rubroSelect.Id,
            rNombre: $scope.rubroSelect.Nombre,
            srId: $scope.subRubroSelect.Id,
            srNombre: $scope.subRubroSelect.Nombre
        };
        $scope.rubrosList.push(rubroTemp);
    } //Agrega un nuevo rubro a la lista de Rubro/SubRubro del empleado

    $scope.RubroDel = function (item) {
        var index = $scope.rubrosList.indexOf(item);
        $scope.rubrosList.splice(index, 1);
    }//Elimino un Rubro/SubRubro de la lista
    //#endregion


    $scope.infoEmpleado = infoEmpleado;
    var infoActualEmpleado = infoEmpleado;
    $scope.empleados = listadoEmpleados;
    var data = $scope.empleados;

    $scope.infoCollapse = false; //var para hacer el collapse de la seccion info detallada de empleados detail
    $scope.addEmpleadoCollapse = true; //var para hacer el collapse de la seccion carga nueva Empleado de empleados_main
    $scope.listEmpleadosCollapse = false; //var para hacer el collapse de la seccion Listados de empleados de empleados_main

    //#region Alta de empleados
    //funcion para agregar una nueva Empleado y mostrarla en la tabla
    $scope.addEmpleado = function () {
        $scope.empleados = empleadoDataFactory.query();
        data = $scope.empleados;
    };

    
    $scope.empleadoAdd = function (empleado) {
        empleadoDataFactory.save(empleado).$promise.then(
            function () {
                $scope.addEmpleado();
                $scope.empleado = {};
                alert('Nuevo Empleado Guardado');
                $state.go('empleadoList');
            },
            function (response) {
                $scope.errors = response.data;
                alert('Error al guardar el Empleado');
            });
    };

    $scope.cancelEmpleadoAdd = function () {
        $scope.empleado = null;
    };
    //#endregion

    //#region Modificacion de empleados

    $scope.editValue = false; // variable que voya usarpara activar y desactivar los modos de edicion para hacer el update de la info de la Empleado

    $scope.edit = function () {// activa el modo de edicion de los campos        
        $scope.editValue = true;
    };

    $scope.save = function (infoEmpleado) {// guarda los cambios y llama a la funcion put de la api        
        empleadoDataFactory.update({ id: infoEmpleado.Id }, infoEmpleado).$promise.then(
                function () {
                    $scope.editValue = false;
                    alert("Modificacion de Datos Exitosa");
                },
                function (response) {
                    $scope.infoEmpleado = $scope.infoEmpleadoOriginal;
                    alert("Error en la Modificacion de Datos", response.data);
                });
    };

    $scope.cancel = function () {
        $scope.infoEmpleado = empleadoDataFactory.get({ id: infoEmpleado.Id })
        $scope.editValue = false;
    };

    //#endregion

    //#region Eliminacion de empleados
    $scope.delete = function (infoEmpleado) {
        empleadoDataFactory.delete(infoEmpleado).$promise.then(
            function () {
                alert("Eliminacion Exitosa");
                $state.go('empleados');
            },
            function (response) {
                alert("Eliminacion Fallida", response.data);
                //$scope.resultado = 'Error Eliminacion';
            });
    };
    //#endregion

    //#region Paginacion y llenado y filtrado de la tabla dinamica de empleados
    //$scope.tableParams = new ngTableParams({
    //    page: 1,            // show first page
    //    count: 10,          // count per page
    //    filter: {
    //        // filtros de la tabla, 
    //        CUE: '', //por numero de CUE       
    //        Nombre: ''// por nombre de Empleado
    //    }
    //}, {
    //    total: data.length, // saco el Total de registros del listado de empleados
    //    getData: function ($defer, params) {
    //        // use build-in angular filter
    //        var orderedData = params.filter() ?
    //               $filter('filter')(data, params.filter()) :
    //               data;

    //        //$defer.resolve(data.slice((params.page() - 1) * params.count(), params.page() * params.count()));
    //        $scope.empleados = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());

    //        params.total(orderedData.length); // set total for recalc pagination
    //        $defer.resolve($scope.empleados);
    //    }
    //});
    //#endregion

   


  


    //$scope.AddRubro = function () {
    //    $scope.Rubros.push("20");
    //    ($scope.CantRubro)++;
    //}

    //#Region Puestos
    $scope.puestos = listadoPuestos;
    $scope.puestoSelect = [];
    $scope.puestoList = [];

    $scope.puestoAdd = function () {
        puestoTemp = {
            pId: $scope.puestoSelect.Id,
            pNombre: $scope.puestoSelect.Nombre,
        };
        $scope.puestoList.push(puestoTemp);


    };

    $scope.puestoDel = function (item) {
        var index = $scope.puestoList.indexOf(item);
        $scope.puestoList.splice(index, 1);
    };


});