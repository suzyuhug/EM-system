Imports System.Data.SqlClient
Public Class inorder
    Dim orderid As String
    Dim moldeid As String
    Dim pnid As String
    Dim adddate As String
    Dim yjdate As String
    Dim ownerid As String
    Dim bhid As String
    Dim gdsx As String
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)

    End Sub

    Private Sub inorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripLabel1.Text = Uservar
        UPcom_Click(sender, e)
        ComboBox1.Text = ""
        ListView1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("工单都收完了，没有工单可以收了", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else


            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Order_view", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工单号")}
            drow = ds.Tables("mytable").Rows.Find(orderid)
            Try
                drow("工单上线") = "已上线"

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")
                MessageBox.Show("信息保存成功，请收下一份工单", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
            testno_Click(sender, e)
            UPcom_Click(sender, e)
            ComboBox1.Text = ""
            ListView1.Clear()
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ListView1.Clear()
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Order_view", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "工单号", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find(ComboBox1.Text)
        If rowIndex = -1 Then


            Exit Sub
        Else
            orderid = Trim(dv(rowIndex)("工单号").ToString)
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
            yjdate = Trim(dv(rowIndex)("预计上线时间").ToString)
            ownerid = Trim(dv(rowIndex)("投工单管理员").ToString)
            cn.Close()

        End If

        ListView1.Items.Add("工单号：" & orderid, 0)
        ListView1.Items.Add("型号：" & moldeid, 2)
        ListView1.Items.Add("料号：" & pnid, 1)
        ListView1.Items.Add("投工单时间：" & adddate, 5)
        ListView1.Items.Add("投工单用户：" & ownerid, 3)
        ListView1.Items.Add("预计上线时间：" & yjdate, 4)

        cn.Close()
    End Sub
    Public Sub UPcom_Click(sender As Object, e As EventArgs)
        ComboBox1.ResetText()
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT 工单号 FROM Order_view WHERE 工单上线='未上线'", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox1.DataSource = ds.Tables("mytable")
        ComboBox1.DisplayMember = "工单号"
        'ComboBox1.ValueMember = "列2"
        cn.Close()
    End Sub

    Public Sub testno_Click(sender As Object, e As EventArgs) '测试是否有没收料的
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_view WHERE 编号 ='" & bhid & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Dim strDisplay As String = ""
        Dim i As Integer = 0
        Dim s As Integer = 0

        While dr.Read()
            i = i + 1
            s = s + 1
            gdsx = Trim(dr("工单上线").ToString + Space(5))
            If gdsx = "未上线" Or gdsx = "未完成" Then
                s = s - 1
            End If


        End While

        cn.Close()
        If i = s Then
            uptab_Click(sender, e)
        Else
            uptab1_Click(sender, e)
        End If

    End Sub
    Public Sub uptab_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow
        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(bhid)
        Try
            drow("工单上线") = "已上线"
            drow("上线时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("工单上线管理员") = Uservar

            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")
            MessageBox.Show("这套系统都收完了", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()

    End Sub
    Public Sub uptab1_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from Order_table", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow
        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(bhid)
        Try
            drow("工单上线") = "未完成"
            drow("上线时间") = Format(Now, "yyyy-MM-dd hh:mm ")
            drow("工单上线管理员") = Uservar

            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        PictureBox1_Click(sender, e)
    End Sub



End Class