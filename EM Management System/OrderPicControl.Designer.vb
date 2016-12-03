<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderPicControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderPicControl))
        Me.PicPN = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PicNum = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicPN
        '
        Me.PicPN.AutoSize = True
        Me.PicPN.BackColor = System.Drawing.Color.Transparent
        Me.PicPN.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PicPN.Location = New System.Drawing.Point(45, 11)
        Me.PicPN.Name = "PicPN"
        Me.PicPN.Size = New System.Drawing.Size(121, 20)
        Me.PicPN.TabIndex = 0
        Me.PicPN.Text = "TDN-866-999-02"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(7, 43)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(129, 88)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PicNum
        '
        Me.PicNum.AutoSize = True
        Me.PicNum.BackColor = System.Drawing.Color.Transparent
        Me.PicNum.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PicNum.Location = New System.Drawing.Point(155, 74)
        Me.PicNum.Name = "PicNum"
        Me.PicNum.Size = New System.Drawing.Size(25, 20)
        Me.PicNum.TabIndex = 2
        Me.PicNum.Text = "20"
        '
        'OrderPicControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.PicNum)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PicPN)
        Me.Name = "OrderPicControl"
        Me.Size = New System.Drawing.Size(202, 144)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicPN As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PicNum As Label
End Class
