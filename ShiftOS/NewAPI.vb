Module NewAPI
    Private Command As String
    Private NewModForm As New ModForm

    ' This stores the message and title values for the infobox, since they are created with 2 commands.
    Dim modInfoMessage As String = "ShiftOS has been modified to create this infobox, use infobox.message = <your message> to customise it."
    Dim modInfoTitle As String = "Info from Mod, customise it with infobox.title = <title>"
    Dim isInfo As Integer = 0
    ' Tells other programs where to place output files
    Public modOutputPath As String
    Dim modInPath As String

    Dim WithEvents trmReadModInput As New Timer

    Public Sub ReadModInput(ByVal sender As Object, ByVal e As EventArgs) Handles trmReadModInput.Tick
        If My.Computer.FileSystem.FileExists(modInPath) Then
            UseCode(modInPath, modOutputPath)
        End If
    End Sub

    Public Sub OpenModFile(path As String)
        ' Mod files are zips containing "config.set" and application files.
        My.Computer.FileSystem.DeleteDirectory(ShiftOSDesktop.ShiftOSPath & "\Shiftum42\Temp\ModLoader", FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.CreateDirectory(ShiftOSDesktop.ShiftOSPath & "\Shiftum42\Temp\ModLoader")

        System.IO.Compression.ZipFile.ExtractToDirectory(path, ShiftOSDesktop.ShiftOSPath & "\Shiftum42\Temp\ModLoader")
        ' Config contents: line1 = what exe to launch, line2 = path mod with write to, line 3 = folder mod will read from, line4 = connection delay in milliseconds
        Dim configdata(3) As String
        configdata = System.IO.File.ReadAllLines(ShiftOSDesktop.ShiftOSPath & "\Shiftum42\Temp\ModLoader\config.set")
        Try
            Process.Start(ShiftOSDesktop.ShiftOSPath & "\Shiftum42\Temp\ModLoader\" & configdata(0))
            modOutputPath = configdata(2)
            modInPath = configdata(1)
        Catch ex As Exception
            infobox.showinfo("Mod Error", "There is an error in the modification's config file. Please contact the developer of you mod. If you are the developer, remember: line1 = what exe to launch, line2 = path mod with write to, line 3 = folder mod will read from, line4 = connection delay in milliseconds")
        End Try
        trmReadModInput.Interval = configdata(3)
        trmReadModInput.Start()
    End Sub


    Public Sub UseCode(ByVal InPath As String, ByVal OutPath As String)
        Dim sr As System.IO.StreamReader

        sr = My.Computer.FileSystem.OpenTextFileReader(InPath)
        Dim linenum As Integer = IO.File.ReadAllLines(InPath).Length
        Dim i As Integer = 1
        While i <= linenum
            Command = sr.ReadLine()
            DoCommandAPI()
            i = i + 1
        End While
        sr.Close()
        My.Computer.FileSystem.DeleteFile(modInPath)
        modOutputPath = OutPath
    End Sub

    Private Sub DoCommandAPI()
        If Command Like "infobox.title = *" Then
            Try
                Dim title As String = Command.Substring(16)
                modInfoTitle = title
                isInfo = isInfo + 1
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        ElseIf Command Like "infobox.message = *" Then
            Try
                Dim Message As String = Command.Substring(18)
                modInfoMessage = Message
                isInfo = isInfo + 1
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
        ElseIf Command Like "getcolour.title = *" Then
            Try
                Dim title As String = Command.Substring(18)
                Colour_Picker.colourtochange = title
                Colour_Picker.Show()
                Colour_Picker.sendToMod = True
            Catch ex As Exception
                infobox.showinfo("Critical Modification Application Error", "A critical error occured whilst trying to add to your codepoint value - please contact the developer of your mod")
            End Try
        End If
        If isInfo > 2 Then
            infobox.showinfo(modInfoTitle, modInfoMessage)
            isInfo = 0
        End If
    End Sub
End Module
