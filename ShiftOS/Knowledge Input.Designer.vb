<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Knowledge_Input
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Knowledge_Input))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.pnlintro = New System.Windows.Forms.Panel()
        Me.pnlcategorydisplay = New System.Windows.Forms.Panel()
        Me.lblnextreward = New System.Windows.Forms.Label()
        Me.guessbox = New System.Windows.Forms.TextBox()
        Me.lblcurrentlevel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.listblistedstuff = New System.Windows.Forms.ListBox()
        Me.lbltillnextlevel = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.btnstart = New System.Windows.Forms.Button()
        Me.lblcatedescription = New System.Windows.Forms.Label()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.decider = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.tmrstoryline = New System.Windows.Forms.Timer(Me.components)
        Me.pnlintro.SuspendLayout()
        Me.pnlcategorydisplay.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgleft.SuspendLayout()
        Me.pgright.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Black
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Items.AddRange(New Object() {"Animals", "Countries", "Fruits"})
        Me.ListBox1.Location = New System.Drawing.Point(9, 49)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(175, 216)
        Me.ListBox1.TabIndex = 0
        '
        'pnlintro
        '
        Me.pnlintro.Controls.Add(Me.pnlcategorydisplay)
        Me.pnlintro.Controls.Add(Me.Label4)
        Me.pnlintro.Controls.Add(Me.Label3)
        Me.pnlintro.Controls.Add(Me.Label2)
        Me.pnlintro.Controls.Add(Me.Label1)
        Me.pnlintro.Location = New System.Drawing.Point(190, 0)
        Me.pnlintro.Name = "pnlintro"
        Me.pnlintro.Size = New System.Drawing.Size(479, 272)
        Me.pnlintro.TabIndex = 1
        '
        'pnlcategorydisplay
        '
        Me.pnlcategorydisplay.Controls.Add(Me.lblnextreward)
        Me.pnlcategorydisplay.Controls.Add(Me.guessbox)
        Me.pnlcategorydisplay.Controls.Add(Me.lblcurrentlevel)
        Me.pnlcategorydisplay.Controls.Add(Me.Label5)
        Me.pnlcategorydisplay.Controls.Add(Me.listblistedstuff)
        Me.pnlcategorydisplay.Controls.Add(Me.lbltillnextlevel)
        Me.pnlcategorydisplay.Controls.Add(Me.lbltotal)
        Me.pnlcategorydisplay.Controls.Add(Me.btnstart)
        Me.pnlcategorydisplay.Controls.Add(Me.lblcatedescription)
        Me.pnlcategorydisplay.Controls.Add(Me.lblcategory)
        Me.pnlcategorydisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlcategorydisplay.ForeColor = System.Drawing.Color.Black
        Me.pnlcategorydisplay.Location = New System.Drawing.Point(0, 0)
        Me.pnlcategorydisplay.Name = "pnlcategorydisplay"
        Me.pnlcategorydisplay.Size = New System.Drawing.Size(479, 272)
        Me.pnlcategorydisplay.TabIndex = 2
        '
        'lblnextreward
        '
        Me.lblnextreward.AutoSize = True
        Me.lblnextreward.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnextreward.Location = New System.Drawing.Point(36, 110)
        Me.lblnextreward.Name = "lblnextreward"
        Me.lblnextreward.Size = New System.Drawing.Size(244, 20)
        Me.lblnextreward.TabIndex = 11
        Me.lblnextreward.Text = "Reward for completing level 1: 5CP"
        Me.lblnextreward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'guessbox
        '
        Me.guessbox.BackColor = System.Drawing.Color.White
        Me.guessbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.guessbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guessbox.ForeColor = System.Drawing.Color.Black
        Me.guessbox.Location = New System.Drawing.Point(11, 147)
        Me.guessbox.Multiline = True
        Me.guessbox.Name = "guessbox"
        Me.guessbox.Size = New System.Drawing.Size(297, 45)
        Me.guessbox.TabIndex = 9
        Me.guessbox.Text = "Enter Guess Here"
        Me.guessbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblcurrentlevel
        '
        Me.lblcurrentlevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcurrentlevel.Location = New System.Drawing.Point(-6, 77)
        Me.lblcurrentlevel.Name = "lblcurrentlevel"
        Me.lblcurrentlevel.Size = New System.Drawing.Size(331, 42)
        Me.lblcurrentlevel.TabIndex = 8
        Me.lblcurrentlevel.Text = "Current Level: 1"
        Me.lblcurrentlevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(340, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "All Ready Done"
        '
        'listblistedstuff
        '
        Me.listblistedstuff.BackColor = System.Drawing.Color.Black
        Me.listblistedstuff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listblistedstuff.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listblistedstuff.ForeColor = System.Drawing.Color.White
        Me.listblistedstuff.FormattingEnabled = True
        Me.listblistedstuff.Location = New System.Drawing.Point(340, 41)
        Me.listblistedstuff.Name = "listblistedstuff"
        Me.listblistedstuff.ScrollAlwaysVisible = True
        Me.listblistedstuff.Size = New System.Drawing.Size(129, 221)
        Me.listblistedstuff.TabIndex = 6
        '
        'lbltillnextlevel
        '
        Me.lbltillnextlevel.AutoSize = True
        Me.lbltillnextlevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltillnextlevel.Location = New System.Drawing.Point(8, 250)
        Me.lbltillnextlevel.Name = "lbltillnextlevel"
        Me.lbltillnextlevel.Size = New System.Drawing.Size(146, 16)
        Me.lbltillnextlevel.TabIndex = 5
        Me.lbltillnextlevel.Text = "Words Until Next Level:"
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(191, 250)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(66, 16)
        Me.lbltotal.TabIndex = 3
        Me.lbltotal.Text = "Guessed:"
        '
        'btnstart
        '
        Me.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnstart.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstart.Location = New System.Drawing.Point(11, 198)
        Me.btnstart.Name = "btnstart"
        Me.btnstart.Size = New System.Drawing.Size(297, 46)
        Me.btnstart.TabIndex = 2
        Me.btnstart.Text = "Submit Word"
        Me.btnstart.UseVisualStyleBackColor = True
        '
        'lblcatedescription
        '
        Me.lblcatedescription.Location = New System.Drawing.Point(11, 48)
        Me.lblcatedescription.Name = "lblcatedescription"
        Me.lblcatedescription.Size = New System.Drawing.Size(297, 26)
        Me.lblcatedescription.TabIndex = 1
        Me.lblcatedescription.Text = "There are many animals out there! Can you list them all? " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note that this is a li" & _
    "st of common animals, not every animal!"
        Me.lblcatedescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblcategory
        '
        Me.lblcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(11, 8)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(297, 39)
        Me.lblcategory.TabIndex = 0
        Me.lblcategory.Text = "Animals"
        Me.lblcategory.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(382, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Select A Category On the Left To Start Playing"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(187, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "How To Play:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(354, 96)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(75, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(316, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome to Knowledge Input"
        '
        'decider
        '
        Me.decider.Interval = 500
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 28)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Categories"
        '
        'pgcontents
        '
        Me.pgcontents.Controls.Add(Me.pnlintro)
        Me.pgcontents.Controls.Add(Me.Label6)
        Me.pgcontents.Controls.Add(Me.ListBox1)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(669, 272)
        Me.pgcontents.TabIndex = 10
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
        Me.titlebar.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titlebar.ForeColor = System.Drawing.Color.White
        Me.titlebar.Location = New System.Drawing.Point(0, 0)
        Me.titlebar.Name = "titlebar"
        Me.titlebar.Size = New System.Drawing.Size(673, 30)
        Me.titlebar.TabIndex = 9
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(224, 5)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconKnowledgeInput
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
        Me.rollupbutton.Location = New System.Drawing.Point(252, 4)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'closebutton
        '
        Me.closebutton.BackColor = System.Drawing.Color.Black
        Me.closebutton.Location = New System.Drawing.Point(280, 4)
        Me.closebutton.Name = "closebutton"
        Me.closebutton.Size = New System.Drawing.Size(22, 22)
        Me.closebutton.TabIndex = 19
        '
        'lbtitletext
        '
        Me.lbtitletext.AutoSize = True
        Me.lbtitletext.BackColor = System.Drawing.Color.Transparent
        Me.lbtitletext.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(131, 18)
        Me.lbtitletext.TabIndex = 18
        Me.lbtitletext.Text = "Knowledge Input"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(671, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 274)
        Me.pgleft.TabIndex = 11
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 272)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(671, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 274)
        Me.pgright.TabIndex = 12
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 272)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 302)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(669, 2)
        Me.pgbottom.TabIndex = 13
        '
        'tmrstoryline
        '
        Me.tmrstoryline.Interval = 1000
        '
        'Knowledge_Input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(673, 304)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Knowledge_Input"
        Me.Text = "Knowledge_Input"
        Me.TopMost = True
        Me.pnlintro.ResumeLayout(False)
        Me.pnlintro.PerformLayout()
        Me.pnlcategorydisplay.ResumeLayout(False)
        Me.pnlcategorydisplay.PerformLayout()
        Me.pgcontents.ResumeLayout(False)
        Me.pgcontents.PerformLayout()
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgleft.ResumeLayout(False)
        Me.pgright.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents pnlintro As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlcategorydisplay As System.Windows.Forms.Panel
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents btnstart As System.Windows.Forms.Button
    Friend WithEvents lblcatedescription As System.Windows.Forms.Label
    Friend WithEvents lbltillnextlevel As System.Windows.Forms.Label
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents listblistedstuff As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents guessbox As System.Windows.Forms.TextBox
    Friend WithEvents lblcurrentlevel As System.Windows.Forms.Label
    Friend WithEvents decider As System.Windows.Forms.Timer
    Friend WithEvents lblnextreward As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents tmrstoryline As System.Windows.Forms.Timer
End Class
