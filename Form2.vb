Imports System.IO

Public Class Frm2_melonDS_to_DeSmuMe
    Private Sub Frm2_melonDS_to_DeSmuMe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValidateFields() ' Update UI based on initial validation
    End Sub

    Private Sub Frm2_melonDS_Cvrt_DeSmuME_btn_Click(sender As Object, e As EventArgs) Handles Frm2_melonDS_Cvrt_DeSmuME_btn.Click
        Try
            ProcessCheatFile()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Frm2_Close_Btn_Click(sender As Object, e As EventArgs) Handles Frm2_Close_Btn.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub HandleInputChanges(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, MaskedTextBox1.TextChanged
        ValidateFields() ' Trigger validation on text changes

    End Sub

    Private Function ValidateFields() As Boolean
        ' Check if both fields are valid and update UI elements accordingly
        If TextBox1.Text.Trim <> "" AndAlso MaskedTextBox1.MaskFull Then
            MaskedTextBox1.ForeColor = Color.Green
            Label1.Visible = False
            Frm2_melonDS_Cvrt_DeSmuME_btn.Visible = True
            Return True
        ElseIf Not TextBox1.Text.Trim <> "" OrElse Not MaskedTextBox1.MaskFull Then ' Handle invalid case
            PictureBox1.Visible = True
            Label1.Visible = True
            MaskedTextBox1.ForeColor = Color.Red
            Frm2_melonDS_Cvrt_DeSmuME_btn.Visible = False
            Return False
        End If

        ' Final safeguard to ensure a value is always returned
        Return False ' Or a more appropriate default value if applicable
    End Function

    Private Function PromptUserForFile() As String
        Dim openFileDialog As New OpenFileDialog With {
            .Title = "Select Cheat File",
            .Filter = "Cheat Files (*.MCH)|*.MCH",
            .InitialDirectory = "E:\Emulator's\ROMS\DS\Pokemon Diamond (v05) (U)(Legacy)"'This will be dynamic when project is finished
        }
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Return filePath ' Return the selected file path
        Else
            Return String.Empty ' Return an empty string if the user canceled
        End If
    End Function



    Private Sub ProcessCheatFile()
        Dim invalidHexCodes As List(Of String) = New List(Of String)

        Dim filePath = PromptUserForFile()
        Dim lines = File.ReadAllLines(filePath).ToArray()


        Dim outputLines As List(Of String) = New List(Of String)
        GenerateDctHeader(outputLines)
        For Each line As String In lines
            ProcessLine(line, outputLines, invalidHexCodes)
        Next

        Dim saveFilePath = PromptUserForSaveFile()
        File.WriteAllLines(saveFilePath, outputLines.ToArray())
        MsgBox("Cheat file converted successfully.")

        DisplayInvalidCodesMessage(invalidHexCodes)
    End Sub

    'This Function Needs modified to work with MCH cheat file layout to convert to DCT Cheat File Layout
    Private Sub ProcessLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        Select Case True
            Case line.StartsWith(";cheats list") : ProcessCommentLine(line, outputLines)
            Case line.StartsWith("CODE 0") OrElse line.StartsWith("CODE 1") : ProcessCodeLine(line, outputLines, invalidHexCodes)
            Case Else : ProcessHexCodeLine(line, outputLines, invalidHexCodes)
        End Select
    End Sub

    'This Function Needs modified to work with MCH cheat file layout to convert to DCT Cheat File Layout, it requires user
    'Input for Game Title, and Game Code
    'Game Title is found by: Open rom up in melonDS, in the title bar Click System, ROM info Look for Game Title
    '"Game Title: {Field Data}, Eg, For Pokemon Diamond "Game Tile: POKEMON D"
    'Game Code is found by:  Open rom up in melonDS, in the title bar, Click System, ROM info, Look for Game Code
    'Game Code: {Field Data} Eg, For Pokemon Diamond "Game Code: ADAE" 
    'For the game code that is technically the Serial so for the USA version of Pokemon Diamond the Serial would be
    'NTR-ADAE-USA that meands the field data should be "ADAE" as far as i can tell this should work for most USA NDS ROMS
    'the NTR-{Field Data}-USA is automatically filled in during conversion.
    'also the cheat code block of all the cheat codes and hex codes starts with ;cheats list carriage return
    'then AR 1 or AR 0, Hexcodes in hexcode block, Description.
    Private Sub ProcessCommentLine(line As String, outputLines As List(Of String))

        Dim hexCodesAndDescription = line.Substring(1).Trim().Split({","c, ";"c}, StringSplitOptions.RemoveEmptyEntries)
        Dim codeType = If(line.StartsWith(";AR 1 "), "CODE 1", "CAT") ' Determine code type
        Dim description = hexCodesAndDescription.Last().Trim() ' Trim potential extra spaces
        description = description & Environment.NewLine
        ' Add description to code type line
        outputLines.Add($"{codeType} {description}")
    End Sub

    Private Sub GenerateDctHeader(outputLines As Object)
        Dim gameTitle As String = "POKEMON D" 'Dim gameTitle As String = TextBox1.Text
        Dim gameCode As String = "ADAE" 'Dim gameCode As String = MaskedTextBox1.Text

        Dim headerLines As String() = {
        "; DeSmuME cheats file. VERSION 2.000",
        "Name=" & gameTitle,
        "Serial=NTR-" & gameCode & "-USA",
         outputLines.Add(Environment.NewLine),
        "; cheats list"
    }
        outputLines.InsertRange(0, headerLines) ' Prepend header lines to output
    End Sub
    'Function Needs Modified to work with MCH File format to convert to DCT file format
    'this needs to convert ouput to codetype delimited by " ", Hexcodes delimited by "," ,Delimited by ";" Description.
    Private Sub ProcessCodeLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        ' ... (code for processing code lines, including category handling)
        Dim description As String
        Dim hexCodes As String()
        ' Use a temporary variable to hold the tuple
        Dim result = ExtractDescriptionAndHexCodes(line)
        description = result.Description
        hexCodes = result.HexCodes
        Dim codeType = DetermineCodeType(line)
        ProcessHexCodes(hexCodes, outputLines, invalidHexCodes)
        outputLines.Add($"{codeType} ;{description}")
        outputLines.Add(Environment.NewLine)
    End Sub

    Private Sub ProcessHexCodeLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        ' ... (code for processing hex code lines)

    End Sub

    'I don't think this function needs modifieds once all the other required functions are modified
    Private Function PromptUserForSaveFile() As String
        Dim outputLines As List(Of String) = New List(Of String)
        Dim saveFileDialog As New SaveFileDialog With {
            .Title = "Save Converted Cheat File",
            .Filter = "Cheat Files (*.DCT)|*.DCT",
            .InitialDirectory = "E:\Emulator's\DS\DeSmuMe\Cheats"'This will be dynamic when project is finished
            }
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Return saveFileDialog.FileName ' Return the selected file path
        Else
            Return String.Empty ' Return an empty string if the user canceled
        End If
    End Function

    'I don't think this function needs modifieds once all the other required functions are modified
    Private Sub DisplayInvalidCodesMessage(invalidHexCodes As List(Of String))
        ' Display a message about invalid codes (optional)
        If invalidHexCodes.Count > 0 Then
            MsgBox("The following hex codes were invalid: " & Environment.NewLine & String.Join(Environment.NewLine, invalidHexCodes))
        End If
    End Sub

    'Function Needs Modified to work with MCH File format to convert to DCT file format
    Private Function ExtractDescriptionAndHexCodes(line As String) As (Description As String, HexCodes As String())
        Dim codeStartIndex = line.IndexOf("CODE ")
        If codeStartIndex >= 0 Then
            Dim codeType = line.Substring(codeStartIndex + 5, 1).Trim() ' Get the code type (0 or 1)
            If codeType = "0" OrElse codeType = "1" Then
                Dim descriptionStartIndex = line.IndexOf(" ", codeStartIndex + 6) ' Find the space after "CODE 0" or "CODE 1"
                If descriptionStartIndex >= 0 Then
                    Dim description = line.Substring(descriptionStartIndex + 1).Trim()
                    Dim hexCodesAndDescription = line.Substring(codeStartIndex + 6, descriptionStartIndex - codeStartIndex - 6).Trim()
                    Dim hexCodes = hexCodesAndDescription.Split({","c}, StringSplitOptions.RemoveEmptyEntries).ToArray()
                    Return (description, hexCodes)
                End If
            End If
        End If
        Return ("", {}) ' Return empty values if description and hex codes are not found
    End Function

    'Function Needs Modified to work with MCH File format to convert to DCT file format
    Private Function DetermineCodeType(line As String) As String
        Return If(line.StartsWith("CODE 1 "), "AR 1", "AR 0")
    End Function

    'I don't think this function needs modifieds once all the other required functions are modified 
    Private Sub ProcessHexCodes(hexCodes As String(), outputLines As List(Of String), invalidHexCodes As List(Of String))
        For Each hexCode As String In hexCodes
            Try
                If IsValidHexCode(hexCode) Then
                    ProcessValidHexCode(hexCode, outputLines)
                Else
                    outputLines.Add(hexCode)
                    invalidHexCodes.Add(hexCode)
                End If
            Catch ex As Exception
                outputLines.Add("Error processing hex code: " & ex.Message)
            End Try
        Next
    End Sub

    'Function Needs Modified to work with MCH File format to convert to DCT file format
    Private Function IsValidHexCode(hexCode As String) As Boolean
        Return hexCode.Replace(" ", "").All(Function(c) Char.IsDigit(c) OrElse Char.IsLetter(c))
    End Function

    'Function Needs Modified to work with MCH File format to convert to DCT file format
    'this needs to take the hexcodes seperated by " " and combine them from to sets of 8 to 
    'one sent of 16, then add "," next hexcode in hexcode block untill carriage return after hexcode block is reached.
    'so i assume it will loop until a black carriage return is reached then proccede to next hex code block if exist
    'after which the description needs to be added witt ; at the beginning followed by description
    'eg, {All HEX codes in block} ;{Description} ended with a carriage return.
    Private Sub ProcessValidHexCode(hexCode As String, outputLines As List(Of String))
        Dim substringLength = If(hexCode.Length > 18, 18, 8)
        If hexCode.Length >= substringLength Then
            outputLines.Add(hexCode.Substring(0, substringLength) + " " + hexCode.Substring(substringLength))
        Else
            ' Handle the case where the string is too short (e.g., output the original hexCode or log a warning)
        End If
    End Sub

End Class