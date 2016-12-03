Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class ordercxfrm
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Private Sub ordercxfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
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
        DataGridView1.Columns(0).Width = 125
        DataGridView1.Columns(2).Width = 125
        cn.Close()
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
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




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox2.Visible = True
        Dim MyDesktop As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim mm As String = Format(Now, "yyyyMMddhhmmss")
        Dim xlApp As New Excel.Application
        '添加一个工作簿 
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
        '添加一个表
        Dim xlWorkSheet As Excel.Worksheet = xlWorkBook.Sheets("sheet1")
        '显示Excel
        xlApp.Visible = False
        '用于将DataGridView中的表赋值到Excel中的表中
        Dim i As Integer
        Dim j As Integer
        Dim Cols As Integer
        For Cols = 1 To DataGridView1.Columns.Count
            xlWorkSheet.Cells(1, Cols) = DataGridView1.Columns(Cols - 1).HeaderText
        Next
        '将DataGridView表格的内容导入到Excel表中
        For i = 0 To DataGridView1.RowCount - 1
            'DataGridView中的表头行不做为行数来计算，并且，有一空行所以减
            For j = 0 To DataGridView1.ColumnCount - 1
                xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
            Next
        Next
        xlApp.ActiveWorkbook.SaveAs(MyDesktop & "\" & mm & "1.xls")
        xlApp.Workbooks.Close()
        xlApp.Quit()
        MessageBox.Show("数据已导出到桌面" & mm & "1.xls", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        PictureBox2.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class