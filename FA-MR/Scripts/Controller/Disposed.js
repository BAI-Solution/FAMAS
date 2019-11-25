_app.controller("DisposedCntrl", function ($scope, Table, FixedAssetsHttp) {
    var _tblDispose = [
        {
            className: "text-left",
            targets: 0
        },
        {
            className: "text-center",
            targets: 1
        }
    ];
    $scope.Dispose =  {
        Load: function () {
            $scope.isDisabled = false;
            Table.Load(jQuery("#TblDisposed"), [], _tblDispose, false);
            FixedAssetsHttp.GetDisposed()
                .then(function (result) {
                    var _result = result.data;
                    if (_result.success) {
                        var _newTbl = _result.data.map(function (d) {
                            return [d.ANAM, d.UMEA, d.QUNT, "", d.UCST, moment(d.SDAT).format("MM/DD/YYYY"), d.ULIF];
                        });
                        Table.Load(jQuery("#TblDisposed"), _newTbl, _tblDispose, true);
                        $scope.isDisabled = true;
                    } else {
                        $scope.$emit("Dialog",
                            {
                                ev: pEv,
                                type: "Error",
                                message: _result.message
                            });
                    }
                }, function (result) {
                    $scope.$emit("Dialog",
                        {
                            ev: pEv,
                            type: "Error",
                            message: result
                        });
                });
        }
    };
});