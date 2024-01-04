Imports System.IO
Imports System.Text.RegularExpressions ' Add this import statement

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim invalidHexCodes As List(Of String) = New List(Of String)

        Try
            Dim openFileDialog As New OpenFileDialog With {
                .Title = "Select Cheat File",
                .Filter = "Cheat Files (*.DCT)|*.DCT",
                .InitialDirectory = "E:\Emulator's\DS\DeSmuMe\Cheats"'This will be dynamic when project is finished
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = openFileDialog.FileName
                Dim lines As String() = File.ReadAllLines(filePath).Skip(4).ToArray()

                Dim outputLines As List(Of String) = New List(Of String)
                For Each line As String In lines
                    If line.StartsWith(";") Then
                        Dim hexCodesAndDescription = line.Substring(1).Trim().Split({","c, ";"c}, StringSplitOptions.RemoveEmptyEntries)
                        Dim codeType = If(line.StartsWith(";AR 1 "), "CODE 1", "CAT") ' Determine code type
                        Dim description = hexCodesAndDescription.Last().Trim() ' Trim potential extra spaces
                        description = description & Environment.NewLine

                        ' Add description to code type line
                        outputLines.Add($"{codeType} {description}")
                    ElseIf line.StartsWith("AR 1") Or line.StartsWith("AR 0") Then
                        Dim hexCodesAndDescription = line.Substring(4).Trim().Split({","c, ";"c}, StringSplitOptions.RemoveEmptyEntries)
                        Dim hexCodes = hexCodesAndDescription.Take(hexCodesAndDescription.Length - 1).ToArray()
                        Dim codeType = If(line.StartsWith("AR 1 "), "CODE 1", "CODE 0") ' Determine code type
                        Dim description = hexCodesAndDescription.Last().Trim() ' Trim potential extra spaces

                        ' Output code type and description with proper spacing
                        outputLines.Add($"{codeType} {description}")

                        For Each hexCode As String In hexCodes
                            Try
                                ' Filter non-hexadecimal characters, allowing spaces within hex codes
                                If hexCode.Replace(" ", "").All(Function(c) Char.IsDigit(c) OrElse Char.IsLetter(c)) Then
                                    Dim substringLength = If(hexCode.Length > 18, 18, 8)
                                    outputLines.Add(hexCode.Substring(0, substringLength) + " " + hexCode.Substring(substringLength))
                                Else
                                    ' Handle invalid hex code case
                                    outputLines.Add(hexCode) ' Output the original hex code without marking it as invalid
                                    invalidHexCodes.Add(hexCode) ' Add the invalid code to the list
                                End If
                            Catch ex As Exception
                                outputLines.Add("Error processing hex code: " & ex.Message)
                            End Try
                        Next
                        ' Output the code description separately, ensuring a whole line Is output
                        'outputLines.Add(hexCodesAndDescription.Last()) '' lined removed so description is not shown twice
                        outputLines.Add(Environment.NewLine) ' Add a new line for better readability
                    Else
                        Dim hexCodes As String() = line.Split({","c, ";"c})
                        For Each hexCode As String In hexCodes
                            Try
                                ' Filter non-hexadecimal characters
                                If hexCode.All(Function(c) Char.IsDigit(c) OrElse Char.IsLetter(c)) Then
                                    outputLines.Add(hexCode.Substring(0, 8) + " " + hexCode.Substring(8))
                                Else
                                    ' Handle invalid hex code case
                                    outputLines.Add("Invalid hex code: " & hexCode)
                                    invalidHexCodes.Add(hexCode) ' Add the invalid code to the list
                                End If
                            Catch ex As Exception
                                outputLines.Add("Error processing hex code: " & ex.Message)
                            End Try
                        Next
                        outputLines.Add(Environment.NewLine)
                    End If
                Next
                Dim saveFileDialog As New SaveFileDialog With {
                .Title = "Save Converted Cheat File",
                .Filter = "Cheat Files (*.MCH)|*.MCH",
                .InitialDirectory = "e:\Emulator's\ROMS\DS\Pokemon - HeartGold Version (U)"'This will be dynamic when project is finished
            }

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    File.WriteAllLines(saveFileDialog.FileName, outputLines.ToArray())
                    MsgBox("Cheat file converted successfully.")

                    ' Display a message about invalid codes (optional)
                    If invalidHexCodes.Count > 0 Then
                        MsgBox("The following hex codes were invalid: " & Environment.NewLine & String.Join(Environment.NewLine, invalidHexCodes))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try


    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class