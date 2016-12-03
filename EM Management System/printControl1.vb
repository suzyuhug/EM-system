Public Class printControl1
    Dim bhcon As String
    Event prtClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Private Sub printControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Parent = Button1
        PictureBox3.Location = New Point(2, -23)
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Parent = Button1
        PictureBox4.Location = New Point(127, -14)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent prtClick(Me, e)
        If PictureBox2.Visible = False Then
            PictureBox2.Visible = True
            PictureBox4.Visible = True
        ElseIf PictureBox2.Visible = True Then
            PictureBox2.Visible = False
            PictureBox4.Visible = False
        End If
    End Sub
    Public Property value() As String
        Get
            Return Me.Button1.Text
        End Get
        Set(ByVal value As String)
            Button1.Text = value
        End Set
    End Property
    Public Property modelid() As String
        Get
            Return Me.TextBox1.Text
        End Get
        Set(ByVal modelid As String)
            TextBox1.Text = modelid
        End Set
    End Property
    Public Property bhid() As String
        Get
            Return bhcon
        End Get
        Set(ByVal bhid As String)
            bhcon = bhid
        End Set
    End Property
End Class
