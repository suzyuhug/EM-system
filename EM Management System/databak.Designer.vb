<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class databak
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Me.cmdBackup = New System.Windows.Forms.Button()
        Me.cmdRestore = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdBackup
        '
        Me.cmdBackup.Location = New System.Drawing.Point(66, 163)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(106, 38)
        Me.cmdBackup.TabIndex = 0
        Me.cmdBackup.Text = "备份"
        Me.cmdBackup.UseVisualStyleBackColor = True
        '
        'cmdRestore
        '
        Me.cmdRestore.Location = New System.Drawing.Point(295, 163)
        Me.cmdRestore.Name = "cmdRestore"
        Me.cmdRestore.Size = New System.Drawing.Size(106, 38)
        Me.cmdRestore.TabIndex = 1
        Me.cmdRestore.Text = "恢复"
        Me.cmdRestore.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(164, 53)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(41, 12)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "Label1"
        '
        'databak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 251)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.cmdRestore)
        Me.Controls.Add(Me.cmdBackup)
        Me.MaximizeBox = False
        Me.Name = "databak"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "数据备份与恢复"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdBackup As Button
    Friend WithEvents cmdRestore As Button
    Friend WithEvents lblProgress As Label
End Class
