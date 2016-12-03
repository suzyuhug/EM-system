<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TouOrderControl
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ControlModel = New System.Windows.Forms.Label()
        Me.ControlPN = New System.Windows.Forms.Label()
        Me.ControlDate = New System.Windows.Forms.Label()
        Me.ControlUser = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ControlModel
        '
        Me.ControlModel.AutoSize = True
        Me.ControlModel.BackColor = System.Drawing.Color.Transparent
        Me.ControlModel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ControlModel.Location = New System.Drawing.Point(7, 12)
        Me.ControlModel.Name = "ControlModel"
        Me.ControlModel.Size = New System.Drawing.Size(83, 17)
        Me.ControlModel.TabIndex = 0
        Me.ControlModel.Text = "Ultra Flex 3.0"
        '
        'ControlPN
        '
        Me.ControlPN.AutoSize = True
        Me.ControlPN.BackColor = System.Drawing.Color.Transparent
        Me.ControlPN.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ControlPN.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ControlPN.Location = New System.Drawing.Point(42, 59)
        Me.ControlPN.Name = "ControlPN"
        Me.ControlPN.Size = New System.Drawing.Size(137, 21)
        Me.ControlPN.TabIndex = 1
        Me.ControlPN.Text = "TDN-866-999-02"
        '
        'ControlDate
        '
        Me.ControlDate.AutoSize = True
        Me.ControlDate.BackColor = System.Drawing.Color.Transparent
        Me.ControlDate.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ControlDate.Location = New System.Drawing.Point(20, 152)
        Me.ControlDate.Name = "ControlDate"
        Me.ControlDate.Size = New System.Drawing.Size(180, 17)
        Me.ControlDate.TabIndex = 2
        Me.ControlDate.Text = "时间：2015-03-05 16：22：22"
        '
        'ControlUser
        '
        Me.ControlUser.AutoSize = True
        Me.ControlUser.BackColor = System.Drawing.Color.Transparent
        Me.ControlUser.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ControlUser.Location = New System.Drawing.Point(20, 123)
        Me.ControlUser.Name = "ControlUser"
        Me.ControlUser.Size = New System.Drawing.Size(80, 17)
        Me.ControlUser.TabIndex = 3
        Me.ControlUser.Text = "用户：黄宇飞"
        '
        'TouOrderControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.EM_Management_System.My.Resources.Resources.OrderMouseLeave
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.ControlUser)
        Me.Controls.Add(Me.ControlDate)
        Me.Controls.Add(Me.ControlPN)
        Me.Controls.Add(Me.ControlModel)
        Me.Name = "TouOrderControl"
        Me.Size = New System.Drawing.Size(219, 189)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ControlModel As Label
    Friend WithEvents ControlPN As Label
    Friend WithEvents ControlDate As Label
    Friend WithEvents ControlUser As Label
End Class
