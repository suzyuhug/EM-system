
Imports System.Data.SqlClient
Public Class ordelistedit
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql

    Private Sub ordelistedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from order_list", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Width = 130
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 60
        DataGridView1.Columns(4).Width = 100
        'DataGridView1.Columns(4).Width = 105

        cn.Close()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox6.Text = DataGridView1.Item(0, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox4.Text = DataGridView1.Item(3, i).Value.ToString()
        ComboBox2.Text = DataGridView1.Item(4, i).Value.ToString()
        TextBox5.Text = DataGridView1.Item(5, i).Value.ToString()

        Button5.Visible = False
        Button2.Visible = True
        Button3.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            cn = New SqlConnection(cnStr)

            Dim Sql As String = "select * from order_list where " & ComboBox1.Text & " like " & "'%" & TextBox1.Text & "%'"
            da = New SqlDataAdapter(Sql, cn) '表名
            ds = New DataSet()
            da.Fill(ds, "mytable")
            DataGridView1.DataSource = ds.Tables("mytable") '表名
            cn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("请输入型号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then

            MessageBox.Show("请输入料号，这个不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("请输入数量，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ComboBox2.Text = "" Then
            MessageBox.Show("请选择是否默认收料", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox5.Text = "" Then
            MessageBox.Show("请输入系统料号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from order_list", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("ID")}
            drow = ds.Tables("mytable").Rows.Find(TextBox6.Text)
            Try
                drow("型号") = TextBox2.Text
                drow("料号") = TextBox3.Text
                drow("数量") = TextBox4.Text
                drow("默认收料") = ComboBox2.Text
                drow("系统料号") = TextBox5.Text


                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")


                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox2.Text = ""
                Button5.Visible = True
                Button2.Visible = False
                Button3.Visible = False
                upda_Click(sender, e)
                MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("请输入型号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then

            MessageBox.Show("请输入料号，这个不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("请输入数量，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ComboBox2.Text = "" Then
            MessageBox.Show("请选择是否默认收料", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox5.Text = "" Then
            MessageBox.Show("请输入系统料号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from order_list", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            drow = ds.Tables("mytable").NewRow
            Try
                drow("型号") = TextBox2.Text
                drow("料号") = TextBox3.Text
                drow("数量") = TextBox4.Text
                drow("默认收料") = ComboBox2.Text
                drow("系统料号") = TextBox5.Text

                ds.Tables("mytable").Rows.Add(drow)
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                MessageBox.Show("数据保存成功，请插入下一条", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox2.Text = ""
                Button5.Visible = True
                Button2.Visible = False
                Button3.Visible = False
                upda_Click(sender, e)
            Catch ex As Exception
                MessageBox.Show("数据保存出错了，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        cn.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("你确定要删除数据，删除后将不可恢复，点击（确定）删除！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then


            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)

            Dim da As SqlCommand = New SqlCommand("delete from order_list WHERE ID='" & TextBox6.Text & "'", cn)
            cn.Open()
            da.ExecuteNonQuery()
            MessageBox.Show("数据删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            ComboBox2.Text = ""
            Button5.Visible = True
            Button2.Visible = False
            Button3.Visible = False
            upda_Click(sender, e)
            cn.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        ComboBox2.Text = ""
        Button5.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        upda_Click(sender, e)
    End Sub
End Class