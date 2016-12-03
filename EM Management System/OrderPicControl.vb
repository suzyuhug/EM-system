Public Class OrderPicControl
    Dim s As Boolean = True
    Private Sub OrderPicControl_click(sender As Object, e As EventArgs) Handles MyBase.Click
        If s = True Then
            Me.BackgroundImage = My.Resources.OrderPiccancel
            s = False
        ElseIf s = False Then

            Me.BackgroundImage = My.Resources.OrderPic
            s = True
        End If


    End Sub



    Public Property PicPNValue() As String
        Get
            Return Me.PicPN.Text
        End Get
        Set(ByVal PicPNValue As String)
            PicPN.Text = PicPNValue
        End Set
    End Property

    Public Property PicNumValue() As String
        Get
            Return Me.PicNum.Text
        End Get
        Set(ByVal PicNumValue As String)
            PicNum.Text = PicNumValue
        End Set
    End Property
    Public Property PicPathValue() As Image
        Get
            Return Me.PictureBox1.Image
        End Get
        Set(ByVal PicPathValue As Image)
            PictureBox1.Image = PicPathValue
        End Set
    End Property
End Class
