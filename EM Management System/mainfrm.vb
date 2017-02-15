Imports System.Data.SqlClient
Imports System.Threading
Public Class mainfrm
    Dim qx1 As String
    Dim qx2 As String
    Dim qx3 As String
    Dim qx4 As String
    Dim qx5 As String
    Dim qx6 As String
    Dim qx7 As String
    Dim qx8 As String
    Dim qx9 As String
    Dim qx10 As String
    Dim qx11 As String
    Dim qx12 As String
    Dim qx13 As String
    Dim qx14 As String
    Dim qx15 As String
    Dim qx16 As String
    Dim qx17 As String
    Dim qx18 As String
    Dim qx19 As String
    Dim qx20 As String
    Dim qx21 As String
    Dim qx22 As String
    Dim qx23 As String
    Dim qx24 As String
    Dim qx25 As String
    Private Delegate Sub VoidShow(ByRef i As String) '定义要委托的类型  
    Dim mythread As Thread

    Private Sub mainfrm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TabControl1.Width = Me.Width - 40
        TabControl1.Height = Me.Height - 205
        DataGridView1.Width = Me.Width / 4 * 3
        DataGridView1.Height = Me.Height - 280
        Panel1.Top = DataGridView1.Top + DataGridView1.Height + 5
        TabControl2.Top = DataGridView1.Top
        TabControl2.Height = DataGridView1.Height / 3 * 2
        TabControl2.Width = TabControl1.Width - DataGridView1.Width - 35
        TabControl2.Left = DataGridView1.Width + DataGridView1.Left + 10

        Panel2.Width = TabPage4.Width
        Panel2.Left = TabPage4.Left
        Panel2.Height = TabPage4.Height
        Panel2.Top = TabPage4.Top - 22

        TabControl3.Top = TabControl2.Top + TabControl2.Height
        TabControl3.Height = DataGridView1.Height / 3 * 1
        TabControl3.Width = TabControl2.Width
        TabControl3.Left = TabControl2.Left
        DataGridView2.Height = TabPage3.Height
        DataGridView2.Width = TabPage3.Width - 5
        DataGridView2.Top = TabPage3.Top - 22
        DataGridView2.Left = TabPage3.Left - 2







    End Sub
    Private Sub mainfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        '---

        Me.Text = Me.Text & "-" & Application.ProductVersion


        Uservarlook.Text = Uservar
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from login_user", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "UserID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find(useridvar)
        If rowIndex = -1 Then


            Exit Sub
        Else
            qx1 = Trim(dv(rowIndex)("工单登记").ToString)
            qx2 = Trim(dv(rowIndex)("投工单").ToString)
            qx3 = Trim(dv(rowIndex)("工单上线").ToString)
            qx4 = Trim(dv(rowIndex)("工单入库").ToString)
            qx5 = Trim(dv(rowIndex)("终检完成").ToString)
            qx6 = Trim(dv(rowIndex)("库位查询").ToString)
            qx7 = Trim(dv(rowIndex)("借料管理").ToString)
            qx8 = Trim(dv(rowIndex)("检查表打印").ToString)
            qx9 = Trim(dv(rowIndex)("木箱上线").ToString)
            qx10 = Trim(dv(rowIndex)("数据备份").ToString)
            qx11 = Trim(dv(rowIndex)("工单目录").ToString)
            qx12 = Trim(dv(rowIndex)("工单顺序").ToString)
            qx13 = Trim(dv(rowIndex)("检查表编辑").ToString)
            qx14 = Trim(dv(rowIndex)("借料数据").ToString)
            qx15 = Trim(dv(rowIndex)("借料用户").ToString)
            qx16 = Trim(dv(rowIndex)("用户注册").ToString)
            qx17 = Trim(dv(rowIndex)("密码重置").ToString)
            qx18 = Trim(dv(rowIndex)("用户权限").ToString)
            qx19 = Trim(dv(rowIndex)("工单物料").ToString)
            qx20 = Trim(dv(rowIndex)("工单数据").ToString)
            qx21 = Trim(dv(rowIndex)("木箱管理").ToString)
            qx22 = Trim(dv(rowIndex)("工单查询").ToString)
            qx23 = Trim(dv(rowIndex)("工单明细").ToString)
            qx24 = Trim(dv(rowIndex)("借料查询").ToString)
            qx25 = Trim(dv(rowIndex)("记住密码").ToString)



        End If
        cn.Close()

        Application.DoEvents()

        test_Click(sender, e)
    End Sub
    Public Sub test_Click(sender As Object, e As EventArgs)
        mythread = New Thread(AddressOf ShowNumber)
        mythread.Name = "myShowNumber"
        mythread.Start()

    End Sub

    Private Sub ShowNumber(ByVal Path As String)

        Me.Invoke(New VoidShow(AddressOf TureShowNumber), "")
        mythread.Abort()
    End Sub
    Private Sub TureShowNumber()


        TabControl1.Width = Me.Width - 40
        TabControl1.Height = Me.Height - 205
        DataGridView1.Width = Me.Width / 4 * 3
        DataGridView1.Height = Me.Height - 280
        Panel1.Top = DataGridView1.Top + DataGridView1.Height + 5
        TabControl2.Top = DataGridView1.Top
        TabControl2.Height = DataGridView1.Height / 3 * 2
        TabControl2.Width = TabControl1.Width - DataGridView1.Width - 35
        TabControl2.Left = DataGridView1.Width + DataGridView1.Left + 10

        Panel2.Width = TabPage4.Width
        Panel2.Left = TabPage4.Left
        Panel2.Height = TabPage4.Height
        Panel2.Top = TabPage4.Top - 22

        TabControl3.Top = TabControl2.Top + TabControl2.Height
        TabControl3.Height = DataGridView1.Height / 3 * 1
        TabControl3.Width = TabControl2.Width
        TabControl3.Left = TabControl2.Left
        DataGridView2.Height = TabPage3.Height
        DataGridView2.Width = TabPage3.Width - 5
        DataGridView2.Top = TabPage3.Top - 22
        DataGridView2.Left = TabPage3.Left - 2







        'upda_Click(sender, e)
        DataGridView1.Rows.Clear()
        Label5.Text = "0"
        Label6.Text = "0"
        Label7.Text = "0"
        Label8.Text = "0"
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_table WHERE 工单入库 ='Open' or 工单入库 ='待入库'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        Dim cn1 As SqlConnection = New SqlConnection(cnStr)



        Dim i As Integer = "-1"
        Dim bhidid As String
        Dim lhidid As String


        While dr.Read()
            i = i + 1
            bhidid = Trim(dr("编号").ToString + Space(5))
            lhidid = Trim(dr("料号").ToString + Space(5))
            cn1.Open()
            Dim sql As String = "SELECT * FROM Order_view WHERE 编号 ='" & bhidid & "' and 料号 ='" & lhidid & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(sql, cn1) '表名
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            dr1.Read()




            DataGridView1.Rows.Add(1)
            DataGridView1.Rows(i).Cells(0).Value = i + 1
            DataGridView1.Rows(i).Cells(2).Value = Trim(dr1("工单号").ToString + Space(5))
            cn1.Close()
            DataGridView1.Rows(i).Cells(1).Value = Trim(dr("型号").ToString + Space(5))
            DataGridView1("Column2", i).Value = ImageList1.Images(1)
            DataGridView1("Column3", i).Value = ImageList1.Images(1)
            DataGridView1("Column4", i).Value = ImageList1.Images(1)
            DataGridView1("Column5", i).Value = ImageList1.Images(1)
            DataGridView1("Column6", i).Value = ImageList1.Images(1)
            Label5.Text = Label5.Text + 1
            If Trim(dr("投工单").ToString + Space(5)) = "工单已投" Then
                DataGridView1("Column2", i).Value = ImageList1.Images(0)
                DataGridView1("Column2", i).ToolTipText = "ID：" & Trim(dr("投工单管理员").ToString + Space(5)) & "  时间：" & Trim(dr("投工单时间").ToString + Space(5))
                Label6.Text = Label6.Text + 1
            End If

            If Trim(dr("工单上线").ToString + Space(5)) = "已上线" Then
                DataGridView1("Column3", i).Value = ImageList1.Images(0)
                DataGridView1("Column3", i).ToolTipText = "ID：" & Trim(dr("工单上线管理员").ToString + Space(5)) & "  时间：" & Trim(dr("上线时间").ToString + Space(5))


                Label7.Text = Label7.Text + 1
            End If
            If Trim(dr("工单上线").ToString + Space(5)) = "未完成" Then
                DataGridView1("Column3", i).Value = ImageList1.Images(3)
                DataGridView1("Column3", i).ToolTipText = "ID：" & Trim(dr("工单上线管理员").ToString + Space(5)) & "  时间：" & Trim(dr("上线时间").ToString + Space(5))


                Label7.Text = Label7.Text + 1
            End If
            If Trim(dr("木箱状态").ToString + Space(5)) = "Close" Then
                DataGridView1("Column4", i).Value = ImageList1.Images(0)
                DataGridView1("Column4", i).ToolTipText = "ID：" & Trim(dr("木箱管理员").ToString + Space(5)) & "  时间：" & Trim(dr("木箱上线时间").ToString + Space(5))
            End If
            If Trim(dr("木箱状态").ToString + Space(5)) = "未完成" Then
                DataGridView1("Column4", i).Value = ImageList1.Images(3)
                DataGridView1("Column4", i).ToolTipText = "ID：" & Trim(dr("木箱管理员").ToString + Space(5)) & "  时间：" & Trim(dr("木箱上线时间").ToString + Space(5))
            End If
            If Trim(dr("系统序列号").ToString + Space(5)) <> "Open" Then
                DataGridView1("Column5", i).Value = ImageList1.Images(0)
                DataGridView1("Column5", i).ToolTipText = Trim(dr("系统序列号").ToString + Space(5))
                DataGridView1("Column6", i).Value = ImageList1.Images(2)
                Label8.Text = Label8.Text + 1
            End If
            If Trim(dr("工单入库").ToString + Space(5)) = "已入库" Then
                DataGridView1("Column6", i).Value = ImageList1.Images(0)
            End If

        End While

        cn.Close()


        Dim cnStr3 As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn3 As SqlConnection = New SqlConnection(cnStr3)
        cn3.Open()
        Dim a3 As String = "SELECT * FROM Order_table WHERE FF信息 ='Open'"
        Dim cmd3 As SqlCommand = New SqlCommand(a3, cn3) '表名
        Dim dr3 As SqlDataReader
        dr3 = cmd3.ExecuteReader()

        Dim r As Integer = "0"
        While dr3.Read()
            r = r + 1
            Dim snlabel As New snControl
            snlabel.SNID = Trim(dr3("系统序列号").ToString + Space(5))
            snlabel.modelid = Trim(dr3("型号").ToString + Space(5))
            snlabel.orderid = Trim(dr3("料号").ToString + Space(5))


            snlabel.Top = 160 * r - 160
            snlabel.Left = 0
            snlabel.Width = Panel2.Width - 20
            Me.Panel2.Controls.Add(snlabel)

        End While
        cn3.Close()
        Dim cn4 As SqlConnection
        Dim da4 As SqlDataAdapter
        Dim ds4 As DataSet
        Dim cnStr4 As String = FrmDataSql

        cn4 = New SqlConnection(cnStr)
        da4 = New SqlDataAdapter("select 型号,工单号,状态 from order_view WHERE  状态<>'Completed' ", cn4) '表名
        ds4 = New DataSet()
        da4.Fill(ds4, "mytable")
        DataGridView2.DataSource = ds4.Tables("mytable") '表名


        cn4.Close()

    End Sub





    Private Sub 修改密码ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 修改密码ToolStripMenuItem.Click
        chanepw.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx1 = "有" Then
            sendorder.Show()
        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx3 = "有" Then
            inorder.Show()
        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx4 = "有" Then
            closeorder.Show()
        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx6 = "有" Then
            locationfrm.Show()

        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx7 = "有" Then
            borrow.Show()

        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Userloginfrm.Show()
        Me.Close()
    End Sub

    Private Sub 新用户注册ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新用户注册ToolStripMenuItem.Click

        If qx16 = "有" Then
            sysuseradd.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 密码重置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 密码重置ToolStripMenuItem.Click

        If qx17 = "有" Then
            pwreset.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx2 = "有" Then
            'touorder.Show()
            touorderfrm.Show()
            ' FrmtouOrder.Show()

        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub 管理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 管理ToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx5 = "有" Then
            clickfrm.Show()
        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx9 = "有" Then
            boxfrm.Show()
        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        msgboxfrm.Show()
        Application.DoEvents()
        If qx8 = "有" Then
            printfrm.Show()
        Else
            msgboxfrm.Close()
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        msgboxfrm.Close()
    End Sub

    Private Sub 工单编辑ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工单编辑ToolStripMenuItem.Click

    End Sub

    Private Sub 检查表编辑ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查表编辑ToolStripMenuItem.Click

        If qx13 = "有" Then
            printedit.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 借料数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 借料数据ToolStripMenuItem.Click

        If qx14 = "有" Then
            borrowedit.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub 借料用户ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 借料用户ToolStripMenuItem.Click

        If qx15 = "有" Then
            borrowuseredit.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 工单目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工单目录ToolStripMenuItem.Click

        If qx11 = "有" Then
            ordeviewedit.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 工单顺序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工单顺序ToolStripMenuItem.Click

        If qx12 = "有" Then
            orderedit.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 工单数据ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ordelistedit.Show()
    End Sub

    Private Sub 库位查询ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 库位查询ToolStripMenuItem1.Click
        locationfrm.Show()
    End Sub

    Private Sub 库位查询ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 库位查询ToolStripMenuItem.Click
        Process.Start("C:\WINDOWS\system32\calc.exe")
    End Sub

    Private Sub 借料查询ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 借料查询ToolStripMenuItem.Click

        If qx24 = "有" Then
            borrowquery.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub



    Private Sub 木箱管理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 木箱管理ToolStripMenuItem.Click

        If qx21 = "有" Then
            boxeditfrm.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub 工单物料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工单物料ToolStripMenuItem.Click

        If qx19 = "有" Then
            bomeditfrm.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 工单数据ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 工单数据ToolStripMenuItem1.Click

        If qx20 = "有" Then
            ordelistedit.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 已送工单查询ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 已送工单查询ToolStripMenuItem.Click

        If qx22 = "有" Then
            ordercxfrm.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub 工单上线查询ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工单上线查询ToolStripMenuItem.Click

        If qx23 = "有" Then
            ordermxfrm.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub 用户权限ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 用户权限ToolStripMenuItem.Click

        If qx18 = "有" Then
            userprfrm.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        test_Click(sender, e)
    End Sub


    Private Sub 工具管理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工具管理ToolStripMenuItem.Click
        If qx16 = "有" Then
            toolfrm.Show()
        Else
            MessageBox.Show("您没有这个权限，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        touorderfrm.Show()
    End Sub
End Class