Imports System.Data.SqlClient
Imports System.Text

Public Class Userloginfrm
    Dim FrmPcName As String

    Dim Jzmm As String


    Private Sub loginbutton_Click(sender As Object, e As EventArgs) Handles loginbutton.Click
        Me.Hide() : msgboxfrm.Show()

        Application.DoEvents()

        If RemembCheckBox.Checked = False Then
            My.Settings.Reckset = False
        ElseIf RemembCheckBox.Checked = True Then
            My.Settings.Reckset = True
            My.Settings.UserSet = UserTextBox.Text
            My.Settings.PWSet = PwTextBox.Text
        End If
        Try
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Login_User", cn)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "Login_User")
            Dim dv As New DataView(ds.Tables("Login_User"), "", "UserID", DataViewRowState.CurrentRows)
            Dim rowIndex As Integer = dv.Find(UserTextBox.Text)

            If rowIndex = -1 Then
                msgboxfrm.Close()
                Me.Show()
                MessageBox.Show("此用户不存在，请联系管理员注册", "用户登录提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                UserTextBox.Clear() : PwTextBox.Clear() : UserTextBox.Focus()
                Exit Sub
            Else
                Dim pw As String = Trim(dv(rowIndex)("PassWord").ToString)
                Uservar = Trim(dv(rowIndex)("UserName").ToString)
                useridvar = Trim(dv(rowIndex)("UserID").ToString)
                passwordvar = Trim(dv(rowIndex)("PassWord").ToString)
                jzmm = Trim(dv(rowIndex)("记住密码").ToString)
                If getMd5Hash(PwTextBox.Text) = pw Then
                    If jzmm = "无" Then
                        My.Settings.Reckset = False
                        My.Settings.UserSet = ""
                        My.Settings.PWSet = ""
                    End If

                    logging_Click(sender, e)
                    mainfrm.Show()
                    Me.Close()
                Else
                    msgboxfrm.Close()
                    Me.Show()
                    MessageBox.Show("密码错误，请重试！", "用户登录提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    PwTextBox.Clear() : PwTextBox.Focus()

                End If

            End If
            cn.Close()


        Catch ex As Exception
            Dataerror.Show()
            Me.Close()
        End Try
        msgboxfrm.Close()

    End Sub



    Private Sub Userloginfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.Label1.BackColor = Color.Transparent
        Me.Label2.BackColor = Color.Transparent
        Me.Label3.BackColor = Color.Transparent

        If My.Settings.Reckset = True Then
            RemembCheckBox.Checked = True
            UserTextBox.Text = My.Settings.UserSet
            PwTextBox.Text = My.Settings.PWSet
        Else

        End If
        Label4.Text = "REV:" & Application.ProductVersion
        Label5.Text = My.Settings.DataSource
        Me.Label5.BackColor = Color.Transparent



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

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        DataSetup.Show()
        Me.Close()
    End Sub
End Class