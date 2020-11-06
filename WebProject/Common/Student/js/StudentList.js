!(function () {
    $(function () {

        href = "/Common/Student/ajax/HandlerStndent.ashx"
        bindDate();

    })
    function bindDate() {
        debugger
        var parameters = {
            cmd: "getStudentList",
            aaa: "666"
        }
        $.post(href, parameters, function (jsonData) {

            if (jsonData.state == "success") {
                var trs = "";
                $(jsonData.data.DataList).each(function (index) {
                    trs += "<tr>";
                    trs += "<td>" + this.UserName + "</td>";
                    trs += "<td>" + this.Name + "</td>";
                    trs += "<td>" + this.Powd + "</td>";
                    trs += "</tr>";
                })
                $("#tableDate").html(trs);
            }
            else {
                alert("", jsonData.catch1, "error");
            }
        })
    }
})();