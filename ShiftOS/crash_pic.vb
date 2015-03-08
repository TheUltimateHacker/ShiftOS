Public Class crash_pic


    Private Sub crash_pic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        killme.Start()
    End Sub

    Private Sub killme_Tick(sender As Object, e As EventArgs) Handles killme.Tick
        Application.Exit()
    End Sub
End Class