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
        Dim filePath = PromptUserForFile()
        If String.IsNullOrEmpty(filePath) Then Return

        Dim outputLines As New List(Of String)
        Dim invalidHexCodes As New List(Of String)

        GenerateDctHeader(outputLines)

        Using reader As New StreamReader(filePath)
            Dim line As String
            While (InlineAssignHelper(line, reader.ReadLine())) IsNot Nothing
                ProcessLine(line.Trim(), reader, outputLines, invalidHexCodes)
            End While
        End Using

        Dim saveFilePath = PromptUserForSaveFile()
        If Not String.IsNullOrEmpty(saveFilePath) Then
            File.WriteAllLines(saveFilePath, outputLines)
            MsgBox("Cheat file converted successfully.")
            DisplayInvalidCodesMessage(invalidHexCodes)
        End If
    End Sub


    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function


    'This Function Needs modified to work with MCH cheat file layout to convert to DCT Cheat File Layout
    Private Sub ProcessLine(line As String, reader As StreamReader, outputLines As List(Of String), invalidHexCodes As List(Of String))
        If String.IsNullOrWhiteSpace(line) Then Return
        If line.StartsWith(";") Then
            ProcessCommentLine(line, outputLines)
        ElseIf line.StartsWith("CODE ") Then
            ProcessCodeLine(line, reader, outputLines, invalidHexCodes)
        End If
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
        outputLines.Add(line)
    End Sub


    Private Sub GenerateDctHeader(outputLines As List(Of String))
        Dim gameTitle As String = TextBox1.Text.Trim()
        Dim gameCode As String = MaskedTextBox1.Text.Trim()

        ' Use default values if the input is empty
        If String.IsNullOrEmpty(gameTitle) Then gameTitle = "POKEMON D"
        If String.IsNullOrEmpty(gameCode) Then gameCode = "ADAE"

        Dim headerLines As String() = {
        "; DeSmuME cheats file. VERSION 2.000",
        $"Name={gameTitle}",
        $"Serial=NTR-{gameCode}-USA",
        "",
        "; cheats list"
    }
        outputLines.AddRange(headerLines)
    End Sub


    'Function Needs Modified to work with MCH File format to convert to DCT file format
    'this needs to convert ouput to codetype delimited by " ", Hexcodes delimited by "," ,Delimited by ";" Description.
    Private Sub ProcessCodeLine(line As String, reader As StreamReader, outputLines As List(Of String), invalidHexCodes As List(Of String))
        Dim parts = line.Split(New Char() {" "c}, 3)
        If parts.Length < 3 Then Return

        Dim codeType = If(parts(1) = "1", "AR 1", "AR 0")
        Dim description = parts(2)
        Dim hexCodes = New List(Of String)()

        ' Read the next 4 lines for hex codes
        For i As Integer = 1 To 4
            Dim hexLine = reader.ReadLine()
            If Not String.IsNullOrWhiteSpace(hexLine) Then
                hexCodes.Add(hexLine.Replace(" ", ""))
            End If
        Next

        Dim formattedHexCodes = String.Join(",", hexCodes)
        outputLines.Add($"{codeType} {formattedHexCodes} ;{description}")
    End Sub



    Private Function FormatHexCodes(hexCodes As String()) As String
        Dim formattedCodes = New List(Of String)()
        For i As Integer = 0 To hexCodes.Length - 1 Step 2
            If i + 1 < hexCodes.Length Then
                formattedCodes.Add(hexCodes(i) & hexCodes(i + 1))
            Else
                formattedCodes.Add(hexCodes(i))
            End If
        Next
        Return String.Join(",", formattedCodes)
    End Function

    'Private Sub ProcessHexCodeLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
    'Dim hexCodes = line.Split(" "c)
    'Dim formattedHexCodes = String.Join(",", hexCodes)
    '   outputLines.Add(formattedHexCodes)
    'End Sub



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
        Dim parts = line.Split(New Char() {" "c}, 3)
        If parts.Length < 3 Then Return ("", Array.Empty(Of String)())

        Dim description = parts(2)
        Dim hexCodes = New List(Of String)()

        ' Extract hex codes
        Dim hexCodeMatch = System.Text.RegularExpressions.Regex.Match(description, "^([0-9A-Fa-f\s]+)")
        If hexCodeMatch.Success Then
            hexCodes.AddRange(hexCodeMatch.Value.Trim().Split(" "c))
            description = description.Substring(hexCodeMatch.Length).Trim()
        End If

        Return (description, hexCodes.ToArray())
    End Function



    'Function Needs Modified to work with MCH File format to convert to DCT file format
    Private Function DetermineCodeType(line As String) As String
        Return If(line.StartsWith("AR 1"), "CODE 1", "CODE 0")
    End Function


    'I don't think this function needs modifieds once all the other required functions are modified 
    Private Sub ProcessHexCodes(hexCodes As String(), outputLines As List(Of String), invalidHexCodes As List(Of String), description As String)
        Dim processedCodes As New List(Of String)

        For Each hexCode As String In hexCodes
            Try
                If IsValidHexCode(hexCode) Then
                    processedCodes.Add(hexCode)
                Else
                    invalidHexCodes.Add(hexCode)
                End If
            Catch ex As Exception
                outputLines.Add("Error processing hex code: " & ex.Message)
            End Try
        Next

        If processedCodes.Count > 0 Then
            ProcessValidHexCode(processedCodes.ToArray(), outputLines, description)
        End If
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
    Private Sub ProcessValidHexCode(hexCodes As String(), outputLines As List(Of String), description As String)
        Dim processedCodes As New List(Of String)

        For i As Integer = 0 To hexCodes.Length - 1 Step 2
            If i + 1 < hexCodes.Length Then
                processedCodes.Add(hexCodes(i) & hexCodes(i + 1))
            Else
                processedCodes.Add(hexCodes(i))
            End If
        Next

        outputLines.Add(String.Join(",", processedCodes) & " ;" & description)
    End Sub


End Class