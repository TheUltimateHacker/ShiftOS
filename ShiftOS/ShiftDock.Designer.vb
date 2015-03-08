<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShiftDock
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
        Me.dockimg = New System.Windows.Forms.PictureBox()
        Me.icn1 = New System.Windows.Forms.PictureBox()
        Me.icn2 = New System.Windows.Forms.PictureBox()
        Me.icn3 = New System.Windows.Forms.PictureBox()
        Me.icn4 = New System.Windows.Forms.PictureBox()
        Me.icn5 = New System.Windows.Forms.PictureBox()
        Me.icn6 = New System.Windows.Forms.PictureBox()
        Me.icn7 = New System.Windows.Forms.PictureBox()
        Me.icn8 = New System.Windows.Forms.PictureBox()
        Me.icn9 = New System.Windows.Forms.PictureBox()
        Me.mousecheck = New System.Windows.Forms.Timer(Me.components)
        Me.dockanimate = New System.Windows.Forms.Timer(Me.components)
        Me.Content = New System.Windows.Forms.Panel()
        CType(Me.dockimg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icn9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Content.SuspendLayout()
        Me.SuspendLayout()
        '
        'dockimg
        '
        Me.dockimg.Location = New System.Drawing.Point(2, 0)
        Me.dockimg.Name = "dockimg"
        Me.dockimg.Size = New System.Drawing.Size(706, 23)
        Me.dockimg.TabIndex = 0
        Me.dockimg.TabStop = False
        '
        'icn1
        '
        Me.icn1.Image = Global.ShiftOS.My.Resources.Resources.iconDownloader
        Me.icn1.ImageLocation = ""
        Me.icn1.Location = New System.Drawing.Point(59, 0)
        Me.icn1.Name = "icn1"
        Me.icn1.Size = New System.Drawing.Size(103, 103)
        Me.icn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn1.TabIndex = 1
        Me.icn1.TabStop = False
        '
        'icn2
        '
        Me.icn2.Location = New System.Drawing.Point(195, 0)
        Me.icn2.Name = "icn2"
        Me.icn2.Size = New System.Drawing.Size(103, 103)
        Me.icn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn2.TabIndex = 2
        Me.icn2.TabStop = False
        '
        'icn3
        '
        Me.icn3.Location = New System.Drawing.Point(0, 0)
        Me.icn3.Name = "icn3"
        Me.icn3.Size = New System.Drawing.Size(103, 103)
        Me.icn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn3.TabIndex = 3
        Me.icn3.TabStop = False
        '
        'icn4
        '
        Me.icn4.Location = New System.Drawing.Point(0, 0)
        Me.icn4.Name = "icn4"
        Me.icn4.Size = New System.Drawing.Size(103, 103)
        Me.icn4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn4.TabIndex = 4
        Me.icn4.TabStop = False
        '
        'icn5
        '
        Me.icn5.Location = New System.Drawing.Point(0, 0)
        Me.icn5.Name = "icn5"
        Me.icn5.Size = New System.Drawing.Size(103, 103)
        Me.icn5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn5.TabIndex = 5
        Me.icn5.TabStop = False
        '
        'icn6
        '
        Me.icn6.Location = New System.Drawing.Point(0, 0)
        Me.icn6.Name = "icn6"
        Me.icn6.Size = New System.Drawing.Size(103, 103)
        Me.icn6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn6.TabIndex = 6
        Me.icn6.TabStop = False
        '
        'icn7
        '
        Me.icn7.Location = New System.Drawing.Point(0, 0)
        Me.icn7.Name = "icn7"
        Me.icn7.Size = New System.Drawing.Size(103, 103)
        Me.icn7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn7.TabIndex = 7
        Me.icn7.TabStop = False
        '
        'icn8
        '
        Me.icn8.Location = New System.Drawing.Point(0, 0)
        Me.icn8.Name = "icn8"
        Me.icn8.Size = New System.Drawing.Size(103, 103)
        Me.icn8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn8.TabIndex = 8
        Me.icn8.TabStop = False
        '
        'icn9
        '
        Me.icn9.Location = New System.Drawing.Point(1111, -6)
        Me.icn9.Name = "icn9"
        Me.icn9.Size = New System.Drawing.Size(103, 103)
        Me.icn9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icn9.TabIndex = 9
        Me.icn9.TabStop = False
        '
        'mousecheck
        '
        '
        'dockanimate
        '
        Me.dockanimate.Interval = 10
        '
        'Content
        '
        Me.Content.Controls.Add(Me.icn1)
        Me.Content.Controls.Add(Me.icn9)
        Me.Content.Controls.Add(Me.icn8)
        Me.Content.Controls.Add(Me.icn7)
        Me.Content.Controls.Add(Me.icn6)
        Me.Content.Controls.Add(Me.icn5)
        Me.Content.Controls.Add(Me.icn4)
        Me.Content.Controls.Add(Me.icn3)
        Me.Content.Controls.Add(Me.icn2)
        Me.Content.Controls.Add(Me.dockimg)
        Me.Content.Location = New System.Drawing.Point(2, 0)
        Me.Content.Name = "Content"
        Me.Content.Size = New System.Drawing.Size(1263, 100)
        Me.Content.TabIndex = 10
        '
        'ShiftDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1263, 103)
        Me.Controls.Add(Me.Content)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ShiftDock"
        Me.Text = "Dock"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        CType(Me.dockimg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icn9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Content.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dockimg As System.Windows.Forms.PictureBox
    Friend WithEvents icn1 As System.Windows.Forms.PictureBox
    Friend WithEvents icn2 As System.Windows.Forms.PictureBox
    Friend WithEvents icn3 As System.Windows.Forms.PictureBox
    Friend WithEvents icn4 As System.Windows.Forms.PictureBox
    Friend WithEvents icn5 As System.Windows.Forms.PictureBox
    Friend WithEvents icn6 As System.Windows.Forms.PictureBox
    Friend WithEvents icn7 As System.Windows.Forms.PictureBox
    Friend WithEvents icn8 As System.Windows.Forms.PictureBox
    Friend WithEvents icn9 As System.Windows.Forms.PictureBox
    Friend WithEvents mousecheck As System.Windows.Forms.Timer
    Friend WithEvents dockanimate As System.Windows.Forms.Timer
    Friend WithEvents Content As System.Windows.Forms.Panel
End Class
