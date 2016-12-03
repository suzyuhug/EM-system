Imports System.Data.SqlClient
Public Class borrowedit
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sxbl As String
    Private Sub borrowedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        upda_Click(sender, e)
    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from borrow_table", cn) '表名
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String
        If ComboBox2.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else

            If ComboBox2.Text = "借料时间" Or ComboBox2.Text = "预计归还时间" Then
                Dim dtStart As DateTime = DateTimePicker4.Value
                Dim dtEnd As DateTime = DateTimePicker3.Value
                Dim s As Integer
                s = DateDiff(DateInterval.Day, dtEnd, dtStart)
                If s > 90 Then
                    MessageBox.Show("查询时间不能超过90天", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf s < 0 Then
                    MessageBox.Show("起始时间不能大于结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else




                    cn = New SqlConnection(cnStr)
                    sql = "select * from borrow_table where " & ComboBox2.Text & " BETWEEN '" & DateTimePicker3.Value & "' AND '" & DateTimePicker4.Value & "'"
                    'sql = "select * from borrow_table where " & ComboBox2.Text & " BETWEEN '2015/11/02 19:34:24' and '2015/11/04 19:34:24'"
                    da = New SqlDataAdapter(sql, cn) '表名
                    ds = New DataSet()
                    da.Fill(ds, "mytable")
                    DataGridView1.DataSource = ds.Tables("mytable") '表名
                    cn.Close()
                    Exit Sub
                End If
            ElseIf ComboBox2.Text = "状态" Then
                sxbl = ComboBox3.Text
                cn = New SqlConnection(cnStr)

                sql = "select * from borrow_table where " & ComboBox2.Text & " like " & "'%" & sxbl & "%'"
                da = New SqlDataAdapter(sql, cn) '表名
                ds = New DataSet()
                da.Fill(ds, "mytable")
                DataGridView1.DataSource = ds.Tables("mytable") '表名
                cn.Close()
            Else
                sxbl = TextBox5.Text
                cn = New SqlConnection(cnStr)

                sql = "select * from borrow_table where " & ComboBox2.Text & " like " & "'%" & sxbl & "%'"
                da = New SqlDataAdapter(sql, cn) '表名
                ds = New DataSet()
                da.Fill(ds, "mytable")
                DataGridView1.DataSource = ds.Tables("mytable") '表名
                cn.Close()
            End If






        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "借料时间" Or ComboBox2.Text = "预计归还时间" Then
            Label9.Visible = True
            Label10.Visible = True
            DateTimePicker3.Visible = True
            DateTimePicker4.Visible = True
            TextBox5.Visible = False
            ComboBox3.Visible = False
        ElseIf ComboBox2.Text = "状态" Then
            Label9.Visible = False
            Label10.Visible = False
            DateTimePicker3.Visible = False
            DateTimePicker4.Visible = False
            TextBox5.Visible = False
            ComboBox3.Visible = True
        Else
            Label9.Visible = False
            Label10.Visible = False
            DateTimePicker3.Visible = False
            DateTimePicker4.Visible = False
            TextBox5.Visible = True
            ComboBox3.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("请输入一个料号，这个不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text = "" Then

            MessageBox.Show("数量不能为空，请输入一个数量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text <> Int(TextBox2.Text) Then
            MessageBox.Show("请输入一个整数，不可为小数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("请输入借料人的工号，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("请输入借料人手机号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ComboBox1.Text = "" Then
            MessageBox.Show("请选择一个状态", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from borrow_table", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("借料单ID")}
            drow = ds.Tables("mytable").Rows.Find(TextBox6.Text)
            Try
                drow("料号") = TextBox1.Text
                drow("数量") = TextBox2.Text
                drow("借料人") = TextBox3.Text
                drow("电话") = TextBox4.Text
                drow("借料时间") = DateTimePicker1.Value
                drow("预计归还时间") = DateTimePicker2.Value
                drow("状态") = ComboBox1.Text
                drow("备注") = TextBox7.Text
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                ComboBox1.Text = ""

                upda_Click(sender, e)
                MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox6.Text = DataGridView1.Item(0, i).Value.ToString()
        TextBox1.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(3, i).Value.ToString()
        TextBox4.Text = DataGridView1.Item(4, i).Value.ToString()
        TextBox7.Text = DataGridView1.Item(8, i).Value.ToString()
        DateTimePicker2.Value = DataGridView1.Item(5, i).Value.ToString()
        DateTimePicker1.Value = DataGridView1.Item(6, i).Value.ToString()
        ComboBox1.Text = DataGridView1.Item(7, i).Value.ToString()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class