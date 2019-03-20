/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentEPayCo')
        .factory('paymentEPayCoService', paymentEPayCoService);

    /* @ngInject */
    function paymentEPayCoService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/epayco/config');
        }

        function updateSetting(settings) {
            return $http.put('api/epayco/config', settings);
        }
    }
})();
