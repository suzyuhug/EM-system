Imports System.Data.SqlClient
Imports System.IO
Public Class updatemanfrm
    Dim FilePath As String
    Dim Pathlike As String
    Dim Qline As Integer
    Dim Curversion As String
    Dim FrmFTPPath, FrmFTPName, FrmFTPpw As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()

        OpenFileDialog1.Filter = "主程序文件(*.exe;)|*.exe|所有文件(*.*)|**"
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.FileName = "EM Management System"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then '如果打开窗口OK
            If OpenFileDialog1.FileName <> "" Then '如果有选中文件

                Pathlike = Path.GetDirectoryName(OpenFileDialog1.FileName)
                TextBox1.Text = OpenFileDialog1.FileName
                Qline = Pathlike.Length
                GetAllFile(Pathlike)
                Label4.Text = Getcurversion(OpenFileDialog1.FileName)




            End If
        End If


    End Sub
    Private Function Getcurversion(ByVal filepath As String) As String
        Try
            Curversion = FileVersionInfo.GetVersionInfo(filepath).FileVersion.ToString
            Return Curversion
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



    Private Sub GetAllFile(ByVal pathlike As String)
        Dim StrDir As String() = Directory.GetDirectories(pathlike)
        Dim StrFile As String() = Directory.GetFiles(pathlike)
        Dim i As Integer
        If StrFile.Length > 0 Then
            For i = 0 To StrFile.Length - 1
                Dim StrName As String = Path.GetFileName(StrFile(i))
                Dim Nameline As Integer = StrName.Length
                Dim Pathline As Integer = StrFile(i).Length
                Dim StrPath As String
                'StrPath = Mid(StrFile(i), Qline, pathlike - Nameline - Qline)
                StrPath = Mid(StrFile(i), Qline + 1, Pathline - Qline - Nameline)


                DataGridView1.Rows.Insert(0)
                DataGridView1.Rows(0).Cells(0).Value = StrName
                DataGridView1.Rows(0).Cells(2).Value = StrFile(i)
                DataGridView1.Rows(0).Cells(1).Value = StrPath
            Next
        End If
        If StrDir.Length > 0 Then
            For i = 0 To StrDir.Length - 1
                GetAllFile(StrDir(i)) '回调函数
            Next
        End If

    End Sub

    Private Sub updatemanfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = Application.ProductVersion
        Label4.Text = ""

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("FTPPath")
        If rowIndex = -1 Then


            Exit Sub
        Else
            FrmFTPPath = Trim(dv(rowIndex)("PortPath").ToString)

            FrmFTPName = Trim(dv(rowIndex)("PortUser").ToString)
            FrmFTPpw = Trim(dv(rowIndex)("PortPassWord").ToString)

        End If
        cn.Close()

    End Sub


    Private Sub 删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除ToolStripMenuItem.Click
        For Each r As DataGridViewRow In DataGridView1.SelectedRows
            If Not r.IsNewRow Then
                DataGridView1.Rows.Remove(r)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim upidid As String = Format(Now, "yyyyMMddhhmmss")
        If Label4.Text = "" Then
            MessageBox.Show("请选择要更新的主程序！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from NewREV_Table", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("ID")}
            drow = ds.Tables("mytable").Rows.Find("1")
            Try
                drow("NewRev") = Label4.Text
                drow("UpID") = upidid
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Exit Sub
            End Try
            cn.Close()

            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            Dim da1 As New SqlDataAdapter("select * from Update_History", cn1)
            Dim ds1 As New DataSet()
            da1.Fill(ds1, "mytable")
            Dim drow1 As DataRow
            drow1 = ds1.Tables("mytable").NewRow
            Try
                drow1("ID") = upidid
                drow1("REV") = Label4.Text
                drow1("Updateinfo") = TextBox2.Text
                ds1.Tables("mytable").Rows.Add(drow1)
                Dim cmdb As New SqlCommandBuilder(da1)
                da1.Update(ds1, "mytable")

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Exit Sub
            End Try

            cn1.Close()

            Dim cn2 As SqlConnection = New SqlConnection(cnStr)
                Dim da2 As New SqlDataAdapter("select * from UpCon_List", cn2)
                Dim ds2 As New DataSet()
            da2.Fill(ds2, "mytable")
            Dim drow2 As DataRow
            Dim x As Integer = 1
            For i As Integer = 0 To DataGridView1.RowCount - 1
                drow2 = ds2.Tables("mytable").NewRow
                Try
                    x = x + 1
                    Dim Fname, Fi, Upath As String
                    Fname = DataGridView1.Item(0, i).Value
                    Fi = DataGridView1.Item(1, i).Value
                    Upath = DataGridView1.Item(2, i).Value
                    drow2("UpID") = upidid
                    drow2("UpFileName") = Fname
                    drow2("UpFile") = Fi
                    drow2("UpPath") = Upath
                    drow2("FileID") = upidid & x & ".EM"
                    ds2.Tables("mytable").Rows.Add(drow2)
                    Dim cmdb As New SqlCommandBuilder(da2)
                    da2.Update(ds2, "mytable")
                    My.Computer.Network.UploadFile(Upath, FrmFTPPath & "/Update/" & upidid & x & ".EM", FrmFTPName, FrmFTPpw, True, 500)

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

            Next
            MessageBox.Show("更新程序已上传成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cn2.Close()







        End If
    End Sub
End Class