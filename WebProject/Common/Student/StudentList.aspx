<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="WebProject.Common.Student.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/JS/jquery-3.5.1.min.js"></script>
    <script src="js/StudentList.js"></script>
</head>
<body>
<form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    <tr>
                        <td>账号</td>
                        <td>姓名</td>
                        <td>密码</td>
                    </tr>
                </thead>
                <tbody id="tableDate">
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
