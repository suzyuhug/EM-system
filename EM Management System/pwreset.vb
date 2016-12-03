Imports System.Data.SqlClient

Public Class pwreset
    Private Sub pwreset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT UserID FROM Login_User", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox1.DataSource = ds.Tables("mytable")
        ComboBox1.DisplayMember = "UserID"
        'ComboBox1.ValueMember = "列2"

        cn.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Login_User", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "UserID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find(ComboBox1.Text)
        If rowIndex = -1 Then


        Else

            mynamelable.Text = Trim(dv(rowIndex)("UserName").ToString)
        End If
        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If passwordtextbox.Text = "" Then
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
            drow = ds.Tables("mytable").Rows.Find(ComboBox1.Text)
            Try
                drow("PassWord") = getMd5Hash(passwordtextbox.Text)

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")
                MessageBox.Show("密码重置成功！", "密码重置提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                passwordtextbox.Clear()
                spasswordtextbox.Clear()
                passwordtextbox.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If


    End Sub
End Class