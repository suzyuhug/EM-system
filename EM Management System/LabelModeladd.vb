
Imports System.Threading
Imports System.Data.SqlClient
Imports System.IO



Public Class LabelModeladd
    Dim MyLabel As Object
    Dim MyDoc As Object
    Dim mythread As Thread
    Dim FrmVar(12) As TextBox
    Dim FrmVarID As Int32 = 1
    Private Delegate Sub VoidShow(ByRef i As String) '定义要委托的类型  

    Dim OpenLabelPath As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        OpenFileDialog1.Filter = "CodeSoft文件(*.Lab;)|*.Lab|所有文件(*.*)|**"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = "CodeSoft"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            If OpenFileDialog1.FileName <> "" Then
                OpenLabelPath = OpenFileDialog1.FileName
                TextCodePath.Text = OpenLabelPath

                mythread = New Thread(AddressOf ShowNumber)
                mythread.Name = "myShowNumber"
                mythread.Start(OpenLabelPath)

            End If
        End If
    End Sub
    Private Sub ShowNumber(ByVal Path As String)
        MyLabel = CreateObject("Lppx2.Application")
        MyDoc = MyLabel.Documents.Open(Path)
        Me.Invoke(New VoidShow(AddressOf TureShowNumber), "")
        mythread.Abort()
    End Sub
    Private Sub TureShowNumber()

        MyDoc.CopyToClipboard()
        PictureBox1.Image = Clipboard.GetImage


        MyLabel.Quit()
        MyLabel = Nothing
        MyDoc = Nothing

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim LabelPath As String = "g:\1.lab"

        Dim MyLabel As Object = CreateObject("Lppx2.Application")
        Dim MyDoc As Object = MyLabel.Documents.Open(LabelPath)



        MyDoc.CopyToClipboard()

        PictureBox1.Image = Clipboard.GetImage
        MyLabel.ActiveDocument.variables("变量1").Value = "test"
        MyLabel.ActiveDocument.printlabel(1)
        MyLabel.ActiveDocument.formfeed
        MyLabel.ActiveDocument.Close(True)
        MyLabel.Quit()
        MyLabel = Nothing


    End Sub

    Private Sub LabelModeladd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmVar(1) = TextVar1 : FrmVar(2) = TextVar2 : FrmVar(3) = TextVar3 : FrmVar(4) = TextVar4
        FrmVar(5) = TextVar5 : FrmVar(6) = TextVar6 : FrmVar(7) = TextVar7 : FrmVar(8) = TextVar8
        FrmVar(9) = TextVar9 : FrmVar(10) = TextVar10 : FrmVar(11) = TextVar11 : FrmVar(12) = TextVar12
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButVarAdd.Click

        FrmVarID = FrmVarID + 1
        If FrmVarID < 13 Then
            FrmVar(FrmVarID).Visible = True
            ButVarAdd.Top = FrmVar(FrmVarID).Top - 4
        Else
            MessageBox.Show("最多只能添加12个变量", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If TextCodePath.Text = "" Then
            MessageBox.Show("请选择一个标签模板", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("请输入模板的名称，便于查找", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("请输入标签的尺寸", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else


            Dim fs = New FileStream(TextCodePath.Text, IO.FileMode.Open, IO.FileAccess.Read)
            Dim imgData(fs.Length - 1) As Byte
            fs.Read(imgData, 0, fs.Length - 1)
            fs.Close()



            Dim FrmPath As String = Application.StartupPath + "\\LabelTemp\LabelPic.jpeg"
            Me.PictureBox1.Image.Save(FrmPath, Imaging.ImageFormat.Jpeg)

            Dim fs1 = New FileStream(FrmPath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim picData(fs1.Length - 1) As Byte
            fs1.Read(picData, 0, fs1.Length - 1)
            fs1.Close()


            Dim strText As String
            strText = BitConverter.ToString(picData)
            Me.TextBox1.Text = strText



            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from LabelTemplate", cn) '搬运工拉好水
            Dim ds As New DataSet()  '本地内存准备好容器来装水
            da.Fill(ds, "mytable")   '装水
            Dim drow As DataRow          '定义行变量
            drow = ds.Tables("mytable").NewRow   '行变量是新的一个行
            'Try
            drow("LabelTemplate") = imgData
            drow("LabelPicture") = picData
            drow("LabelName") = Trim(TextBox2.Text)
            drow("LabelWidth") = Trim(TextBox3.Text)
            drow("LabelHight") = Trim(TextBox4.Text)
            drow("Description") = Trim(TextBox5.Text)

            ds.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
            Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去

            da.Update(ds, "mytable")


            cn.Open()
            Dim db As New SqlCommand("SELECT MAX(ID) AS maxid FROM LabelTemplate", cn)
            Dim S As Int32 = Convert.ToInt32(db.ExecuteScalar())
            TextBox2.Text = S

            For g As Integer = 1 To FrmVarID
                If FrmVar(g).Text <> "" Then
                    Dim cn1 As SqlConnection = New SqlConnection(cnStr)
                    Dim da1 As New SqlDataAdapter("select * from CodeVar", cn1) '搬运工拉好水
                    Dim ds1 As New DataSet()  '本地内存准备好容器来装水
                    da1.Fill(ds1, "mytable")   '装水
                    Dim drow1 As DataRow          '定义行变量
                    drow1 = ds1.Tables("mytable").NewRow   '行变量是新的一个行
                    'Try
                    drow1("TemplateID") = S
                    drow1("CodeVar") = FrmVar(g).Text


                    ds1.Tables("mytable").Rows.Add(drow1)  '新行内容加入到表中
                    Dim cmdb1 As New SqlCommandBuilder(da1)  '和数据库打个电话，本地内存有水要运过去

                    da1.Update(ds1, "mytable")


                    cn1.Close()

                End If

            Next

            cn.Close()
                MessageBox.Show("标签模板已上传成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ' Catch ex As Exception
            ' MessageBox.Show("工单号已存在， 请查证后再试", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Exit Sub
            ' End Try
        End If

    End Sub
End Class