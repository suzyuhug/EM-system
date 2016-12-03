Imports System.Data.SqlClient
Public Class sysuseradd
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If usertextbox.Text = "" Then
            MessageBox.Show("用户名不能为空！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            usertextbox.Focus()
        ElseIf passwordtextbox.Text <> spasswordtextbox.Text Then
            MessageBox.Show("两次输入的密码不一样！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            passwordtextbox.Focus()
        ElseIf nametextbox.Text = "" Then
            MessageBox.Show("输一个名字吧，不能为空！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        ElseIf photostextbox.Text = "" Then
            MessageBox.Show("电话号码不能为空！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else


            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Login_User", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")

            Dim dv As New DataView(ds.Tables("mytable"), "", "UserID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
            Dim rowIndex As Integer = dv.Find(usertextbox.Text)
            If rowIndex = -1 Then
                Dim drow As DataRow
                drow = ds.Tables("mytable").NewRow
                Try
                    drow("UserID") = usertextbox.Text
                    drow("UserName") = nametextbox.Text
                    drow("PassWord") = getMd5Hash(passwordtextbox.Text)
                    drow("Phone") = photostextbox.Text
                    drow("date") = Format(Now, "yyyy-MM-dd hh:mm ")
                    drow("记住密码") = "无"
                    drow("工单登记") = "无"
                    drow("投工单") = "无"
                    drow("工单上线") = "无"
                    drow("工单入库") = "无"
                    drow("终检完成") = "无"
                    drow("库位查询") = "无"
                    drow("借料管理") = "无"
                    drow("检查表打印") = "无"
                    drow("木箱上线") = "无"
                    drow("数据备份") = "无"
                    drow("工单目录") = "无"
                    drow("工单顺序") = "无"
                    drow("检查表编辑") = "无"
                    drow("借料数据") = "无"
                    drow("借料用户") = "无"
                    drow("用户注册") = "无"
                    drow("密码重置") = "无"
                    drow("用户权限") = "无"
                    drow("工单物料") = "无"
                    drow("工单数据") = "无"
                    drow("木箱管理") = "无"
                    drow("工单查询") = "无"
                    drow("工单明细") = "无"
                    drow("借料查询") = "无"

                    ds.Tables("mytable").Rows.Add(drow)
                    Dim cmdb As New SqlCommandBuilder(da)
                    da.Update(ds, "mytable")
                    MessageBox.Show("用户注册成功！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    usertextbox.Clear()
                    nametextbox.Clear()
                    passwordtextbox.Clear()
                    spasswordtextbox.Clear()
                    photostextbox.Clear()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            Else
                MessageBox.Show("用户名存在！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                usertextbox.Clear()
                usertextbox.Focus()
            End If
            cn.Close()
        End If

    End Sub
End Class