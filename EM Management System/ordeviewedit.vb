Imports System.Data.SqlClient

Public Class ordeviewedit
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Private Sub ordeviewedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT 型号 FROM Order_list", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox2.DataSource = ds.Tables("mytable")
        ComboBox2.DisplayMember = "型号"
        ComboBox2.Text = ""
        'ComboBox1.ValueMember = "列2"
        cn.Close()
    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from order_view", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(1).Width = 160
        DataGridView1.Columns(2).Width = 115
        'DataGridView1.Columns(3).Width = 370
        'DataGridView1.Columns(4).Width = 105

        cn.Close()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value.ToString()
        ComboBox2.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox4.Text = DataGridView1.Item(3, i).Value.ToString()
        TextBox5.Text = DataGridView1.Item(4, i).Value.ToString()
        ComboBox3.Text = DataGridView1.Item(5, i).Value.ToString()
        ComboBox4.Text = DataGridView1.Item(6, i).Value.ToString()
        ComboBox5.Text = DataGridView1.Item("状态", i).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("请选择要更新的工单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("请输入编号，不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ComboBox2.Text = "" Then
            MessageBox.Show("请选择型号，不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("请输入料号，不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("请输入数量，不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ComboBox3.Text = "" Then
            MessageBox.Show("请选择工单上线状态，不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ComboBox4.Text = "" Then
            MessageBox.Show("请选择工单入库状态，不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from order_view", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工单号")}
            drow = ds.Tables("mytable").Rows.Find(TextBox4.Text)
            Try
                drow("编号") = TextBox2.Text
                drow("型号") = ComboBox2.Text
                drow("料号") = TextBox3.Text

                drow("数量") = TextBox5.Text
                drow("工单上线") = ComboBox3.Text
                drow("工单入库") = ComboBox4.Text
                drow("状态") = ComboBox5.Text

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")


                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""

                upda_Click(sender, e)
                MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            cn = New SqlConnection(cnStr)

            Dim Sql As String = "select * from order_view where " & ComboBox1.Text & " like " & "'%" & TextBox1.Text & "%'"
            da = New SqlDataAdapter(Sql, cn) '表名
            ds = New DataSet()
            da.Fill(ds, "mytable")
            DataGridView1.DataSource = ds.Tables("mytable") '表名
            cn.Close()
        End If
    End Sub


End Class