_app.controller("FixedAssetsMovementCntrl", function ($scope, Table, MRHttp, ReportsHttp) {
    //Initialize
    var Ini = (function () {
        var Load = function () {
            $scope.isDisabled = false;
            Table.Load(jQuery("#TblFAM"), [], TblFAM(), false, false);
            MRHttp.GetMRsAssetsItems()
                .then(function (result) {
                    var _result = result.data;
                    if (_result.success) {
                        var _newTbl = _result.data.map(function (d) {
                            return ["",
                                d.FNAM + " " + d.LNAM,
                                d.ACOD,
                                d.ANAM,
                                d.UMEA,
                                d.QUNT,
                                d.SNUM,
                                parseFloat(d.UCST).toFixed(2),
                                moment(d.SDAT).format("MM/DD/YYYY"),
                                d.ULIF,
                                d.AIID];
                        });
                        Table.Load(jQuery("#TblFAM"), _newTbl, TblFAM(), true, false);
                        $scope.isDisabled = true;
                    } else {
                    }
                }, function (result) {
                });
        };
        var TblFAM = function () {
            var _tblFAM = [
                {
                    orderable: false,
                    className: "select-checkbox",
                    targets: 0
                },
                {
                    className: "text-left",
                    targets: 1
                },
                {
                    className: "text-left",
                    targets: 2
                },
                {
                    className: "text-left",
                    targets: 3
                },
                {
                    className: "text-center",
                    targets: 4
                },
                {
                    className: "text-left",
                    targets: 6
                },
                {
                    className: "display-none",
                    targets: 10
                }
            ];
            return _tblFAM;
        };
        var TblMovement = function () {
            var _tblMovement = [
                {
                    orderable: false,
                    className: "select-checkbox",
                    targets: 0
                },
                {
                    "orderable": false,
                    "targets": 1
                },
                {
                    className: "text-center",
                    targets: 1
                },
                {
                    className: "text-left",
                    targets: 2
                },
                {
                    className: "text-center",
                    targets: 3
                },
                {
                    className: "text-center",
                    targets: 4
                },
                {
                    className: "text-center",
                    targets: 5
                },
                {
                    className: "text-center",
                    targets: 6
                }
            ];
            return _tblMovement;
        };
        return {
            Load: Load,
            TblMovement: TblMovement
        };
    })();
    //Function
    $scope.FAM = {
        Load: function () {
            Ini.Load();
        },
        ViewMovement: function (pEv) {
            var _newTbl = [];
            var _selIds = jQuery("#TblFAM").DataTable().rows({ selected: true });
            var _count = _selIds.count();

            if (_count !== 0) {
                var _data = _selIds.data().toArray();
                $scope.AIID = 0;
                _data.map(function (d) {
                    $scope.AssetCode = d[2];
                    $scope.Serial = d[6];
                    $scope.Description = d[3];
                    $scope.AIID = d[10];
                });
                MRHttp.GetAssetMovement({ pAIID: $scope.AIID })
                    .then(function (result) {
                        var _result = result.data;
                        if (_result.success) {
                            var _newTbl = _result.data.map(function (d) {
                                var _transDate = moment(d.TDAT).format("YYYY-MM-DD");
                                return ["",
                                    d.MRID,
                                    d.FNAM + " " + d.LNAM,
                                    d.PSTN,
                                    d.DPRT,
                                    d.ASTA,
                                    (_transDate === "1753-01-01" ? "" : _transDate)];
                            });
                            Table.Load(jQuery("#TblMovement"), _newTbl, Ini.TblMovement(), true, true);
                        } else {
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Error",
                                    message: result.message
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
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "Modal",
                        IdName: "AssetMovement"
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "Error",
                        message: "No selected asset item"
                    });
            }
        },
        Generate: function (pEv) {
            var _selIds = jQuery("#TblMovement").DataTable().rows({ selected: true });
            var _count = _selIds.count();

            if (_count !== 0) {
                var _data = _selIds.data().toArray();
                var _params = { pAssetItemId: 0, pMRId: "" }, _mrId = [];
                _data.map(function (d) {
                    _mrId.push({ MRId: d[1] });
                });
                _params.pAssetItemId = $scope.AIID;
                _params.pMRId = JSON.stringify(_mrId);
                $scope.$emit("Dialog",
                    {
                        ev: $scope.ParentEv,
                        type: "BWorker"
                    });
                ReportsHttp.RptMRPrevious(_params)
                    .then(function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: pEv,
                                type: "Success",
                                message: "Thanks for waiting",
                                multiple: false
                            });
                        window.open(result, "_blank");
                    }, function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: pEv,
                                type: "Error",
                                message: result
                            });
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "Error",
                        message: "No selected MR",
                        multiple: true
                    });
            }
        }
    };
});