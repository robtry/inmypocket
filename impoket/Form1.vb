Imports MaterialSkin
Public Class Form1
    Public slidepanel As Integer
    Dim year As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SkinManager.ColorScheme = New ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Green200, Accent.Red100, TextShade.WHITE)
        ConnectToAccess()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label10.Text = DateTime.Now
    End Sub
    '==========================slide del menus===============================================
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click 'menu>>>>>>>>>>>>>>>>
        Panel1.Location = New Point(-190, 64)
        Do Until Panel1.Location.X = -13
            Panel1.Location = New Point(Panel1.Location.X + 1, 64)
        Loop
        Do Until Panel1.Location.X = 1
            Panel1.Location = New Point(Panel1.Location.X + 1, 64)
            Refresh()
            System.Threading.Thread.Sleep(5)
        Loop
    End Sub
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click 'menu>>>>>>>>>>
        Panel1.Location = New Point(-190, 64)
        Do Until Panel1.Location.X = -13
            Panel1.Location = New Point(Panel1.Location.X + 1, 64)
        Loop
        Do Until Panel1.Location.X = 1
            Panel1.Location = New Point(Panel1.Location.X + 1, 64)
            Refresh()
            System.Threading.Thread.Sleep(5)
        Loop
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click 'menu<<<<<<<<<<<<<<<<<<<<<<
        Panel1.Location = New Point(10, 64)
        Do Until Panel1.Location.X = -130
            Panel1.Location = New Point(Panel1.Location.X - 1, 64)
        Loop
        Do Until Panel1.Location.X = -150
            Panel1.Location = New Point(Panel1.Location.X - 1, 64)
            Refresh()
            System.Threading.Thread.Sleep(1)
        Loop
    End Sub
    '===========================================slide de todo el panel===========================================================
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If slidepanel = 0 Then
            Panel2.Location = New Point(Panel2.Location.X - 8, 64)
            If Panel2.Location.X = -350 Then
                Timer2.Enabled = False
            End If
        Else
            Panel2.Location = New Point(Panel2.Location.X + 8, 64)
            If Panel2.Location.X = 54 Then
                Timer2.Enabled = False
            End If
        End If
        Refresh()
    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        regresacase()
    End Sub
    '=====================================Ingreso========================================================================
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ingtresocase()
    End Sub
    Private Sub MaterialFlatButton2_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton2.Click
        ingtresocase()
    End Sub
    '===========================================Gasto===================================================================
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        gastoscase()
    End Sub
    Private Sub MaterialFlatButton4_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton4.Click
        gastoscase()
    End Sub
    '=======================================Presupuesto==============================================================
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        presupuestocase()
    End Sub
    Private Sub MaterialFlatButton5_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton5.Click
        presupuestocase()
    End Sub
    '=========================================Tarjeta==================================================================
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        tarjetacase()
    End Sub
    Private Sub MaterialFlatButton6_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton6.Click
        tarjetacase()
    End Sub
    '=================================Graficar==================================================================================
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub
    Private Sub MaterialFlatButton9_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton9.Click

    End Sub
    '=====================================Limpiar====================================================================
    Private Sub MaterialRaisedButton4_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton4.Click
        limpiartodo()
    End Sub
    '========================================Editar=====================================================================
    Private Sub MaterialRaisedButton7_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton7.Click
        Select Case whereiam
            Case 3
                cambiapresupuesto() 'update en la bd
            Case Else
                Tiposde.Show()
                Me.Hide()
        End Select
    End Sub
    '==============================================Agregar==============================================================
    Private Sub MaterialRaisedButton6_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton6.Click
        Select Case whereiam
            Case 1
                agregaingresos()
            Case 4
                agregatarjetas()
        End Select
    End Sub
    '====================================Nuevo====================================================================
    Private Sub MaterialRaisedButton5_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton5.Click
        limpiartodo()
        Me.ErrorProvider1.SetError(MetroComboBox1, Nothing)
        Me.ErrorProvider1.SetError(Label15, Nothing)
        Select Case whereiam
            Case 1
                ingtresocase()
            Case 2
                gastoscase()
            Case 4
                tarjetacase()
        End Select
    End Sub
    '======================================Salir==========================================================================
    Private Sub MaterialRaisedButton8_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton8.Click
        End
    End Sub
    '==================================Errrror================================================
    Private Sub MetroComboBox1_Click(sender As Object, e As EventArgs) Handles MetroComboBox1.Click
        Me.ErrorProvider1.SetError(MetroComboBox1, Nothing)
    End Sub
    Private Sub MaterialSingleLineTextField1_Click(sender As Object, e As EventArgs) Handles MaterialSingleLineTextField1.Click
        Me.ErrorProvider1.SetError(Label15, Nothing)
    End Sub
End Class
