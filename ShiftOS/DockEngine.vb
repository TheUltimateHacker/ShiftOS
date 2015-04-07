Public Class DockEngine

    Public docktop As Integer
    Public topbottom As String

    Dim allLines As List(Of String) = New List(Of String)
    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Public Sub readFile(ByVal file As String)

        If My.Computer.FileSystem.FileExists(file) Then

            allLines.Clear()

            Dim reader As New System.IO.StreamReader(file)
            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop
            reader.Close()

            For Each item As String In allLines
                Dim tileinfo() As String
                tileinfo = item.Split("#")
                DockWindow.createtile(tileinfo(0), tileinfo(1))

            Next
        Else
            Dim filepath As String = file
            If Not System.IO.File.Exists(filepath) Then
                If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "\SoftwareData\ShiftDock") Then
                    My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "\SoftwareData\ShiftDock")
                End If
                System.IO.File.Create(filepath).Dispose()
                DockWindow.firststart = True
            End If
        End If

    End Sub

    Public Sub readConfFile(ByVal file As String)

        If My.Computer.FileSystem.FileExists(file) Then

            allLines.Clear()

            Dim reader As New System.IO.StreamReader(file)
            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop
            reader.Close()


            docktop = allLines(0)
            topbottom = allLines(1)

            DockWindow.Top = docktop

        Else
            Dim filepath As String = file
            If Not System.IO.File.Exists(filepath) Then
                System.IO.File.Create(filepath).Dispose()
            End If
        End If


    End Sub

    Public Sub writeFile(ByVal path As String, color As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath + "\SoftwareData\ShiftDock\tiles.dat", True)
        file.WriteLine(path + "#" + color)
        file.Close()
    End Sub

    Public Sub writeConfFile(ByVal top As String, updown As String)
        My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\SoftwareData\ShiftDock\conf.dat")
        Dim filepath As String = Application.StartupPath + "\SoftwareData\ShiftDock\conf.dat"
        If Not System.IO.File.Exists(filepath) Then
            System.IO.File.Create(filepath).Dispose()
        End If
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath + "\SoftwareData\ShiftDock\conf.dat", True)
        file.WriteLine(top)
        file.WriteLine(updown)
        file.Close()
    End Sub

End Class
