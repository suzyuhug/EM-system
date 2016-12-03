Imports System.Data.SqlClient
Public Class closeorder
    Dim pnid As String
    Dim moldeid As String
    Dim bhid As String
    Dim adddate As String
    Dim yjdate As String
    Dim ownerid As String
    Dim xtsn As String
    Dim wcsj As String
    Dim gdsx As String
    Dim bian As String
    Dim orsl As String



    Private Sub closeorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripLabel1.Text = Uservar
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_table WHERE 工单入库 ='待入库'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        While dr.Read()
            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            cn1.Open()
            Dim c As String = Trim(dr("编号").ToString + Space(5))
            Dim b As String = "SELECT * FROM Order_view WHERE 编号 ='" & c & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(b, cn1) '表名
            Dim br As SqlDataReader
            br = cmd1.ExecuteReader()
            While br.Read()
                ListBox1.Items.Add(Trim(br("工单号").ToString + Space(5)))


            End While
            cn1.Close()
        End While
        cn.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        ListView1.Clear()
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Order_view", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "工单号", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find(ListBox1.Text)
        If rowIndex = -1 Then


            Exit Sub
        Else

            moldeid = Trim(dv(rowIndex)("型号").ToString)
            pnid = Trim(dv(rowIndex)("料号").ToString)
            bhid = Trim(dv(rowIndex)("编号").ToString)
            'adddate = Trim(dv(rowIndex)("PassWord").ToString)
            'yjdate = Trim(dv(rowIndex)("PassWord").ToString)
            'ownerid = Trim(dv(rowIndex)("PassWord").ToString)

            bhcx_Click(sender, e)
        End If
        cn.Close()
    End Sub
    Public Sub bhcx_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Order_table", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "编号", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find(bhid)
        If rowIndex = -1 Then

            MessageBox.Show("信息提取错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            Exit Sub
        Else

            adddate = Trim(dv(rowIndex)("投工单时间").ToString)
            yjdate = Trim(dv(rowIndex)("上线时间").ToString)
            ownerid = Trim(dv(rowIndex)("投工单管理员").ToString)
            xtsn = Trim(dv(rowIndex)("系统序列号").ToString)
            wcsj = Trim(dv(rowIndex)("终检完成时间").ToString)
            gdsx = Trim(dv(rowIndex)("工单上线管理员").ToString)
            cn.Close()

        End If

        ListView1.Items.Add("型号：" & moldeid, 2)
        ListView1.Items.Add("料号：" & pnid, 1)
        ListView1.Items.Add("工单号：" & ListBox1.Text, 0)
        ListView1.Items.Add("投工单用户：" & ownerid, 5)
        ListView1.Items.Add("投工单时间：" & adddate, 3)
        ListView1.Items.Add("收料者：" & gdsx, 4)
        ListView1.Items.Add("上线时间：" & yjdate, 4)
        ListView1.Items.Add("系统序列号：" & xtsn, 6)
        ListView1.Items.Add("系统完成时间：" & wcsj, 7)

        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MessageBox.Show("你确定要入库，点击后将不可恢复，点击（确定）进行入库！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
            If ListBox1.Items.Count = 0 Then
                MessageBox.Show("没有可以入库的工单了！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                msgboxfrm.Show()
                Application.DoEvents()
                bian = ""
                For i As Integer = 0 To ListBox1.Items.Count - 1


                    Dim cnStr As String = FrmDataSql
                    Dim cn As SqlConnection = New SqlConnection(cnStr)
                    Dim da As New SqlDataAdapter("select * from Order_view", cn)
                    Dim ds As New DataSet()
                    da.Fill(ds, "mytable")
                    Dim drow As DataRow
                    ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工单号")}
                    drow = ds.Tables("mytable").Rows.Find(ListBox1.Items(i).ToString)

                    Dim dv As New DataView(ds.Tables("mytable"), "", "工单号", DataViewRowState.CurrentRows) '指定默认查找列为姓名
                    Dim rowIndex As Integer = dv.Find(ListBox1.Items(i).ToString)

                    If rowIndex = -1 Then
                        Exit Sub
                    Else
                        bhid = Trim(dv(rowIndex)("编号").ToString)
                        moldeid = Trim(dv(rowIndex)("型号").ToString)
                        pnid = Trim(dv(rowIndex)("料号").ToString)
                        orsl = Trim(dv(rowIndex)("数量").ToString)
                        bian &= moldeid & "                          " & ListBox1.Items(i).ToString & "                         " & pnid & "                         " & orsl
                        bian &= vbCrLf
                        bian &= "-------------------------------------------------------------------------------------------------------------------------------------------------------------"
                        bian &= vbCrLf
                    End If
                    Try

                        drow("工单入库") = "已入库"
                        drow("状态") = "Open"
                        Dim cmdb As New SqlCommandBuilder(da)
                        da.Update(ds, "mytable")


                        cxtable_Click(sender, e)

                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try
                    cn.Close()
                    ListBox2.Items.Add(ListBox1.Items(i).ToString)
                Next
                msgboxfrm.Close()
                MessageBox.Show("恭喜你入库成功了，赶快去FlexFlow和Baan系统完成剩余的步骤吧！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                addbom_Click(sender, e)
                If CheckBox1.Checked = True Then

                    Dim printDoc As New System.Drawing.Printing.PrintDocument
                    AddHandler printDoc.PrintPage, AddressOf Me.PrintText
                    printDoc.Print()
                End If
                ListBox1.Items.Clear()
                ListView1.Items.Clear()
            End If
        End If
        msgboxfrm.Close()

    End Sub
    Public Sub cxtable_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow
        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(bhid)

        Try

            drow("工单入库") = "已入库"
            drow("入库时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("入库管理员") = Uservar
            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")




        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()


    End Sub



    Private Sub PrintText(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        ev.Graphics.DrawString("入库明细", New Font("Arial", 25, FontStyle.Bold), Brushes.Black, 320, 70)
        ev.Graphics.DrawString("型号", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 50, 150)
        ev.Graphics.DrawString("工单号", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 180, 150)
        ev.Graphics.DrawString("料号", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 360, 150)
        ev.Graphics.DrawString("数量", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 500, 150)
        ev.Graphics.DrawString("FlexFlow", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 600, 150)
        ev.Graphics.DrawString(bian, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 45, 200)

    End Sub

    Public Sub addbom_Click(sender As Object, e As EventArgs)
        Dim mm As String = Format(Now, "yyyyMMddhhmmss ")
        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\\orderlog\" & mm & ".txt", bian, False, System.Text.Encoding.Default)

    End Sub
End Class