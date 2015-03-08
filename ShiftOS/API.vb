Imports System.Runtime.InteropServices
Public Class API
    'Error handling
    Private Shared LastError As Exception
    <DebuggerStepThrough()> _
    Public Shared Sub HandleError()
        If LastError IsNot Nothing Then
            Throw LastError
        ElseIf Marshal.GetLastWin32Error() <> 0 Then
            Throw New System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error())
        End If
    End Sub

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Int32, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    Public Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Int32, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    Public Declare Function AttachThreadInput Lib "user32" (ByVal idAttach As Integer, ByVal idAttackTo As Integer, ByVal fAttack As Int32) As Boolean
    Public Declare Function GetCurrentThreadId Lib "kernel32" () As Integer

    Public Class WM
        Public Enum SC 'System Commands
            CLOSE = &HF060
            CONTEXTHELP = &HF180
            CDEFAULT = &HF160
            HOTKEY = &HF150
            HSCROLL = &HF080
            ISSECURE = &H1
            KEYMENU = &HF100
            MAXIMIZE = &HF030
            MINIMIZE = &HF020
            MONITORPOWER = &HF170
            MouseMenu = &HF090
            MOVE = &HF010
            NEXTWINDOW = &HF040
            PREVWINDOW = &HF050
            RESTORE = &HF120
            SCREENSAVE = &HF140
            Size = &HF000
            TASKLIST = &HF130
            VSCROLL = &HF070
        End Enum

        Public Enum msg As UInteger
            USER = &H400&
            ACTIVATE = &H6
            ACTIVATEAPP = &H1C
            ASKCBFORMATNAME = &H30C
            CANCELJOURNAL = &H4B
            CANCELMODE = &H1F
            CHANGECBCHAIN = &H30D
            Chr = &H102
            CHARTOITEM = &H2F
            CHILDACTIVATE = &H22
            CHOOSEFONT_GETLOGFONT = (USER + 1)
            CHOOSEFONT_SETFLAGS = (USER + 102)
            CHOOSEFONT_SETLOGFONT = (USER + 101)
            CLEAR = &H303
            CLOSE = &H10
            Command = &H111
            COMMNOTIFY = &H44 ' no longer suported
            COMPACTING = &H41
            COMPAREITEM = &H39
            CONVERTREQUESTEX = &H108
            Copy = &H301
            COPYDATA = &H4A
            CREATE = &H1
            CTLCOLORBTN = &H135
            CTLCOLORDLG = &H136
            CTLCOLOREDIT = &H133
            CTLCOLORLISTBOX = &H134
            CTLCOLORMSGBOX = &H132
            CTLCOLORSCROLLBAR = &H137
            CTLCOLORSTATIC = &H138
            CUT = &H300
            DDE_FIRST = &H3E0
            DDE_ACK = (DDE_FIRST + 4)
            DDE_ADVISE = (DDE_FIRST + 2)
            DDE_DATA = (DDE_FIRST + 5)
            DDE_EXECUTE = (DDE_FIRST + 8)
            DDE_INITIATE = (DDE_FIRST)
            DDE_LAST = (DDE_FIRST + 8)
            DDE_POKE = (DDE_FIRST + 7)
            DDE_REQUEST = (DDE_FIRST + 6)
            DDE_TERMINATE = (DDE_FIRST + 1)
            DDE_UNADVISE = (DDE_FIRST + 3)
            DEADCHAR = &H103
            DELETEITEM = &H2D
            DESTROY = &H2
            DESTROYCLIPBOARD = &H307
            DEVMODECHANGE = &H1B
            DRAWCLIPBOARD = &H308
            DRAWITEM = &H2B
            DROPFILES = &H233
            ENABLE = &HA
            ENDSESSION = &H16
            ENTERIDLE = &H121
            ENTERMENULOOP = &H211
            ERASEBKGND = &H14
            EXITMENULOOP = &H212
            FONTCHANGE = &H1D
            GETFONT = &H31
            GETDLGCODE = &H87
            GETHOTKEY = &H33
            GETMINMAXINFO = &H24
            GETTEXT = &HD
            GETTEXTLENGTH = &HE
            HOTKEY = &H312
            HSCROLL = &H114
            HSCROLLCLIPBOARD = &H30E
            ICONERASEBKGND = &H27
            IME_CHAR = &H286
            IME_COMPOSITION = &H10F
            IME_COMPOSITIONFULL = &H284
            IME_CONTROL = &H283
            IME_ENDCOMPOSITION = &H10E
            IME_KEYDOWN = &H290
            IME_KEYLAST = &H10F
            IME_KEYUP = &H291
            IME_NOTIFY = &H282
            IME_SELECT = &H285
            IME_SETCONTEXT = &H281
            IME_STARTCOMPOSITION = &H10D
            INITDIALOG = &H110
            INITMENU = &H116
            INITMENUPOPUP = &H117
            KEYDOWN = &H100
            KEYFIRST = &H100
            KEYLAST = &H108
            KEYUP = &H101
            KILLFOCUS = &H8
            LBUTTONDBLCLK = &H203
            LBUTTONDOWN = &H201
            LBUTTONUP = &H202
            MBUTTONDBLCLK = &H209
            MBUTTONDOWN = &H207
            MBUTTONUP = &H208
            MDIACTIVATE = &H222
            MDICASCADE = &H227
            MDICREATE = &H220
            MDIDESTROY = &H221
            MDIGETACTIVE = &H229
            MDIICONARRANGE = &H228
            MDIMAXIMIZE = &H225
            MDINEXT = &H224
            MDIREFRESHMENU = &H234
            MDIRESTORE = &H223
            MDISETMENU = &H230
            MDITILE = &H226
            MEASUREITEM = &H2C
            MENUCHAR = &H120
            MENUSELECT = &H11F
            MOUSEACTIVATE = &H21
            MOUSEFIRST = &H200
            MOUSELAST = &H209
            MOUSEMOVE = &H200
            MOVE = &H3
            NCACTIVATE = &H86
            NCCALCSIZE = &H83
            NCCREATE = &H81
            NCDESTROY = &H82
            NCHITTEST = &H84
            NCLBUTTONDBLCLK = &HA3
            NCLBUTTONDOWN = &HA1
            NCLBUTTONUP = &HA2
            NCMBUTTONDBLCLK = &HA9
            NCMBUTTONDOWN = &HA7
            NCMBUTTONUP = &HA8
            NCMOUSEMOVE = &HA0
            NCPAINT = &H85
            NCRBUTTONDBLCLK = &HA6
            NCRBUTTONDOWN = &HA4
            NCRBUTTONUP = &HA5
            NEXTDLGCTL = &H28
            NULL = &H0
            PAINT = &HF
            PAINTCLIPBOARD = &H309
            PAINTICON = &H26
            PALETTECHANGED = &H311
            PALETTEISCHANGING = &H310
            PARENTNOTIFY = &H210
            PASTE = &H302
            PENWINFIRST = &H380
            PENWINLAST = &H38F
            POWER = &H48
            Print = &H317
            PSD_ENVSTAMPRECT = (USER + 5)
            PSD_FULLPAGERECT = (USER + 1)
            PSD_GREEKTEXTRECT = (USER + 4)
            PSD_MARGINRECT = (USER + 3)
            PSD_MINMARGINRECT = (USER + 2)
            PSD_PAGESETUPDLG = (USER)
            PSD_YAFULLPAGERECT = (USER + 6)
            QUERYDRAGICON = &H37
            QUERYENDSESSION = &H11
            QUERYNEWPALETTE = &H30F
            QUERYOPEN = &H13
            QUEUESYNC = &H23
            QUIT = &H12
            RBUTTONDBLCLK = &H206
            RBUTTONDOWN = &H204
            RBUTTONUP = &H205
            RENDERALLFORMATS = &H306
            RENDERFORMAT = &H305
            SETCURSOR = &H20
            SETFOCUS = &H7
            SETFONT = &H30
            SETHOTKEY = &H32
            SETREDRAW = &HB
            SETTEXT = &HC
            Size = &H5
            SIZECLIPBOARD = &H30B
            SPOOLERSTATUS = &H2A
            SYSCHAR = &H106
            SYSCOLORCHANGE = &H15
            SYSCOMMAND = &H112
            SYSDEADCHAR = &H107
            SYSKEYDOWN = &H104
            SYSKEYUP = &H105
            SHOWWINDOW = &H18
            Timer = &H113
            TIMECHANGE = &H1E
            UNDO = &H304
            VKEYTOITEM = &H2E
            VSCROLL = &H115
            VSCROLLCLIPBOARD = &H30A
            WINDOWPOSCHANGED = &H47
            WINDOWPOSCHANGING = &H46
            WININICHANGE = &H1A
        End Enum 'Window Messages

        Public Shared Function GETTEXTLENGTH(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.GETTEXTLENGTH, 0, 0) + 1
        End Function
        Public Shared Property TEXT(ByVal hwnd As IntPtr) As String
            Get
                Dim length As Integer = GETTEXTLENGTH(hwnd)
                Dim Handle As IntPtr = Marshal.AllocHGlobal(length)
                SendMessage(hwnd, 13, length, Handle)
                TEXT = Marshal.PtrToStringAnsi(Handle)
                Marshal.FreeHGlobal(Handle)
            End Get
            Set(ByVal value As String)
                Dim handle As IntPtr = Marshal.StringToHGlobalAnsi(value)
                SendMessage(hwnd, &HC, IntPtr.Zero, handle)
                Marshal.FreeHGlobal(handle)
            End Set
        End Property
        Public Shared Property FONT(ByVal hwnd As IntPtr) As System.Drawing.Font
            Get
                Return System.Drawing.Font.FromHfont(SendMessage(hwnd, msg.GETFONT, 0, 0))
            End Get
            Set(ByVal value As System.Drawing.Font)
                SendMessage(hwnd, msg.SETFONT, value.ToHfont, True)
            End Set
        End Property
        Public Shared Function SETFOCUS(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.SETFOCUS, 0, 0)
        End Function
        Public Shared Function CLOSE(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.CLOSE, 0, 0)
        End Function
        Public Shared Function DESTROY(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.DESTROY, 0, 0)
        End Function
        Public Shared Function CLEAR(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.CLEAR, 0, 0)
        End Function
        Public Shared Function UNDO(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.UNDO, 0, 0)
        End Function
        Public Shared Function Copy(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.Copy, 0, 0)
        End Function
        Public Shared Function PASTE(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.PASTE, 0, 0)
        End Function
        Public Shared Function CUT(ByVal hwnd As IntPtr) As Integer
            Return SendMessage(hwnd, msg.CUT, 0, 0)
        End Function
        Public Shared Function SETREDRAW(ByVal hwnd As IntPtr, Optional ByVal redraw As Boolean = True) As Integer
            Return SendMessage(hwnd, msg.SETREDRAW, redraw, 0)
        End Function
        Public Shared Function KILLFOCUS(ByVal hwnd As IntPtr) As Boolean
            Return SendMessage(hwnd, msg.KILLFOCUS, 0, 0)
        End Function

        'listview
        Public Shared Function SETICONSPACING(ByVal lview As ListView, ByVal spaceX As Integer, ByVal spaceY As Integer) As Integer
            Return SETICONSPACING(lview.Handle, spaceX, spaceY)
        End Function
        Public Shared Function SETICONSPACING(ByVal hwnd As IntPtr, ByVal spaceX As Integer, ByVal spaceY As Integer) As Integer
            Return SendMessage(hwnd, &H1035, spaceX, spaceY)
        End Function

        Public Shared Function SYSCOMMAND(ByVal hwnd As IntPtr, ByVal command As SC, Optional ByVal lparam As Integer = 0) As Boolean
            Return SendMessage(hwnd, WM.msg.SYSCOMMAND, command, lparam)
        End Function
        Public Shared Function SYSCOMMAND(ByVal hwnd As IntPtr, ByVal command As SC, ByVal x As Short, ByVal y As Short) As Boolean
            Return SendMessage(hwnd, WM.msg.SYSCOMMAND, command, New DWORD(x, y))
        End Function
    End Class

    Public Class SPI
        <System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint:="SystemParametersInfo")> _
        Private Shared Function SystemParametersInfoGet(ByVal uAction As SPI.GetActions, ByVal uiParam As UInt32, ByRef pvParam As IntPtr, ByVal fuWinIni As UInt32) As Boolean
        End Function
        <System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint:="SystemParametersInfo")> _
        Private Shared Function SystemParametersInfoSet(ByVal uAction As SPI.SetActions, ByVal uiParam As UInt32, ByVal pvParam As IntPtr, ByVal fuWinIni As UInt32) As Boolean
        End Function

        Public Enum GetActions As UInt32
            ICONHORIZONTALSPACING = &HD
            ICONVERTICALSPACING = &H18
            BEEP = &H1
            MOUSE = &H3
            BORDER = &H5
            KEYBOARDSPEED = &HA
            SCREENSAVETIMEOUT = &HE
            SCREENSAVEACTIVE = &H10
            GRIDGRANULARITY = &H12
            KEYBOARDDELAY = &H16
            ICONTITLEWRAP = &H19
            MENUDROPALIGNMENT = &H1B
            ICONTITLELOGFONT = &H1F
            FASTTASKSWITCH = &H23
            DRAGFULLWINDOWS = &H26
            NONCLIENTMETRICS = &H29
            MINIMIZEDMETRICS = &H2B
            ICONMETRICS = &H2D
            WORKAREA = &H30
            HIGHCONTRAST = &H42
            KEYBOARDPREF = &H44
            SCREENREADER = &H46
            ANIMATION = &H48
            FONTSMOOTHING = &H4A
            LOWPOWERTIMEOUT = &H4F
            POWEROFFTIMEOUT = &H50
            LOWPOWERACTIVE = &H53
            POWEROFFACTIVE = &H54
            DEFAULTINPUTLANG = &H59
            WINDOWSEXTENSION = &H5C
            MOUSETRAILS = &H5E
            FILTERKEYS = &H32
            TOGGLEKEYS = &H34
            MOUSEKEYS = &H36
            SHOWSOUNDS = &H38
            STICKYKEYS = &H3A
            ACCESSTIMEOUT = &H3C
            SERIALKEYS = &H3E
            SOUNDSENTRY = &H40
            SNAPTODEFBUTTON = &H5F
            MOUSEHOVERWIDTH = &H62
            MOUSEHOVERHEIGHT = &H64
            MOUSEHOVERTIME = &H66
            WHEELSCROLLLINES = &H68
            MENUSHOWDELAY = &H6A
            WHEELSCROLLCHARS = &H6C
            SCREENSAVERRUNNING = &H72
            MOUSESPEED = &H70
            DESKWALLPAPER = &H73
            AUDIODESCRIPTION = &H74
            SCREENSAVESECURE = &H76
            SHOWIMEUI = &H6E
            ACTIVEWINDOWTRACKING = &H1000
            MENUANIMATION = &H1002
            COMBOBOXANIMATION = &H1004
            LISTBOXSMOOTHSCROLLING = &H1006
            GRADIENTCAPTIONS = &H1008
            KEYBOARDCUES = &H100A
            MENUUNDERLINES = KEYBOARDCUES
            ACTIVEWNDTRKZORDER = &H100C
            HOTTRACKING = &H100E
            MENUFADE = &H1012
            SELECTIONFADE = &H1014
            TOOLTIPANIMATION = &H1016
            TOOLTIPFADE = &H1018
            CURSORSHADOW = &H101A
            MOUSESONAR = &H101C
            MOUSECLICKLOCK = &H101E
            MOUSEVANISH = &H1020
            FLATMENU = &H1022
            DROPSHADOW = &H1024
            BLOCKSENDINPUTRESETS = &H1026
            UIEFFECTS = &H103E
            DISABLEOVERLAPPEDCONTENT = &H1040
            CLIENTAREAANIMATION = &H1042
            CLEARTYPE = &H1048
            SPEECHRECOGNITION = &H104A
            FOREGROUNDLOCKTIMEOUT = &H2000
            ACTIVEWNDTRKTIMEOUT = &H2002
            FOREGROUNDFLASHCOUNT = &H2004
            CARETWIDTH = &H2006
            MOUSECLICKLOCKTIME = &H2008
            FONTSMOOTHINGTYPE = &H200A
            FONTSMOOTHINGCONTRAST = &H200C
            FOCUSBORDERWIDTH = &H200E
            FOCUSBORDERHEIGHT = &H2010
            FONTSMOOTHINGORIENTATION = &H2012
            MINIMUMHITRADIUS = &H2014
            MESSAGEDURATION = &H2016
        End Enum
        Public Enum SetActions As UInt32
            BEEP = &H2
            MOUSE = &H4
            BORDER = &H6
            KEYBOARDSPEED = &HB
            SCREENSAVETIMEOUT = &HF
            SCREENSAVEACTIVE = &H11
            GRIDGRANULARITY = &H13
            DESKWALLPAPER = &H14
            DESKPATTERN = &H15
            KEYBOARDDELAY = &H17
            ICONTITLEWRAP = &H1A
            MENUDROPALIGNMENT = &H1C
            DOUBLECLKWIDTH = &H1D
            DOUBLECLKHEIGHT = &H1E
            DOUBLECLICKTIME = &H20
            MOUSEBUTTONSWAP = &H21
            ICONTITLELOGFONT = &H22
            FASTTASKSWITCH = &H24
            DRAGFULLWINDOWS = &H25
            NONCLIENTMETRICS = &H2A
            MINIMIZEDMETRICS = &H2C
            ICONMETRICS = &H2E
            WORKAREA = &H2F
            PENWINDOWS = &H31
            HIGHCONTRAST = &H43
            KEYBOARDPREF = &H45
            SCREENREADER = &H47
            ANIMATION = &H49
            FONTSMOOTHING = &H4B
            DRAGWIDTH = &H4C
            DRAGHEIGHT = &H4D
            HANDHELD = &H4E
            LOWPOWERTIMEOUT = &H51
            POWEROFFTIMEOUT = &H52
            LOWPOWERACTIVE = &H55
            POWEROFFACTIVE = &H56
            CURSORS = &H57
            ICONS = &H58
            DEFAULTINPUTLANG = &H5A
            LANGTOGGLE = &H5B
            MOUSETRAILS = &H5D
            SCREENSAVERRUNNING = &H61
            FILTERKEYS = &H33
            TOGGLEKEYS = &H35
            MOUSEKEYS = &H37
            SHOWSOUNDS = &H39
            STICKYKEYS = &H3B
            ACCESSTIMEOUT = &H3D
            SERIALKEYS = &H3F
            SOUNDSENTRY = &H41
            SNAPTODEFBUTTON = &H60
            MOUSEHOVERWIDTH = &H63
            MOUSEHOVERHEIGHT = &H65
            MOUSEHOVERTIME = &H67
            WHEELSCROLLLINES = &H69
            MENUSHOWDELAY = &H6B
            WHEELSCROLLCHARS = &H6D
            SHOWIMEUI = &H6F
            MOUSESPEED = &H71
            AUDIODESCRIPTION = &H75
            SCREENSAVESECURE = &H77
            ACTIVEWINDOWTRACKING = &H1001
            MENUANIMATION = &H1003
            COMBOBOXANIMATION = &H1005
            LISTBOXSMOOTHSCROLLING = &H1007
            GRADIENTCAPTIONS = &H1009
            KEYBOARDCUES = &H100B
            MENUUNDERLINES = KEYBOARDCUES
            ACTIVEWNDTRKZORDER = &H100D
            HOTTRACKING = &H100F
            MENUFADE = &H1013
            SELECTIONFADE = &H1015
            TOOLTIPANIMATION = &H1017
            TOOLTIPFADE = &H1019
            CURSORSHADOW = &H101B
            MOUSESONAR = &H101D
            MOUSECLICKLOCK = &H101F
            MOUSEVANISH = &H1021
            FLATMENU = &H1023
            DROPSHADOW = &H1025
            BLOCKSENDINPUTRESETS = &H1027
            UIEFFECTS = &H103F
            DISABLEOVERLAPPEDCONTENT = &H1041
            CLIENTAREAANIMATION = &H1043
            CLEARTYPE = &H1049
            SPEECHRECOGNITION = &H104B
            FOREGROUNDLOCKTIMEOUT = &H2001
            ACTIVEWNDTRKTIMEOUT = &H2003
            FOREGROUNDFLASHCOUNT = &H2005
            CARETWIDTH = &H2007
            MOUSECLICKLOCKTIME = &H2009
            FONTSMOOTHINGTYPE = &H200B
            FONTSMOOTHINGCONTRAST = &H200D
            FOCUSBORDERWIDTH = &H200F
            FOCUSBORDERHEIGHT = &H2011
            FONTSMOOTHINGORIENTATION = &H2013
            MINIMUMHITRADIUS = &H2015
            MESSAGEDURATION = &H2017
        End Enum
        Public Enum FontSmoothing As Int32
            STANDARD = &H1
            CLEARTYPE = &H2
            DOCKING = &H8000
        End Enum
        Public Enum FontSmoothingOrientation As Int32
            BGR = &H0
            RGB = &H1
        End Enum

        Public Shared Function SetParameter(ByVal parameter As SetActions, ByVal uparam As UInteger, ByVal pvParam As IntPtr) As Boolean
            Return SystemParametersInfoSet(parameter, uparam, pvParam, 1)
        End Function
        Public Shared Function SetParameter(ByVal parameter As SetActions, ByVal pvParam As IntPtr) As Boolean
            Return SetParameter(parameter, 0, pvParam)
        End Function
        Public Shared Function GetParameter(ByVal parameter As GetActions) As IntPtr
            SystemParametersInfoGet(parameter, 0, GetParameter, 0)
        End Function
    End Class

    Public Class DC
        Implements System.IDisposable

        Private Declare Function BitBlt Lib "gdi32" (ByVal hdc As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As UInteger) As Boolean
        Private Declare Function GetPixel Lib "gdi32" Alias "GetPixel" (ByVal hdc As IntPtr, ByVal X As Int32, ByVal Y As Int32) As Int32
        Private Declare Function SetPixel Lib "gdi32" Alias "SetPixel" (ByVal hdc As IntPtr, ByVal X As Int32, ByVal Y As Int32, ByVal crColor As UInt32) As UInt32
        Private Declare Function ReleaseDC Lib "user32" (ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Boolean
        Private Declare Function GetClipBox Lib "gdi32" (ByVal hdc As IntPtr, ByRef lprc As WRECT) As Integer
        Private Declare Function GetClipRgn Lib "gdi32" (ByVal hdc As IntPtr, ByRef hrgn As Region) As Integer
        Private Declare Function GetRandomRgn Lib "gdi32" (ByVal hdc As IntPtr, ByRef hrgn As Region, ByVal inum As Integer) As Integer

        Private managedtype As DCSource
        Private managedobject As Object
        Private managedgraphics As Graphics
        Private hdc As IntPtr
        Private _disposed As Boolean
        Public Enum DCSource
            None
            Handle
            Graphics
        End Enum
        Sub New(ByVal g As Graphics)
            Me.managedobject = g
            Me.managedtype = DCSource.Graphics
            Me.hdc = g.GetHdc
        End Sub
        Sub New(ByVal hwnd As IntPtr, ByVal hdc As IntPtr)
            Me.managedobject = hwnd
            Me.managedtype = DCSource.Handle
            Me.hdc = hdc
        End Sub
        Sub New()
            Me.managedobject = Nothing
            Me.managedtype = DCSource.None
        End Sub
        Public ReadOnly Property Source() As DCSource
            Get
                Return Me.managedtype
            End Get
        End Property
        Public Sub SetPixel(ByVal X As Integer, ByVal Y As Integer, ByVal C As Color)
            SetPixel(Me.hdc, X, Y, C.ToArgb)
        End Sub
        Public Function GetPixel(ByVal X As Integer, ByVal Y As Integer) As Color
            Return ColorTranslator.FromOle(GetPixel(Me.hdc, X, Y))
        End Function
        Public Property Pixel(ByVal X As Integer, ByVal Y As Integer) As Color
            Get
                Return GetPixel(X, Y)
            End Get
            Set(ByVal value As Color)
                SetPixel(X, Y, value)
            End Set
        End Property
        Public Enum RasterOperation As UInteger
            ''' <summary>default operation</summary>
            NORMAL = RasterOperation.SRCCOPY Or RasterOperation.CAPTUREBLT
            ''' <summary>dest = source</summary>
            SRCCOPY = &HCC0020
            ''' <summary>dest = source OR dest</summary>
            SRCPAINT = &HEE0086
            ''' <summary>dest = source AND dest</summary>
            SRCAND = &H8800C6
            ''' <summary>dest = source XOR dest</summary>
            SRCINVERT = &H660046
            ''' <summary>dest = source AND (NOT dest)</summary>
            SRCERASE = &H440328
            ''' <summary>dest = (NOT source)</summary>
            NOTSRCCOPY = &H330008
            ''' <summary>dest = (NOT src) AND (NOT dest)</summary>
            NOTSRCERASE = &H1100A6
            ''' <summary>dest = (source AND pattern)</summary>
            MERGECOPY = &HC000CA
            ''' <summary>dest = (NOT source) OR dest</summary>
            MERGEPAINT = &HBB0226
            ''' <summary>dest = pattern</summary>
            PATCOPY = &HF00021
            ''' <summary>dest = DPSnoo</summary>
            PATPAINT = &HFB0A09
            ''' <summary>dest = pattern XOR dest</summary>
            PATINVERT = &H5A0049
            ''' <summary>dest = (NOT dest)</summary>
            DSTINVERT = &H550009
            ''' <summary>dest = BLACK</summary>
            BLACKNESS = &H42
            ''' <summary>dest = WHITE</summary>
            WHITENESS = &HFF0062
            ''' <summary>
            ''' Capture window as seen on screen.  This includes layered windows
            ''' such as WPF windows with AllowsTransparency="true"
            ''' </summary>
            CAPTUREBLT = &H40000000
        End Enum

        Public ReadOnly Property ClipBox() As Rectangle
            Get
                Dim w As WRECT
                GetClipBox(Me.hdc, w)
                Return w.Value
            End Get
        End Property
        Public ReadOnly Property ClipSize() As Size
            Get
                Return Me.ClipBox.Size
            End Get
        End Property

        Public Property Handle() As IntPtr
            Get
                Return Me.hdc
            End Get
            Set(ByVal value As IntPtr)
                Me.hdc = value
            End Set
        End Property

        Public ReadOnly Property Disposed() As Boolean
            Get
                Return Me._disposed
            End Get
        End Property

        Public Sub Draw(ByVal source As Graphics, ByVal destrect As Rectangle, ByVal sourceoffset As Point, ByVal operation As RasterOperation)
            Dim hdc As IntPtr = source.GetHdc
            Draw(hdc, destrect, sourceoffset, operation)
            source.ReleaseHdc(hdc)
        End Sub
        Public Sub Draw(ByVal source As DC, ByVal destrect As Rectangle, ByVal sourceoffset As Point, ByVal operation As RasterOperation)
            Draw(source.hdc, destrect, sourceoffset, operation)
        End Sub
        Public Sub Draw(ByVal sourcehdc As IntPtr, ByVal destrect As Rectangle, ByVal sourceoffset As Point, ByVal operation As RasterOperation)
            BitBlt(Me.hdc, destrect.X, destrect.Y, destrect.Width, destrect.Height, sourcehdc, sourceoffset.X, sourceoffset.Y, operation)
        End Sub

        Public Sub CopyTo(ByVal destination As Graphics, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            CopyTo(destination, Me.ClipBox, operation)
        End Sub
        Public Sub CopyTo(ByVal destination As Graphics, ByVal destrect As Rectangle, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            CopyTo(destination, destrect, New Point(0, 0), operation)
        End Sub
        Public Sub CopyTo(ByVal destination As Graphics, ByVal destrect As Rectangle, ByVal sourceoffset As Point, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            Dim hdc As IntPtr = destination.GetHdc
            CopyTo(hdc, destrect, sourceoffset, operation)
            destination.ReleaseHdc(hdc)
        End Sub
        Public Sub CopyTo(ByVal destination As DC, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            CopyTo(destination.hdc, Me.ClipBox, New Point(0, 0), operation)
        End Sub
        Public Sub CopyTo(ByVal destination As DC, ByVal destrect As Rectangle, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            CopyTo(destination.hdc, destrect, New Point(0, 0), operation)
        End Sub
        Public Sub CopyTo(ByVal destination As DC, ByVal destrect As Rectangle, ByVal sourceoffset As Point, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            CopyTo(destination.hdc, destrect, sourceoffset, operation)
        End Sub
        Public Sub CopyTo(ByVal desthdc As IntPtr, ByVal destrect As Rectangle, ByVal sourceoffset As Point, Optional ByVal operation As RasterOperation = RasterOperation.NORMAL)
            BitBlt(desthdc, destrect.X, destrect.Y, destrect.Width, destrect.Height, Me.hdc, sourceoffset.X, sourceoffset.Y, operation)
        End Sub

        Public Function ToBitmap(Optional ByVal operation As RasterOperation = RasterOperation.NORMAL) As Bitmap
            Return ToBitmap(Me.ClipSize, operation)
        End Function
        Public Function ToBitmap(ByVal Resolution As Size, Optional ByVal operation As RasterOperation = RasterOperation.SRCCOPY Or RasterOperation.CAPTUREBLT) As Bitmap
            ToBitmap = New Bitmap(Resolution.Width, Resolution.Height)
            Dim g As Graphics = Graphics.FromImage(ToBitmap)
            Dim ghdc As IntPtr = g.GetHdc
            BitBlt(ghdc, 0, 0, Resolution.Width, Resolution.Height, Me.hdc, 0, 0, operation)
            g.ReleaseHdc(ghdc)
            g.Dispose()
        End Function

        Public ReadOnly Property Graphics() As Graphics
            Get
                If Me.managedgraphics Is Nothing Then Me.managedgraphics = Graphics.FromHdc(Me.hdc)
                Return Me.managedgraphics
            End Get
        End Property
        Public Shared Function FromHandle(ByVal handle As IntPtr) As DC
            FromHandle = New DC()
            FromHandle.hdc = handle
        End Function

        Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
            If Me._disposed = False Then
                Select Case managedtype
                    Case DCSource.Handle
                        ReleaseDC(CType(Me.managedobject, IntPtr), Me.hdc)
                    Case DCSource.Graphics
                        CType(Me.managedobject, Graphics).ReleaseHdc(Me.hdc)
                End Select
                If managedgraphics IsNot Nothing Then managedgraphics.Dispose()
                Me.managedgraphics = Nothing
                Me.managedobject = Nothing
                Me.managedtype = Nothing
                Me.hdc = Nothing
                Me._disposed = True
            End If
        End Sub
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class

    Public Structure ShellExecuteInfo
        Private Declare Function ShellExecuteEx Lib "shell32.dll" Alias "ShellExecuteExA" (ByRef lpExecInfo As ShellExecuteInfo) As Boolean
        Sub New(ByVal Verb As Verb)
            Me.lpVerb = Verb.ToString()
        End Sub
        Private cbSize As Integer
        Public fMask As Mask
        Public hwnd As IntPtr
        Public lpVerb As String
        Public lpFile As String
        Public lpParameters As String
        Public lpDirectory As String
        Public nShow As SW
        Public hInstApp As IntPtr
        Public lpIDList As IntPtr
        Public lpClass As String
        Public hkeyClass As IntPtr
        Public dwHotKey As Integer
        Public hIcon As IntPtr
        Public hProcess As IntPtr
        Public Property hMonitor() As IntPtr
            Get
                Return Me.hIcon
            End Get
            Set(ByVal value As IntPtr)
                Me.hIcon = value
            End Set
        End Property

        Public Enum Mask As Integer
            NONE = &H0
            CLASSNAME = &H1
            CLASSKEY = &H3
            IDLIST = &H4
            INVOKEIDLIST = &HC
            ICON = &H10
            HOTKEY = &H20
            NOCLOSEPROCESS = &H40
            CONNECTNETDRV = &H80
            NOASYNC = &H100
            DOENVSUBST = &H200
            FLAG_NO_UI = &H400
            UNICODE = &H4000
            NO_CONSOLE = &H8000
            ASYNCOK = &H100000
            NOQUERYCLASSSTORE = &H1000000
            HMONITOR = &H200000
            NOZONECHECKS = &H800000
            WAITFORINPUTIDLE = &H2000000
            FLAG_LOG_USAGE = &H4000000
        End Enum
        Public Enum SW As Integer
            ''' <summary>
            ''' No SW command, default value.
            ''' </summary>
            NONE
            ''' <summary>
            ''' Hides the window and activates another window.
            ''' </summary>
            HIDE
            ''' <summary>
            ''' Maximizes the specified window.
            ''' </summary>
            MAXIMIZE
            ''' <summary>
            ''' Minimizes the specified window and activates the next top-level window in the z-order.
            ''' </summary>
            MINIMIZE
            ''' <summary>
            ''' Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and position. 
            ''' An application should specify this flag when restoring a minimized window.
            ''' </summary>
            RESTORE
            ''' <summary>
            ''' Activates the window and displays it in its current size and position.
            ''' </summary>
            SHOW
            ''' <summary>
            ''' Sets the show state based on the SW_ flag specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application. 
            ''' An application should call ShowWindow with this flag to set the initial show state of its main window.
            ''' </summary>
            SHOWDEFAULT
            ''' <summary>
            ''' Activates the window and displays it as a maximized window.
            ''' </summary>
            SHOWMAXIMIZED
            ''' <summary>
            ''' Activates the window and displays it as a minimized window.
            ''' </summary>
            SHOWMINIMIZED
            ''' <summary>
            ''' Displays the window as a minimized window. The active window remains active.
            ''' </summary>
            SHOWMINNOACTIVE
            ''' <summary>
            ''' Displays the window in its current state. The active window remains active.
            ''' </summary>
            SHOWNA
            ''' <summary>
            ''' Displays a window in its most recent size and position. The active window remains active.
            ''' </summary>
            SHOWNOACTIVATE
            ''' <summary>
            ''' Activates and displays a window. If the window is minimized or maximized, Windows restores it to its original size and position.
            ''' An application should specify this flag when displaying the window for the first time.
            ''' </summary>
            SHOWNORMAL
        End Enum
        Public Enum Verb
            none
            edit
            explore
            find
            open
            print
            properties
        End Enum

        Public Function Execute() As Boolean
            Me.cbSize = Marshal.SizeOf(Me)
            Return ShellExecuteEx(Me)
        End Function
    End Structure

    Public Declare Function VkKeyScan Lib "user32" Alias "VkKeyScanA" (ByVal ch As Char) As Short
    Public Declare Function MapVirtualKey Lib "User32.dll" Alias "MapVirtualKeyA" (ByVal uCode As UInt32, ByVal uMapType As MAPVK) As UInt32
    Public Enum MAPVK As UInt32
        ''' <summary>uCode is a virtual-key code and is translated into a scan code.
        ''' If it is a virtual-key code that does not distinguish between left- and
        ''' right-hand keys, the left-hand scan code is returned.
        ''' If there is no translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        VK_TO_VSC = 0
        ''' <summary>uCode is a scan code and is translated into a virtual-key code that
        ''' does not distinguish between left- and right-hand keys. If there is no
        ''' translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        VSC_TO_VK = 1
        ''' <summary>uCode is a virtual-key code and is translated into an unshifted
        ''' character value in the low-order word of the return value. Dead keys (diacritics)
        ''' are indicated by setting the top bit of the return value. If there is no
        ''' translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        VK_TO_CHAR = 2
        ''' <summary>Windows NT/2000/XP: uCode is a scan code and is translated into a
        ''' virtual-key code that distinguishes between left- and right-hand keys. If
        ''' there is no translation, the function returns 0.
        ''' </summary>
        ''' <remarks></remarks>
        VSC_TO_VK_EX = 3
    End Enum
    <StructLayout(LayoutKind.Explicit)> Public Structure Input
        Sub New(ByVal dx As Integer, ByVal dy As Integer, ByVal flags As MouseEvent, Optional ByVal data As MouseData = 0)
            If (flags And MouseEvent.MoveScreen) = MouseEvent.MoveScreen Then
                'convert to screen absolute
                dx = dx / My.Computer.Screen.Bounds.Width * UShort.MaxValue
                dy = dy / My.Computer.Screen.Bounds.Height * UShort.MaxValue
                flags -= MouseEvent.MoveScreen
                If Not (flags And MouseEvent.MoveAbsolute) = MouseEvent.MoveAbsolute Then
                    flags += MouseEvent.MoveAbsolute
                End If
            End If
            Me.type = dwType.MOUSE
            With Me.mi
                .dx = dx
                .dy = dy
                .time = 0
                .dwExtraInfo = 0
                .mouseData = data
                .dwFlags = flags
            End With
        End Sub
        Sub New(ByVal key As Keys, ByVal keyevent As KeyEvent)
            Me.type = dwType.KEYBOARD
            Dim extended As Boolean = False
            If key = Keys.Shift Then key = &H10
            If key = Keys.Control Then key = &H11
            If key = Keys.Menu Then key = &H12
            If key = Keys.LControlKey Or key = Keys.RControlKey Then extended = True
            If key = Keys.LMenu Or key = Keys.RMenu Then extended = True
            If key = Keys.LShiftKey Or key = Keys.RShiftKey Then extended = True
            With Me.ki
                .wVk = key
                .dwFlags = keyevent
                If extended Then .dwFlags += KEYBDINPUT.KEYEVENTF.EXTENDEDKEY
                .time = 0
                .dwExtraInfo = 0
            End With
        End Sub
        Sub New(ByVal msg As Integer, ByVal ParamL As Short, ByVal ParamH As Short)
            Me.type = dwType.HARDWARE
            With Me.hi
                .uMsg = msg
                .wParamL = ParamL
                .wParamH = ParamH
            End With
        End Sub

        <FieldOffset(0)> Private type As dwType
        <FieldOffset(4)> Private mi As MOUSEINPUT
        <FieldOffset(4)> Private ki As KEYBDINPUT
        <FieldOffset(4)> Private hi As HARDWAREINPUT

        Private Structure MOUSEINPUT
            Public dx As Integer
            Public dy As Integer
            Public mouseData As Integer
            Public dwFlags As MOUSEEVENTF
            Public time As Integer
            Public dwExtraInfo As IntPtr
            Public Enum MOUSEEVENTF As Integer
                MOVE = &H1
                LEFTDOWN = &H2
                LEFTUP = &H4
                RIGHTDOWN = &H8
                RIGHTUP = &H10
                MIDDLEDOWN = &H20
                MIDDLEUP = &H40
                XDOWN = &H80
                XUP = &H100
                WHEEL = &H800
                VIRTUALDESK = &H4000
                ABSOLUTE = &H8000
            End Enum
        End Structure
        Private Structure KEYBDINPUT
            Public wVk As Short
            Public wScan As Short
            Public dwFlags As KEYEVENTF
            Public time As Integer
            Public dwExtraInfo As IntPtr
            Public Enum KEYEVENTF As Integer
                KEYDOWN = 0
                EXTENDEDKEY = 1
                KEYUP = 2
                UNICODE = 4
                SCANCODE = 8
            End Enum
        End Structure
        Private Structure HARDWAREINPUT
            Public uMsg As Integer
            Public wParamL As Short
            Public wParamH As Short
        End Structure
        Private Enum dwType As Integer
            MOUSE = 0
            KEYBOARD = 1
            HARDWARE = 2
        End Enum

        Public Enum MouseEvent
            ''' <summary>
            ''' Moves the cursor with the offset dx and dy
            ''' </summary>
            Move = &H1
            ''' <summary>
            ''' Places the cursor at the screen coordinates dx and dy
            ''' </summary>
            MoveScreen = &H1000
            ''' <summary>
            ''' Places the cursor at the screen using dx and dy ranging from 0 (left/top) to 65535 (right/bottom)
            ''' </summary>
            MoveAbsolute = Move Or &H8000
            ''' <summary>
            ''' Places the cursor at the desktop using dx and dy ranging from 0 (left/top) to 65535 (right/bottom)
            ''' </summary>
            MoveVirtualDesktop = MoveAbsolute Or &H4000
            ''' <summary>
            ''' Press the left mouse button
            ''' </summary>
            LeftDown = &H2
            ''' <summary>
            ''' Release the left mouse button
            ''' </summary>
            LeftUp = &H4
            ''' <summary>
            ''' Press the right mouse button
            ''' </summary>
            RightDown = &H8
            ''' <summary>
            ''' Release the right mouse button
            ''' </summary>
            RightUp = &H10
            ''' <summary>
            ''' Press the middle mouse button
            ''' </summary>
            MiddleDown = &H30
            ''' <summary>
            ''' Release the middle mouse button
            ''' </summary>
            MiddleUp = &H40
            ''' <summary>
            ''' Press the XButton specified in the data member
            ''' </summary>
            XDown = &H80
            ''' <summary>
            ''' Release the XButton specified in the data member
            ''' </summary>
            XUp = &H100
            ''' <summary>
            ''' Scroll the vertical mousewheel with the delta count of the data member
            ''' </summary>
            MouseVWheel = &H800
            ''' <summary>
            ''' Scroll the horizontal mousewheel with the delta count of the data member
            ''' </summary>
            MouseHWheel = &H20E
        End Enum
        Public Enum MouseData As Integer
            XButton1 = 1
            XButton2 = 2
            Wheel_Delta_Backward = -120
            Wheel_Delta_Forward = 120
            Wheel_Delta_Left = -120
            Wheel_Delta_Right = 120
        End Enum
        Public Enum KeyEvent
            Down = 0
            Up = 2
        End Enum

        Private Declare Function SendInput Lib "user32.dll" (ByVal cInputs As Integer, ByVal pInputs() As Input, ByVal cbSize As Integer) As Integer
        Public Shared Function Send(ByVal ParamArray inputs() As Input) As Boolean
            Return SendInput(inputs.Count, inputs, Marshal.SizeOf(GetType(Input)))
        End Function
        Public Function Send() As Boolean
            Return Send(Me)
        End Function
    End Structure

    <StructLayout(LayoutKind.Explicit)> Public Structure WORD
        Sub New(ByVal value As Short)
            Me.Short1 = value
        End Sub
        Shared Widening Operator CType(ByVal w As WORD) As Short
            Return w.Short1
        End Operator
        <FieldOffset(0)> Public Short1 As Short
        <FieldOffset(0)> Public UShort1 As UShort
        <FieldOffset(0)> Public Byte1 As Byte
        <FieldOffset(1)> Public Byte2 As Byte
        Public Shared Function FromBB(ByVal Byte1 As Byte, ByVal Byte2 As Byte) As WORD
            FromBB = New WORD
            FromBB.Byte1 = Byte1
            FromBB.Byte2 = Byte2
        End Function
    End Structure
    <StructLayout(LayoutKind.Explicit)> Public Structure DWORD
        Sub New(ByVal value As Integer)
            Me.Integer1 = value
        End Sub
        Sub New(ByVal Short1 As Short, ByVal Short2 As Short)
            Me.Short1 = Short1
            Me.Short2 = Short2
        End Sub
        Shared Widening Operator CType(ByVal w As DWORD) As Integer
            Return w.Integer1
        End Operator
        Shared Widening Operator CType(ByVal w As DWORD) As IntPtr
            Return w.Integer1
        End Operator
        <FieldOffset(0)> Public Integer1 As Integer
        <FieldOffset(0)> Public UInteger1 As UInteger
        <FieldOffset(0)> Public Short1 As Short
        <FieldOffset(0)> Public UShort1 As UShort
        <FieldOffset(2)> Public Short2 As Short
        <FieldOffset(2)> Public UShort2 As UShort
        <FieldOffset(0)> Public Byte1 As Byte
        <FieldOffset(1)> Public Byte2 As Byte
        <FieldOffset(2)> Public Byte3 As Byte
        <FieldOffset(3)> Public Byte4 As Byte
        Public Shared Function FromUsBB(ByVal UShort1 As UShort, ByVal Byte1 As Byte, ByVal Byte2 As Byte) As DWORD
            FromUsBB = New DWORD
            FromUsBB.UShort1 = UShort1
            FromUsBB.Byte3 = Byte1
            FromUsBB.Byte4 = Byte2
        End Function
        Public Shared Function FromSBB(ByVal Short1 As Short, ByVal Byte1 As Byte, ByVal Byte2 As Byte) As DWORD
            FromSBB = New DWORD
            FromSBB.Short1 = Short1
            FromSBB.Byte3 = Byte1
            FromSBB.Byte4 = Byte2
        End Function
        Public Shared Function FromBBBB(ByVal Byte1 As Byte, ByVal Byte2 As Byte, ByVal Byte3 As Byte, ByVal Byte4 As Byte) As DWORD
            FromBBBB = New DWORD
            FromBBBB.Byte1 = Byte1
            FromBBBB.Byte2 = Byte2
            FromBBBB.Byte3 = Byte3
            FromBBBB.Byte4 = Byte4
        End Function
    End Structure
    <StructLayout(LayoutKind.Explicit)> Public Structure QWORD
        Sub New(ByVal value As Long)
            Me.Long1 = value
        End Sub
        Shared Widening Operator CType(ByVal w As QWORD) As Long
            Return w.Long1
        End Operator
        <FieldOffset(0)> Public Long1 As Long
        <FieldOffset(0)> Public ULong1 As ULong
        <FieldOffset(0)> Public Integer1 As Integer
        <FieldOffset(0)> Public UInteger1 As UInteger
        <FieldOffset(4)> Public Integer2 As Integer
        <FieldOffset(4)> Public UInteger2 As UInteger
        <FieldOffset(0)> Public Short1 As Short
        <FieldOffset(0)> Public UShort1 As UShort
        <FieldOffset(2)> Public Short2 As Short
        <FieldOffset(2)> Public UShort2 As UShort
        <FieldOffset(4)> Public Short3 As Short
        <FieldOffset(4)> Public UShort3 As UShort
        <FieldOffset(6)> Public Short4 As Short
        <FieldOffset(6)> Public UShort4 As UShort
        <FieldOffset(0)> Public Byte1 As Byte
        <FieldOffset(1)> Public Byte2 As Byte
        <FieldOffset(2)> Public Byte3 As Byte
        <FieldOffset(3)> Public Byte4 As Byte
        <FieldOffset(4)> Public Byte5 As Byte
        <FieldOffset(5)> Public Byte6 As Byte
        <FieldOffset(6)> Public Byte7 As Byte
        <FieldOffset(7)> Public Byte8 As Byte
    End Structure

    Public Structure WPOINT
        Public X As Integer
        Public Y As Integer
        Sub New(ByVal X As Integer, ByVal Y As Integer)
            Me.X = X
            Me.Y = Y
        End Sub
        Sub New(ByVal p As Point)
            Me.X = p.X
            Me.Y = p.Y
        End Sub
        Public Property Value() As Point
            Get
                Return New Point(Me.X, Me.Y)
            End Get
            Set(ByVal value As Point)
                Me.X = value.X
                Me.Y = value.Y
            End Set
        End Property
    End Structure
    Public Structure WRECT
        Public Left As Integer, Top As Integer, Right As Integer, Bottom As Integer
        Sub New(ByVal r As Rectangle)
            Me.Value = r
        End Sub
        Public Property Value() As Rectangle
            Get
                Return New Rectangle(Left, Top, Right - Left, Bottom - Top)
            End Get
            Set(ByVal value As Rectangle)
                Me.Left = value.Left
                Me.Right = value.Right
                Me.Top = value.Top
                Me.Bottom = value.Bottom
            End Set
        End Property
    End Structure

    Public Class MCI
        <DllImport("winmm.dll")> _
        Private Shared Function mciGetErrorString(ByVal fdwError As Integer, ByVal lpszErrorText As System.Text.StringBuilder, ByVal cchErrorText As UInt32) As Boolean
        End Function
        <DllImport("winmm.dll")> _
        Private Shared Function mciSendString(ByVal strCommand As String, ByVal strReturn As System.Text.StringBuilder, ByVal iReturnLength As Integer, ByVal hwndCallback As IntPtr) As Long
        End Function
        <DllImport("winmm.dll")> _
        Private Shared Function mciSendCommand(ByVal IDDevice As Integer, ByVal uMsg As UInt32, ByVal fdwCommand As Integer, ByVal dwParam As Integer) As Long
        End Function

        Private Shared Function GetErrorString(ByVal ErrorCode As Long) As String
            With New QWORD(ErrorCode)
                GetErrorString = "Device: " & .Integer2 & " - "
                Dim buff As New System.Text.StringBuilder(128)
                If mciGetErrorString(.Integer1, buff, buff.Capacity) Then
                    GetErrorString &= buff.ToString
                Else
                    GetErrorString &= "Error code: " & .Integer1
                End If
            End With
        End Function
        <DebuggerStepThrough()> _
        Public Shared Function SendString(ByVal command As String, ByVal callback As IntPtr, ByVal returnlength As Integer) As String
            Dim buff As System.Text.StringBuilder = Nothing
            If returnlength > 0 Then buff = New System.Text.StringBuilder(returnlength)
            Dim err As Long = mciSendString(command, buff, returnlength, callback)
            If err <> 0 Then
                LastError = New Exception(GetErrorString(err))
                Throw LastError
                Return "ERROR"
            End If
            If returnlength = 0 Then Return Nothing Else Return buff.ToString
        End Function
        <DebuggerStepThrough()> _
        Public Shared Sub SendString(ByVal command As String, ByVal callback As IntPtr)
            SendString(command, callback, 0)
        End Sub
        <DebuggerStepThrough()> _
        Public Shared Sub SendCommand(ByVal DeviceID As Integer, ByVal Message As UInt32, ByVal Command As IntPtr, ByVal Parameter As Integer)
            Dim err As Long = mciSendCommand(DeviceID, Message, Command, Parameter)
            If err <> 0 Then
                LastError = New Exception(GetErrorString(err))
                Throw LastError
            End If
        End Sub
    End Class

    Public Class DESKTOP
        Public Declare Auto Function GetThreadDesktop Lib "user32.dll" (ByVal threadId As Integer) As IntPtr
        Public Declare Auto Function OpenInputDesktop Lib "user32.dll" (ByVal flags As Integer, <MarshalAs(UnmanagedType.Bool)> ByVal inherit As Boolean, ByVal desiredAccess As Integer) As IntPtr
        Public Declare Auto Function CreateDesktop Lib "user32.dll" (ByVal desktop As String, ByVal device As String, ByVal devmode As IntPtr, ByVal flags As Integer, ByVal desiredAccess As Integer, ByVal lpsa As IntPtr) As IntPtr
        Public Declare Auto Function SetThreadDesktop Lib "user32.dll" (ByVal desktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Public Declare Auto Function SwitchDesktop Lib "user32.dll" (ByVal desktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Public Declare Auto Function CloseDesktop Lib "user32.dll" (ByVal desktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Class
End Class