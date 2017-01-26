angular.module("umbraco").controller("My.Workshop.DeleteController", function ($scope, navigationService, treeService, workshopResource) {
    $scope.performDelete = function () {
        $scope.currentNode.loading = true;
        workshopResource.delete($scope.currentNode.id).then(function() {
            $scope.currentNode.loading = false;
            treeService.removeNode($scope.currentNode);
            navigationService.hideDialog();
        });
    };

    $scope.cancel = function() {
        navigationService.hideDialog();
    };
});