_app.controller("FixedAssetsCtrl", function ($scope, $q, Table, ReportsHttp, FixedAssetsHttp, EmployeesHttp, MRHttp) {
    $scope.AssetItemId = 0;
    var lEvent;
    var BusinessUnits = [];
    var Names = [];
    var Types = [];
    //Initialize
    var Ini = (function () {
        var Load = function () {
            $scope.isDisabled = false;
            Table.Load(jQuery("#TblFixedAsset"), [], TblFA(), false, true);
            FixedAssetsHttp.GetItems()
                .then(function (result) {
                    var _result = result.data;
                    if (_result.success) {
                        $scope.AssetsGoups = _result.data.AGRP;
                        $scope.UOMs = _result.data.UMEA;
                        Types = _result.data.ATYP;
                        var _newTbl = _result.data.AITM.map(function (d) {
                            return ["", d.ACOD, d.ANAM, d.UMEA, d.QUNT, d.SNUM, d.UCST, moment(d.SDAT).format("MM/DD/YYYY"), d.ULIF, d.AIID, d.AGRP, d.ATYP];
                        });
                        Table.Load(jQuery("#TblFixedAsset"), _newTbl, TblFA(), true, true);
                        $scope.isDisabled = true;
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
        };
        var Types = function (pVal) {
            var _selected = pVal === 0 ? $scope.AssetGroup : $scope.FAssetGroup;
            $scope.AssetsTypes = [];
            Types.map(function (d) {
                if (_selected === d.AGRP) {
                    $scope.AssetsTypes.push(d);
                }
            });
        };
        var TblFA = function () {
            return [
                {
                    orderable: false,
                    className: "select-checkbox",
                    targets: 0
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
                    className: "display-none",
                    targets: 9
                },
                {
                    className: "display-none",
                    targets: 10
                },
                {
                    className: "display-none",
                    targets: 11
                }
            ];
        };
        var TblMR = function () {
            return [
                {
                    className: "text-left",
                    targets: 0
                },
                {
                    className: "text-left",
                    targets: 1
                },
                {
                    className: "text-center",
                    targets: 2
                },
                {
                    className: "text-center",
                    targets: 3
                },
                {
                    className: "display-none",
                    targets: 5
                }
            ];
        };
        return {
            Load: Load,
            Types: Types,
            TblMR: TblMR
        };
    })();
    //Function
    $scope.FixedAsset = {
        Load: function () {
            Ini.Load();
        },
        MouseHover: function (pMenu, pEv) {
            lEvent = pEv;
            pMenu.open();
        },
        Assign: function () {
            var _selIds = jQuery("#TblFixedAsset").DataTable().rows({ selected: true });
            var _count = _selIds.count();

            if (_count !== 0) {
                var _data = _selIds.data().toArray();
                var _newTbl = [];
                $scope.TransDate = new Date();
                $scope.BusinessUnit = "";
                $scope.Department = "";
                $scope.Name = "";
                $scope.Position = "";

                EmployeesHttp.GetEmployeeRepo().then(function (result) {
                    var _result = result.data;
                    if (_result.success) {
                        BusinessUnits = _result.data.DPRT;
                        $scope.BusinessUnits = _result.data.BUNT;
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
                _data.map(function (d) {
                    _newTbl.push(["", d[2], d[3], d[4], "", d[9]]);
                });
                Table.Load(jQuery("#TblMR"), _newTbl, Ini.TblMR(), false);
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Modal",
                        IdName: "AssignAsset"
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Error",
                        message: "No selected asset item"
                    });
            }
        },
        Dispose: function () {
            var _selIds = jQuery("#TblFixedAsset").DataTable().rows({ selected: true });
            var _count = _selIds.count();

            if (_count !== 0) {
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Modal",
                        IdName: "Dispose"
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Error",
                        message: "No selected asset item"
                    });
            }
        },
        SaveMR: function (pEv) {
            var _fixedAsset = [];
            var _params = { pTransDate: "", pName: "", pPosition: "", pPrepared: $scope.UserLog, pFFormat: "", pObj: [] };
            var _selIds = jQuery("#TblMR").DataTable().rows();
            var _data = _selIds.data().toArray();
            _data.map(function (d) {
                var _fixedAssetModel = FixedAssetsHttp.Model();

                _fixedAssetModel.EMID = $scope.Name;
                _fixedAssetModel.AIID = d[5];
                _fixedAsset.push(_fixedAssetModel);
            });
            $scope.AssignForm.$setPristine();
            if ($scope.AssignForm.$valid) {
                _params.pTransDate = $scope.TransDate;
                _params.pNameId = $scope.Name;
                _params.pPosition = $scope.Position;
                _params.pFFormat = "PDF";
                _params.pObj = JSON.stringify(_fixedAsset);
                $scope.Names.map(function (d) {
                    if ($scope.Name === d.EMID) {
                        _params.pName = d.FNAM + " " + d.LNAM;
                        return;
                    }
                });
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "BWorker"
                    });
                $q.all([MRHttp.InsertMR(_fixedAsset), ReportsHttp.RptMR(_params), Ini.Load()])
                    .then(function (result) {

                        if (result[0].data.success) {
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Success",
                                    message: result[0].data.message,
                                    multiple: false
                                });
                            window.open(result[1], "_blank");
                        } else {
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Error",
                                    message: result[0].data.message,
                                    multiple: false
                                });
                        }
                    }, function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: pEv,
                                type: "Error",
                                message: result,
                                multiple: false
                            });
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "Error",
                        message: "There are empty fields"
                    });
            }
        },
        SaveDispose: function (pEv) {
            var _selIds = jQuery("#TblFixedAsset").DataTable().rows({ selected: true });
            var _count = _selIds.count();
            var _selected = [];

            if (_count !== 0) {
                var _data = _selIds.data().toArray();
                _data.map(function (d) {
                    var _model = MRHttp.Model();
                    _model.AIID = d[9];
                    _model.RMRK = $scope.Remarks;
                    _model.ASTA = "Disposed";
                    _selected.push(_model);
                });
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "BWorker"
                    });
                FixedAssetsHttp.UpdateStatus(_selected)
                    .then(function (result) {
                        var _result = result.data;

                        if (_result.success) {
                            Ini.Load();
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Success",
                                    message: _result.message,
                                    multiple: false
                                });
                        }
                        else {
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Error",
                                    message: _result.message,
                                    multiple: false
                                });
                        }

                    }, function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: pEv,
                                type: "Error",
                                message: result,
                                multiple: false
                            });
                    });
            }
        },
        AddAsset: function () {
            $scope.AssetItemId = 0;
            $scope.AssetCode = "";
            $scope.Description = "";
            $scope.DateInService = "";
            $scope.UOM = "";
            $scope.Cost = "";
            $scope.FAssetGroup = "";
            $scope.UsefulLife = "";
            $scope.FAssetType = "";
            $scope.DateInService = new Date();
            $scope.$emit("Dialog",
                {
                    ev: lEvent,
                    type: "Modal",
                    IdName: "AddAsset"
                });
        },
        UpdateAsset: function () {
            var _selIds = jQuery("#TblFixedAsset").DataTable().rows({ selected: true });
            var _count = _selIds.count();
            var _data = _selIds.data().toArray();

            if (_count === 1) {
                _data.map(function (d) {
                    $scope.AssetItemId = d[9];
                    $scope.AssetCode = d[1];
                    $scope.Description = d[2];
                    $scope.DateInService = d[7];
                    $scope.UOM = d[3];
                    $scope.Cost = d[6];
                    $scope.FAssetGroup = d[10];
                    $scope.UsefulLife = d[8];
                    $scope.Serial = d[5];
                    Ini.Types(1);
                    $scope.FAssetType = d[11];
                    return;
                });
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Modal",
                        IdName: "AddAsset"
                    });
            }
            else if (_count >= 1) {
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Error",
                        message: "At least one asset item only"
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: lEvent,
                        type: "Error",
                        message: "No selected asset item"
                    });
            }
        },
        SaveAssetItem: function (pEv) {
            $scope.AddForm.$setPristine();
            if ($scope.AddForm.$valid) {
                var _model = FixedAssetsHttp.Model();
                _model.AIID = $scope.AssetItemId;
                _model.AGRP = $scope.FAssetGroup;
                _model.ATYP = $scope.FAssetType;
                _model.ACOD = $scope.AssetCode;
                _model.ANAM = $scope.Description;
                _model.SNUM = $scope.Serial;
                _model.ULIF = $scope.UsefulLife;
                _model.SDAT = $scope.DateInService;
                _model.UMEA = $scope.UOM;
                _model.UCST = $scope.Cost;
                var _request = $scope.AssetItemId === 0 ? FixedAssetsHttp.InsertAssetItem(_model) : FixedAssetsHttp.UpdateAssetItem(_model);
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "BWorker"
                    });
                _request.then(function (result) {
                        var _result = result.data;

                        if (_result.success) {
                            Ini.Load();
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Success",
                                    message: _result.message,
                                    multiple: false
                                });
                        }
                        else {
                            $scope.$emit("Dialog",
                                {
                                    ev: pEv,
                                    type: "Error",
                                    message: _result.message,
                                    multiple: false
                                });
                        }

                    }, function (result) {
                        $scope.$emit("Dialog",
                            {
                                ev: pEv,
                                type: "Error",
                                message: result,
                                multiple: false
                            });
                    });
            }
            else {
                $scope.$emit("Dialog",
                    {
                        ev: pEv,
                        type: "Error",
                        message: "There are empty fields",
                        multiple: true
                    });
            }
        },
        SyncMasterData: function (pEv) {
            $scope.$emit("Dialog",
                {
                    ev: lEvent,
                    type: "Modal",
                    IdName: "SyncMasterData"
                });
        },
        StartSync: function (pEv) {
            console.log($scope.File);
        },
        ChangeGroups: function (pVal) {
            Ini.Types(pVal);
        },
        ChangeTypes: function (ev) {
            $scope.isDisabled = false;
            Table.Load(jQuery("#TblFixedAsset"), [], false, true);
            var _params = { AGRP: $scope.AssetGroup, ATYP: $scope.AssetType };
            FixedAssetsHttp.GetFiltered(_params)
                .then(function (result) {
                    var _result = result.data;
                    if (_result.success) {
                        var _newTbl = _result.data.map(function (d) {
                            return ["", d.ANAM, d.UMEA, d.QUNT, "", d.UCST, moment(d.SDAT).format("MM/DD/YYYY"), d.ULIF];
                        });
                        Table.Load(jQuery("#TblFixedAsset"), _newTbl, _tblFA, true, true);
                        $scope.isDisabled = true;
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
        },
        ChangeBusinessUnits: function () {
            $scope.Departments = [];

            BusinessUnits.map(function (d) {
                if ($scope.BusinessUnit === d.BUNT) {
                    $scope.Departments.push(d);
                }
            });
        },
        ChangeDepartments: function () {
            var _params = { pBUNT: $scope.BusinessUnit, pDPRT: $scope.Department };
            EmployeesHttp.GetEmployeeInfo(_params)
                .then(function (result) {
                    var _result = result.data;

                    if (_result.success) {
                        Names = _result.data;
                        $scope.Names = _result.data;
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
        },
        ChangeNames: function () {
            $scope.Position = "";
            Names.map(function (d) {
                if ($scope.Name === d.EMID) {
                    $scope.Position = d.PSTN;
                    return;
                }
            });
        }
    };
});