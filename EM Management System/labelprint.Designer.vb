<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class labelprint
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(labelprint))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.预览ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打印机设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.管理ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工作周设定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.页面配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabLabel = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.WklabelFrm = New System.Windows.Forms.Label()
        Me.WKlabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.FrmSNPrintButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.CopyButton = New System.Windows.Forms.Button()
        Me.CopySNText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.Uservarlook = New System.Windows.Forms.ToolStripLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.TabLabel.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.管理ToolStripMenuItem, Me.帮助ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1227, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打印ToolStripMenuItem, Me.预览ToolStripMenuItem, Me.打印机设置ToolStripMenuItem, Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '打印ToolStripMenuItem
        '
        Me.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem"
        Me.打印ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.打印ToolStripMenuItem.Text = "打印"
        '
        '预览ToolStripMenuItem
        '
        Me.预览ToolStripMenuItem.Name = "预览ToolStripMenuItem"
        Me.预览ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.预览ToolStripMenuItem.Text = "预览"
        '
        '打印机设置ToolStripMenuItem
        '
        Me.打印机设置ToolStripMenuItem.Name = "打印机设置ToolStripMenuItem"
        Me.打印机设置ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.打印机设置ToolStripMenuItem.Text = "打印机设置"
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        '管理ToolStripMenuItem
        '
        Me.管理ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.工作周设定ToolStripMenuItem, Me.页面配置ToolStripMenuItem})
        Me.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem"
        Me.管理ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.管理ToolStripMenuItem.Text = "管理"
        '
        '工作周设定ToolStripMenuItem
        '
        Me.工作周设定ToolStripMenuItem.Name = "工作周设定ToolStripMenuItem"
        Me.工作周设定ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.工作周设定ToolStripMenuItem.Text = "工作周设定"
        '
        '页面配置ToolStripMenuItem
        '
        Me.页面配置ToolStripMenuItem.Name = "页面配置ToolStripMenuItem"
        Me.页面配置ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.页面配置ToolStripMenuItem.Text = "页面配置"
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.帮助ToolStripMenuItem.Text = "帮助"
        '
        'TabLabel
        '
        Me.TabLabel.Controls.Add(Me.TabPage2)
        Me.TabLabel.Controls.Add(Me.TabPage4)
        Me.TabLabel.Controls.Add(Me.TabPage3)
        Me.TabLabel.ImageList = Me.ImageList1
        Me.TabLabel.Location = New System.Drawing.Point(12, 30)
        Me.TabLabel.Name = "TabLabel"
        Me.TabLabel.SelectedIndex = 0
        Me.TabLabel.Size = New System.Drawing.Size(1203, 701)
        Me.TabLabel.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Controls.Add(Me.WklabelFrm)
        Me.TabPage2.Controls.Add(Me.WKlabel)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.FrmSNPrintButton)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.TabControl1)
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1195, 674)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "序列号打印"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Location = New System.Drawing.Point(53, 214)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(782, 412)
        Me.TabControl2.TabIndex = 6
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(774, 386)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "打印历史纪录"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'WklabelFrm
        '
        Me.WklabelFrm.AutoSize = True
        Me.WklabelFrm.Location = New System.Drawing.Point(1043, 22)
        Me.WklabelFrm.Name = "WklabelFrm"
        Me.WklabelFrm.Size = New System.Drawing.Size(77, 12)
        Me.WklabelFrm.TabIndex = 5
        Me.WklabelFrm.Text = "当前工作周："
        '
        'WKlabel
        '
        Me.WKlabel.AutoSize = True
        Me.WKlabel.Location = New System.Drawing.Point(960, 22)
        Me.WKlabel.Name = "WKlabel"
        Me.WKlabel.Size = New System.Drawing.Size(77, 12)
        Me.WKlabel.TabIndex = 4
        Me.WKlabel.Text = "当前工作周："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(432, 106)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(85, 21)
        Me.TextBox1.TabIndex = 3
        '
        'FrmSNPrintButton
        '
        Me.FrmSNPrintButton.Location = New System.Drawing.Point(541, 96)
        Me.FrmSNPrintButton.Name = "FrmSNPrintButton"
        Me.FrmSNPrintButton.Size = New System.Drawing.Size(109, 39)
        Me.FrmSNPrintButton.TabIndex = 2
        Me.FrmSNPrintButton.Text = "打印"
        Me.FrmSNPrintButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(385, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "数量："
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(53, 42)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(233, 122)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(225, 96)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "序列号标签预览"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CopyButton)
        Me.TabPage4.Controls.Add(Me.CopySNText)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.ImageIndex = 2
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1195, 674)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "序列号复制"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CopyButton
        '
        Me.CopyButton.Location = New System.Drawing.Point(240, 179)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(101, 32)
        Me.CopyButton.TabIndex = 3
        Me.CopyButton.Text = "复制"
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'CopySNText
        '
        Me.CopySNText.Location = New System.Drawing.Point(172, 111)
        Me.CopySNText.Name = "CopySNText"
        Me.CopySNText.Size = New System.Drawing.Size(169, 21)
        Me.CopySNText.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(123, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "序列号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Adobe 黑体 Std R", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(152, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "序列号复制工具"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.TextBox3)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.ImageIndex = 3
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1195, 674)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Interface标签"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(247, 180)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 42)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "打印"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(194, 111)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(156, 21)
        Me.TextBox3.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "序列号："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Adobe 黑体 Std R", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(129, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(234, 26)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Interface标签打印工具"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Calendar_PNG_128px_522605_easyicon.net.png")
        Me.ImageList1.Images.SetKeyName(1, "system_file_manager_128px_572119_easyicon.net.png")
        Me.ImageList1.Images.SetKeyName(2, "preferences_system_login_128px_572066_easyicon.net.png")
        Me.ImageList1.Images.SetKeyName(3, "bar_chart_remove_72px_6795_easyicon.net.png")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(35, 35)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator5, Me.ToolStripLabel2, Me.Uservarlook})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 752)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1227, 40)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.BackgroundImage = Global.EM_Management_System.My.Resources.Resources.PNG__311_
        Me.ToolStripLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel1.Image = Global.EM_Management_System.My.Resources.Resources.profle
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 37)
        Me.ToolStripLabel1.Text = "用户："
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(20, 37)
        Me.ToolStripLabel2.Text = "   "
        '
        'Uservarlook
        '
        Me.Uservarlook.Name = "Uservarlook"
        Me.Uservarlook.Size = New System.Drawing.Size(70, 37)
        Me.Uservarlook.Text = "UserName"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(795, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 20)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'labelprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1227, 792)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabLabel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "labelprint"
        Me.Text = "标签打印客户端"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabLabel.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打印ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 预览ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打印机设置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 工作周设定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 页面配置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabLabel As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents Uservarlook As ToolStripLabel
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents WklabelFrm As Label
    Friend WithEvents WKlabel As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FrmSNPrintButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents CopyButton As Button
    Friend WithEvents CopySNText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ImageList1 As ImageList
End Class
