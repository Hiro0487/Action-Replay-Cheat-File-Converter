<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        OpenFileDialog1 = New OpenFileDialog()
        GroupBox1 = New GroupBox()
        Button2 = New Button()
        Button1 = New Button()
        Button3 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.FlatStyle = FlatStyle.Flat
        GroupBox1.Font = New Font("Segoe UI", 18F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        GroupBox1.ForeColor = Color.PaleGreen
        GroupBox1.Location = New Point(12, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(288, 163)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Convert From"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Black
        Button2.BackgroundImage = My.Resources.Resources.MelonDS_to_DeSumME
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Location = New Point(6, 96)
        Button2.Name = "Button2"
        Button2.Size = New Size(276, 52)
        Button2.TabIndex = 1
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Black
        Button1.BackgroundImage = My.Resources.Resources.DeSumME_to_MelonDS
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Image = My.Resources.Resources.DeSumME_to_MelonDS
        Button1.Location = New Point(6, 38)
        Button1.Name = "Button1"
        Button1.Size = New Size(276, 52)
        Button1.TabIndex = 0
        Button1.TextImageRelation = TextImageRelation.ImageAboveText
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Black
        Button3.BackgroundImage = My.Resources.Resources.Close_Btn_From1
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.FlatStyle = FlatStyle.Popup
        Button3.Location = New Point(12, 169)
        Button3.Name = "Button3"
        Button3.Size = New Size(288, 66)
        Button3.TabIndex = 1
        Button3.TextImageRelation = TextImageRelation.ImageAboveText
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.ConsoleRetroCodeSequence
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(312, 247)
        Controls.Add(Button3)
        Controls.Add(GroupBox1)
        DoubleBuffered = True
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Hiro's Cheat FIle Converter"
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Private WithEvents Button2 As Button

End Class
