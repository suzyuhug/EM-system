Imports System.Text
Public Class DataSetup
    Private Sub DataSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ModUser, ModPsw As String
        Dim ByteUser, BytePsw As Byte()

        ByteUser = Convert.FromBase64String(My.Settings.DataUser)
        ModUser = Encoding.GetEncoding("gb2312").GetString(ByteUser)
        BytePsw = Convert.FromBase64String(My.Settings.DataPsw)
        ModPsw = Encoding.GetEncoding("gb2312").GetString(BytePsw)
        TextBox1.Text = My.Settings.DataSource
        TextBox2.Text = ModUser
        TextBox3.Text = ModPsw

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("数据不能为空，请输入数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            Dim ModUser, ModPsw As String
            Dim ByteUser, BytePsw As Byte()

            ByteUser = Encoding.Default.GetBytes(TextBox2.Text)
            ModUser = Convert.ToBase64String(ByteUser)
            BytePsw = Encoding.Default.GetBytes(TextBox2.Text)
            ModPsw = Convert.ToBase64String(BytePsw)
            My.Settings.DataSource = TextBox1.Text
            My.Settings.DataUser = ModUser
            My.Settings.DataPsw = ModPsw
            MessageBox.Show("数据保存成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TextBox1.Clear() : TextBox2.Clear() : TextBox3.Clear()



        End If
    End Sub
    Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Userloginfrm.Show()

    End Sub
End Class