<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Downloadmanager

    Inherits System.Windows.Forms.Form

    Public ShiftOSPath As String = "C:\ShiftOS\"

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Downloadmanager))
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.pnlsettings = New System.Windows.Forms.Panel()
        Me.btnclearhist = New System.Windows.Forms.Button()
        Me.txtspeedlimiter = New System.Windows.Forms.TextBox()
        Me.btnsavefolder = New System.Windows.Forms.Button()
        Me.lbldownloadspeedtitle = New System.Windows.Forms.Label()
        Me.lbldownloadlocationtitle = New System.Windows.Forms.Label()
        Me.pnldownloads = New System.Windows.Forms.Panel()
        Me.lblqueueddownloads = New System.Windows.Forms.Label()
        Me.lblqueuetitle = New System.Windows.Forms.Label()
        Me.lbldownloadstitle = New System.Windows.Forms.Label()
        Me.lbldownloadingitems = New System.Windows.Forms.Label()
        Me.pnlwelcome = New System.Windows.Forms.Panel()
        Me.lblexit = New System.Windows.Forms.Label()
        Me.lblwelcometext = New System.Windows.Forms.Label()
        Me.pnlhistory = New System.Windows.Forms.Panel()
        Me.lblpreviousdownloadstitle = New System.Windows.Forms.Label()
        Me.lblpreviousdownloads = New System.Windows.Forms.Label()
        Me.pnltabbuttons = New System.Windows.Forms.Panel()
        Me.bntsettingtab = New System.Windows.Forms.Label()
        Me.bnthistorytab = New System.Windows.Forms.Label()
        Me.bntdownloadstab = New System.Windows.Forms.Label()
        Me.bntwelcometab = New System.Windows.Forms.Label()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.pullside = New System.Windows.Forms.Timer(Me.components)
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.pullbs = New System.Windows.Forms.Timer(Me.components)
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.tmrdownloadspeed = New System.Windows.Forms.Timer(Me.components)
        Me.tmrapplied = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pgcontents.SuspendLayout()
        Me.pnlsettings.SuspendLayout()
        Me.pnldownloads.SuspendLayout()
        Me.pnlwelcome.SuspendLayout()
        Me.pnlhistory.SuspendLayout()
        Me.pnltabbuttons.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.pgright.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.pnlsettings)
        Me.pgcontents.Controls.Add(Me.pnldownloads)
        Me.pgcontents.Controls.Add(Me.pnlwelcome)
        Me.pgcontents.Controls.Add(Me.pnlhistory)
        Me.pgcontents.Controls.Add(Me.pnltabbuttons)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(498, 220)
        Me.pgcontents.TabIndex = 20
        '
        'pnlsettings
        '
        Me.pnlsettings.Controls.Add(Me.Label1)
        Me.pnlsettings.Controls.Add(Me.btnclearhist)
        Me.pnlsettings.Controls.Add(Me.txtspeedlimiter)
        Me.pnlsettings.Controls.Add(Me.btnsavefolder)
        Me.pnlsettings.Controls.Add(Me.lbldownloadspeedtitle)
        Me.pnlsettings.Controls.Add(Me.lbldownloadlocationtitle)
        Me.pnlsettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlsettings.Location = New System.Drawing.Point(0, 25)
        Me.pnlsettings.Name = "pnlsettings"
        Me.pnlsettings.Size = New System.Drawing.Size(498, 195)
        Me.pnlsettings.TabIndex = 8
        '
        'btnclearhist
        '
        Me.btnclearhist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclearhist.Location = New System.Drawing.Point(21, 80)
        Me.btnclearhist.Name = "btnclearhist"
        Me.btnclearhist.Size = New System.Drawing.Size(138, 23)
        Me.btnclearhist.TabIndex = 10
        Me.btnclearhist.Text = "Clear Download History"
        Me.btnclearhist.UseVisualStyleBackColor = True
        '
        'txtspeedlimiter
        '
        Me.txtspeedlimiter.Location = New System.Drawing.Point(143, 46)
        Me.txtspeedlimiter.Name = "txtspeedlimiter"
        Me.txtspeedlimiter.Size = New System.Drawing.Size(100, 20)
        Me.txtspeedlimiter.TabIndex = 9
        Me.txtspeedlimiter.Text = "500"
        Me.txtspeedlimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnsavefolder
        '
        Me.btnsavefolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsavefolder.Location = New System.Drawing.Point(128, 10)
        Me.btnsavefolder.Name = "btnsavefolder"
        Me.btnsavefolder.Size = New System.Drawing.Size(194, 23)
        Me.btnsavefolder.TabIndex = 8
        Me.btnsavefolder.Text = "Downloads"
        Me.btnsavefolder.UseVisualStyleBackColor = True
        '
        'lbldownloadspeedtitle
        '
        Me.lbldownloadspeedtitle.AutoSize = True
        Me.lbldownloadspeedtitle.Location = New System.Drawing.Point(18, 49)
        Me.lbldownloadspeedtitle.Name = "lbldownloadspeedtitle"
        Me.lbldownloadspeedtitle.Size = New System.Drawing.Size(119, 13)
        Me.lbldownloadspeedtitle.TabIndex = 4
        Me.lbldownloadspeedtitle.Text = "Download speed limiter:"
        '
        'lbldownloadlocationtitle
        '
        Me.lbldownloadlocationtitle.AutoSize = True
        Me.lbldownloadlocationtitle.Location = New System.Drawing.Point(20, 15)
        Me.lbldownloadlocationtitle.Name = "lbldownloadlocationtitle"
        Me.lbldownloadlocationtitle.Size = New System.Drawing.Size(102, 13)
        Me.lbldownloadlocationtitle.TabIndex = 2
        Me.lbldownloadlocationtitle.Text = "Download Location:"
        '
        'pnldownloads
        '
        Me.pnldownloads.Controls.Add(Me.lblqueueddownloads)
        Me.pnldownloads.Controls.Add(Me.lblqueuetitle)
        Me.pnldownloads.Controls.Add(Me.lbldownloadstitle)
        Me.pnldownloads.Controls.Add(Me.lbldownloadingitems)
        Me.pnldownloads.Location = New System.Drawing.Point(15, 31)
        Me.pnldownloads.Name = "pnldownloads"
        Me.pnldownloads.Size = New System.Drawing.Size(201, 98)
        Me.pnldownloads.TabIndex = 6
        '
        'lblqueueddownloads
        '
        Me.lblqueueddownloads.AutoSize = True
        Me.lblqueueddownloads.Location = New System.Drawing.Point(10, 79)
        Me.lblqueueddownloads.Name = "lblqueueddownloads"
        Me.lblqueueddownloads.Size = New System.Drawing.Size(157, 13)
        Me.lblqueueddownloads.TabIndex = 5
        Me.lblqueueddownloads.Text = "No downloads currently queued"
        '
        'lblqueuetitle
        '
        Me.lblqueuetitle.AutoSize = True
        Me.lblqueuetitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblqueuetitle.Location = New System.Drawing.Point(10, 56)
        Me.lblqueuetitle.Name = "lblqueuetitle"
        Me.lblqueuetitle.Size = New System.Drawing.Size(48, 13)
        Me.lblqueuetitle.TabIndex = 4
        Me.lblqueuetitle.Text = "Queue:"
        '
        'lbldownloadstitle
        '
        Me.lbldownloadstitle.AutoSize = True
        Me.lbldownloadstitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldownloadstitle.Location = New System.Drawing.Point(10, 3)
        Me.lbldownloadstitle.Name = "lbldownloadstitle"
        Me.lbldownloadstitle.Size = New System.Drawing.Size(73, 13)
        Me.lbldownloadstitle.TabIndex = 3
        Me.lbldownloadstitle.Text = "Downloads:"
        '
        'lbldownloadingitems
        '
        Me.lbldownloadingitems.AutoSize = True
        Me.lbldownloadingitems.Location = New System.Drawing.Point(10, 27)
        Me.lbldownloadingitems.Name = "lbldownloadingitems"
        Me.lbldownloadingitems.Size = New System.Drawing.Size(167, 13)
        Me.lbldownloadingitems.TabIndex = 2
        Me.lbldownloadingitems.Text = "No download currently in progress"
        '
        'pnlwelcome
        '
        Me.pnlwelcome.Controls.Add(Me.lblexit)
        Me.pnlwelcome.Controls.Add(Me.lblwelcometext)
        Me.pnlwelcome.Location = New System.Drawing.Point(244, 34)
        Me.pnlwelcome.Name = "pnlwelcome"
        Me.pnlwelcome.Size = New System.Drawing.Size(103, 44)
        Me.pnlwelcome.TabIndex = 5
        '
        'lblexit
        '
        Me.lblexit.BackColor = System.Drawing.Color.White
        Me.lblexit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblexit.Location = New System.Drawing.Point(365, 161)
        Me.lblexit.Name = "lblexit"
        Me.lblexit.Size = New System.Drawing.Size(125, 25)
        Me.lblexit.TabIndex = 5
        Me.lblexit.Text = "Close"
        Me.lblexit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblwelcometext
        '
        Me.lblwelcometext.Location = New System.Drawing.Point(10, 20)
        Me.lblwelcometext.Name = "lblwelcometext"
        Me.lblwelcometext.Size = New System.Drawing.Size(480, 116)
        Me.lblwelcometext.TabIndex = 0
        Me.lblwelcometext.Text = resources.GetString("lblwelcometext.Text")
        '
        'pnlhistory
        '
        Me.pnlhistory.Controls.Add(Me.lblpreviousdownloadstitle)
        Me.pnlhistory.Controls.Add(Me.lblpreviousdownloads)
        Me.pnlhistory.Location = New System.Drawing.Point(23, 135)
        Me.pnlhistory.Name = "pnlhistory"
        Me.pnlhistory.Size = New System.Drawing.Size(162, 72)
        Me.pnlhistory.TabIndex = 7
        '
        'lblpreviousdownloadstitle
        '
        Me.lblpreviousdownloadstitle.AutoSize = True
        Me.lblpreviousdownloadstitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpreviousdownloadstitle.Location = New System.Drawing.Point(10, 3)
        Me.lblpreviousdownloadstitle.Name = "lblpreviousdownloadstitle"
        Me.lblpreviousdownloadstitle.Size = New System.Drawing.Size(126, 13)
        Me.lblpreviousdownloadstitle.TabIndex = 3
        Me.lblpreviousdownloadstitle.Text = "Previous Downloads:"
        Me.lblpreviousdownloadstitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblpreviousdownloads
        '
        Me.lblpreviousdownloads.AutoSize = True
        Me.lblpreviousdownloads.Location = New System.Drawing.Point(10, 27)
        Me.lblpreviousdownloads.Name = "lblpreviousdownloads"
        Me.lblpreviousdownloads.Size = New System.Drawing.Size(121, 13)
        Me.lblpreviousdownloads.TabIndex = 2
        Me.lblpreviousdownloads.Text = "No previous downloads."
        '
        'pnltabbuttons
        '
        Me.pnltabbuttons.Controls.Add(Me.bntsettingtab)
        Me.pnltabbuttons.Controls.Add(Me.bnthistorytab)
        Me.pnltabbuttons.Controls.Add(Me.bntdownloadstab)
        Me.pnltabbuttons.Controls.Add(Me.bntwelcometab)
        Me.pnltabbuttons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnltabbuttons.Location = New System.Drawing.Point(0, 0)
        Me.pnltabbuttons.Name = "pnltabbuttons"
        Me.pnltabbuttons.Size = New System.Drawing.Size(498, 25)
        Me.pnltabbuttons.TabIndex = 4
        '
        'bntsettingtab
        '
        Me.bntsettingtab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntsettingtab.BackColor = System.Drawing.Color.White
        Me.bntsettingtab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bntsettingtab.Location = New System.Drawing.Point(371, 0)
        Me.bntsettingtab.Name = "bntsettingtab"
        Me.bntsettingtab.Size = New System.Drawing.Size(127, 25)
        Me.bntsettingtab.TabIndex = 7
        Me.bntsettingtab.Text = "Settings"
        Me.bntsettingtab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bnthistorytab
        '
        Me.bnthistorytab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnthistorytab.BackColor = System.Drawing.Color.White
        Me.bnthistorytab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bnthistorytab.Location = New System.Drawing.Point(247, 0)
        Me.bnthistorytab.Name = "bnthistorytab"
        Me.bnthistorytab.Size = New System.Drawing.Size(127, 25)
        Me.bnthistorytab.TabIndex = 6
        Me.bnthistorytab.Text = "History"
        Me.bnthistorytab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bntdownloadstab
        '
        Me.bntdownloadstab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntdownloadstab.BackColor = System.Drawing.Color.White
        Me.bntdownloadstab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bntdownloadstab.Location = New System.Drawing.Point(123, 0)
        Me.bntdownloadstab.Name = "bntdownloadstab"
        Me.bntdownloadstab.Size = New System.Drawing.Size(127, 25)
        Me.bntdownloadstab.TabIndex = 5
        Me.bntdownloadstab.Text = "Current Downloads"
        Me.bntdownloadstab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bntwelcometab
        '
        Me.bntwelcometab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntwelcometab.BackColor = System.Drawing.Color.White
        Me.bntwelcometab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bntwelcometab.Location = New System.Drawing.Point(-1, 0)
        Me.bntwelcometab.Name = "bntwelcometab"
        Me.bntwelcometab.Size = New System.Drawing.Size(127, 25)
        Me.bntwelcometab.TabIndex = 4
        Me.bntwelcometab.Text = "Welcome"
        Me.bntwelcometab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 220)
        Me.pgleft.TabIndex = 21
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 218)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(498, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 220)
        Me.pgright.TabIndex = 22
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 218)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgtoprcorner
        '
        Me.pgtoprcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoprcorner.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgtoprcorner.Location = New System.Drawing.Point(498, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgtoplcorner
        '
        Me.pgtoplcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoplcorner.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgtoplcorner.Location = New System.Drawing.Point(0, 0)
        Me.pgtoplcorner.Name = "pgtoplcorner"
        Me.pgtoplcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoplcorner.TabIndex = 17
        '
        'lbtitletext
        '
        Me.lbtitletext.AutoSize = True
        Me.lbtitletext.BackColor = System.Drawing.Color.Transparent
        Me.lbtitletext.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(77, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Template"
        '
        'closebutton
        '
        Me.closebutton.BackColor = System.Drawing.Color.Black
        Me.closebutton.Location = New System.Drawing.Point(302, 3)
        Me.closebutton.Name = "closebutton"
        Me.closebutton.Size = New System.Drawing.Size(22, 22)
        Me.closebutton.TabIndex = 20
        '
        'rollupbutton
        '
        Me.rollupbutton.BackColor = System.Drawing.Color.Black
        Me.rollupbutton.Location = New System.Drawing.Point(274, 3)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'titlebar
        '
        Me.titlebar.BackColor = System.Drawing.Color.Gray
        Me.titlebar.Controls.Add(Me.minimizebutton)
        Me.titlebar.Controls.Add(Me.pnlicon)
        Me.titlebar.Controls.Add(Me.rollupbutton)
        Me.titlebar.Controls.Add(Me.closebutton)
        Me.titlebar.Controls.Add(Me.lbtitletext)
        Me.titlebar.Controls.Add(Me.pgtoplcorner)
        Me.titlebar.Controls.Add(Me.pgtoprcorner)
        Me.titlebar.Dock = System.Windows.Forms.DockStyle.Top
        Me.titlebar.ForeColor = System.Drawing.Color.White
        Me.titlebar.Location = New System.Drawing.Point(0, 0)
        Me.titlebar.Name = "titlebar"
        Me.titlebar.Size = New System.Drawing.Size(500, 30)
        Me.titlebar.TabIndex = 19
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(246, 5)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconTextPad
        Me.pnlicon.Location = New System.Drawing.Point(8, 8)
        Me.pnlicon.Name = "pnlicon"
        Me.pnlicon.Size = New System.Drawing.Size(16, 16)
        Me.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlicon.TabIndex = 24
        Me.pnlicon.TabStop = False
        Me.pnlicon.Visible = False
        '
        'pullside
        '
        Me.pullside.Interval = 1
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 248)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(496, 2)
        Me.pgbottom.TabIndex = 23
        '
        'pullbs
        '
        Me.pullbs.Interval = 1
        '
        'pullbottom
        '
        Me.pullbottom.Interval = 1
        '
        'tmrdownloadspeed
        '
        '
        'tmrapplied
        '
        Me.tmrapplied.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        Me.Label1.Location = New System.Drawing.Point(245, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Kilobytes / second"
        '
        'Downloadmanager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 250)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Downloadmanager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "downloadmanager"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pnlsettings.ResumeLayout(False)
        Me.pnlsettings.PerformLayout()
        Me.pnldownloads.ResumeLayout(False)
        Me.pnldownloads.PerformLayout()
        Me.pnlwelcome.ResumeLayout(False)
        Me.pnlhistory.ResumeLayout(False)
        Me.pnlhistory.PerformLayout()
        Me.pnltabbuttons.ResumeLayout(False)
        Me.pgleft.ResumeLayout(False)
        Me.pgright.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents pnltabbuttons As System.Windows.Forms.Panel
    Friend WithEvents bntsettingtab As System.Windows.Forms.Label
    Friend WithEvents bnthistorytab As System.Windows.Forms.Label
    Friend WithEvents bntdownloadstab As System.Windows.Forms.Label
    Friend WithEvents bntwelcometab As System.Windows.Forms.Label
    Friend WithEvents pnlwelcome As System.Windows.Forms.Panel
    Friend WithEvents lblexit As System.Windows.Forms.Label
    Friend WithEvents lblwelcometext As System.Windows.Forms.Label
    Friend WithEvents pnldownloads As System.Windows.Forms.Panel
    Friend WithEvents lbldownloadingitems As System.Windows.Forms.Label
    Friend WithEvents tmrdownloadspeed As System.Windows.Forms.Timer
    Friend WithEvents lblqueueddownloads As System.Windows.Forms.Label
    Friend WithEvents lblqueuetitle As System.Windows.Forms.Label
    Friend WithEvents lbldownloadstitle As System.Windows.Forms.Label
    Friend WithEvents pnlhistory As System.Windows.Forms.Panel
    Friend WithEvents lblpreviousdownloadstitle As System.Windows.Forms.Label
    Friend WithEvents lblpreviousdownloads As System.Windows.Forms.Label
    Friend WithEvents pnlsettings As System.Windows.Forms.Panel
    Friend WithEvents lbldownloadspeedtitle As System.Windows.Forms.Label
    Friend WithEvents lbldownloadlocationtitle As System.Windows.Forms.Label
    Friend WithEvents tmrapplied As System.Windows.Forms.Timer
    Friend WithEvents btnclearhist As System.Windows.Forms.Button
    Friend WithEvents txtspeedlimiter As System.Windows.Forms.TextBox
    Friend WithEvents btnsavefolder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
