<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pong
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pong))
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.pnlintro = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnstartgame = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnllose = New System.Windows.Forms.Panel()
        Me.lblmissedout = New System.Windows.Forms.Label()
        Me.btnlosetryagain = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlgamestats = New System.Windows.Forms.Panel()
        Me.lblnextstats = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblpreviousstats = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnplayon = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btncashout = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbllevelreached = New System.Windows.Forms.Label()
        Me.pnlfinalstats = New System.Windows.Forms.Panel()
        Me.btnplayagain = New System.Windows.Forms.Button()
        Me.lblfinalcodepoints = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblfinalcomputerreward = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblfinallevelreward = New System.Windows.Forms.Label()
        Me.lblfinallevelreached = New System.Windows.Forms.Label()
        Me.lblfinalcodepointswithtext = New System.Windows.Forms.Label()
        Me.lblbeatai = New System.Windows.Forms.Label()
        Me.lblcountdown = New System.Windows.Forms.Label()
        Me.ball = New System.Windows.Forms.Panel()
        Me.paddleHuman = New System.Windows.Forms.PictureBox()
        Me.paddleComputer = New System.Windows.Forms.Panel()
        Me.lbllevelandtime = New System.Windows.Forms.Label()
        Me.lblstatscodepoints = New System.Windows.Forms.Label()
        Me.lblstatsY = New System.Windows.Forms.Label()
        Me.lblstatsX = New System.Windows.Forms.Label()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.lblstorylinechancedebug = New System.Windows.Forms.Label()
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.gameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.counter = New System.Windows.Forms.Timer(Me.components)
        Me.tmrcountdown = New System.Windows.Forms.Timer(Me.components)
        Me.tmrstoryline = New System.Windows.Forms.Timer(Me.components)
        Me.pgcontents.SuspendLayout()
        Me.pnlintro.SuspendLayout()
        Me.pnllose.SuspendLayout()
        Me.pnlgamestats.SuspendLayout()
        Me.pnlfinalstats.SuspendLayout()
        CType(Me.paddleHuman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgleft.SuspendLayout()
        Me.pgright.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.pnlintro)
        Me.pgcontents.Controls.Add(Me.pnllose)
        Me.pgcontents.Controls.Add(Me.pnlgamestats)
        Me.pgcontents.Controls.Add(Me.pnlfinalstats)
        Me.pgcontents.Controls.Add(Me.lblbeatai)
        Me.pgcontents.Controls.Add(Me.lblcountdown)
        Me.pgcontents.Controls.Add(Me.ball)
        Me.pgcontents.Controls.Add(Me.paddleHuman)
        Me.pgcontents.Controls.Add(Me.paddleComputer)
        Me.pgcontents.Controls.Add(Me.lbllevelandtime)
        Me.pgcontents.Controls.Add(Me.lblstatscodepoints)
        Me.pgcontents.Controls.Add(Me.lblstatsY)
        Me.pgcontents.Controls.Add(Me.lblstatsX)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(696, 368)
        Me.pgcontents.TabIndex = 20
        '
        'pnlintro
        '
        Me.pnlintro.Controls.Add(Me.Label6)
        Me.pnlintro.Controls.Add(Me.btnstartgame)
        Me.pnlintro.Controls.Add(Me.Label8)
        Me.pnlintro.Location = New System.Drawing.Point(52, 29)
        Me.pnlintro.Name = "pnlintro"
        Me.pnlintro.Size = New System.Drawing.Size(595, 303)
        Me.pnlintro.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(589, 227)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = resources.GetString("Label6.Text")
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnstartgame
        '
        Me.btnstartgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnstartgame.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstartgame.Location = New System.Drawing.Point(186, 273)
        Me.btnstartgame.Name = "btnstartgame"
        Me.btnstartgame.Size = New System.Drawing.Size(242, 28)
        Me.btnstartgame.TabIndex = 15
        Me.btnstartgame.Text = "Click this button to play pong!"
        Me.btnstartgame.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(179, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(250, 31)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Welcome to Pong!"
        '
        'pnllose
        '
        Me.pnllose.Controls.Add(Me.lblmissedout)
        Me.pnllose.Controls.Add(Me.btnlosetryagain)
        Me.pnllose.Controls.Add(Me.Label5)
        Me.pnllose.Controls.Add(Me.Label1)
        Me.pnllose.Location = New System.Drawing.Point(209, 71)
        Me.pnllose.Name = "pnllose"
        Me.pnllose.Size = New System.Drawing.Size(266, 214)
        Me.pnllose.TabIndex = 10
        Me.pnllose.Visible = False
        '
        'lblmissedout
        '
        Me.lblmissedout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmissedout.Location = New System.Drawing.Point(3, 175)
        Me.lblmissedout.Name = "lblmissedout"
        Me.lblmissedout.Size = New System.Drawing.Size(146, 35)
        Me.lblmissedout.TabIndex = 3
        Me.lblmissedout.Text = "You Missed Out On:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "500 Codepoints"
        Me.lblmissedout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnlosetryagain
        '
        Me.btnlosetryagain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlosetryagain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlosetryagain.Location = New System.Drawing.Point(155, 176)
        Me.btnlosetryagain.Name = "btnlosetryagain"
        Me.btnlosetryagain.Size = New System.Drawing.Size(106, 35)
        Me.btnlosetryagain.TabIndex = 2
        Me.btnlosetryagain.Text = "Try Again"
        Me.btnlosetryagain.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(260, 163)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unfortunately you just lost the game..."
        '
        'pnlgamestats
        '
        Me.pnlgamestats.Controls.Add(Me.lblnextstats)
        Me.pnlgamestats.Controls.Add(Me.Label7)
        Me.pnlgamestats.Controls.Add(Me.lblpreviousstats)
        Me.pnlgamestats.Controls.Add(Me.Label4)
        Me.pnlgamestats.Controls.Add(Me.btnplayon)
        Me.pnlgamestats.Controls.Add(Me.Label3)
        Me.pnlgamestats.Controls.Add(Me.btncashout)
        Me.pnlgamestats.Controls.Add(Me.Label2)
        Me.pnlgamestats.Controls.Add(Me.lbllevelreached)
        Me.pnlgamestats.Location = New System.Drawing.Point(122, 84)
        Me.pnlgamestats.Name = "pnlgamestats"
        Me.pnlgamestats.Size = New System.Drawing.Size(466, 206)
        Me.pnlgamestats.TabIndex = 6
        Me.pnlgamestats.Visible = False
        '
        'lblnextstats
        '
        Me.lblnextstats.AutoSize = True
        Me.lblnextstats.Location = New System.Drawing.Point(278, 136)
        Me.lblnextstats.Name = "lblnextstats"
        Me.lblnextstats.Size = New System.Drawing.Size(119, 52)
        Me.lblnextstats.TabIndex = 8
        Me.lblnextstats.Text = "Initial Ball X Speed: 6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Initial Ball Y Speed: 9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Increment X Speed: 0.5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Increme" & _
    "nt Y Speed: 0.9"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(278, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Next Level Stats:"
        '
        'lblpreviousstats
        '
        Me.lblpreviousstats.AutoSize = True
        Me.lblpreviousstats.Location = New System.Drawing.Point(278, 54)
        Me.lblpreviousstats.Name = "lblpreviousstats"
        Me.lblpreviousstats.Size = New System.Drawing.Size(119, 52)
        Me.lblpreviousstats.TabIndex = 6
        Me.lblpreviousstats.Text = "Initial Ball X Speed: 5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Initial Ball Y Speed: 7" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Increment X Speed: 0.3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Increme" & _
    "nt Y Speed: 0.6"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(278, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Previous Level Stats:"
        '
        'btnplayon
        '
        Me.btnplayon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnplayon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnplayon.Location = New System.Drawing.Point(32, 162)
        Me.btnplayon.Name = "btnplayon"
        Me.btnplayon.Size = New System.Drawing.Size(191, 35)
        Me.btnplayon.TabIndex = 4
        Me.btnplayon.Text = "Play on for 3 codepoints!"
        Me.btnplayon.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(245, 33)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Or do you want to try your luck on the next level to increase your reward?"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncashout
        '
        Me.btncashout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncashout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncashout.Location = New System.Drawing.Point(32, 73)
        Me.btncashout.Name = "btncashout"
        Me.btncashout.Size = New System.Drawing.Size(191, 35)
        Me.btncashout.TabIndex = 2
        Me.btncashout.Text = "Cash out with 1 codepoint!"
        Me.btncashout.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Would you like the end the game now and cash out with your reward?"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbllevelreached
        '
        Me.lbllevelreached.AutoSize = True
        Me.lbllevelreached.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllevelreached.Location = New System.Drawing.Point(149, 6)
        Me.lbllevelreached.Name = "lbllevelreached"
        Me.lbllevelreached.Size = New System.Drawing.Size(185, 20)
        Me.lbllevelreached.TabIndex = 0
        Me.lbllevelreached.Text = "You Reached Level 2!"
        '
        'pnlfinalstats
        '
        Me.pnlfinalstats.Controls.Add(Me.btnplayagain)
        Me.pnlfinalstats.Controls.Add(Me.lblfinalcodepoints)
        Me.pnlfinalstats.Controls.Add(Me.Label11)
        Me.pnlfinalstats.Controls.Add(Me.lblfinalcomputerreward)
        Me.pnlfinalstats.Controls.Add(Me.Label9)
        Me.pnlfinalstats.Controls.Add(Me.lblfinallevelreward)
        Me.pnlfinalstats.Controls.Add(Me.lblfinallevelreached)
        Me.pnlfinalstats.Controls.Add(Me.lblfinalcodepointswithtext)
        Me.pnlfinalstats.Location = New System.Drawing.Point(172, 74)
        Me.pnlfinalstats.Name = "pnlfinalstats"
        Me.pnlfinalstats.Size = New System.Drawing.Size(362, 226)
        Me.pnlfinalstats.TabIndex = 9
        Me.pnlfinalstats.Visible = False
        '
        'btnplayagain
        '
        Me.btnplayagain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnplayagain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnplayagain.Location = New System.Drawing.Point(5, 194)
        Me.btnplayagain.Name = "btnplayagain"
        Me.btnplayagain.Size = New System.Drawing.Size(352, 29)
        Me.btnplayagain.TabIndex = 16
        Me.btnplayagain.Text = "Click this button to play again!"
        Me.btnplayagain.UseVisualStyleBackColor = True
        '
        'lblfinalcodepoints
        '
        Me.lblfinalcodepoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinalcodepoints.Location = New System.Drawing.Point(3, 124)
        Me.lblfinalcodepoints.Name = "lblfinalcodepoints"
        Me.lblfinalcodepoints.Size = New System.Drawing.Size(356, 73)
        Me.lblfinalcodepoints.TabIndex = 15
        Me.lblfinalcodepoints.Text = "134 CP"
        Me.lblfinalcodepoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(162, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 33)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "+"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfinalcomputerreward
        '
        Me.lblfinalcomputerreward.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinalcomputerreward.Location = New System.Drawing.Point(193, 72)
        Me.lblfinalcomputerreward.Name = "lblfinalcomputerreward"
        Me.lblfinalcomputerreward.Size = New System.Drawing.Size(151, 52)
        Me.lblfinalcomputerreward.TabIndex = 12
        Me.lblfinalcomputerreward.Text = "34"
        Me.lblfinalcomputerreward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(179, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 49)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Codepoints rewarded for beating the Computer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfinallevelreward
        '
        Me.lblfinallevelreward.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinallevelreward.Location = New System.Drawing.Point(12, 72)
        Me.lblfinallevelreward.Name = "lblfinallevelreward"
        Me.lblfinallevelreward.Size = New System.Drawing.Size(151, 52)
        Me.lblfinallevelreward.TabIndex = 10
        Me.lblfinallevelreward.Text = "100"
        Me.lblfinallevelreward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfinallevelreached
        '
        Me.lblfinallevelreached.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinallevelreached.Location = New System.Drawing.Point(3, 31)
        Me.lblfinallevelreached.Name = "lblfinallevelreached"
        Me.lblfinallevelreached.Size = New System.Drawing.Size(170, 49)
        Me.lblfinallevelreached.TabIndex = 9
        Me.lblfinallevelreached.Text = "Codepoints rewarded for reaching level 10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblfinallevelreached.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfinalcodepointswithtext
        '
        Me.lblfinalcodepointswithtext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinalcodepointswithtext.Location = New System.Drawing.Point(3, 2)
        Me.lblfinalcodepointswithtext.Name = "lblfinalcodepointswithtext"
        Me.lblfinalcodepointswithtext.Size = New System.Drawing.Size(356, 26)
        Me.lblfinalcodepointswithtext.TabIndex = 1
        Me.lblfinalcodepointswithtext.Text = "You cashed out with 134 codepoints!"
        Me.lblfinalcodepointswithtext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblbeatai
        '
        Me.lblbeatai.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbeatai.Location = New System.Drawing.Point(47, 41)
        Me.lblbeatai.Name = "lblbeatai"
        Me.lblbeatai.Size = New System.Drawing.Size(600, 30)
        Me.lblbeatai.TabIndex = 8
        Me.lblbeatai.Text = "You got 2 codepoints for beating the Computer!"
        Me.lblbeatai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblbeatai.Visible = False
        '
        'lblcountdown
        '
        Me.lblcountdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcountdown.Location = New System.Drawing.Point(182, 152)
        Me.lblcountdown.Name = "lblcountdown"
        Me.lblcountdown.Size = New System.Drawing.Size(315, 49)
        Me.lblcountdown.TabIndex = 7
        Me.lblcountdown.Text = "3"
        Me.lblcountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblcountdown.Visible = False
        '
        'ball
        '
        Me.ball.BackColor = System.Drawing.Color.Black
        Me.ball.Location = New System.Drawing.Point(300, 152)
        Me.ball.Name = "ball"
        Me.ball.Size = New System.Drawing.Size(20, 20)
        Me.ball.TabIndex = 2
        '
        'paddleHuman
        '
        Me.paddleHuman.BackColor = System.Drawing.Color.Black
        Me.paddleHuman.Location = New System.Drawing.Point(10, 134)
        Me.paddleHuman.Name = "paddleHuman"
        Me.paddleHuman.Size = New System.Drawing.Size(20, 100)
        Me.paddleHuman.TabIndex = 3
        Me.paddleHuman.TabStop = False
        '
        'paddleComputer
        '
        Me.paddleComputer.BackColor = System.Drawing.Color.Black
        Me.paddleComputer.Location = New System.Drawing.Point(666, 134)
        Me.paddleComputer.Name = "paddleComputer"
        Me.paddleComputer.Size = New System.Drawing.Size(20, 100)
        Me.paddleComputer.TabIndex = 1
        '
        'lbllevelandtime
        '
        Me.lbllevelandtime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllevelandtime.Location = New System.Drawing.Point(6, 3)
        Me.lbllevelandtime.Name = "lbllevelandtime"
        Me.lbllevelandtime.Size = New System.Drawing.Size(684, 22)
        Me.lbllevelandtime.TabIndex = 4
        Me.lbllevelandtime.Text = "Level: 1 - 58 Seconds Left"
        Me.lbllevelandtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblstatscodepoints
        '
        Me.lblstatscodepoints.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatscodepoints.Location = New System.Drawing.Point(237, 335)
        Me.lblstatscodepoints.Name = "lblstatscodepoints"
        Me.lblstatscodepoints.Size = New System.Drawing.Size(219, 35)
        Me.lblstatscodepoints.TabIndex = 12
        Me.lblstatscodepoints.Text = "Codepoints: "
        Me.lblstatscodepoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblstatsY
        '
        Me.lblstatsY.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatsY.Location = New System.Drawing.Point(541, 335)
        Me.lblstatsY.Name = "lblstatsY"
        Me.lblstatsY.Size = New System.Drawing.Size(144, 35)
        Me.lblstatsY.TabIndex = 11
        Me.lblstatsY.Text = "Yspeed:"
        Me.lblstatsY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblstatsX
        '
        Me.lblstatsX.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatsX.Location = New System.Drawing.Point(6, 335)
        Me.lblstatsX.Name = "lblstatsX"
        Me.lblstatsX.Size = New System.Drawing.Size(144, 35)
        Me.lblstatsX.TabIndex = 5
        Me.lblstatsX.Text = "Xspeed: "
        Me.lblstatsX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 370)
        Me.pgleft.TabIndex = 21
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 368)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(698, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 370)
        Me.pgright.TabIndex = 22
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 368)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'titlebar
        '
        Me.titlebar.BackColor = System.Drawing.Color.Gray
        Me.titlebar.Controls.Add(Me.lblstorylinechancedebug)
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
        Me.titlebar.Size = New System.Drawing.Size(700, 30)
        Me.titlebar.TabIndex = 19
        '
        'lblstorylinechancedebug
        '
        Me.lblstorylinechancedebug.AutoSize = True
        Me.lblstorylinechancedebug.Location = New System.Drawing.Point(473, 8)
        Me.lblstorylinechancedebug.Name = "lblstorylinechancedebug"
        Me.lblstorylinechancedebug.Size = New System.Drawing.Size(121, 13)
        Me.lblstorylinechancedebug.TabIndex = 25
        Me.lblstorylinechancedebug.Text = "lblstorylinechancedebug"
        Me.lblstorylinechancedebug.Visible = False
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(246, 3)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconPong
        Me.pnlicon.Location = New System.Drawing.Point(8, 8)
        Me.pnlicon.Name = "pnlicon"
        Me.pnlicon.Size = New System.Drawing.Size(16, 16)
        Me.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlicon.TabIndex = 24
        Me.pnlicon.TabStop = False
        Me.pnlicon.Visible = False
        '
        'rollupbutton
        '
        Me.rollupbutton.BackColor = System.Drawing.Color.Black
        Me.rollupbutton.Location = New System.Drawing.Point(274, 3)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'closebutton
        '
        Me.closebutton.BackColor = System.Drawing.Color.Black
        Me.closebutton.Location = New System.Drawing.Point(302, 3)
        Me.closebutton.Name = "closebutton"
        Me.closebutton.Size = New System.Drawing.Size(22, 22)
        Me.closebutton.TabIndex = 20
        '
        'lbtitletext
        '
        Me.lbtitletext.AutoSize = True
        Me.lbtitletext.BackColor = System.Drawing.Color.Transparent
        Me.lbtitletext.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(47, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Pong"
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
        'pgtoprcorner
        '
        Me.pgtoprcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoprcorner.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgtoprcorner.Location = New System.Drawing.Point(698, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 398)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(696, 2)
        Me.pgbottom.TabIndex = 23
        '
        'gameTimer
        '
        Me.gameTimer.Interval = 30
        '
        'counter
        '
        Me.counter.Interval = 1000
        '
        'tmrcountdown
        '
        Me.tmrcountdown.Interval = 1000
        '
        'tmrstoryline
        '
        Me.tmrstoryline.Interval = 1000
        '
        'Pong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(700, 400)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.titlebar)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Pong"
        Me.Text = "Pong"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pnlintro.ResumeLayout(False)
        Me.pnlintro.PerformLayout()
        Me.pnllose.ResumeLayout(False)
        Me.pnllose.PerformLayout()
        Me.pnlgamestats.ResumeLayout(False)
        Me.pnlgamestats.PerformLayout()
        Me.pnlfinalstats.ResumeLayout(False)
        Me.pnlfinalstats.PerformLayout()
        CType(Me.paddleHuman, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents ball As System.Windows.Forms.Panel
    Friend WithEvents paddleComputer As System.Windows.Forms.Panel
    Friend WithEvents gameTimer As System.Windows.Forms.Timer
    Friend WithEvents paddleHuman As System.Windows.Forms.PictureBox
    Friend WithEvents lbllevelandtime As System.Windows.Forms.Label
    Friend WithEvents lblstatsX As System.Windows.Forms.Label
    Friend WithEvents counter As System.Windows.Forms.Timer
    Friend WithEvents pnlgamestats As System.Windows.Forms.Panel
    Friend WithEvents lblnextstats As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblpreviousstats As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnplayon As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btncashout As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbllevelreached As System.Windows.Forms.Label
    Friend WithEvents lblcountdown As System.Windows.Forms.Label
    Friend WithEvents tmrcountdown As System.Windows.Forms.Timer
    Friend WithEvents lblbeatai As System.Windows.Forms.Label
    Friend WithEvents pnlfinalstats As System.Windows.Forms.Panel
    Friend WithEvents btnplayagain As System.Windows.Forms.Button
    Friend WithEvents lblfinalcodepoints As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblfinalcomputerreward As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblfinallevelreward As System.Windows.Forms.Label
    Friend WithEvents lblfinallevelreached As System.Windows.Forms.Label
    Friend WithEvents lblfinalcodepointswithtext As System.Windows.Forms.Label
    Friend WithEvents pnllose As System.Windows.Forms.Panel
    Friend WithEvents lblmissedout As System.Windows.Forms.Label
    Friend WithEvents btnlosetryagain As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblstatscodepoints As System.Windows.Forms.Label
    Friend WithEvents lblstatsY As System.Windows.Forms.Label
    Friend WithEvents pnlintro As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnstartgame As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents tmrstoryline As System.Windows.Forms.Timer
    Friend WithEvents lblstorylinechancedebug As System.Windows.Forms.Label
End Class
