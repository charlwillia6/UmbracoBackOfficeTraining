angular.module("umbraco").controller("community.dashboard", function($scope, contentResource, entityResource) {
   
   
    entityResource.getByQuery("//community", -1, "Document").then(function (document) {

        contentResource.getChildren(document.id).then(function (response) {
            var community = response.items;
            _.each(community, function (member) {
                var date = moment(member.updateDate);
                member.outdated = date.diff(Date.now(), "days") <= -6;
                member.diff = date.fromNow();
                member.avatar = _.findWhere(member.properties, { 'alias': 'twitterHandle' }).value;
            })

            $scope.community = community;

        });

    });
   
    
});