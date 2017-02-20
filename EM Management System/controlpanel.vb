Imports System.Data.SqlClient

Public Class controlpanel
    Private Sub controlpanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim cn As SqlConnection = New SqlConnection(FrmDataSql)
            Dim Sql As String = "SELECT [编号],[型号],[系统序列号],'批准' as pz FROM Order_Table WHERE Panel='Open'"
            Dim cmd As SqlCommand = New SqlCommand(Sql, cn)
            Dim dp As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            cn.Open()
            dp.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)

            cn.Close()
            cn.Dispose()

        Catch

        End Try

    End Sub
    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If e.ColumnIndex = 3 Then

            Dim i As Integer = DataGridView1.CurrentRow.Index


            If DataGridView1.Item(3, i).Value.ToString() = "批准" Then

                Dim cnStr As String = FrmDataSql
                Dim cn As SqlConnection = New SqlConnection(cnStr)
                Dim da As New SqlDataAdapter("select * from order_Table", cn)
                Dim ds As New DataSet()
                da.Fill(ds, "mytable")
                Dim drow As DataRow
                ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("编号")}
                drow = ds.Tables("mytable").Rows.Find(DataGridView1.Item(0, i).Value.ToString())
                Try
                    drow("Panel") = "Close"

                    Dim cmdb As New SqlCommandBuilder(da)
                    da.Update(ds, "mytable")
                    MessageBox.Show("系统已批准！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
                cn.Close()

                DataGridView1.Item(3, i).Value = "已批准"

            End If



        End If

    End Sub
End Class