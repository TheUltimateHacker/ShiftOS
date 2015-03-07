<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HijackScreen
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
        Me.lblHijack = New System.Windows.Forms.Label()
        Me.conversationtimer = New System.Windows.Forms.Timer(Me.components)
        Me.textgen = New System.Windows.Forms.Timer(Me.components)
        Me.lblhackwords = New System.Windows.Forms.Label()
        Me.hackeffecttimer = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'lblHijack
        '
        Me.lblHijack.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHijack.AutoSize = True
        Me.lblHijack.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblHijack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHijack.ForeColor = System.Drawing.Color.DimGray
        Me.lblHijack.Location = New System.Drawing.Point(143, 193)
        Me.lblHijack.Name = "lblHijack"
        Me.lblHijack.Size = New System.Drawing.Size(18, 25)
        Me.lblHijack.TabIndex = 0
        Me.lblHijack.Text = "\"
        '
        'conversationtimer
        '
        '
        'textgen
        '
        Me.textgen.Interval = 20
        '
        'lblhackwords
        '
        Me.lblhackwords.AutoSize = True
        Me.lblhackwords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblhackwords.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhackwords.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblhackwords.Location = New System.Drawing.Point(0, 0)
        Me.lblhackwords.Name = "lblhackwords"
        Me.lblhackwords.Size = New System.Drawing.Size(127, 18)
        Me.lblhackwords.TabIndex = 1
        Me.lblhackwords.Text = "Hijack in progress"
        '
        'hackeffecttimer
        '
        Me.hackeffecttimer.Interval = 50
        '
        'HijackScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(653, 457)
        Me.Controls.Add(Me.lblhackwords)
        Me.Controls.Add(Me.lblHijack)
        Me.Name = "HijackScreen"
        Me.Text = "ShiftOS"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHijack As System.Windows.Forms.Label
    Friend WithEvents conversationtimer As System.Windows.Forms.Timer
    Friend WithEvents textgen As System.Windows.Forms.Timer
    Friend WithEvents lblhackwords As System.Windows.Forms.Label
    Friend WithEvents hackeffecttimer As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
