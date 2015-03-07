Public Class Knowledge_Input
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Dim guessalreadydone As Boolean
    Dim guesscorrect As Boolean
    Dim levelup As Boolean
    Dim rewardbase As Integer
    Dim savecontent() As String

    Dim totalguessed As Integer
    Dim level As Integer
    Dim tillnextlevel As Integer

    Dim animalslist(226) As String
    Dim fruitslist(75) As String
    Dim countrieslist(232) As String
    Dim carbrandslist(328) As String
    Dim gameconsoleslist(124) As String
    Dim elementslist(117) As String


    Private Sub Knowledge_Input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        pnlcategorydisplay.Hide()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()

        ShiftOSDesktop.pnlpanelbuttonknowledgeinput.SendToBack()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonknowledgeinput, ShiftOSDesktop.tbknowledgeinputicon, ShiftOSDesktop.tbknowledgeinputtext, True)
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        level = 1
        tillnextlevel = 10
        makeanimallist()
        makefruitlist()
        makecountrieslist()
        makecarbrandslist()
        makegameconsoleslist()
        makeelementslist()

        If ShiftOSDesktop.boughtkicarbrands = True Then
            If ListBox1.Items.Contains("Car Brands") Then
            Else
                ListBox1.Items.Add("Car Brands")
            End If
        End If

        If ShiftOSDesktop.boughtkigameconsoles = True Then
            If ListBox1.Items.Contains("Game Consoles") Then
            Else
                ListBox1.Items.Add("Game Consoles")
            End If
        End If

        If ShiftOSDesktop.boughtkielements = True Then
            If ListBox1.Items.Contains("Elements") Then
            Else
                ListBox1.Items.Add("Elements")
            End If
        End If

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
                e.SuppressKeyPress = True
            End If
            If e.KeyCode = Keys.D AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X + ShiftOSDesktop.movablewindownumber, Me.Location.Y)
                e.SuppressKeyPress = True
            End If
            If e.KeyCode = Keys.W AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y - ShiftOSDesktop.movablewindownumber)
                e.SuppressKeyPress = True
            End If
            If e.KeyCode = Keys.S AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y + ShiftOSDesktop.movablewindownumber)
                e.SuppressKeyPress = True
            End If

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
            Me.Size = New Size(673, 304) 'put the default size of your window here
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
                lbtitletext.Text = ShiftOSDesktop.knowledgeinputname
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

            If ShiftOSDesktop.boughtknowledgeinputicon = True Then
                pnlicon.Visible = True
                pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
                pnlicon.Image = ShiftOSDesktop.knowledgeinputicontitlebar 'Replace with the correct icon for the program.
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

    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.Black, e.Bounds)
        End If
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        Using b As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items(e.Index)), e.Font, b, e.Bounds, sf)
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub listblistedstuff_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listblistedstuff.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.Black, e.Bounds)
        End If

        Using b As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(listblistedstuff.GetItemText(listblistedstuff.Items(e.Index)), e.Font, b, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        On Error Resume Next
        'Remember to create the files for each category in the hijack screen and add the category in the design view and make the countries list in this load event
        Select Case ListBox1.SelectedItem.ToString
            Case "Animals"
                loadsavepoint("Animals", 10, "C:\ShiftOS\SoftwareData\KnowledgeInput\Animals.lst", "There are many animals out there! Can you list them all?" & Environment.NewLine _
                & "Note that you get points for listing animals... not animal breeds!", animalslist)

            Case "Fruits"
                loadsavepoint("Fruits", 10, "C:\ShiftOS\SoftwareData\KnowledgeInput\Fruits.lst", "Do you get your daily serving of fruit each day?" & Environment.NewLine _
                & "Really...? See if you can list them then ;)", fruitslist)

            Case "Countries"
                loadsavepoint("Countries", 10, "C:\ShiftOS\SoftwareData\KnowledgeInput\Countries.lst", "Ever wanted to travel the entire world?" & Environment.NewLine _
                & "Well before you do see if you can list every country in the world!", countrieslist)

            Case "Car Brands"
                loadsavepoint("Car Brands", 10, "C:\ShiftOS\SoftwareData\KnowledgeInput\Car Brands.lst", "Can you list every single car brand?" & Environment.NewLine _
                & "Don't use words like automobiles, motors or cars!", carbrandslist)

            Case "Game Consoles"
                loadsavepoint("Game Consoles", 10, "C:\ShiftOS\SoftwareData\KnowledgeInput\Game Consoles.lst", "Do you call yourself a gamer?" & Environment.NewLine _
                & "Earn that title by listing non-handheld game consoles!", gameconsoleslist)

            Case "Elements"
                loadsavepoint("Elements", 10, "C:\ShiftOS\SoftwareData\KnowledgeInput\Elements.lst", "Have you memorized the periodic table of elements?" & Environment.NewLine _
                & "No? Well don't even attempt trying to guess them all here!", elementslist)
        End Select

    End Sub

    Private Sub handleword()

        Select Case ListBox1.SelectedItem.ToString
            Case "Animals"
                handlewordtype(animalslist, "C:\ShiftOS\SoftwareData\KnowledgeInput\Animals.lst")
            Case "Fruits"
                handlewordtype(fruitslist, "C:\ShiftOS\SoftwareData\KnowledgeInput\Fruits.lst")
            Case "Countries"
                handlewordtype(countrieslist, "C:\ShiftOS\SoftwareData\KnowledgeInput\Countries.lst")
            Case "Car Brands"
                handlewordtype(carbrandslist, "C:\ShiftOS\SoftwareData\KnowledgeInput\Car Brands.lst")
            Case "Game Consoles"
                handlewordtype(gameconsoleslist, "C:\ShiftOS\SoftwareData\KnowledgeInput\Game Consoles.lst")
            Case "Elements"
                handlewordtype(elementslist, "C:\ShiftOS\SoftwareData\KnowledgeInput\Elements.lst")
        End Select

        guessbox.Text = ""
        listblistedstuff.TopIndex = listblistedstuff.Items.Count - 1
    End Sub

    Private Sub btnquit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        handleword()
    End Sub

    Private Sub guessbox_click(sender As Object, e As EventArgs) Handles guessbox.MouseClick
        guessbox.Text = ""
    End Sub

    Private Sub guessbox_keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles guessbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            handleword()
        End If
    End Sub

    Private Sub decider_Tick(sender As Object, e As EventArgs) Handles decider.Tick
        lblcurrentlevel.Text = "Current Level: " & level
        lblnextreward.Text = "Reward for completing level " & level & " : " & rewardbase * level & "CP"
        guessalreadydone = False
        guesscorrect = False
        levelup = False
        decider.Interval = 500
        decider.Stop()
    End Sub

    Private Sub loadsavepoint(ByVal title As String, ByVal reward As Integer, ByVal loadpath As String, ByVal info As String, ByVal listtype() As String)
        lblcategory.Text = title
        rewardbase = reward
        listblistedstuff.Items.Clear()
        listblistedstuff.Items.AddRange(IO.File.ReadAllLines(loadpath))
        totalguessed = listblistedstuff.Items.Count
        level = Math.Ceiling((totalguessed / 10))
        tillnextlevel = Math.Abs(totalguessed - (level * 10))

        If tillnextlevel = 0 Then
            level = level + 1
            tillnextlevel = 10
        End If

        lblcatedescription.Text = info
        pnlcategorydisplay.Show()
        lbltillnextlevel.Text = "Words Until Next Level: " & tillnextlevel
        lblcurrentlevel.Text = "Current Level: " & level
        lbltotal.Text = "Guessed: " & totalguessed & "/" & listtype.Length
        lblnextreward.Text = "Reward for completing level " & level & " : " & rewardbase * level & "CP"
    End Sub

    Private Sub handlewordtype(ByVal listtype() As String, ByVal savepath As String)

        Dim userguess As String = guessbox.Text
        userguess = userguess.ToLower
        For Each Str As String In listtype
            If Str = userguess Then
                If listblistedstuff.Items.Contains(userguess) Then
                    guessalreadydone = True
                    ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " Knowledge Input Already Did " & ListBox1.SelectedItem.ToString & ": " & userguess & Environment.NewLine
                Else
                    guesscorrect = True
                    listblistedstuff.Items.Add(userguess)
                    ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " Knowledge Input Guessed " & ListBox1.SelectedItem.ToString & ": " & userguess & Environment.NewLine
                    tillnextlevel = tillnextlevel - 1
                    totalguessed = totalguessed + 1
                    IO.File.WriteAllLines(savepath, listblistedstuff.Items.Cast(Of String).ToArray)

                    If tillnextlevel = 0 Then
                        levelup = True
                        tillnextlevel = 10
                        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + rewardbase * level
                        Dim objWriter As New System.IO.StreamWriter("C:/ShiftOS/Shiftum42/SKernal.sft", False)
                        objWriter.Write(ShiftOSDesktop.codepoints)
                        objWriter.Close()
                        level = level + 1
                        ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " Reached " & ListBox1.SelectedItem.ToString & " Level: " & level & Environment.NewLine
                    End If
                End If
            End If
        Next
        lbltillnextlevel.Text = "Words Until Next Level: " & tillnextlevel
        lblcurrentlevel.Text = "Current Level: " & level
        lbltotal.Text = "Guessed: " & totalguessed & "/" & listtype.Length
        lblnextreward.Text = "Reward for completing level " & level & " : " & rewardbase * level & "CP"

        If levelup = True Then
            decider.Interval = 2000
            lblcurrentlevel.Text = "Level Up!"
            lblnextreward.Text = "You have earned " & rewardbase * (level - 1) & " Code Points!"
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User has " & ShiftOSDesktop.codepoints & " Code Points!" & Environment.NewLine
            decider.Start()
        Else
            If guessalreadydone = True Then
                lblcurrentlevel.Text = "Already Guessed"
                decider.Start()
            Else
                If guesscorrect = True Then
                    lblcurrentlevel.Text = "Correct :)"
                    decider.Start()
                Else
                    lblcurrentlevel.Text = "Wrong :("
                    ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " Knowledge Input Wrong " & ListBox1.SelectedItem.ToString & ": " & userguess & Environment.NewLine
                    decider.Start()
                End If
            End If
        End If
    End Sub

    Private Sub makeanimallist()
        animalslist(0) = "aardvark"
        animalslist(1) = "albatross"
        animalslist(2) = "alligator"
        animalslist(3) = "alpaca"
        animalslist(4) = "ant"
        animalslist(5) = "anteater"
        animalslist(6) = "antelope"
        animalslist(7) = "ape"
        animalslist(8) = "armadillo"
        animalslist(9) = "ass"
        animalslist(10) = "baboon"
        animalslist(11) = "badger"
        animalslist(12) = "barracuda"
        animalslist(13) = "bat"
        animalslist(14) = "bear"
        animalslist(15) = "beaver"
        animalslist(16) = "bee"
        animalslist(17) = "bison"
        animalslist(18) = "boar"
        animalslist(19) = "buffalo"
        animalslist(20) = "butterfly"
        animalslist(21) = "camel"
        animalslist(22) = "caribou"
        animalslist(23) = "cat"
        animalslist(24) = "caterpillar"
        animalslist(25) = "cow"
        animalslist(26) = "chamois"
        animalslist(27) = "cheetah"
        animalslist(28) = "chicken"
        animalslist(29) = "chimpanzee"
        animalslist(30) = "chinchilla"
        animalslist(31) = "chough"
        animalslist(32) = "clam"
        animalslist(33) = "cobra"
        animalslist(34) = "cockroach"
        animalslist(35) = "cod"
        animalslist(36) = "cormorant"
        animalslist(37) = "coyote"
        animalslist(38) = "crab"
        animalslist(39) = "crane"
        animalslist(40) = "crocodile"
        animalslist(41) = "crow"
        animalslist(42) = "curlew"
        animalslist(43) = "deer"
        animalslist(44) = "dinosaur"
        animalslist(45) = "dog"
        animalslist(46) = "dogfish"
        animalslist(47) = "dolphin"
        animalslist(48) = "donkey"
        animalslist(49) = "dotterel"
        animalslist(50) = "dove"
        animalslist(51) = "dragonfly"
        animalslist(52) = "duck"
        animalslist(53) = "dugong"
        animalslist(54) = "dunlin"
        animalslist(55) = "eagle"
        animalslist(56) = "echidna"
        animalslist(57) = "eel"
        animalslist(58) = "eland"
        animalslist(59) = "elephant"
        animalslist(60) = "elephant seal"
        animalslist(61) = "elk"
        animalslist(62) = "emu"
        animalslist(63) = "falcon"
        animalslist(64) = "ferret"
        animalslist(65) = "finch"
        animalslist(66) = "fish"
        animalslist(67) = "flamingo"
        animalslist(68) = "fly"
        animalslist(69) = "fox"
        animalslist(70) = "frog"
        animalslist(71) = "galago"
        animalslist(72) = "gaur"
        animalslist(73) = "gazelle"
        animalslist(74) = "gerbil"
        animalslist(75) = "giant panda"
        animalslist(76) = "giraffe"
        animalslist(77) = "gnat"
        animalslist(78) = "gnu"
        animalslist(79) = "goat"
        animalslist(80) = "goldfinch"
        animalslist(81) = "goldfish"
        animalslist(82) = "goose"
        animalslist(83) = "gorilla"
        animalslist(84) = "goshawk"
        animalslist(85) = "grasshopper"
        animalslist(86) = "grouse"
        animalslist(87) = "guanaco"
        animalslist(88) = "guineafowl"
        animalslist(89) = "guinea pig"
        animalslist(90) = "gull"
        animalslist(91) = "hamster"
        animalslist(92) = "hare"
        animalslist(93) = "hawk"
        animalslist(94) = "hedgehog"
        animalslist(95) = "heron"
        animalslist(96) = "herring"
        animalslist(97) = "hippopotamus"
        animalslist(98) = "hornet"
        animalslist(99) = "horse"
        animalslist(100) = "human"
        animalslist(101) = "humming bird"
        animalslist(102) = "hyena"
        animalslist(103) = "jackal"
        animalslist(104) = "jaguar"
        animalslist(105) = "jay"
        animalslist(106) = "jellyfish"
        animalslist(107) = "kangaroo"
        animalslist(108) = "koala"
        animalslist(109) = "komodo dragon"
        animalslist(110) = "kouprey"
        animalslist(111) = "kudu"
        animalslist(112) = "lizard"
        animalslist(113) = "lark"
        animalslist(114) = "lemur"
        animalslist(115) = "leopard"
        animalslist(116) = "lion"
        animalslist(117) = "llama"
        animalslist(118) = "lobster"
        animalslist(119) = "locust"
        animalslist(120) = "loris"
        animalslist(121) = "louse"
        animalslist(122) = "lyrebird"
        animalslist(123) = "magpie"
        animalslist(124) = "mallard"
        animalslist(125) = "manatee"
        animalslist(126) = "marten"
        animalslist(127) = "meerkat"
        animalslist(128) = "mink"
        animalslist(129) = "mole"
        animalslist(130) = "monkey"
        animalslist(131) = "moose"
        animalslist(132) = "mosquito"
        animalslist(133) = "mouse"
        animalslist(134) = "mule"
        animalslist(135) = "narwhal"
        animalslist(136) = "newt"
        animalslist(137) = "nightingale"
        animalslist(138) = "octopus"
        animalslist(139) = "okapi"
        animalslist(140) = "opossum"
        animalslist(141) = "oryx"
        animalslist(142) = "ostrich"
        animalslist(143) = "otter"
        animalslist(144) = "owl"
        animalslist(145) = "ox"
        animalslist(146) = "oyster"
        animalslist(147) = "panther"
        animalslist(148) = "parrot"
        animalslist(149) = "partridge"
        animalslist(150) = "peafowl"
        animalslist(151) = "pelican"
        animalslist(152) = "penguin"
        animalslist(153) = "pheasant"
        animalslist(154) = "pig"
        animalslist(155) = "pigeon"
        animalslist(156) = "pony"
        animalslist(157) = "porcupine"
        animalslist(158) = "porpoise"
        animalslist(159) = "prairie dog"
        animalslist(160) = "quail"
        animalslist(161) = "quelea"
        animalslist(162) = "rabbit"
        animalslist(163) = "raccoon"
        animalslist(164) = "rail"
        animalslist(165) = "ram"
        animalslist(166) = "rat"
        animalslist(167) = "raven"
        animalslist(168) = "red deer"
        animalslist(169) = "red panda"
        animalslist(170) = "reindeer"
        animalslist(171) = "rhinoceros"
        animalslist(172) = "rook"
        animalslist(173) = "ruff"
        animalslist(174) = "salamander"
        animalslist(175) = "salmon"
        animalslist(176) = "sand dollar"
        animalslist(177) = "sandpiper"
        animalslist(178) = "sardine"
        animalslist(179) = "scorpion"
        animalslist(180) = "sea lion"
        animalslist(181) = "sea urchin"
        animalslist(182) = "seahorse"
        animalslist(183) = "seal"
        animalslist(184) = "shark"
        animalslist(185) = "sheep"
        animalslist(186) = "shrew"
        animalslist(187) = "shrimp"
        animalslist(188) = "skunk"
        animalslist(189) = "snail"
        animalslist(190) = "snake"
        animalslist(191) = "spider"
        animalslist(192) = "squid"
        animalslist(193) = "squirrel"
        animalslist(194) = "starling"
        animalslist(195) = "stingray"
        animalslist(196) = "stink bug"
        animalslist(197) = "stork"
        animalslist(198) = "swallow"
        animalslist(199) = "swan"
        animalslist(200) = "tapir"
        animalslist(201) = "tarsier"
        animalslist(202) = "termite"
        animalslist(203) = "tiger"
        animalslist(204) = "toad"
        animalslist(205) = "trout"
        animalslist(206) = "turkey"
        animalslist(207) = "turtle"
        animalslist(208) = "vicuña"
        animalslist(209) = "viper"
        animalslist(210) = "vulture"
        animalslist(211) = "wallaby"
        animalslist(212) = "walrus"
        animalslist(213) = "wasp"
        animalslist(214) = "water buffalo"
        animalslist(215) = "weasel"
        animalslist(216) = "whale"
        animalslist(217) = "wolf"
        animalslist(218) = "wolverine"
        animalslist(219) = "wombat"
        animalslist(220) = "woodcock"
        animalslist(221) = "woodpecker"
        animalslist(222) = "worm"
        animalslist(223) = "wren"
        animalslist(224) = "yak"
        animalslist(225) = "zebra"
        animalslist(226) = "bird"
    End Sub

    Private Sub makefruitlist()
        fruitslist(0) = "apple"
        fruitslist(1) = "apricot"
        fruitslist(2) = "avocado"
        fruitslist(3) = "banana"
        fruitslist(4) = "breadfruit"
        fruitslist(5) = "bilberry"
        fruitslist(6) = "blackberry"
        fruitslist(7) = "blackcurrant"
        fruitslist(8) = "blueberry"
        fruitslist(9) = "boysenberry"
        fruitslist(10) = "cantaloupe"
        fruitslist(11) = "currant"
        fruitslist(12) = "cherry"
        fruitslist(13) = "cherimoya"
        fruitslist(14) = "chili"
        fruitslist(15) = "cloudberry"
        fruitslist(16) = "coconut"
        fruitslist(17) = "damson"
        fruitslist(18) = "date"
        fruitslist(19) = "dragonfruit"
        fruitslist(20) = "durian"
        fruitslist(21) = "elderberry"
        fruitslist(22) = "feijoa"
        fruitslist(23) = "fig"
        fruitslist(24) = "gooseberry"
        fruitslist(25) = "grape"
        fruitslist(26) = "grapefruit"
        fruitslist(27) = "guava"
        fruitslist(28) = "huckleberry"
        fruitslist(29) = "honeydew"
        fruitslist(30) = "jackfruit"
        fruitslist(31) = "jambul"
        fruitslist(32) = "jujube"
        fruitslist(33) = "kiwi fruit"
        fruitslist(34) = "kumquat"
        fruitslist(35) = "legume"
        fruitslist(36) = "lemon"
        fruitslist(37) = "lime"
        fruitslist(38) = "loquat"
        fruitslist(39) = "lychee"
        fruitslist(40) = "mango"
        fruitslist(41) = "melon"
        fruitslist(42) = "canary melon"
        fruitslist(43) = "cantaloupe"
        fruitslist(44) = "honeydew"
        fruitslist(45) = "watermelon"
        fruitslist(46) = "rock melon"
        fruitslist(47) = "nectarine"
        fruitslist(48) = "nut"
        fruitslist(49) = "orange"
        fruitslist(50) = "clementine"
        fruitslist(51) = "mandarine"
        fruitslist(52) = "tangerine"
        fruitslist(53) = "papaya"
        fruitslist(54) = "passionfruit"
        fruitslist(55) = "peach"
        fruitslist(56) = "bell pepper"
        fruitslist(57) = "pear"
        fruitslist(58) = "persimmon"
        fruitslist(59) = "physalis"
        fruitslist(60) = "plum"
        fruitslist(61) = "pineapple"
        fruitslist(62) = "pomegranate"
        fruitslist(63) = "pomelo"
        fruitslist(64) = "purple mangosteen"
        fruitslist(65) = "quince"
        fruitslist(66) = "raspberry"
        fruitslist(67) = "rambutan"
        fruitslist(68) = "redcurrant"
        fruitslist(69) = "salal berry"
        fruitslist(70) = "satsuma"
        fruitslist(71) = "star fruit"
        fruitslist(72) = "strawberry"
        fruitslist(73) = "tamarillo"
        fruitslist(74) = "tomato"
        fruitslist(75) = "ugli fruit"
    End Sub

    Private Sub makecountrieslist()
        countrieslist(0) = "afghanistan"
        countrieslist(1) = "albania"
        countrieslist(2) = "algeria"
        countrieslist(3) = "american samoa"
        countrieslist(4) = "andorra"
        countrieslist(5) = "angola"
        countrieslist(6) = "anguilla"
        countrieslist(7) = "antigua"
        countrieslist(8) = "argentina"
        countrieslist(9) = "armenia"
        countrieslist(10) = "aruba"
        countrieslist(11) = "australia"
        countrieslist(12) = "austria"
        countrieslist(13) = "azerbaijan"
        countrieslist(14) = "bahamas"
        countrieslist(15) = "bahrain"
        countrieslist(16) = "bangladesh"
        countrieslist(17) = "barbados"
        countrieslist(18) = "barbuda"
        countrieslist(19) = "belarus"
        countrieslist(20) = "belgium"
        countrieslist(21) = "belize"
        countrieslist(22) = "benin"
        countrieslist(23) = "bermuda"
        countrieslist(24) = "bhutan"
        countrieslist(25) = "bolivia"
        countrieslist(26) = "bosnia"
        countrieslist(27) = "botswana"
        countrieslist(28) = "bouvet island"
        countrieslist(29) = "brazil"
        countrieslist(30) = "brunei"
        countrieslist(31) = "bulgaria"
        countrieslist(32) = "burkina faso"
        countrieslist(33) = "burundi"
        countrieslist(34) = "cambodia"
        countrieslist(35) = "cameroon"
        countrieslist(36) = "canada"
        countrieslist(37) = "cape verde"
        countrieslist(38) = "cayman islands"
        countrieslist(39) = "central african republic"
        countrieslist(40) = "chad"
        countrieslist(41) = "chile"
        countrieslist(42) = "china"
        countrieslist(43) = "christmas island"
        countrieslist(44) = "cocos islands"
        countrieslist(45) = "colombia"
        countrieslist(46) = "comoros"
        countrieslist(47) = "democratic republic of the congo"
        countrieslist(48) = "republic of congo"
        countrieslist(49) = "cook islands"
        countrieslist(50) = "costa rica"
        countrieslist(51) = "croatia"
        countrieslist(52) = "cuba"
        countrieslist(53) = "cyprus"
        countrieslist(54) = "czech republic"
        countrieslist(55) = "denmark"
        countrieslist(56) = "djibouti"
        countrieslist(57) = "dominica"
        countrieslist(58) = "dominican republic"
        countrieslist(59) = "ecuador"
        countrieslist(60) = "egypt"
        countrieslist(61) = "el salvador"
        countrieslist(62) = "equatorial guinea"
        countrieslist(63) = "eritrea"
        countrieslist(64) = "estonia"
        countrieslist(65) = "ethiopia"
        countrieslist(66) = "falkland islands"
        countrieslist(67) = "faroe islands"
        countrieslist(68) = "fiji"
        countrieslist(69) = "finland"
        countrieslist(70) = "france"
        countrieslist(71) = "french guiana"
        countrieslist(72) = "gabon"
        countrieslist(73) = "gambia"
        countrieslist(74) = "georgia"
        countrieslist(75) = "germany"
        countrieslist(76) = "ghana"
        countrieslist(77) = "gibraltar"
        countrieslist(78) = "greece"
        countrieslist(79) = "greenland"
        countrieslist(80) = "grenada"
        countrieslist(81) = "guadeloupe"
        countrieslist(82) = "guam"
        countrieslist(83) = "guatemala"
        countrieslist(84) = "guinea"
        countrieslist(85) = "guinea bissau"
        countrieslist(86) = "guyana"
        countrieslist(87) = "haiti"
        countrieslist(88) = "holy see"
        countrieslist(89) = "honduras"
        countrieslist(90) = "hong kong"
        countrieslist(91) = "hungary"
        countrieslist(92) = "iceland"
        countrieslist(93) = "india"
        countrieslist(94) = "indonesia"
        countrieslist(95) = "iran"
        countrieslist(96) = "iraq"
        countrieslist(97) = "ireland"
        countrieslist(98) = "israel"
        countrieslist(99) = "italy"
        countrieslist(100) = "ivory coas"
        countrieslist(101) = "jamaica"
        countrieslist(102) = "japan"
        countrieslist(103) = "jordan"
        countrieslist(104) = "kazakhstan"
        countrieslist(105) = "kenya"
        countrieslist(106) = "kiribati"
        countrieslist(107) = "kuwait"
        countrieslist(108) = "kyrgyzstan"
        countrieslist(109) = "laos"
        countrieslist(110) = "latvia"
        countrieslist(111) = "lebanon"
        countrieslist(112) = "lesotho"
        countrieslist(113) = "liberia"
        countrieslist(114) = "libya"
        countrieslist(115) = "liechtenstein"
        countrieslist(116) = "lithuania"
        countrieslist(117) = "luxembourg"
        countrieslist(118) = "macau"
        countrieslist(119) = "macedonia"
        countrieslist(120) = "madagascar"
        countrieslist(121) = "malawi"
        countrieslist(122) = "malaysia"
        countrieslist(123) = "maldives"
        countrieslist(124) = "mali"
        countrieslist(125) = "malta"
        countrieslist(126) = "marshall islands"
        countrieslist(127) = "martinique"
        countrieslist(128) = "mauritania"
        countrieslist(129) = "mauritius"
        countrieslist(130) = "mayotte"
        countrieslist(131) = "mexico"
        countrieslist(132) = "micronesia"
        countrieslist(133) = "moldova"
        countrieslist(134) = "monaco"
        countrieslist(135) = "mongolia"
        countrieslist(136) = "montenegro"
        countrieslist(137) = "montserrat"
        countrieslist(138) = "morocco"
        countrieslist(139) = "mozambique"
        countrieslist(140) = "myanmar"
        countrieslist(141) = "namibia"
        countrieslist(142) = "nauru"
        countrieslist(143) = "nepal"
        countrieslist(144) = "netherlands"
        countrieslist(145) = "new caledonia"
        countrieslist(146) = "new zealand"
        countrieslist(147) = "nicaragua"
        countrieslist(148) = "niger"
        countrieslist(149) = "nigeria"
        countrieslist(150) = "niue"
        countrieslist(151) = "norfolk island"
        countrieslist(152) = "north korea"
        countrieslist(153) = "northern mariana islands"
        countrieslist(154) = "norway"
        countrieslist(155) = "oman"
        countrieslist(156) = "pakistan"
        countrieslist(157) = "palau"
        countrieslist(158) = "panama"
        countrieslist(159) = "papua new guinea"
        countrieslist(160) = "paraguay"
        countrieslist(161) = "peru"
        countrieslist(162) = "philippines"
        countrieslist(163) = "pitcairn island"
        countrieslist(164) = "poland"
        countrieslist(165) = "polynesia"
        countrieslist(166) = "portugal"
        countrieslist(167) = "puerto rico"
        countrieslist(168) = "qatar"
        countrieslist(169) = "reunion"
        countrieslist(170) = "romania"
        countrieslist(171) = "russia"
        countrieslist(172) = "rwanda"
        countrieslist(173) = "saint helena"
        countrieslist(174) = "saint kitts and nevis"
        countrieslist(175) = "saint lucia"
        countrieslist(176) = "saint pierre and miquelon"
        countrieslist(177) = "saint vincent and grenadines"
        countrieslist(178) = "samoa"
        countrieslist(179) = "san marino"
        countrieslist(180) = "sao tome and principe"
        countrieslist(181) = "saudi arabia"
        countrieslist(182) = "senegal"
        countrieslist(183) = "serbia"
        countrieslist(184) = "seychelles"
        countrieslist(185) = "sierra leone"
        countrieslist(186) = "singapore"
        countrieslist(187) = "slovakia"
        countrieslist(188) = "slovenia"
        countrieslist(189) = "solomon islands"
        countrieslist(190) = "somalia"
        countrieslist(191) = "south africa"
        countrieslist(192) = "south georgia and south sandwich islands"
        countrieslist(193) = "south korea"
        countrieslist(194) = "south sudan"
        countrieslist(195) = "spain"
        countrieslist(196) = "sri lanka"
        countrieslist(197) = "sudan"
        countrieslist(198) = "suriname"
        countrieslist(199) = "svalbard and jan mayen islands"
        countrieslist(200) = "swaziland"
        countrieslist(201) = "sweden"
        countrieslist(202) = "switzerland"
        countrieslist(203) = "syria"
        countrieslist(204) = "taiwan"
        countrieslist(205) = "tajikistan"
        countrieslist(206) = "tanzania"
        countrieslist(207) = "thailand"
        countrieslist(208) = "east timor"
        countrieslist(209) = "togo"
        countrieslist(210) = "tokelau"
        countrieslist(211) = "tonga"
        countrieslist(212) = "trinidad and tobago"
        countrieslist(213) = "tunisia"
        countrieslist(214) = "turkey"
        countrieslist(215) = "turkmenistan"
        countrieslist(216) = "turks and caicos islands"
        countrieslist(217) = "tuvalu"
        countrieslist(218) = "uganda"
        countrieslist(219) = "ukraine"
        countrieslist(220) = "united arab emirates"
        countrieslist(221) = "united kingdom"
        countrieslist(222) = "united states"
        countrieslist(223) = "uruguay"
        countrieslist(224) = "uzbekistan"
        countrieslist(225) = "vanuatu"
        countrieslist(226) = "venezuela"
        countrieslist(227) = "vietnam"
        countrieslist(228) = "virgin islands"
        countrieslist(229) = "wallis and futuna islands"
        countrieslist(230) = "yemen"
        countrieslist(231) = "zambia"
        countrieslist(232) = "zimbabwe"
    End Sub

    Public Sub makecarbrandslist()
        carbrandslist(0) = "8 chinkara"
        carbrandslist(1) = "aba"
        carbrandslist(2) = "abarth"
        carbrandslist(3) = "ac"
        carbrandslist(4) = "ac schnitzer"
        carbrandslist(5) = "acura"
        carbrandslist(6) = "adam"
        carbrandslist(7) = "adams-farwell"
        carbrandslist(8) = "adler"
        carbrandslist(9) = "aero"
        carbrandslist(10) = "aga"
        carbrandslist(11) = "agrale"
        carbrandslist(12) = "aixam"
        carbrandslist(13) = "alfa romeo"
        carbrandslist(14) = "allard"
        carbrandslist(15) = "alpine"
        carbrandslist(16) = "alvis"
        carbrandslist(17) = "anadol"
        carbrandslist(18) = "anasagasti"
        carbrandslist(19) = "angkor"
        carbrandslist(20) = "apollo"
        carbrandslist(21) = "armstrong siddeley"
        carbrandslist(22) = "aro"
        carbrandslist(23) = "ascari"
        carbrandslist(24) = "ashok leyland"
        carbrandslist(25) = "aston martin"
        carbrandslist(26) = "auburn"
        carbrandslist(27) = "audi"
        carbrandslist(28) = "austin"
        carbrandslist(29) = "austin-healey"
        carbrandslist(30) = "auto-mixte"
        carbrandslist(31) = "autobianchi"
        carbrandslist(32) = "automobile dacia"
        carbrandslist(33) = "avia"
        carbrandslist(34) = "avtoframos"
        carbrandslist(35) = "awz"
        carbrandslist(36) = "bahman"
        carbrandslist(37) = "bajaj"
        carbrandslist(38) = "barkas"
        carbrandslist(39) = "bate"
        carbrandslist(40) = "bentley"
        carbrandslist(41) = "bharath benz"
        carbrandslist(42) = "bitter"
        carbrandslist(43) = "bmc"
        carbrandslist(44) = "bmw"
        carbrandslist(45) = "bollore"
        carbrandslist(46) = "borgward"
        carbrandslist(47) = "bricklin"
        carbrandslist(48) = "bristol"
        carbrandslist(49) = "british leyland"
        carbrandslist(50) = "bufori"
        carbrandslist(51) = "bugatti"
        carbrandslist(52) = "buick"
        carbrandslist(53) = "bussing"
        carbrandslist(54) = "c-fee"
        carbrandslist(55) = "cadillac"
        carbrandslist(56) = "callaway"
        carbrandslist(57) = "caterham"
        carbrandslist(58) = "cherdchai"
        carbrandslist(59) = "chevrolet"
        carbrandslist(60) = "chrysler"
        carbrandslist(61) = "citroen"
        carbrandslist(62) = "cizeta"
        carbrandslist(63) = "coda"
        carbrandslist(64) = "cord"
        carbrandslist(65) = "crespi"
        carbrandslist(66) = "crobus"
        carbrandslist(67) = "daf"
        carbrandslist(68) = "daihatsu"
        carbrandslist(69) = "daimler"
        carbrandslist(70) = "datsun"
        carbrandslist(71) = "davis"
        carbrandslist(72) = "dc design"
        carbrandslist(73) = "de tomaso"
        carbrandslist(74) = "delorean"
        carbrandslist(75) = "derby"
        carbrandslist(76) = "dina"
        carbrandslist(77) = "dkw"
        carbrandslist(78) = "dodge"
        carbrandslist(79) = "dok-ing"
        carbrandslist(80) = "dok-ing xd"
        carbrandslist(81) = "dome"
        carbrandslist(82) = "donkervoort"
        carbrandslist(83) = "dr"
        carbrandslist(84) = "duesenberg"
        carbrandslist(85) = "e-z-go"
        carbrandslist(86) = "eagle"
        carbrandslist(87) = "edsel"
        carbrandslist(88) = "eicher"
        carbrandslist(89) = "elfin"
        carbrandslist(90) = "elva"
        carbrandslist(91) = "enzmann"
        carbrandslist(92) = "essex"
        carbrandslist(93) = "esther"
        carbrandslist(94) = "exagon"
        carbrandslist(95) = "falcon"
        carbrandslist(96) = "fap"
        carbrandslist(97) = "ferrari"
        carbrandslist(98) = "fiat"
        carbrandslist(99) = "fisker"
        carbrandslist(100) = "force"
        carbrandslist(101) = "ford"
        carbrandslist(102) = "fpv"
        carbrandslist(103) = "gaz"
        carbrandslist(104) = "gengatharan"
        carbrandslist(105) = "geo"
        carbrandslist(106) = "ghandhara"
        carbrandslist(107) = "ghandhara nissan"
        carbrandslist(108) = "gillet"
        carbrandslist(109) = "ginetta"
        carbrandslist(110) = "gkd"
        carbrandslist(111) = "glas"
        carbrandslist(112) = "global electric"
        carbrandslist(113) = "gm daewoo"
        carbrandslist(114) = "gm uzbekistan"
        carbrandslist(115) = "gmc"
        carbrandslist(116) = "goliath"
        carbrandslist(117) = "gordon keeble"
        carbrandslist(118) = "graham-paige"
        carbrandslist(119) = "guleryuz karoseri"
        carbrandslist(120) = "gumpert"
        carbrandslist(121) = "gurgel"
        carbrandslist(122) = "hansa"
        carbrandslist(123) = "hattat"
        carbrandslist(124) = "heinkel"
        carbrandslist(125) = "hennessey"
        carbrandslist(126) = "hero"
        carbrandslist(127) = "hillman"
        carbrandslist(128) = "hindustan"
        carbrandslist(129) = "hino"
        carbrandslist(130) = "hinopak"
        carbrandslist(131) = "hispano-argentina"
        carbrandslist(132) = "holden"
        carbrandslist(133) = "hommell"
        carbrandslist(134) = "honda"
        carbrandslist(135) = "honda atlas"
        carbrandslist(136) = "horch"
        carbrandslist(137) = "hsv"
        carbrandslist(138) = "huet brothers"
        carbrandslist(139) = "humber"
        carbrandslist(140) = "hummer"
        carbrandslist(141) = "hupmobile"
        carbrandslist(142) = "hyundai"
        carbrandslist(143) = "iame"
        carbrandslist(144) = "icml"
        carbrandslist(145) = "ida-opel"
        carbrandslist(146) = "ika"
        carbrandslist(147) = "ikarbus"
        carbrandslist(148) = "ikco"
        carbrandslist(149) = "indus"
        carbrandslist(150) = "infiniti"
        carbrandslist(151) = "inokom"
        carbrandslist(152) = "intermeccanica"
        carbrandslist(153) = "international harvester"
        carbrandslist(154) = "isuzu"
        carbrandslist(155) = "isuzu anadolu"
        carbrandslist(156) = "italika"
        carbrandslist(157) = "izh"
        carbrandslist(158) = "jaguar cars"
        carbrandslist(159) = "jeep"
        carbrandslist(160) = "jensen"
        carbrandslist(161) = "josse"
        carbrandslist(162) = "jowett"
        carbrandslist(163) = "jv man"
        carbrandslist(164) = "kaipan"
        carbrandslist(165) = "kaiser"
        carbrandslist(166) = "karsan"
        carbrandslist(167) = "kerman"
        carbrandslist(168) = "kia"
        carbrandslist(169) = "kia"
        carbrandslist(170) = "kish khodro"
        carbrandslist(171) = "kissel"
        carbrandslist(172) = "koenigsegg"
        carbrandslist(173) = "lada"
        carbrandslist(174) = "laforza"
        carbrandslist(175) = "lamborghini"
        carbrandslist(176) = "lanchester"
        carbrandslist(177) = "lancia"
        carbrandslist(178) = "land rover"
        carbrandslist(179) = "lasalle"
        carbrandslist(180) = "lexus"
        carbrandslist(181) = "ligier"
        carbrandslist(182) = "lincoln"
        carbrandslist(183) = "lister"
        carbrandslist(184) = "lloyd"
        carbrandslist(185) = "lobini"
        carbrandslist(186) = "locomobile"
        carbrandslist(187) = "lotus"
        carbrandslist(188) = "mahindra"
        carbrandslist(189) = "man"
        carbrandslist(190) = "mansory"
        carbrandslist(191) = "marcos"
        carbrandslist(192) = "marmon"
        carbrandslist(193) = "marussia"
        carbrandslist(194) = "maruti suzuki"
        carbrandslist(195) = "maserati"
        carbrandslist(196) = "master"
        carbrandslist(197) = "mastretta"
        carbrandslist(198) = "matra"
        carbrandslist(199) = "maybach"
        carbrandslist(200) = "mazda"
        carbrandslist(201) = "mclaren"
        carbrandslist(202) = "mdi"
        carbrandslist(203) = "mercedes"
        carbrandslist(204) = "mercury"
        carbrandslist(205) = "micro"
        carbrandslist(206) = "microcar"
        carbrandslist(207) = "mini"
        carbrandslist(208) = "mini cooper"
        carbrandslist(209) = "mitsubishi"
        carbrandslist(210) = "mitsuoka"
        carbrandslist(211) = "morgan"
        carbrandslist(212) = "morris"
        carbrandslist(213) = "moskvitch"
        carbrandslist(214) = "mosler"
        carbrandslist(215) = "multicar"
        carbrandslist(216) = "mvm"
        carbrandslist(217) = "nag"
        carbrandslist(218) = "nagant"
        carbrandslist(219) = "nash"
        carbrandslist(220) = "navistar"
        carbrandslist(221) = "naza"
        carbrandslist(222) = "neobus"
        carbrandslist(223) = "neoplan"
        carbrandslist(224) = "nissan"
        carbrandslist(225) = "noble"
        carbrandslist(226) = "nsu"
        carbrandslist(227) = "oldsmobile"
        carbrandslist(228) = "oltcit"
        carbrandslist(229) = "opel"
        carbrandslist(230) = "orient"
        carbrandslist(231) = "otokar"
        carbrandslist(232) = "otosan"
        carbrandslist(233) = "oyak"
        carbrandslist(234) = "p.a.r.s moto"
        carbrandslist(235) = "packard"
        carbrandslist(236) = "pagani"
        carbrandslist(237) = "pak suzuki"
        carbrandslist(238) = "panoz"
        carbrandslist(239) = "pars khodro"
        carbrandslist(240) = "perodua"
        carbrandslist(241) = "peugeot"
        carbrandslist(242) = "pgo"
        carbrandslist(243) = "pieper"
        carbrandslist(244) = "pierce-arrow"
        carbrandslist(245) = "plymouth"
        carbrandslist(246) = "pontiac"
        carbrandslist(247) = "porsche"
        carbrandslist(248) = "praga"
        carbrandslist(249) = "premier"
        carbrandslist(250) = "proto"
        carbrandslist(251) = "proton"
        carbrandslist(252) = "puma"
        carbrandslist(253) = "ram"
        carbrandslist(254) = "ramirez"
        carbrandslist(255) = "regal"
        carbrandslist(256) = "renault"
        carbrandslist(257) = "renault samsung"
        carbrandslist(258) = "reo"
        carbrandslist(259) = "riley"
        carbrandslist(260) = "rimac"
        carbrandslist(261) = "robur"
        carbrandslist(262) = "rolls royce"
        carbrandslist(263) = "rover"
        carbrandslist(264) = "ruf"
        carbrandslist(265) = "russo-balt"
        carbrandslist(266) = "saab"
        carbrandslist(267) = "saipa"
        carbrandslist(268) = "saleen"
        carbrandslist(269) = "samavto"
        carbrandslist(270) = "saturn"
        carbrandslist(271) = "sbarro"
        carbrandslist(272) = "scania"
        carbrandslist(273) = "scion"
        carbrandslist(274) = "shane moto"
        carbrandslist(275) = "siam v.m.c."
        carbrandslist(276) = "siata"
        carbrandslist(277) = "simson"
        carbrandslist(278) = "singer"
        carbrandslist(279) = "skoda"
        carbrandslist(280) = "sound"
        carbrandslist(281) = "spyker"
        carbrandslist(282) = "ssangyong"
        carbrandslist(283) = "standard"
        carbrandslist(284) = "stealth"
        carbrandslist(285) = "sterling"
        carbrandslist(286) = "studebaker"
        carbrandslist(287) = "subaru"
        carbrandslist(288) = "sunbeam"
        carbrandslist(289) = "suzuki"
        carbrandslist(290) = "tac"
        carbrandslist(291) = "tafe"
        carbrandslist(292) = "tata"
        carbrandslist(293) = "tatra"
        carbrandslist(294) = "td2000"
        carbrandslist(295) = "temsa"
        carbrandslist(296) = "tesla"
        carbrandslist(297) = "th!nk"
        carbrandslist(298) = "thai rung"
        carbrandslist(299) = "the jamie stahley car"
        carbrandslist(300) = "tickford"
        carbrandslist(301) = "toyota"
        carbrandslist(302) = "trabant"
        carbrandslist(303) = "tranvias-cimex"
        carbrandslist(304) = "triumph"
        carbrandslist(305) = "trojan"
        carbrandslist(306) = "troller"
        carbrandslist(307) = "tucker"
        carbrandslist(308) = "turk traktor"
        carbrandslist(309) = "tvr"
        carbrandslist(310) = "tvs"
        carbrandslist(311) = "uaz"
        carbrandslist(312) = "vam sa"
        carbrandslist(313) = "vauxhall"
        carbrandslist(314) = "venturi"
        carbrandslist(315) = "vignale"
        carbrandslist(316) = "volkswagen"
        carbrandslist(317) = "volvo"
        carbrandslist(318) = "wanderer"
        carbrandslist(319) = "wartburg"
        carbrandslist(320) = "wiesmann"
        carbrandslist(321) = "willys"
        carbrandslist(322) = "wolseley"
        carbrandslist(323) = "yamaha"
        carbrandslist(324) = "yo-mobile"
        carbrandslist(325) = "zastava"
        carbrandslist(326) = "zenvo"
        carbrandslist(327) = "zil"
        carbrandslist(328) = "zoragy"
    End Sub

    Public Sub makegameconsoleslist()
        gameconsoleslist(0) = "magnavox odyssey"
        gameconsoleslist(1) = "ping-o-tronic"
        gameconsoleslist(2) = "telstar"
        gameconsoleslist(3) = "apf tv fun"
        gameconsoleslist(4) = "philips odyssey"
        gameconsoleslist(5) = "radio shack tv scoreboard"
        gameconsoleslist(6) = "binatone tv master mk iv"
        gameconsoleslist(7) = "color tv game 6"
        gameconsoleslist(8) = "color tv game 15"
        gameconsoleslist(9) = "color tv racing 112"
        gameconsoleslist(10) = "color tv game block breaker"
        gameconsoleslist(11) = "computer tv game"
        gameconsoleslist(12) = "bss 01"
        gameconsoleslist(13) = "fairchild channel f"
        gameconsoleslist(14) = "fairchild channel f system ii"
        gameconsoleslist(15) = "rca studio ii"
        gameconsoleslist(16) = "atari 2600"
        gameconsoleslist(17) = "atari 2600 jr"
        gameconsoleslist(18) = "atari 2800"
        gameconsoleslist(19) = "coleco gemini"
        gameconsoleslist(20) = "bally astrocade"
        gameconsoleslist(21) = "vc 4000"
        gameconsoleslist(22) = "magnavox odyssey 2"
        gameconsoleslist(23) = "apf imagination machine"
        gameconsoleslist(24) = "intellivision"
        gameconsoleslist(25) = "playcable"
        gameconsoleslist(26) = "bandai super vision 8000"
        gameconsoleslist(27) = "intellivision ii"
        gameconsoleslist(28) = "vtech creativision"
        gameconsoleslist(29) = "epoch cassette vision"
        gameconsoleslist(30) = "super cassette vision"
        gameconsoleslist(31) = "arcadia 2001"
        gameconsoleslist(32) = "atari 5200"
        gameconsoleslist(33) = "atari 5100"
        gameconsoleslist(34) = "colecovision"
        gameconsoleslist(35) = "entex adventure vision"
        gameconsoleslist(36) = "vectrex"
        gameconsoleslist(37) = "rdi halcyon"
        gameconsoleslist(38) = "pv-1000"
        gameconsoleslist(39) = "commodore 64 games system"
        gameconsoleslist(40) = "amstrad gx4000"
        gameconsoleslist(41) = "atari 7800"
        gameconsoleslist(42) = "atari xegs"
        gameconsoleslist(43) = "sega sg-1000"
        gameconsoleslist(44) = "sega master system"
        gameconsoleslist(45) = "nintendo entertainment system"
        gameconsoleslist(46) = "sharp nintendo television"
        gameconsoleslist(47) = "nes-101"
        gameconsoleslist(48) = "family computer disk system"
        gameconsoleslist(49) = "zemmix"
        gameconsoleslist(50) = "action max"
        gameconsoleslist(51) = "sega genesis"
        gameconsoleslist(52) = "sega pico"
        gameconsoleslist(53) = "pc engine"
        gameconsoleslist(54) = "konix multisystem"
        gameconsoleslist(55) = "neo-geo"
        gameconsoleslist(56) = "neo-geo cd"
        gameconsoleslist(57) = "neo-geo cdz"
        gameconsoleslist(58) = "commodore cdtv"
        gameconsoleslist(59) = "memorex vis"
        gameconsoleslist(60) = "super nintendo entertainment system"
        gameconsoleslist(61) = "sf-1 snes tv"
        gameconsoleslist(62) = "snes 2"
        gameconsoleslist(63) = "snes-cd"
        gameconsoleslist(64) = "satellaview"
        gameconsoleslist(65) = "cd-i"
        gameconsoleslist(66) = "turboduo"
        gameconsoleslist(67) = "super a'can"
        gameconsoleslist(68) = "pioneer laseractive"
        gameconsoleslist(69) = "fm towns marty"
        gameconsoleslist(70) = "apple bandai pippin"
        gameconsoleslist(71) = "pc-fx"
        gameconsoleslist(72) = "atari panther"
        gameconsoleslist(73) = "atari jaguar"
        gameconsoleslist(74) = "atari jaguar cd"
        gameconsoleslist(75) = "playstation"
        gameconsoleslist(76) = "net yaroze"
        gameconsoleslist(77) = "sega saturn"
        gameconsoleslist(78) = "3do interactive multiplayer"
        gameconsoleslist(79) = "amiga cd32"
        gameconsoleslist(80) = "casio loopy"
        gameconsoleslist(81) = "playdia"
        gameconsoleslist(82) = "nintendo 64"
        gameconsoleslist(83) = "nintendo 64dd"
        gameconsoleslist(84) = "sega neptune"
        gameconsoleslist(85) = "apextreme"
        gameconsoleslist(86) = "atari flashback"
        gameconsoleslist(87) = "atari jaguar ii"
        gameconsoleslist(88) = "dreamcast"
        gameconsoleslist(89) = "l600"
        gameconsoleslist(90) = "gamecube"
        gameconsoleslist(91) = "nuon"
        gameconsoleslist(92) = "ique player"
        gameconsoleslist(93) = "panasonic m2"
        gameconsoleslist(94) = "panasonic q"
        gameconsoleslist(95) = "playstation 2"
        gameconsoleslist(96) = "psx"
        gameconsoleslist(97) = "v.smile"
        gameconsoleslist(98) = "xavixport gaming console"
        gameconsoleslist(99) = "xbox"
        gameconsoleslist(100) = "atari flashback 2"
        gameconsoleslist(101) = "atari flashback 3"
        gameconsoleslist(102) = "atari flashback 4"
        gameconsoleslist(103) = "evo smart console"
        gameconsoleslist(104) = "retro duo"
        gameconsoleslist(105) = "game wave"
        gameconsoleslist(106) = "mattel hyperscan"
        gameconsoleslist(107) = "onlive"
        gameconsoleslist(108) = "phantom"
        gameconsoleslist(109) = "playstation 3"
        gameconsoleslist(110) = "wii"
        gameconsoleslist(111) = "xbox 360"
        gameconsoleslist(112) = "sega firecore"
        gameconsoleslist(113) = "zeebo"
        gameconsoleslist(114) = "sega zone"
        gameconsoleslist(115) = "eedoo ct510"
        gameconsoleslist(116) = "wii u"
        gameconsoleslist(117) = "ouya"
        gameconsoleslist(118) = "gamestick"
        gameconsoleslist(119) = "mojo"
        gameconsoleslist(120) = "gamepop"
        gameconsoleslist(121) = "playstation 4"
        gameconsoleslist(122) = "steam machine"
        gameconsoleslist(123) = "xbox one"
        gameconsoleslist(124) = "xi3 piston"

    End Sub

    Public Sub makeelementslist()
        elementslist(0) = "hydrogen"
        elementslist(1) = "helium"
        elementslist(2) = "lithium"
        elementslist(3) = "beryllium"
        elementslist(4) = "boron"
        elementslist(5) = "carbon"
        elementslist(6) = "nitrogen"
        elementslist(7) = "oxygen"
        elementslist(8) = "fluorine"
        elementslist(9) = "neon"
        elementslist(10) = "sodium"
        elementslist(11) = "magnesium"
        elementslist(12) = "aluminium"
        elementslist(13) = "silicon"
        elementslist(14) = "phosphorus"
        elementslist(15) = "sulfur"
        elementslist(16) = "chlorine"
        elementslist(17) = "argon"
        elementslist(18) = "potassium"
        elementslist(19) = "calcium"
        elementslist(20) = "scandium"
        elementslist(21) = "titanium"
        elementslist(22) = "vanadium"
        elementslist(23) = "chromium"
        elementslist(24) = "manganese"
        elementslist(25) = "iron"
        elementslist(26) = "cobalt"
        elementslist(27) = "nickel"
        elementslist(28) = "copper"
        elementslist(29) = "zinc"
        elementslist(30) = "gallium"
        elementslist(31) = "germanium"
        elementslist(32) = "arsenic"
        elementslist(33) = "selenium"
        elementslist(34) = "bromine"
        elementslist(35) = "krypton"
        elementslist(36) = "rubidium"
        elementslist(37) = "strontium"
        elementslist(38) = "yttrium"
        elementslist(39) = "zirconium"
        elementslist(40) = "niobium"
        elementslist(41) = "molybdenum"
        elementslist(42) = "technetium"
        elementslist(43) = "ruthenium"
        elementslist(44) = "rhodium"
        elementslist(45) = "palladium"
        elementslist(46) = "silver"
        elementslist(47) = "cadmium"
        elementslist(48) = "indium"
        elementslist(49) = "tin"
        elementslist(50) = "antimony"
        elementslist(51) = "tellurium"
        elementslist(52) = "iodine"
        elementslist(53) = "xenon"
        elementslist(54) = "caesium"
        elementslist(55) = "barium"
        elementslist(56) = "lanthanum"
        elementslist(57) = "cerium"
        elementslist(58) = "praseodymium"
        elementslist(59) = "neodymium"
        elementslist(60) = "promethium"
        elementslist(61) = "samarium"
        elementslist(62) = "europium"
        elementslist(63) = "gadolinium"
        elementslist(64) = "terbium"
        elementslist(65) = "dysprosium"
        elementslist(66) = "holmium"
        elementslist(67) = "erbium"
        elementslist(68) = "thulium"
        elementslist(69) = "ytterbium"
        elementslist(70) = "lutetium"
        elementslist(71) = "hafnium"
        elementslist(72) = "tantalum"
        elementslist(73) = "tungsten"
        elementslist(74) = "rhenium"
        elementslist(75) = "osmium"
        elementslist(76) = "iridium"
        elementslist(77) = "platinum"
        elementslist(78) = "gold"
        elementslist(79) = "mercury"
        elementslist(80) = "thallium"
        elementslist(81) = "lead"
        elementslist(82) = "bismuth"
        elementslist(83) = "polonium"
        elementslist(84) = "astatine"
        elementslist(85) = "radon"
        elementslist(86) = "francium"
        elementslist(87) = "radium"
        elementslist(88) = "actinium"
        elementslist(89) = "thorium"
        elementslist(90) = "protactinium"
        elementslist(91) = "uranium"
        elementslist(92) = "neptunium"
        elementslist(93) = "plutonium"
        elementslist(94) = "americium"
        elementslist(95) = "curium"
        elementslist(96) = "berkelium"
        elementslist(97) = "californium"
        elementslist(98) = "einsteinium"
        elementslist(99) = "fermium"
        elementslist(100) = "mendelevium"
        elementslist(101) = "nobelium"
        elementslist(102) = "lawrencium"
        elementslist(103) = "rutherfordium"
        elementslist(104) = "dubnium"
        elementslist(105) = "seaborgium"
        elementslist(106) = "bohrium"
        elementslist(107) = "hassium"
        elementslist(108) = "meitnerium"
        elementslist(109) = "darmstadtium"
        elementslist(110) = "roentgenium"
        elementslist(111) = "copernicium"
        elementslist(112) = "ununtrium"
        elementslist(113) = "flerovium"
        elementslist(114) = "ununpentium"
        elementslist(115) = "livermorium"
        elementslist(116) = "ununseptium"
        elementslist(117) = "ununoctium"
    End Sub

End Class