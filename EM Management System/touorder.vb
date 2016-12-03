Imports System.Data.SqlClient

Public Class touorder
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim i As Integer = 0
        ListView1.LargeImageList = Me.ImageList1
        'ListView1.View = View.LargeIcon
        ' ListView1.Columns.Add("列 1", 50, HorizontalAlignment.Center)
        Dim grp As New ListViewGroup


        grp.Header = "女"
        ListView1.Groups.Add(grp)
        ListView1.ShowGroups = True
        For i = 0 To 3
            Dim mItem As New ListViewItem
            mItem.ImageIndex = i
            mItem.Text = "test" & i
            grp.Items.Add(mItem)
            ListView1.Items.Add(mItem)

        Next

    End Sub
    Private Sub ListView1_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.ItemActivate
        Try
            Dim TmpLitem As ListViewItem
            Dim TmpStr As String = ""
            For Each TmpLitem In Me.ListView1.SelectedItems
                TmpStr += TmpLitem.SubItems.Item(0).Text.Trim
            Next
            MessageBox.Show(Mid(TmpStr, 1, 14))
            Dim cn = New SqlConnection(FrmDataSql)
            Dim cmd As New SqlCommand("sp_bomlistview", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim myParameter As New SqlParameter("@pn", SqlDbType.VarChar)
            myParameter.Value = Mid(TmpStr, 1, 14)
            cmd.Parameters.Add(myParameter)
            Try
                cn.Open()
                cmd.ExecuteNonQuery()

                Dim dp = New SqlDataAdapter(cmd)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)
                DataGridView1.DataSource = ds.Tables(0)
                cmd.Dispose()
                cn.Close()
                For i = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows(i).Cells(0).Value = "true"



                Next

            Catch ex As Exception

            End Try

















        Catch ex As Exception

        End Try
    End Sub
    Private Sub touorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cn = New SqlConnection(FrmDataSql)
        Dim cmd As New SqlCommand("sp_inorder_liseview", cn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim dp = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        dp.Fill(ds, 0)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim grp As New ListViewGroup
            Dim bh As String = ds.Tables(0).Rows(i)("编号").ToString
            grp.Header = bh
            ListView1.Groups.Add(grp)
            ListView1.ShowGroups = True
            For s = 0 To ds.Tables(1).Rows.Count - 1
                If bh = ds.Tables(1).Rows(s)("编号").ToString Then
                    Dim mItem As New ListViewItem
                    mItem.ImageIndex = 2
                    mItem.Text = ds.Tables(1).Rows(s)("料号").ToString & vbCr & ds.Tables(1).Rows(s)("工单号").ToString
                    grp.Items.Add(mItem)
                    ListView1.Items.Add(mItem)
                End If
            Next
        Next



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim i As Integer = 0
        Dim str As String = ""
        For i = 0 To ListView1.SelectedItems.Count - 1
            str = str & "选中项索引=" & ListView1.SelectedItems.Item(i).Index.ToString & "；"
            str = str & "在控件中的索引=" & ListView1.SelectedIndices.Item(i).ToString & vbCr
        Next
        MessageBox.Show(str)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.Columns.Clear()
        ListView1.Columns.Add("列 1", 50, HorizontalAlignment.Left)
        ListView1.Columns.Add("列 2", 50, HorizontalAlignment.Left)
        ListView1.Columns.Add("列 3", 50, HorizontalAlignment.Left)
        ListView1.Columns.Add("列 4", 50, HorizontalAlignment.Center)
        ListView1.Refresh()
    End Sub


End Class