Imports System.Data.SqlClient
Public Class orderedit
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim sql As String
    Dim listid As Integer
    Private Sub orderedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upda_Click(sender, e)
    End Sub
    Private Sub orderedit_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DataGridView1.Width = Me.Width - 40
        DataGridView1.Height = Me.Height - 125
        Button1.Left = Me.Width - 200
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height) / 2



    End Sub

    Private Sub 更改ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更改ToolStripMenuItem.Click
        Panel1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Visible = False
    End Sub
    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContextMenuStripNeeded

        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item("编号", i).Value.ToString()
        listid = i
        For s As Integer = 0 To DataGridView1.ColumnCount - 1
            ComboBox2.Items.Add(DataGridView1.Columns(s).Name)
        Next




    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox3.Clear()
        TextBox3.Text = DataGridView1.Item(ComboBox2.Text, listid).Value.ToString()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As New SqlDataAdapter("select * from order_table", cn)
        Dim ds As New DataSet()
        da.Fill(ds, "mytable")
        Dim drow As DataRow
        ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
        drow = ds.Tables("mytable").Rows.Find(TextBox2.Text)
        Try



            drow(ComboBox2.Text) = TextBox3.Text




            Dim cmdb As New SqlCommandBuilder(da)
            da.Update(ds, "mytable")





            MessageBox.Show("数据更新成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            upda_Click(sender, e)
            Panel1.Visible = False

            TextBox2.Clear()
            ComboBox2.Text = ""
            TextBox3.Clear()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        cn.Close()

    End Sub
    Public Sub upda_Click(sender As Object, e As EventArgs)
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from order_table", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名


        DataGridView1.RowHeadersVisible = False

        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择筛选条件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            cn = New SqlConnection(cnStr)

            sql = "select * from order_table where " & ComboBox1.Text & " like " & "'%" & TextBox1.Text & "%'"
            da = New SqlDataAdapter(sql, cn) '表名
            ds = New DataSet()
            da.Fill(ds, "mytable")
            DataGridView1.DataSource = ds.Tables("mytable") '表名
            cn.Close()
        End If

    End Sub


End Class