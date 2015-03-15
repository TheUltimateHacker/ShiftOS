Module NewAPI
    Private Command As String
    Private NewModForm As New ModForm


    Public Sub UseCode(ByVal Path As String)
        Dim sr As System.IO.StreamReader

        sr = My.Computer.FileSystem.OpenTextFileReader(Path)
        Dim linenum As Integer = IO.File.ReadAllLines(Path).Length
        Dim i As Integer = 1
        While i <= linenum
            Command = sr.ReadLine()
            DoCommandAPI()
            i = i + 1
        End While
        sr.Close()
    End Sub

    Private Sub DoCommandAPI()
        If Command Like "infobox = *" Then
            Try
                Dim Message As String = Command.Substring(10)
                infobox.showinfo("Message from a ShiftOS Mod Files", Message)
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "codepoints.add = *" Then
            Try
                Dim CodePointsToAdd As Integer = Command.Substring(17)
                ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + CodePointsToAdd
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "bitnotes.add = *" Then
            Try
                Dim BitNotesToAdd As Integer = Command.Substring(15)
                ShiftOSDesktop.bitnotebalance = ShiftOSDesktop.bitnotebalance + BitNotesToAdd
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "window.create" Then
            Try
                NewModForm.Show()
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "label.create = *" Then
            Try
                NewModForm.CreateLabel(Command.Substring(15))
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "label.select = *" Then
            Try
                NewModForm.SelectLabel(Command.Substring(15))
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "SelectedLabel.Location.X = *" Then
            Try
                NewModForm.MoveSelectedLabelLocationX(Command.Substring(27))
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "SelectedLabel.Location.Y = *" Then
            Try
                NewModForm.MoveSelectedLabelLocationY(Command.Substring(27))
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "SelectedLabel.Text = *" Then
            Try
                NewModForm.SelectedLabelText(Command.Substring(21))
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        End If
    End Sub
End Module
