Imports System.Data.SqlClient
Public Class sendorder
    Dim pn(8) As TextBox
    Dim dd(8) As TextBox
    Dim pc(8) As TextBox
    Dim idnum As Integer
    Dim sl(8) As TextBox
    Dim n As Integer
    Dim xtpn As String
    Dim modeltable As String = ""
    Dim bhbox, xhbox As String





    Private Sub sendorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT 型号 FROM Order_list", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox1.DataSource = ds.Tables("mytable")
        ComboBox1.DisplayMember = "型号"
        'ComboBox1.ValueMember = "列2"
        ComboBox1.Text = ""
        cn.Close()
        ToolStripLabel1.Text = Uservar
        upda_Click(sender, e)

    End Sub

    Public Sub upda_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select 编号,型号,料号 from Order_table WHERE 工单登记='Open'", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        ' DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(0).Width = 130
        DataGridView1.Columns(1).Width = 124
        DataGridView1.Columns(2).Width = 130
        'DataGridView1.Columns(4).Width = 105

        cn.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_List WHERE 型号 ='" & ComboBox1.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Dim strDisplay As String = ""
        pn(1) = pn1 : pn(2) = pn2 : pn(3) = pn3 : pn(4) = pn4 : pn(5) = pn5 : pn(6) = pn6 : pn(7) = pn7 : pn(8) = pn8
        pc(1) = pc1 : pc(2) = pc2 : pc(3) = pc3 : pc(4) = pc4 : pc(5) = pc5 : pc(6) = pc6 : pc(7) = pc7 : pc(8) = pc8
        dd(1) = dd1 : dd(2) = dd2 : dd(3) = dd3 : dd(4) = dd4 : dd(5) = dd5 : dd(6) = dd6 : dd(7) = dd7 : dd(8) = dd8
        sl(1) = sl1 : sl(2) = sl2 : sl(3) = sl3 : sl(4) = sl4 : sl(5) = sl5 : sl(6) = sl6 : sl(7) = sl7 : sl(8) = sl8
        For s As Integer = 1 To 8
            pn(s).Visible = False
            pc(s).Visible = False
            dd(s).Visible = False
        Next s
        Dim i As Integer = 0
        While dr.Read()
            i = i + 1
            pn(i).Visible = True
            pc(i).Visible = True
            dd(i).Visible = True
            pn(i).Text = Trim(dr("料号").ToString + Space(5))
            pc(i).Text = Trim(dr("数量").ToString + Space(5))
            sl(i).Text = Trim(dr("默认收料").ToString + Space(5))
            xtpn = Trim(dr("系统料号").ToString + Space(5))
            idnum = i
        End While

        cn.Close()
        upid_Click(sender, e)
    End Sub

    Private Sub dd1_LostFocus(sender As Object, e As EventArgs) Handles dd1.LostFocus
        If dd1.Text <> "" Then
            If Mid(dd1.Text, 1, 4) = "TDNM" Then
            Else
                dd1.Text = "TDNM" & dd1.Text
            End If
            For i As Integer = 2 To 8
                Dim s As Integer = Mid(dd1.Text, 5, 8) + i - 1
                Select Case s
                    Case Is >= 10000
                        dd(i).Text = "TDNM" & s
                    Case 1000 To 9999
                        dd(i).Text = "TDNM0" & s
                    Case 100 To 999
                        dd(i).Text = "TDNM00" & s
                    Case 10 To 99
                        dd(i).Text = "TDNM000" & s
                    Case 1 To 9
                        dd(i).Text = "TDNM0000" & s
                End Select
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_view", cn) '搬运工拉好水
        Dim ds As New DataSet()  '本地内存准备好容器来装水
        da.Fill(ds, "mytable")   '装水
        Dim drow As DataRow          '定义行变量
        For p As Integer = 1 To idnum
            drow = ds.Tables("mytable").NewRow   '行变量是新的一个行

            If pn(p).Text = "请手动输入料号" Then
            Else
                Try

                    drow("编号") = idlabel.Text
                    drow("型号") = ComboBox1.Text
                    drow("料号") = pn(p).Text    '新行赋值
                    drow("数量") = pc(p).Text

                    If dd(p).Text <> "" Then
                        drow("工单号") = dd(p).Text
                    Else
                        MessageBox.Show("请输入工单号！" & vbCrLf & "第 " & p & " 排工单号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Exit Sub
                    End If

                    drow("工单入库") = "未入库"
                    If sl(p).Text = "是" Then
                        drow("工单上线") = "已上线"
                    ElseIf sl(p).Text = "否" Then
                        drow("工单上线") = "待投"
                    End If


                    ds.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
                    Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
                    da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 

                Catch ex As Exception
                    MessageBox.Show("工单号已存在，请查证后再试", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Next
        addtab_Click(sender, e)
        addbox_Click(sender, e)
        addid_Click(sender, e)
        upda_Click(sender, e)
        MessageBox.Show("工单保存成功！" & vbCrLf & "请添加下一套工单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        dd1.Clear()
        dd2.Clear()
        dd3.Clear()
        dd4.Clear()
        dd5.Clear()
        dd6.Clear()
        dd7.Clear()
        dd8.Clear()


        cn.Close()
    End Sub
    Public Sub upid_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Order_ID", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "编号ID", DataViewRowState.CurrentRows) '指定默认查找列为姓名

        Dim rowIndex As Integer = dv.Find(ComboBox1.Text)

        If rowIndex = -1 Then

        Else

            n = Trim(dv(rowIndex)("变量").ToString)
            Select Case n
                Case Is >= 1000
                    idlabel.Text = ComboBox1.Text & " " & n
                Case 100 To 999
                    idlabel.Text = ComboBox1.Text & " " & "0" & n
                Case 10 To 99
                    idlabel.Text = ComboBox1.Text & " " & "00" & n
                Case 1 To 9
                    idlabel.Text = ComboBox1.Text & " " & "000" & n



            End Select
        End If
        cn.Close()
    End Sub
    Public Sub addtab_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn) '搬运工拉好水
        Dim ds As New DataSet()  '本地内存准备好容器来装水
        da.Fill(ds, "mytable")   '装水
        Dim drow As DataRow          '定义行变量

        drow = ds.Tables("mytable").NewRow   '行变量是新的一个行
        Try

            drow("料号") = xtpn
            drow("编号") = idlabel.Text
            drow("型号") = ComboBox1.Text
            drow("工单登记") = "Open"
            drow("工单入库") = "Open"
            drow("系统序列号") = "Open"
            drow("登记时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("登记管理员") = Uservar

            ds.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
            Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
            da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()
    End Sub
    Public Sub addid_Click(sender As Object, e As EventArgs)
        n = n + 1

        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_ID", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow
        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号ID")} '数据库一定要设置成主键，不然无用
        drow = ds.Tables("mytable").Rows.Find(ComboBox1.Text)
        Try
            drow("变量") = n

            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")
            Select Case n
                Case Is >= 1000
                    idlabel.Text = ComboBox1.Text & " " & n
                Case 100 To 999
                    idlabel.Text = ComboBox1.Text & " " & "0" & n
                Case 10 To 99
                    idlabel.Text = ComboBox1.Text & " " & "00" & n
                Case 1 To 9
                    idlabel.Text = ComboBox1.Text & " " & "000" & n



            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()
    End Sub
    Public Sub addbox_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM box_List WHERE 型号 ='" & ComboBox1.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        Dim boxpn As String
        Dim boxpcs As String
        Dim boxmc As String

        While dr.Read()

            boxpn = Trim(dr("木箱料号").ToString + Space(5))
            boxpcs = Trim(dr("数量").ToString + Space(5))
            boxmc = Trim(dr("名称").ToString + Space(5))



            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            cn1.Open()
            Dim da1 As New SqlDataAdapter("select * from box_view", cn1) '搬运工拉好水
            Dim ds1 As New DataSet()  '本地内存准备好容器来装水
            da1.Fill(ds1, "mytable")   '装水
            Dim drow As DataRow          '定义行变量

            drow = ds1.Tables("mytable").NewRow   '行变量是新的一个行
            Try



                drow("编号") = idlabel.Text
                drow("名称") = boxmc
                drow("木箱料号") = boxpn
                drow("数量") = boxpcs
                drow("状态") = "Open"


                ds1.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
                Dim cmdb As New SqlCommandBuilder(da1)  '和数据库打个电话，本地内存有水要运过去
                da1.Update(ds1, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn1.Close()


        End While

        cn.Close()
    End Sub



    Private Sub 复制ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制ToolStripMenuItem.Click

    End Sub

    Private Sub 剪切ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 剪切ToolStripMenuItem.Click

    End Sub

    Private Sub 粘贴VToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 粘贴VToolStripMenuItem.Click
        Dim pasteText As String = Clipboard.GetText()
        If String.IsNullOrEmpty(pasteText) Then
            Return
        End If
        pasteText = pasteText.Replace(vbCrLf, vbLf)
        pasteText = pasteText.Replace(vbCr, vbLf)
        pasteText.TrimEnd(New Char() {vbLf})
        Dim lines As String() = pasteText.Split(vbLf)

        Dim isHeader As Boolean = True
        For Each line As String In lines
            DataGridView2.Rows.Add(line.Split(ControlChars.Tab))
        Next line
        DataGridView2.Rows.RemoveAt(DataGridView2.RowCount - 1)
        If Trim(DataGridView2.Item(0, 1).Value.ToString()) Like "TDNM#####" Then
            DataGridView2.Columns(0).HeaderText = "工单号"
            DataGridView2.Columns(1).HeaderText = "料号"
            DataGridView2.Columns(0).Name = "工单号"
            DataGridView2.Columns(1).Name = "料号"
            DataGridView2.Columns(2).Name = "数量"
        ElseIf Trim(DataGridView2.Item(1, 1).Value.ToString()) Like "TDNM#####" Then
            DataGridView2.Columns(0).Name = "料号"
            DataGridView2.Columns(1).HeaderText = "工单号"
            DataGridView2.Columns(1).Name = "工单号"
            DataGridView2.Columns(0).Name = "料号"
            DataGridView2.Columns(2).Name = "数量"
        End If



    End Sub

    Private Sub 清空ZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清空ZToolStripMenuItem.Click
        DataGridView2.Rows.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ListBox1.Items.Clear()
        dataviewtest.Rows.Clear()
        DataGridView3.Rows.Clear()
        DataGridView4.Rows.Clear()

        If DataGridView2.RowCount < 1 Then
            MessageBox.Show("没有要添加的工单，请将内容复制到数据框内！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            msgboxfrm.Show()
            Application.DoEvents()
            Dim oridlike, pnlike, numlike As String
            Dim oridid, pnid, numid As String
            For i = 0 To DataGridView2.RowCount - 1

                If DataGridView2.Item(2, i).Value = Nothing Then DataGridView2.Rows(i).Cells(2).Value = "1"
                If DataGridView2.Item(1, i).Value = Nothing Then DataGridView2.Rows(i).Cells(1).Value = "-"
                oridid = Trim(DataGridView2.Item("工单号", i).Value.ToString())
                pnid = Trim(DataGridView2.Item("料号", i).Value.ToString())
                numid = Trim(DataGridView2.Item("数量", i).Value.ToString())
                oridlike = oridid Like "TDNM#####"
                pnlike = pnid Like "TDN-###-###-##"
                numlike = numid Like "#"
                If oridlike = True And pnlike = True And numlike = True Then


                Else
                    Dim msgstr As String = "数据格式错误：" & pnid & "  " & oridid & " " & numid
                    ListBox1.Items.Add(msgstr)

                    msgboxfrm.Close()
                    MessageBox.Show("你复制的数据有误，请启动错误日志进行查看", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next
            updataline_Click(sender, e)
        End If
        msgboxfrm.Close()
    End Sub
    Public Sub updataline_Click(sender As Object, e As EventArgs)
        Dim pnoptint As String
        Dim x As Integer = 0
        Dim xtpn As String = ""


        Try
            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            cn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter("select * from order_option", cn) '表名
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "mytable")
            Dim dv As New DataView(ds.Tables("mytable"), "", "系统料号", DataViewRowState.CurrentRows) '指定默认查找列为姓名

            For i = 0 To DataGridView2.RowCount - 1

                pnoptint = Trim(DataGridView2.Item("料号", i).Value.ToString())

                Dim rowIndex As Integer = dv.Find(pnoptint)
                If rowIndex = -1 Then
                    Dim errorlog As String = "第" & i + 1 & "排  " & pnoptint & "  不是系统料号"
                    ListBox1.Items.Add(errorlog)
                    dataviewtest.Rows.Clear()
                    DataGridView3.Rows.Clear()
                    DataGridView4.Rows.Clear()
                    msgboxfrm.Close()
                    MessageBox.Show("你复制的数据有误，请启动错误日志进行查看", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    dataviewtest.Rows.Clear()
                    modeltable = Trim(dv(rowIndex)("型号").ToString)
                    Dim cnStr1 As String = FrmDataSql  '数据库名，帐号，密码            
                    Dim cn1 As SqlConnection = New SqlConnection(cnStr1)
                    cn1.Open()
                    Dim b As String = "SELECT * FROM Order_list WHERE 型号 ='" & modeltable & "'"
                    Dim cmd1 As SqlCommand = New SqlCommand(b, cn1) '表名
                    Dim br As SqlDataReader
                    br = cmd1.ExecuteReader()
                    While br.Read()

                        dataviewtest.Rows.Insert(0)
                        dataviewtest.Rows(0).Cells(0).Value = Trim(br("料号").ToString + Space(5))
                        dataviewtest.Rows(0).Cells(1).Value = Trim(br("默认收料").ToString + Space(5))
                        xtpn = Trim(br("系统料号").ToString + Space(5))
                    End While
                    cn1.Close()
                    x = x + 1

                    Dim testnum As Integer = dataviewtest.RowCount - 1
                    Dim s As Integer
                    For s = i To i + testnum
                        If s < DataGridView2.RowCount Then
                            Dim testpn As String
                            Dim testorid As String
                            Dim testno As String
                            testpn = Trim(DataGridView2.Item("料号", s).Value)
                            testorid = Trim(DataGridView2.Item("工单号", s).Value)
                            testno = Trim(DataGridView2.Item("数量", s).Value)
                            For z As Integer = 0 To testnum



                                If Trim(dataviewtest.Item(0, z).Value) = testpn Then

                                    DataGridView3.Rows.Insert(0)
                                    DataGridView3.Rows(0).Cells(0).Value = x
                                    DataGridView3.Rows(0).Cells(1).Value = modeltable
                                    DataGridView3.Rows(0).Cells(2).Value = testpn
                                    DataGridView3.Rows(0).Cells(3).Value = testorid
                                    DataGridView3.Rows(0).Cells(4).Value = testno
                                    If Trim(dataviewtest.Item(1, z).Value) = "是" Then
                                        DataGridView3.Rows(0).Cells(5).Value = "已上线"
                                    ElseIf dataviewtest.Item(1, z).Value = "否" Then
                                        DataGridView3.Rows(0).Cells(5).Value = "待投"
                                    End If
                                    DataGridView3.Rows(0).Cells(6).Value = "未入库"
                                    dataviewtest.Item(0, z).Value = "------------"

                                Else
                                    'MessageBox.Show("你复制的数据有误，请查找错误！002", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                End If


                            Next
                        Else
                            Dim errorlog As String = "复制的数据不够一套工单"
                            ListBox1.Items.Add(errorlog)
                            msgboxfrm.Close()
                            MessageBox.Show("你复制的数据有误，请启动错误日志进行查看", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dataviewtest.Rows.Clear()
                            DataGridView3.Rows.Clear()
                            DataGridView4.Rows.Clear()
                            Return
                        End If
                    Next
                    Dim l As Integer = DataGridView4.RowCount
                    DataGridView4.Rows.Insert(l)
                    DataGridView4.Rows(l).Cells(0).Value = x
                    DataGridView4.Rows(l).Cells(1).Value = modeltable
                    DataGridView4.Rows(l).Cells(2).Value = xtpn

                    i = s - 1
                End If
            Next
            cn.Close()
            '------------------------------------------------------------------------------------------
            If DataGridView2.RowCount = DataGridView3.RowCount Then

                Dim oridtest As String
                For h As Integer = 0 To DataGridView3.RowCount - 1
                    oridtest = Trim(DataGridView3.Item(3, h).Value)
                    Dim cnStr3 As String = FrmDataSql  '数据库名，帐号，密码            
                    Dim cn3 As SqlConnection = New SqlConnection(cnStr3)
                    Dim da3 As SqlDataAdapter = New SqlDataAdapter("select * from Order_view", cn3) '表名
                    Dim ds3 As DataSet = New DataSet()
                    da3.Fill(ds3, "mytable")

                    Dim dv3 As New DataView(ds3.Tables("mytable"), "", "工单号", DataViewRowState.CurrentRows) '指定默认查找列为姓名

                    Dim rowIndex3 As Integer = dv3.Find(oridtest)

                    If rowIndex3 = -1 Then
                    Else
                        msgboxfrm.Close()
                        MessageBox.Show("你复制的数据有误，请启动错误日志进行查看", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Dim errorlog As String = oridtest & "  已存在"
                        ListBox1.Items.Add(errorlog)
                        dataviewtest.Rows.Clear()
                        DataGridView3.Rows.Clear()
                        DataGridView4.Rows.Clear()
                        Return
                    End If
                    cn3.Close()
                Next

                For j As Integer = 0 To DataGridView4.RowCount - 1
                    Dim modelidtemp As String
                    modelidtemp = Trim(DataGridView4.Item(1, j).Value.ToString())
                    Dim cnStr2 As String = FrmDataSql  '数据库名，帐号，密码            
                    Dim cn2 As SqlConnection = New SqlConnection(cnStr2)
                    Dim da2 As SqlDataAdapter = New SqlDataAdapter("select * from Order_ID", cn2) '表名
                    Dim ds2 As DataSet = New DataSet()
                    da2.Fill(ds2, "mytable")
                    Dim dv2 As New DataView(ds2.Tables("mytable"), "", "编号ID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
                    Dim rowIndex As Integer = dv2.Find(modelidtemp)
                    Dim drow As DataRow
                    ds2.Tables("mytable").PrimaryKey = New DataColumn() {ds2.Tables("mytable").Columns("编号ID")} '数据库一定要设置成主键，不然无用
                    drow = ds2.Tables("mytable").Rows.Find(modelidtemp)
                    If rowIndex = -1 Then
                        Return
                    Else
                        Dim modelidup As String = ""
                        n = Trim(dv2(rowIndex)("变量").ToString)
                        Select Case n
                            Case Is >= 1000
                                modelidup = modelidtemp & " " & n
                            Case 100 To 999
                                modelidup = modelidtemp & " " & "0" & n
                            Case 10 To 99
                                modelidup = modelidtemp & " " & "00" & n
                            Case 1 To 9
                                modelidup = modelidtemp & " " & "000" & n

                        End Select

                        Dim gridv3 As String
                        Dim gridv4 As String


                        gridv4 = Trim(DataGridView4.Item(0, j).Value.ToString())
                        DataGridView4.Rows(j).Cells(0).Value = modelidup

                        For y As Integer = 0 To DataGridView3.RowCount - 1
                            gridv3 = Trim(DataGridView3.Item(0, y).Value.ToString())

                            If gridv3 = gridv4 Then
                                DataGridView3.Rows(y).Cells(0).Value = modelidup
                            End If
                        Next

                    End If
                    n = n + 1
                    Try
                        drow("变量") = n

                        Dim cmdb As New SqlCommandBuilder(da2)
                        da2.Update(ds2, "mytable")

                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try
                    cn2.Close()
                Next




                If DataGridView2.RowCount = DataGridView3.RowCount Then
                    Dim cnStr4 As String = FrmDataSql  '数据库名，帐号，密码            
                    Dim cn4 As SqlConnection = New SqlConnection(cnStr4)
                    Dim da4 As New SqlDataAdapter("select * from Order_view", cn4) '搬运工拉好水
                    Dim ds4 As New DataSet()  '本地内存准备好容器来装水
                    da4.Fill(ds4, "mytable")   '装水
                    Dim drow4 As DataRow          '定义行变量
                    For w As Integer = 0 To DataGridView3.RowCount - 1
                        drow4 = ds4.Tables("mytable").NewRow   '行变量是新的一个行

                        Try

                            drow4("编号") = Trim(DataGridView3.Item(0, w).Value.ToString())
                            drow4("型号") = Trim(DataGridView3.Item(1, w).Value.ToString())
                            drow4("料号") = Trim(DataGridView3.Item(2, w).Value.ToString())
                            drow4("工单号") = Trim(DataGridView3.Item(3, w).Value.ToString())
                            drow4("数量") = Trim(DataGridView3.Item(4, w).Value.ToString())
                            drow4("工单上线") = Trim(DataGridView3.Item(5, w).Value.ToString()）
                            drow4("工单入库") = Trim(DataGridView3.Item(6, w).Value.ToString()）
                            ds4.Tables("mytable").Rows.Add(drow4)  '新行内容加入到表中
                            Dim cmdb4 As New SqlCommandBuilder(da4)  '和数据库打个电话，本地内存有水要运过去
                            da4.Update(ds4, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
                        Catch ex As Exception

                        End Try

                    Next
                    cn4.Close()
                    Dim cnStr5 As String = FrmDataSql  '数据库名，帐号，密码            
                    Dim cn5 As SqlConnection = New SqlConnection(cnStr5)
                    Dim da5 As New SqlDataAdapter("select * from Order_table", cn5) '搬运工拉好水
                    Dim ds5 As New DataSet()  '本地内存准备好容器来装水
                    da5.Fill(ds5, "mytable")   '装水
                    Dim drow5 As DataRow
                    For r As Integer = 0 To DataGridView4.RowCount - 1

                        '定义行变量

                        drow5 = ds5.Tables("mytable").NewRow   '行变量是新的一个行
                        Try

                            drow5("料号") = Trim(DataGridView4.Item(2, r).Value.ToString())
                            drow5("编号") = Trim(DataGridView4.Item(0, r).Value.ToString())
                            drow5("型号") = Trim(DataGridView4.Item(1, r).Value.ToString())
                            drow5("工单登记") = "Open"
                            drow5("工单入库") = "Open"
                            drow5("系统序列号") = "Open"
                            drow5("登记时间") = Format(Now, "yyyy-MM-dd hh:mm ")
                            drow5("登记管理员") = Uservar

                            ds5.Tables("mytable").Rows.Add(drow5)  '新行内容加入到表中
                            Dim cmdb5 As New SqlCommandBuilder(da5)  '和数据库打个电话，本地内存有水要运过去
                            da5.Update(ds5, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
                            bhbox = Trim(DataGridView4.Item(0, r).Value.ToString())
                            xhbox = Trim(DataGridView4.Item(1, r).Value.ToString())
                            pladdbox_Click(sender, e)
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString)
                        End Try


                    Next
                    cn5.Close()
                    msgboxfrm.Close()

                    MessageBox.Show("工单保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If

            Else
                msgboxfrm.Close()
                MessageBox.Show("你复制的数据有误，请启动错误日志进行查看", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Panel1.Visible = False Then
            Panel1.Visible = True
            Button2.Visible = False
        Else
            Panel1.Visible = False
            Button2.Visible = True
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel1.Visible = False
        Button2.Visible = True
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Public Sub pladdbox_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM box_List WHERE 型号 ='" & xhbox & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        Dim boxpn As String
        Dim boxpcs As String
        Dim boxmc As String

        While dr.Read()

            boxpn = Trim(dr("木箱料号").ToString + Space(5))
            boxpcs = Trim(dr("数量").ToString + Space(5))
            boxmc = Trim(dr("名称").ToString + Space(5))



            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            cn1.Open()
            Dim da1 As New SqlDataAdapter("select * from box_view", cn1) '搬运工拉好水
            Dim ds1 As New DataSet()  '本地内存准备好容器来装水
            da1.Fill(ds1, "mytable")   '装水
            Dim drow As DataRow          '定义行变量

            drow = ds1.Tables("mytable").NewRow   '行变量是新的一个行
            Try



                drow("编号") = bhbox
                drow("名称") = boxmc
                drow("木箱料号") = boxpn
                drow("数量") = boxpcs
                drow("状态") = "Open"


                ds1.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
                Dim cmdb As New SqlCommandBuilder(da1)  '和数据库打个电话，本地内存有水要运过去
                da1.Update(ds1, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn1.Close()


        End While

        cn.Close()
    End Sub


End Class