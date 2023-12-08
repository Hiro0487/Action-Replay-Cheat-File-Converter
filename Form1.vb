Imports System.IO

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
                        ' Add category name after code 0/1 with space and carriage return
                        outputLines.Add(String.Format("CODE {0}{1} ", line.Substring(2).Trim(), Environment.NewLine))
                    Else
                        ' Process hex codes until semicolon
                        Dim hexCodes As String() = line.Split(",")
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