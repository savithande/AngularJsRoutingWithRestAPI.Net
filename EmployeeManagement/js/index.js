angular.module('myApp')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when("/employee", {
                templateUrl: "employee.html",
               controller: "employeeDetailsController"
            })
            .when("/department", {
                templateUrl: "department.html",
                controller: "departmentDetailsController"
            })
            .when('/', {
                redirectTo: "index.html"
            })
            .otherwise({
                redirectedTo: '/'
            });

    }]);
