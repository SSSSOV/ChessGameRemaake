Public Class Main
    Private settings As Settings = New Settings() '' Field With settings Object.
    Private cb As ChessBoard = New ChessBoard() '' Field With chess.

    Private game_field As Button()() = New Button(7)() {} '' 2d array with buttons.
    Private random As Random = New Random() '' Pseudo-random number generator.
    Private soundPlayer As System.Media.SoundPlayer '' Controls the playback Of a WAV audio file.
    Private map As Integer()() = New Integer(7)() {} '' Map with 
    Private player As Integer = 0 '' Id Of curent move player.
    Private isComputer As Boolean = False '' Game With computer.
    Private selectedPoint As Point = New Point(-1, -1) '' Selected point.
    Private point_of_field As Point = New Point(6, 20) '' The point from which the playing field Is drawn.

    ' Loops for a specificied period of time (milliseconds)
    'Private Sub wait(ByVal interval As Integer)
    '    Dim sw As New Stopwatch
    '    sw.Start()
    '    Do While sw.ElapsedMilliseconds < interval
    '        ' Allows UI to remain responsive
    '        Application.DoEvents()
    '    Loop
    '    sw.Stop()
    'End Sub

    ''' <summary>
    ''' Reset color for button.
    ''' </summary>
    ''' <param name="p">Button coordinates.</param>
    Private Sub ResetButtonColor(p As Point)
        game_field(p.X)(p.Y).BackColor = If((p.X + p.Y) Mod 2 = 0, settings.colorWhite, settings.colorBlack)
    End Sub

    ''' <summary>
    ''' Reset colors for buttons.
    ''' </summary>
    ''' <param name="map">Map of buttons.</param>
    Private Sub ResetButtonsColor(map As Integer()())
        For x = 0 To 7
            For y = 0 To 7
                If (map(x)(y) <> 0) Then ResetButtonColor(New Point(x, y))
            Next
        Next
    End Sub

    ''' <summary>
    ''' Reset color for all buttons.
    ''' </summary>
    Private Sub ResetAllButtonsColor()
        For x = 0 To 7
            For y = 0 To 7
                ResetButtonColor(New Point(x, y))
            Next
        Next
    End Sub

    ''' <summary>
    ''' Draw a figure on the board.
    ''' </summary>
    ''' <param name="p">Figure coordinates.</param>
    Public Sub DrowFigure(p As Point)
        Dim figure As Figure = cb.getFigure(p)
        If (figure.name <> "none") Then
            game_field(p.X)(p.Y).BackgroundImage = figure.image
        Else game_field(p.X)(p.Y).BackgroundImage = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Draw all figures on the board.
    ''' </summary>
    Public Sub DrowAllFigures()
        For x = 0 To 7
            For y = 0 To 7
                DrowFigure(New Point(x, y))
            Next
        Next
    End Sub

    Public Sub New()
        InitializeComponent()

        For i = 0 To 7
            game_field(i) = New Button(7) {}
            map(i) = New Integer(7) {}
        Next

        For x = 0 To 7
            For y = 0 To 7
                Dim button As Button = New Button()
                button.Name = "button_" + x.ToString() + y.ToString()
                button.Size = New Size(50, 50)
                button.Location = New Point(x * 50 + point_of_field.X, y * 50 + point_of_field.Y)
                button.BackColor = If((x + y) Mod 2 = 0, settings.colorWhite, settings.colorBlack)
                AddHandler button.Click, AddressOf Me.OnButtonPress
                button.BackgroundImageLayout = ImageLayout.Stretch
                button.FlatStyle = FlatStyle.Flat
                button.FlatAppearance.BorderSize = 0
                game_field(x)(y) = button
                groupBox_ChessBoard.Controls.Add(button)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Chess board buttons click handler
    ''' </summary>
    Public Sub OnButtonPress(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)

        If (button.BackColor <> settings.colorMove And button.BackColor <> settings.colorCut) Then
            ResetButtonsColor(map)
            selectedPoint.X = -1
        End If
        If (selectedPoint.X = -1) Then
            selectedPoint = New Point(Integer.Parse(button.Name(7).ToString()), Integer.Parse(button.Name(8).ToString()))
            If (cb.getFigure(selectedPoint).idPlayer <> player) Then Return
            map = cb.getPossibleActions(selectedPoint)
            Dim isNotMoveble As Boolean = True
            For x = 0 To 7
                For y = 0 To 7
                    If (map(x)(y) = 1) Then game_field(x)(y).BackColor = settings.colorMove
                    If (map(x)(y) = 2) Then game_field(x)(y).BackColor = settings.colorCut
                    If (settings.PaintAllPossible) Then
                        If (map(x)(y) = 3) Then game_field(x)(y).BackColor = Color.Orange
                        If (map(x)(y) = 4) Then game_field(x)(y).BackColor = Color.OrangeRed
                    End If
                    isNotMoveble = False
                Next
            Next
            If (isNotMoveble) Then selectedPoint.X = -1

        Else
            If (button.BackColor = settings.colorMove) Then
                soundPlayer = New System.Media.SoundPlayer("res/sound_move.wav")
                soundPlayer.Play()
                Dim newPoint As Point = New Point(Integer.Parse(button.Name(7).ToString()), Integer.Parse(button.Name(8).ToString()))
                cb.MoveFigure(selectedPoint, newPoint)
                ResetButtonsColor(map)
                DrowFigure(selectedPoint)
                DrowFigure(newPoint)
                selectedPoint.X = -1
                player = player Mod 2 + 1
                label_whichPlayer.Text = player.ToString() + " player move."

            ElseIf (button.BackColor = settings.colorCut) Then
                soundPlayer = New System.Media.SoundPlayer("res/sound_cut.wav")
                soundPlayer.Play()
                Dim newPoint As Point = New Point(Integer.Parse(button.Name(7).ToString()), Integer.Parse(button.Name(8).ToString()))
                cb.CutFigure(selectedPoint, newPoint)
                ResetButtonsColor(map)
                DrowFigure(selectedPoint)
                DrowFigure(newPoint)
                selectedPoint.X = -1
                player = player Mod 2 + 1
                label_whichPlayer.Text = player.ToString() + " player move."
            End If

            label_gameOver.Text = cb.GameOver()
            If (label_gameOver.Text = "Checkmate for 2 player" Or label_gameOver.Text = "Checkmate for 1 player") Then groupBox_ChessBoard.Enabled = False

            If (isComputer And groupBox_ChessBoard.Enabled = True) Then
                'wait(random.Next(1000, 3000))
                RandomMoveForFirstPlayer(sender, e)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Create a New game And unlock the board.
    ''' </summary>
    Private Sub NewGame()
        NewGame("Default")
    End Sub

    ''' <summary>
    ''' Create a New game And unlock the board.
    ''' </summary>
    ''' <param name="path">Path to the file with level.</param>
    Private Sub NewGame(path As String)
        groupBox_ChessBoard.Enabled = True
        ResetAllButtonsColor()
        cb.ArrangeFigures(path)
        DrowAllFigures()
        selectedPoint.X = -1

        label_gameOver.Text = cb.GameOver()
    End Sub

    ''' <summary>
    ''' Open the settings form for changing settings.
    ''' </summary>
    Private Sub SeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim sf As SettingsForm = New SettingsForm(settings)
        sf.Owner = Me
        sf.ShowDialog()
        settings.ReadFromCfg()
        ResetAllButtonsColor()
    End Sub

    ''' <summary>
    ''' Do computer move for first player when player vs. computer.
    ''' </summary>
    Private Sub RandomMoveForFirstPlayer(sender As Object, e As EventArgs)
        Dim num_of_figure As Integer = random.Next(0, cb.figuresPlayer1.Length)
        Dim amount_possible_actions As Integer = 0
        Dim possible_actions_map As Integer()()
        Dim possible_actions As Point() = New Point(20) {}
        Dim count As Integer = 0

        possible_actions_map = cb.getPossibleActions(cb.figuresPlayer1(num_of_figure).position)
        While (ChessBoard.IsEmptyMap(possible_actions_map))
            num_of_figure = random.Next(0, cb.figuresPlayer1.Length)
            possible_actions_map = cb.getPossibleActions(cb.figuresPlayer1(num_of_figure).position)
            count += 1
            If (count > 5) Then
                label_gameOver.Text = "Checkmate for 1 player"
                groupBox_ChessBoard.Enabled = False
                MessageBox.Show("Checkmate for 1 player.", "GameOver!")
                Return
            End If
        End While

        selectedPoint = cb.figuresPlayer1(num_of_figure).position

        For x = 0 To 7
            For y = 0 To 7
                If (possible_actions_map(x)(y) = 1 Or possible_actions_map(x)(y) = 2) Then
                    possible_actions(amount_possible_actions) = New Point(x, y)
                    amount_possible_actions += 1
                    If (amount_possible_actions = 19) Then Exit For
                End If
            Next
            If (amount_possible_actions = 19) Then Exit For
        Next

        Dim num_of_action As Integer = random.Next(0, amount_possible_actions)

        Dim randomPoint As Point = possible_actions(num_of_action)
        If (cb.getFigure(randomPoint).name <> "none") Then
            soundPlayer = New System.Media.SoundPlayer("res/sound_cut.wav")
            soundPlayer.Play()
            cb.CutFigure(selectedPoint, randomPoint)
            ResetButtonsColor(map)
            DrowFigure(selectedPoint)
            DrowFigure(randomPoint)
            selectedPoint.X = -1
            player = player Mod 2 + 1
            label_whichPlayer.Text = player.ToString() + " player move."

        Else
            soundPlayer = New System.Media.SoundPlayer("res/sound_move.wav")
            soundPlayer.Play()
            cb.MoveFigure(selectedPoint, randomPoint)
            ResetButtonsColor(map)
            DrowFigure(selectedPoint)
            DrowFigure(randomPoint)
            selectedPoint.X = -1
            player = player Mod 2 + 1
            label_whichPlayer.Text = player.ToString() + " player move."
        End If
        label_gameOver.Text = cb.GameOver()
        If (label_gameOver.Text = "Checkmate for 2 player" Or label_gameOver.Text = "Checkmate for 1 player") Then groupBox_ChessBoard.Enabled = False
    End Sub

    ''' <summary>
    ''' Start game player vs. player.
    ''' </summary>
    Private Sub playerVsPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayerVsPlayerToolStripMenuItem.Click
        NewGame()
        isComputer = False
        player = random.Next(1, 3)
        label_whichPlayer.Text = player.ToString() + " player move."
    End Sub

    ''' <summary>
    ''' Start game player vs. computer.
    ''' </summary>
    Private Sub playerVsComputerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayerVsComputerToolStripMenuItem.Click
        NewGame()
        isComputer = True
        player = 2
        label_whichPlayer.Text = player.ToString() + " player move."
    End Sub

    ''' <summary>
    ''' Load level player vs. computer from file.
    ''' </summary>
    Private Sub loadLevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadLevelToolStripMenuItem.Click
        OpenFileDialog1 = New OpenFileDialog()
        OpenFileDialog1.Filter = "txt files (*.txt)|*.txt"

        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then NewGame(OpenFileDialog1.FileName)
        isComputer = True
        player = 2
        label_whichPlayer.Text = player.ToString() + " player move."
    End Sub
End Class