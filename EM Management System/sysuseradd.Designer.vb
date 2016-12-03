<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sysuseradd
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.usertextbox = New System.Windows.Forms.TextBox()
        Me.passwordtextbox = New System.Windows.Forms.TextBox()
        Me.spasswordtextbox = New System.Windows.Forms.TextBox()
        Me.nametextbox = New System.Windows.Forms.TextBox()
        Me.photostextbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(109, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "用户名："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "密码："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(61, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "再次输入密码："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(125, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 21)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "姓名："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(93, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 21)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "手机号码："
        '
        'usertextbox
        '
        Me.usertextbox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.usertextbox.Location = New System.Drawing.Point(213, 33)
        Me.usertextbox.Name = "usertextbox"
        Me.usertextbox.Size = New System.Drawing.Size(168, 26)
        Me.usertextbox.TabIndex = 5
        '
        'passwordtextbox
        '
        Me.passwordtextbox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.passwordtextbox.Location = New System.Drawing.Point(213, 79)
        Me.passwordtextbox.Name = "passwordtextbox"
        Me.passwordtextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordtextbox.Size = New System.Drawing.Size(168, 26)
        Me.passwordtextbox.TabIndex = 6
        '
        'spasswordtextbox
        '
        Me.spasswordtextbox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.spasswordtextbox.Location = New System.Drawing.Point(213, 124)
        Me.spasswordtextbox.Name = "spasswordtextbox"
        Me.spasswordtextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.spasswordtextbox.Size = New System.Drawing.Size(168, 26)
        Me.spasswordtextbox.TabIndex = 7
        '
        'nametextbox
        '
        Me.nametextbox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.nametextbox.Location = New System.Drawing.Point(213, 166)
        Me.nametextbox.Name = "nametextbox"
        Me.nametextbox.Size = New System.Drawing.Size(168, 26)
        Me.nametextbox.TabIndex = 8
        '
        'photostextbox
        '
        Me.photostextbox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.photostextbox.Location = New System.Drawing.Point(213, 213)
        Me.photostextbox.Name = "photostextbox"
        Me.photostextbox.Size = New System.Drawing.Size(168, 26)
        Me.photostextbox.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(343, 258)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 37)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "注  册"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'sysuseradd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 316)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.photostextbox)
        Me.Controls.Add(Me.nametextbox)
        Me.Controls.Add(Me.spasswordtextbox)
        Me.Controls.Add(Me.passwordtextbox)
        Me.Controls.Add(Me.usertextbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "sysuseradd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "用户注册"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents usertextbox As TextBox
    Friend WithEvents passwordtextbox As TextBox
    Friend WithEvents spasswordtextbox As TextBox
    Friend WithEvents nametextbox As TextBox
    Friend WithEvents photostextbox As TextBox
    Friend WithEvents Button1 As Button
End Class
