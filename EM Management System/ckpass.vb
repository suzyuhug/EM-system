Public Class ckpass
    Dim i As String = "0"
    Dim gdbh As String
    Dim pnid As String
    Dim num As String
    Event BtnClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Property value() As String
        Get
            Return Me.Button1.Text
        End Get
        Set(ByVal value As String)
            Button1.Text = value
        End Set
    End Property

    Public Property piclog() As String
        Get
            Return Me.i
        End Get
        Set(ByVal piclog As String)
            i = piclog
        End Set
    End Property
    Public Property gongdan() As String
        Get
            Return Me.gdbh
        End Get
        Set(ByVal gongdan As String)
            gdbh = gongdan
        End Set
    End Property
    Public Property parin() As String
        Get
            Return Me.pnid
        End Get
        Set(ByVal parin As String)
            pnid = parin
        End Set
    End Property
    Public Property shuliang() As String
        Get
            Return Me.num
        End Get
        Set(ByVal shuliang As String)
            num = shuliang
        End Set
    End Property



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent BtnClick(Me, e)
        If PictureBox1.Visible = True Then
            PictureBox1.Visible = False
            i = "0"
        ElseIf PictureBox1.Visible = False Then

            PictureBox1.Visible = True
            i = "1"
        End If
    End Sub

    Private Sub ckpass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
