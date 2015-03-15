Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms

Public Class File_Saver
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 400
    Public minimumsizeheight As Integer = 177
    Public ShiftOSPath As String = "C:\ShiftOS\"

    Dim itemsdeleted As Integer
    Dim filetype As Integer
    Public saveextention As String = ".txt"
    Public savingprogram As String = "textpad"

    Public useformatchooser As Boolean = False
    Public nondefaultextention(4) As String 'If this is not enough add more, just update the item adding below

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()

        showcontents()

        lbextention.Text = saveextention
        showcontents()
        If useformatchooser = True Then
            cmbformatchooser.BringToFront()
            cmbformatchooser.Show()
            cmbformatchooser.Items.Clear()
            cmbformatchooser.Items.Add(saveextention)
            If Not nondefaultextention(0) = "" Then cmbformatchooser.Items.Add(nondefaultextention(0))
            If Not nondefaultextention(1) = "" Then cmbformatchooser.Items.Add(nondefaultextention(1))
            If Not nondefaultextention(2) = "" Then cmbformatchooser.Items.Add(nondefaultextention(2))
            If Not nondefaultextention(3) = "" Then cmbformatchooser.Items.Add(nondefaultextention(3))
            If Not nondefaultextention(4) = "" Then cmbformatchooser.Items.Add(nondefaultextention(4))
            cmbformatchooser.SelectedIndex = 0
        Else
            cmbformatchooser.Hide()
        End If

        ShiftOSDesktop.pnlpanelbuttonfilesaver.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonfilesaver, ShiftOSDesktop.tbfilesavericon, ShiftOSDesktop.tbfilesavertext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1
    End Sub

    Public Sub setupall()
        setuptitlebar()
        setupborders()
        setskin()
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        closebutton.BackgroundImage = Skins.closebtnhover
    End Sub

    Private Sub closebutton_MouseLeave(sender As Object, e As EventArgs) Handles closebutton.MouseLeave
        closebutton.BackgroundImage = Skins.closebtn
    End Sub

    Private Sub closebutton_MouseDown(sender As Object, e As EventArgs) Handles closebutton.MouseDown
        closebutton.BackgroundImage = Skins.closebtnclick
    End Sub

    Private Sub minimizebutton_Click(sender As Object, e As EventArgs) Handles minimizebutton.Click
        ShiftOSDesktop.minimizeprogram(Me, False)
    End Sub

    'Old skinning system - No idea what this does
    ''Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
    ''    If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    ''End Sub

    'Private Sub titlebar_MouseLeave(sender As Object, e As EventArgs) Handles titlebar.MouseLeave, lbtitletext.MouseLeave, pnlicon.MouseLeave, closebutton.MouseLeave, rollupbutton.MouseLeave
    '    If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0)
    'End Sub

    Private Sub rollupbutton_Click(sender As Object, e As EventArgs) Handles rollupbutton.Click
        rollupanddown()
    End Sub

    Private Sub rollupbutton_MouseEnter(sender As Object, e As EventArgs) Handles rollupbutton.MouseEnter, rollupbutton.MouseUp
        rollupbutton.BackgroundImage = Skins.rollbtnhover
    End Sub

    Private Sub rollupbutton_MouseLeave(sender As Object, e As EventArgs) Handles rollupbutton.MouseLeave
        rollupbutton.BackgroundImage = Skins.rollbtn
    End Sub

    Private Sub rollupbutton_MouseDown(sender As Object, e As EventArgs) Handles rollupbutton.MouseDown
        rollupbutton.BackgroundImage = Skins.rollbtnclick
    End Sub

    Public Sub setuptitlebar()

        setupborders()

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = Skins.borderwidth
        pgright.Width = Skins.borderwidth
        pgbottom.Height = Skins.borderwidth
        titlebar.Height = Skins.titlebarheight

        If justopened = True Then
            Me.Size = New Size(600, 377) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
            Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
            oldbordersize = Skins.borderwidth
            oldtitlebarheight = Skins.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                'Me.Hide()
                Me.Size = New Size(Me.Width - (2 * oldbordersize) + (2 * Skins.borderwidth), (Me.Height - oldtitlebarheight - oldbordersize) + Skins.titlebarheight + Skins.borderwidth)
                'Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize) 'Just put a little algebra in the first size setting and comment out the mess
                oldbordersize = Skins.borderwidth
                oldtitlebarheight = Skins.titlebarheight
                'Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
                'Me.Size = New Size(Me.Width + Skins. borderwidth + Skins. borderwidth, Me.Height + Skins. borderwidth)
                'rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                'Me.Show()
            End If
        End If

        If Skins.enablecorners = True Then
            pgtoplcorner.Show()
            pgtoprcorner.Show()
            pgtoprcorner.Width = Skins.titlebarcornerwidth
            pgtoplcorner.Width = Skins.titlebarcornerwidth
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
            lbtitletext.Font = New Font(Skins.titletextfontfamily, Skins.titletextfontsize, Skins.titletextfontstyle, GraphicsUnit.Point)
            lbtitletext.Text = ShiftOSDesktop.filesavername 'Remember to change to name of program!!!!
            lbtitletext.Show()
        End If

        If ShiftOSDesktop.boughtclosebutton = False Then
            closebutton.Hide()
        Else
            closebutton.BackColor = Skins.closebtncolour
            closebutton.Size = Skins.closebtnsize
            closebutton.Show()
        End If

        If ShiftOSDesktop.boughtrollupbutton = False Then
            rollupbutton.Hide()
        Else
            rollupbutton.BackColor = Skins.rollbtncolour
            rollupbutton.Size = Skins.rollbtnsize
            rollupbutton.Show()
        End If

        If ShiftOSDesktop.boughtminimizebutton = False Then
            minimizebutton.Hide()
        Else
            minimizebutton.BackColor = Skins.minbtncolour
            minimizebutton.Size = Skins.minbtnsize
            minimizebutton.Show()
        End If

        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - closebutton.Size.Width, Skins.closebtnfromtop)
            rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - rollupbutton.Size.Width, Skins.rollbtnfromtop)
            minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, Skins.closebtnfromtop)
            rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, Skins.rollbtnfromtop)
            minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside + pgtoplcorner.Width, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
        End If

        'Change when Icon skinning complete
        If ShiftOSDesktop.boughtfileskimmericon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.filesavericontitlebar  'Replace with the correct icon for the program.
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

    Public Sub resettitlebar()
        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - closebutton.Size.Width, Skins.closebtnfromtop)
            rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - rollupbutton.Size.Width, Skins.rollbtnfromtop)
            minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, Skins.closebtnfromtop)
            rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, Skins.rollbtnfromtop)
            minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside + pgtoplcorner.Width, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
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

    'delete this for non-resizable windows
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
        'disposals
        closebutton.BackgroundImage = Nothing
        titlebar.BackgroundImage = Nothing
        rollupbutton.BackgroundImage = Nothing
        pgtoplcorner.BackgroundImage = Nothing
        pgtoprcorner.BackgroundImage = Nothing
        minimizebutton.BackgroundImage = Nothing
        'apply new skin
        If Skins.closebtn Is Nothing Then closebutton.BackColor = Skins.closebtncolour Else closebutton.BackgroundImage = Skins.closebtn
        closebutton.BackgroundImageLayout = Skins.closebtnlayout
        If Skins.titlebar Is Nothing Then titlebar.BackColor = Skins.titlebarcolour Else titlebar.BackgroundImage = Skins.titlebar
        titlebar.BackgroundImageLayout = Skins.titlebarlayout
        If Skins.rollbtn Is Nothing Then rollupbutton.BackColor = Skins.rollbtncolour Else rollupbutton.BackgroundImage = Skins.rollbtn
        rollupbutton.BackgroundImageLayout = Skins.rollbtnlayout
        If Skins.leftcorner Is Nothing Then pgtoplcorner.BackColor = Skins.leftcornercolour Else pgtoplcorner.BackgroundImage = Skins.leftcorner
        pgtoplcorner.BackgroundImageLayout = Skins.leftcornerlayout
        If Skins.rightcorner Is Nothing Then pgtoprcorner.BackColor = Skins.rightcornercolour Else pgtoprcorner.BackgroundImage = Skins.rightcorner
        pgtoprcorner.BackgroundImageLayout = Skins.rightcornerlayout
        If Skins.minbtn Is Nothing Then minimizebutton.BackColor = Skins.minbtncolour Else minimizebutton.BackgroundImage = Skins.minbtn
        minimizebutton.BackgroundImageLayout = Skins.minbtnlayout
        If Skins.borderleft Is Nothing Then pgleft.BackColor = Skins.borderleftcolour Else pgleft.BackgroundImage = Skins.borderleft
        pgleft.BackgroundImageLayout = Skins.borderleftlayout
        If Skins.borderright Is Nothing Then pgright.BackColor = Skins.borderrightcolour Else pgright.BackgroundImage = Skins.borderright
        pgleft.BackgroundImageLayout = Skins.borderrightlayout
        If Skins.borderbottom Is Nothing Then pgbottom.BackColor = Skins.borderbottomcolour Else pgbottom.BackgroundImage = Skins.borderbottom
        pgbottom.BackgroundImageLayout = Skins.borderbottomlayout
        If enablebordercorners = True Then
            If Skins.bottomleftcorner Is Nothing Then pgbottomlcorner.BackColor = Skins.bottomleftcornercolour Else pgbottomlcorner.BackgroundImage = Skins.bottomleftcorner
            pgbottomlcorner.BackgroundImageLayout = Skins.bottomleftcornerlayout
            If Skins.bottomrightcorner Is Nothing Then pgbottomrcorner.BackColor = Skins.bottomrightcornercolour Else pgbottomrcorner.BackgroundImage = Skins.bottomrightcorner
            pgbottomrcorner.BackgroundImageLayout = Skins.bottomrightcornerlayout
        Else
            pgbottomlcorner.BackColor = Skins.borderrightcolour
            pgbottomrcorner.BackColor = Skins.borderrightcolour
            pgbottomlcorner.BackgroundImage = Nothing
            pgbottomrcorner.BackgroundImage = Nothing
        End If

        'set bottom border corner size
        pgbottomlcorner.Size = New Size(Skins.borderwidth, Skins.borderwidth)
        pgbottomrcorner.Size = New Size(Skins.borderwidth, Skins.borderwidth)
        pgbottomlcorner.Location = New Point(0, Me.Height - Skins.borderwidth)
        pgbottomrcorner.Location = New Point(Me.Width, Me.Height - Skins.borderwidth)

        Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour
    End Sub

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
        Me.Hide()
        ShiftOSDesktop.setuppanelbuttons()
    End Sub

    'end of general setup
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showcontents()
    End Sub

    Private Sub showcontents()
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
                Case ".mp3"
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
                Case ".stp"
                    filetype = 13
                Case ".trm"
                    filetype = 14
                Case ".sh"
                    filetype = 14
                Case ".bat"
                    filetype = 14
                Case ".command"
                    filetype = 14
                Case ".saa"
                    filetype = 15
                Case ".flood"
                    filetype = 16
                Case ".url"
                    filetype = 17
                Case ".urls"
                    filetype = 18
                Case Else
                    filetype = 1
            End Select

            Select Case savingprogram
                Case "textpad", "sysinf"
                    If fileex = ".txt" Then lvfiles.Items.Add(filename, filetype)
                Case "skinloader"
                    If fileex = ".skn" Then lvfiles.Items.Add(filename, filetype)
                Case "artpad"
                    If fileex = ".pic" Then lvfiles.Items.Add(filename, filetype)
                Case "namechanger"
                    If fileex = ".nls" Then lvfiles.Items.Add(filename, filetype)
                Case "orcwrite"
                    If fileex = ".owd" Then lvfiles.Items.Add(filename, filetype)
            End Select
        Next

        ShiftOSDesktop.fileopenerlastdirectory = lbllocation.Text
    End Sub

    Private Sub lvfiles_MouseClick(sender As Object, e As MouseEventArgs) Handles lvfiles.MouseClick
        'need to remove the file extention!
        If lvfiles.SelectedItems(0).Text.Contains(".") Then
            txtfilename.Text = lvfiles.SelectedItems(0).Text.Substring(0, lvfiles.SelectedItems(0).Text.Length - 4)
        End If
    End Sub

    Private Sub lbfiles_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvfiles.MouseDoubleClick
        If lvfiles.SelectedItems(0).Text.Contains(".") Then
            savefile()
        Else
            If lvfiles.SelectedItems(0).Text = "Exit Folder" Then
                If lbllocation.Text = "C:/ShiftOS/" Or lbllocation.Text = "C:/ShiftOS" Then
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

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If lbllocation.Text = "C:/ShiftOS/Home/Desktop" Then
            ShiftOSDesktop.RefreshIcons()
        End If
        savefile()
    End Sub

    Dim filename As String
    Private Sub savefile()
        If useformatchooser = True Then
            filename = txtfilename.Text & cmbformatchooser.SelectedItem.ToString
        Else
            filename = txtfilename.Text & saveextention
        End If
        If txtfilename.Text = "" Then
        Else
            Select Case savingprogram
                Case "sysinf"
                    Dim sw As New IO.StreamWriter(lbllocation.Text & "/" & txtfilename.Text & ".txt")
                    sw.WriteLine("### SHIFTOS SYSTEM INFORMATION DUMP ###")
                    sw.WriteLine(" ")
                    sw.WriteLine("ShiftOS Version: " & ShiftOSDesktop.ingameversion)
                    sw.WriteLine("User Name: " & ShiftOSDesktop.username)
                    Dim PrcName As String

                    PrcName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", Nothing)
                    sw.WriteLine("CPU: " & PrcName)
                    sw.WriteLine("Random Access Memory (RAM): " & (String.Format("{0} Megabytes", System.Math.Round(My.Computer.Info.TotalPhysicalMemory / (1024 * 1024)), 2).ToString))
                    sw.Close()
                    Me.Close()
                    ShiftOSDesktop.refreshIcons()
                Case "textpad"
                    My.Computer.FileSystem.WriteAllText(lbllocation.Text & "/" & filename, TextPad.txtuserinput.Text, False)
                    TextPad.needtosave = False
                    ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + TextPad.codepointsearned
                    If ShiftOSDesktop.boughttitletext = True Then
                        TextPad.lbtitletext.Text = TextPad.lbtitletext.Text & " - You earned " & TextPad.codepointsearned & " codepoints!"
                        TextPad.setuptitlebar()
                    Else
                        infobox.title = "Textpad - " & TextPad.codepointsearned & " codepoints!"
                        infobox.textinfo = "Awesome! That document you just created with Textpad has earned you " & TextPad.codepointsearned & " codepoints! " & Environment.NewLine & Environment.NewLine & "Keep those docs coming for even more codepoints!"
                        infobox.Show()
                    End If
                    TextPad.codepointsearned = 0
                    TextPad.tmrshowearnedcodepoints.Start()
                Case "skinloader"
                    Skins.saveskin(lbllocation.Text & " / " & filename)
                Case "iconmanager"
                    System.IO.Compression.ZipFile.CreateFromDirectory(ShiftOSPath + "Shiftum42\Icons", lbllocation.Text & " / " & filename)
                    Icon_Manager.unsavedchanges = False
                Case "namechanger"
                    IO.File.WriteAllLines(lbllocation.Text & "/" & filename, Name_Changer.savelines)
                Case "artpad"
                    ArtPad.savelocation = lbllocation.Text & "/" & filename
                    ArtPad.saveimage()
                    ArtPad.canvasbitmap.Save("C:\ShiftOS\SoftwareData\AdvStart\Recent\" & txtfilename.Text & ".pic", Imaging.ImageFormat.Bmp)
                    ArtPad.needtosave = False
                    ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + ArtPad.codepointsearned
                    If ShiftOSDesktop.boughttitletext = True Then
                        ArtPad.lbtitletext.Text = ArtPad.lbtitletext.Text & " - You earned " & ArtPad.codepointsearned & " codepoints!"
                        ArtPad.setuptitlebar()
                    Else
                        infobox.title = "Artpad - " & ArtPad.codepointsearned & " codepoints!"
                        infobox.textinfo = "Awesome! That picture you just created with Artpad has earned you " & ArtPad.codepointsearned & " codepoints! " & Environment.NewLine & Environment.NewLine & "Keep those artworks coming for even more codepoints!"
                        infobox.Show()
                    End If
                    ArtPad.codepointsearned = 0
                    ArtPad.tmrshowearnedcodepoints.Start()
                Case "orcwrite"
                    OrcWrite.savepath = lbllocation.Text & "/" & filename
                    OrcWrite.savedocument()
                    Dim sw As New IO.StreamWriter("C:\ShiftOS\SoftwareData\AdvStart\Recent\" & txtfilename.Text + ".owd")
                    sw.Write(OrcWrite.RichTextBox1.Rtf)
                    sw.Close()
            End Select
            Me.Close()
        End If
    End Sub
End Class