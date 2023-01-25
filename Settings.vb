Public Class Settings

    Public colorBlack As Color '' Color Of black fields On the board.
    Public colorWhite As Color '' Color Of white fields On the board.
    Public colorMove As Color '' Color Of fields On the board where the figure can moves.
    Public colorCut As Color '' Color Of fields On the board where the figure can cuts.
    Public theme As Integer '' Board color theme.
    Public PaintAllPossible As Boolean '' Is it necessary To draw all possible actions.

    Private defaultPath As String = "res/cfg.txt" '' Path To the file With settings value.

    ''' <summary>
    ''' Constructor of setting. If the file with the value Is Not found, then the default values are set.
    ''' </summary>
    Public Sub New()
        theme = 2
        colorBlack = System.Drawing.Color.FromArgb(116, 150, 84)
        colorWhite = System.Drawing.Color.FromArgb(236, 238, 212)
        colorMove = System.Drawing.Color.FromArgb(248, 240, 103)
        colorCut = System.Drawing.Color.FromArgb(183, 191, 36)
        PaintAllPossible = False
        ReadFromCfg()
    End Sub

    ''' <summary>
    ''' Convert color to string.
    ''' </summary>
    Public Function ColorToString(color As Color) As String
        Return color.ToArgb().ToString()
    End Function

    ''' <summary>
    ''' Convert string to color.
    ''' </summary>
    Public Function StringToColor(str As String) As Color
        Return Color.FromArgb(Integer.Parse(str))
    End Function

    ''' <summary>
    ''' Read file with values from default file.
    ''' </summary>
    Public Sub ReadFromCfg()
        ReadFromCfg(defaultPath)
    End Sub

    ''' <summary>
    ''' Read file with values from file.
    ''' </summary>
    Public Sub ReadFromCfg(path As String)
        Try
            Using streamReader As System.IO.StreamReader = New System.IO.StreamReader(path)
                Dim param As String()
                Dim line As String = streamReader.ReadLine()
                While (line <> Nothing)
                    param = line.Split("=")
                    Select Case param(0)
                        Case "colorBlack" : colorBlack = StringToColor(param(1))
                        Case "colorWhite" : colorWhite = StringToColor(param(1))
                        Case "colorMove" : colorMove = StringToColor(param(1))
                        Case "colorCut" : colorCut = StringToColor(param(1))
                        Case "theme" : theme = Integer.Parse(param(1))
                        Case "paintAllPossible" : PaintAllPossible = param(1) = "True"
                    End Select
                    line = streamReader.ReadLine()
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Config file not found.\nThe settings are set by default.\n" + ex.Message, "Warning!")
        End Try
    End Sub

    ''' <summary>
    ''' Write settings to default file.
    ''' </summary>
    Public Sub WriteToCfg()
        WriteToCfg(defaultPath)
    End Sub

    ''' <summary>
    ''' Write settings to file.
    ''' </summary>
    Public Sub WriteToCfg(path As String)
        Using streamWriter As System.IO.StreamWriter = New System.IO.StreamWriter(path)
            streamWriter.WriteLine("theme=" + theme.ToString())
            streamWriter.WriteLine("colorBlack=" + ColorToString(colorBlack))
            streamWriter.WriteLine("colorWhite=" + ColorToString(colorWhite))
            streamWriter.WriteLine("colorMove=" + ColorToString(colorMove))
            streamWriter.WriteLine("colorCut=" + ColorToString(colorCut))
            streamWriter.WriteLine("paintAllPossible=" + PaintAllPossible.ToString())
        End Using
    End Sub
End Class
