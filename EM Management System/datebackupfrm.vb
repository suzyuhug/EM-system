
Imports System.Data.SqlClient
Public Class datebackupfrm
    Dim i As Integer
    Dim WEBPath As String
    Dim FrmBackup As String


    Private Sub datebackupfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("WebPath")
        If rowIndex = -1 Then


            Exit Sub
        Else
            WEBPath = Trim(dv(rowIndex)("PortPath").ToString)


        End If
        cn.Close()

        BackupClick_Click(sender, e)
    End Sub

    Public Sub BackupClick_Click(sender As Object, e As EventArgs)

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("BackupPath")
        If rowIndex = -1 Then


            Exit Sub
        Else
            FrmBackup = Trim(dv(rowIndex)("PortPath").ToString)


        End If
        cn.Close()

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("你确定要备份数据，点击（确定）进行备份！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
            Label1.Text = "正在备份数据库..."
            Try
                jd_Click(sender, e)
                Application.DoEvents()
                Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
                Dim cn As SqlConnection = New SqlConnection(cnStr)
                Dim da As New SqlCommand("BACKUP DATABASE EMsystem TO DISK='" & FrmBackup & "EMsystem_Backup.bak" & "' WITH Format", cn)
                cn.Open()
                da.ExecuteNonQuery()
                cn.Close()
                do_Click(sender, e)

            Catch ex As Exception
                MessageBox.Show("数据备份失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("你确定要恢复数据，点击（确定）进行恢复！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
            MessageBox.Show("请手动去SQL Server Management Studio 去恢复数据，备份数据在根目录下！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Else
            Exit Sub
            Try


                Label1.Text = "正在恢复数据库..."
                jd_Click(sender, e)
                Application.DoEvents()
                Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
                Dim cn As SqlConnection = New SqlConnection(cnStr)
                Dim da As New SqlCommand("RESTORE DATABASE Test FROM DISK ='" & FrmBackup & "' WITH REPLACE, MOVE 'Test' TO 'c:\EMsystem.mdf', MOVE 'EMsystem_Log' TO 'c:\CafeSystem_log.ldf'", cn)
                cn.Open()
                da.ExecuteNonQuery()



                cn.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub jd_Click(sender As Object, e As EventArgs)
        Panel1.Visible = True

        Timer1.Enabled = True
        i = 0

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i = i + 1
        If i < 100 Then
            ProgressBar1.Value = i
        Else
            Label1.Text = "数据已处理完成"
            Timer1.Enabled = False

        End If
    End Sub

    Public Sub do_Click(sender As Object, e As EventArgs)
        Dim doURL
        Dim dlfilename
        Dim mm As String = Format(Now, "yyyyMMddhhmmss ")
        doURL = WEBPath & "/backup/EMsystem_Backup.bak"
        dlfilename = Application.StartupPath + "\\Backup\" & mm & ".bak"
        Dim wc As New System.Net.WebClient
        Try
            wc.DownloadFile(doURL, dlfilename)
            MessageBox.Show("数据已备份成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ProgressBar1.Value = 100
            Timer1.Enabled = False
        Catch ex As Exception
            MessageBox.Show("数据备份失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


End Class