Public Class TouOrderControl
    Dim ControlID As String
    Event BtnClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Private Sub TouOrderControl_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter, ControlModel.MouseEnter, ControlPN.MouseEnter, ControlDate.MouseEnter, ControlUser.MouseEnter

        Me.BackgroundImage = My.Resources.OrderMouseEnter


    End Sub
    Private Sub TouOrderControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Me.BackgroundImage = My.Resources.OrderMouseLeave

    End Sub
    Public Property ModelValue() As String
        Get
            Return Me.ControlModel.Text
        End Get
        Set(ByVal ModelValue As String)
            ControlModel.Text = ModelValue
        End Set
    End Property
    Public Property PNValue() As String
        Get
            Return Me.ControlPN.Text
        End Get
        Set(ByVal PNValue As String)
            ControlPN.Text = PNValue
        End Set
    End Property
    Public Property UserValue() As String
        Get
            Return Me.ControlUser.Text
        End Get
        Set(ByVal UserValue As String)
            ControlUser.Text = UserValue
        End Set
    End Property
    Public Property DateValue() As String
        Get
            Return Me.ControlDate.Text
        End Get
        Set(ByVal DateValue As String)
            ControlDate.Text = DateValue
        End Set
    End Property

    Public Property IDValue() As String
        Get
            Return Me.ControlID
        End Get
        Set(ByVal IDValue As String)
            ControlID = IDValue
        End Set
    End Property

    Private Sub TouOrderControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
