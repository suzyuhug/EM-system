<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class chanepw
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.usernamelabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.opasswordtextbox = New System.Windows.Forms.TextBox()
        Me.passwordtextbox = New System.Windows.Forms.TextBox()
        Me.spasswordtextbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "当前用户："
        '
        'usernamelabel
        '
        Me.usernamelabel.AutoSize = True
        Me.usernamelabel.Location = New System.Drawing.Point(114, 23)
        Me.usernamelabel.Name = "usernamelabel"
        Me.usernamelabel.Size = New System.Drawing.Size(78, 20)
        Me.usernamelabel.TabIndex = 1
        Me.usernamelabel.Text = "UserName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "旧密码："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "新密码："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "重复新密码："
        '
        'opasswordtextbox
        '
        Me.opasswordtextbox.Location = New System.Drawing.Point(162, 72)
        Me.opasswordtextbox.Name = "opasswordtextbox"
        Me.opasswordtextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.opasswordtextbox.Size = New System.Drawing.Size(155, 26)
        Me.opasswordtextbox.TabIndex = 5
        '
        'passwordtextbox
        '
        Me.passwordtextbox.Location = New System.Drawing.Point(162, 117)
        Me.passwordtextbox.Name = "passwordtextbox"
        Me.passwordtextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordtextbox.Size = New System.Drawing.Size(155, 26)
        Me.passwordtextbox.TabIndex = 6
        '
        'spasswordtextbox
        '
        Me.spasswordtextbox.Location = New System.Drawing.Point(162, 162)
        Me.spasswordtextbox.Name = "spasswordtextbox"
        Me.spasswordtextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.spasswordtextbox.Size = New System.Drawing.Size(155, 26)
        Me.spasswordtextbox.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(266, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 40)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "修  改"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chanepw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 263)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.spasswordtextbox)
        Me.Controls.Add(Me.passwordtextbox)
        Me.Controls.Add(Me.opasswordtextbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.usernamelabel)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "chanepw"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "密码修改"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents usernamelabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents opasswordtextbox As TextBox
    Friend WithEvents passwordtextbox As TextBox
    Friend WithEvents spasswordtextbox As TextBox
    Friend WithEvents Button1 As Button
End Class
