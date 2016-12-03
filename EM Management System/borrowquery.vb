
Imports System.Data.SqlClient
Public Class borrowquery
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sxbl As String
    Private Sub borrowquery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
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
End Class