<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comboBox_theme = New System.Windows.Forms.ComboBox()
        Me.groupBox_colorButtons = New System.Windows.Forms.GroupBox()
        Me.button_blackColor = New System.Windows.Forms.Button()
        Me.button_whiteColor = New System.Windows.Forms.Button()
        Me.button_moveColor = New System.Windows.Forms.Button()
        Me.button_cutColor = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.checkBox_paintAllPosible = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.button_cancel = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.GroupBox1.SuspendLayout()
        Me.groupBox_colorButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Settings:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.groupBox_colorButtons)
        Me.GroupBox1.Controls.Add(Me.comboBox_theme)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 145)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Theme:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Select theme:"
        '
        'comboBox_theme
        '
        Me.comboBox_theme.FormattingEnabled = True
        Me.comboBox_theme.Items.AddRange(New Object() {"Classic", "Dark", "Light", "Custom"})
        Me.comboBox_theme.Location = New System.Drawing.Point(110, 14)
        Me.comboBox_theme.Name = "comboBox_theme"
        Me.comboBox_theme.Size = New System.Drawing.Size(126, 24)
        Me.comboBox_theme.TabIndex = 1
        '
        'groupBox_colorButtons
        '
        Me.groupBox_colorButtons.Controls.Add(Me.Label6)
        Me.groupBox_colorButtons.Controls.Add(Me.Label5)
        Me.groupBox_colorButtons.Controls.Add(Me.Label4)
        Me.groupBox_colorButtons.Controls.Add(Me.Label3)
        Me.groupBox_colorButtons.Controls.Add(Me.button_cutColor)
        Me.groupBox_colorButtons.Controls.Add(Me.button_moveColor)
        Me.groupBox_colorButtons.Controls.Add(Me.button_whiteColor)
        Me.groupBox_colorButtons.Controls.Add(Me.button_blackColor)
        Me.groupBox_colorButtons.Location = New System.Drawing.Point(6, 44)
        Me.groupBox_colorButtons.Name = "groupBox_colorButtons"
        Me.groupBox_colorButtons.Size = New System.Drawing.Size(230, 96)
        Me.groupBox_colorButtons.TabIndex = 2
        Me.groupBox_colorButtons.TabStop = False
        Me.groupBox_colorButtons.Text = "Colors:"
        '
        'button_blackColor
        '
        Me.button_blackColor.Location = New System.Drawing.Point(6, 20)
        Me.button_blackColor.Name = "button_blackColor"
        Me.button_blackColor.Size = New System.Drawing.Size(50, 50)
        Me.button_blackColor.TabIndex = 0
        Me.button_blackColor.UseVisualStyleBackColor = True
        '
        'button_whiteColor
        '
        Me.button_whiteColor.Location = New System.Drawing.Point(62, 20)
        Me.button_whiteColor.Name = "button_whiteColor"
        Me.button_whiteColor.Size = New System.Drawing.Size(50, 50)
        Me.button_whiteColor.TabIndex = 0
        Me.button_whiteColor.UseVisualStyleBackColor = True
        '
        'button_moveColor
        '
        Me.button_moveColor.Location = New System.Drawing.Point(118, 20)
        Me.button_moveColor.Name = "button_moveColor"
        Me.button_moveColor.Size = New System.Drawing.Size(50, 50)
        Me.button_moveColor.TabIndex = 0
        Me.button_moveColor.UseVisualStyleBackColor = True
        '
        'button_cutColor
        '
        Me.button_cutColor.Location = New System.Drawing.Point(174, 20)
        Me.button_cutColor.Name = "button_cutColor"
        Me.button_cutColor.Size = New System.Drawing.Size(50, 50)
        Me.button_cutColor.TabIndex = 0
        Me.button_cutColor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Black"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "White"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(118, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Move"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(174, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Cut"
        '
        'checkBox_paintAllPosible
        '
        Me.checkBox_paintAllPosible.AutoSize = True
        Me.checkBox_paintAllPosible.Location = New System.Drawing.Point(12, 179)
        Me.checkBox_paintAllPosible.Name = "checkBox_paintAllPosible"
        Me.checkBox_paintAllPosible.Size = New System.Drawing.Size(215, 20)
        Me.checkBox_paintAllPosible.TabIndex = 2
        Me.checkBox_paintAllPosible.Text = "Paint all possible actions."
        Me.checkBox_paintAllPosible.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(99, 234)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'button_cancel
        '
        Me.button_cancel.Location = New System.Drawing.Point(180, 234)
        Me.button_cancel.Name = "button_cancel"
        Me.button_cancel.Size = New System.Drawing.Size(75, 23)
        Me.button_cancel.TabIndex = 3
        Me.button_cancel.Text = "Cancel"
        Me.button_cancel.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 269)
        Me.Controls.Add(Me.button_cancel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.checkBox_paintAllPosible)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Cascadia Code SemiBold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SettingsForm"
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.groupBox_colorButtons.ResumeLayout(False)
        Me.groupBox_colorButtons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents groupBox_colorButtons As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents button_cutColor As Button
    Friend WithEvents button_moveColor As Button
    Friend WithEvents button_whiteColor As Button
    Friend WithEvents button_blackColor As Button
    Friend WithEvents comboBox_theme As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents checkBox_paintAllPosible As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents button_cancel As Button
    Friend WithEvents ColorDialog1 As ColorDialog
End Class
