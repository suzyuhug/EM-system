Imports System.Data.SqlClient
Public Class userprfrm
    Private Sub userprfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
        Dim cn As SqlConnection = New SqlConnection(cnStr)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT UserID FROM Login_User", cn) '表名
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "mytable")

        ComboBox1.DataSource = ds.Tables("mytable")
        ComboBox1.DisplayMember = "UserID"
        'ComboBox1.ValueMember = "列2"

        cn.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        CheckBox12.Checked = False
        CheckBox13.Checked = False
        CheckBox14.Checked = False
        CheckBox15.Checked = False
        CheckBox16.Checked = False
        CheckBox17.Checked = False
        CheckBox18.Checked = False
        CheckBox19.Checked = False
        CheckBox20.Checked = False
        CheckBox21.Checked = False
        CheckBox22.Checked = False
        CheckBox23.Checked = False
        CheckBox24.Checked = False
        CheckBox25.Checked = False




        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择一个用户！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim cnStr As String = FrmDataSql  '数据库名，帐号，密码            
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Login_User", cn) '表名
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "mytable")

            Dim dv As New DataView(ds.Tables("mytable"), "", "UserID", DataViewRowState.CurrentRows) '指定默认查找列为姓名
            Dim rowIndex As Integer = dv.Find(ComboBox1.Text)
            If rowIndex = -1 Then


            Else
                Label2.Visible = True
                Label3.Visible = True

                Label3.Text = Trim(dv(rowIndex)("UserName").ToString)
                If Trim(dv(rowIndex)("记住密码").ToString) = "有" Then CheckBox25.Checked = True
                If Trim(dv(rowIndex)("工单登记").ToString) = "有" Then CheckBox1.Checked = True
                If Trim(dv(rowIndex)("投工单").ToString) = "有" Then CheckBox2.Checked = True
                If Trim(dv(rowIndex)("工单上线").ToString) = "有" Then CheckBox3.Checked = True
                If Trim(dv(rowIndex)("工单入库").ToString) = "有" Then CheckBox4.Checked = True
                If Trim(dv(rowIndex)("终检完成").ToString) = "有" Then CheckBox5.Checked = True
                If Trim(dv(rowIndex)("库位查询").ToString) = "有" Then CheckBox6.Checked = True
                If Trim(dv(rowIndex)("借料管理").ToString) = "有" Then CheckBox7.Checked = True
                If Trim(dv(rowIndex)("检查表打印").ToString) = "有" Then CheckBox8.Checked = True
                If Trim(dv(rowIndex)("木箱上线").ToString) = "有" Then CheckBox9.Checked = True
                If Trim(dv(rowIndex)("数据备份").ToString) = "有" Then CheckBox10.Checked = True
                If Trim(dv(rowIndex)("工单目录").ToString) = "有" Then CheckBox11.Checked = True
                If Trim(dv(rowIndex)("工单顺序").ToString) = "有" Then CheckBox12.Checked = True
                If Trim(dv(rowIndex)("检查表编辑").ToString) = "有" Then CheckBox13.Checked = True
                If Trim(dv(rowIndex)("借料数据").ToString) = "有" Then CheckBox14.Checked = True
                If Trim(dv(rowIndex)("借料用户").ToString) = "有" Then CheckBox15.Checked = True
                If Trim(dv(rowIndex)("用户注册").ToString) = "有" Then CheckBox16.Checked = True
                If Trim(dv(rowIndex)("密码重置").ToString) = "有" Then CheckBox17.Checked = True
                If Trim(dv(rowIndex)("用户权限").ToString) = "有" Then CheckBox18.Checked = True
                If Trim(dv(rowIndex)("工单物料").ToString) = "有" Then CheckBox19.Checked = True
                If Trim(dv(rowIndex)("工单数据").ToString) = "有" Then CheckBox20.Checked = True
                If Trim(dv(rowIndex)("木箱管理").ToString) = "有" Then CheckBox21.Checked = True
                If Trim(dv(rowIndex)("工单查询").ToString) = "有" Then CheckBox22.Checked = True
                If Trim(dv(rowIndex)("工单明细").ToString) = "有" Then CheckBox23.Checked = True
                If Trim(dv(rowIndex)("借料查询").ToString) = "有" Then CheckBox24.Checked = True

            End If
            cn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Label3.Text = "" Then
            MessageBox.Show("请选择要更改的用户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim cnStr As String = FrmDataSql
            Dim cn As SqlConnection = New SqlConnection(cnStr)
            Dim da As New SqlDataAdapter("select * from Login_User", cn)
            Dim ds As New DataSet()
            da.Fill(ds, "mytable")
            Dim drow As DataRow
            ds.Tables("mytable").PrimaryKey = New DataColumn() {ds.Tables("mytable").Columns("UserID")}
            drow = ds.Tables("mytable").Rows.Find(ComboBox1.Text)
            Try

                If CheckBox25.Checked = True Then drow("记住密码") = "有" Else drow("记住密码") = "无"
                If CheckBox1.Checked = True Then drow("工单登记") = "有" Else drow("工单登记") = "无"
                If CheckBox2.Checked = True Then drow("投工单") = "有" Else drow("投工单") = "无"
                If CheckBox3.Checked = True Then drow("工单上线") = "有" Else drow("工单上线") = "无"
                If CheckBox4.Checked = True Then drow("工单入库") = "有" Else drow("工单入库") = "无"
                If CheckBox5.Checked = True Then drow("终检完成") = "有" Else drow("终检完成") = "无"
                If CheckBox6.Checked = True Then drow("库位查询") = "有" Else drow("库位查询") = "无"
                If CheckBox7.Checked = True Then drow("借料管理") = "有" Else drow("借料管理") = "无"
                If CheckBox8.Checked = True Then drow("检查表打印") = "有" Else drow("检查表打印") = "无"
                If CheckBox9.Checked = True Then drow("木箱上线") = "有" Else drow("木箱上线") = "无"
                If CheckBox10.Checked = True Then drow("数据备份") = "有" Else drow("数据备份") = "无"
                If CheckBox11.Checked = True Then drow("工单目录") = "有" Else drow("工单目录") = "无"
                If CheckBox12.Checked = True Then drow("工单顺序") = "有" Else drow("工单顺序") = "无"
                If CheckBox13.Checked = True Then drow("检查表编辑") = "有" Else drow("检查表编辑") = "无"
                If CheckBox14.Checked = True Then drow("借料数据") = "有" Else drow("借料数据") = "无"
                If CheckBox15.Checked = True Then drow("借料用户") = "有" Else drow("借料用户") = "无"
                If CheckBox16.Checked = True Then drow("用户注册") = "有" Else drow("用户注册") = "无"
                If CheckBox17.Checked = True Then drow("密码重置") = "有" Else drow("密码重置") = "无"
                If CheckBox18.Checked = True Then drow("用户权限") = "有" Else drow("用户权限") = "无"
                If CheckBox19.Checked = True Then drow("工单物料") = "有" Else drow("工单物料") = "无"
                If CheckBox20.Checked = True Then drow("工单数据") = "有" Else drow("工单数据") = "无"
                If CheckBox21.Checked = True Then drow("木箱管理") = "有" Else drow("木箱管理") = "无"
                If CheckBox22.Checked = True Then drow("工单查询") = "有" Else drow("工单查询") = "无"
                If CheckBox23.Checked = True Then drow("工单明细") = "有" Else drow("工单明细") = "无"
                If CheckBox24.Checked = True Then drow("借料查询") = "有" Else drow("借料查询") = "无"


                Dim cmdb As New SqlCommandBuilder(da)
                da.Update(ds, "mytable")
                MessageBox.Show("权限更改成功！", "密码重置提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Label3.Text = ""
                Label2.Visible = False
                Label3.Visible = False
                ComboBox1.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            cn.Close()
        End If
    End Sub
End Class