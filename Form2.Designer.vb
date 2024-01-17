<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm2_melonDS_to_DeSmuMe
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm2_melonDS_to_DeSmuMe))
        SaveFileDialog1 = New SaveFileDialog()
        ToolTip1 = New ToolTip(components)
        Button1 = New Button()
        Button2 = New Button()
        MaskedTextBox1 = New MaskedTextBox()
        TextBox1 = New TextBox()
        Frm2_Close_Btn = New Button()
        Frm2_melonDS_Cvrt_DeSmuME_btn = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ToolTip1
        ' 
        ToolTip1.AutoPopDelay = 5000
        ToolTip1.InitialDelay = 500
        ToolTip1.ReshowDelay = 100
        ToolTip1.ToolTipIcon = ToolTipIcon.Info
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImage = My.Resources.Resources.Provide_Game_Title
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.CausesValidation = False
        Button1.Enabled = False
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.Transparent
        Button1.Image = My.Resources.Resources.Provide_Game_Title
        Button1.Location = New Point(10, 8)
        Button1.Name = "Button1"
        Button1.Size = New Size(145, 85)
        Button1.TabIndex = 2
        ToolTip1.SetToolTip(Button1, resources.GetString("Button1.ToolTip"))
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImage = My.Resources.Resources.Provide_Game_Code
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.CausesValidation = False
        Button2.Enabled = False
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.ForeColor = Color.Transparent
        Button2.Image = My.Resources.Resources.Provide_Game_Title
        Button2.Location = New Point(10, 99)
        Button2.Name = "Button2"
        Button2.Size = New Size(145, 85)
        Button2.TabIndex = 4
        ToolTip1.SetToolTip(Button2, resources.GetString("Button2.ToolTip"))
        Button2.UseVisualStyleBackColor = False
        ' 
        ' MaskedTextBox1
        ' 
        MaskedTextBox1.Location = New Point(161, 131)
        MaskedTextBox1.Mask = "AAAA"
        MaskedTextBox1.Name = "MaskedTextBox1"
        MaskedTextBox1.Size = New Size(143, 23)
        MaskedTextBox1.TabIndex = 8
        ToolTip1.SetToolTip(MaskedTextBox1, resources.GetString("MaskedTextBox1.ToolTip"))
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(161, 40)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(143, 23)
        TextBox1.TabIndex = 9
        ToolTip1.SetToolTip(TextBox1, resources.GetString("TextBox1.ToolTip"))
        ' 
        ' Frm2_Close_Btn
        ' 
        Frm2_Close_Btn.ForeColor = Color.Black
        Frm2_Close_Btn.Location = New Point(10, 235)
        Frm2_Close_Btn.Name = "Frm2_Close_Btn"
        Frm2_Close_Btn.Size = New Size(307, 23)
        Frm2_Close_Btn.TabIndex = 5
        Frm2_Close_Btn.Text = "Close"
        Frm2_Close_Btn.UseVisualStyleBackColor = True
        ' 
        ' Frm2_melonDS_Cvrt_DeSmuME_btn
        ' 
        Frm2_melonDS_Cvrt_DeSmuME_btn.ForeColor = Color.Black
        Frm2_melonDS_Cvrt_DeSmuME_btn.Location = New Point(10, 174)
        Frm2_melonDS_Cvrt_DeSmuME_btn.Name = "Frm2_melonDS_Cvrt_DeSmuME_btn"
        Frm2_melonDS_Cvrt_DeSmuME_btn.Size = New Size(307, 55)
        Frm2_melonDS_Cvrt_DeSmuME_btn.TabIndex = 6
        Frm2_melonDS_Cvrt_DeSmuME_btn.Text = "Convert"
        Frm2_melonDS_Cvrt_DeSmuME_btn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold Or FontStyle.Underline)
        Label1.ForeColor = Color.Cyan
        Label1.Location = New Point(0, 173)
        Label1.Name = "Label1"
        Label1.Size = New Size(328, 56)
        Label1.TabIndex = 7
        Label1.Text = "Convert Button Will Appear " & vbCrLf & "After the above is properly Given" & vbCrLf
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Red
        PictureBox1.Image = My.Resources.Resources.Please_Input_Both_Fields
        PictureBox1.Location = New Point(161, 69)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(143, 56)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' Frm2_melonDS_to_DeSmuMe
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.FutureLoginModified
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(329, 261)
        ControlBox = False
        Controls.Add(PictureBox1)
        Controls.Add(TextBox1)
        Controls.Add(MaskedTextBox1)
        Controls.Add(Label1)
        Controls.Add(Frm2_melonDS_Cvrt_DeSmuME_btn)
        Controls.Add(Frm2_Close_Btn)
        Controls.Add(Button2)
        Controls.Add(Button1)
        DoubleBuffered = True
        ForeColor = Color.Transparent
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Frm2_melonDS_to_DeSmuMe"
        Text = "MelonDS to DeSumME "
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Frm2_Close_Btn As Button
    Friend WithEvents Frm2_melonDS_Cvrt_DeSmuME_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
