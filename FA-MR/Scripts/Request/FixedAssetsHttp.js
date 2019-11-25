_app.service("FixedAssetsHttp", function ($http, $q) {
    this.GetItems = function () {
        var _q = $q.defer();
        $http.get("/FixedAssets/GetItems")
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.GetFiltered = function (pParams) {
        var _q = $q.defer();
        $http.get("/FixedAssets/GetFiltered", { params: pParams })
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.GetAssigned = function () {
        var _q = $q.defer();
        $http.get("/FixedAssets/GetAssigned")
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.GetDisposed = function () {
        var _q = $q.defer();
        $http.get("/FixedAssets/GetDisposed")
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    };
    this.InsertAssetItem = function (pParams) {
        var _q = $q.defer();
        $http.post("/FixedAssets/InsertAssetItem", pParams)
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    },
    this.UpdateAssetItem = function (pParams) {
        var _q = $q.defer();
        $http.post("/FixedAssets/UpdateAssetItem", pParams)
            .then(function (result) {
                _q.resolve(result);
            }, function (result) {
                _q.reject(result);
            });
        return _q.promise;
    },
    this.UpdateStatus = function (pParams) {
        var _q = $q.defer();
        $http.post("/FixedAssets/UpdateStatus", pParams)
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
            AIID: 0,
            AGRP: "",
            ACOD: "",
            ANUM: "",
            ANAM: "",
            ATYP: "",
            UCST: 0,
            UMEA: "",
            QUNT: 0,
            SNUM: "",
            ULIF: 0,
            SDAT: "1753-01-01",
            ASTA: "",
            RMRK: ""
        };
        return _model;
    };
    this.Binding = function () {
        var _binding = {
            MRId: 0,
            FirstName: "",
            LastName: "",
            Position: "",
            AssetItemId: 0,
            AssetGroup: "",
            AssetCode: "",
            AssetNumber: "",
            AssetName: "",
            AssetType: "",
            UnitCost: 0,
            SerialNumber: "",
            UnitMeasure: "",
            Quantity: 0,
            UsefulLife: 0,
            ServiceDate: "1753-01-01",
            AssetStatus: "",
            Remarks: ""
        };
        return _binding;
    };
});