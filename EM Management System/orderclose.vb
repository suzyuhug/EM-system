
Imports System.Data.SqlClient
Public Class orderclose
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql

    Dim sql, sqlpath, sqltable, sqluser, sqlpw As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        sql = "Data Source=" & sqlpath & ";Initial Catalog=" & sqltable & ";Integrated Security=False;User ID=" & sqluser & ";Password=" & sqlpw & ";"


        If DataGridView1.RowCount = 0 Then
            MessageBox.Show("没有入库好的工单！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else

            Dim zt, orderid As String
            Dim s As Integer = DataGridView1.RowCount - 1
            ProgressBar1.Maximum = s

            For i As Integer = 0 To s
                ProgressBar1.Value = i
                orderid = DataGridView1.Item(3, i).Value
                If DataGridView1.Item(7, i).Value IsNot DBNull.Value Then zt = DataGridView1.Item(7, i).Value Else zt = ""




                Dim cnStr As String = sql
                    Dim cn As SqlConnection = New SqlConnection(cnStr)
                    cn.Open()
                    Dim a As String = "SELECT * FROM SUZ_ProdcutionOrder_Bu7 WHERE ProductionOrderNumber ='" & orderid & "'"
                    Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
                    Dim dr As SqlDataReader
                    dr = cmd.ExecuteReader()
                    If dr.HasRows = 0 Then
                        MessageBox.Show("工单号错误，可能工单不存在！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Else


                        Dim idid As String
                        Dim cnStr1 As String = FrmDataSql

                        While dr.Read()

                            idid = Trim(dr("Status").ToString + Space(5))



                            Dim cn1 As SqlConnection = New SqlConnection(cnStr1)
                            cn1.Open()
                            Dim da As New SqlDataAdapter("select * from Order_view", cn1)
                            Dim ds As New DataSet()
                            da.Fill(ds, "mytable")
                            Dim drow As DataRow


                            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("工单号")}
                            drow = ds.Tables("mytable").Rows.Find(orderid)
                            Try

                                drow("状态") = idid


                                Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去
                                da.Update(ds, "mytable")               '上面电话里已经说好了，现在把水运到数据库去 

                            Catch ex As Exception
                                MessageBox.Show(ex.ToString)
                            End Try


                            cn1.Close()


                        End While

                        cn.Close()

                    End If




            Next

            MessageBox.Show("数据更新完成！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If




    End Sub

    Private Sub orderclose_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        orderlist_Click(sender, e)
        portup_Click(sender, e)

    End Sub

    Public Sub orderlist_Click(sender As Object, e As EventArgs)

        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from order_view WHERE 状态 <>'Completed'", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "mytable")
        DataGridView1.DataSource = ds.Tables("mytable") '表名

        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(0).Width = 160
        DataGridView1.Columns(1).Width = 120
        DataGridView1.Columns(4).Width = 60

        cn.Close()

    End Sub

    Public Sub portup_Click(sender As Object, e As EventArgs)

        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("OrderStatus")
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


End Class