Imports System.Data.SqlClient
Public Class chanepw
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If getMd5Hash（opasswordtextbox.Text） <> passwordvar Then
            MessageBox.Show("密码错误！", "密码重置提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            opasswordtextbox.Clear()
            opasswordtextbox.Focus()
        ElseIf passwordtextbox.Text = "" Then
            MessageBox.Show("密码不能为空！", "密码重置提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            passwordtextbox.Focus()
        ElseIf passwordtextbox.Text <> spasswordtextbox.Text Then
            MessageBox.Show("两次密码不一样！", "密码重置提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Login_User", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("UserID")}
            drow = ds.Tables("mytable").Rows.Find(useridvar)
            Try
                drow("PassWord") = getMd5Hash(passwordtextbox.Text)

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")
                MessageBox.Show("密码修改成功！", "密码重置提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                passwordtextbox.Clear()
                spasswordtextbox.Clear()
                opasswordtextbox.Clear()

                opasswordtextbox.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If

    End Sub

    Private Sub chanepw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usernamelabel.Text = Uservar
    End Sub
End Class