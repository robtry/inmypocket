Imports System.ComponentModel
Imports System.IO
Imports MaterialSkin
Imports MetroFramework

Public Class Form1
    Public slidepanel As Integer
    Dim year As String
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim resultado As MsgBoxResult
        resultado = MetroMessageBox.Show(Me, "InMyPocket v1.0", "¿Seguro que deseas salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If resultado = MsgBoxResult.Yes Then
            End
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SkinManager.ColorScheme = New ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Green200, Accent.Red100, TextShade.WHITE)
        ConnectToAccess()
        'leer
        actualizar()
    End Sub
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        'leer
        actualizar()
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
        actualizar()
    End Sub
    Private Sub MaterialFlatButton9_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton9.Click
        actualizar()
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
                actualizar()
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
                actualizar()
            Case 2
                agregagastos()
                actualizar()
            Case 4
                If Label15.Text = "$" Then
                    Label11.Text = DateTime.Now
                End If
                agregatarjetas()
                actualizar()
        End Select
    End Sub
    '=============================================El enter=========================================================
    Private Sub MaterialSingleLineTextField1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaterialSingleLineTextField1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case whereiam
                Case 1
                    agregaingresos()
                    actualizar()
                Case 2
                    agregagastos()
                    actualizar()
                Case 3
                    cambiapresupuesto() 'update en la bd
                    actualizar()
                Case 4
                    If Label15.Text = "$" Then
                        Label11.Text = DateTime.Now
                    End If
                    agregatarjetas()
                    actualizar()
            End Select
        End If
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
    '===============================Ver todo====================================================================
    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click
        Detashes.Close()
        Detashes.Show()
        Me.Hide()
    End Sub
    '======================================Salir==========================================================================
    Private Sub MaterialRaisedButton8_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton8.Click
        Dim resultado As MsgBoxResult
        resultado = MetroMessageBox.Show(Me, "InMyPocket v1.0", "¿Seguro que deseas salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If resultado = MsgBoxResult.Yes Then
            End
        End If
    End Sub
    '==================================Errrror================================================
    Private Sub MetroComboBox1_Click(sender As Object, e As EventArgs) Handles MetroComboBox1.Click
        Me.ErrorProvider1.SetError(MetroComboBox1, Nothing)
    End Sub
    Private Sub MaterialSingleLineTextField1_Click(sender As Object, e As EventArgs) Handles MaterialSingleLineTextField1.Click
        Me.ErrorProvider1.SetError(MaterialSingleLineTextField1, Nothing)
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        MetroMessageBox.Show(Me, "Procura tener mas ingresos que gastos" + vbCr + "Manten el punto de equilibrio en tus finanzas" + vbCr + "Contempla Todos los movimientos financieros que debes hacer" + vbCr + "No compres por comprar, checa si es necesario", "Consejos Financieros en In My Pocket v1.0", MessageBoxButtons.OK, MessageBoxIcon.Question)

    End Sub
End Class
