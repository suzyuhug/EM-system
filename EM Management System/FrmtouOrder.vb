Imports System.Data.SqlClient
Public Class FrmtouOrder
    Dim ListLabelNum As Int16
    Dim SQL, SQLPath, SQLTable, SQLUser, SQLPW As String
    Dim FrmPicList As Int16
    Dim ImagePath As String
    Private Sub FrmtouOrder_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TabControl1.Height = Me.Height - 100
        TabControl2.Height = TabControl1.Height - 200
        TabControl3.Top = TabControl2.Top + TabControl2.Height + 5
        TabControl2.Width = Me.Width - TabControl1.Width - 50
        TabControl3.Width = TabControl2.Width

    End Sub
    Private Sub FrmtouOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UP_Click(sender, e)
        imageup_Click(sender, e)
        Uservarlook.Text = Uservar
        Try

            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Interface", cn) '表名
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "mytable")

            Dim dv As New DataView(ds.Tables("mytable"), "", "PortName", DataViewRowState.CurrentRows) '指定默认查找列为姓名
            Dim rowIndex As Integer = dv.Find("TOV")
            If rowIndex = -1 Then


                Exit Sub
            Else
                sqlpath = Trim(dv(rowIndex)("PortPath").ToString)
                sqltable = Trim(dv(rowIndex)("TableName").ToString)
                sqluser = Trim(dv(rowIndex)("PortUser").ToString)
                sqlpw = Trim(dv(rowIndex)("PortPassWord").ToString)

            End If
            cn.Close()

            Sql = "Data Source=" & sqlpath & ";Initial Catalog=" & sqltable & ";Integrated Security=False;User ID=" & sqluser & ";Password=" & sqlpw & ";"



        Catch ex As Exception
            MessageBox.Show("BOM接口连接失败，请联系管理员！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


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

    Public Sub UP_Click(sender As Object, e As EventArgs)
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Try
            cn.Open()

            Dim a As String = "select 编号,型号,料号,登记时间,登记管理员 from Order_table WHERE 工单登记='Open'"
            Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim i As Int16 = -1
            While dr.Read()
                i = i + 1

                Dim Orderlabel As New TouOrderControl
                Orderlabel.IDValue = Trim(dr("编号").ToString + Space(5))
                Orderlabel.ModelValue = Trim(dr("型号").ToString + Space(5))
                Orderlabel.PNValue = Trim(dr("料号").ToString + Space(5))
                Orderlabel.UserValue = "用户：" & Trim(dr("登记管理员").ToString + Space(5))
                Orderlabel.DateValue = "日期：" & Trim(dr("登记时间").ToString + Space(5))



                Orderlabel.Top = 200 * i + 5
                Orderlabel.Left = 3
                Me.TabPage1.Controls.Add(Orderlabel)
                AddHandler Orderlabel.Click, AddressOf Orderlabelclick




            End While
            cn.Close()

        Catch ex As Exception
            MessageBox.Show("出错了，可能桌面没有Order文件夹！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Orderlabelclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For s = 0 To ListLabelNum

            Me.TabPage3.Controls.RemoveByKey(s)

        Next


        Dim OrderID As String = CType(sender, TouOrderControl).IDValue
        Dim cnStr As String = FrmDataSql
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM Order_view WHERE 编号 ='" & OrderID & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim i As Int16 = -1
        ListLabelNum = 0
        While dr.Read()
            i = i + 1
            BOMPicList(BOMPN:=Trim(dr("料号").ToString + Space(5)))
            Dim ListOrderLabel As New OrderListControl

            ListOrderLabel.Name = i
            ListOrderLabel.ListPNValue = Trim(dr("料号").ToString + Space(5))
            ListOrderLabel.ListOrderValue = Trim(dr("工单号").ToString + Space(5))
            ListOrderLabel.ListNumValue = Trim(dr("数量").ToString + Space(5)) & "PCS"

            ListOrderLabel.Top = 5
            ListOrderLabel.Left = 220 * i + 5

            Me.TabPage3.Controls.Add(ListOrderLabel)
            ' AddHandler Orderlabel.Click, AddressOf Orderlabelclick



            'If Trim(dr("工单上线").ToString + Space(5)) <> "已上线" Then




        End While
        ListLabelNum = i


        cn.Close()


    End Sub



    Private Sub BOMPicList(ByVal BOMPN As String)
        Dim cnStr As String = SQL
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        cn.Open()
        Dim a As String = "SELECT * FROM ERPBOM WHERE ITEMNO ='" & BOMPN & "'"
        Dim cmd As SqlCommand = New SqlCommand(a, cn) '表名
        Dim dr As SqlDataReader = cmd.ExecuteReader()


        If dr.HasRows = 0 Then

        Else
            Dim i As Int32 = 0
            While dr.Read()
                BOMPN = Trim(dr("COMPITEM").ToString + Space(5))



                Dim cn1 As SqlConnection = New SqlConnection(cnStr)
                cn1.Open()
                Dim a1 As String = "SELECT * FROM ERPBOM WHERE ITEMNO ='" & BOMPN & "'"
                Dim cmd1 As SqlCommand = New SqlCommand(a1, cn1) '表名
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader()

                If dr1.HasRows = 0 Then

                    If i < Int(TabPage2.Width / 200) Then
                        i = i + 1
                    Else
                        i = 1
                        FrmPicList = FrmPicList + 1
                    End If
                    Dim PicLabel As New OrderPicControl
                    BOMPN = Trim(dr("COMPITEM").ToString + Space(5))
                    PicLabel.PicPNValue = BOMPN
                    PicLabel.PicNumValue = Fix(Trim(dr("QTYPER").ToString + Space(5)))
                    Dim PicName As String = Mid(BOMPN, 5, Len(BOMPN))
                    Try
                        PicLabel.PicPathValue = Image.FromStream(Net.WebRequest.Create(ImagePath & "/image/" & PicName & ".jpg").GetResponse().GetResponseStream())
                    Catch ex As Exception
                        PicLabel.PicPathValue = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                    End Try
                    PicLabel.Top = FrmPicList * 150
                    PicLabel.Left = 200 * i - 190
                    Me.TabPage2.Controls.Add(PicLabel)
                    TextBox1.Text = TextBox1.Text + 1
                Else
                    While dr1.Read()
                        BOMPN = Trim(dr1("COMPITEM").ToString + Space(5))

                        Dim cn2 As SqlConnection = New SqlConnection(cnStr)
                        cn2.Open()
                        Dim a2 As String = "SELECT * FROM ERPBOM WHERE ITEMNO ='" & BOMPN & "'"
                        Dim cmd2 As SqlCommand = New SqlCommand(a2, cn2) '表名
                        Dim dr2 As SqlDataReader = cmd2.ExecuteReader()

                        If dr2.HasRows = 0 Then

                            If i < Int(TabPage2.Width / 200) Then
                                i = i + 1
                            Else
                                i = 1
                                FrmPicList = FrmPicList + 1
                            End If
                            Dim PicLabel As New OrderPicControl
                            BOMPN = Trim(dr1("COMPITEM").ToString + Space(5))
                            PicLabel.PicPNValue = BOMPN
                            PicLabel.PicNumValue = Fix(Trim(dr1("QTYPER").ToString + Space(5)))
                            Dim PicName As String = Mid(BOMPN, 5, Len(BOMPN))
                            Try
                                PicLabel.PicPathValue = Image.FromStream(Net.WebRequest.Create(ImagePath & "/image/" & PicName & ".jpg").GetResponse().GetResponseStream())
                            Catch ex As Exception
                                PicLabel.PicPathValue = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                            End Try
                            PicLabel.Top = FrmPicList * 150
                            PicLabel.Left = 200 * i - 190
                            Me.TabPage2.Controls.Add(PicLabel)
                            TextBox1.Text = TextBox1.Text + 1




                        Else
                            While dr2.Read()



                                '-------------------------------------------------------







                            End While
                        End If
                        cn2.Close()
                    End While
                End If
                cn1.Close()
            End While
        End If
        cn.Close()
    End Sub
End Class