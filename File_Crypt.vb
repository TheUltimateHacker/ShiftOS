Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Public Class File_Crypt
    Public Const sSecretKey As String = "Password"

    Public Shared Sub EncryptFile(ByVal sInputFilename As String, ByVal sOutputFilename As String, ByVal sKey As String)

        Dim fsInput As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        Dim fsEncrypted As New FileStream(sOutputFilename, FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()


        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()

        Dim cryptostream As New CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write)

        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Dispose()
        fsInput.Dispose()
        fsEncrypted.Dispose()
    End Sub

    Public Shared Sub DecryptFile(ByVal sInputFilename As String, ByVal sOutputFilename As String, ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()


        DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)

        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)

        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()

        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)

        Dim fsDecrypted As New StreamWriter(sOutputFilename)
        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
        fsDecrypted.Flush()
        fsread.Dispose()
        fsDecrypted.Dispose()
    End Sub

End Class