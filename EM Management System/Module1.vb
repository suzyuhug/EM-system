Imports System
Imports System.Security.Cryptography
Imports System.Text



Module Example
    '---------------------------------------------------------全局变量
    Public Uservar As String
    Public useridvar As String
    Public passwordvar As String
    Public FrmDataSql As String

    '---------------------------------------------------------标签打印全局变量
    Public LabelButtionName As String





    ' 哈希输入字符串并返回一个32字符的十六进制字符串哈希。
    Function getMd5Hash(ByVal input As String) As String
        ' 创建新的一个MD5CryptoServiceProvider对象的实例。
        Dim md5Hasher As New MD5CryptoServiceProvider()
        ' 输入的字符串转换为字节数组，并计算哈希。
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))
        ' 创建一个新的StringBuilder收集的字节，并创建一个字符串。
        Dim sBuilder As New StringBuilder()
        ' 通过每个字节的哈希数据和格式为十六进制字符串的每一个循环。
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        ' 返回十六进制字符串。
        Return sBuilder.ToString()
    End Function
    ' 验证对一个字符串的哈希值。
    Function verifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        ' 哈希的输入。
        Dim hashOfInput As String = getMd5Hash(input)
        ' 创建StringComparer1的哈希进行比较。
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
' 此代码示例产生下面的输出：
'
' 进行MD5加密的字符串为：Hello World! 加密的结果是：ed076287532e86365e841e92bfc50d8c.
' 验证哈希...
' 哈希值是相同的。