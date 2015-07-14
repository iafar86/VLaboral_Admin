vLaboralApp.factory('rubroDataFactory', function ($resource) {
    return $resource('api/Rubros/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});