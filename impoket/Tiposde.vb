Imports MaterialSkin
Public Class Tiposde
    Private Sub Tiposde_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form1.Show()
    End Sub
    Private Sub tiposde_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case whereiam
            Case 1 'ingreso
                actualizatipoingresos2()
            Case 2 'gasto
                actualizatipogastos2()
            Case 4 'tarjetas
                actualizatipotarjetas2()
        End Select
    End Sub
    '====================================Agregar================================================
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Select Case whereiam
            Case 1 'ingreso
                editatipodeingreso()
            Case 2 'gasto
                editatipodegastos()
            Case 4 'tarejtas
                editatipodetrarjetas()
        End Select
    End Sub
    Private Sub MaterialSingleLineTextField1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaterialSingleLineTextField1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case whereiam
                Case 1 'ingreso
                    editatipodeingreso()
                Case 2 'gasto
                    editatipodegastos()
                Case 4 'tarejtas
                    editatipodetrarjetas()
            End Select
        End If
    End Sub
    '=====================================Eliminar============================================
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Select Case whereiam
            Case 1 'ingreso
                eliminatipodeingreso()
            Case 2 'gtasto
                eliminatipodegasto()
            Case 4 'tarjetas
                eliminatipodetarjetas()
        End Select
    End Sub
    '====================================Regresar=============================================
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class