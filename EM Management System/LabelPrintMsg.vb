Public Class LabelPrintMsg
    Dim i As Integer = 5
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If i >= 0 Then
            i = i - 1
            Button2.Text = "打印(" & i & ")"
        Else
            Timer1.Enabled = False


        End If
    End Sub

    Private Sub LabelPrintMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "准备打印标签 " & LabelButtionName
    End Sub
End Class