Public Class FullScreenLogin

    Private Sub FullScreenLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        setskin()
    End Sub

    Public Sub setskin()
        Me.BackColor = Color.Black
        Me.BackgroundImage = Skins.loginbg
        Me.BackgroundImageLayout = Skins.loginbglayout
        userpic.Size = New Size(Skins.userimagesize, Skins.userimagesize)
        userpic.BackgroundImage = Skins.userimage
        userpic.BackColor = Color.Transparent
        userpic.BackgroundImageLayout = Skins.userimagelayout
        If Not IsNothing(Skins.userimagelocation) Then userpic.Location = Skins.userimagelocation
        txtusername.Location = New Point(Skins.userTextboxX, Skins.userTextBoxY)
        txtpassword.Location = New Point(Skins.passTextBoxX, Skins.passTextBoxY)
        loginbtn.Location = New Point(Skins.loginbtnX, Skins.loginbtnY)
        shutdown.Location = New Point(Skins.shutdownbtnX, Skins.shutdownbtnY)
        Me.TopMost = True
    End Sub

    Private Sub loginbtn_Click(sender As Object, e As EventArgs) Handles loginbtn.Click
        If txtusername.Text = ShiftOSDesktop.username And txtpassword.Text = ShiftOSDesktop.password Then
            Me.Close()
            infobox.showinfo("Login Screen", "The Login Screen has completed with no errors!")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles shutdown.Click
        ShiftOSDesktop.shutdownshiftos()
    End Sub

    Private Sub clearChars(sender As Object, e As MouseEventArgs) Handles txtusername.MouseDown, txtpassword.MouseDown
        txtusername.Text = ""
        txtpassword.Text = ""
    End Sub
End Class