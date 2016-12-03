<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class touorderfrm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(touorderfrm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Uservarlook = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.sx8 = New System.Windows.Forms.TextBox()
        Me.sx7 = New System.Windows.Forms.TextBox()
        Me.sx6 = New System.Windows.Forms.TextBox()
        Me.sx5 = New System.Windows.Forms.TextBox()
        Me.sx4 = New System.Windows.Forms.TextBox()
        Me.sx3 = New System.Windows.Forms.TextBox()
        Me.sx2 = New System.Windows.Forms.TextBox()
        Me.sx1 = New System.Windows.Forms.TextBox()
        Me.bu8 = New System.Windows.Forms.Button()
        Me.bu7 = New System.Windows.Forms.Button()
        Me.pn8 = New System.Windows.Forms.TextBox()
        Me.pn7 = New System.Windows.Forms.TextBox()
        Me.dd8 = New System.Windows.Forms.TextBox()
        Me.dd7 = New System.Windows.Forms.TextBox()
        Me.bu6 = New System.Windows.Forms.Button()
        Me.bu5 = New System.Windows.Forms.Button()
        Me.bu4 = New System.Windows.Forms.Button()
        Me.pn6 = New System.Windows.Forms.TextBox()
        Me.pn5 = New System.Windows.Forms.TextBox()
        Me.pn4 = New System.Windows.Forms.TextBox()
        Me.dd6 = New System.Windows.Forms.TextBox()
        Me.dd5 = New System.Windows.Forms.TextBox()
        Me.dd4 = New System.Windows.Forms.TextBox()
        Me.bu3 = New System.Windows.Forms.Button()
        Me.bu2 = New System.Windows.Forms.Button()
        Me.bu1 = New System.Windows.Forms.Button()
        Me.pn3 = New System.Windows.Forms.TextBox()
        Me.pn2 = New System.Windows.Forms.TextBox()
        Me.pn1 = New System.Windows.Forms.TextBox()
        Me.dd3 = New System.Windows.Forms.TextBox()
        Me.dd2 = New System.Windows.Forms.TextBox()
        Me.dd1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.Uservarlook})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 451)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(811, 40)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.BackgroundImage = Global.EM_Management_System.My.Resources.Resources.PNG__311_
        Me.ToolStripLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 37)
        Me.ToolStripLabel1.Text = "用户："
        '
        'Uservarlook
        '
        Me.Uservarlook.Name = "Uservarlook"
        Me.Uservarlook.Size = New System.Drawing.Size(70, 37)
        Me.Uservarlook.Text = "UserName"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(12, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(388, 283)
        Me.DataGridView1.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.sx8)
        Me.Panel1.Controls.Add(Me.sx7)
        Me.Panel1.Controls.Add(Me.sx6)
        Me.Panel1.Controls.Add(Me.sx5)
        Me.Panel1.Controls.Add(Me.sx4)
        Me.Panel1.Controls.Add(Me.sx3)
        Me.Panel1.Controls.Add(Me.sx2)
        Me.Panel1.Controls.Add(Me.sx1)
        Me.Panel1.Controls.Add(Me.bu8)
        Me.Panel1.Controls.Add(Me.bu7)
        Me.Panel1.Controls.Add(Me.pn8)
        Me.Panel1.Controls.Add(Me.pn7)
        Me.Panel1.Controls.Add(Me.dd8)
        Me.Panel1.Controls.Add(Me.dd7)
        Me.Panel1.Controls.Add(Me.bu6)
        Me.Panel1.Controls.Add(Me.bu5)
        Me.Panel1.Controls.Add(Me.bu4)
        Me.Panel1.Controls.Add(Me.pn6)
        Me.Panel1.Controls.Add(Me.pn5)
        Me.Panel1.Controls.Add(Me.pn4)
        Me.Panel1.Controls.Add(Me.dd6)
        Me.Panel1.Controls.Add(Me.dd5)
        Me.Panel1.Controls.Add(Me.dd4)
        Me.Panel1.Controls.Add(Me.bu3)
        Me.Panel1.Controls.Add(Me.bu2)
        Me.Panel1.Controls.Add(Me.bu1)
        Me.Panel1.Controls.Add(Me.pn3)
        Me.Panel1.Controls.Add(Me.pn2)
        Me.Panel1.Controls.Add(Me.pn1)
        Me.Panel1.Controls.Add(Me.dd3)
        Me.Panel1.Controls.Add(Me.dd2)
        Me.Panel1.Controls.Add(Me.dd1)
        Me.Panel1.Location = New System.Drawing.Point(423, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 283)
        Me.Panel1.TabIndex = 18
        '
        'sx8
        '
        Me.sx8.Enabled = False
        Me.sx8.Location = New System.Drawing.Point(352, 202)
        Me.sx8.Name = "sx8"
        Me.sx8.Size = New System.Drawing.Size(19, 21)
        Me.sx8.TabIndex = 50
        Me.sx8.Visible = False
        '
        'sx7
        '
        Me.sx7.Enabled = False
        Me.sx7.Location = New System.Drawing.Point(352, 173)
        Me.sx7.Name = "sx7"
        Me.sx7.Size = New System.Drawing.Size(19, 21)
        Me.sx7.TabIndex = 49
        Me.sx7.Visible = False
        '
        'sx6
        '
        Me.sx6.Enabled = False
        Me.sx6.Location = New System.Drawing.Point(352, 146)
        Me.sx6.Name = "sx6"
        Me.sx6.Size = New System.Drawing.Size(19, 21)
        Me.sx6.TabIndex = 48
        Me.sx6.Visible = False
        '
        'sx5
        '
        Me.sx5.Enabled = False
        Me.sx5.Location = New System.Drawing.Point(352, 120)
        Me.sx5.Name = "sx5"
        Me.sx5.Size = New System.Drawing.Size(19, 21)
        Me.sx5.TabIndex = 47
        Me.sx5.Visible = False
        '
        'sx4
        '
        Me.sx4.Enabled = False
        Me.sx4.Location = New System.Drawing.Point(352, 92)
        Me.sx4.Name = "sx4"
        Me.sx4.Size = New System.Drawing.Size(19, 21)
        Me.sx4.TabIndex = 46
        Me.sx4.Visible = False
        '
        'sx3
        '
        Me.sx3.Enabled = False
        Me.sx3.Location = New System.Drawing.Point(352, 67)
        Me.sx3.Name = "sx3"
        Me.sx3.Size = New System.Drawing.Size(19, 21)
        Me.sx3.TabIndex = 45
        Me.sx3.Visible = False
        '
        'sx2
        '
        Me.sx2.Enabled = False
        Me.sx2.Location = New System.Drawing.Point(352, 38)
        Me.sx2.Name = "sx2"
        Me.sx2.Size = New System.Drawing.Size(19, 21)
        Me.sx2.TabIndex = 44
        Me.sx2.Visible = False
        '
        'sx1
        '
        Me.sx1.Enabled = False
        Me.sx1.Location = New System.Drawing.Point(352, 11)
        Me.sx1.Name = "sx1"
        Me.sx1.Size = New System.Drawing.Size(19, 21)
        Me.sx1.TabIndex = 43
        Me.sx1.Visible = False
        '
        'bu8
        '
        Me.bu8.Location = New System.Drawing.Point(278, 201)
        Me.bu8.Name = "bu8"
        Me.bu8.Size = New System.Drawing.Size(68, 20)
        Me.bu8.TabIndex = 42
        Me.bu8.Text = "生成模板"
        Me.bu8.UseVisualStyleBackColor = True
        Me.bu8.Visible = False
        '
        'bu7
        '
        Me.bu7.Location = New System.Drawing.Point(278, 173)
        Me.bu7.Name = "bu7"
        Me.bu7.Size = New System.Drawing.Size(68, 20)
        Me.bu7.TabIndex = 41
        Me.bu7.Text = "生成模板"
        Me.bu7.UseVisualStyleBackColor = True
        Me.bu7.Visible = False
        '
        'pn8
        '
        Me.pn8.Enabled = False
        Me.pn8.Location = New System.Drawing.Point(139, 200)
        Me.pn8.Name = "pn8"
        Me.pn8.Size = New System.Drawing.Size(133, 21)
        Me.pn8.TabIndex = 39
        Me.pn8.Visible = False
        '
        'pn7
        '
        Me.pn7.Enabled = False
        Me.pn7.Location = New System.Drawing.Point(139, 173)
        Me.pn7.Name = "pn7"
        Me.pn7.Size = New System.Drawing.Size(133, 21)
        Me.pn7.TabIndex = 38
        Me.pn7.Visible = False
        '
        'dd8
        '
        Me.dd8.Enabled = False
        Me.dd8.Location = New System.Drawing.Point(23, 200)
        Me.dd8.Name = "dd8"
        Me.dd8.Size = New System.Drawing.Size(110, 21)
        Me.dd8.TabIndex = 36
        Me.dd8.Visible = False
        '
        'dd7
        '
        Me.dd7.Enabled = False
        Me.dd7.Location = New System.Drawing.Point(23, 173)
        Me.dd7.Name = "dd7"
        Me.dd7.Size = New System.Drawing.Size(110, 21)
        Me.dd7.TabIndex = 35
        Me.dd7.Visible = False
        '
        'bu6
        '
        Me.bu6.Location = New System.Drawing.Point(278, 148)
        Me.bu6.Name = "bu6"
        Me.bu6.Size = New System.Drawing.Size(68, 20)
        Me.bu6.TabIndex = 34
        Me.bu6.Text = "生成模板"
        Me.bu6.UseVisualStyleBackColor = True
        Me.bu6.Visible = False
        '
        'bu5
        '
        Me.bu5.Location = New System.Drawing.Point(278, 121)
        Me.bu5.Name = "bu5"
        Me.bu5.Size = New System.Drawing.Size(68, 20)
        Me.bu5.TabIndex = 33
        Me.bu5.Text = "生成模板"
        Me.bu5.UseVisualStyleBackColor = True
        Me.bu5.Visible = False
        '
        'bu4
        '
        Me.bu4.Location = New System.Drawing.Point(278, 93)
        Me.bu4.Name = "bu4"
        Me.bu4.Size = New System.Drawing.Size(68, 20)
        Me.bu4.TabIndex = 32
        Me.bu4.Text = "生成模板"
        Me.bu4.UseVisualStyleBackColor = True
        Me.bu4.Visible = False
        '
        'pn6
        '
        Me.pn6.Enabled = False
        Me.pn6.Location = New System.Drawing.Point(139, 147)
        Me.pn6.Name = "pn6"
        Me.pn6.Size = New System.Drawing.Size(133, 21)
        Me.pn6.TabIndex = 31
        Me.pn6.Visible = False
        '
        'pn5
        '
        Me.pn5.Enabled = False
        Me.pn5.Location = New System.Drawing.Point(139, 120)
        Me.pn5.Name = "pn5"
        Me.pn5.Size = New System.Drawing.Size(133, 21)
        Me.pn5.TabIndex = 30
        Me.pn5.Visible = False
        '
        'pn4
        '
        Me.pn4.Enabled = False
        Me.pn4.Location = New System.Drawing.Point(139, 93)
        Me.pn4.Name = "pn4"
        Me.pn4.Size = New System.Drawing.Size(133, 21)
        Me.pn4.TabIndex = 29
        Me.pn4.Visible = False
        '
        'dd6
        '
        Me.dd6.Enabled = False
        Me.dd6.Location = New System.Drawing.Point(23, 147)
        Me.dd6.Name = "dd6"
        Me.dd6.Size = New System.Drawing.Size(110, 21)
        Me.dd6.TabIndex = 28
        Me.dd6.Visible = False
        '
        'dd5
        '
        Me.dd5.Enabled = False
        Me.dd5.Location = New System.Drawing.Point(23, 120)
        Me.dd5.Name = "dd5"
        Me.dd5.Size = New System.Drawing.Size(110, 21)
        Me.dd5.TabIndex = 27
        Me.dd5.Visible = False
        '
        'dd4
        '
        Me.dd4.Enabled = False
        Me.dd4.Location = New System.Drawing.Point(23, 93)
        Me.dd4.Name = "dd4"
        Me.dd4.Size = New System.Drawing.Size(110, 21)
        Me.dd4.TabIndex = 26
        Me.dd4.Visible = False
        '
        'bu3
        '
        Me.bu3.Location = New System.Drawing.Point(278, 67)
        Me.bu3.Name = "bu3"
        Me.bu3.Size = New System.Drawing.Size(68, 20)
        Me.bu3.TabIndex = 25
        Me.bu3.Text = "生成模板"
        Me.bu3.UseVisualStyleBackColor = True
        Me.bu3.Visible = False
        '
        'bu2
        '
        Me.bu2.Location = New System.Drawing.Point(278, 40)
        Me.bu2.Name = "bu2"
        Me.bu2.Size = New System.Drawing.Size(68, 20)
        Me.bu2.TabIndex = 24
        Me.bu2.Text = "生成模板"
        Me.bu2.UseVisualStyleBackColor = True
        Me.bu2.Visible = False
        '
        'bu1
        '
        Me.bu1.Location = New System.Drawing.Point(278, 12)
        Me.bu1.Name = "bu1"
        Me.bu1.Size = New System.Drawing.Size(68, 20)
        Me.bu1.TabIndex = 23
        Me.bu1.Text = "生成模板"
        Me.bu1.UseVisualStyleBackColor = True
        Me.bu1.Visible = False
        '
        'pn3
        '
        Me.pn3.Enabled = False
        Me.pn3.Location = New System.Drawing.Point(139, 66)
        Me.pn3.Name = "pn3"
        Me.pn3.Size = New System.Drawing.Size(133, 21)
        Me.pn3.TabIndex = 22
        Me.pn3.Visible = False
        '
        'pn2
        '
        Me.pn2.Enabled = False
        Me.pn2.Location = New System.Drawing.Point(139, 39)
        Me.pn2.Name = "pn2"
        Me.pn2.Size = New System.Drawing.Size(133, 21)
        Me.pn2.TabIndex = 21
        Me.pn2.Visible = False
        '
        'pn1
        '
        Me.pn1.Enabled = False
        Me.pn1.Location = New System.Drawing.Point(139, 12)
        Me.pn1.Name = "pn1"
        Me.pn1.Size = New System.Drawing.Size(133, 21)
        Me.pn1.TabIndex = 20
        Me.pn1.Visible = False
        '
        'dd3
        '
        Me.dd3.Enabled = False
        Me.dd3.Location = New System.Drawing.Point(23, 66)
        Me.dd3.Name = "dd3"
        Me.dd3.Size = New System.Drawing.Size(110, 21)
        Me.dd3.TabIndex = 19
        Me.dd3.Visible = False
        '
        'dd2
        '
        Me.dd2.Enabled = False
        Me.dd2.Location = New System.Drawing.Point(23, 39)
        Me.dd2.Name = "dd2"
        Me.dd2.Size = New System.Drawing.Size(110, 21)
        Me.dd2.TabIndex = 18
        Me.dd2.Visible = False
        '
        'dd1
        '
        Me.dd1.Enabled = False
        Me.dd1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.dd1.Location = New System.Drawing.Point(23, 12)
        Me.dd1.Name = "dd1"
        Me.dd1.Size = New System.Drawing.Size(110, 21)
        Me.dd1.TabIndex = 17
        Me.dd1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(371, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "预计上线时间"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(374, 387)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(177, 21)
        Me.DateTimePicker1.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "待投的工单"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(421, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "选择的工单"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "28f4efa892af22502c8044aa7e23414d.png")
        '
        'Button4
        '
        Me.Button4.ImageIndex = 0
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(604, 355)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(126, 53)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "  保存"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'touorderfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 491)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.Name = "touorderfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "投工单"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Uservarlook As ToolStripLabel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents bu8 As Button
    Friend WithEvents bu7 As Button
    Friend WithEvents pn8 As TextBox
    Friend WithEvents pn7 As TextBox
    Friend WithEvents dd8 As TextBox
    Friend WithEvents dd7 As TextBox
    Friend WithEvents bu6 As Button
    Friend WithEvents bu5 As Button
    Friend WithEvents bu4 As Button
    Friend WithEvents pn6 As TextBox
    Friend WithEvents pn5 As TextBox
    Friend WithEvents pn4 As TextBox
    Friend WithEvents dd6 As TextBox
    Friend WithEvents dd5 As TextBox
    Friend WithEvents dd4 As TextBox
    Friend WithEvents bu3 As Button
    Friend WithEvents bu2 As Button
    Friend WithEvents bu1 As Button
    Friend WithEvents pn3 As TextBox
    Friend WithEvents pn2 As TextBox
    Friend WithEvents pn1 As TextBox
    Friend WithEvents dd3 As TextBox
    Friend WithEvents dd2 As TextBox
    Friend WithEvents dd1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents sx8 As TextBox
    Friend WithEvents sx7 As TextBox
    Friend WithEvents sx6 As TextBox
    Friend WithEvents sx5 As TextBox
    Friend WithEvents sx4 As TextBox
    Friend WithEvents sx3 As TextBox
    Friend WithEvents sx2 As TextBox
    Friend WithEvents sx1 As TextBox
    Friend WithEvents ImageList1 As ImageList
End Class
