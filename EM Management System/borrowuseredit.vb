Imports System.Data.SqlClient
Public Class borrowuseredit
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sxbl As String
    Private Sub borrowuseredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from borrow_user", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(1).Width = 160
        'DataGridView1.Columns(2).Width = 160
        'DataGridView1.Columns(3).Width = 370
        'DataGridView1.Columns(4).Width = 105

        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            cn = New SqlConnection(cnStr)

            Dim Sql As String = "select * from borrow_user where " & ComboBox1.Text & " like " & "'%" & TextBox1.Text & "%'"
            da = New SqlDataAdapter(Sql, cn) '表名
            ds = New DataSet()
            da.Fill(ds, "mytable")
            DataGridView1.DataSource = ds.Tables("mytable") '表名
            cn.Close()
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value.ToString()
        TextBox7.Text = DataGridView1.Item(0, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox4.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox5.Text = DataGridView1.Item(3, i).Value.ToString()
        TextBox6.Text = DataGridView1.Item(4, i).Value.ToString()
        Button2.Visible = False
        Button3.Visible = True
        Button5.Visible = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("请输入工号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text <> TextBox7.Text Then
            MessageBox.Show("工号不可以更改，可以进行插入用户", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then

            MessageBox.Show("请输入姓名，这个不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("请输入电话号码，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox6.Text = "" Then
            MessageBox.Show("请输入部门，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Else
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from borrow_user", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工号")}
            drow = ds.Tables("mytable").Rows.Find(TextBox2.Text)
            Try
                drow("工号") = TextBox2.Text

                drow("姓名") = TextBox3.Text
                drow("电话") = TextBox4.Text
                drow("邮箱") = TextBox5.Text
                drow("部门") = TextBox6.Text
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")


                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                Button2.Visible = True
                Button3.Visible = False
                Button5.Visible = False

                upda_Click(sender, e)
                MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MessageBox.Show("你确定要删除数据，删除后将不可恢复，点击（确定）删除！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then


            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)

            Dim da As SqlCommand = New SqlCommand("delete from borrow_user WHERE 工号='" & TextBox7.Text & "'", cn)
            cn.Open()
            da.ExecuteNonQuery()
            MessageBox.Show("数据删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            Button2.Visible = True
            Button3.Visible = False
            Button5.Visible = False
            upda_Click(sender, e)
            cn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("请输入工号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        ElseIf TextBox3.Text = "" Then

            MessageBox.Show("请输入姓名，这个不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("请输入电话号码，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox6.Text = "" Then
            MessageBox.Show("请输入部门，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from borrow_user", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            drow = ds.Tables("mytable").NewRow
            Try
                drow("工号") = TextBox2.Text

                drow("姓名") = TextBox3.Text
                drow("电话") = TextBox4.Text
                drow("邮箱") = TextBox5.Text
                drow("部门") = TextBox6.Text
                ds.Tables("mytable").Rows.Add(drow)
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                MessageBox.Show("数据保存成功，请插入下一条", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                Button2.Visible = True
                Button3.Visible = False
                Button5.Visible = False
                upda_Click(sender, e)
            Catch ex As Exception
                MessageBox.Show("数据保存出错了，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        cn.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        Button2.Visible = True
        Button3.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class