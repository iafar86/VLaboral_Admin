vLaboralApp.factory('ofertaDataFactory', function ($resource) {
    return $resource('api/Ofertas/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});