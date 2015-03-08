Imports System.Xml
Imports System.IO
Imports System.Text

Public Class STML_Test
    Dim obj As Collection
    Private Sub STML_Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim test As String = "Hello,50,50,500,50,text|Hello210,100,100,500,50,text".Replace(ControlChars.NewLine, "|")
        parse(test)
    End Sub
    Private Sub parse(objs As String)
        For Each tag As String In objs.Split("|")
            parseobj(tag)
        Next
    End Sub
    Private Sub parseobj(objx As String)
        Dim values As String() = objx.Split(",")
        Try
            Select Case values(5)
                Case "text"
                    addLabel(getLabel(New Size(values(3), values(4)), New Point(values(1), values(2)), values(0)))
                Case Else
                    addLabel(getLabel(New Size(values(3), values(4)), New Point(values(1), values(2)), values(0)))
            End Select
        Catch ex As Exception
            addLabel(getLabel(New Size(50, 555), New Point(0, 0), "Syntax error somewhere"))
        End Try
    End Sub
    Private Sub addLink(lbl As TextBox, onclick As Func(Of Object, EventArgs))

        AddHandler lbl.MouseDown, AddressOf MyTextbox_TextChanged
        Me.Controls.Add(lbl)
    End Sub
    Private Function getLabel(size As Size, pos As Point, text As String)
        Dim tb As New TextBox()
        With tb
            .Size = size
            .Location = pos
            .BorderStyle = BorderStyle.None
            .ReadOnly = True
            .Multiline = True
            .Text = text
        End With
        Return tb
    End Function
    Private Sub addLabel(lbl As TextBox)
        Me.Controls.Add(lbl)
    End Sub
    Private Sub MyTextbox_TextChanged(sender As Object, e As EventArgs)
        MsgBox("SS")
    End Sub

End Class