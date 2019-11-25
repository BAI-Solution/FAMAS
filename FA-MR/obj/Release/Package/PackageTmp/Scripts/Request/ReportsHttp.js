_app.service("ReportsHttp", function ($http, $q) {
    this.RptMR = function (pParams) {
        var _q = $q.defer();
        $http.get("https://rapport.rafi.org.ph:8080/api/Report/MR", { params: pParams, responseType: "blob"})
            .then(function (result) {
                var file = new Blob([result.data], { type: "application/pdf" });
                var fileURL = URL.createObjectURL(file);
                _q.resolve(fileURL);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.RptExportExcel = function (pParams) {
        var _q = $q.defer();
        $http.get("http://localhost:64333/api/Report/ExportToExcel", { params: pParams, responseType: "blob" })
            .then(function (result) {
                var file = new Blob([result.data], { type: "text/csv" });
                var fileURL = URL.createObjectURL(file);
                _q.resolve(fileURL);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.RptMRPrevious = function (pParams) {
        var _q = $q.defer();
        $http.get("https://rapport.rafi.org.ph:8080/api/Report/MRPrevious", { params: pParams, responseType: "blob" })
            .then(function (result) {
                var file = new Blob([result.data], { type: "application/pdf" });
                var fileURL = URL.createObjectURL(file);
                _q.resolve(fileURL);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
});