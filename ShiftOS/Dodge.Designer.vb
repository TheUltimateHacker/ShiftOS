<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dodge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dodge))
        Me.pgbottom = New System.Windows.Forms.Panel()
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
        Me.player = New System.Windows.Forms.PictureBox()
        Me.QuitButton = New System.Windows.Forms.PictureBox()
        Me.BeginButton = New System.Windows.Forms.PictureBox()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.object_small2 = New System.Windows.Forms.PictureBox()
        Me.object_mid2 = New System.Windows.Forms.PictureBox()
        Me.object_large = New System.Windows.Forms.PictureBox()
        Me.object_small = New System.Windows.Forms.PictureBox()
        Me.object_mid = New System.Windows.Forms.PictureBox()
        Me.scorelabel = New System.Windows.Forms.Label()
        Me.PicBonus = New System.Windows.Forms.PictureBox()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.clock = New System.Windows.Forms.Timer(Me.components)
        Me.pgright.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        CType(Me.player, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuitButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeginButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.object_small2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.object_mid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.object_large, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.object_small, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.object_mid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBonus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgleft.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 565)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(593, 2)
        Me.pgbottom.TabIndex = 23
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
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 535)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(595, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 537)
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
        Me.lbtitletext.Size = New System.Drawing.Size(57, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Dodge"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(595, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 535)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.player)
        Me.pgcontents.Controls.Add(Me.QuitButton)
        Me.pgcontents.Controls.Add(Me.BeginButton)
        Me.pgcontents.Controls.Add(Me.DescriptionLabel)
        Me.pgcontents.Controls.Add(Me.object_small2)
        Me.pgcontents.Controls.Add(Me.object_mid2)
        Me.pgcontents.Controls.Add(Me.object_large)
        Me.pgcontents.Controls.Add(Me.object_small)
        Me.pgcontents.Controls.Add(Me.object_mid)
        Me.pgcontents.Controls.Add(Me.scorelabel)
        Me.pgcontents.Controls.Add(Me.PicBonus)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(593, 535)
        Me.pgcontents.TabIndex = 20
        '
        'player
        '
        Me.player.BackColor = System.Drawing.Color.Transparent
        Me.player.Image = CType(resources.GetObject("player.Image"), System.Drawing.Image)
        Me.player.Location = New System.Drawing.Point(192, 445)
        Me.player.Name = "player"
        Me.player.Size = New System.Drawing.Size(32, 32)
        Me.player.TabIndex = 18
        Me.player.TabStop = False
        '
        'QuitButton
        '
        Me.QuitButton.Image = CType(resources.GetObject("QuitButton.Image"), System.Drawing.Image)
        Me.QuitButton.Location = New System.Drawing.Point(216, 424)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(200, 50)
        Me.QuitButton.TabIndex = 12
        Me.QuitButton.TabStop = False
        '
        'BeginButton
        '
        Me.BeginButton.Image = CType(resources.GetObject("BeginButton.Image"), System.Drawing.Image)
        Me.BeginButton.Location = New System.Drawing.Point(3, 424)
        Me.BeginButton.Name = "BeginButton"
        Me.BeginButton.Size = New System.Drawing.Size(200, 50)
        Me.BeginButton.TabIndex = 11
        Me.BeginButton.TabStop = False
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLabel.Location = New System.Drawing.Point(3, 3)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(413, 409)
        Me.DescriptionLabel.TabIndex = 10
        Me.DescriptionLabel.Text = "Placeholder"
        '
        'object_small2
        '
        Me.object_small2.Image = CType(resources.GetObject("object_small2.Image"), System.Drawing.Image)
        Me.object_small2.Location = New System.Drawing.Point(75, 43)
        Me.object_small2.Name = "object_small2"
        Me.object_small2.Size = New System.Drawing.Size(75, 20)
        Me.object_small2.TabIndex = 17
        Me.object_small2.TabStop = False
        '
        'object_mid2
        '
        Me.object_mid2.Image = CType(resources.GetObject("object_mid2.Image"), System.Drawing.Image)
        Me.object_mid2.Location = New System.Drawing.Point(279, 134)
        Me.object_mid2.Name = "object_mid2"
        Me.object_mid2.Size = New System.Drawing.Size(125, 20)
        Me.object_mid2.TabIndex = 16
        Me.object_mid2.TabStop = False
        '
        'object_large
        '
        Me.object_large.Image = CType(resources.GetObject("object_large.Image"), System.Drawing.Image)
        Me.object_large.Location = New System.Drawing.Point(49, 208)
        Me.object_large.Name = "object_large"
        Me.object_large.Size = New System.Drawing.Size(175, 20)
        Me.object_large.TabIndex = 15
        Me.object_large.TabStop = False
        '
        'object_small
        '
        Me.object_small.Image = CType(resources.GetObject("object_small.Image"), System.Drawing.Image)
        Me.object_small.Location = New System.Drawing.Point(290, 294)
        Me.object_small.Name = "object_small"
        Me.object_small.Size = New System.Drawing.Size(75, 20)
        Me.object_small.TabIndex = 13
        Me.object_small.TabStop = False
        '
        'object_mid
        '
        Me.object_mid.Image = CType(resources.GetObject("object_mid.Image"), System.Drawing.Image)
        Me.object_mid.Location = New System.Drawing.Point(58, 371)
        Me.object_mid.Name = "object_mid"
        Me.object_mid.Size = New System.Drawing.Size(125, 20)
        Me.object_mid.TabIndex = 14
        Me.object_mid.TabStop = False
        '
        'scorelabel
        '
        Me.scorelabel.AutoSize = True
        Me.scorelabel.BackColor = System.Drawing.Color.Transparent
        Me.scorelabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scorelabel.Location = New System.Drawing.Point(3, 4)
        Me.scorelabel.Name = "scorelabel"
        Me.scorelabel.Size = New System.Drawing.Size(51, 55)
        Me.scorelabel.TabIndex = 19
        Me.scorelabel.Text = "0"
        '
        'PicBonus
        '
        Me.PicBonus.Image = CType(resources.GetObject("PicBonus.Image"), System.Drawing.Image)
        Me.PicBonus.Location = New System.Drawing.Point(187, 84)
        Me.PicBonus.Name = "PicBonus"
        Me.PicBonus.Size = New System.Drawing.Size(16, 11)
        Me.PicBonus.TabIndex = 20
        Me.PicBonus.TabStop = False
        Me.PicBonus.Visible = False
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 537)
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
        Me.titlebar.Size = New System.Drawing.Size(597, 30)
        Me.titlebar.TabIndex = 19
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
        'clock
        '
        Me.clock.Interval = 20
        '
        'Dodge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 567)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "Dodge"
        Me.Text = "Dodge"
        Me.TopMost = True
        Me.pgright.ResumeLayout(False)
        Me.pgcontents.ResumeLayout(False)
        Me.pgcontents.PerformLayout()
        CType(Me.player, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuitButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeginButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.object_small2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.object_mid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.object_large, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.object_small, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.object_mid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBonus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgleft.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
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
    Friend WithEvents player As System.Windows.Forms.PictureBox
    Friend WithEvents QuitButton As System.Windows.Forms.PictureBox
    Friend WithEvents BeginButton As System.Windows.Forms.PictureBox
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents object_small2 As System.Windows.Forms.PictureBox
    Friend WithEvents object_mid2 As System.Windows.Forms.PictureBox
    Friend WithEvents object_large As System.Windows.Forms.PictureBox
    Friend WithEvents object_small As System.Windows.Forms.PictureBox
    Friend WithEvents object_mid As System.Windows.Forms.PictureBox
    Friend WithEvents scorelabel As System.Windows.Forms.Label
    Friend WithEvents clock As System.Windows.Forms.Timer
    Friend WithEvents PicBonus As System.Windows.Forms.PictureBox
End Class
