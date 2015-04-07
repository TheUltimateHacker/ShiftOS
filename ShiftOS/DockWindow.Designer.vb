<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DockWindow
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
        Me.pnlTiles = New System.Windows.Forms.Panel()
        Me.picBoarder = New System.Windows.Forms.PictureBox()
        CType(Me.picBoarder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTiles
        '
        Me.pnlTiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTiles.BackColor = System.Drawing.Color.Transparent
        Me.pnlTiles.Location = New System.Drawing.Point(-1, 0)
        Me.pnlTiles.Name = "pnlTiles"
        Me.pnlTiles.Size = New System.Drawing.Size(125, 112)
        Me.pnlTiles.TabIndex = 3
        '
        'picBoarder
        '
        Me.picBoarder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picBoarder.BackColor = System.Drawing.Color.Gray
        Me.picBoarder.Location = New System.Drawing.Point(-1, 107)
        Me.picBoarder.Name = "picBoarder"
        Me.picBoarder.Size = New System.Drawing.Size(125, 21)
        Me.picBoarder.TabIndex = 2
        Me.picBoarder.TabStop = False
        '
        'DockWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(124, 149)
        Me.Controls.Add(Me.pnlTiles)
        Me.Controls.Add(Me.picBoarder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DockWindow"
        Me.Text = "Dock"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        CType(Me.picBoarder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTiles As System.Windows.Forms.Panel
    Friend WithEvents picBoarder As System.Windows.Forms.PictureBox
End Class
