Imports System.Data.SqlClient
Public Class clickfrm
    Dim bhid As String
    Private Sub click_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ToolStripLabel1.Text = Uservar
        uptab_Click(sender, e)

    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ListView1.Clear()
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index


            bhid = DataGridView1.Item(0, i).Value.ToString()
            Dim lsgdid As String = DataGridView1.Item(3, i).Value.ToString()
            Dim modelid As String = DataGridView1.Item(1, i).Value.ToString()
            Dim pnid As String = DataGridView1.Item(2, i).Value.ToString()



            ListView1.Items.Add("型号：" & modelid, 1)
            ListView1.Items.Add("料号：" & pnid, 2)
            ListView1.Items.Add("临时工单号：" & bhid, 3)
            ListView1.Items.Add("上线时间：" & lsgdid, 0)

        Catch ex As Exception

        End Try







    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sntextbox.Text = "" Then
            MessageBox.Show("系统序列号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf bhid = "" Then
            MessageBox.Show("请选择要保存SN的系统", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf sntextbox.text.Length <> 8 Then
            MessageBox.Show("请输入的SN格式有误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sntextbox.Clear()
        ElseIf Mid(sntextbox.Text, 5, 1) <> "F" Then
            MessageBox.Show("请输入的SN格式有误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Order_table", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
            Dim dv As New DataView(ds.Tables("mytable"), "", "系统序列号", DataViewRowState.CurrentRows)
            Dim rowIndex As Integer = dv.Find(sntextbox.Text)
            drow = ds.Tables("mytable").Rows.Find(bhid)

            If rowIndex = -1 Then
                Try
                    drow("系统序列号") = sntextbox.Text
                    drow("终检完成时间") = Format(Now, "yyyy-MM-dd hh:mm ")
                    drow("终检员") = Uservar
                    drow("工单入库") = "待入库"
                    drow("FF信息") = "Open"
                    Dim cmdb As New SqlCommandBuilder(da)
                    da.Update(ds, "mytable")
                    MessageBox.Show("系统S/N: " & sntextbox.Text & "  已保存到数据库", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    uptab_Click(sender, e)
                    bhid = ""
                    ListView1.Clear()
                    sntextbox.Clear()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            Else
                MessageBox.Show("SN已存在，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sntextbox.Clear()
                cn.Close()
            End If
        End If
    End Sub

    Public Sub uptab_Click(sender As Object, e As EventArgs)
        Dim cn As SqlConnection
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim cnStr As String = FrmDataSql
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select 编号,型号,料号,上线时间 from Order_table WHERE 工单上线='已上线'and 系统序列号='Open'", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "Order_table")
        DataGridView1.DataSource = ds.Tables("Order_table") '表名


        DataGridView1.RowHeadersVisible = False
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 127
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cn.Close()
    End Sub
End Class