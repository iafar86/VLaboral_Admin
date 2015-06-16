vLaboralApp.factory('empleadorDataFactory', function ($resource) {
    return $resource('api/Empleadores/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});