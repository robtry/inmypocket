Imports System.ComponentModel
Public Class Detashes
    Private Sub Detashes_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
    End Sub
    Private Sub Detashes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MsgBox("loafring")
        Select Case whereiam
            Case 1
                llenarlistingresos()
            Case 2
                llenarlistgastos()
            Case 4
                llenarlisttarjeta()
        End Select
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Form1.Show()
        Select Case whereiam
            Case 1
                ingtresocase()
            Case 2
                gastoscase()
            Case 4
                tarjetacase()
        End Select
        Me.Close()
    End Sub
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Select Case whereiam
            Case 1
                delingreso()
            Case 2
                delgasto()
            Case 4
                deltarjeta()
        End Select
    End Sub
End Class