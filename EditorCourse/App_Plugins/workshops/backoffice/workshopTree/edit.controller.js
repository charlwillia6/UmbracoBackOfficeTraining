angular.module("umbraco").controller("My.Workshop.EditController", function ($routeParams, workshopResource, notificationsService) {
    var vm = this;
    vm.workshop = {};
    vm.buttonState = "init";
    vm.properties = {
        description: { label: "Description", description: "What will attendess learn on this workshop" }
    };

    //initialize
    if (!$routeParams.create) {
        workshopResource.getById($routeParams.id).then(function (response) {
            vm.workshop = response.data;
        });
    };

    vm.save = function () {
        vm.buttonState = "busy";

        workshopResource.save(vm.workshop).then(function (response) {
            vm.buttonState = "success";
            vm.workshop = response.data;
            notificationsService.success("Workshop saved!");
        });
    };
});