Imports MaterialSkin
Imports MetroFramework
Public Class Login
    Dim i As Integer = 0
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usuariosiniciar()
        'MsgBox(MetroComboBox1.Items.Count)
        If MetroComboBox1.Items.Count = 0 Then
            'MetroMessageBox.Show(Me, "Debes crear almenos uno", "No hay usuarios registrados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTabControl1.SelectedIndex = 1
        Else
            MetroTabControl1.SelectedIndex = 0
        End If
    End Sub
    '========================================Iniciar==================================================
    Private Sub MetroComboBox1_Click(sender As Object, e As EventArgs)
        usuariosiniciar()
    End Sub
    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs)
        If Not MetroComboBox1.Text = "" Then
            ConnectToAccessTry()
        End If
    End Sub
    '==================================Crear Usuario===================================================
    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs)
        If Not MaterialSingleLineTextField1.Text = "" Then
            If Not System.IO.Directory.Exists(CurDir() & "\basededatos\users\" & MaterialSingleLineTextField1.Text) Then
                Try
                    System.IO.Directory.CreateDirectory(CurDir() & "\basededatos\users\" & MaterialSingleLineTextField1.Text)
                    System.IO.File.Copy(CurDir() + "\basededatos\Limpia.accdb", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\plantilla.accdb", True)
                    System.IO.File.Copy(CurDir() + "\basededatos\tiposdeingresos.txt", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\tiposdeingreso.txt", True)
                    System.IO.File.Copy(CurDir() + "\basededatos\tiposdegastos.txt", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\tiposdegasto.txt", True)
                    System.IO.File.Copy(CurDir() + "\basededatos\tiposdetarjetas.txt", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\tiposdetarjeta.txt", True)
                    System.IO.File.Copy(CurDir() + "\basededatos\avatar.dll", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\avatar.dll", True)
                    My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users.txt", MaterialSingleLineTextField1.Text & vbCrLf, True)
                    MetroMessageBox.Show(Me, "", "Usuario creado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    MaterialSingleLineTextField1.Clear()
                Catch ex As Exception
                    If ex.ToString.Contains("Caracteres no válidos") Then
                        MetroMessageBox.Show(Me, "El nombre de usuario no puede contener caracteres especiales", "Error al crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Else
                        MsgBox(ex.Message)
                        MetroMessageBox.Show(Me, "Intentalo de nuevo", "Error al crear el usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End Try
            Else
                MetroMessageBox.Show(Me, "Elije otro nombre", "¡El usuario '" & MaterialSingleLineTextField1.Text & "' ya existe!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub MaterialSingleLineTextField1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Not MaterialSingleLineTextField1.Text = "" Then
                If Not System.IO.Directory.Exists(CurDir() & "\basededatos\users\" & MaterialSingleLineTextField1.Text) Then
                    Try
                        System.IO.Directory.CreateDirectory(CurDir() & "\basededatos\users\" & MaterialSingleLineTextField1.Text)
                        System.IO.File.Copy(CurDir() + "\basededatos\Limpia.accdb", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\plantilla.accdb", True)
                        System.IO.File.Copy(CurDir() + "\basededatos\tiposdeingresos.txt", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\tiposdeingreso.txt", True)
                        System.IO.File.Copy(CurDir() + "\basededatos\tiposdegastos.txt", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\tiposdegasto.txt", True)
                        System.IO.File.Copy(CurDir() + "\basededatos\tiposdetarjetas.txt", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\tiposdetarjeta.txt", True)
                        System.IO.File.Copy(CurDir() + "\basededatos\avatar.dll", CurDir() + "\basededatos\users\" + MaterialSingleLineTextField1.Text + "\avatar.dll", True)
                        My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users.txt", MaterialSingleLineTextField1.Text & vbCrLf, True)
                        MetroMessageBox.Show(Me, "", "Usuario creado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        MaterialSingleLineTextField1.Clear()
                    Catch ex As Exception
                        If ex.ToString.Contains("Caracteres no válidos") Then
                            MetroMessageBox.Show(Me, "El nombre de usuario no puede contener caracteres especiales", "Error al crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Else
                            MsgBox(ex.Message)
                            MetroMessageBox.Show(Me, "Intentalo de nuevo", "Error al crear el usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End Try
                Else
                    MetroMessageBox.Show(Me, "Elije otro nombre", "¡El usuario '" & MaterialSingleLineTextField1.Text & "' ya existe!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    '====================================Eliminar=============================================================
    Private Sub MetroComboBox2_Click(sender As Object, e As EventArgs) Handles MetroComboBox2.Click
        usuarioseliminar()
    End Sub
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Dim resultado As MsgBoxResult
        If Not MetroComboBox2.Text = "" Then
            Try
                resultado = MetroMessageBox.Show(Me, "¿Seguro que desea eliminar?", "Se eliminará: " + MetroComboBox2.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resultado = MsgBoxResult.Yes Then
                    'Kill(CurDir() + "\basededatos\users\" + MetroComboBox2.Text + ".accdb")
                    My.Computer.FileSystem.DeleteDirectory(CurDir() + "\basededatos\users\" + MetroComboBox2.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    MetroComboBox2.Items.Remove(MetroComboBox2.SelectedItem)
                    Kill(CurDir() + "\basededatos\users.txt")
                    Dim sw As New System.IO.StreamWriter(CurDir() + "\basededatos\users.txt")
                    sw.Close()
                    If MetroComboBox2.Items.Count > 0 Then
                        MetroComboBox2.SelectedIndex = 0
                        i = 0
                        While i < (MetroComboBox2.Items.Count)
                            MetroComboBox2.SelectedIndex = i
                            My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users.txt", MetroComboBox2.GetItemText(MetroComboBox2.SelectedItem) + vbCrLf, True)
                            i = i + 1
                        End While
                    End If
                    MetroMessageBox.Show(Me, "", "Usuario borrado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    usuariosiniciar()
                    usuarioseliminar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    '=============================================Recursos==================================================
    Private Sub MaterialRaisedButton5_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton5.Click
        Dim resultado As MsgBoxResult
        Try
            resultado = MetroMessageBox.Show(Me, "No podrás recuperarlos ¿Estas seguro?", "Todos los usuarios se eliminaran", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If resultado = MsgBoxResult.Yes Then
                'Kill(CurDir() + "\basededatos\users\*.*")
                My.Computer.FileSystem.DeleteDirectory(CurDir() + "\basededatos\users", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Kill(CurDir() + "\basededatos\users.txt")
                Dim sw As New System.IO.StreamWriter(CurDir() + "\basededatos\users.txt")
                sw.Close()
                'System.IO.Directory.CreateDirectory(CurDir() & "\basededatos\users\")
                MetroMessageBox.Show(Me, "Ya no hay ningún usuario registrado", "Limpiado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Question)
            End If
        Catch ex As Exception
            If ex.ToString.Contains("No se pudo encontrar el directorio") Then
                MetroMessageBox.Show(Me, "Puedes crear nuevos usuarios", "Ya no hay ningun usuario", MessageBoxButtons.OK, MessageBoxIcon.Question)
                MetroTabControl1.SelectedIndex = 1
                MaterialSingleLineTextField1.Select()
            ElseIf ex.ToString.Contains("El directorio no está v") Then
                MetroMessageBox.Show(Me, "Intentalo de nuevo", "Cerrando archivos...", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MsgBox(ex.Message)
            End If
        End Try
        usuariosiniciar()
        usuarioseliminar()
    End Sub
    Private Sub MaterialRaisedButton4_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton4.Click
        Try
            System.Diagnostics.Process.Start(CurDir() & "\instaladores\AccessDatabaseEngine.exe")
        Catch ex As Exception
            If ex.ToString.Contains("El usuario ha cancelado la op") Then
                MetroMessageBox.Show(Me, "Intentalo de nuevo" & vbCr & "No podras disfrutar de InMyPocket", "¡Debes instalarlo!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
    '=================================Salir============================================
    Private Sub MetroTabControl1_Click(sender As Object, e As EventArgs) Handles MetroTabControl1.Click
        If MetroTabControl1.SelectedIndex = 5 Then
            End
        End If
    End Sub

    Private Sub MaterialRaisedButton3_Click_1(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click

    End Sub
End Class