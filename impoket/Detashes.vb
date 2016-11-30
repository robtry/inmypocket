Imports System.ComponentModel
Public Class Detashes
    Private Sub Detashes_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub Detashes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case whereiam
            Case 1
                llenarlistingresos()
        End Select
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Form1.Show()
        ingtresocase()
        Me.Hide()
    End Sub
End Class