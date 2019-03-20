/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentEPayCo', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-epayco-config', {
                        url: '/payments/epayco/config',
                        templateUrl: 'modules/paymentepayco/admin/epayco/epayco-config-form.html',
                        controller: 'EPayCoConfigFormCtrl as vm'
                    })
                ;
            }
        ]);
})();
