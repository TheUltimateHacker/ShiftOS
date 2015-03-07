Imports System.IO

Public Class File_Opener
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 400
    Public minimumsizeheight As Integer = 177

    Dim itemsdeleted As Integer
    Dim filetype As Integer
    Public openextention As String
    Public openingprogram As String
    Dim lastselectedfilename As String

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()

        ShiftOSDesktop.pnlpanelbuttonfileopener.SendToBack()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonfileopener, ShiftOSDesktop.tbfileopenericon, ShiftOSDesktop.tbfileopenertext, True)
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        If ShiftOSDesktop.fileopenerlastdirectory = "" Then
            'open default directory
        Else
            lbllocation.Text = ShiftOSDesktop.fileopenerlastdirectory
        End If
        lbextention.Text = openextention
        showcontents()
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Make terminal appear
        If e.KeyCode = Keys.T AndAlso e.Control Then
            Terminal.Show()
            Terminal.Visible = True
            Terminal.BringToFront()
        End If

        'Movable Windows
        If ShiftOSDesktop.boughtmovablewindows = True Then
            If e.KeyCode = Keys.A AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X - ShiftOSDesktop.movablewindownumber, Me.Location.Y)
            End If
            If e.KeyCode = Keys.D AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X + ShiftOSDesktop.movablewindownumber, Me.Location.Y)
            End If
            If e.KeyCode = Keys.W AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y - ShiftOSDesktop.movablewindownumber)
            End If
            If e.KeyCode = Keys.S AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y + ShiftOSDesktop.movablewindownumber)
            End If
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User moved " & Me.Name & " to " & Me.Location.ToString & " with " & e.KeyCode.ToString & Environment.NewLine
        End If
    End Sub

    Private Sub titlebar_MouseDown(sender As Object, e As MouseEventArgs) Handles titlebar.MouseDown, lbtitletext.MouseDown, pnlicon.MouseDown, pgtoplcorner.MouseDown, pgtoprcorner.MouseDown
        ' Handle Draggable Windows
        If ShiftOSDesktop.boughtdraggablewindows = True Then
            If e.Button = MouseButtons.Left Then
                titlebar.Capture = False
                lbtitletext.Capture = False
                pnlicon.Capture = False
                pgtoplcorner.Capture = False
                pgtoprcorner.Capture = False
                Const WM_NCLBUTTONDOWN As Integer = &HA1S
                Const HTCAPTION As Integer = 2
                Dim msg As Message = _
                    Message.Create(Me.Handle, WM_NCLBUTTONDOWN, _
                        New IntPtr(HTCAPTION), IntPtr.Zero)
                Me.DefWndProc(msg)
            End If
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User dragged " & Me.Name & " to " & Me.Location.ToString & Environment.NewLine
        End If
    End Sub

    Public Sub setupborders()
        If ShiftOSDesktop.boughtwindowborders = False Then
            pgleft.Hide()
            pgbottom.Hide()
            pgright.Hide()
            Me.Size = New Size(Me.Width - pgleft.Width - pgright.Width, Me.Height - pgbottom.Height)
        End If
    End Sub

    Private Sub closebutton_Click(sender As Object, e As EventArgs) Handles closebutton.Click
        Me.Close()
    End Sub

    Private Sub closebutton_MouseEnter(sender As Object, e As EventArgs) Handles closebutton.MouseEnter, closebutton.MouseUp
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(1)
    End Sub

    Private Sub closebutton_MouseLeave(sender As Object, e As EventArgs) Handles closebutton.MouseLeave
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(0)
    End Sub

    Private Sub closebutton_MouseDown(sender As Object, e As EventArgs) Handles closebutton.MouseDown
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(2)
    End Sub

    Private Sub minimizebutton_Click(sender As Object, e As EventArgs) Handles minimizebutton.Click
        ShiftOSDesktop.minimizeprogram(Me)
    End Sub

    Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
        If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    End Sub

    Private Sub titlebar_MouseLeave(sender As Object, e As EventArgs) Handles titlebar.MouseLeave, lbtitletext.MouseLeave, pnlicon.MouseLeave, closebutton.MouseLeave, rollupbutton.MouseLeave
        If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0)
    End Sub

    Private Sub rollupbutton_Click(sender As Object, e As EventArgs) Handles rollupbutton.Click
        rollupanddown()
    End Sub

    Private Sub rollupbutton_MouseEnter(sender As Object, e As EventArgs) Handles rollupbutton.MouseEnter, rollupbutton.MouseUp
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(1)
    End Sub

    Private Sub rollupbutton_MouseLeave(sender As Object, e As EventArgs) Handles rollupbutton.MouseLeave
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(0)
    End Sub

    Private Sub rollupbutton_MouseDown(sender As Object, e As EventArgs) Handles rollupbutton.MouseDown
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(2)
    End Sub

    Public Sub setuptitlebar()

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = ShiftOSDesktop.windowbordersize
        pgright.Width = ShiftOSDesktop.windowbordersize
        pgbottom.Height = ShiftOSDesktop.windowbordersize
        titlebar.Height = ShiftOSDesktop.titlebarheight

        If justopened = True Then
            Me.Size = New Size(600, 377) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
            Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
            oldbordersize = ShiftOSDesktop.windowbordersize
            oldtitlebarheight = ShiftOSDesktop.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                Me.Hide()
                Me.Size = New Size(Me.Width, Me.Height - oldtitlebarheight + 30)
                Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize)
                oldbordersize = ShiftOSDesktop.windowbordersize
                oldtitlebarheight = ShiftOSDesktop.titlebarheight
                Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
                Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
                rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                Me.Show()
            End If
        End If

        If ShiftOSDesktop.showwindowcorners = True Then
            pgtoplcorner.Show()
            pgtoprcorner.Show()
            pgtoprcorner.Width = ShiftOSDesktop.titlebarcornerwidth
            pgtoplcorner.Width = ShiftOSDesktop.titlebarcornerwidth
        Else
            pgtoplcorner.Hide()
            pgtoprcorner.Hide()
        End If

        If ShiftOSDesktop.boughttitlebar = False Then
            titlebar.Hide()
            Me.Size = New Size(Me.Width, Me.Size.Height - titlebar.Height)
        End If

        If ShiftOSDesktop.boughttitletext = False Then
            lbtitletext.Hide()
        Else
            lbtitletext.Font = New Font(ShiftOSDesktop.titletextfont, ShiftOSDesktop.titletextsize, ShiftOSDesktop.titletextstyle)
            lbtitletext.Text = ShiftOSDesktop.fileopenername
            lbtitletext.Show()
        End If

        If ShiftOSDesktop.boughtclosebutton = False Then
            closebutton.Hide()
        Else
            closebutton.BackColor = ShiftOSDesktop.closebuttoncolour
            closebutton.Height = ShiftOSDesktop.closebuttonheight
            closebutton.Width = ShiftOSDesktop.closebuttonwidth
            closebutton.Show()
        End If

        If ShiftOSDesktop.boughtrollupbutton = False Then
            rollupbutton.Hide()
        Else
            rollupbutton.BackColor = ShiftOSDesktop.rollupbuttoncolour
            rollupbutton.Height = ShiftOSDesktop.rollupbuttonheight
            rollupbutton.Width = ShiftOSDesktop.rollupbuttonwidth
            rollupbutton.Show()
        End If

        If ShiftOSDesktop.boughtminimizebutton = False Then
            minimizebutton.Hide()
        Else
            minimizebutton.BackColor = ShiftOSDesktop.minimizebuttoncolour
            minimizebutton.Height = ShiftOSDesktop.minimizebuttonheight
            minimizebutton.Width = ShiftOSDesktop.minimizebuttonwidth
            minimizebutton.Show()
        End If

        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside + pgtoplcorner.Width, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        End If

        If ShiftOSDesktop.boughtfileskimmericon = True Then
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.fileopenericontitlebar 'Replace with the correct icon for the program.
        End If

    End Sub

    Public Sub rollupanddown()
        If Me.Height = Me.titlebar.Height Then
            pgleft.Show()
            pgbottom.Show()
            pgright.Show()
            Me.Height = rolldownsize
            Me.MinimumSize = New Size(minimumsizewidth, minimumsizeheight)
        Else
            Me.MinimumSize = New Size(0, 0)
            pgleft.Hide()
            pgbottom.Hide()
            pgright.Hide()
            rolldownsize = Me.Height
            Me.Height = Me.titlebar.Height
        End If
    End Sub

    Private Sub resettitlebar()
        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside + pgtoplcorner.Width, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        End If
    End Sub

    Private Sub pullside_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pullside.Tick
        Me.Width = Cursor.Position.X - Me.Location.X
        resettitlebar()
    End Sub

    Private Sub pullbottom_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pullbottom.Tick
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub pullbs_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pullbs.Tick
        Me.Width = Cursor.Position.X - Me.Location.X
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub Rightpull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgright.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullside.Start()
        End If
    End Sub

    Private Sub RightCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgright.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeWE
        End If
    End Sub

    Private Sub bottomCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgbottom.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeNS
        End If
    End Sub

    Private Sub CornerCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgbottomrcorner.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeNWSE
        End If
    End Sub

    Private Sub SizeCursoroff_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgright.MouseLeave, pgbottom.MouseLeave, pgbottomrcorner.MouseLeave
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub rightpull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgright.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullside.Stop()
        End If
    End Sub

    Private Sub bottompull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottom.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbottom.Start()
        End If
    End Sub

    Private Sub buttompull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottom.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbottom.Stop()
        End If
    End Sub

    Private Sub bspull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottomrcorner.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbs.Start()
        End If
    End Sub

    Private Sub bspull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottomrcorner.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbs.Stop()
        End If
    End Sub

    Public Sub setskin()
        If ShiftOSDesktop.skinclosebutton(0) Is Nothing Then  Else closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(0).Clone
        closebutton.BackgroundImageLayout = ShiftOSDesktop.skinclosebuttonstyle
        If ShiftOSDesktop.skintitlebar(0) Is Nothing Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0).Clone
        titlebar.BackgroundImageLayout = ShiftOSDesktop.skintitlebarstyle
        If ShiftOSDesktop.skinrollupbutton(0) Is Nothing Then  Else rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(0).Clone
        rollupbutton.BackgroundImageLayout = ShiftOSDesktop.skinrollupbuttonstyle
        If ShiftOSDesktop.skintitlebarleftcorner(0) Is Nothing Then  Else pgtoplcorner.BackgroundImage = ShiftOSDesktop.skintitlebarleftcorner(0).Clone
        pgtoplcorner.BackgroundImageLayout = ShiftOSDesktop.skintitlebarleftcornerstyle
        If ShiftOSDesktop.skintitlebarrightcorner(0) Is Nothing Then  Else pgtoprcorner.BackgroundImage = ShiftOSDesktop.skintitlebarrightcorner(0).Clone
        pgtoprcorner.BackgroundImageLayout = ShiftOSDesktop.skintitlebarrightcornerstyle
        If ShiftOSDesktop.skinminimizebutton(0) Is Nothing Then  Else minimizebutton.BackgroundImage = ShiftOSDesktop.skinminimizebutton(0).Clone
        minimizebutton.BackgroundImageLayout = ShiftOSDesktop.skinminimizebuttonstyle

        'remove background colour when image is present
        If closebutton.BackgroundImage Is Nothing Then  Else closebutton.BackColor = Color.Transparent
        If titlebar.BackgroundImage Is Nothing Then  Else titlebar.BackColor = Color.Transparent
        If rollupbutton.BackgroundImage Is Nothing Then  Else rollupbutton.BackColor = Color.Transparent
        If pgtoplcorner.BackgroundImage Is Nothing Then  Else pgtoplcorner.BackColor = Color.Transparent
        If pgtoprcorner.BackgroundImage Is Nothing Then  Else pgtoprcorner.BackColor = Color.Transparent
        If minimizebutton.BackgroundImage Is Nothing Then  Else minimizebutton.BackColor = Color.Transparent

        Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour
    End Sub

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
        Me.Hide()
        ShiftOSDesktop.setuppanelbuttons()
    End Sub

    'end of general setup

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showcontents()
    End Sub

    Public Sub showcontents()
        lvfiles.Items.Clear()

        lvfiles.Items.Add("Exit Folder", 5)

        Dim dir As New DirectoryInfo(lbllocation.Text)
        Dim files As FileInfo() = dir.GetFiles()
        Dim file As FileInfo
        Dim folders As DirectoryInfo() = dir.GetDirectories()
        Dim folder As DirectoryInfo

        For Each folder In folders
            Dim foldername As String = folder.Name
            lvfiles.Items.Add(foldername, 0)
        Next

        For Each file In files
            Dim filename As String = file.Name
            Dim fileex As String = file.Extension

            Select Case fileex
                Case ".txt"
                    filetype = 2
                Case ".doc"
                    filetype = 2
                Case ".docx"
                    filetype = 2
                Case ".lst"
                    filetype = 2
                Case ".png"
                    filetype = 3
                Case ".jpg"
                    filetype = 3
                Case ".jpeg"
                    filetype = 3
                Case ".bmp"
                    filetype = 3
                Case ".gif"
                    filetype = 3
                Case ".avi"
                    filetype = 4
                Case ".m4v"
                    filetype = 4
                Case ".mp4"
                    filetype = 4
                Case ".wmv"
                    filetype = 4
                Case ".dll"
                    filetype = 6
                Case ".exe"
                    filetype = 7
                Case ".sft"
                    filetype = 8
                Case ".dri"
                    filetype = 9
                Case ".pic"
                    filetype = 3
                Case ".skn"
                    filetype = 10
                Case ".nls"
                    filetype = 11
                Case ".icp"
                    filetype = 12
                Case Else
                    filetype = 1
            End Select

            Select Case openingprogram
                Case "textpad"
                    If fileex = ".txt" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "graphicpicker1", "graphicpicker2", "graphicpicker3"
                    If fileex = ".pic" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".gif" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".jpeg" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".png" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".jpg" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".tiff" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".bmp" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "skinloader"
                    If fileex = ".skn" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "artpad"
                    If fileex = ".pic" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "audioplayer"
                    If fileex = ".mp3" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".wav" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".mwa" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".midi" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "videoplayer"
                    If fileex = ".mp4" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".avi" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".wmv" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".mov" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".m4v" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".mpeg4" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".mkv" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "namechanger"
                    If fileex = ".nls" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "iconmanager"
                    If fileex = ".pic" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".gif" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".jpeg" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".png" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".jpg" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".tiff" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                    If fileex = ".bmp" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "iconmanagerpack"
                    If fileex = ".icp" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
                Case "skinshifter"
                    If fileex = ".skn" Then
                        lvfiles.Items.Add(filename, filetype)
                    End If
            End Select
        Next

        ShiftOSDesktop.fileopenerlastdirectory = lbllocation.Text
    End Sub

    Private Sub lvfiles_MouseClick(sender As Object, e As MouseEventArgs) Handles lvfiles.MouseClick
        lastselectedfilename = lvfiles.SelectedItems(0).Text
    End Sub

    Private Sub lbfiles_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvfiles.MouseDoubleClick

        If lvfiles.SelectedItems(0).Text = "Exit Folder" Then

            If lbllocation.Text = "C:/ShiftOS/" Then
                infobox.title = "File Skimmer - Warning!"
                infobox.textinfo = "Unable to move into a higher directory due to error reading the requested folder on the drive." & Environment.NewLine & Environment.NewLine & "You can only enter directories formatted in the ShiftOS file system (ShiftFS)"
                infobox.Show()
            Else
                Dim endloop As Boolean = False
                lbllocation.Text = lbllocation.Text.Substring(0, lbllocation.Text.Length - 1)

                While endloop = False
                    If lbllocation.Text.Substring(lbllocation.Text.Length - 1) = "/" Then
                        endloop = True
                    Else
                        lbllocation.Text = lbllocation.Text.Substring(0, lbllocation.Text.Length - 1)
                    End If
                End While
                showcontents()
            End If
        Else
            'Check if selected item is a file or folder. It it's a folder check its extension
            If lvfiles.SelectedItems(0).Text Like "*.txt" Then
                openfile()
            ElseIf lvfiles.SelectedItems(0).Text Like "*.skn" Then
                openfile()
            ElseIf lvfiles.SelectedItems(0).Text Like "*.gra" Then
                openfile()
            ElseIf lvfiles.SelectedItems(0).Text Like "*.*" Then
                openfile()
            Else
                Dim textboxtext As String
                textboxtext = lbllocation.Text
                Dim last As String
                Dim selit As String
                last = textboxtext.Substring(textboxtext.Length - 1)
                If last = "/" Then
                    selit = lvfiles.SelectedItems(0).Text
                    lbllocation.Text = lbllocation.Text + selit
                Else
                    selit = lvfiles.SelectedItems(0).Text
                    lbllocation.Text = lbllocation.Text + ("/" & selit)
                End If
                showcontents()
            End If
        End If
    End Sub

    Private Sub btndeletefile_Click(sender As Object, e As EventArgs)
        If lvfiles.SelectedItems(0).Text Like "*.*" Then
            My.Computer.FileSystem.DeleteFile(lbllocation.Text & "/" & lvfiles.SelectedItems(0).Text)
            My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            showcontents()
        Else
            My.Computer.FileSystem.DeleteDirectory(lbllocation.Text & "/" & lvfiles.SelectedItems(0).Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            showcontents()
        End If
    End Sub

    Private Sub btnnewfolder_Click(sender As Object, e As EventArgs)
        infobox.lblintructtext.Text = "Please enter a name for your new folder:"
        infobox.txtuserinput.Text = ""
        infobox.lblintructtext.Show()
        infobox.txtuserinput.Show()
        infobox.Show()
        scaninput.Start()
    End Sub

    Private Sub scaninput_Tick(sender As Object, e As EventArgs) Handles scaninput.Tick
        If infobox.Visible = False Then
            My.Computer.FileSystem.CreateDirectory(lbllocation.Text & "/" & infobox.txtuserinput.Text)
            showcontents()
            scaninput.Stop()
        End If
    End Sub

    Private Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        openfile()
    End Sub

    Private Sub openfile()
        If lastselectedfilename = "" Then
        Else
            Select Case openingprogram
                Case "textpad"
                    If TextPad.needtosave = False Then
                        TextPad.Show()
                        TextPad.txtuserinput.Text = My.Computer.FileSystem.ReadAllText(lbllocation.Text & "/" & lvfiles.SelectedItems(0).Text)
                        TextPad.needtosave = False
                        Me.Close()
                    Else
                        infobox.title = "Textpad - Save?"
                        infobox.textinfo = "It appears that your text document currently contains unsaved changes." & Environment.NewLine & Environment.NewLine & "Are you sure you want to load a file without saving the changes?"
                        infobox.Show()
                        infobox.showyesno()
                        infobox.sendyesno = "fileopenertextpad"
                    End If
                Case "graphicpicker1"
                    Graphic_Picker.imagelocations(0) = (lbllocation.Text & "/" & lastselectedfilename)
                    Graphic_Picker.txtidlefile.Text = lastselectedfilename
                    Graphic_Picker.setgraphicsidle()
                    Me.Close()
                Case "graphicpicker2"
                    Graphic_Picker.imagelocations(1) = (lbllocation.Text & "/" & lastselectedfilename)
                    Graphic_Picker.txtmouseoverfile.Text = lastselectedfilename
                    Graphic_Picker.setgraphicsmouseover()
                    Me.Close()
                Case "graphicpicker3"
                    Graphic_Picker.imagelocations(2) = (lbllocation.Text & "/" & lastselectedfilename)
                    Graphic_Picker.txtmousedownfile.Text = lastselectedfilename
                    Graphic_Picker.setgraphicsmousedown()
                    Me.Close()
                Case "skinloader"
                    ShiftOSDesktop.disposeoldskindata("skinloaderemovepreview")
                    If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Preview\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\Preview\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    System.IO.Compression.ZipFile.ExtractToDirectory(lbllocation.Text & "\" & lastselectedfilename, "C:\ShiftOS\Shiftum42\Skins\Preview\")
                    My.Computer.FileSystem.WriteAllText("C:\ShiftOS\Shiftum42\Skins\Preview\skindata.dat", My.Computer.FileSystem.ReadAllText("C:\ShiftOS\Shiftum42\Skins\Preview\skindata.dat").Replace("\Current", "\Preview"), False)
                    Skin_Loader.loadlines = IO.File.ReadAllLines("C:\ShiftOS\Shiftum42\Skins\Preview\skindata.dat")
                    Skin_Loader.loadskintopreview()
                    Skin_Loader.skinloaded = True
                    Me.Close()
                Case "artpad"
                    ArtPad.savelocation = (lbllocation.Text & "/" & lastselectedfilename)
                    ArtPad.openpic()
                    Me.Close()
                Case "audioplayer"
                    Audio_Player.lbmusiclist.Items.Add(lbllocation.Text & "/" & lastselectedfilename)
                    Me.Close()
                Case "videoplayer"
                    Video_Player.AxWindowsMediaPlayer1.URL = (lbllocation.Text & "/" & lastselectedfilename)
                    Me.Close()
                Case "namechanger"
                    Name_Changer.loadlines = IO.File.ReadAllLines(lbllocation.Text & "/" & lvfiles.SelectedItems(0).Text)
                    Name_Changer.loadnamesfromfile()
                    Me.Close()
                Case "iconmanager"
                    Icon_Manager.openedfilelocation = (lbllocation.Text & "/" & lastselectedfilename)
                    Icon_Manager.loadicon()
                    Me.Close()
                Case "iconmanagerpack"
                    Icon_Manager.disposebackgrounds()
                    If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Icons") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Icons", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    System.IO.Compression.ZipFile.ExtractToDirectory(lbllocation.Text & "\" & lastselectedfilename, "C:\ShiftOS\Shiftum42\Icons")
                    ShiftOSDesktop.setupicons()
                    Icon_Manager.needtosetupdesktop = True
                    Icon_Manager.loadsettings()
                    Me.Close()
                Case "skinshifter"
                    Skinshifter.lbskinlist.Items.Add(lbllocation.Text & "/" & lastselectedfilename)
                    Me.Close()
            End Select
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class