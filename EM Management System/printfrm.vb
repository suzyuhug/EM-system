Imports System.Data.SqlClient
Imports Microsoft.Office.Interop



Public Class printfrm
    Dim m_items As New ArrayList
    Dim printpath As String
    Dim printname As String
    Dim printnum As String
    Dim moid As String
    Dim bhbl As String
    Dim xh As String
    Dim PrinterName As String
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub printfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripLabel1.Text = Uservar

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_table WHERE 检查表打印 ='Open'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        Dim i As Integer = "0"
        While dr.Read()
            i = i + 1
            Dim printlabel As New printControl1
            printlabel.value = Trim(dr("型号").ToString + Space(5))
            printlabel.bhid = Trim(dr("编号").ToString + Space(5))
            printlabel.modelid = i
            printlabel.Top = 120 * i - 85
            printlabel.Left = 30
            Me.Panel1.Controls.Add(printlabel)
            AddHandler printlabel.prtClick, AddressOf printlabelarrayclick
        End While
        cn.Close()
        view_Click(sender, e)

        Dim PD As New PrintDialog
        'PD.ShowDialog()
        PrinterName = PD.PrinterSettings.PrinterName

        ToolStripLabel5.Text = PrinterName

    End Sub
    Private Sub printlabelarrayclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("您将要打印全套的检查表，点击（确定）继续！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = DialogResult.OK Then

            moid = CType(sender, printControl1).value
            bhbl = CType(sender, printControl1).bhid
            PictureBox2.Visible = False
            TextBox1.Visible = True
            ProgressBar1.Visible = True
            PictureBox1.Visible = False

            printlist_Click(sender, e)
        End If

    End Sub

    Public Sub printlist_Click(sender As Object, e As EventArgs)

        Try
            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            cn.Open()
            Dim a As String = "SELECT * FROM Print_List WHERE 型号 ='" & moid & "'"
            Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            Dim s As Integer = "1"
            While dr.Read()
                s = s + 10
                If s < "100" Then

                    ToolStripProgressBar1.Value = s
                Else
                    s = s - 10
                    ToolStripProgressBar1.Value = s
                End If


                'System.Threading.Thread.Sleep(1000)
                printpath = Trim(dr("路径").ToString + Space(5))
                printname = Trim(dr("名称").ToString + Space(5))
                printnum = Trim(dr("数量").ToString + Space(5))
                TextBox1.Text = "正在打印" & printname
                If CheckBox1.Checked = False Then

                    print_Click(sender, e)
                End If

            End While

            cn.Close()
            ToolStripProgressBar1.Value = "100"
            TextBox1.Text = moid & "全部检查表已打印完成"
            PictureBox1.Visible = True
            ProgressBar1.Visible = False
            uptabel_Click(sender, e)
            ' MessageBox.Show(moid & "全部检查表已打印完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub print_Click(sender As Object, e As EventArgs)








        ProgressBar1.Value = "10"

        Dim myexcel As New Excel.Application
        ProgressBar1.Value = "20"
        myexcel.Visible = False
        myexcel.Application.DisplayAlerts = False
        myexcel.Workbooks.Open(printpath)
        ProgressBar1.Value = "30"

        myexcel.Worksheets(1).Delete
        ProgressBar1.Value = "50"

        myexcel.Worksheets.PrintOut(Copies:=printnum, ActivePrinter:=PrinterName)

        ProgressBar1.Value = "60"
        myexcel.ActiveWorkbook.Saved = True
        ProgressBar1.Value = "70"
        myexcel.Workbooks.Close()
        ProgressBar1.Value = "80"
        myexcel.Quit()
            ProgressBar1.Value = "100"

    End Sub
    Public Sub uptabel_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn) '搬运工拉好水
        Dim ds As New DataSet()  '本地内存准备好容器来装水
        da.Fill(ds, "mytable")   '装水
        Dim drow As DataRow          '定义行变量

        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(bhbl)
        Try


            drow("检查表打印") = "Close"
            drow("打印时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("打印管理员") = Uservar


            Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
            da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()


    End Sub

    Public Sub view_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT DISTINCT 型号 FROM print_list"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        Dim i As Integer = "-1"
        While dr.Read()
            i = i + 1
            TreeView1.Nodes.Add(Trim(dr("型号").ToString + Space(5)))

            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            cn1.Open()
            Dim b As String = "SELECT * FROM Print_List WHERE 型号 ='" & Trim(dr("型号").ToString + Space(5)) & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(b, cn1) '表名
            Dim br As SqlDataReader
            br = cmd1.ExecuteReader()
            While br.Read()

                TreeView1.Nodes(i).Nodes.Add("12 slot", Trim(br("名称").ToString + Space(5)))
            End While
            cn1.Close()
        End While
        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click





        Label1.Text = "正在打印，请稍后。。。"
        If printpath = "" Then
            MessageBox.Show("请选择要打印的检查表！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox5.Text <> Int(TextBox5.Text) Then
            MessageBox.Show("请输入要打印的份数！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            print_Click(sender, e)
            MessageBox.Show("检查表打印完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            printpath = ""
            ListView1.Items.Clear()
            Label1.Text = "检查表打印完成！"
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub



    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ListView1.Items.Clear()
        Dim xh, mc, lj As String
        Try
            If TreeView1.SelectedNode.Parent.Nodes.Count <> 0 Then
                mc = TreeView1.SelectedNode.Text
                xh = TreeView1.SelectedNode.Parent.Text

                ListView1.Items.Add("型号: " & xh, 1)
                ListView1.Items.Add("名称: " & mc, 1)

                If xh = "" Or mc = "" Then
                    MessageBox.Show("请在左侧选择要打印的检查表", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else

                    Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
                    Dim cn As SqlConnection = New SqlConnection(cnStr)
                    cn.Open()
                    Dim a As String = "SELECT * FROM print_list WHERE 型号 ='" & xh & "' and 名称 ='" & mc & "'"
                    Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
                    Dim dr As SqlDataReader
                    dr = cmd.ExecuteReader()

                    Dim i As Integer = 0


                    While dr.Read()

                        lj = Trim(dr("路径").ToString + Space(5))
                        printpath = lj
                        ListView1.Items.Add("路径: " & lj, 1)
                        ListView1.Items.Add("数量: " & TextBox5.Text, 1)
                        printnum = TextBox5.Text
                    End While

                    cn.Close()
                End If


            ElseIf TreeView1.SelectedNode.Parent.Nodes.Count = 0 Then

            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        Dim PD As New PrintDialog
        PD.ShowDialog()
        PrinterName = PD.PrinterSettings.PrinterName

        ToolStripLabel5.Text = PrinterName

    End Sub


End Class