Public Class snControl
    Private Sub snControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Public Property SNID() As String
        Get
            Return Me.Label1.Text
        End Get
        Set(ByVal SNID As String)
            Label1.Text = SNID
        End Set
    End Property
    Public Property modelid() As String
        Get
            Return Me.Label2.Text
        End Get
        Set(ByVal modelid As String)
            Label2.Text = modelid
        End Set
    End Property
    Public Property orderid() As String
        Get
            Return Me.Label3.Text
        End Get
        Set(ByVal orderid As String)
            Label3.Text = orderid
        End Set
    End Property


End Class
