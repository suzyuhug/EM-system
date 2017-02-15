Imports System.Data.SqlClient
Imports System.IO

Public Class updateclass
    Shared AppName As String = Nothing
    Public Shared ReadOnly CnStr As String = "server=suznt004;user id=andy;password=123;initial catalog=Update OnLine;Connect Timeout=5"


    Public Shared Function ExcuteDataSet(ByVal Sql As String) As DataSet
        Try
            Dim cn As SqlConnection = New SqlConnection(CnStr)
            Dim cmd As SqlCommand = New SqlCommand(Sql, cn)
            Dim dp As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            cn.Open()
            dp.Fill(ds)
            cn.Close()
            cn.Dispose()
            Return ds
        Catch
            Return Nothing
        End Try
    End Function
    Public Shared Sub UpdateFrom(ByVal Name As String)
        AppName = Name
        Dim str As String = Update()
        If Not str Is Nothing Then
            If DialogResult.Yes = MessageBox.Show($"更新内容：\n\n{str}", "发现新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) Then
                If loadUpdate() Then
                    Application.Exit()
                End If
            End If
        End If
    End Sub



    Public Shared Function loadUpdate() As Boolean
        Dim path As String = $"{Application.StartupPath.ToString()}\\Update.exe"
        If Not File.Exists(path) Then
            Dim sql As String = "exec sp_GetUpdate"
            Dim ds As DataSet = New DataSet()
            ds = ExcuteDataSet(sql)
            If Not ds Is Nothing Then
                Dim Files() As Byte = CType(ds.Tables(0).Rows(0)("Application"), Byte())
                Dim paths As String = $"{Application.StartupPath.ToString()}\\Update.exe"
                Dim bw As BinaryWriter = New BinaryWriter(File.Open(paths, FileMode.OpenOrCreate))
                bw.Write(Files)
                bw.Close()
            End If
        End If
        If File.Exists(path) Then
            Dim ID As String = Process.GetCurrentProcess().ProcessName
            Dim message As String = $"{AppName}#{ID}"
            Process.Start(path, message)
            Return True
        Else
            MessageBox.Show("更新程序不存在！", "在线更新程序", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If


    End Function


    'Error: Converting Methods, Functions and Constructors 
    'Error: Converting If-Else-End If Blocks 

    Public Shared Function Update() As String

        Dim sql As String = $"exec sp_REVdes '{AppName}'"
        Dim ds As DataSet = New DataSet()
        Dim rev As String, des As String
        ds = ExcuteDataSet(sql)
        If (ds.Tables(0).Rows.Count > 0) Then

            rev = ds.Tables(0).Rows(0)("Versions").ToString()
            des = ds.Tables(0).Rows(0)("Description").ToString()

            If (rev <> Application.ProductVersion) Then

                Return des

            Else

                Return Nothing
            End If

        Else

            Return Nothing
        End If
    End Function



End Class
