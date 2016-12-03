Imports System.Data.SqlClient

Imports System.Drawing.Drawing2D
Public Class toolfrm
    Dim gp As New GraphicsPath
    Dim gp1 As New GraphicsPath
    Dim gr As Graphics '定义画布
    Dim gr1 As Graphics '定义画布
    Dim bp As New Bitmap(800, 500) '定义位图,并进行赋值
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet


    Dim snid, model, bs, jyfw, pj1, pj2, pj3, nw, sy, qsrq, jsrq, syy, sc As String

    Dim sql, sqlpath, sqltable, sqluser, sqlpw As String
    Dim ImagePath As String
    Dim zf, zx, zd As String

    Private Sub toolfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        portup_Click(sender, e)
        imageup_Click(sender, e)
        sql = "Data Source=" & sqlpath & ";Initial Catalog=" & sqltable & ";Integrated Security=False;User ID=" & sqluser & ";Password=" & sqlpw & ";"
        Dim pn As New Pen(Color.Gray, 1)

        pn.DashStyle = DashStyle.Dash
        PictureBox1.Image = bp
        gr = Graphics.FromImage(PictureBox1.Image)
        For i As Integer = 1 To 9
            gp.CloseAllFigures()
            gp.AddLine(New Point(0, 50 * i), New Point(800, 50 * i))
            gr.DrawPath(pn, gp)
            gp.CloseAllFigures()
            gp.AddLine(New Point(100 * i, 0), New Point(100 * i, 500))
            gr.DrawPath(pn, gp)
        Next


        RadioButton1.Checked = True
    End Sub
    Public Sub portup_Click(sender As Object, e As EventArgs)

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("ToolStatus")
        If rowIndex = -1 Then


            Exit Sub
        Else
            sqlpath = Trim(dv(rowIndex)("PortPath").ToString)
            sqltable = Trim(dv(rowIndex)("TableName").ToString)
            sqluser = Trim(dv(rowIndex)("PortUser").ToString)
            sqlpw = Trim(dv(rowIndex)("PortPassWord").ToString)

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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label22.Visible = True
        Application.DoEvents()
        cn = New SqlConnection(sql)
        da = New SqlDataAdapter("select * from ScrewDriverMaster", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名
        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False

        DataGridView1.Columns(14).Visible = False
        DataGridView1.Columns(15).Visible = False
        DataGridView1.Columns(16).Visible = False
        DataGridView1.Columns(17).Visible = False
        DataGridView1.Columns(18).Visible = False
        DataGridView1.Columns(19).Visible = False
        DataGridView1.Columns(21).Visible = False
        DataGridView1.Columns(22).Visible = False
        DataGridView1.Columns(24).Visible = False
        DataGridView1.Columns(25).Visible = False
        DataGridView1.Columns(26).Visible = False
        DataGridView1.Columns(27).Visible = False
        Label22.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label22.Visible = True
        Application.DoEvents()
        cn = New SqlConnection(sql)
        da = New SqlDataAdapter("select * from ScrewDriverHistory", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名
        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False

        DataGridView1.Columns(14).Visible = False
        DataGridView1.Columns(15).Visible = False
        DataGridView1.Columns(16).Visible = False
        DataGridView1.Columns(17).Visible = False
        DataGridView1.Columns(18).Visible = False
        DataGridView1.Columns(19).Visible = False
        DataGridView1.Columns(21).Visible = False
        DataGridView1.Columns(22).Visible = False
        DataGridView1.Columns(24).Visible = False
        DataGridView1.Columns(25).Visible = False
        DataGridView1.Columns(26).Visible = False
        DataGridView1.Columns(27).Visible = False
        Label22.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql1 As String = ""
        If TextBox1.Text = "" Then
            MessageBox.Show("内容不能为空，请输入！")
            TextBox1.Focus()
        Else

            If RadioButton1.Checked = True Then
                sql1 = "select * from ScrewDriverMaster where SN like " & "'%" & TextBox1.Text & "%'"
            ElseIf RadioButton2.Checked = True Then
                sql1 = "select * from ScrewDriverHistory where SN like " & "'%" & TextBox1.Text & "%'"
            End If

            cn = New SqlConnection(sql)

            da = New SqlDataAdapter(sql1, cn) '表名
            ds = New DataSet()
            da.Fill(ds, "mytable")
            DataGridView1.DataSource = ds.Tables("mytable") '表名
            If DataGridView1.RowCount > 0 Then

                Dim picname As String = Trim(DataGridView1.Item(1, 0).Value.ToString())
                TextBox1.Clear()
                TextBox1.Focus()

                Try
                    PictureBox2.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/toolpic/" & picname & ".jpg").GetResponse().GetResponseStream())

                Catch ex As Exception
                    PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                End Try
            Else
                MessageBox.Show("料号不存在，请确认后再查询！")
                TextBox1.Clear()
                TextBox1.Focus()

            End If
            cn.Close()
        End If



    End Sub





    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TreeView1.Nodes.Clear()
        Dim i As Integer = DataGridView1.CurrentRow.Index
        snid = Trim(DataGridView1.Item(1, i).Value.ToString())
        model = DataGridView1.Item(2, i).Value.ToString()
        bs = DataGridView1.Item(3, i).Value.ToString()
        jyfw = DataGridView1.Item(4, i).Value.ToString()
        qsrq = DataGridView1.Item(5, i).Value.ToString()
        jsrq = DataGridView1.Item(6, i).Value.ToString()
        sc = DataGridView1.Item(9, i).Value.ToString()
        pj1 = DataGridView1.Item(10, i).Value.ToString()
        pj2 = DataGridView1.Item(11, i).Value.ToString()
        pj3 = DataGridView1.Item(12, i).Value.ToString()
        nw = DataGridView1.Item(13, i).Value.ToString()
        sy = DataGridView1.Item(23, i).Value.ToString()
        syy = DataGridView1.Item(20, i).Value.ToString()
        TreeView1.Nodes.Add("序列号： " & snid)
        TreeView1.Nodes.Add("标准磅数： " & bs)
        TreeView1.Nodes.Add("校验日期： " & sy)
        TreeView1.Nodes.Add("校验员： " & syy)
        TreeView1.Nodes(0).Nodes.Add("工具类型： " & model)
        TreeView1.Nodes(1).Nodes.Add("磅数范围： " & jyfw)
        TreeView1.Nodes(1).Nodes.Add("第一次数据： " & pj1)
        TreeView1.Nodes(1).Nodes.Add("第二次数据： " & pj2)
        TreeView1.Nodes(1).Nodes.Add("第三次数据： " & pj3)
        TreeView1.Nodes(1).Nodes.Add("平均值： " & nw)
        TreeView1.Nodes(2).Nodes.Add("开始日期： " & qsrq)
        TreeView1.Nodes(2).Nodes.Add("结束日期： " & jsrq)

        TreeView1.Nodes(0).ExpandAll()
        TreeView1.Nodes(1).ExpandAll()
        TreeView1.Nodes(2).ExpandAll()

        upid_Click(sender, e)

        Try
            PictureBox2.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/toolpic/" & snid & ".jpg").GetResponse().GetResponseStream())

        Catch ex As Exception
            PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End Try

        zf = ""
        For x = 1 To bs.Length
            Dim txt As String = Mid(bs, x, 1)
            If txt Like "#" Or txt = "." Then

                zf = zf & txt
            End If
        Next

        zx = zf - (Int(zf) * 0.05)
        zd = zf + (Int(zf) * 0.05)



        Try


            Select Case Int(pj1)
                Case Is >= 100
                    Label8.Text = "100"
                    Label9.Text = "200"
                    Label10.Text = "300"
                    Label11.Text = "400"
                    Label12.Text = "500"
                    Label13.Text = "600"
                    Label14.Text = "700"
                    Label15.Text = "800"
                    Label16.Text = "900"
                    If sc <> "" Then Label17.Location = New Point(151, 180 - ((Int(sc) / 100) * 18) - 15) : Label17.Text = sc
                    If pj1 <> "" Then Label18.Location = New Point(212, 180 - ((Int(pj1) / 100) * 18) - 15) : Label18.Text = pj1
                    If pj2 <> "" Then Label19.Location = New Point(273, 180 - ((Int(pj2) / 100) * 18) - 15) : Label19.Text = pj2
                    If pj3 <> "" Then Label20.Location = New Point(334, 180 - ((Int(pj3) / 100) * 18) - 15) : Label20.Text = pj3
                    If nw <> "" Then Label21.Location = New Point(395, 180 - ((Int(nw) / 100) * 18) - 15) : Label21.Text = nw

                    If sc <> "" Then PictureBox3.Location = New Point(151, 180 - ((Int(sc) / 100) * 18))
                    If pj1 <> "" Then PictureBox4.Location = New Point(212, 180 - ((Int(pj1) / 100) * 18))
                    If pj2 <> "" Then PictureBox5.Location = New Point(273, 180 - ((Int(pj2) / 100) * 18))
                    If pj3 <> "" Then PictureBox6.Location = New Point(334, 180 - ((Int(pj3) / 100) * 18))
                    If nw <> "" Then PictureBox7.Location = New Point(395, 180 - ((Int(nw) / 100) * 18))
                    If zx <> "" Then PictureBox8.Location = New Point(90, 180 - ((Int(zx) / 100) * 18))
                    If zd <> "" Then PictureBox9.Location = New Point(90, 180 - ((Int(zd) / 100) * 18))

                Case 10 To 100
                    Label8.Text = "10"
                    Label9.Text = "20"
                    Label10.Text = "30"
                    Label11.Text = "40"
                    Label12.Text = "50"
                    Label13.Text = "60"
                    Label14.Text = "70"
                    Label15.Text = "80"
                    Label16.Text = "90"
                    If sc <> "" Then Label17.Location = New Point(151, 180 - ((Int(sc) / 10) * 18) - 15) : Label17.Text = sc
                    If pj1 <> "" Then Label18.Location = New Point(212, 180 - ((Int(pj1) / 10) * 18) - 15) : Label18.Text = pj1
                    If pj2 <> "" Then Label19.Location = New Point(273, 180 - ((Int(pj2) / 10) * 18) - 15) : Label19.Text = pj2
                    If pj3 <> "" Then Label20.Location = New Point(334, 180 - ((Int(pj3) / 10) * 18) - 15) : Label20.Text = pj3
                    If nw <> "" Then Label21.Location = New Point(395, 180 - ((Int(nw) / 10) * 18) - 15) : Label21.Text = nw
                    If sc <> "" Then PictureBox3.Location = New Point(151, 180 - ((Int(sc) / 10) * 18))
                    If pj1 <> "" Then PictureBox4.Location = New Point(212, 180 - ((Int(pj1) / 10) * 18))
                    If pj2 <> "" Then PictureBox5.Location = New Point(273, 180 - ((Int(pj2) / 10) * 18))
                    If pj3 <> "" Then PictureBox6.Location = New Point(334, 180 - ((Int(pj3) / 10) * 18))
                    If nw <> "" Then PictureBox7.Location = New Point(395, 180 - ((Int(nw) / 10) * 18))
                    If zx <> "" Then PictureBox8.Location = New Point(90, 180 - ((Int(zx) / 10) * 18))
                    If zd <> "" Then PictureBox9.Location = New Point(90, 180 - ((Int(zd) / 10) * 18))


                Case 1 To 10
                    Label8.Text = "1"
                    Label9.Text = "2"
                    Label10.Text = "3"
                    Label11.Text = "4"
                    Label12.Text = "5"
                    Label13.Text = "6"
                    Label14.Text = "7"
                    Label15.Text = "8"
                    Label16.Text = "9"
                    If sc <> "" Then Label17.Location = New Point(151, 180 - (Int(sc) * 18) - 15) : Label17.Text = sc
                    If pj1 <> "" Then Label18.Location = New Point(212, 180 - (Int(pj1) * 18) - 15) : Label18.Text = pj1
                    If pj2 <> "" Then Label19.Location = New Point(273, 180 - (Int(pj2) * 18) - 15) : Label19.Text = pj2
                    If pj3 <> "" Then Label20.Location = New Point(334, 180 - (Int(pj3) * 18) - 15) : Label20.Text = pj3
                    If nw <> "" Then Label21.Location = New Point(395, 180 - (Int(nw) * 18) - 15) : Label21.Text = nw
                    If sc <> "" Then PictureBox3.Location = New Point(151, 180 - (Int(sc) * 18))
                    If pj1 <> "" Then PictureBox4.Location = New Point(212, 180 - (Int(pj1) * 18))
                    If pj2 <> "" Then PictureBox5.Location = New Point(273, 180 - (Int(pj2) * 18))
                    If pj3 <> "" Then PictureBox6.Location = New Point(334, 180 - (Int(pj3) * 18))
                    If nw <> "" Then PictureBox7.Location = New Point(395, 180 - (Int(nw) * 18))
                    If zx <> "" Then PictureBox8.Location = New Point(90, 180 - (Int(zx) * 18))
                    If zd <> "" Then PictureBox9.Location = New Point(90, 180 - (Int(zd) * 18))
            End Select

            Label17.Visible = True
            Label18.Visible = True
            Label19.Visible = True
            Label20.Visible = True
            Label21.Visible = True
            PictureBox3.Visible = True
            PictureBox4.Visible = True
            PictureBox5.Visible = True
            PictureBox6.Visible = True
            PictureBox7.Visible = True
            PictureBox8.Visible = True
            PictureBox9.Visible = True

        Catch ex As Exception

        End Try


    End Sub

    Public Sub upid_Click(sender As Object, e As EventArgs)

        TreeView2.Nodes.Clear()

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Tool_list", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "工具序列号", DataViewRowState.CurrentRows) '指定默认查找列为姓名

        Dim rowIndex As Integer = dv.Find(Trim(snid))

        If rowIndex = -1 Then
            TreeView2.Nodes.Add("别的部门工具")
        Else

            TreeView2.Nodes.Add("序列号： " & snid)
            TreeView2.Nodes(0).Nodes.Add("工具类型： " & Trim(dv(rowIndex)("工具类型").ToString))
            TreeView2.Nodes(0).Nodes.Add("工具位置： " & Trim(dv(rowIndex)("工具位置").ToString))
            TreeView2.Nodes(0).ExpandAll()
        End If
        cn.Close()
    End Sub

End Class