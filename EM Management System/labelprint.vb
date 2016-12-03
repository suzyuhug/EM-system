Imports System.Data.SqlClient
Imports System.IO


Public Class labelprint
    Dim FrmWK As Integer

    Private Sub labelprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim CnStr As String = FrmDataSql
            Dim Cn As SqlConnection = New SqlConnection(CnStr)
            Cn.Open()
            Dim SEL As String = "SELECT DISTINCT TabUnit FROM LabelFromConfig"
            Dim Cmd As SqlCommand = New SqlCommand(SEL, Cn) '表名
            Dim Dr As SqlDataReader
            Dr = Cmd.ExecuteReader()
            If Dr.HasRows = 0 Then

            Else
                Dim FrmTabUnit As String
                While Dr.Read()

                    FrmTabUnit = Trim(Dr("TabUnit").ToString)
                    TabLabel.TabPages.Add(FrmTabUnit)


                End While
            End If
            Cn.Close()
        Catch ex As Exception
            Me.Close()
            Dataerror.Show()
        End Try
        FrmWK = DatePart("ww", Now, vbMonday)

        WklabelFrm.Text = "第 " & FrmWK & " 周"


    End Sub
    Private Sub labelprint_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TabLabel.Width = Me.Width - 40
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)
        Button1.Text = "1"
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        Button1.Text = "2"
    End Sub

    Private Sub TabLabel_Selected(sender As Object, e As TabControlEventArgs) Handles TabLabel.Selected
        'If e.TabPage.TabIndex = TabPage1.TabIndex Then
        ' If e.TabPage.Text = "出货标签" Then
        Button1.Text = e.TabPage.Text
        '  End If

        Dim CnStr As String = FrmDataSql
        Dim Cn As SqlConnection = New SqlConnection(CnStr)
        Cn.Open()
        Dim SEL As String = "SELECT * FROM LabelFromConfig WHERE TabUnit ='" & e.TabPage.Text & "'"
        Dim Cmd As SqlCommand = New SqlCommand(SEL, Cn) '表名
        Dim Dr As SqlDataReader
        Dr = Cmd.ExecuteReader()
        If Dr.HasRows = 0 Then

        Else
            Dim FrmButText As String
            Dim i As Integer = 0
            Dim s As Integer = 1
            While Dr.Read()
                If i < Int(TabLabel.Width / 130) Then
                    i = i + 1
                Else
                    i = 1
                    s = s + 1


                End If

                FrmButText = Trim(Dr("TabListName").ToString)


                Dim LabelButton As New Button
                LabelButton.Text = FrmButText


                LabelButton.Width = 100
                LabelButton.Height = 30
                LabelButton.Left = 120 * i - 80
                LabelButton.Top = 50 * s - 30

                e.TabPage.Controls.Add(LabelButton)
                AddHandler LabelButton.Click, AddressOf LabelButtonarrayclick

            End While
        End If
        Cn.Close()


    End Sub
    Private Sub LabelButtonarrayclick(ByVal sender As Object, ByVal e As EventArgs)
        LabelPrintMsg.Show()
        LabelButtionName = Me.Text


    End Sub

    Private Sub 页面配置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 页面配置ToolStripMenuItem.Click
        LabelconfigFrm.Show()

    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        If Trim(CopySNText.Text) Like "####F###" = True Then
            Dim FrmCopySNID As String = "SNCopyLabel"
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM LabelTemplate WHERE LabelName ='" & FrmCopySNID & "'", cn) '表名
            Dim ds As DataSet = New DataSet()


            da.Fill(ds)
            cn.Close()

            If ds.Tables(0).Rows.Count > 0 Then
                '将文件保存到硬盘文件c:\2.jpg   
                Dim imgData() As Byte
                imgData = ds.Tables(0).Rows(0).Item("LabelTemplate")
                Dim fs As FileStream
                fs = File.Create("D:\Temp.Lab", imgData.Length - 1)
                fs.Write(imgData, 0, imgData.Length - 1)
                fs.Close()
            End If














        Else
            MessageBox.Show("序列号格式应为 ####F### ,请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CopySNText.Clear() : CopySNText.Focus()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles FrmSNPrintButton.Click

    End Sub
End Class