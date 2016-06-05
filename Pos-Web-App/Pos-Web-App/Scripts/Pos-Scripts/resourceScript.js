//Var used to save the URL 
var urlGeneric = 'http://172.19.12.255';
var urlPaciente = 'Paciente';
var urlHistorial = 'Historial';
//This script is the resource that is used to connect to the web Api od DrPhischel
/*
angular.module('DrPhischelApp').factory('drPhischelApiResource', function ($resource) {
    return $resource(urlGeneric + ':8090/api/:type/:extension/:extension2/:extension3/:extension4/:extension5/:id', {}, {
        query: {
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' },
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: true
        },
        get: {
            method: 'GET',
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: false
        },
        save: {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }            
        },
        saveList: {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },
            isArray: true
        },
        update: {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        },
        delete: { method: 'DELETE' }
    });
});

//This script is the resource that is used to connect to the web Api od FarmaticaPhischel
angular.module('DrPhischelApp').factory('farmaticaPhischelResource', function ($resource) {
    return $resource(urlGeneric +':8091/api/:type/:extension/:extension2/:id', {}, {
        query: {
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' },
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: true
        },
        get: {
            method: 'GET',
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: false
        },
        save: {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        },
        update: { method: 'PUT' },
        delete: { method: 'DELETE' }
    });
});



*/