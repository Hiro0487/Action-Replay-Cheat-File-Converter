<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm2_Preview
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
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        SaveFileDialog1 = New SaveFileDialog()
        Frm2_Save_Btn = New Button()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(12, 12)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Source Fille to Convert Preview"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(381, 384)
        TextBox1.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(399, 12)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.PlaceholderText = "Target Converted Preview"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(398, 384)
        TextBox2.TabIndex = 1
        ' 
        ' Frm2_Save_Btn
        ' 
        Frm2_Save_Btn.Location = New Point(12, 402)
        Frm2_Save_Btn.Name = "Frm2_Save_Btn"
        Frm2_Save_Btn.Size = New Size(381, 46)
        Frm2_Save_Btn.TabIndex = 2
        Frm2_Save_Btn.Text = "Save"
        Frm2_Save_Btn.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(399, 402)
        Button2.Name = "Button2"
        Button2.Size = New Size(398, 46)
        Button2.TabIndex = 3
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Frm2_Preview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.FutureLoginModified
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        ControlBox = False
        Controls.Add(Button2)
        Controls.Add(Frm2_Save_Btn)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        DoubleBuffered = True
        Name = "Frm2_Preview"
        Text = "Conversion Preview"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Frm2_Save_Btn As Button
    Friend WithEvents Button2 As Button
End Class
