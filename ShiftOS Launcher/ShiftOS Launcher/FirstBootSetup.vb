Public Class FirstBootSetup

    Public FinishedFirstBoot As Boolean = False

    Private Sub FirstBootSetup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If FinishedFirstBoot = False Then
            e.Cancel = True
            MsgBox("You need to finish the first boot setup!")
        End If
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDown
        If TextBox1.Text = "Where do you want your ShiftOS executables to be save to? Nothing = C:\ShiftOS\SoftwareData\Launcher\ShiftOSEXE\" Then TextBox1.Text = Nothing
    End Sub

    Private Sub TextBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseDown
        If TextBox2.Text = "Type in a nickname here" Then TextBox2.Text = Nothing
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim folDialog As New FolderBrowserDialog
        If folDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = folDialog.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then My.Computer.FileSystem.WriteAllText(Main_Launcher.appData + "\BuildOption.dat", "Stable", False)
        If RadioButton2.Checked = True Then My.Computer.FileSystem.WriteAllText(Main_Launcher.appData + "\BuildOption.dat", "Unstable", False)

        If TextBox1.Text = Nothing Then My.Computer.FileSystem.WriteAllText(Main_Launcher.appData + "\ExecFolder.dat", "C:\ShiftOS\", False)
        If Not TextBox1.Text = Nothing Then My.Computer.FileSystem.WriteAllText(Main_Launcher.appData + "\ExecFolder.dat", TextBox1.Text, False)

        If TextBox2.Text = Nothing Then My.Computer.FileSystem.WriteAllText(Main_Launcher.appData + "\Nickname.dat", "ShiftOS User", False)
        If Not TextBox2.Text = Nothing Then My.Computer.FileSystem.WriteAllText(Main_Launcher.appData + "\Nickname.dat", TextBox2.Text, False)

        MsgBox("Completed!")
        FinishedFirstBoot = True
        Application.Restart()
    End Sub


End Class