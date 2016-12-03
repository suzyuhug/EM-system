Imports System.Data.SqlClient
Public Class touorderfrm
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sxbl As String
    Dim bhid As String
    Dim pn(8) As TextBox
    Dim dd(8) As TextBox
    Dim bu(8) As Button
    Dim sx(8) As TextBox
    Dim mbpn As String
    Dim baan As String
    Dim orderid As String
    Dim ordersum As Integer

    Private Sub touorderfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Uservarlook.Text = Uservar
        upda_Click(sender, e)


    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select 编号,型号,料号,登记时间,登记管理员 from Order_table WHERE 工单登记='Open'", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(1).Width = 160
        'DataGridView1.Columns(2).Width = 160
        'DataGridView1.Columns(3).Width = 370
        'DataGridView1.Columns(4).Width = 105

        cn.Close()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ordersum = 10000000
        Dim z As Integer = DataGridView1.CurrentRow.Index
        bhid = DataGridView1.Item(0, z).Value.ToString()
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_view WHERE 编号 ='" & bhid & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        bu(1) = bu1 : bu(2) = bu2 : bu(3) = bu3 : bu(4) = bu4 : bu(5) = bu5 : bu(6) = bu6 : bu(7) = bu7 : bu(8) = bu8
        pn(1) = pn1 : pn(2) = pn2 : pn(3) = pn3 : pn(4) = pn4 : pn(5) = pn5 : pn(6) = pn6 : pn(7) = pn7 : pn(8) = pn8
        dd(1) = dd1 : dd(2) = dd2 : dd(3) = dd3 : dd(4) = dd4 : dd(5) = dd5 : dd(6) = dd6 : dd(7) = dd7 : dd(8) = dd8
        sx(1) = sx1 : sx(2) = sx2 : sx(3) = sx3 : sx(4) = sx4 : sx(5) = sx5 : sx(6) = sx6 : sx(7) = sx7 : sx(8) = sx8
        For s As Integer = 1 To 8
            pn(s).Visible = False
            bu(s).Visible = False
            dd(s).Visible = False

        Next s
        Dim i As Integer = 0
        While dr.Read()
            i = i + 1
            If Trim(dr("工单上线").ToString + Space(5)) <> "已上线" Then
                bu(i).Visible = True
                sx(i).Text = "待投"
            End If
            pn(i).Visible = True

            dd(i).Visible = True
            pn(i).Text = Trim(dr("料号").ToString + Space(5))

            dd(i).Text = Trim(dr("工单号").ToString + Space(5))
            If Trim(dr("数量").ToString + Space(5)) < ordersum Then ordersum = Trim(dr("数量").ToString + Space(5))


        End While

        cn.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If dd1.Text <> "" Then

            If MessageBox.Show("您确定你要投工单吗，点击（确定）将无法返回！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = DialogResult.OK Then

                Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
                Dim cn As SqlConnection = New SqlConnection(cnStr)
                Dim da As New SqlDataAdapter("select * from Order_table", cn) '搬运工拉好水
                Dim ds As New DataSet()  '本地内存准备好容器来装水
                da.Fill(ds, "mytable")   '装水
                Dim drow As DataRow          '定义行变量

                ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
                drow = ds.Tables("mytable").Rows.Find(bhid)
                Try


                    drow("系统序列号") = "Open"
                    drow("投工单") = "工单已投"
                    drow("工单登记") = "Close"
                    drow("木箱状态") = "Open"
                    drow("检查表打印") = "Open"
                    drow("预计上线时间") = DateTimePicker1.Value
                    drow("投工单时间") = Format(Now, "yyyy-MM-dd hh:mm ")
                    drow("投工单管理员") = Uservar



                    Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
                    da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
                    MessageBox.Show("工单已保存成功，请投下一份工单", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    upview_Click(sender, e)
                    upda_Click(sender, e)
                    Dim x As Integer
                    For x = 1 To 8
                        pn(x).Visible = False
                        bu(x).Visible = False
                        dd(x).Visible = False
                        pn(x).Clear()
                        dd(x).Clear()
                        bu(x).Text = "生成模板"
                        bhid = ""
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
                cn.Close()
            End If
        Else

                MessageBox.Show("请选择一个要投的工单!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


    End Sub

    Private Sub bu1_Click(sender As Object, e As EventArgs) Handles bu1.Click
        If bu1.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn1.Text
            bu1.Text = "已生成"
            orderid = dd1.Text
            addbom_Click(sender, e)
        End If
    End Sub
    Public Sub addbom_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Try
            cn.Open()

            Dim a As String = "SELECT * FROM bom_List WHERE 系统料号 ='" & mbpn & "'"
            Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()


            baan = ""
            While dr.Read()
                Dim pngrid As String = Trim(dr("工单料号").ToString + Space(5))
                Dim numgrid As Integer = Int(Trim(dr("数量").ToString + Space(5))) * Int(ordersum)
                Dim ek As String
                If pngrid = "TDN-979-392-01" Or pngrid = "TDN-979-251-01" Then
                    ek = "J11203"
                Else
                    ek = "J11210"
                End If
                baan &= "22	IS3	3	MN	J11101	" & ek & "						" & pngrid & "				" & orderid & "		" & numgrid
                baan &= vbCrLf



            End While
            cn.Close()
            'Dim MyDesktop As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  '得到我的桌面路径       

            My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\\order\requests.txt", baan, False, System.Text.Encoding.Default)
            MessageBox.Show("工单模版已生成到桌面Order文件夹内，请切换到BAAN系统进行增料！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch ex As Exception
            MessageBox.Show("出错了，可能桌面没有Order文件夹！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub upview_Click(sender As Object, e As EventArgs)
        For s = 1 To 8
            If dd(s).Text <> "" Then

                Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
                Dim cn As SqlConnection = New SqlConnection(cnStr)
                Dim da As New SqlDataAdapter("select * from Order_view", cn) '搬运工拉好水
                Dim ds As New DataSet()  '本地内存准备好容器来装水
                da.Fill(ds, "mytable")   '装水
                Dim drow As DataRow          '定义行变量

                ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工单号")}
                drow = ds.Tables("mytable").Rows.Find(dd(s).Text)
                Try
                    If sx(s).Text = "待投" Then
                        drow("工单上线") = "未上线"
                    End If
                    Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
                    da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
                cn.Close()
            End If


        Next



    End Sub

    Private Sub bu2_Click(sender As Object, e As EventArgs) Handles bu2.Click
        If bu2.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn2.Text
            bu2.Text = "已生成"
            orderid = dd2.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub bu3_Click(sender As Object, e As EventArgs) Handles bu3.Click
        If bu3.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn3.Text
            bu3.Text = "已生成"
            orderid = dd3.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub bu4_Click(sender As Object, e As EventArgs) Handles bu4.Click
        If bu4.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn4.Text
            bu4.Text = "已生成"
            orderid = dd4.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub bu5_Click(sender As Object, e As EventArgs) Handles bu5.Click
        If bu5.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn5.Text
            bu5.Text = "已生成"
            orderid = dd5.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub bu6_Click(sender As Object, e As EventArgs) Handles bu6.Click
        If bu6.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn6.Text
            bu6.Text = "已生成"
            orderid = dd6.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub bu7_Click(sender As Object, e As EventArgs) Handles bu7.Click
        If bu7.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn7.Text
            bu7.Text = "已生成"
            orderid = dd7.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub bu8_Click(sender As Object, e As EventArgs) Handles bu8.Click
        If bu8.Text = "已生成" Then
            MessageBox.Show("工单已生成，不要再点了!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            mbpn = pn8.Text
            bu8.Text = "已生成"
            orderid = dd8.Text
            addbom_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class