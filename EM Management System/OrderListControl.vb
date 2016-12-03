Public Class OrderListControl
    Dim i As Boolean
    Private Sub OrderListControl_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter, ListControlOrder.MouseEnter, ListControlNum.MouseEnter, ListControlPN.MouseEnter
        If i = True Then
            Me.BackgroundImage = My.Resources.OKMouseEnter
        Else

            Me.BackgroundImage = My.Resources.ListMouseEnter

        End If
    End Sub
    Private Sub OrderListControl_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        If i = True Then
            Me.BackgroundImage = My.Resources.OKMouseLeave
        Else

            Me.BackgroundImage = My.Resources.ListMouseLeave
        End If

    End Sub

    Private Sub OrderListControl_click(sender As Object, e As EventArgs) Handles MyBase.Click
        i = True
        Me.BackgroundImage = My.Resources.OKMouseEnter
    End Sub

    Public Property ListPNValue() As String
        Get
            Return Me.ListControlPN.Text
        End Get
        Set(ByVal ListPNValue As String)
            ListControlPN.Text = ListPNValue
        End Set
    End Property

    Public Property ListOrderValue() As String
        Get
            Return Me.ListControlOrder.Text
        End Get
        Set(ByVal ListOrderValue As String)
            ListControlOrder.Text = ListOrderValue
        End Set
    End Property
    Public Property ListNumValue() As String
        Get
            Return Me.ListControlNum.Text
        End Get
        Set(ByVal ListNumValue As String)
            ListControlNum.Text = ListNumValue
        End Set
    End Property

End Class
