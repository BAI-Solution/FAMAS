_app.service("Dialog", function ($mdDialog) {
    this.Modal = function (pEV, pScope, pId) {
        $mdDialog.show({
            controller: DialogCtrl(pScope, $mdDialog),
            contentElement: document.querySelector("#" + pId),
            parent: angular.element(document.body),
            targetEvent: pEV
            //fullscreen: pScope.customFullscreen // Only for -xs, -sm breakpoints.
        });
    };
    this.Error = function (pData, pScope) {
        pScope.ErrorMsg = pData.message;
        $mdDialog.show({
            controller: DialogCtrl(pScope, $mdDialog),
            contentElement: document.querySelector("#Error"),
            parent: angular.element(document.body),
            targetEvent: pData.ev,
            multiple: pData.multiple
            //fullscreen: pScope.customFullscreen // Only for -xs, -sm breakpoints.
        });
    };
    this.Success = function (pData, pScope) {
        pScope.SuccessMsg = pData.message;
        $mdDialog.show({
            controller: DialogCtrl(pScope, $mdDialog),
            contentElement: document.querySelector("#Success"),
            parent: angular.element(document.body),
            targetEvent: pData.ev,
            onRemoving: function () {
                $mdDialog.hide();
            },
            multiple: pData.multiple
            //fullscreen: pScope.customFullscreen // Only for -xs, -sm breakpoints.
        });
    };
    this.BWorker = function (pData, pScope) {
        pScope.isDisabled = false;
        $mdDialog.show({
            controller: DialogCtrl(pScope, $mdDialog),
            contentElement: document.querySelector("#Wait"),
            parent: angular.element(document.body),
            targetEvent: pData.ev,
            preserveScope: true,
            multiple: true
        });
    };
    function DialogCtrl(pScope, pDialog) {
        pScope.hide = function () {
            pDialog.hide();
        };
        pScope.cancel = function () {
            pDialog.cancel();
        };
    }
});