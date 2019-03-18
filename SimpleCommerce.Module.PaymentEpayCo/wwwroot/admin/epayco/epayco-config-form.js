/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentEPayCo')
        .controller('EPayCoConfigFormCtrl', EPayCoConfigFormCtrl);

    /* @ngInject */
    function EPayCoConfigFormCtrl($state, paymentEPayCoService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.epaycoConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentEPayCoService.updateSetting(vm.epaycoConfig)
                .then(function (result) {
                    toastr.success('Application settings have been saved');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not save settings.');
                    }
                });
        };

        function init() {
            paymentEPayCoService.getSettings().then(function (result) {
                vm.epaycoConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
