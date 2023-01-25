<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerVsPlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerVsComputerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.groupBox_ChessBoard = New System.Windows.Forms.GroupBox()
        Me.label_gameOver = New System.Windows.Forms.Label()
        Me.label_whichPlayer = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Cascadia Code SemiBold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(436, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.LoadLevelToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.GameToolStripMenuItem.Text = "Game"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayerVsPlayerToolStripMenuItem, Me.PlayerVsComputerToolStripMenuItem})
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.NewGameToolStripMenuItem.Text = "New Gabe"
        '
        'PlayerVsPlayerToolStripMenuItem
        '
        Me.PlayerVsPlayerToolStripMenuItem.Name = "PlayerVsPlayerToolStripMenuItem"
        Me.PlayerVsPlayerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.PlayerVsPlayerToolStripMenuItem.Size = New System.Drawing.Size(298, 22)
        Me.PlayerVsPlayerToolStripMenuItem.Text = "Player vs. Player"
        '
        'PlayerVsComputerToolStripMenuItem
        '
        Me.PlayerVsComputerToolStripMenuItem.Name = "PlayerVsComputerToolStripMenuItem"
        Me.PlayerVsComputerToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.PlayerVsComputerToolStripMenuItem.Size = New System.Drawing.Size(298, 22)
        Me.PlayerVsComputerToolStripMenuItem.Text = "Player vs. Computer"
        '
        'LoadLevelToolStripMenuItem
        '
        Me.LoadLevelToolStripMenuItem.Name = "LoadLevelToolStripMenuItem"
        Me.LoadLevelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LoadLevelToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.LoadLevelToolStripMenuItem.Text = "Load Level"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'groupBox_ChessBoard
        '
        Me.groupBox_ChessBoard.Enabled = False
        Me.groupBox_ChessBoard.Location = New System.Drawing.Point(12, 27)
        Me.groupBox_ChessBoard.Name = "groupBox_ChessBoard"
        Me.groupBox_ChessBoard.Size = New System.Drawing.Size(412, 427)
        Me.groupBox_ChessBoard.TabIndex = 1
        Me.groupBox_ChessBoard.TabStop = False
        Me.groupBox_ChessBoard.Text = "Chess board"
        '
        'label_gameOver
        '
        Me.label_gameOver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_gameOver.Location = New System.Drawing.Point(183, 457)
        Me.label_gameOver.Name = "label_gameOver"
        Me.label_gameOver.Size = New System.Drawing.Size(241, 16)
        Me.label_gameOver.TabIndex = 2
        Me.label_gameOver.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_whichPlayer
        '
        Me.label_whichPlayer.AutoSize = True
        Me.label_whichPlayer.Location = New System.Drawing.Point(12, 457)
        Me.label_whichPlayer.Name = "label_whichPlayer"
        Me.label_whichPlayer.Size = New System.Drawing.Size(0, 16)
        Me.label_whichPlayer.TabIndex = 3
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 479)
        Me.Controls.Add(Me.label_whichPlayer)
        Me.Controls.Add(Me.label_gameOver)
        Me.Controls.Add(Me.groupBox_ChessBoard)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Cascadia Code SemiBold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Main"
        Me.Text = "Chess Game"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayerVsPlayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayerVsComputerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadLevelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents groupBox_ChessBoard As GroupBox
    Friend WithEvents label_gameOver As Label
    Friend WithEvents label_whichPlayer As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
