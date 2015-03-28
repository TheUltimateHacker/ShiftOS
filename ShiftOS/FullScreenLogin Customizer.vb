Public Class FullScreenLoginCustomizer

#Region "Declarations"
    Public autologin As Boolean
    Public fullScreen As Boolean
    Public inputfont As String
    Public inputfontsize As Integer
    Public inputfontstyle As FontStyle
    Public inputforecolor As Color
    Public inputbackcolor As Color
    Public buttonfont As String
    Public buttonfontsize As Integer
    Public buttonfontstyle As FontStyle

    Public userimagesize As Integer
    Public userimagelocation As Point
    Public userimage As Image
    Public userimagelayout As ImageLayout

    Public loginbg As Image
    Public loginbgcolor As Color
    Public loginbglayout As ImageLayout

    'Locations...

    Public userTextboxX As Integer
    Public userTextBoxY As Integer
    Public passTextBoxX As Integer
    Public passTextBoxY As Integer
    Public loginbtnX As Integer
    Public loginbtnY As Integer
    Public shutdownbtnX As Integer
    Public shutdownbtnY As Integer

    'Codepoint Stuff

    Public earnedCP As Integer = 0


#End Region

    Dim currentControl As String = "None"

    Private Sub FullScreenLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        setskin()
    End Sub

    Public Sub setskin()
        preview.BackColor = Skins.loginbgcolor
        preview.BackgroundImage = Skins.loginbg
        preview.BackgroundImageLayout = Skins.loginbglayout
        userpic.Size = New Size(Skins.userimagesize, Skins.userimagesize)
        userpic.BackgroundImage = Skins.userimage
        userpic.BackColor = Color.Transparent
        userpic.BackgroundImageLayout = Skins.userimagelayout
        If Not IsNothing(Skins.userimagelocation) Then userpic.Location = Skins.userimagelocation
        'buggy
        'txtusername.ForeColor = Skins.inputforecolor
        'txtpassword.ForeColor = Skins.inputforecolor
        'txtusername.BackColor = Skins.inputbackcolor
        'txtpassword.BackColor = Skins.inputbackcolor
        txtusername.Location = New Point(Skins.userTextboxX, Skins.userTextBoxY)
        txtpassword.Location = New Point(Skins.passTextBoxX, Skins.passTextBoxY)
        loginbtn.Location = New Point(Skins.loginbtnX, Skins.loginbtnY)
        shutdown.Location = New Point(Skins.shutdownbtnX, Skins.shutdownbtnY)
        If shutdown.Location.X > preview.Height Then
            shutdown.Location = New Point(Skins.shutdownbtnX, Skins.shutdownbtnY - pnldefault.Height)
        End If
        Titlebar.Height = Skins.titlebarheight
        lbtitletext.ForeColor = Skins.titletextcolour
        lbtitletext.BackColor = Skins.titlebarcolour
        If Skins.titlebar Is Nothing Then lbtitletext.BackgroundImage = Nothing Else lbtitletext.BackgroundImage = Skins.titlebar
        lbtitletext.BackgroundImageLayout = Skins.titlebarlayout
        Select Case Skins.titletextpos
            Case "Left"
                lbtitletext.TextAlign = ContentAlignment.MiddleLeft
            Case "Centre"
                lbtitletext.TextAlign = ContentAlignment.MiddleCenter
        End Select
        lbtitletext.Font = New Font(Skins.titletextfontfamily, Skins.titletextfontsize, Skins.titletextfontstyle, GraphicsUnit.Point)
        Me.TopMost = True
    End Sub


    Private Sub userpic_Click(sender As Object, e As EventArgs) Handles userpic.Click
        currentControl = "User Picture"
        determineSettings()
    End Sub

    Private Sub userpic_UserMove(sender As Object, e As MouseEventArgs) Handles userpic.MouseUp
        userimagelocation = userpic.Location
        setNewSkin()
    End Sub

    Public Sub determineSettings()
        'Sets what settings panel is visible:
        Select Case currentControl
            Case "None"
                pnldefault.Show()
            Case "User Picture"
                pnluserpicture.Show()
        End Select
    End Sub

    Public Sub applySettings()
        Skins.userimage = userimage
        Skins.userimagesize = userimagesize
        Skins.userimagelayout = userimagelayout
        Skins.userimagelocation = userimagelocation
        Skins.inputforecolor = inputforecolor
        Skins.inputbackcolor = inputbackcolor
        Skins.inputfont = inputfont
        Skins.inputfontsize = inputfontsize
        Skins.inputfontstyle = inputfontstyle
        Skins.buttonfont = buttonfont
        Skins.buttonfontsize = buttonfontsize
        Skins.buttonfontstyle = buttonfontstyle
        Skins.loginbg = loginbg
        Skins.loginbglayout = loginbglayout
        Skins.loginbgcolor = loginbgcolor
        Skins.userTextboxX = userTextboxX
        Skins.userTextBoxY = userTextBoxY
        Skins.passTextBoxX = passTextBoxX
        Skins.passTextBoxY = passTextBoxY
        Skins.shutdownbtnX = shutdownbtnX
        Skins.shutdownbtnY = shutdownbtnY
        Skins.loginbtnX = loginbtnX
        Skins.loginbtnY = loginbtnY
        Skins.saveskinfiles(True)
        infobox.showinfo("Login Screen Customizer", "You have earned " & earnedCP & " Code points for all customizations made to your login screen.")
        Helper.addCP(earnedCP)
    End Sub

    Public Sub setDefaults()
        userimage = Skins.userimage
        userimagesize = Skins.userimagesize
        userimagelayout = Skins.userimagelayout
        userimagelocation = Skins.userimagelocation
        inputforecolor = Skins.inputforecolor
        inputbackcolor = Skins.inputbackcolor
        inputfont = Skins.inputfont
        inputfontsize = Skins.inputfontsize
        inputfontstyle = Skins.inputfontstyle
        buttonfont = Skins.buttonfont
        buttonfontsize = Skins.buttonfontsize
        buttonfontstyle = Skins.buttonfontstyle
        loginbg = Skins.loginbg
        loginbgcolor = Skins.loginbgcolor
        loginbglayout = Skins.loginbglayout
        userTextboxX = Skins.userTextboxX
        userTextBoxY = Skins.userTextBoxY
        passTextBoxX = Skins.passTextBoxX
        passTextBoxY = Skins.passTextBoxY
        shutdownbtnX = Skins.shutdownbtnX
        shutdownbtnY = Skins.shutdownbtnY
        loginbtnX = Skins.loginbtnX
        loginbtnY = Skins.loginbtnY
    End Sub

    Public Sub setNewSkin()
        preview.BackColor = loginbgcolor
        If loginbg Is Nothing Then preview.BackgroundImage = Nothing Else preview.BackgroundImage = loginbg
        preview.BackgroundImageLayout = loginbglayout

        userpic.BackgroundImage = userimage
        userpic.Size = New Size(userimagesize, userimagesize)
        userpic.BackgroundImageLayout = userimagelayout

        txtusername.ForeColor = inputforecolor
        txtpassword.ForeColor = inputforecolor
        txtusername.BackColor = inputbackcolor
        txtpassword.BackColor = inputbackcolor
        addRandomCP()
        
    End Sub

    Public Sub addRandomCP()
        Dim rand As New Random
        Dim numToAdd As Integer = rand.Next(1, 5)
        earnedCP = earnedCP + numToAdd
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Graphic_Picker.graphictochange = "User Account Picture"
        Graphic_Picker.Show()
    End Sub

    Private Sub txtusername_UserMove(sender As Object, e As MouseEventArgs) Handles txtusername.MouseUp
        currentControl = "Username Input"
        determineSettings()
        userTextboxX = txtusername.Location.X
        userTextBoxY = txtusername.Location.Y
        setNewSkin()
    End Sub

    Private Sub txtpassword_MouseUp(sender As Object, e As MouseEventArgs) Handles txtpassword.MouseUp
        currentControl = "Password Input"
        determineSettings()
        passTextBoxX = txtpassword.Location.X
        passTextBoxY = txtpassword.Location.Y
        setNewSkin()
    End Sub

    Private Sub shutdown_MouseUp(sender As Object, e As MouseEventArgs) Handles shutdown.MouseUp
        currentControl = "Shutdown Button"
        determineSettings()
        shutdownbtnX = shutdown.Location.X
        shutdownbtnY = shutdown.Location.Y
        setNewSkin()
    End Sub

    Private Sub loginbtn_MouseUp(sender As Object, e As MouseEventArgs) Handles loginbtn.MouseUp
        currentControl = "Log In Button"
        determineSettings()
        loginbtnX = loginbtn.Location.X
        loginbtnY = loginbtn.Location.Y
        setNewSkin()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        applySettings()
        Me.Close()
    End Sub
End Class