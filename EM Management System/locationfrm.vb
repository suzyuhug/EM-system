Imports System.Data.SqlClient
Public Class locationfrm
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cnStr As String = FrmDataSql
    Dim ImagePath As String

    Private Sub locationfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripLabel1.Text = Uservar
        cn = New SqlConnection(cnStr)
        da = New SqlDataAdapter("select * from Location_Query", cn) '表名
        ds = New DataSet()
        da.Fill(ds, "Location_Query")
        DataGridView1.DataSource = ds.Tables("Location_Query") '表名


        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(2).Width = 107
        cn.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For s = 1 To 100
            ToolStripProgressBar1.Value = s
        Next

        If TextBox1.Text = "" Then
            MessageBox.Show("内容不能为空，请输入！")
        TextBox1.Focus()
        Else


            If ComboBox1.Text = "料号" Then
                cn = New SqlConnection(cnStr)
                Dim sql As String = "select * from Location_Query where [Part Number] like " & "'%" & TextBox1.Text & "%'"
                da = New SqlDataAdapter(sql, cn) '表名
                ds = New DataSet()
                da.Fill(ds, "Location_Query")
                DataGridView1.DataSource = ds.Tables("Location_Query") '表名
                If DataGridView1.RowCount > 0 Then
                    ToolStripLabel3.Text = DataGridView1.Item(0, 0).Value.ToString()
                    ToolStripLabel5.Text = DataGridView1.Item(1, 0).Value.ToString()
                    ToolStripLabel7.Text = DataGridView1.Item(2, 0).Value.ToString()
                    Dim picname As String = DataGridView1.Item(4, 0).Value.ToString()
                    TextBox1.Clear()
                    TextBox1.Focus()
                    Try
                        PictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

                    Catch ex As Exception
                        PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                    End Try
                Else
                    MessageBox.Show("料号不存在，请确认后再查询！")
                    TextBox1.Clear()
                    TextBox1.Focus()

                End If

            ElseIf ComboBox1.Text = "库位" Then
                cn = New SqlConnection(cnStr)
                Dim sql As String = "select * from Location_Query where Location like " & "'%" & TextBox1.Text & "%'"
                da = New SqlDataAdapter(sql, cn) '表名
                ds = New DataSet()
                da.Fill(ds, "Location_Query")
                DataGridView1.DataSource = ds.Tables("Location_Query") '表名
                If DataGridView1.RowCount > 0 Then
                    ToolStripLabel3.Text = DataGridView1.Item(0, 0).Value.ToString()
                    ToolStripLabel5.Text = DataGridView1.Item(1, 0).Value.ToString()
                    ToolStripLabel7.Text = DataGridView1.Item(2, 0).Value.ToString()
                    Dim picname As String = DataGridView1.Item(4, 0).Value.ToString()
                    TextBox1.Clear()
                    TextBox1.Focus()
                    Try
                        PictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

                    Catch ex As Exception
                        PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                    End Try
                Else
                    MessageBox.Show("库位不存在，请确认后再查询！")
                    TextBox1.Clear()
                    TextBox1.Focus()

                End If
                cn.Close()
            End If
            cn.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        For s = 1 To 100
            ToolStripProgressBar1.Value = s
        Next
        Dim i As Integer = DataGridView1.CurrentRow.Index
        ToolStripLabel3.Text = DataGridView1.Item(0, i).Value.ToString()
        ToolStripLabel5.Text = DataGridView1.Item(1, i).Value.ToString()
        ToolStripLabel7.Text = DataGridView1.Item(2, i).Value.ToString()
        Dim picname As String = DataGridView1.Item(4, i).Value.ToString()

        Try
            PictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(ImagePath & "/image/" & picname & ".jpg").GetResponse().GetResponseStream())

        Catch ex As Exception
            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End Try

    End Sub



    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)

        End If
    End Sub


End Class