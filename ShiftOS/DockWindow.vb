Public Class DockWindow

    Public screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim toleft As Integer = 30
    Dim tileprogram(100) As String
    Dim currenttile As String = 0
    Public loadevents As New DockEngine
    Public docktopbot As String = "Bottom"
    Public firststart As Boolean

    Public Sub colours()
        'Dim img As New Bitmap(picBackColor.Width, picBackColor.Height)
        'Dim brush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(img.Width, img.Height), SystemColors.Window, SystemColors.ControlLight)
        ' Dim gr As Graphics = Graphics.FromImage(img)
        'gr.FillRectangle(brush, New RectangleF(0, 0, img.Width, img.Height))
        'picBackColor.BackgroundImage = img
    End Sub

    Private Sub Dock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Me.ShowInTaskbar = False
        toleft = toleft + 40
        Dim tile As New PictureBox
        tile.BackColor = Color.Silver
        tile.Height = 40
        tile.Width = 40
        tile.Top = 54
        tile.Left = toleft
        'tile.Image = My.Resources.settings
        tile.SizeMode = PictureBoxSizeMode.Zoom
        tile.Name = currenttile
        toleft = toleft + 45
        tile.BringToFront()
        'picBackColor.SendToBack()
        tile.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Width = Me.Width + tile.Width + 5
        Me.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)
        pnlTiles.Controls.Add(tile)
        currenttile = currenttile + 1
        AddHandler tile.Click, AddressOf tilesets_click
        AddHandler tile.MouseHover, AddressOf tile_hover
        AddHandler tile.MouseLeave, AddressOf tile_leave
        colours()
        loadevents.readFile(Application.StartupPath + "\SoftwareData\ShiftDock\tiles.dat")
        loadevents.readConfFile(Application.StartupPath + "\SoftwareData\ShiftDock\conf.dat")
        loadevents.writeConfFile(Me.Top, docktopbot)
        Me.Top = loadevents.docktop
        docktopbot = loadevents.topbottom
        If firststart = True Then
            docktopbot = "Bottom"
            Me.Top = screenHeight - Me.Height + 25
        End If
        If docktopbot = "Bottom" Then
            'Me.Top = screenHeight - Me.Height - 42
            Me.picBoarder.Top = 96
            Me.picBoarder.BringToFront()
            loadevents.writeConfFile(Me.Top, "Bottom")
        Else
            Me.picBoarder.Top = 31
            Me.picBoarder.BringToFront()
            loadevents.writeConfFile(Me.Top, "Top")
        End If
       Me.TopMost = True
        'tmr_faid.Start()
    End Sub

    Public Sub createtile(ByVal openPath As String, backcolor As String)
        Dim tile As New PictureBox
        If backcolor.Contains("A=") Then
            Dim newcolor() As String
            newcolor = backcolor.Split(",")
            tile.BackColor = Color.FromArgb(newcolor(0).Replace("A=", "").Replace(" ", ""), newcolor(1).Replace("R=", "").Replace(" ", ""), newcolor(2).Replace("G=", "").Replace(" ", ""), newcolor(3).Replace("B=", "").Replace(" ", ""))
        Else
            Try
                tile.BackColor = Color.FromName(backcolor.Replace(" ", ""))
            Catch
                Try
                    tile.BackColor = Color.FromKnownColor(backcolor)
                Catch
                    tile.BackColor = Color.Red
                End Try
            End Try
        End If
        tile.Height = 40
        tile.Width = 40
        tile.Top = 54
        tile.Left = toleft
        If openPath = "ArtPad" Then
            tile.Image = ShiftOSDesktop.artpadiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Audio Player" Then
            tile.Image = ShiftOSDesktop.audioplayericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Bit Note Digger" Then
            tile.Image = ShiftOSDesktop.bitnotediggericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Bit Note Wallet" Then
            tile.Image = ShiftOSDesktop.bitnotewalleticonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Calculator" Then
            tile.Image = ShiftOSDesktop.calculatoriconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
         ElseIf openPath = "Catlyst" Then
            tile.Image = ShiftOSDesktop.calculatoriconlauncher 'needs new icon
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Clock" Then
            tile.Image = ShiftOSDesktop.clockiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Dodge" Then
            tile.Image = ShiftOSDesktop.dodgeiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Downloader" Then
            tile.Image = ShiftOSDesktop.downloadericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Downloader Manager" Then
            tile.Image = ShiftOSDesktop.downloadmanagericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "File Skimmer" Then
            tile.Image = ShiftOSDesktop.fileskimmericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "FloodGate Manager" Then
            tile.Image = ShiftOSDesktop.floodgateiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Icon Manager" Then
            tile.Image = ShiftOSDesktop.iconmanagericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Installer" Then
            tile.Image = ShiftOSDesktop.installericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Knowledge Input" Then
            tile.Image = ShiftOSDesktop.knowledgeinputiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Labyrinth" Then
            tile.Image = ShiftOSDesktop.calculatoriconlauncher 'needs new icon
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Name Changer" Then
            tile.Image = ShiftOSDesktop.namechangericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "OrcWrite" Then
            tile.Image = ShiftOSDesktop.orcwriteiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Pong" Then
            tile.Image = ShiftOSDesktop.pongiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Shifter" Then
            tile.Image = ShiftOSDesktop.shiftericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Shiftorium" Then
            tile.Image = ShiftOSDesktop.shiftoriumiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Snakey" Then
            tile.Image = ShiftOSDesktop.snakeyiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Terminal" Then
            tile.Image = ShiftOSDesktop.terminaliconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "TextPad" Then
            tile.Image = ShiftOSDesktop.textpadiconlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "Video Player" Then
            tile.Image = ShiftOSDesktop.videoplayericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "VirusScanner" Then
            tile.Image = ShiftOSDesktop.virusscannericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "WebBrowser" Then
            tile.Image = ShiftOSDesktop.webbrowsericonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf openPath = "ShiftNet" Then
            tile.Image = ShiftOSDesktop.shiftneticonlauncher
            tile.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        tile.Name = currenttile
        tileprogram(currenttile) = openPath
        toleft = toleft + 45
        tile.BringToFront()
        'picBackColor.SendToBack()
        tile.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Width = Me.Width + tile.Width + 5
        Me.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)
        pnlTiles.Controls.Add(tile)
        currenttile = currenttile + 1
        AddHandler tile.Click, AddressOf tile_click
        AddHandler tile.MouseHover, AddressOf tile_hover
        AddHandler tile.MouseLeave, AddressOf tile_leave
    End Sub

    'Private Sub btnAddIcon_Click(sender As Object, e As EventArgs) Handles btnAddIcon.Click
    ' createtile(txtURL.Text)
    'colours()
    ' End Sub

    Private Sub tile_click(sender As Object, e As EventArgs)
        Dim tle As PictureBox = DirectCast(sender, PictureBox)
        Dim open As String = tle.Name
        If tileprogram(open) = "ArtPad" Then
            ArtPad.Show()
        ElseIf tileprogram(open) = "Audio Player" Then
            Audio_Player.Show()
        ElseIf tileprogram(open) = "Bit Note Digger" Then
            Bitnote_Digger.Show()
        ElseIf tileprogram(open) = "Bit Note Wallet" Then
            Bitnote_Wallet.Show()
        ElseIf tileprogram(open) = "Calculator" Then
            Calculator.Show()
        ElseIf tileprogram(open) = "Catlyst" Then
            Catalyst_Main.Show()
        ElseIf tileprogram(open) = "Clock" Then
            Clock.Show()
        ElseIf tileprogram(open) = "Dodge" Then
            Dodge.Show()
        ElseIf tileprogram(open) = "Downloader" Then
            Downloader.Show()
        ElseIf tileprogram(open) = "Downloader Manager" Then
            Downloadmanager.Show()
        ElseIf tileprogram(open) = "File Skimmer" Then
            File_Skimmer.Show()
        ElseIf tileprogram(open) = "FloodGate Manager" Then
            FloodGate_Manager.Show()
        ElseIf tileprogram(open) = "Icon Manager" Then
            Icon_Manager.Show()
        ElseIf tileprogram(open) = "Installer" Then
            Installer.Show()
        ElseIf tileprogram(open) = "Knowledge Input" Then
            Knowledge_Input.Show()
        ElseIf tileprogram(open) = "Labyrinth" Then
            Labyrinth.Show()
        ElseIf tileprogram(open) = "Name Changer" Then
            Name_Changer.Show()
        ElseIf tileprogram(open) = "OrcWrite" Then
            OrcWrite.Show()
        ElseIf tileprogram(open) = "Pong" Then
            Pong.Show()
        ElseIf tileprogram(open) = "Shifter" Then
            Shifter.Show()
        ElseIf tileprogram(open) = "Shiftorium" Then
            Shiftorium.Show()
        ElseIf tileprogram(open) = "Snakey" Then
            Snakey.Show()
        ElseIf tileprogram(open) = "Terminal" Then
            Terminal.Show()
        ElseIf tileprogram(open) = "TextPad" Then
            TextPad.Show()
        ElseIf tileprogram(open) = "Video Pad" Then
            Video_Player.Show()
        ElseIf tileprogram(open) = "VirusScanner" Then
            VirusScanner.Show()
        ElseIf tileprogram(open) = "WebBrowser" Then
            Web_Browser.Show()
        ElseIf tileprogram(open) = "ShiftNet" Then
            Shiftnet.Show()
        End If
    End Sub

    Dim dtop As Integer

    Private Sub tile_hover(sender As Object, e As EventArgs)
        Dim tle As PictureBox = DirectCast(sender, PictureBox)
        If docktopbot = "Bottom" Then
            Dim open As String = tle.Name
            tle.Top = tle.Top - 10
            Try
                'lblApp.Text = open
            Catch
                'lblApp.Text = "Error"
            End Try
        End If
        If docktopbot = "Top" Then
            dtop = tle.Top
            Dim open As String = tle.Name
            tle.Top = tle.Top + 10
            Try
                'lblApp.Text = open
            Catch
                'lblApp.Text = "Error"
            End Try
        End If

    End Sub

    Private Sub tile_leave(sender As Object, e As EventArgs)
        Dim tle As PictureBox = DirectCast(sender, PictureBox)
        If docktopbot = "Bottom" Then
            tle.Top = tle.Top + 10
            If tle.Top > 54 Then
                tle.Top = 54
            End If
        End If
        If docktopbot = "Top" Then
            tle.Top = tle.Top - 10
            If tle.Top < dtop Then
                tle.Top = dtop
            End If
        End If
    End Sub

    Private Sub tilesets_click(sender As Object, e As EventArgs)
        DockSettingsMenu.Show()
    End Sub

End Class