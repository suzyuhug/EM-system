Public Class mControl1

    Public Property value() As String
        Get
            Return Me.Button1.Text
        End Get
        Set(ByVal value As String)
            Button1.Text = value
        End Set
    End Property

End Class
