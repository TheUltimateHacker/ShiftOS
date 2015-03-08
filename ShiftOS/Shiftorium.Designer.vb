<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shiftorium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shiftorium))
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.lbcodepoints = New System.Windows.Forms.Label()
        Me.lbupgrades = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlinfo = New System.Windows.Forms.Panel()
        Me.pnlintro = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnbuy = New System.Windows.Forms.Button()
        Me.lbprice = New System.Windows.Forms.Label()
        Me.picpreview = New System.Windows.Forms.PictureBox()
        Me.lbudescription = New System.Windows.Forms.Label()
        Me.lbupgradename = New System.Windows.Forms.Label()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.tmrcodepointsupdate = New System.Windows.Forms.Timer(Me.components)
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.pgcontents.SuspendLayout()
        Me.pnlinfo.SuspendLayout()
        Me.pnlintro.SuspendLayout()
        CType(Me.picpreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgleft.SuspendLayout()
        Me.pgright.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.lbcodepoints)
        Me.pgcontents.Controls.Add(Me.lbupgrades)
        Me.pgcontents.Controls.Add(Me.Label1)
        Me.pgcontents.Controls.Add(Me.pnlinfo)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(697, 430)
        Me.pgcontents.TabIndex = 0
        Me.pgcontents.TabStop = True
        '
        'lbcodepoints
        '
        Me.lbcodepoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcodepoints.ForeColor = System.Drawing.Color.Black
        Me.lbcodepoints.Location = New System.Drawing.Point(16, 372)
        Me.lbcodepoints.Name = "lbcodepoints"
        Me.lbcodepoints.Size = New System.Drawing.Size(309, 43)
        Me.lbcodepoints.TabIndex = 8
        Me.lbcodepoints.Text = "Codepoints: 25"
        Me.lbcodepoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbupgrades
        '
        Me.lbupgrades.BackColor = System.Drawing.Color.White
        Me.lbupgrades.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbupgrades.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbupgrades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbupgrades.ForeColor = System.Drawing.Color.Black
        Me.lbupgrades.FormattingEnabled = True
        Me.lbupgrades.ItemHeight = 19
        Me.lbupgrades.Items.AddRange(New Object() {"Title Bar - 80 CP", "Program Titles - 60 CP", "Seconds Since Midnight - 10 CP", "Close Button - 100 CP", "Shifter - 500 CP", "Gray - 50 CP"})
        Me.lbupgrades.Location = New System.Drawing.Point(21, 70)
        Me.lbupgrades.Name = "lbupgrades"
        Me.lbupgrades.Size = New System.Drawing.Size(304, 285)
        Me.lbupgrades.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(85, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 39)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Upgrades"
        '
        'pnlinfo
        '
        Me.pnlinfo.Controls.Add(Me.pnlintro)
        Me.pnlinfo.Controls.Add(Me.btnbuy)
        Me.pnlinfo.Controls.Add(Me.lbprice)
        Me.pnlinfo.Controls.Add(Me.picpreview)
        Me.pnlinfo.Controls.Add(Me.lbudescription)
        Me.pnlinfo.Controls.Add(Me.lbupgradename)
        Me.pnlinfo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlinfo.Location = New System.Drawing.Point(328, 0)
        Me.pnlinfo.Name = "pnlinfo"
        Me.pnlinfo.Size = New System.Drawing.Size(369, 430)
        Me.pnlinfo.TabIndex = 0
        '
        'pnlintro
        '
        Me.pnlintro.Controls.Add(Me.Label4)
        Me.pnlintro.Controls.Add(Me.Label2)
        Me.pnlintro.Controls.Add(Me.Label5)
        Me.pnlintro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlintro.Location = New System.Drawing.Point(0, 0)
        Me.pnlintro.Name = "pnlintro"
        Me.pnlintro.Size = New System.Drawing.Size(369, 430)
        Me.pnlintro.TabIndex = 8
        Me.pnlintro.TabStop = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-3, 397)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(358, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Select an upgrade on the left to view its details"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(340, 341)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(-4, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(355, 31)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Welcome to the Shiftorium"
        '
        'btnbuy
        '
        Me.btnbuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbuy.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbuy.ForeColor = System.Drawing.Color.Black
        Me.btnbuy.Location = New System.Drawing.Point(160, 362)
        Me.btnbuy.Name = "btnbuy"
        Me.btnbuy.Size = New System.Drawing.Size(185, 56)
        Me.btnbuy.TabIndex = 7
        Me.btnbuy.Text = "Buy"
        Me.btnbuy.UseVisualStyleBackColor = True
        '
        'lbprice
        '
        Me.lbprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbprice.ForeColor = System.Drawing.Color.Black
        Me.lbprice.Location = New System.Drawing.Point(15, 362)
        Me.lbprice.Name = "lbprice"
        Me.lbprice.Size = New System.Drawing.Size(139, 59)
        Me.lbprice.TabIndex = 6
        Me.lbprice.Text = "50 CP"
        Me.lbprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picpreview
        '
        Me.picpreview.Image = Global.ShiftOS.My.Resources.Resources.upgradegray
        Me.picpreview.Location = New System.Drawing.Point(25, 218)
        Me.picpreview.Name = "picpreview"
        Me.picpreview.Size = New System.Drawing.Size(320, 130)
        Me.picpreview.TabIndex = 5
        Me.picpreview.TabStop = False
        '
        'lbudescription
        '
        Me.lbudescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbudescription.ForeColor = System.Drawing.Color.Black
        Me.lbudescription.Location = New System.Drawing.Point(24, 63)
        Me.lbudescription.Name = "lbudescription"
        Me.lbudescription.Size = New System.Drawing.Size(321, 144)
        Me.lbudescription.TabIndex = 4
        Me.lbudescription.Text = resources.GetString("lbudescription.Text")
        Me.lbudescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbupgradename
        '
        Me.lbupgradename.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbupgradename.ForeColor = System.Drawing.Color.Black
        Me.lbupgradename.Location = New System.Drawing.Point(5, 17)
        Me.lbupgradename.Name = "lbupgradename"
        Me.lbupgradename.Size = New System.Drawing.Size(361, 43)
        Me.lbupgradename.TabIndex = 3
        Me.lbupgradename.Text = "Upgradename"
        Me.lbupgradename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.titlebar.Size = New System.Drawing.Size(701, 30)
        Me.titlebar.TabIndex = 11
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(283, 2)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconShiftorium
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
        Me.rollupbutton.Location = New System.Drawing.Point(311, 4)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'closebutton
        '
        Me.closebutton.BackColor = System.Drawing.Color.Black
        Me.closebutton.Location = New System.Drawing.Point(339, 4)
        Me.closebutton.Name = "closebutton"
        Me.closebutton.Size = New System.Drawing.Size(22, 22)
        Me.closebutton.TabIndex = 21
        '
        'lbtitletext
        '
        Me.lbtitletext.AutoSize = True
        Me.lbtitletext.BackColor = System.Drawing.Color.Transparent
        Me.lbtitletext.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(85, 18)
        Me.lbtitletext.TabIndex = 20
        Me.lbtitletext.Text = "Shiftorium"
        '
        'pgtoplcorner
        '
        Me.pgtoplcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoplcorner.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgtoplcorner.Location = New System.Drawing.Point(0, 0)
        Me.pgtoplcorner.Name = "pgtoplcorner"
        Me.pgtoplcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoplcorner.TabIndex = 19
        '
        'pgtoprcorner
        '
        Me.pgtoprcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoprcorner.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgtoprcorner.Location = New System.Drawing.Point(699, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 18
        '
        'tmrcodepointsupdate
        '
        Me.tmrcodepointsupdate.Enabled = True
        Me.tmrcodepointsupdate.Interval = 1000
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 432)
        Me.pgleft.TabIndex = 12
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 430)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(699, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 432)
        Me.pgright.TabIndex = 13
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 430)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 460)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(697, 2)
        Me.pgbottom.TabIndex = 14
        '
        'Shiftorium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(701, 462)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Shiftorium"
        Me.Text = "Shiftorium"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pgcontents.PerformLayout()
        Me.pnlinfo.ResumeLayout(False)
        Me.pnlintro.ResumeLayout(False)
        Me.pnlintro.PerformLayout()
        CType(Me.picpreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgleft.ResumeLayout(False)
        Me.pgright.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents lbupgrades As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlinfo As System.Windows.Forms.Panel
    Friend WithEvents lbcodepoints As System.Windows.Forms.Label
    Friend WithEvents btnbuy As System.Windows.Forms.Button
    Friend WithEvents lbprice As System.Windows.Forms.Label
    Friend WithEvents picpreview As System.Windows.Forms.PictureBox
    Friend WithEvents lbudescription As System.Windows.Forms.Label
    Friend WithEvents lbupgradename As System.Windows.Forms.Label
    Friend WithEvents pnlintro As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tmrcodepointsupdate As System.Windows.Forms.Timer
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
End Class
