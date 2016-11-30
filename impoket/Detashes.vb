Imports System.ComponentModel
Public Class Detashes
    Private Sub Detashes_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
    End Sub
    Private Sub Detashes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("loafring")
        llenarlistingresos()
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Form1.Show()
        ingtresocase()
        Me.Close()
    End Sub
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        MsgBox(MaterialListView1.Items(0))
        MsgBox(ListBox1.SelectedIndex)
    End Sub
End Class