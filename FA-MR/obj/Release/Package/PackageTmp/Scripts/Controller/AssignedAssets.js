_app.controller("AssignedAssetsCtrl", function ($scope, Table, FixedAssetsHttp, MRHttp, ReportsHttp) {
    //Initialize
    var Ini = (function () {
        var Load = function () {
            $scope.isDisabled = false;
            Table.Load(jQuery("#TblAssignedAssets"), [], TblAssigned(), false, false);
            FixedAssetsHttp.GetAssigned()
                .then(function (result) {
                    var _result = result.data;
                    if (_result.success) {
                        var _newTbl = _result.data.map(function (d) {
                            return ["", d.FNAM + " " + d.LNAM, d.PSTN, d.ACOD, d.ANAM, d.UMEA, d.QUNT, d.SNUM, d.UCST.toFixed(2), moment(d.SDAT).format("MM/DD/YYYY"), d.ULIF, d.AIID, d.MRID];
                        });
                        Table.Load(jQuery("#TblAssignedAssets"), _newTbl, TblAssigned(), true, false);
                        $scope.isDisabled = true;
                    } else {
                        $scope.$emit("Dialog",
                            {
                                type: "Error",
                                message: _result.message
                            });
                    }
                }, function (result) {
                    $scope.$emit("Dialog",
                        {
                            type: "Error",
                            message: result
                        });
                });
        };
        var TblAssigned = function () {
            return [{
                orderable: false,
                className: "select-checkbox",
                targets: 0
            },
            {
                className: "text-left",
                targets: 1
            },
            {
                className: "display-none",
                targets: 2
            },
            {
                className: "text-left",
                targets: 3
            },
            {
                className: "text-left",
                targets: 4
            },
            {
                className: "text-center",
                targets: 5
            },
            {
                className: "display-none",
                targets: 11
            },
            {
                className: "display-none",
                targets: 12
            }];
        };
        return {
            Load: Load,
            TblAssigned: TblAssigned
        };
    })();
    //Function
    $scope.AssignedAssets = {
        Load: function () {
            Ini.Load();
        },
        MouseHover: function (pMenu, pEv) {
            $scope.ParentEv = pEv;
            pMenu.open();
        },
        Surrender: function (pEv) {
            var _selIds = jQuery("#TblAssignedAssets").DataTable().rows({ selected: true });
            var _count = _selIds.count();

            if (_count !== 0) {
                var _data = _selIds.data().toArray();
                _data.map(function (d) {
                    var _model = MRHttp.Model();
                    $scope.AssetCode = d[1];
                    $scope.Serial = d[7];
                    $scope.Description = d[4];
                });
                $scope.TransDate = new Date();
                $scope.$emit("Dialog",
                    {
                        ev: $scope.ParentEv,
                        type: "Modal",
                        IdName: "Surrender"
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: $scope.ParentEv,
                        type: "Error",
                        message: "No selected assigned asset"
                    });
            }
        },
        Submit: function (pEv) {
            var _selIds = jQuery("#TblAssignedAssets").DataTable().rows({ selected: true });
            var _count = _selIds.count();
            var _selected = [];

            if (_count !== 0) {
                var _data = _selIds.data().toArray();
                _data.map(function (d) {
                    var _model = MRHttp.Model();
                    _model.AIID = d[11];
                    _model.MRID = d[12];
                    _model.RMRK = $scope.Remarks;
                    _model.TDAT = $scope.TransDate;
                    _selected.push(_model);
                });

                MRHttp.Surrender(_selected)
                    .then(function (result) {
                        var _result = result.data;
                        if (_result.success) {
                            Ini.Load();
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Success",
                                    message: _result.message
                                });
                        }
                        else {
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

        },
        Generate: function (pEv) {
            var _selIds = jQuery("#TblAssignedAssets").DataTable().rows({ selected: true });
            var _count = _selIds.count();
            var _faList = [];

            if (_count === 1) {
                var _data = _selIds.data().toArray();
                var _params = { pTransDate: "", pName: "", pPosition: "", pPrepared: $scope.UserLog, pFFormat: "", pObj: [] };
                var _fa = FixedAssetsHttp.Binding();

                _data.map(function (d) {
                    _fa.AssetItemId = d[11];
                    _params.pTransDate = new Date();//Dont forget
                    _params.pPosition = d[2];
                    _params.pName = d[1];
                    _faList.push(_fa);
                });
                _params.pObj = JSON.stringify(_faList);
                _params.pFFormat = "PDF";
                $scope.$emit("Dialog",
                    {
                        ev: $scope.ParentEv,
                        type: "BWorker"
                    });
                ReportsHttp.RptMR(_params)
                    .then(function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: $scope.ParentEv,
                                type: "Success",
                                message: "Thanks for waiting",
                                multiple: false
                            });
                        window.open(result, "_blank");
                    }, function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: $scope.ParentEv,
                                type: "Error",
                                message: result
                            });
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: $scope.ParentEv,
                        type: "Error",
                        message: "No selected assigned asset"
                    });
            }
        },
        ExportToExcel: function (pEv) {
            $scope.IsAll = false;

            $scope.$emit("Dialog",
                {
                    ev: $scope.ParentEv,
                    type: "Modal",
                    IdName: "ExportExcel"
                });
        },
        Export: function (pEv) {
            var _params = { pFrom: "1753-01-01", pTo: "1753-01-01" };

            if (!$scope.IsAll) {
                _params.pFrom = $scope.FromDate;
                _params.pTo = $scope.ToDate;
            }
            $scope.$emit("Dialog",
                {
                    ev: $scope.ParentEv,
                    type: "BWorker"
                });
            ReportsHttp.RptExportExcel(_params)
                .then(function (result) {
                    $scope.$emit("Dialog",
                        {
                            ev: $scope.ParentEv,
                            type: "Success",
                            message: "Thanks for waiting",
                            multiple: false
                        });
                    if (window.navigator.msSaveOrOpenBlob) {
                        window.navigator.msSaveBlob(blob, new Date() + ".csv");
                    }
                    else {
                        var a = window.document.createElement("a");
                        a.href = result;
                        a.download = new Date() + ".csv";
                        document.body.appendChild(a);
                        a.click();
                        document.body.removeChild(a);
                    }
                }, function (result) {
                    $scope.$emit("Dialog",
                        {
                            ev: $scope.ParentEv,
                            type: "Error",
                            message: result.status + ":" + "Could not export"
                        });
                });
        }
    };
});