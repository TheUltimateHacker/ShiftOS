﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class systeminfo
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
        Me.pullside = New System.Windows.Forms.Timer(Me.components)
        Me.pullbs = New System.Windows.Forms.Timer(Me.components)
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.SysInfoBox = New System.Windows.Forms.GroupBox()
        Me.SysInfoTextBox5 = New System.Windows.Forms.TextBox()
        Me.SysInfoLabel5 = New System.Windows.Forms.Label()
        Me.SysInfoBox2 = New System.Windows.Forms.TextBox()
        Me.SysInfoBox1 = New System.Windows.Forms.TextBox()
        Me.SysInfoLabel2 = New System.Windows.Forms.Label()
        Me.SysInfoLabel1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SysInfoLabel3 = New System.Windows.Forms.Label()
        Me.SysInfoBox3 = New System.Windows.Forms.TextBox()
        Me.SysInfoBox4 = New System.Windows.Forms.TextBox()
        Me.SysInfoLabel4 = New System.Windows.Forms.Label()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pgcontents.SuspendLayout()
        Me.SysInfoBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgright.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.titlebar.SuspendLayout()
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
        'pgcontents
        '
        Me.pgcontents.Controls.Add(Me.SysInfoBox)
        Me.pgcontents.Controls.Add(Me.GroupBox1)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(438, 218)
        Me.pgcontents.TabIndex = 20
        '
        'SysInfoBox
        '
        Me.SysInfoBox.Controls.Add(Me.SysInfoTextBox5)
        Me.SysInfoBox.Controls.Add(Me.SysInfoLabel5)
        Me.SysInfoBox.Controls.Add(Me.SysInfoBox2)
        Me.SysInfoBox.Controls.Add(Me.SysInfoBox1)
        Me.SysInfoBox.Controls.Add(Me.SysInfoLabel2)
        Me.SysInfoBox.Controls.Add(Me.SysInfoLabel1)
        Me.SysInfoBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SysInfoBox.Location = New System.Drawing.Point(6, 15)
        Me.SysInfoBox.Name = "SysInfoBox"
        Me.SysInfoBox.Size = New System.Drawing.Size(428, 98)
        Me.SysInfoBox.TabIndex = 14
        Me.SysInfoBox.TabStop = False
        Me.SysInfoBox.Text = "ShiftOS"
        '
        'SysInfoTextBox5
        '
        Me.SysInfoTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SysInfoTextBox5.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SysInfoTextBox5.Location = New System.Drawing.Point(145, 68)
        Me.SysInfoTextBox5.Name = "SysInfoTextBox5"
        Me.SysInfoTextBox5.ReadOnly = True
        Me.SysInfoTextBox5.Size = New System.Drawing.Size(277, 20)
        Me.SysInfoTextBox5.TabIndex = 9
        '
        'SysInfoLabel5
        '
        Me.SysInfoLabel5.AutoSize = True
        Me.SysInfoLabel5.Location = New System.Drawing.Point(7, 75)
        Me.SysInfoLabel5.Name = "SysInfoLabel5"
        Me.SysInfoLabel5.Size = New System.Drawing.Size(122, 13)
        Me.SysInfoLabel5.TabIndex = 8
        Me.SysInfoLabel5.Text = "ShiftOS Computer Name"
        '
        'SysInfoBox2
        '
        Me.SysInfoBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SysInfoBox2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SysInfoBox2.Location = New System.Drawing.Point(145, 41)
        Me.SysInfoBox2.Name = "SysInfoBox2"
        Me.SysInfoBox2.ReadOnly = True
        Me.SysInfoBox2.Size = New System.Drawing.Size(277, 20)
        Me.SysInfoBox2.TabIndex = 7
        '
        'SysInfoBox1
        '
        Me.SysInfoBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SysInfoBox1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SysInfoBox1.Location = New System.Drawing.Point(145, 13)
        Me.SysInfoBox1.Name = "SysInfoBox1"
        Me.SysInfoBox1.ReadOnly = True
        Me.SysInfoBox1.Size = New System.Drawing.Size(277, 20)
        Me.SysInfoBox1.TabIndex = 6
        '
        'SysInfoLabel2
        '
        Me.SysInfoLabel2.AutoSize = True
        Me.SysInfoLabel2.Location = New System.Drawing.Point(7, 48)
        Me.SysInfoLabel2.Name = "SysInfoLabel2"
        Me.SysInfoLabel2.Size = New System.Drawing.Size(94, 13)
        Me.SysInfoLabel2.TabIndex = 1
        Me.SysInfoLabel2.Text = "ShiftOS Username"
        '
        'SysInfoLabel1
        '
        Me.SysInfoLabel1.AutoSize = True
        Me.SysInfoLabel1.Location = New System.Drawing.Point(7, 20)
        Me.SysInfoLabel1.Name = "SysInfoLabel1"
        Me.SysInfoLabel1.Size = New System.Drawing.Size(81, 13)
        Me.SysInfoLabel1.TabIndex = 0
        Me.SysInfoLabel1.Text = "ShiftOS Version"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.SysInfoLabel3)
        Me.GroupBox1.Controls.Add(Me.SysInfoBox3)
        Me.GroupBox1.Controls.Add(Me.SysInfoBox4)
        Me.GroupBox1.Controls.Add(Me.SysInfoLabel4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 133)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 76)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hardware"
        '
        'SysInfoLabel3
        '
        Me.SysInfoLabel3.AutoSize = True
        Me.SysInfoLabel3.Location = New System.Drawing.Point(8, 22)
        Me.SysInfoLabel3.Name = "SysInfoLabel3"
        Me.SysInfoLabel3.Size = New System.Drawing.Size(29, 13)
        Me.SysInfoLabel3.TabIndex = 2
        Me.SysInfoLabel3.Text = "CPU"
        '
        'SysInfoBox3
        '
        Me.SysInfoBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SysInfoBox3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SysInfoBox3.Location = New System.Drawing.Point(68, 15)
        Me.SysInfoBox3.Name = "SysInfoBox3"
        Me.SysInfoBox3.ReadOnly = True
        Me.SysInfoBox3.Size = New System.Drawing.Size(220, 20)
        Me.SysInfoBox3.TabIndex = 8
        '
        'SysInfoBox4
        '
        Me.SysInfoBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SysInfoBox4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SysInfoBox4.Location = New System.Drawing.Point(68, 48)
        Me.SysInfoBox4.Name = "SysInfoBox4"
        Me.SysInfoBox4.ReadOnly = True
        Me.SysInfoBox4.Size = New System.Drawing.Size(220, 20)
        Me.SysInfoBox4.TabIndex = 9
        '
        'SysInfoLabel4
        '
        Me.SysInfoLabel4.AutoSize = True
        Me.SysInfoLabel4.Location = New System.Drawing.Point(8, 48)
        Me.SysInfoLabel4.Name = "SysInfoLabel4"
        Me.SysInfoLabel4.Size = New System.Drawing.Size(54, 13)
        Me.SysInfoLabel4.TabIndex = 3
        Me.SysInfoLabel4.Text = "RAM Size"
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 248)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(438, 2)
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
        Me.lbtitletext.Size = New System.Drawing.Size(154, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "System Information"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(440, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
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
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(440, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 220)
        Me.pgright.TabIndex = 22
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
        Me.titlebar.Size = New System.Drawing.Size(442, 30)
        Me.titlebar.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(294, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 55)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Dump to Text File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'systeminfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 250)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "systeminfo"
        Me.Text = "SystemInfo"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.SysInfoBox.ResumeLayout(False)
        Me.SysInfoBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgright.ResumeLayout(False)
        Me.pgleft.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents SysInfoBox As System.Windows.Forms.GroupBox
    Friend WithEvents SysInfoBox2 As System.Windows.Forms.TextBox
    Friend WithEvents SysInfoBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SysInfoLabel2 As System.Windows.Forms.Label
    Friend WithEvents SysInfoLabel1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SysInfoLabel3 As System.Windows.Forms.Label
    Friend WithEvents SysInfoBox3 As System.Windows.Forms.TextBox
    Friend WithEvents SysInfoBox4 As System.Windows.Forms.TextBox
    Friend WithEvents SysInfoLabel4 As System.Windows.Forms.Label
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents SysInfoTextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents SysInfoLabel5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
