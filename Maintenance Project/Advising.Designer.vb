<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advising
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
        Me.advisingLabel = New System.Windows.Forms.Label()
        Me.AdvisingCalendar = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.AdvisingDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TestLabel = New System.Windows.Forms.Label()
        CType(Me.AdvisingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'advisingLabel
        '
        Me.advisingLabel.AutoSize = True
        Me.advisingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.advisingLabel.Location = New System.Drawing.Point(7, 18)
        Me.advisingLabel.Name = "advisingLabel"
        Me.advisingLabel.Size = New System.Drawing.Size(396, 25)
        Me.advisingLabel.TabIndex = 0
        Me.advisingLabel.Text = "Pick a Date to See Available Instructors:"
        '
        'AdvisingCalendar
        '
        Me.AdvisingCalendar.Location = New System.Drawing.Point(18, 52)
        Me.AdvisingCalendar.Name = "AdvisingCalendar"
        Me.AdvisingCalendar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(481, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(520, 168)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(520, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Schedule"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(481, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Time:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(520, 194)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 8
        '
        'AdvisingDataGridView
        '
        Me.AdvisingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdvisingDataGridView.Location = New System.Drawing.Point(12, 319)
        Me.AdvisingDataGridView.Name = "AdvisingDataGridView"
        Me.AdvisingDataGridView.Size = New System.Drawing.Size(834, 268)
        Me.AdvisingDataGridView.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 291)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 25)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Advisors:"
        '
        'TestLabel
        '
        Me.TestLabel.AutoSize = True
        Me.TestLabel.Location = New System.Drawing.Point(370, 216)
        Me.TestLabel.Name = "TestLabel"
        Me.TestLabel.Size = New System.Drawing.Size(28, 13)
        Me.TestLabel.TabIndex = 11
        Me.TestLabel.Text = "Test"
        '
        'Advising
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 599)
        Me.Controls.Add(Me.TestLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AdvisingDataGridView)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AdvisingCalendar)
        Me.Controls.Add(Me.advisingLabel)
        Me.Name = "Advising"
        Me.Text = "Advising"
        CType(Me.AdvisingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents advisingLabel As Label
    Friend WithEvents AdvisingCalendar As MonthCalendar
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents AdvisingDataGridView As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents TestLabel As Label
End Class
