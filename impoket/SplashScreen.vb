Public Class SplashScreen
    Dim i As Integer = 20
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usuariosiniciar()
        If Not Login.MetroComboBox1.Items.Count = 0 Then
            Login.Show()
            Me.Close()
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Timer1.Enabled = False
        Login.Show()
        Me.Close()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MetroProgressBar1.Value = i
        i += 1
        If i = 100 Then
            Timer1.Enabled = False
            Login.Show()
            Me.Close()
        End If
    End Sub
End Class