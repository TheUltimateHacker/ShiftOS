<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bitnote_Wallet
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
        Me.pnltransactions = New System.Windows.Forms.Panel()
        Me.txthistory = New System.Windows.Forms.RichTextBox()
        Me.pnltotalbalance = New System.Windows.Forms.Panel()
        Me.lblbalancerounded = New System.Windows.Forms.Label()
        Me.lblprecisebalance = New System.Windows.Forms.Label()
        Me.pnlsend = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtamounttopay = New System.Windows.Forms.TextBox()
        Me.btnsendmoney = New System.Windows.Forms.Button()
        Me.lblpostpayment = New System.Windows.Forms.Label()
        Me.lbltotalbalancesendscreen = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtsendtoaddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlreceive = New System.Windows.Forms.Panel()
        Me.btncopyaddress = New System.Windows.Forms.Button()
        Me.lblmybitnoteaddress = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlmenuholder = New System.Windows.Forms.FlowLayoutPanel()
        Me.btntotalbalance = New System.Windows.Forms.Button()
        Me.btnsend = New System.Windows.Forms.Button()
        Me.btnreceive = New System.Windows.Forms.Button()
        Me.btntransactions = New System.Windows.Forms.Button()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.pgright.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        Me.pnltransactions.SuspendLayout()
        Me.pnltotalbalance.SuspendLayout()
        Me.pnlsend.SuspendLayout()
        Me.pnlreceive.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlmenuholder.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 202)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(421, 2)
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
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 172)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(423, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 174)
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
        Me.lbtitletext.Font = New System.Drawing.Font("Felix Titling", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(147, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Bitnote Wallet"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(423, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 172)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgcontents
        '
        Me.pgcontents.Controls.Add(Me.pnltotalbalance)
        Me.pgcontents.Controls.Add(Me.PictureBox1)
        Me.pgcontents.Controls.Add(Me.pnltransactions)
        Me.pgcontents.Controls.Add(Me.pnlsend)
        Me.pgcontents.Controls.Add(Me.pnlreceive)
        Me.pgcontents.Controls.Add(Me.pnlmenuholder)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(421, 172)
        Me.pgcontents.TabIndex = 20
        '
        'pnltransactions
        '
        Me.pnltransactions.Controls.Add(Me.txthistory)
        Me.pnltransactions.Location = New System.Drawing.Point(297, 52)
        Me.pnltransactions.Name = "pnltransactions"
        Me.pnltransactions.Size = New System.Drawing.Size(63, 110)
        Me.pnltransactions.TabIndex = 7
        '
        'txthistory
        '
        Me.txthistory.BackColor = System.Drawing.Color.White
        Me.txthistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txthistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txthistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthistory.Location = New System.Drawing.Point(0, 0)
        Me.txthistory.Name = "txthistory"
        Me.txthistory.ReadOnly = True
        Me.txthistory.Size = New System.Drawing.Size(63, 110)
        Me.txthistory.TabIndex = 0
        Me.txthistory.Text = ""
        '
        'pnltotalbalance
        '
        Me.pnltotalbalance.Controls.Add(Me.lblbalancerounded)
        Me.pnltotalbalance.Controls.Add(Me.lblprecisebalance)
        Me.pnltotalbalance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnltotalbalance.Location = New System.Drawing.Point(0, 34)
        Me.pnltotalbalance.Name = "pnltotalbalance"
        Me.pnltotalbalance.Size = New System.Drawing.Size(421, 138)
        Me.pnltotalbalance.TabIndex = 5
        '
        'lblbalancerounded
        '
        Me.lblbalancerounded.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalancerounded.Location = New System.Drawing.Point(6, 30)
        Me.lblbalancerounded.Name = "lblbalancerounded"
        Me.lblbalancerounded.Size = New System.Drawing.Size(409, 48)
        Me.lblbalancerounded.TabIndex = 3
        Me.lblbalancerounded.Text = "Balance: 1.54 BTN"
        Me.lblbalancerounded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblprecisebalance
        '
        Me.lblprecisebalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecisebalance.Location = New System.Drawing.Point(6, 74)
        Me.lblprecisebalance.Name = "lblprecisebalance"
        Me.lblprecisebalance.Size = New System.Drawing.Size(409, 29)
        Me.lblprecisebalance.TabIndex = 4
        Me.lblprecisebalance.Text = "(Precise Balance: 1.54663 BTN)"
        Me.lblprecisebalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlsend
        '
        Me.pnlsend.Controls.Add(Me.Label8)
        Me.pnlsend.Controls.Add(Me.Label7)
        Me.pnlsend.Controls.Add(Me.txtamounttopay)
        Me.pnlsend.Controls.Add(Me.btnsendmoney)
        Me.pnlsend.Controls.Add(Me.lblpostpayment)
        Me.pnlsend.Controls.Add(Me.lbltotalbalancesendscreen)
        Me.pnlsend.Controls.Add(Me.Label4)
        Me.pnlsend.Controls.Add(Me.txtsendtoaddress)
        Me.pnlsend.Controls.Add(Me.Label3)
        Me.pnlsend.Location = New System.Drawing.Point(99, 52)
        Me.pnlsend.Name = "pnlsend"
        Me.pnlsend.Size = New System.Drawing.Size(72, 110)
        Me.pnlsend.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(222, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Payment Amount:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(297, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "BTN"
        '
        'txtamounttopay
        '
        Me.txtamounttopay.BackColor = System.Drawing.Color.White
        Me.txtamounttopay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtamounttopay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamounttopay.Location = New System.Drawing.Point(224, 113)
        Me.txtamounttopay.Multiline = True
        Me.txtamounttopay.Name = "txtamounttopay"
        Me.txtamounttopay.Size = New System.Drawing.Size(70, 21)
        Me.txtamounttopay.TabIndex = 6
        Me.txtamounttopay.Text = "0.00007"
        Me.txtamounttopay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnsendmoney
        '
        Me.btnsendmoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsendmoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsendmoney.Location = New System.Drawing.Point(340, 91)
        Me.btnsendmoney.Name = "btnsendmoney"
        Me.btnsendmoney.Size = New System.Drawing.Size(75, 43)
        Me.btnsendmoney.TabIndex = 5
        Me.btnsendmoney.Text = "Send"
        Me.btnsendmoney.UseVisualStyleBackColor = True
        '
        'lblpostpayment
        '
        Me.lblpostpayment.AutoSize = True
        Me.lblpostpayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpostpayment.Location = New System.Drawing.Point(5, 115)
        Me.lblpostpayment.Name = "lblpostpayment"
        Me.lblpostpayment.Size = New System.Drawing.Size(195, 16)
        Me.lblpostpayment.TabIndex = 4
        Me.lblpostpayment.Text = "Post Payment Balance: 0.00053"
        '
        'lbltotalbalancesendscreen
        '
        Me.lbltotalbalancesendscreen.AutoSize = True
        Me.lbltotalbalancesendscreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalbalancesendscreen.Location = New System.Drawing.Point(4, 93)
        Me.lbltotalbalancesendscreen.Name = "lbltotalbalancesendscreen"
        Me.lbltotalbalancesendscreen.Size = New System.Drawing.Size(188, 16)
        Me.lbltotalbalancesendscreen.TabIndex = 3
        Me.lbltotalbalancesendscreen.Text = "Current Total Balance: 0.00060"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(415, 49)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "In order to spend your bitnotes you must find a service that allows you to pay wi" & _
    "th bitnotes. They will provide you with a Bitnote Address which you must copy ex" & _
    "actly into the pay to box below."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtsendtoaddress
        '
        Me.txtsendtoaddress.BackColor = System.Drawing.Color.White
        Me.txtsendtoaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsendtoaddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsendtoaddress.Location = New System.Drawing.Point(60, 63)
        Me.txtsendtoaddress.Multiline = True
        Me.txtsendtoaddress.Name = "txtsendtoaddress"
        Me.txtsendtoaddress.Size = New System.Drawing.Size(355, 22)
        Me.txtsendtoaddress.TabIndex = 1
        Me.txtsendtoaddress.Text = "1FfmbHfnpaZjKFvyi1okTjJJusN455paPH"
        Me.txtsendtoaddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pay To: "
        '
        'pnlreceive
        '
        Me.pnlreceive.Controls.Add(Me.btncopyaddress)
        Me.pnlreceive.Controls.Add(Me.lblmybitnoteaddress)
        Me.pnlreceive.Controls.Add(Me.Label9)
        Me.pnlreceive.Location = New System.Drawing.Point(194, 52)
        Me.pnlreceive.Name = "pnlreceive"
        Me.pnlreceive.Size = New System.Drawing.Size(72, 110)
        Me.pnlreceive.TabIndex = 7
        '
        'btncopyaddress
        '
        Me.btncopyaddress.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btncopyaddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncopyaddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncopyaddress.Location = New System.Drawing.Point(157, 98)
        Me.btncopyaddress.Name = "btncopyaddress"
        Me.btncopyaddress.Size = New System.Drawing.Size(98, 34)
        Me.btncopyaddress.TabIndex = 2
        Me.btncopyaddress.Text = "Copy"
        Me.btncopyaddress.UseVisualStyleBackColor = True
        '
        'lblmybitnoteaddress
        '
        Me.lblmybitnoteaddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmybitnoteaddress.Location = New System.Drawing.Point(1, 59)
        Me.lblmybitnoteaddress.Name = "lblmybitnoteaddress"
        Me.lblmybitnoteaddress.Size = New System.Drawing.Size(419, 36)
        Me.lblmybitnoteaddress.TabIndex = 1
        Me.lblmybitnoteaddress.Text = "1LgZUWQNYWZ7Qhc1hScZieC3GWnPLzaqSd"
        Me.lblmybitnoteaddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(415, 51)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "This is your bitnote address for receiving payments. When withdrawing bitnotes fr" & _
    "om online accounts or a bit digger be sure to give them them this address so you" & _
    " can receive your money."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(421, 1)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'pnlmenuholder
        '
        Me.pnlmenuholder.Controls.Add(Me.btntotalbalance)
        Me.pnlmenuholder.Controls.Add(Me.btnsend)
        Me.pnlmenuholder.Controls.Add(Me.btnreceive)
        Me.pnlmenuholder.Controls.Add(Me.btntransactions)
        Me.pnlmenuholder.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlmenuholder.Location = New System.Drawing.Point(0, 0)
        Me.pnlmenuholder.Name = "pnlmenuholder"
        Me.pnlmenuholder.Size = New System.Drawing.Size(421, 33)
        Me.pnlmenuholder.TabIndex = 1
        '
        'btntotalbalance
        '
        Me.btntotalbalance.BackgroundImage = Global.ShiftOS.My.Resources.Resources.TotalBalanceClicked
        Me.btntotalbalance.FlatAppearance.BorderSize = 0
        Me.btntotalbalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntotalbalance.Location = New System.Drawing.Point(3, 3)
        Me.btntotalbalance.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.btntotalbalance.Name = "btntotalbalance"
        Me.btntotalbalance.Size = New System.Drawing.Size(103, 27)
        Me.btntotalbalance.TabIndex = 0
        Me.btntotalbalance.UseVisualStyleBackColor = True
        '
        'btnsend
        '
        Me.btnsend.BackgroundImage = Global.ShiftOS.My.Resources.Resources.SendUnclicked
        Me.btnsend.FlatAppearance.BorderSize = 0
        Me.btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsend.Location = New System.Drawing.Point(109, 3)
        Me.btnsend.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.btnsend.Name = "btnsend"
        Me.btnsend.Size = New System.Drawing.Size(101, 27)
        Me.btnsend.TabIndex = 1
        Me.btnsend.UseVisualStyleBackColor = True
        '
        'btnreceive
        '
        Me.btnreceive.BackgroundImage = Global.ShiftOS.My.Resources.Resources.ReceiveUnclicked
        Me.btnreceive.FlatAppearance.BorderSize = 0
        Me.btnreceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreceive.Location = New System.Drawing.Point(213, 3)
        Me.btnreceive.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.btnreceive.Name = "btnreceive"
        Me.btnreceive.Size = New System.Drawing.Size(101, 27)
        Me.btnreceive.TabIndex = 2
        Me.btnreceive.UseVisualStyleBackColor = True
        '
        'btntransactions
        '
        Me.btntransactions.BackgroundImage = Global.ShiftOS.My.Resources.Resources.transactionsUnclicked
        Me.btntransactions.FlatAppearance.BorderSize = 0
        Me.btntransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntransactions.Location = New System.Drawing.Point(317, 3)
        Me.btntransactions.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.btntransactions.Name = "btntransactions"
        Me.btntransactions.Size = New System.Drawing.Size(101, 27)
        Me.btntransactions.TabIndex = 3
        Me.btntransactions.UseVisualStyleBackColor = True
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 174)
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
        Me.titlebar.Size = New System.Drawing.Size(425, 30)
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
        'Bitnote_Wallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(425, 204)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Bitnote_Wallet"
        Me.Text = "Bitnote_Wallet"
        Me.TopMost = True
        Me.pgright.ResumeLayout(False)
        Me.pgcontents.ResumeLayout(False)
        Me.pnltransactions.ResumeLayout(False)
        Me.pnltotalbalance.ResumeLayout(False)
        Me.pnlsend.ResumeLayout(False)
        Me.pnlsend.PerformLayout()
        Me.pnlreceive.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlmenuholder.ResumeLayout(False)
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
    Friend WithEvents pnlmenuholder As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btntotalbalance As System.Windows.Forms.Button
    Friend WithEvents btnsend As System.Windows.Forms.Button
    Friend WithEvents btnreceive As System.Windows.Forms.Button
    Friend WithEvents btntransactions As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblprecisebalance As System.Windows.Forms.Label
    Friend WithEvents lblbalancerounded As System.Windows.Forms.Label
    Friend WithEvents pnltotalbalance As System.Windows.Forms.Panel
    Friend WithEvents pnltransactions As System.Windows.Forms.Panel
    Friend WithEvents pnlreceive As System.Windows.Forms.Panel
    Friend WithEvents pnlsend As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtamounttopay As System.Windows.Forms.TextBox
    Friend WithEvents btnsendmoney As System.Windows.Forms.Button
    Friend WithEvents lblpostpayment As System.Windows.Forms.Label
    Friend WithEvents lbltotalbalancesendscreen As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtsendtoaddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btncopyaddress As System.Windows.Forms.Button
    Friend WithEvents lblmybitnoteaddress As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txthistory As System.Windows.Forms.RichTextBox
End Class
