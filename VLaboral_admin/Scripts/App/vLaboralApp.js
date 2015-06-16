var vLaboralApp = angular.module('vLaboralApp', ['ngRoute', 'ngResource', 'ui.router', 'ngCookies', 'ui.bootstrap', 'ngTable',
  'ngSanitize', 'ngAnimate', 'ui.select', 'ct.ui.router.extras','angular-loading-bar'])
    .config(function ($stateProvider, $urlRouterProvider, $httpProvider, $stickyStateProvider, cfpLoadingBarProvider) {

        cfpLoadingBarProvider.includeSpinner = true;
        cfpLoadingBarProvider.includeBar = true;        

        $urlRouterProvider.otherwise("/");

        $stateProvider //fpaz: defino los states que van a guiar el ruteo de las vistas parciales de la app       
        //#region Home
          .state('home', {
              url: "/",
              views: {
                  'content': {
                      templateUrl: '/Scripts/App/Dashboard/Partials/dashboard.html',
                      controller: ''
                  }
              }
          })
        //#endregion  

        //#region Empleador
          .state('empleador', {
              url: "/Empleador",
              views: {
                  'content': {
                      templateUrl: '/Scripts/App/Empleador/Partials/empleadorInfo.html',
                      controller: 'empleadorCtrl',
                      resolve: {
                          empleadorDataFactory: 'empleadorDataFactory',
                          infoEmpleador: function (empleadorDataFactory) {
                              return empleadorDataFactory.get({ id: 0 })
                          },
                          listadoEmpleadores: function () {
                              return { value: [] };
                          }
                      }
                  }
              }
          })

            .state('empleadorAdd', {
                url: "/Empleador",
                views: {
                    'content': {
                        templateUrl: '/Scripts/App/Empleador/Partials/empleadorAdd.html',
                        controller: 'empleadorCtrl',
                        resolve: {
                            empleadorDataFactory: 'empleadorDataFactory',
                            infoEmpleador: function () {
                                return { value: [] };
                            },
                            listadoEmpleadores: function () {
                                return { value: [] };
                            }
                        }
                    }
                }
            })
            //.state('empleadorDetailBase', {
            //    abstract: true,
            //    views: {
            //        'content': {
            //            templateUrl: '',
            //            controller: '',
            //            resolve: {
            //                listadoEscuelas: function () {
            //                    return { value: [] };
            //                }
            //            }
            //        }
            //    }
            //})
            //.state('empleadorDetailBase.detail', {
            //    url: "",
            //    views: {
            //        'info': {
            //            templateUrl: '',
            //            controller: 'empleadorCtrl',
            //            resolve: {
            //                empleadorDataFactory: 'empleadorDataFactory',
            //                infoEmpleador: function (empleadorDataFactory, $stateParams) {
            //                    //fpaz: trae los datos de un empleador en particular
            //                    var empleadorId = $stateParams.empleadorId;
            //                    return empleadorDataFactory.get({ id: empleador }).$promise;
            //                },
            //                listadoEmpleadores: function () {
            //                    return { value: [] };
            //                },
            //                estadoActual: function ($state) {
            //                    return $state;
            //                }
            //            }
            //        },
            //        'encargados': {
            //            templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail_Encargados.html',
            //            controller: 'encargadosCtrl',
            //            resolve: {
            //                encargadosDataFactory: 'encargadosDataFactory',
            //                listadoEncargados: function (encargadosDataFactory, $stateParams) {
            //                    var escuelaId = $stateParams.escuelaId;
            //                    return encargadosDataFactory.query({ prmIdEscuela: escuelaId });
            //                },
            //                estadoActual: function ($state) {
            //                    return $state;
            //                },
            //                escuelaId: function ($stateParams) {
            //                    //fpaz: trae el Id de una escuela en particular
            //                    return $stateParams.escuelaId;
            //                },
            //                tipoCargosEncargadosDataFactory: 'tipoCargosEncargadosDataFactory',
            //                tiposCargos: function (tipoCargosEncargadosDataFactory) {
            //                    return tipoCargosEncargadosDataFactory.query();
            //                }
            //            }
            //        }            
            //    }
            //})
        //#endregion

        //#region Empleado
          .state('empleado', {
              url: "/Empleado",
              views: {
                  'content': {
                      templateUrl: '/Scripts/App/Empleado/Partials/empleadoAdd.html',
                      controller: 'empleadoCtrl',
                      resolve: {
                          empleadoDataFactory: 'empleadoDataFactory',
                          infoEmpleado: function () {
                              return { value: [] };
                          },
                          listadoEmpleados: function () {
                              return { value: [] };
                          }
                      }
                  }
              }
          })
          .state('empleadoList', {
              url: "/Empleados",
              views: {
                  'content': {
                      templateUrl: '/Scripts/App/Empleado/Partials/empleadoList.html',
                      controller: 'empleadoCtrl',
                      resolve: {
                          empleadoDataFactory: 'empleadoDataFactory',
                          infoEmpleado: function () {
                              return { value: [] };
                          },
                          listadoEmpleados: function (empleadoDataFactory) {
                              return empleadoDataFactory.query();
                          }
                      }
                  }
              }
          })
            .state('profile', {
                //abstract: true,
                url: "/Perfil/:empleadoId",
                views: {
                    'content': {
                        templateUrl: '/Scripts/App/Emp/Partials/empleadoProfile.html',
                        controller: '',
                        controller: 'empleadoCtrl',
                        resolve: {
                            empleadoDataFactory: 'empleadoDataFactory',
                            infoEmpleado: function (empleadoDataFactory, $stateParams) {
                                //fpaz: trae los datos de un empleado en particular
                                    var empleadoId = $stateParams.empleadoId;
                                    return empleadoDataFactory.get({ id: empleadoId });
                            },
                            listadoEmpleados: function () {
                                return { value: [] };
                            }
                        }
                    }
                }
            })
            //.state('empleadoDetailBase.detail', {
            //    url: "",
            //    views: {
            //        'info': {
            //            templateUrl: '',
            //            controller: 'empleadoCtrl',
            //            resolve: {                            
            //            }
            //        },
            //        'misTrabajos': {
            //            templateUrl: '',
            //            controller: '',
            //            resolve: {                            
            //            }
            //        },
            //        'misPostulaciones': {
            //            templateUrl: '',
            //            controller: '',
            //            resolve: {
            //            }
            //        },
            //        'misMensajes': {
            //            templateUrl: '',
            //            controller: '',
            //            resolve: {
            //            }
            //        }
            //    }
            //})
        //#endregion  

        //#region Oferta
         .state('oferta', {
             url: "/Ofertas",
             views: {
                 'content': {
                     templateUrl: '/Scripts/App/Oferta/Partials/ofertaList.html',
                     controller: '',
                     resolve: {
                         //ofertaDataFactory: 'ofertaDataFactory',
                         //listadoEmpleadores: function () {
                         //    return { value: [] };
                         //}
                     }
                 }
             }
         })

            .state('ofertaAdd', {
                url: "/Ofertas",
                views: {
                    'content': {
                        templateUrl: '/Scripts/App/Oferta/Partials/ofertaAdd.html',
                        controller: '',
                        resolve: {
                            //ofertaDataFactory: 'ofertaDataFactory',
                            //listadoEmpleadores: function () {
                            //    return { value: [] };
                            //}
                        }
                    }
                }
            })
        //#endregion

        
    })

