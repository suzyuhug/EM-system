Imports System.Data.SqlClient
Imports System.IO

Imports System.Threading
Public Class LabelconfigFrm
    Dim IDCodeVar(12) As TextBox
    Dim IDContent(12) As TextBox
    Dim MyLabel As Object
    Dim MyDoc As Object
    Dim mythread As Thread
    Dim FrmtemplateID As Integer
    Dim FrmVarID As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LabelModeladd.Show()

    End Sub

    Private Sub LabelconfigFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IDCodeVar(1) = FrmCodeVar1 : IDCodeVar(2) = FrmCodeVar2 : IDCodeVar(3) = FrmCodeVar3 : IDCodeVar(4) = FrmCodeVar4 : IDCodeVar(5) = FrmCodeVar5 : IDCodeVar(6) = FrmCodeVar6
        IDCodeVar(7) = FrmCodeVar7 : IDCodeVar(8) = FrmCodeVar8 : IDCodeVar(9) = FrmCodeVar9 : IDCodeVar(10) = FrmCodeVar10 : IDCodeVar(11) = FrmCodeVar11 : IDCodeVar(12) = FrmCodeVar12
        IDContent(1) = FrmContent1 : IDContent(2) = FrmContent2 : IDContent(3) = FrmContent3 : IDContent(4) = FrmContent4 : IDContent(5) = FrmContent5 : IDContent(6) = FrmContent6
        IDContent(7) = FrmContent7 : IDContent(8) = FrmContent8 : IDContent(9) = FrmContent9 : IDContent(10) = FrmContent10 : IDContent(11) = FrmContent11 : IDContent(12) = FrmContent12
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT TabUnit FROM LabelFromConfig", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox1.DataSource = ds.Tables("mytable")
        ComboBox1.DisplayMember = "TabUnit"
        ComboBox1.Text = ""
        Dim cn1 As SqlConnection = New SqlConnection(cnStr)
        Dim da1 As SqlDataAdapter = New SqlDataAdapter("SELECT LabelName FROM LabelTemplate", cn1) '表名
        Dim ds1 As DataSet = New DataSet()
        da1.Fill(ds1, "mytable")

        ComboBox2.DataSource = ds1.Tables("mytable")
        ComboBox2.DisplayMember = "LabelName"
        ' ComboBox2.Text = ""


    End Sub

    Private Sub ComboBox2_SelectedIndex(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged




        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM LabelTemplate WHERE LabelName ='" & ComboBox2.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Dim r As Integer
        While dr.Read()

            FrmLabelWidth.Text = "标签宽度：" & Trim(dr("LabelWidth").ToString + Space(5))
            FrmLabelHight.Text = "标签高度：" & Trim(dr("LabelHight").ToString + Space(5))
            FrmlabelDes.Text = "标签描述：" & Trim(dr("Description").ToString + Space(5))
            r = Trim(dr("ID").ToString + Space(5))
            FrmtemplateID = r



            Dim cn2 As SqlConnection = New SqlConnection(cnStr)
            Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM LabelTemplate WHERE ID ='" & r & "'", cn2) '表名
            Dim ds2 As DataSet = New DataSet()


            da2.Fill(ds2)
            cn2.Close()

            If ds2.Tables(0).Rows.Count > 0 Then


                Dim imgData() As Byte

                Dim FrmPath As String = Application.StartupPath + "\\LabelTemp\LoadPic.jpeg"
                imgData = ds2.Tables(0).Rows(0).Item("Labelpicture")
                Dim fs As FileStream
                fs = File.Create(FrmPath, imgData.Length - 1)
                fs.Write(imgData, 0, imgData.Length - 1)



                PictureBox1.Image = Image.FromStream(fs)
                fs.Close()









            Else
                MessageBox.Show("错误001，标签模板不存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If




            Dim cn1 As SqlConnection = New SqlConnection(cnStr)
            cn1.Open()
            Dim a1 As String = "SELECT * FROM CodeVar WHERE TemplateID ='" & r & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(a1, cn1) '表名
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            For s As Integer = 1 To 12
                IDCodeVar(s).Visible = False
                IDContent(s).Visible = False

            Next s

            Dim i As Integer = 0
            While dr1.Read()
                i = i + 1
                IDCodeVar(i).Visible = True : IDContent(i).Visible = True

                IDCodeVar(i).Text = Trim(dr1("CodeVar").ToString + Space(5))

            End While
            FrmVarID = i
            cn1.Close()




        End While

        cn.Close()
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT TabUnit FROM LabelFromConfig", cn) '表名
        Dim ds As DataSet = New DataSet()


        da.Fill(ds)
        cn.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            '将文件保存到硬盘文件c:\2.jpg   
            Dim imgData() As Byte
            imgData = ds.Tables(0).Rows(0).Item("LabelTemplate")
            Dim fs As FileStream
            fs = File.Create("c:\Temp.Lab", imgData.Length - 1)
            fs.Write(imgData, 0, imgData.Length - 1)
            fs.Close()
        End If
    End Sub
    Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("选择一个页面模块，可以手懂输入", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox1.Text = "" Then
            MessageBox.Show("输入要显示的名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ComboBox2.Text = "" Then
            MessageBox.Show("请选择一个标签模板！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else



            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from LabelFromConfig", cn) '搬运工拉好水
            Dim ds As New DataSet()  '本地内存准备好容器来装水
            da.Fill(ds, "mytable")   '装水
            Dim drow As DataRow          '定义行变量
            drow = ds.Tables("mytable").NewRow   '行变量是新的一个行
            'Try
            drow("TabUnit") = Trim(ComboBox1.Text)
            drow("TabListName") = TextBox1.Text
            drow("LabelTemplateID") = FrmtemplateID


            ds.Tables("mytable").Rows.Add(drow)  '新行内容加入到表中
            Dim cmdb As New SqlCommandBuilder(da)  '和数据库打个电话，本地内存有水要运过去

            da.Update(ds, "mytable")


            cn.Open()
            Dim db As New SqlCommand("SELECT MAX(ID) AS maxid FROM LabelFromConfig", cn)
            Dim S As Int32 = Convert.ToInt32(db.ExecuteScalar())


            For i = 1 To FrmVarID


                Dim cn1 As SqlConnection = New SqlConnection(cnStr)
                Dim da1 As New SqlDataAdapter("select * from LabelVar", cn1) '搬运工拉好水
                Dim ds1 As New DataSet()  '本地内存准备好容器来装水
                da1.Fill(ds1, "mytable")   '装水
                Dim drow1 As DataRow          '定义行变量
                drow1 = ds1.Tables("mytable").NewRow   '行变量是新的一个行
                'Try
                drow1("LabelFromConfigID") = S
                drow1("LocalVar") = IDCodeVar(i).Text
                drow1("CodeVar") = IDContent(i).Text


                ds1.Tables("mytable").Rows.Add(drow1)  '新行内容加入到表中
                Dim cmdb1 As New SqlCommandBuilder(da1)  '和数据库打个电话，本地内存有水要运过去

                da1.Update(ds1, "mytable")
                cn1.Close()


            Next



            cn.Close()

            MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If




    End Sub
End Class
