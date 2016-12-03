Imports System.Data.SqlClient
Public Class bomeditfrm
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sxbl As String
    Dim ImagePath As String
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from bom_list", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False
        'DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(0).Width = 50
        'DataGridView1.Columns(1).Width = 80
        'DataGridView1.Columns(2).Width = 160
        'DataGridView1.Columns(3).Width = 370
        ' DataGridView1.Columns(4).Width = 63

        cn.Close()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer = DataGridView1.CurrentRow.Index
        ComboBox2.Text = DataGridView1.Item(1, i).Value.ToString()
        ComboBox3.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(3, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(4, i).Value.ToString()
        TextBox4.Text = DataGridView1.Item(0, i).Value.ToString()

        Button2.Visible = False
        Button3.Visible = True
        Button4.Visible = True

        Dim picname As String = TextBox2.Text.Substring(4)

        Try
            PictureBox2.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

        Catch ex As Exception
            PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End Try

    End Sub

    Private Sub bomeditfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
        imageup_Click(sender, e)
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT 型号 FROM Order_list", cn) '表名
        Dim da1 As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT 料号 FROM Order_list", cn) '表名
        Dim ds As DataSet = New DataSet()
        Dim ds1 As DataSet = New DataSet()
        da.Fill(ds, "mytable")
        da1.Fill(ds1, "mytable")
        ComboBox2.DataSource = ds.Tables("mytable")
        ComboBox2.DisplayMember = "型号"
        ComboBox2.Text = ""
        ComboBox3.DataSource = ds1.Tables("mytable")
        ComboBox3.DisplayMember = "料号"
        ComboBox3.Text = ""
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("请选择一条要更新的数据", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ComboBox2.Text = "" Then
            MessageBox.Show("请选择型号，不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ComboBox3.Text = "" Then

            MessageBox.Show("请选择系统料号，这个不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("请输入工单里的料号，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("请输入物料的默认数量", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text <> Int(TextBox3.Text) Then
            MessageBox.Show("请输入正确的数量，只能是整数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from bom_list", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
            drow = ds.Tables("mytable").Rows.Find(TextBox4.Text)
            Try
                drow("型号") = ComboBox2.Text

                drow("系统料号") = ComboBox3.Text
                drow("工单料号") = TextBox2.Text
                drow("数量") = TextBox3.Text

                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                ComboBox2.Text = ""
                ComboBox3.Text = ""
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()


                Button2.Visible = True
                Button3.Visible = False
                Button4.Visible = False

                upda_Click(sender, e)
                MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox2.Text = "" Then
            MessageBox.Show("请选择型号，不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ComboBox3.Text = "" Then

            MessageBox.Show("请选择系统料号，这个不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("请输入工单里的料号，不可为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("请输入物料的默认数量", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf TextBox3.Text <> Int(TextBox3.Text) Then
            MessageBox.Show("请输入正确的数量，只能是整数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from bom_list", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            drow = ds.Tables("mytable").NewRow
            Try
                drow("型号") = ComboBox2.Text

                drow("系统料号") = ComboBox3.Text
                drow("工单料号") = TextBox2.Text
                drow("数量") = TextBox3.Text
                ds.Tables("mytable").Rows.Add(drow)
                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")

                MessageBox.Show("数据保存成功，请插入下一条", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox3.Text = ""
                ComboBox2.Text = ""
                Button2.Visible = True
                Button3.Visible = False
                Button4.Visible = False
                upda_Click(sender, e)
            Catch ex As Exception
                MessageBox.Show("数据保存出错了，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        cn.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MessageBox.Show("你确定要删除数据，删除后将不可恢复，点击（确定）删除！", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then


            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)

            Dim da As SqlCommand = New SqlCommand("delete from bom_list WHERE 编号='" & TextBox4.Text & "'", cn)
            cn.Open()
            da.ExecuteNonQuery()
            MessageBox.Show("数据删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            Button2.Visible = True
            Button3.Visible = False
            Button4.Visible = False
            upda_Click(sender, e)
            cn.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        Button2.Visible = True
        Button3.Visible = False
        Button4.Visible = False
        upda_Click(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            cn = New SqlConnection(cnStr)

            Dim Sql As String = "select * from bom_list where " & ComboBox1.Text & " like " & "'%" & TextBox1.Text & "%'"
            da = New SqlDataAdapter(Sql, cn) '表名
            ds = New DataSet()
            da.Fill(ds, "mytable")
            DataGridView1.DataSource = ds.Tables("mytable") '表名
            cn.Close()
        End If
    End Sub
End Class