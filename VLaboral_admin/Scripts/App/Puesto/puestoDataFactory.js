vLaboralApp.factory('puestoDataFactory', function ($resource) {
    return $resource('api/Puestos/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});