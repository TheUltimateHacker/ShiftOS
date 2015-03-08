<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VirusScanner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VirusScanner))
        Me.pullside = New System.Windows.Forms.Timer(Me.components)
        Me.pullbs = New System.Windows.Forms.Timer(Me.components)
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.grpabout = New System.Windows.Forms.GroupBox()
        Me.lblabout = New System.Windows.Forms.Label()
        Me.grpresults = New System.Windows.Forms.GroupBox()
        Me.btnremoveviruses = New System.Windows.Forms.Button()
        Me.lblresults = New System.Windows.Forms.Label()
        Me.btnsysscan = New System.Windows.Forms.Button()
        Me.btnhomescan = New System.Windows.Forms.Button()
        Me.btnfullscan = New System.Windows.Forms.Button()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.tmrprogress = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar = New ShiftOS.ProgressBarEX()
        Me.pgright.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        Me.grpabout.SuspendLayout()
        Me.grpresults.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pullside
        '
        Me.pullside.Interval = 1
        '
        'pullbs
        '
        Me.pullbs.Interval = 1
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 322)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(341, 2)
        Me.pgbottom.TabIndex = 23
        '
        'pullbottom
        '
        Me.pullbottom.Interval = 1
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(246, 5)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'rollupbutton
        '
        Me.rollupbutton.BackColor = System.Drawing.Color.Black
        Me.rollupbutton.Location = New System.Drawing.Point(274, 3)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 292)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(343, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 294)
        Me.pgright.TabIndex = 22
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
        Me.lbtitletext.Size = New System.Drawing.Size(77, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Template"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(343, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 292)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.ProgressBar)
        Me.pgcontents.Controls.Add(Me.grpabout)
        Me.pgcontents.Controls.Add(Me.grpresults)
        Me.pgcontents.Controls.Add(Me.btnsysscan)
        Me.pgcontents.Controls.Add(Me.btnhomescan)
        Me.pgcontents.Controls.Add(Me.btnfullscan)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(343, 294)
        Me.pgcontents.TabIndex = 20
        '
        'grpabout
        '
        Me.grpabout.Controls.Add(Me.lblabout)
        Me.grpabout.Location = New System.Drawing.Point(191, 12)
        Me.grpabout.Name = "grpabout"
        Me.grpabout.Size = New System.Drawing.Size(139, 274)
        Me.grpabout.TabIndex = 5
        Me.grpabout.TabStop = False
        Me.grpabout.Text = "About"
        '
        'lblabout
        '
        Me.lblabout.Location = New System.Drawing.Point(6, 20)
        Me.lblabout.Name = "lblabout"
        Me.lblabout.Size = New System.Drawing.Size(125, 251)
        Me.lblabout.TabIndex = 0
        Me.lblabout.Text = resources.GetString("lblabout.Text")
        '
        'grpresults
        '
        Me.grpresults.Controls.Add(Me.btnremoveviruses)
        Me.grpresults.Controls.Add(Me.lblresults)
        Me.grpresults.Location = New System.Drawing.Point(6, 99)
        Me.grpresults.Name = "grpresults"
        Me.grpresults.Size = New System.Drawing.Size(179, 158)
        Me.grpresults.TabIndex = 3
        Me.grpresults.TabStop = False
        Me.grpresults.Text = "Scan Results"
        '
        'btnremoveviruses
        '
        Me.btnremoveviruses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnremoveviruses.Location = New System.Drawing.Point(4, 129)
        Me.btnremoveviruses.Name = "btnremoveviruses"
        Me.btnremoveviruses.Size = New System.Drawing.Size(164, 23)
        Me.btnremoveviruses.TabIndex = 1
        Me.btnremoveviruses.Text = "Remove"
        Me.btnremoveviruses.UseVisualStyleBackColor = True
        Me.btnremoveviruses.Visible = False
        '
        'lblresults
        '
        Me.lblresults.Location = New System.Drawing.Point(6, 20)
        Me.lblresults.Name = "lblresults"
        Me.lblresults.Size = New System.Drawing.Size(167, 106)
        Me.lblresults.TabIndex = 0
        Me.lblresults.Text = "No scan yet completed"
        '
        'btnsysscan
        '
        Me.btnsysscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsysscan.Location = New System.Drawing.Point(10, 70)
        Me.btnsysscan.Name = "btnsysscan"
        Me.btnsysscan.Size = New System.Drawing.Size(175, 23)
        Me.btnsysscan.TabIndex = 2
        Me.btnsysscan.Text = "Scan System files"
        Me.btnsysscan.UseVisualStyleBackColor = True
        '
        'btnhomescan
        '
        Me.btnhomescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnhomescan.Location = New System.Drawing.Point(10, 41)
        Me.btnhomescan.Name = "btnhomescan"
        Me.btnhomescan.Size = New System.Drawing.Size(175, 23)
        Me.btnhomescan.TabIndex = 1
        Me.btnhomescan.Text = "Scan Home Folder"
        Me.btnhomescan.UseVisualStyleBackColor = True
        '
        'btnfullscan
        '
        Me.btnfullscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnfullscan.Location = New System.Drawing.Point(10, 12)
        Me.btnfullscan.Name = "btnfullscan"
        Me.btnfullscan.Size = New System.Drawing.Size(175, 23)
        Me.btnfullscan.TabIndex = 0
        Me.btnfullscan.Text = "Start System Wide Scan (slow)"
        Me.btnfullscan.UseVisualStyleBackColor = True
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 294)
        Me.pgleft.TabIndex = 21
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
        Me.titlebar.Size = New System.Drawing.Size(345, 30)
        Me.titlebar.TabIndex = 19
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Location = New System.Drawing.Point(8, 8)
        Me.pnlicon.Name = "pnlicon"
        Me.pnlicon.Size = New System.Drawing.Size(16, 16)
        Me.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlicon.TabIndex = 24
        Me.pnlicon.TabStop = False
        Me.pnlicon.Visible = False
        '
        'tmrprogress
        '
        '
        'ProgressBar
        '
        Me.ProgressBar.BackColor = System.Drawing.Color.White
        Me.ProgressBar.BlockSeparation = 3
        Me.ProgressBar.BlockWidth = 5
        Me.ProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProgressBar.Color = System.Drawing.Color.Gray
        Me.ProgressBar.Location = New System.Drawing.Point(10, 263)
        Me.ProgressBar.MaxValue = 100
        Me.ProgressBar.MinValue = 0
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal
        Me.ProgressBar.ShowValue = False
        Me.ProgressBar.Size = New System.Drawing.Size(175, 23)
        Me.ProgressBar.Step = 10
        Me.ProgressBar.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous
        Me.ProgressBar.TabIndex = 1
        Me.ProgressBar.Value = 0
        '
        'VirusScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 324)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VirusScanner"
        Me.Text = "VirusScanner"
        Me.TopMost = True
        Me.pgright.ResumeLayout(False)
        Me.pgcontents.ResumeLayout(False)
        Me.grpabout.ResumeLayout(False)
        Me.grpresults.ResumeLayout(False)
        Me.pgleft.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents grpresults As System.Windows.Forms.GroupBox
    Friend WithEvents btnsysscan As System.Windows.Forms.Button
    Friend WithEvents btnhomescan As System.Windows.Forms.Button
    Friend WithEvents btnfullscan As System.Windows.Forms.Button
    Friend WithEvents lblresults As System.Windows.Forms.Label
    Friend WithEvents grpabout As System.Windows.Forms.GroupBox
    Friend WithEvents lblabout As System.Windows.Forms.Label
    Friend WithEvents tmrprogress As System.Windows.Forms.Timer
    Friend WithEvents btnremoveviruses As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As ShiftOS.ProgressBarEX
End Class
