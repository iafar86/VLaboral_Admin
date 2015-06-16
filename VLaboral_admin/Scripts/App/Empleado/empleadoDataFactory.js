vLaboralApp.factory('empleadoDataFactory', function ($resource) {
    return $resource('api/Empleados/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});