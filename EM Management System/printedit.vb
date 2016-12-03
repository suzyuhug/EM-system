Imports System.Data.SqlClient
Public Class printedit
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub printedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
        combo_Click(sender, e)
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox4.Text = DataGridView1.Item(0, i).Value.ToString()
        ComboBox1.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox1.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(3, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(4, i).Value.ToString()
        Button2.Visible = False
        Button1.Visible = True
        Button4.Visible = True

    End Sub

    Public Sub combo_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT 型号 FROM Order_list", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox1.DataSource = ds.Tables("mytable")
        ComboBox1.DisplayMember = "型号"
        'ComboBox1.ValueMember = "列2"
        cn.Close()
        ComboBox1.Text = ""
    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from print_list", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Width = 160
        DataGridView1.Columns(2).Width = 160
        DataGridView1.Columns(3).Width = 370
        DataGridView1.Columns(4).Width = 105

        cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择型号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox1.Text = "" Then

            MessageBox.Show("请输入一个名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("请输入文件路径，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf textbox3.Text = "" Then
            MessageBox.Show("请输入一下默认要打印的数量", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text <> Int(TextBox3.text) Then
            MessageBox.Show("请输入一个整数，不可为小数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from print_list", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            drow = ds.Tables("mytable").NewRow
            Try
                drow("型号") = ComboBox1.Text
                drow("名称") = TextBox1.Text
                drow("路径") = TextBox2.Text
                drow("数量") = TextBox3.Text
                ds.Tables("mytable").Rows.Add(drow)
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                MessageBox.Show("数据保存成功，请插入下一条", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.Text = ""
                upda_Click(sender, e)
            Catch ex As Exception
                MessageBox.Show("数据保存出错了，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        cn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        Button2.Visible = True
        Button4.Visible = False
        Button1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择型号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox1.Text = "" Then

            MessageBox.Show("请输入一个名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("请输入文件路径，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("请输入一下默认要打印的数量", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text <> Int(TextBox3.Text) Then
            MessageBox.Show("请输入一个整数，不可为小数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from print_list", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("ID")}
            drow = ds.Tables("mytable").Rows.Find(TextBox4.Text)
            Try
                drow("型号") = ComboBox1.Text
                drow("名称") = TextBox1.Text
                drow("路径") = TextBox2.Text
                drow("数量") = TextBox3.Text

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.Text = ""
                Button2.Visible = True
                Button1.Visible = False
                Button4.Visible = False
                upda_Click(sender, e)
                MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MessageBox.Show("你确定要删除数据，删除后将不可恢复，点击（确定）删除！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then


            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)

            Dim da As SqlCommand = New SqlCommand("delete from print_list WHERE ID='" & TextBox4.Text & "'", cn)
            cn.Open()
            da.ExecuteNonQuery()
            MessageBox.Show("数据删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.Text = ""
            Button2.Visible = True
            Button1.Visible = False
            Button4.Visible = False
            upda_Click(sender, e)
            cn.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class