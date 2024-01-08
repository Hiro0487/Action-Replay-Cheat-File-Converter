<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm2_melonDS_to_DeSmuMe
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
        components = New ComponentModel.Container()
        SaveFileDialog1 = New SaveFileDialog()
        ToolTip1 = New ToolTip(components)
        TextBox1 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        TextBox2 = New TextBox()
        Frm2_Close_Btn = New Button()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(161, 70)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(143, 23)
        TextBox1.TabIndex = 1
        TextBox1.Text = "Game Title"
        ToolTip1.SetToolTip(TextBox1, "In melonDS can be found by going to System in menu bard and clicking on ROM Info")
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImage = My.Resources.Resources.Provide_Game_Title
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.CausesValidation = False
        Button1.Enabled = False
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.Transparent
        Button1.Image = My.Resources.Resources.Provide_Game_Title
        Button1.Location = New Point(10, 8)
        Button1.Name = "Button1"
        Button1.Size = New Size(145, 85)
        Button1.TabIndex = 2
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImage = My.Resources.Resources.Provide_Game_Title
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.CausesValidation = False
        Button2.Enabled = False
        Button2.FlatStyle = FlatStyle.Flat
        Button2.ForeColor = Color.Transparent
        Button2.Image = My.Resources.Resources.Provide_Game_Title
        Button2.Location = New Point(12, 99)
        Button2.Name = "Button2"
        Button2.Size = New Size(145, 85)
        Button2.TabIndex = 4
        Button2.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(163, 161)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(143, 23)
        TextBox2.TabIndex = 3
        TextBox2.Text = "Game Code"
        ' 
        ' Frm2_Close_Btn
        ' 
        Frm2_Close_Btn.ForeColor = Color.Black
        Frm2_Close_Btn.Location = New Point(10, 194)
        Frm2_Close_Btn.Name = "Frm2_Close_Btn"
        Frm2_Close_Btn.Size = New Size(307, 23)
        Frm2_Close_Btn.TabIndex = 5
        Frm2_Close_Btn.Text = "Close"
        Frm2_Close_Btn.UseVisualStyleBackColor = True
        ' 
        ' Frm2_melonDS_to_DeSmuMe
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.FutureLoginModified
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(329, 229)
        ControlBox = False
        Controls.Add(Frm2_Close_Btn)
        Controls.Add(Button2)
        Controls.Add(TextBox2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        DoubleBuffered = True
        ForeColor = Color.Transparent
        Name = "Frm2_melonDS_to_DeSmuMe"
        Text = "Conversion Preview"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Frm2_Close_Btn As Button
End Class
