_app.service("EmployeesHttp", function ($http, $q) {
    this.GetEmployeeRepo = function () {
        var _q = $q.defer();
        $http.get("/Employees/GetEmployeeRepo")
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.GetEmployeeInfo = function (pParams) {
        var _q = $q.defer();
        $http.get("/Employees/GetEmployeeInfo", { params: pParams })
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
});