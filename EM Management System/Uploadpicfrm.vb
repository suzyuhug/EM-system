
Imports System.Data.SqlClient
Public Class Uploadpicfrm
    Dim FrmFTPPath, FrmFTPName, FrmFTPpw As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
        Label3.Text = 0 : Label4.Text = 0
        Dim filetmp() As String
        Dim pathtmp() As String
        OpenFileDialog1.Filter = "图像文件(*.JPG;)|*.JPG|所有文件(*.*)|**"
        OpenFileDialog1.Multiselect = True

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
            If OpenFileDialog1.FileName <> "" Then '如果有选中文件
                ReDim filetmp(OpenFileDialog1.SafeFileNames.Length)
                ' ReDim pathtmp(OpenFileDialog1.SafeFileNames.Length)
                filetmp = OpenFileDialog1.SafeFileNames '取文件名
                pathtmp = OpenFileDialog1.FileNames
                For i As Integer = 0 To filetmp.Length - 1
                    'ListBox1.Items.Add(filetmp(i)) '添加文件名
                    DataGridView1.Rows.Insert(0)
                    DataGridView1.Rows(0).Cells(0).Value = filetmp(i)
                    DataGridView1.Rows(0).Cells(1).Value = "准备上传"
                    DataGridView1.Rows(0).Cells(2).Value = pathtmp(i)
                Next
            End If
        End If
        Button1.Visible = True
        Button2.Visible = False
        Label6.Text = DataGridView1.RowCount
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim picpath As String
        Dim i As Integer = DataGridView1.CurrentRow.Index
        picpath = DataGridView1.Item(2, i).Value.ToString()


        Try
            PictureBox1.Image = Image.FromFile(picpath)
        Catch ex As Exception
            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim updatapath As String
        Dim fliename As String
        Dim picpath As String
        Dim folderid As String = "image"
        If RadioButton1.Checked = True Then
            folderid = "image"
            PictureBox1.Width = 276
            ProgressBar1.Width = 276
        ElseIf RadioButton2.Checked = True Then
            folderid = "userphoto"
            PictureBox1.Width = 150
            ProgressBar1.Width = 150

        End If



        If DataGridView1.RowCount <= 0 Then Exit Sub
            ProgressBar2.Maximum = DataGridView1.RowCount - 1
            For i As Integer = 0 To DataGridView1.RowCount - 1
                fliename = DataGridView1.Item(0, i).Value.ToString()
                updatapath = DataGridView1.Item(2, i).Value.ToString()
                picpath = DataGridView1.Item(2, i).Value.ToString()
                PictureBox1.Image = Image.FromFile(picpath)
                ProgressBar2.Value = i
                For s As Integer = 30 To 100
                    ProgressBar1.Value = s
                Next
                Try


                My.Computer.Network.UploadFile(updatapath, FrmFTPPath & "/" & folderid & "/" & fliename, FrmFTPName, FrmFTPpw, False, 500)
                Application.DoEvents()
                    'DataGridView1.Rows(i).Selected = True
                    'If i > 0 Then DataGridView1.Rows(i - 1).Selected = False
                    DataGridView1.FirstDisplayedScrollingRowIndex = i
                    DataGridView1.Rows(i).Cells(1).Value = "上传成功"
                    Label3.Text = Label3.Text + 1
                Catch ex As Exception
                    DataGridView1.Rows(i).Cells(1).Value = "上传失败"
                    Label4.Text = Label4.Text + 1
                End Try

            Next
            Button1.Visible = False
            Button2.Visible = True


    End Sub

    Private Sub Uploadpicfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(2).Width = 230



        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
        Dim rowIndex As Integer = dv.Find("FTPPath")
        If rowIndex = -1 Then


            Exit Sub
        Else
            FrmFTPPath = Trim(dv(rowIndex)("PortPath").ToString)

            FrmFTPName = Trim(dv(rowIndex)("PortUser").ToString)
            FrmFTPpw = Trim(dv(rowIndex)("PortPassWord").ToString)

        End If
        cn.Close()

    End Sub


End Class