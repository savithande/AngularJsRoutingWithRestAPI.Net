angular.module('myApp')
    .controller('employeeDetailsController', ['$scope','$http', function ($scope, $http) {
        $scope.employeeDetails = [];

        $scope.employeeDetails =

            $http({
                method: 'get',
                url: 'https://localhost:44311/api/employeeDetails'
            })
            .then(res=>{
                $scope.employeeDetails = res.data
            }).catch(err=>{console.log(err)});
    }]);