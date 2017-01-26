angular.module("umbraco")
	.controller("My.Workshop.EditController", function ($routeParams, notificationsService, workshopResource, assetsService, navigationService) {
		
	    var vm = this;
	    vm.workshop = {};

	    vm.buttonState = "init";
	    vm.properties = {
	        description: { label: "Description", description: "What will attendees learn on this workshop" },
	        location: { label: "Location", description: "Enter the venue for this workshop" }
	    };

        //initialise
	    if (!$routeParams.create) {
		    workshopResource.getById($routeParams.id).then(function (response) {
		        vm.workshop = response.data;

                //set the active item on the tree
		        navigationService.syncTree({ tree: 'workshopTree', path: ["-1", vm.workshop.id], forceReload: false });

                //load the google map (for the go further exercise)
		        loadmap();
			});
		}
	    
        //setup maps and geocoding
	    var maps, geocoder;

	    function loadmap() {
	        assetsService.loadJs("https://maps.googleapis.com/maps/api/js?key=AIzaSyDULMzul1UdFIAHiFcbeTyzU7PeIQ7vcV8").then(function () {
	            geocoder = new google.maps.Geocoder();
	            map = new google.maps.Map(document.getElementById('map'), {
	                center: { lat: -34.397, lng: 150.644 },
	                zoom: 8
	            });

	            //if we have a presaved location, set it on the map
	            if (vm.workshop.location) {
	                vm.lookup(vm.workshop.location);
	            }
	        });
	    }

	    vm.lookup = _.debounce(function (address) {

	        geocoder.geocode({ 'address': address }, function (results, status) {
	            if (status == 'OK') {
	                map.setCenter(results[0].geometry.location);

	                var marker = new google.maps.Marker({
	                    map: map,
	                    position: results[0].geometry.location
	                });
	            }
	        });

	    }, 300);

		vm.save = function() {
		    vm.buttonState = "busy";

		    workshopResource.save(vm.workshop).then(function (response) {
		        vm.buttonState = "success";
		        vm.workshop = response.data;
				notificationsService.success("Workshop saved!");
			});
		};


	});