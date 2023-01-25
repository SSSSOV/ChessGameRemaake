Public Class SettingsForm
    Public settings As Settings '' Settings Object.

    ''' <summary>
    ''' Set components value from settings object.
    ''' </summary>
    ''' <param name="settings">Settings object</param>
    Private Sub SetComponentsValue(settings As Settings)
        comboBox_theme.SelectedIndex = settings.theme
        button_blackColor.BackColor = settings.colorBlack
        button_whiteColor.BackColor = settings.colorWhite
        button_moveColor.BackColor = settings.colorMove
        button_cutColor.BackColor = settings.colorCut
        checkBox_paintAllPosible.Checked = settings.PaintAllPossible
    End Sub

    Public Sub New(settings As Settings)
        InitializeComponent()
        Me.settings = settings
        SetComponentsValue(settings)
    End Sub

    ''' <summary>
    ''' Button click event handler. Shows a form for choosing a color.
    ''' </summary>
    Private Sub Button_Color_Click(sender As Object, e As EventArgs) Handles button_whiteColor.Click, button_moveColor.Click, button_cutColor.Click, button_blackColor.Click
        Dim buttonColor As Button = DirectCast(sender, Button)
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            buttonColor.BackColor = ColorDialog1.Color
            comboBox_theme.SelectedIndex = 3
        End If
    End Sub

    ''' <summary>
    ''' Button click event handler. Save settings to the file.
    ''' </summary>
    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles Button2.Click
        settings.colorBlack = button_blackColor.BackColor
        settings.colorWhite = button_whiteColor.BackColor
        settings.colorMove = button_moveColor.BackColor
        settings.colorCut = button_cutColor.BackColor
        settings.WriteToCfg()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Color theme change handler.
    ''' </summary>
    Private Sub comboBox_theme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox_theme.SelectedIndexChanged
        Select Case comboBox_theme.SelectedIndex
            Case 0
                settings.theme = 0
                button_blackColor.BackColor = Color.FromArgb(184, 139, 98)
                button_whiteColor.BackColor = Color.FromArgb(242, 216, 179)
                button_moveColor.BackColor = Color.FromArgb(95, 192, 224)
                button_cutColor.BackColor = Color.FromArgb(255, 102, 102)

            Case 1
                settings.theme = 1
                button_blackColor.BackColor = Color.FromArgb(16, 22, 44)
                button_whiteColor.BackColor = Color.FromArgb(55, 65, 98)
                button_moveColor.BackColor = Color.FromArgb(51, 89, 102)
                button_cutColor.BackColor = Color.FromArgb(0, 51, 102)

            Case 2
                settings.theme = 2
                button_blackColor.BackColor = Color.FromArgb(116, 150, 84)
                button_whiteColor.BackColor = Color.FromArgb(236, 238, 212)
                button_moveColor.BackColor = Color.FromArgb(248, 240, 103)
                button_cutColor.BackColor = Color.FromArgb(183, 191, 36)

            Case Else
                settings.theme = 3
        End Select

    End Sub

    ''' <summary>
    ''' Check box render handler for all possible actions.
    ''' </summary>
    Private Sub checkBox_paintAllPosible_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox_paintAllPosible.CheckedChanged
        settings.PaintAllPossible = checkBox_paintAllPosible.Checked
    End Sub

    ''' <summary>
    ''' Cancel button click handler. Resets all changes.
    ''' </summary>
    Private Sub button_cancel_Click(sender As Object, e As EventArgs) Handles button_cancel.Click
        settings.ReadFromCfg()
        Me.Close()
    End Sub
End Class