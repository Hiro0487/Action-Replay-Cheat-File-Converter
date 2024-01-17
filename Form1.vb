Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ProcessCheatFile()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Frm2_melonDS_to_DeSmuMe.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    ''This is where all functions aside from main start
    Private Function PromptUserForFile() As String
        Dim openFileDialog As New OpenFileDialog With {
            .Title = "Select Cheat File",
            .Filter = "Cheat Files (*.DCT)|*.DCT",
            .InitialDirectory = "F:\Emulator's\DS\DeSmuMe\Cheats"'This will be dynamic when project is finished
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
        Dim lines = File.ReadAllLines(filePath).Skip(4).ToArray()

        Dim outputLines As List(Of String) = New List(Of String)
        For Each line As String In lines
            ProcessLine(line, outputLines, invalidHexCodes)
        Next

        Dim saveFilePath = PromptUserForSaveFile()
        File.WriteAllLines(saveFilePath, outputLines.ToArray())
        MsgBox("Cheat file converted successfully.")

        DisplayInvalidCodesMessage(invalidHexCodes)
    End Sub

    Private Sub ProcessLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        Select Case True
            Case line.StartsWith(";") : ProcessCommentLine(line, outputLines)
            Case line.StartsWith("AR 1") OrElse line.StartsWith("AR 0") : ProcessCodeLine(line, outputLines, invalidHexCodes)
            Case Else : ProcessHexCodeLine(line, outputLines, invalidHexCodes)
        End Select
    End Sub

    Private Sub ProcessCommentLine(line As String, outputLines As List(Of String))
        Dim hexCodesAndDescription = line.Substring(1).Trim().Split({","c, ";"c}, StringSplitOptions.RemoveEmptyEntries)
        Dim codeType = If(line.StartsWith(";AR 1 "), "CODE 1", "CAT") ' Determine code type
        Dim description = hexCodesAndDescription.Last().Trim() ' Trim potential extra spaces
        description = description & Environment.NewLine
        ' Add description to code type line
        outputLines.Add($"{codeType} {description}")
    End Sub

    Private Sub ProcessCodeLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        ' ... (code for processing code lines, including category handling)
        Dim description As String
        Dim hexCodes As String()
        ' Use a temporary variable to hold the tuple
        Dim result = ExtractDescriptionAndHexCodes(line)
        description = result.Description
        hexCodes = result.HexCodes
        Dim codeType = DetermineCodeType(line)
        outputLines.Add($"{codeType} {description}")
        ProcessHexCodes(hexCodes, outputLines, invalidHexCodes)
        outputLines.Add(Environment.NewLine)
    End Sub

    Private Sub ProcessHexCodeLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        ' ... (code for processing hex code lines)

    End Sub

    Private Function PromptUserForSaveFile() As String
        Dim outputLines As List(Of String) = New List(Of String)
        Dim saveFileDialog As New SaveFileDialog With {
            .Title = "Save Converted Cheat File",
            .Filter = "Cheat Files (*.MCH)|*.MCH",
            .InitialDirectory = "F:\Emulator's\ROMS\DS\Pokemon - HeartGold Version (U)"'This will be dynamic when project is finished
            }
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Return saveFileDialog.FileName ' Return the selected file path
        Else
            Return String.Empty ' Return an empty string if the user canceled
        End If
    End Function

    Private Sub DisplayInvalidCodesMessage(invalidHexCodes As List(Of String))
        ' Display a message about invalid codes (optional)
        If invalidHexCodes.Count > 0 Then
            MsgBox("The following hex codes were invalid: " & Environment.NewLine & String.Join(Environment.NewLine, invalidHexCodes))
        End If
    End Sub

    Private Function ExtractDescriptionAndHexCodes(line As String) As (Description As String, HexCodes As String())
        Dim descriptionStartIndex = line.IndexOf(";")
        If descriptionStartIndex >= 0 Then
            Dim description = line.Substring(descriptionStartIndex + 1).Trim()
            Dim hexCodesAndDescription = line.Substring(4, descriptionStartIndex - 4).Trim()
            Dim hexCodes = hexCodesAndDescription.Split({","c}, StringSplitOptions.RemoveEmptyEntries).ToArray()
            Return (description, hexCodes)
        End If
        Return ("", {}) ' Return empty values if description and hex codes are not found
    End Function

    Private Function DetermineCodeType(line As String) As String
        Return If(line.StartsWith("AR 1 "), "CODE 1", "CODE 0")
    End Function

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

    Private Function IsValidHexCode(hexCode As String) As Boolean
        Return hexCode.Replace(" ", "").All(Function(c) Char.IsDigit(c) OrElse Char.IsLetter(c))
    End Function

    Private Sub ProcessValidHexCode(hexCode As String, outputLines As List(Of String))
        Dim substringLength = If(hexCode.Length > 18, 18, 8)
        If hexCode.Length >= substringLength Then
            outputLines.Add(hexCode.Substring(0, substringLength) + " " + hexCode.Substring(substringLength))
        Else
            ' Handle the case where the string is too short (e.g., output the original hexCode or log a warning)
        End If
    End Sub


End Class