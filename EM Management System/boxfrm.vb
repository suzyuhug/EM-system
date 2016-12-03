Imports System.Data.SqlClient
Public Class boxfrm
    Dim m_items As New ArrayList
    Dim moid As String
    Dim b As String
    Dim bhgrid As String
    Dim baan As String
    Dim ImagePath As String

    Private Sub boxfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Width = Me.Width - 40
        Panel2.Height = Me.Height - 350
        Panel1.Top = Panel2.Top + Panel2.Height + 5
        ToolStripLabel1.Text = Uservar
        upparl_Click(sender, e)
        imageup_Click(sender, e)
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
    Private Sub boxfrm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Panel2.Width = Me.Width - 40
        Panel2.Height = Me.Height - 350
        Panel1.Top = Panel2.Top + Panel2.Height + 5


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)


        'Dim screenPoint As Point
        'screenPoint = Me.PointToScreen(New Point(e.x, e.y))

        ' ContextMenuStrip1.Show(screenPoint)

        Try


            Dim i As Integer = DataGridView1.CurrentRow.Index


            moid = DataGridView1.Item(0, i).Value.ToString()


            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            cn.Open()
            Dim a As String = "SELECT * FROM box_List WHERE 型号 ='" & moid & "'"
            Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            Dim s As Integer = "0"
            While dr.Read()
                s = s + 1

                '-------------------------------------------------------------------------
                Dim boxbut As New ckpass
                boxbut.value = Trim(dr("名称").ToString + Space(5))
                boxbut.Top = 40 * i
                boxbut.Left = (110 * s) - 100
                Me.Panel2.Controls.Add(boxbut)

                AddHandler boxbut.BtnClick, AddressOf boxbutarrayclick


                '---------------------------------------------------------------------------



            End While
            cn.Close()
        Catch ex As Exception

        End Try
    End Sub





    Private Sub boxbutarrayclick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim boxtext As String
        Dim itext As String
        Dim pntext As String
        Dim bhtext As String
        Dim shutext As String

        boxtext = CType(sender, ckpass).value
        itext = CType(sender, ckpass).piclog
        pntext = CType(sender, ckpass).parin
        bhtext = CType(sender, ckpass).gongdan
        shutext = CType(sender, ckpass).shuliang
        If itext = "0" Then
            b = b + 1
            If pntext = "TDN-979-251-01" Or pntext = "TDN-979-392-01" Then
                DataGridView1.Rows.Insert(0)
                DataGridView1.Rows(0).Cells(0).Value = bhtext
                DataGridView1.Rows(0).Cells(1).Value = pntext
                DataGridView1.Rows(0).Cells(2).Value = shutext
            Else
                DataGridView1.Rows.Add(1)
                DataGridView1.Rows(b).Cells(0).Value = bhtext
                DataGridView1.Rows(b).Cells(1).Value = pntext
                DataGridView1.Rows(b).Cells(2).Value = shutext
            End If
        ElseIf itext = "1" Then
            If DataGridView1.RowCount <= 0 Then Exit Sub
            Dim iIndex As Integer
            Dim strworderid As String
            For i As Integer = 0 To DataGridView1.RowCount - 1
                strworderid = DataGridView1.Rows(i).Cells(1).Value.ToString.Trim
                If strworderid = pntext Then
                    iIndex = i
                    Exit For
                End If
            Next
            DataGridView1.Rows(iIndex).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(iIndex).Cells(1)

            DataGridView1.Rows.RemoveAt(iIndex)
            b = b - 1

        End If
        Dim picname As String = pntext.Substring(4)
        Label1.Text = pntext

        Try
            PictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

        Catch ex As Exception
            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("请选择要增的木箱！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Dim pngrid As String
        Dim numgrid As String
        baan = ""
        For i As Integer = 0 To DataGridView1.RowCount - 1
            bhgrid = DataGridView1.Rows(i).Cells(0).Value.ToString.Trim
            pngrid = DataGridView1.Rows(i).Cells(1).Value.ToString.Trim
            numgrid = DataGridView1.Rows(i).Cells(2).Value.ToString.Trim
            'Dim drred As Integer
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)

            Dim da As SqlCommand = New SqlCommand("delete from box_view WHERE 编号='" & bhgrid & "' and 木箱料号='" & pngrid & "'", cn)
            cn.Open()
            da.ExecuteNonQuery()

            cn.Close()

            logview_Click(sender, e)
            Dim ek As String
            Dim remark As String = ""
            If pngrid = "TDN-979-251-01" Or pngrid = "TDN-979-392-01" Then
                ek = "J11203"
            Else
                ek = "J11210"
            End If

            baan &= "22	IS3	3	MN	J11101	" & ek & "						" & pngrid & "				" & remark & "		" & numgrid
            baan &= vbCrLf
            If CheckBox1.Checked = True Then
                addbom_Click(sender, e)
            End If
        Next
        MessageBox.Show("信息保存成功，增料模板已生成到桌面order文件夹内，请切换到Baan系统进行增料！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)


        ' upparl_Click(sender, e)
        DataGridView1.Rows.Clear()
        Label1.Text = ""
        PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
    End Sub

    Public Sub logview_Click(sender As Object, e As EventArgs)
        Try
            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As SqlDataAdapter = New SqlDataAdapter("select * from box_view", cn) '表名
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "mytable")

            Dim dv As New DataView(ds.Tables("mytable"), "", "编号", DataViewRowState.CurrentRows) '指定默认查找列为姓名
            Dim rowIndex As Integer = dv.Find(bhgrid)
            If rowIndex = -1 Then
                uptabel_Click(sender, e)

            Else
                uptabel1_Click(sender, e)

            End If
            cn.Close()


        Catch ex As Exception
            Dataerror.Show()

        End Try

    End Sub
    Public Sub uptabel_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn) '搬运工拉好水
        Dim ds As New DataSet()  '本地内存准备好容器来装水
        da.Fill(ds, "mytable")   '装水
        Dim drow As DataRow          '定义行变量

        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(bhgrid)
        Try


            drow("木箱状态") = "Close"
            drow("木箱上线时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("木箱管理员") = Uservar


            Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
            da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()


    End Sub
    Public Sub uptabel1_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn) '搬运工拉好水
        Dim ds As New DataSet()  '本地内存准备好容器来装水
        da.Fill(ds, "mytable")   '装水
        Dim drow As DataRow          '定义行变量

        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(bhgrid)
        Try


            drow("木箱状态") = "未完成"
            drow("木箱上线时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("木箱管理员") = Uservar


            Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
            da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()


    End Sub
    Public Sub upparl_Click(sender As Object, e As EventArgs)
        b = "-1"

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_table WHERE 木箱状态 ='Open' or 木箱状态 ='未完成'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        Dim i As Integer = "0"
        While dr.Read()
            i = i + 1
            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            cn1.Open()
            Dim c As String = Trim(dr("编号").ToString + Space(5))
            Dim b As String = "SELECT * FROM box_view WHERE 编号 ='" & c & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(b, cn1) '表名
            Dim br As SqlDataReader
            br = cmd1.ExecuteReader()

            Dim boxlabel As New mControl1
            boxlabel.value = Trim(dr("型号").ToString + Space(5))
            boxlabel.Top = 45 * i - 40
            boxlabel.Left = 10
            Me.Panel2.Controls.Add(boxlabel)
            Dim s As Integer = "0"
            While br.Read()


                s = s + 1

                '-------------------------------------------------------------------------
                Dim boxbut As New ckpass
                boxbut.value = Trim(br("名称").ToString + Space(5))
                boxbut.parin = Trim(br("木箱料号").ToString + Space(5))
                boxbut.gongdan = Trim(br("编号").ToString + Space(5))
                boxbut.shuliang = Trim(br("数量").ToString + Space(5))
                boxbut.Top = 45 * i - 35
                boxbut.Left = (110 * s) + 5
                Me.Panel2.Controls.Add(boxbut)

                AddHandler boxbut.BtnClick, AddressOf boxbutarrayclick


                '---------------------------------------------------------------------------




            End While
            cn1.Close()
        End While
        cn.Close()
    End Sub


    Public Sub addbom_Click(sender As Object, e As EventArgs)
        'Dim MyDesktop As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  '得到我的桌面路径       

        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\\order\requests.txt", baan, False, System.Text.Encoding.Default)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class