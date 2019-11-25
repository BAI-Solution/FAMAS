_app.service("Table", function () {
    this.Load = function (pTbl, pData, pColumnDefs, pDisabled, pMultiple) {
        var _tbl = pTbl.DataTable({
            destroy: true,
            data: pData,
            paging: true,
            ordering: true,
            info: false,
            stateSave: true,
            scrollX: true,
            scrollCollapse: pDisabled,
            scrollY: "400px",
            language: {
                emptyTable: !pDisabled ? "Please wait" : "No data available in table",
                decimal: ",",
                thousands: "."
            },
            columnDefs: pColumnDefs,
            select: {
                style: pMultiple ? "multi" : "single",
                selector: "td:first-child"
            }
        });
    };
});