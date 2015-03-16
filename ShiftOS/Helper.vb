Public Class Helper
    Dim path As String = ShiftOSDesktop.ShiftOSPath
    Public Sub addCP(points As Integer) 'Add some CP
        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + points
    End Sub
    Public Sub setCP(points As Integer) 'Set the CP
        ShiftOSDesktop.codepoints = points
    End Sub

    Public Sub removeCP(points As Integer)
        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints - points
    End Sub
    Public Sub playSound(path As String, playMode As AudioPlayMode)
        My.Computer.Audio.Play(path, playMode)
    End Sub
End Class
