Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class borrow
    Dim s As Integer
    Dim p As String
    Dim u As String
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sxbl As String
    Dim ImagePath As String


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Location_Query", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "Location_Query")

        Dim dv As New DataView(ds.Tables("Location_Query"), "", "[Part Number]", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        If Mid(PNTextBox.Text, 1, 4) = "TDN-" Then

        ElseIf PNTextBox.Text = "" Then
            Exit Sub
        Else

            PNTextBox.Text = "TDN-" & PNTextBox.Text
        End If
        Dim rowIndex As Integer = dv.Find(PNTextBox.Text)

        If rowIndex = -1 Then
            MessageBox.Show("你输入的料号不存在！", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PNTextBox.Clear()
            PNTextBox.Focus()
        Else
            Label11.Visible = True
            Label12.Visible = True
            Label14.Visible = True
            Label16.Visible = True
            Label10.Text = Trim(dv(rowIndex)("Part Number").ToString)
            Label13.Text = Trim(dv(rowIndex)("Location").ToString)
            Label15.Text = Trim(dv(rowIndex)("Price").ToString)
            Label17.Text = Trim(dv(rowIndex)("Description").ToString)

            Dim picname As String = Trim(dv(rowIndex)("Picture").ToString)

            Try
                PictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

            Catch ex As Exception
                PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If PNTextBox.Text = "" Then
            MessageBox.Show("请输入借用的料号，料号不能为空！", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PNTextBox.Focus()
        ElseIf Numbertextbox.Text = "" Then

            MessageBox.Show("请输入数量！", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Numbertextbox.Focus()
        ElseIf Numbertextbox.Text <> Int(Numbertextbox.Text) Then
            MessageBox.Show("请输入正确数量！" & vbCrLf & "数量一定为整数，哪有借半个的", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Numbertextbox.Clear()
            Numbertextbox.Focus()
        ElseIf jobid.Text = "" Then
            MessageBox.Show("请输入借料人的工号！", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            jobid.Focus()
        ElseIf photostextbox.Text = "" Then
            MessageBox.Show("请输入电话号码，有个联系方式好找人！", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            photostextbox.Focus()
        Else
            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from borrow_table", cn) '搬运工拉好水
            Dim ds As New DataSet()  '本地内存准备好容器来装水
            da.Fill(ds, "mytable")   '装水
            Dim drow As DataRow          '定义行变量
            drow = ds.Tables("mytable").NewRow   '行变量是新的一个行
            Try
                drow("借料单ID") = idlabel.Text     '新行赋值
                drow("料号") = PNTextBox.Text
                drow("数量") = Numbertextbox.Text
                drow("借料人") = jobid.Text & "-" & nametextbox.Text
                drow("电话") = photostextbox.Text
                drow("预计归还时间") = DateTimePicker1.Value
                drow("借料时间") = Format(Now, "yyyy-MM-dd hh:mm ")
                drow("状态") = "Open"
                drow("备注") = bztext.Text
                ds.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
                Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
                da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
                If CheckBox1.Checked = True Then
                    Try
                        Dim printDoc As New System.Drawing.Printing.PrintDocument
                        AddHandler printDoc.PrintPage, AddressOf Me.PrintText
                        printDoc.Print()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                End If
                MessageBox.Show("借料信息保存成功！" & vbCrLf & "增料模板已生成，请进入Baan系统增料！", "借料管理提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                sendmail()
                upid_Click(sender, e)


                inuser_Click(sender, e)

                addbom_Click(sender, e)
                PNTextBox.Clear()
                Numbertextbox.Clear()
                upda_Click(sender, e)

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If


    End Sub

    Private Sub sendmail()
        Dim FoundMatch As Boolean
        Try
            FoundMatch = Regex.IsMatch(mailtextbox.Text, "\w+([-+.]\w+)*@flextronics.com")
        Catch ex As ArgumentException
            'Syntax error in the regular expression
        End Try
        If FoundMatch Then
            Try
                Dim cn = New SqlConnection(FrmDataSql)
                Dim ii As String = "exec sp_formssend '" + idlabel.Text + "'"
                Dim cm = New SqlCommand(ii, cn)
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
                cn.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        End If
        'If mailtextbox.Text Like  Then
        '   
        'End If

    End Sub


    Private Sub PNTextBox_TextChanged(sender As Object, e As EventArgs)
        PNTextBox.Text = UCase(PNTextBox.Text)
        PNTextBox.SelectionStart = PNTextBox.Text.Length
    End Sub

    Private Sub PNTextBox__LostFocus(sender As Object, e As EventArgs) Handles PNTextBox.LostFocus
        PictureBox2_Click(sender, e)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Borrow_User", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")
        If jobid.Text <> "" Then
            Dim dv As New DataView(ds.Tables("mytable"), "", "工号", DataViewRowState.CurrentRows) '指定默认查找列为姓名

            Dim rowIndex As Integer = dv.Find(jobid.Text)

            If rowIndex = -1 Then
                u = "0"
                nametextbox.Enabled = True
                mailtextbox.Enabled = True
                bmtextbox.Enabled = True

            Else

                nametextbox.Text = Trim(dv(rowIndex)("姓名").ToString)
                photostextbox.Text = Trim(dv(rowIndex)("电话").ToString)
                mailtextbox.Text = Trim(dv(rowIndex)("邮箱").ToString)
                bmtextbox.Text = Trim(dv(rowIndex)("部门").ToString)
                p = Trim(dv(rowIndex)("电话").ToString)
                u = Trim(dv(rowIndex)("工号").ToString)
                Try
                    PictureBox6.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/userphoto/" & u & ".jpg").GetResponse().GetResponseStream())

                Catch ex As Exception
                    PictureBox6.Image = Image.FromFile(Application.StartupPath + "\\userphoto\nophoto.jpg")
                End Try

            End If
        End If
        cn.Close()

    End Sub

    Private Sub jobid_LostFocus(sender As Object, e As EventArgs) Handles jobid.LostFocus
        PictureBox3_Click(sender, e)
    End Sub

    Private Sub borrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripLabel1.Text = Uservar
        upda_Click(sender, e)
        imageup_Click(sender, e)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Borrow_ID", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "编号ID", DataViewRowState.CurrentRows) '指定默认查找列为姓名

        Dim rowIndex As Integer = dv.Find("借料单号")

        If rowIndex = -1 Then

        Else
            s = Trim(dv(rowIndex)("变量").ToString)
            Select Case s
                Case Is >= 1000
                    idlabel.Text = "EM" & s
                Case 100 To 999
                    idlabel.Text = "EM" & "0" & s
                Case 10 To 99
                    idlabel.Text = "EM" & "00" & s
                Case 1 To 9
                    idlabel.Text = "EM" & "000" & s



            End Select
        End If
        cn.Close()
    End Sub
    Public Sub imageup_Click(sender As Object, e As EventArgs)

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("WebPath")
        If rowIndex = -1 Then


            Exit Sub
        Else
            ImagePath = Trim(dv(rowIndex)("PortPath").ToString)


        End If
        cn.Close()

    End Sub
    Public Sub upid_Click(sender As Object, e As EventArgs)
        s = s + 1

        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Borrow_ID", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow
        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号ID")}
        drow = ds.Tables("mytable").Rows.Find("借料单号")
        Try
            drow("变量") = s

            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")
            Select Case s
                Case Is >= 1000
                    idlabel.Text = "EM" & s
                Case 100 To 999
                    idlabel.Text = "EM" & "0" & s
                Case 10 To 99
                    idlabel.Text = "EM" & "00" & s
                Case 1 To 9
                    idlabel.Text = "EM" & "000" & s



            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()
    End Sub
    Public Sub upuser_Click(sender As Object, e As EventArgs)
        If photostextbox.Text = p Then
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Borrow_User", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工号")}
            drow = ds.Tables("mytable").Rows.Find(jobid.Text)
            Try
                drow("电话") = photostextbox.Text

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If

    End Sub
    Public Sub inuser_Click(sender As Object, e As EventArgs)
        If jobid.Text <> u Then
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from borrow_User", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            drow = ds.Tables("mytable").NewRow
            Try
                drow("工号") = jobid.Text
                drow("姓名") = nametextbox.Text
                drow("电话") = photostextbox.Text
                drow("邮箱") = mailtextbox.Text
                drow("部门") = bmtextbox.Text

                ds.Tables("mytable").Rows.Add(drow)
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")
                nametextbox.Enabled = False
                mailtextbox.Enabled = False
                bmtextbox.Enabled = False


            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        Else
            upuser_Click(sender, e)
        End If

    End Sub
    Public Sub addbom_Click(sender As Object, e As EventArgs)
        Dim ek As String
        'Dim MyDesktop As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  '得到我的桌面路径
        If PNTextBox.Text = "TDN-979-251-01" Or PNTextBox.Text = "TDN-979-392-01" Then
            ek = "J11203"
        Else
            ek = "J11210"

        End If
        Dim remark As String = "ID:" & jobid.Text & "  TEL:" & photostextbox.Text
        Dim y As String = "22	IS3	3	MN	J11101	" & ek & "						" & PNTextBox.Text & "				" & remark & "		" & Numbertextbox.Text

        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\\order\requests.txt", y & vbCrLf, False, System.Text.Encoding.Default)

    End Sub


    Private Sub PrintText(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        ev.Graphics.DrawString("借料单", New Font("Arial", 25, FontStyle.Bold), Brushes.Black, 320, 70)
        ev.Graphics.DrawString("单号：" & idlabel.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 650, 30)
        ev.Graphics.DrawString("================================================", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 150, 120)
        ev.Graphics.DrawString("物料信息：", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 200)
        ev.Graphics.DrawString("料号： " & PNTextBox.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 250)
        ev.Graphics.DrawString("数量： " & Numbertextbox.Text & " Pcs", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 420, 250)
        ev.Graphics.DrawString("库位： " & Label13.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 280)
        ev.Graphics.DrawString("价格： " & Label15.Text & "  $", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 420, 280)
        ev.Graphics.DrawString("物料描述： " & Label17.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 310)
        ev.Graphics.DrawString("借料人信息：", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 400)
        ev.Graphics.DrawString("工号： " & jobid.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 450)
        ev.Graphics.DrawString("姓名： " & nametextbox.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 200, 450)
        ev.Graphics.DrawString("部门： " & bmtextbox.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 400, 450)
        ev.Graphics.DrawString("电话： " & photostextbox.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 480)
        ev.Graphics.DrawString("E-mail： " & mailtextbox.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 300, 480)
        ev.Graphics.DrawString("借料时间： " & Format(Now, "yyyy-MM-dd hh:mm:ss "), New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 580)
        ev.Graphics.DrawString("预计还料时间： " & DateTimePicker1.Value, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, 620)
        ev.Graphics.DrawString("MC负责人", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 290, 715)
        ev.Graphics.DrawString("借料人", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 550, 715)
        ev.Graphics.DrawString("签名", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 115, 795)
        ev.Graphics.DrawString("时间", New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 115, 855)
        ev.Graphics.DrawString(Uservar, New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 290, 795)
        ev.Graphics.DrawString(Format(Now, "MM/dd/yyyy "), New Font("Arial", 12, FontStyle.Regular), Brushes.Black, 290, 855)
        ev.Graphics.DrawLine(Pens.Black, 70, 700, 700, 700)
        ev.Graphics.DrawLine(Pens.Black, 70, 750, 700, 750)
        ev.Graphics.DrawLine(Pens.Black, 70, 850, 700, 850)
        ev.Graphics.DrawLine(Pens.Black, 70, 880, 700, 880)
        ev.Graphics.DrawLine(Pens.Black, 70, 700, 70, 880)
        ev.Graphics.DrawLine(Pens.Black, 200, 700, 200, 880)
        ev.Graphics.DrawLine(Pens.Black, 450, 700, 450, 880)
        ev.Graphics.DrawLine(Pens.Black, 700, 700, 700, 880)
        ev.HasMorePages = False
    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from borrow_table WHERE 状态='Open'", cn) '搬运工拉好水
        Dim ds As New DataSet()  '本地内存准备好容器来装水
        da.Fill(ds, "mytable")   '装水        
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(1).Width = 160
        'DataGridView1.Columns(2).Width = 160
        'DataGridView1.Columns(3).Width = 370
        'DataGridView1.Columns(4).Width = 105

        cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String
        If ComboBox2.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else

            If ComboBox2.Text = "借料时间" Or ComboBox2.Text = "预计归还时间" Then
                Dim dtStart As DateTime = DateTimePicker4.Value
                Dim dtEnd As DateTime = DateTimePicker3.Value
                Dim s As Integer
                s = DateDiff(DateInterval.Day, dtEnd, dtStart)
                If s > 90 Then
                    MessageBox.Show("查询时间不能超过90天", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf s < 0 Then
                    MessageBox.Show("起始时间不能大于结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else




                    cn = New SqlConnection(cnStr)
                    sql = "select * from borrow_table where " & ComboBox2.Text & " BETWEEN '" & DateTimePicker3.Value & "' AND '" & DateTimePicker4.Value & "'"
                    'sql = "select * from borrow_table where " & ComboBox2.Text & " BETWEEN '2015/11/02 19:34:24' and '2015/11/04 19:34:24'"
                    da = New SqlDataAdapter(sql, cn) '表名
                    ds = New DataSet()
                    da.Fill(ds, "mytable")
                    DataGridView1.DataSource = ds.Tables("mytable") '表名
                    cn.Close()
                    Exit Sub
                End If
            ElseIf ComboBox2.Text = "状态" Then
                sxbl = ComboBox3.Text
                cn = New SqlConnection(cnStr)

                sql = "select * from borrow_table where " & ComboBox2.Text & " like " & "'%" & sxbl & "%'"
                da = New SqlDataAdapter(sql, cn) '表名
                ds = New DataSet()
                da.Fill(ds, "mytable")
                DataGridView1.DataSource = ds.Tables("mytable") '表名
                cn.Close()
            Else
                sxbl = TextBox5.Text
                cn = New SqlConnection(cnStr)

                sql = "select * from borrow_table where " & ComboBox2.Text & " like " & "'%" & sxbl & "%'"
                da = New SqlDataAdapter(sql, cn) '表名
                ds = New DataSet()
                da.Fill(ds, "mytable")
                DataGridView1.DataSource = ds.Tables("mytable") '表名
                cn.Close()
            End If






        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "借料时间" Or ComboBox2.Text = "预计归还时间" Then
            Label2.Visible = True
            Label19.Visible = True
            DateTimePicker3.Visible = True
            DateTimePicker4.Visible = True
            TextBox5.Visible = False
            ComboBox3.Visible = False
        ElseIf ComboBox2.Text = "状态" Then
            Label2.Visible = False
            Label19.Visible = False
            DateTimePicker3.Visible = False
            DateTimePicker4.Visible = False
            TextBox5.Visible = False
            ComboBox3.Visible = True
        Else
            Label2.Visible = False
            Label19.Visible = False
            DateTimePicker3.Visible = False
            DateTimePicker4.Visible = False
            TextBox5.Visible = True
            ComboBox3.Visible = False
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value.ToString()
        Label24.Text = DataGridView1.Item(1, i).Value.ToString()
        Label25.Text = DataGridView1.Item(2, i).Value.ToString()

        Dim picname As String = Label24.Text.Substring(4)

        Try
            PictureBox5.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

        Catch ex As Exception
            PictureBox5.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("请选择要还的物料", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Borrow_table", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("借料单ID")}
            drow = ds.Tables("mytable").Rows.Find(TextBox2.Text)
            Try
                drow("状态") = "Close"
                drow("备注") = TextBox1.Text

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")
                huanliao(TextBox2.Text)

                MessageBox.Show("物料 " & Label24.Text & " 已还回来了", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            upda_Click(sender, e)
            Label24.Text = ""
            Label25.Text = ""
            PictureBox5.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End If

    End Sub
    Private Sub huanliao(id As String)

        Try
            Dim cn = New SqlConnection(FrmDataSql)
            Dim ii As String = "DELETE ReturnPlan WHERE ItemID='" + id + "'"
            Dim cm = New SqlCommand(ii, cn)
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
            cn.Dispose()
        Catch ex As Exception

        End Try
    End Sub



End Class