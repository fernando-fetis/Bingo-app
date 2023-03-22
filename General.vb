Public Class General
    Public NúmeroPremio As Integer = 0
    Public Respuesta As MsgBoxResult
    Public NúmeroCerrado As Integer = 0
    Public FormDiagrama As Form = New Form
    Public PanelBaseDiagrama As Panel = New Panel
    Public LabelNúmerosDiagrama(5, 5) As Label
    Public LabelBINGODiagrama(5) As Label
    Public FormMando As Form = New Form
    Public LabelTítuloControl As Label = New Label
    Public LabelAutorControl As Label = New Label
    Public TCBaseControl As TabControl = New TabControl
    Public FormPrincipal As Form = New Form
    Public PanelBasePrincipal As Panel = New Panel
    Public LabelNúmerosPrincipal(15, 5) As Label
    Public LabelBINGOPrincipal(5) As Label
    Public LabelPremiosPrincipal(20) As Label
    Public LabelNúmeroActual As Label = New Label
    Public LabelTítuloPrincipal As Label = New Label
    Public PanelNúmerosPrincipal As Panel = New Panel
    Public PanelPremiosPrincipal As Panel = New Panel
    Public ButtonBINGOControlDiagrama As Button = New Button
    Public ButtonBinguitoControlDiagrama As Button = New Button
    Public PanelBaseControlDiagrama As Panel = New Panel
    Public PanelSobreBaseControlDiagrama As Panel = New Panel
    Public MTBNúmeroControlDiagrama As MaskedTextBox = New MaskedTextBox
    Public LabelNúmeroControlDiagrama As Label = New Label
    Public ButtonAceptarControlDiagrama As Button = New Button
    Public ChBBinguitoControlDiagrama As CheckBox = New CheckBox
    Public ButtonDiagramaControlDiagrama As Button = New Button
    Public LabelNúmerosControlDiagrama(5, 5) As Label
    Public LabelBINGOControlDiagrama(5) As Label
    Public PanelDiagramaControlDiagrama As Panel = New Panel
    Public RBMarcarControlDiagrama As RadioButton = New RadioButton
    Public RBDesmarcarControlDiagrama As RadioButton = New RadioButton
    Public DGVPremiosControlPremios As DataGridView = New DataGridView
    Public ButtonCancelarControlPremios As Button = New Button
    Public ButtonModificarControlPremios As Button = New Button
    Public DGVChBCFinalizadoControlPremios As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
    Public DGVTBCPremioControlPremios As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
    Private Sub ButtonBinguitoControlDiagramaClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        Respuesta = MsgBox("¿Desea reiniciar el tablero?", MsgBoxStyle.YesNo, "¡Bingo!")
        If Respuesta = MsgBoxResult.Yes Then
            For y As Integer = 1 To 5
                For x As Integer = 1 To 15
                    LabelNúmerosPrincipal(x, y).BackColor = Color.RoyalBlue
                    LabelNúmerosPrincipal(x, y).ForeColor = Color.White
                Next
            Next
        End If
    End Sub
    Private Sub ButtonBINGOControlDiagramaClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        Respuesta = MsgBox("¿Desea reiniciar el tablero y marcar el premio actual como jugado?", MsgBoxStyle.YesNo, "¡Bingo!")
        If Respuesta = MsgBoxResult.Yes Then
            If NúmeroPremio <= 20 Then
                NúmeroPremio += 1
            End If
            For y As Integer = 1 To 5
                For x As Integer = 1 To 15
                    LabelNúmerosPrincipal(x, y).BackColor = Color.RoyalBlue
                    LabelNúmerosPrincipal(x, y).ForeColor = Color.White
                Next
                LabelPremiosPrincipal(NúmeroPremio).Font = New Font("Palatino", 12, FontStyle.Strikeout)
                LabelPremiosPrincipal(NúmeroPremio).ForeColor = Color.Gray
            Next
        End If
    End Sub

    Private Sub GeneralLoad() Handles MyBase.Load
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        FormularioMando()
        FormularioPrincipal()
        FormularioDiagramaBinguito()
        FormPrincipal.Show()
        MTBNúmeroControlDiagrama.Focus()
    End Sub
    Private Sub GeneralClose(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing
        Respuesta = MsgBox("Si cierra esta ventana también se cerrará el diagrama de BINGO.", MsgBoxStyle.OkCancel, "BINGO")
        If Respuesta = MsgBoxResult.Ok Then
            NúmeroCerrado = 1
            FormPrincipal.Close()
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub FormPrincipalClose(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If NúmeroCerrado = 1 Then
            e.Cancel = False
        Else
            MsgBox("Cierre la aplicación desde la ventana de control.", MsgBoxStyle.Critical, "BINGO")
            e.Cancel = True
        End If
    End Sub
    Private Sub LabelNúmerosPrincipalClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If DirectCast(sender, Label).BackColor = Color.RoyalBlue Then
            DirectCast(sender, Label).BackColor = Color.YellowGreen
            DirectCast(sender, Label).ForeColor = Color.DarkOliveGreen
            LabelNúmeroActual.Text = DirectCast(sender, Label).Text
        Else
            DirectCast(sender, Label).BackColor = Color.RoyalBlue
            DirectCast(sender, Label).ForeColor = Color.White
        End If
    End Sub
    Private Sub FormularioPrincipal()

        With FormPrincipal
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .Width = My.Computer.Screen.Bounds.Width
            .Height = My.Computer.Screen.Bounds.Height
            .BackColor = Color.DarkOrange
            .WindowState = FormWindowState.Maximized
            AddHandler (.FormClosing), AddressOf FormPrincipalClose
        End With
        With PanelBasePrincipal
            .BackgroundImage = My.Resources.Fondo
            .BackgroundImageLayout = ImageLayout.Stretch
            .Size = New Size(FormPrincipal.Width - 10, FormPrincipal.Height - 10)
            .Location = New Point(5, 5)
            .BackColor = Color.Snow
            .Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right
        End With
        FormPrincipal.Controls.Add(PanelBasePrincipal)
        With LabelTítuloPrincipal
            .Text = "BINGO!"
            .AutoSize = True
            .Location = New Point((PanelBasePrincipal.Width - .Width) / 2, 20)
            .Font = New Font("Oxford", 30, FontStyle.Bold)
            .ForeColor = Color.White
            .BackColor = Color.Transparent
            .Visible = True
        End With
        PanelBasePrincipal.Controls.Add(LabelTítuloPrincipal)
        With PanelNúmerosPrincipal
            .Size = New Size(PanelBasePrincipal.Width - 20, PanelBasePrincipal.Height - LabelTítuloPrincipal.Height - 240)
            .Location = New Point(10, 30 + LabelTítuloPrincipal.Height)
            .BackColor = Color.Snow
            .Anchor = AnchorStyles.Top And AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right
            .BorderStyle = BorderStyle.None
            .BackColor = Color.WhiteSmoke
        End With
        PanelBasePrincipal.Controls.Add(PanelNúmerosPrincipal)
        With PanelPremiosPrincipal
            .Size = New Size(PanelBasePrincipal.Width - 20, 190)
            .Location = New Point(10, 40 + LabelTítuloPrincipal.Height + PanelNúmerosPrincipal.Height)
            .BackColor = Color.FromArgb(90, Color.Black)
            .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Right
        End With
        PanelBasePrincipal.Controls.Add(PanelPremiosPrincipal)
        Dim SeparaciónX As Integer = PanelNúmerosPrincipal.Width / 16
        Dim SeparaciónY As Integer = PanelNúmerosPrincipal.Height / 5
        For y As Integer = 1 To 5
            For x As Integer = 1 To 15
                LabelNúmerosPrincipal(x, y) = New Label
                With LabelNúmerosPrincipal(x, y)
                    If 15 * (y - 1) + x < 10 Then
                        .Text = 0 & 15 * (y - 1) + x
                    Else
                        .Text = 15 * (y - 1) + x
                    End If
                    .Size = New Size(SeparaciónX - 1, SeparaciónY - 1)
                    .Location = New Point(SeparaciónX * x, SeparaciónY * (y - 1))
                    .AutoSize = False
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Font = New Font("Oxford", 30, FontStyle.Bold)
                    .ForeColor = Color.White
                    .BackColor = Color.RoyalBlue
                    .Visible = True
                    .Cursor = Cursors.Hand
                    AddHandler (.Click), AddressOf LabelNúmerosPrincipalClick
                End With
                PanelNúmerosPrincipal.Controls.Add(LabelNúmerosPrincipal(x, y))
                LabelNúmerosPrincipal(x, y).Show()
            Next
            LabelBINGOPrincipal(y) = New Label
            With LabelBINGOPrincipal(y)
                .Size = New Size(SeparaciónX - 1, SeparaciónY - 1)
                .Location = New Point(0, SeparaciónY * (y - 1))
                .AutoSize = False
                .TextAlign = ContentAlignment.MiddleCenter
                .Font = New Font("Oxford", 30, FontStyle.Bold)
                .ForeColor = Color.White
                .BackColor = Color.Red
                .Visible = True
            End With
            PanelNúmerosPrincipal.Controls.Add(LabelBINGOPrincipal(y))
        Next
        LabelBINGOPrincipal(1).Text = "B"
        LabelBINGOPrincipal(2).Text = "I"
        LabelBINGOPrincipal(3).Text = "N"
        LabelBINGOPrincipal(4).Text = "G"
        LabelBINGOPrincipal(5).Text = "O"
        For x As Integer = 1 To 4
            For y As Integer = 1 To 5
                LabelPremiosPrincipal(5 * (x - 1) + y) = New Label
                With LabelPremiosPrincipal(5 * (x - 1) + y)
                    .MaximumSize = New Size((PanelPremiosPrincipal.Width - 350) / 4, 20)
                    .Text = "Premio N°" & (x - 1) * 5 + y
                    .AutoSize = True
                    .Location = New Point(10 + (x - 1) * (PanelPremiosPrincipal.Width - 300) / 4, 10 + (y - 1) * PanelPremiosPrincipal.Height / 5)
                    .Font = New Font("Palatino", 14, FontStyle.Bold)
                    .ForeColor = Color.White
                    .BackColor = Color.Transparent
                    .Visible = True
                End With
                PanelPremiosPrincipal.Controls.Add(LabelPremiosPrincipal(5 * (x - 1) + y))
            Next
        Next
        With LabelNúmeroActual
            .Text = "00"
            .AutoSize = True
            .Font = New Font("Oxford", 120, FontStyle.Bold)
            .ForeColor = Color.Yellow
            .BackColor = Color.Transparent
            Visible = True
        End With
        PanelPremiosPrincipal.Controls.Add(LabelNúmeroActual)
        LabelNúmeroActual.Location = New Point(PanelPremiosPrincipal.Width - LabelNúmeroActual.Width - 15, 10 + (PanelPremiosPrincipal.Height - LabelNúmeroActual.Height) / 2)
    End Sub
    Private Sub FormularioMando()
        With Me
            .ClientSize = New Size(600, 400)
            .MinimumSize = .Size
            .MaximumSize = .Size
            .Text = "Control de BINGO"
            .BackColor = Color.GreenYellow
            .MaximizeBox = False
            Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 300, My.Computer.Screen.Bounds.Height / 2 - 200)
        End With
        With LabelTítuloControl
            .AutoSize = True
            .Location = New System.Drawing.Point(350, 10)
            .Text = "Control de BINGO"
            .Font = New Font("Palatino", 18, FontStyle.Bold)
            .ForeColor = Color.DarkOliveGreen
        End With
        Me.Controls.Add(LabelTítuloControl)
        With LabelAutorControl
            .AutoSize = False
            .Size = New Size(180, 20)
            .Location = New Point(210, 380)
            .Text = "Fernando Fêtis Riquelme 2015"
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .ForeColor = Color.OliveDrab
        End With
        Me.Controls.Add(LabelAutorControl)
        With TCBaseControl
            .Location = New Point(10, 20)
            .Size = New Size(580, 360)
            .TabPages.Add("Diagrama de Juego")
            .TabPages.Add("Lista de Premios")
            For i As Integer = 0 To 1
                .TabPages(i).BackColor = Color.Snow
            Next
        End With
        Me.Controls.Add(TCBaseControl)
        FormularioMandoDiagramaJuego()
        FormularioMandoListaPremios()
    End Sub
    Private Sub FormularioDiagramaBinguito()
        With FormDiagrama
            .AutoSize = False
            .Size = New Size(524, 525)
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .BackColor = Color.YellowGreen
            .StartPosition = FormStartPosition.CenterScreen
            ShowInTaskbar = False
            .Text = "Diagrama de Juego"
        End With
        With PanelBaseDiagrama
            .AutoSize = False
            .Size = New Size(504, 505)
            .Location = New Point(10, 10)
            .BackColor = Color.YellowGreen
        End With
        FormDiagrama.Controls.Add(PanelBaseDiagrama)
        For y As Integer = 1 To 5
            For x As Integer = 1 To 5
                LabelNúmerosDiagrama(x, y) = New Label
                With LabelNúmerosDiagrama(x, y)
                    .AutoSize = False
                    .Size = New Size(100, 83)
                    .Location = New Point(101 * (x - 1), 84 * y)
                    .Text = "X"
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Font = New Font("Oxford", 40, FontStyle.Bold)
                    .BackColor = Color.Snow
                    .ForeColor = Color.Snow
                End With
                PanelBaseDiagrama.Controls.Add(LabelNúmerosDiagrama(x, y))
            Next
            LabelBINGODiagrama(y) = New Label
            With LabelBINGODiagrama(y)
                .AutoSize = False
                .Size = New Size(100, 80)
                .Location = New Point(101 * (y - 1), 0)
                .TextAlign = ContentAlignment.MiddleCenter
                .Font = New Font("Oxford", 30, FontStyle.Bold)
                .BackColor = Color.OrangeRed
                .ForeColor = Color.White
            End With
            PanelBaseDiagrama.Controls.Add(LabelBINGODiagrama(y))
        Next
        LabelBINGODiagrama(1).Text = "B"
        LabelBINGODiagrama(2).Text = "I"
        LabelBINGODiagrama(3).Text = "N"
        LabelBINGODiagrama(4).Text = "G"
        LabelBINGODiagrama(5).Text = "O"
    End Sub
    Private Sub FormularioMandoDiagramaJuego()
        With PanelBaseControlDiagrama
            .AutoSize = False
            .Size = New Size(265, 305)
            .Location = New Point(15, 15)
            .BackColor = Color.DarkGray
        End With
        TCBaseControl.TabPages(0).Controls.Add(PanelBaseControlDiagrama)
        With PanelSobreBaseControlDiagrama
            .AutoSize = False
            .Size = New Size(255, 295)
            .Location = New Point(5, 5)
            .BackColor = Color.WhiteSmoke
        End With
        PanelBaseControlDiagrama.Controls.Add(PanelSobreBaseControlDiagrama)
        With LabelNúmeroControlDiagrama
            .AutoSize = False
            .Size = New Size(110, 30)
            .Location = New Point(72.5, 20)
            .Text = "Número:"
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Palatino", 18, FontStyle.Bold Or FontStyle.Underline)
            .ForeColor = Color.DimGray
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(LabelNúmeroControlDiagrama)
        With MTBNúmeroControlDiagrama
            .Size = New Size(70, 50)
            .Location = New Point(92.5, 60)
            .Mask = "00"
            .TextAlign = HorizontalAlignment.Center
            .Font = New Font("Microsoft Sans Serif", 26)
            .ForeColor = Color.OrangeRed
            AddHandler (MTBNúmeroControlDiagrama.TextChanged), AddressOf MTBNúmeroControlDiagramaTextChanged
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(MTBNúmeroControlDiagrama)
        With RBMarcarControlDiagrama
            .AutoSize = False
            .Size = New Size(100, 20)
            .Location = New Point(25, 115)
            .RightToLeft = RightToLeft.Yes
            .Text = "Marcar"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .ForeColor = Color.DimGray
            .Checked = True
            AddHandler .CheckedChanged, AddressOf RBMarcarDesmarcarControlDiagramaCheckedChanged
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(RBMarcarControlDiagrama)
        With RBDesmarcarControlDiagrama
            .AutoSize = False
            .Size = New Size(100, 20)
            .Location = New Point(130, 115)
            .RightToLeft = RightToLeft.No
            .Text = "Desmarcar"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .ForeColor = Color.DimGray
            .Checked = False
            AddHandler .CheckedChanged, AddressOf RBMarcarDesmarcarControlDiagramaCheckedChanged
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(RBDesmarcarControlDiagrama)
        With ChBBinguitoControlDiagrama
            .AutoSize = False
            .Size = New Size(110, 20)
            .Location = New Point(72.5 + 5, 140)
            .RightToLeft = RightToLeft.No
            .Text = "Modo binguito"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .ForeColor = Color.DimGray
            .Checked = False
            AddHandler .CheckedChanged, AddressOf ChBBinguitoControlDiagramaCheckedChanged
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(ChBBinguitoControlDiagrama)
        With ButtonAceptarControlDiagrama
            .AutoSize = False
            .Size = New Size(100, 35)
            .Location = New Point(77.5, 160)
            .FlatStyle = FlatStyle.Flat
            .Text = "Aceptar"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .BackColor = Color.DarkOrange
            .ForeColor = Color.White
            AddHandler .Click, AddressOf ButtonAceptarControlDiagramaClick
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(ButtonAceptarControlDiagrama)
        With ButtonBinguitoControlDiagrama
            .AutoSize = False
            .Size = New Size(100, 35)
            .Location = New Point(25, 200)
            .FlatStyle = FlatStyle.Flat
            .Text = "Binguito"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .BackColor = Color.YellowGreen
            .ForeColor = Color.White
            .Enabled = False
            AddHandler .Click, AddressOf ButtonBinguitoControlDiagramaClick
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(ButtonBinguitoControlDiagrama)
        With ButtonBINGOControlDiagrama
            .AutoSize = False
            .Size = New Size(100, 35)
            .Location = New Point(130, 200)
            .FlatStyle = FlatStyle.Flat
            .Text = "BINGO!"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .BackColor = Color.DodgerBlue
            .ForeColor = Color.White
            AddHandler .Click, AddressOf ButtonBINGOControlDiagramaClick
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(ButtonBINGOControlDiagrama)
        With ButtonDiagramaControlDiagrama
            .AutoSize = False
            .Size = New Size(205, 35)
            .Location = New Point(25, 240)
            .FlatStyle = FlatStyle.Flat
            .Text = "Mostrar Diagrama de Binguito"
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .BackColor = Color.YellowGreen
            .ForeColor = Color.White
            .Enabled = False
            AddHandler .Click, AddressOf ButtonDiagramaControlDiagramaClick
        End With
        PanelSobreBaseControlDiagrama.Controls.Add(ButtonDiagramaControlDiagrama)
        With PanelDiagramaControlDiagrama
            .AutoSize = False
            .Size = New Size(254, 305)
            .Location = New Point(300, 15)
            .BackColor = Color.Snow
            .Enabled = False
        End With
        TCBaseControl.TabPages(0).Controls.Add(PanelDiagramaControlDiagrama)
        For y As Integer = 1 To 5
            For x As Integer = 1 To 5
                LabelNúmerosControlDiagrama(x, y) = New Label
                With LabelNúmerosControlDiagrama(x, y)
                    .AutoSize = False
                    .Size = New Size(50, 50)
                    .Location = New Point(51 * (x - 1), 51 * y)
                    .Text = "X"
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Font = New Font("Palatino", 12, FontStyle.Bold)
                    .BackColor = Color.LightSteelBlue
                    .ForeColor = Color.DarkSlateGray
                    .Cursor = Cursors.Hand
                    AddHandler .Click, AddressOf LabelNúmerosControlDiagramaClick
                End With
                PanelDiagramaControlDiagrama.Controls.Add(LabelNúmerosControlDiagrama(x, y))
                LabelNúmerosControlDiagrama(x, y).Show()
            Next
            LabelBINGOControlDiagrama(y) = New Label
            With LabelBINGOControlDiagrama(y)
                .AutoSize = False
                .Size = New Size(50, 50)
                .Location = New Point(51 * (y - 1), 0)
                .TextAlign = ContentAlignment.MiddleCenter
                .Font = New Font("Palatino", 12, FontStyle.Bold)
                .BackColor = Color.DarkOrange
                .ForeColor = Color.Firebrick
            End With
            PanelDiagramaControlDiagrama.Controls.Add(LabelBINGOControlDiagrama(y))
        Next
        LabelBINGOControlDiagrama(1).Text = "B"
        LabelBINGOControlDiagrama(2).Text = "I"
        LabelBINGOControlDiagrama(3).Text = "N"
        LabelBINGOControlDiagrama(4).Text = "G"
        LabelBINGOControlDiagrama(5).Text = "O"
    End Sub
    Private Sub FormularioMandoListaPremios()
        With ButtonCancelarControlPremios
            .BackColor = Color.DodgerBlue
            .FlatStyle = FlatStyle.Flat
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .ForeColor = Color.White
            .Location = New Point(460, 295)
            .Size = New Size(100, 35)
            .ForeColor = Color.White
            .Text = "Cancelar"
            AddHandler .Click, AddressOf ButtonCancelarControlListaPremiosClick
        End With
        TCBaseControl.TabPages(1).Controls.Add(ButtonCancelarControlPremios)
        With ButtonModificarControlPremios
            .BackColor = Color.DarkOrange
            .FlatStyle = FlatStyle.Flat
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            .ForeColor = Color.White
            .Location = New Point(355, 295)
            .Name = "ButtonModificarControlPremios"
            .Size = New Size(100, 35)
            .Text = "Modificar"
            AddHandler .Click, AddressOf ButtonModificarControlListaPremiosClick
        End With
        TCBaseControl.TabPages(1).Controls.Add(ButtonModificarControlPremios)
        With DGVPremiosControlPremios
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .BackgroundColor = Color.Honeydew
            .BorderStyle = BorderStyle.Fixed3D
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .EditMode = DataGridViewEditMode.EditOnEnter
            .MultiSelect = False
            .Name = "DGVPremiosControlPremios"
            .ScrollBars = ScrollBars.Vertical
            .Size = New Size(545, 270)
            .Location = New Point(15, 15)
        End With
        TCBaseControl.TabPages(1).Controls.Add(DGVPremiosControlPremios)
        DGVPremiosControlPremios.Columns.Add(DGVChBCFinalizadoControlPremios)
        DGVPremiosControlPremios.Columns.Add(DGVTBCPremioControlPremios)
        DGVChBCFinalizadoControlPremios.HeaderText = "Juego Finalizado"
        DGVPremiosControlPremios.Rows.Add(20)
        DGVTBCPremioControlPremios.HeaderText = "Nombre del Premio"
        DGVChBCFinalizadoControlPremios.Width = 100
    End Sub
    Private Sub ChBBinguitoControlDiagramaCheckedChanged(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        If ChBBinguitoControlDiagrama.Checked = False Then
            For x As Integer = 1 To 5
                For y As Integer = 1 To 5
                    LabelNúmerosControlDiagrama(x, y).Text = "X"
                    LabelNúmerosControlDiagrama(x, y).BackColor = Color.LightSteelBlue
                    LabelNúmerosControlDiagrama(x, y).ForeColor = Color.DarkSlateGray
                Next
            Next
            ButtonBinguitoControlDiagrama.Enabled = False
            ButtonDiagramaControlDiagrama.Enabled = False
            PanelDiagramaControlDiagrama.Enabled = False
            ButtonDiagramaControlDiagrama.Text = "Mostrar diagrama de Binguito"
            FormDiagrama.Hide()
        Else
            ButtonBinguitoControlDiagrama.Enabled = True
            ButtonDiagramaControlDiagrama.Enabled = True
            PanelDiagramaControlDiagrama.Enabled = True
        End If
    End Sub
    Private Sub LabelNúmerosControlDiagramaClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        If DirectCast(ControlAsociado, Label).Text = "X" Then
            DirectCast(ControlAsociado, Label).Text = "O"
            DirectCast(ControlAsociado, Label).BackColor = Color.YellowGreen
            DirectCast(ControlAsociado, Label).ForeColor = Color.DarkOliveGreen
        Else
            DirectCast(ControlAsociado, Label).Text = "X"
            DirectCast(ControlAsociado, Label).BackColor = Color.LightSteelBlue
            DirectCast(ControlAsociado, Label).ForeColor = Color.DarkSlateGray
        End If
        For x As Integer = 1 To 5
            For y As Integer = 1 To 5
                If LabelNúmerosControlDiagrama(x, y).Text = "O" Then
                    LabelNúmerosDiagrama(x, y).BackColor = Color.DarkSlateGray
                    LabelNúmerosDiagrama(x, y).ForeColor = Color.White
                Else
                    LabelNúmerosDiagrama(x, y).BackColor = Color.Snow
                    LabelNúmerosDiagrama(x, y).ForeColor = Color.Snow
                End If
            Next
        Next
    End Sub
    Private Sub RBMarcarDesmarcarControlDiagramaCheckedChanged(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        If RBMarcarControlDiagrama.Checked = True Then
            RBDesmarcarControlDiagrama.Checked = False
        ElseIf RBMarcarControlDiagrama.Checked = False Then
            RBDesmarcarControlDiagrama.Checked = True
        End If
        MTBNúmeroControlDiagrama.Focus()
    End Sub
    Private Sub MTBNúmeroControlDiagramaTextChanged(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        If MTBNúmeroControlDiagrama.MaskFull = True Then
            ButtonAceptarControlDiagrama.Focus()
        End If
    End Sub
    Private Sub ButtonAceptarControlDiagramaClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        If 0 < Val(MTBNúmeroControlDiagrama.Text) And Val(MTBNúmeroControlDiagrama.Text) < 76 Then
            If RBMarcarControlDiagrama.Checked = True Then
                Dim NúmeroY As Integer = Math.Ceiling(MTBNúmeroControlDiagrama.Text / 15)
                Dim NúmeroX As Integer = MTBNúmeroControlDiagrama.Text - Math.Floor((MTBNúmeroControlDiagrama.Text - 1) / 15) * 15
                LabelNúmerosPrincipal(NúmeroX, NúmeroY).BackColor = Color.YellowGreen
                LabelNúmerosPrincipal(NúmeroX, NúmeroY).ForeColor = Color.DarkOliveGreen
                LabelNúmeroActual.Text = MTBNúmeroControlDiagrama.Text
            Else
                Dim NúmeroY As Integer = Math.Ceiling(MTBNúmeroControlDiagrama.Text / 15)
                Dim NúmeroX As Integer = MTBNúmeroControlDiagrama.Text - Math.Floor((MTBNúmeroControlDiagrama.Text - 1) / 15) * 15
                LabelNúmerosPrincipal(NúmeroX, NúmeroY).BackColor = Color.RoyalBlue
                LabelNúmerosPrincipal(NúmeroX, NúmeroY).ForeColor = Color.White
            End If
        Else
            MsgBox("El Número " & Val(MTBNúmeroControlDiagrama.Text) & " está fuera del intervalo permitido.", MsgBoxStyle.Exclamation, "BINGO")
        End If
        MTBNúmeroControlDiagrama.Text = ""
        MTBNúmeroControlDiagrama.Focus()
    End Sub
    Private Sub ButtonDiagramaControlDiagramaClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        If FormDiagrama.Visible = True Then
            FormDiagrama.Hide()
            ButtonDiagramaControlDiagrama.Text = "Mostrar diagrama de Binguito"
        Else
            FormDiagrama.Show()
            ButtonDiagramaControlDiagrama.Text = "Ocultar diagrama de Binguito"
        End If
    End Sub
    Private Sub ButtonModificarControlListaPremiosClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        For i = 1 To 20
            With LabelPremiosPrincipal(i)
                .Text = DGVPremiosControlPremios.Item(1, i - 1).Value
                If DGVPremiosControlPremios.Item(0, i - 1).Value = vbTrue Then
                    .Font = New Font("Palatino", 12, FontStyle.Strikeout)
                    .ForeColor = Color.Gray
                Else
                    .Font = New Font("Palatino", 12, FontStyle.Bold)
                    .ForeColor = Color.White
                End If
            End With
        Next
    End Sub
    Private Sub ButtonCancelarControlListaPremiosClick(ByVal ControlAsociado As Object, ByVal EventoControl As System.EventArgs)
        For i = 1 To 20
            With DGVPremiosControlPremios.Item(1, i - 1)
                .Value = LabelPremiosPrincipal(i).Text
                If LabelPremiosPrincipal(i).Font.Strikeout = True Then
                    DGVPremiosControlPremios.Item(0, i - 1).Value = True
                Else
                    DGVPremiosControlPremios.Item(0, i - 1).Value = False
                End If
            End With
        Next
    End Sub
End Class