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

    Private Function PromptUserForFile() As String
        Dim openFileDialog As New OpenFileDialog With {
            .Title = "Select Cheat File",
            .Filter = "Cheat Files (*.DCT)|*.DCT",
            .InitialDirectory = "E:\Emulator's\DS\DeSmuMe\Cheats"'This will be dynamic when project is finished
        }
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Return filePath ' Return the selected file path
        Else
            Return String.Empty ' Return an empty string if the user canceled
        End If
    End Function

    Private Function PromptUserForSaveFile() As String
        Dim outputLines As List(Of String) = New List(Of String)
        Dim saveFileDialog As New SaveFileDialog With {
            .Title = "Save Converted Cheat File",
            .Filter = "Cheat Files (*.MCH)|*.MCH",
            .InitialDirectory = "e:\Emulator's\ROMS\DS\Pokemon - HeartGold Version (U)"'This will be dynamic when project is finished
            }
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Return saveFileDialog.FileName ' Return the selected file path
        Else
            Return String.Empty ' Return an empty string if the user canceled
        End If
    End Function

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
        Dim descriptionStartIndex = line.IndexOf(";") ' Find the start of the description
        If descriptionStartIndex >= 0 Then
            Dim hexCodesAndDescription = line.Substring(4, descriptionStartIndex - 4).Trim() ' Extract part before description
            Dim hexCodes = hexCodesAndDescription.Split({","c}, StringSplitOptions.RemoveEmptyEntries).ToArray() ' Split hex codes
            Dim codeType = If(line.StartsWith("AR 1 "), "CODE 1", "CODE 0") ' Determine code type
            Dim description = line.Substring(descriptionStartIndex + 1).Trim() ' Start after the ";"
            outputLines.Add($"{codeType} {description}")
            For Each hexCode As String In hexCodes
                Try
                    ' Filter non-hexadecimal characters, allowing spaces within hex codes
                    If hexCode.Replace(" ", "").All(Function(c) Char.IsDigit(c) OrElse Char.IsLetter(c)) Then
                        Dim substringLength = If(hexCode.Length > 18, 18, 8)
                        If hexCode.Length >= substringLength Then
                            outputLines.Add(hexCode.Substring(0, substringLength) + " " + hexCode.Substring(substringLength))
                        Else
                            ' Handle the case where the string is too short (e.g., output the original hexCode or log a warning)
                        End If
                    Else
                        ' Handle invalid hex code case
                        outputLines.Add(hexCode) ' Output the original hex code without marking it as invalid
                        invalidHexCodes.Add(hexCode) ' Add the invalid code to the list
                    End If
                Catch ex As Exception
                    outputLines.Add("Error processing hex code: " & ex.Message)
                End Try
            Next
            ' Output code type and description with proper spacing


        End If
        ' Output the code description separately, ensuring a whole line Is output
        'outputLines.Add(hexCodesAndDescription.Last()) '' lined removed so description is not shown twice
        outputLines.Add(Environment.NewLine) ' Add a new line for better readability
    End Sub

    Private Sub ProcessHexCodeLine(line As String, outputLines As List(Of String), invalidHexCodes As List(Of String))
        ' ... (code for processing hex code lines)

    End Sub

    Private Sub DisplayInvalidCodesMessage(invalidHexCodes As List(Of String))
        ' Display a message about invalid codes (optional)
        If invalidHexCodes.Count > 0 Then
            MsgBox("The following hex codes were invalid: " & Environment.NewLine & String.Join(Environment.NewLine, invalidHexCodes))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class