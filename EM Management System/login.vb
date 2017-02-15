Imports System.Data.SqlClient
Imports System.Text
Public Class login
    Dim userid As String
    Dim FrmPcName As String

    Dim Revid As String
    Dim Idid As String
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.BackColor = Color.Transparent
        Label1.Text = "正在加载主程序..."

        updateclass.UpdateFrom("EM-System")
        'Application.DoEvents()
        'Threading.Thread.Sleep(5000)
        ' Application.DoEvents()




    End Sub
    Public Sub sqltest_Click(sender As Object, e As EventArgs)
        Timer1.Enabled = False
        Dim ModUser, ModPsw As String
        Dim ByteUser, BytePsw As Byte()
        Label1.Text = "连接服务器..."
        Application.DoEvents()
        Try


            ByteUser = Convert.FromBase64String(My.Settings.DataUser)
            ModUser = Encoding.GetEncoding("gb2312").GetString(ByteUser)
            BytePsw = Convert.FromBase64String(My.Settings.DataPsw)
            ModPsw = Encoding.GetEncoding("gb2312").GetString(BytePsw)
            FrmDataSql = "Data Source=" & My.Settings.DataSource & ";Initial Catalog=" & My.Settings.DataCatalog & ";Integrated Security=False;User ID=" & ModUser & ";Password=" & ModPsw & ";"

            userid = Environment.GetEnvironmentVariable("USERNAME")
            'upda_Click(sender, e)
            ADlogin_Click(sender, e)

        Catch ex As Exception
            Label1.Text = "服务器连接失败！"
            MessageBox.Show("数据库连接失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub



    Public Sub ADlogin_Click(sender As Object, e As EventArgs)

        Label1.Text = "用户验证中..."
        Application.DoEvents()
        Try
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Login_User", cn)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "Login_User")
            Dim dv As New DataView(ds.Tables("Login_User"), "", "UserID", DataViewRowState.CurrentRows)
            Dim rowIndex As Integer = dv.Find(userid)

            If rowIndex = -1 Then

                Userloginfrm.Show()


            Else

                Uservar = Trim(dv(rowIndex)("UserName").ToString)
                useridvar = Trim(dv(rowIndex)("UserID").ToString)
                passwordvar = Trim(dv(rowIndex)("PassWord").ToString)
                logging_Click(sender, e)

                mainfrm.Show()



            End If
            cn.Close()
            Me.Close()

        Catch ex As Exception
            Dataerror.Show()
            Me.Close()
        End Try

    End Sub
    Public Sub logging_Click(sender As Object, e As EventArgs)

        FrmPcName = SystemInformation.ComputerName

        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Logging", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow

        drow = ds.Tables("mytable").NewRow
        Try

            drow("ComputerName") = FrmPcName
            drow("LoginTimeInt") = Format(Now, "yyyy-MM-dd hh:mm")
            drow("UserName") = Uservar

            ds.Tables("mytable").Rows.Add(drow)
            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()

    End Sub
    'Public Sub upda_Click(sender As Object, e As EventArgs)
    '    Label1.Text = "正在检查更新..."
    '    Application.DoEvents()
    '    Dim info As String = "1111"
    '    Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
    '    Dim cn As SqlConnection = New SqlConnection(cnStr)
    '    Dim da As SqlDataAdapter = New SqlDataAdapter("select * from NewREV_Table", cn) '表名
    '    Dim ds As DataSet = New DataSet()
    '    da.Fill(ds, "mytable")

    '    Dim dv As New DataView(ds.Tables("mytable"), "", "ID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
    '    Dim rowIndex As Integer = dv.Find("1")
    '    If rowIndex = -1 Then
    '    Else
    '        Revid = Trim(dv(rowIndex)("NewRev").ToString)
    '        Idid = Trim(dv(rowIndex)("UpID").ToString)
    '    End If

    '    Dim cn1 As SqlConnection = New SqlConnection(cnStr)
    '    Dim da1 As SqlDataAdapter = New SqlDataAdapter("select * from Update_History", cn1) '表名
    '    Dim ds1 As DataSet = New DataSet()
    '    da1.Fill(ds1, "mytable")
    '    Dim dv1 As New DataView(ds1.Tables("mytable"), "", "ID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
    '    Dim rowIndex1 As Integer = dv1.Find(Idid)
    '    If rowIndex1 = -1 Then
    '    Else
    '        info = Trim(dv1(rowIndex1)("Updateinfo").ToString)
    '    End If


    '    If Revid <> Application.ProductVersion Then
    '        msgboxfrm.Close()
    '        MessageBox.Show("发现新版本  " & Revid & " ，请立即更新！" & vbCr & vbCr & "更新日志：" & vbCr & info, "系统更新", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '        If Dir(Application.StartupPath + "\Update.exe") <> "" Then
    '            Process.Start(Application.StartupPath + "\Update.exe")
    '            End
    '        Else
    '            MessageBox.Show("更新程序不存在，请通知管理员", "系统更新", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    End If
    '    cn.Close()
    '    cn1.Close()
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sqltest_Click(sender, e)

    End Sub
End Class