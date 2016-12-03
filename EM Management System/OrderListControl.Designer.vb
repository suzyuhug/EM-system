<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderListControl
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListControlPN = New System.Windows.Forms.Label()
        Me.ListControlOrder = New System.Windows.Forms.Label()
        Me.ListControlNum = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListControlPN
        '
        Me.ListControlPN.AutoSize = True
        Me.ListControlPN.BackColor = System.Drawing.Color.Transparent
        Me.ListControlPN.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListControlPN.Location = New System.Drawing.Point(14, 23)
        Me.ListControlPN.Name = "ListControlPN"
        Me.ListControlPN.Size = New System.Drawing.Size(121, 20)
        Me.ListControlPN.TabIndex = 0
        Me.ListControlPN.Text = "TDN-866-999-02"
        '
        'ListControlOrder
        '
        Me.ListControlOrder.AutoSize = True
        Me.ListControlOrder.BackColor = System.Drawing.Color.Transparent
        Me.ListControlOrder.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListControlOrder.Location = New System.Drawing.Point(47, 77)
        Me.ListControlOrder.Name = "ListControlOrder"
        Me.ListControlOrder.Size = New System.Drawing.Size(137, 25)
        Me.ListControlOrder.TabIndex = 1
        Me.ListControlOrder.Text = "TDNM015251"
        '
        'ListControlNum
        '
        Me.ListControlNum.AutoSize = True
        Me.ListControlNum.BackColor = System.Drawing.Color.Transparent
        Me.ListControlNum.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListControlNum.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ListControlNum.Location = New System.Drawing.Point(162, 108)
        Me.ListControlNum.Name = "ListControlNum"
        Me.ListControlNum.Size = New System.Drawing.Size(47, 20)
        Me.ListControlNum.TabIndex = 2
        Me.ListControlNum.Text = "1 PCS"
        Me.ListControlNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OrderListControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.EM_Management_System.My.Resources.Resources.ListMouseLeave
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.ListControlNum)
        Me.Controls.Add(Me.ListControlOrder)
        Me.Controls.Add(Me.ListControlPN)
        Me.Name = "OrderListControl"
        Me.Size = New System.Drawing.Size(224, 141)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListControlPN As Label
    Friend WithEvents ListControlOrder As Label
    Friend WithEvents ListControlNum As Label
End Class
