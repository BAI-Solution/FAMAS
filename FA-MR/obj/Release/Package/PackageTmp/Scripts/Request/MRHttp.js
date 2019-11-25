_app.service("MRHttp", function ($http, $q) {
    this.InsertMR = function (pParams) {
        var _q = $q.defer();
        $http.post("/MRs/InsertMR", pParams)
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.Surrender = function (pParams) {
        var _q = $q.defer();
        $http.post("/MRs/Surrender", pParams)
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.GetMRsAssetsItems = function () {
        var _q = $q.defer();
        $http.get("/MRs/GetMRsAssetsItems")
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.GetAssetMovement = function (pParams) {
        var _q = $q.defer();
        $http.get("/MRs/GetAssetMovement", { params: pParams})
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.Model = function () {
        var _model = {
            MRID: 0,
            EMID: 0,
            FNAM: "",
            LNAM: "",
            PSTN: "",
            DPRT: "",
            BUNT: "",
            AIID: 0,
            AGRP: "",
            ACOD: "",
            ANAM: "",
            SNAM: "",
            RMRK: "",
            TDAT: "1753-01-01"
        };
        return _model;
    };
});