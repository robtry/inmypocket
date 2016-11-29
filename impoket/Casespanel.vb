Imports System.IO
Imports MaterialSkin
Module Casespanel
    Public whereiam As Integer
    Public dinero As Double = 0
    Dim y As Integer
    Public Sub depliegacases()
        Form1.MaterialRaisedButton1.Visible = False
        Form1.Panel2.Location = New Point(-98, 64)
        Form1.slidepanel = 1
        Form1.Timer2.Enabled = True
    End Sub
    Public Sub regresacase()
        Form1.Panel2.Location = New Point(-150, 64)
        Form1.slidepanel = 0
        Form1.MaterialRaisedButton1.Visible = True
        Form1.Timer2.Enabled = True
        Form1.Text = "           In My Pocket"
        Form1.SkinManager.ColorScheme = New ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Green200, Accent.Red100, TextShade.WHITE)
        Form1.Refresh()
    End Sub
    Public Sub regresaforce()
        Form1.Panel2.Location = New Point(-350, 64)
        Form1.Text = "           In My Pocket"
        Form1.SkinManager.ColorScheme = New ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Green200, Accent.Red100, TextShade.WHITE)
        Form1.Refresh()
    End Sub
    '=============================================Ingresos=============================================================
    Public Sub ingtresocase()
        limpiartodo()
        Try
            dinero = InputBox("Nuevo ingreso: ", "InMyPocket Ingresos", "0.00")
            'If Not Form1.Panel2.Location.X = 54 Then
            depliegacases()
            'End If
            Form1.Label16.Text = "Ingreso"
            Form1.Text = "           In My Pocket Ingresos"
            Form1.Label13.Text = "Tipo de Ingreso"
            Form1.Label14.Text = "Descripción"
            Form1.Label15.Text = "$" & dinero
            Form1.MaterialSingleLineTextField1.Hint = "Breve descripción del ingreso <op>"
            Form1.Label11.Text = DateTime.Now
            Form1.Panel3.BackColor = ColorTranslator.FromHtml("#43A047")
            Form1.MetroComboBox1.Style = MetroFramework.MetroColorStyle.Green
            Form1.MetroComboBox2.Style = MetroFramework.MetroColorStyle.Green
            Form1.Panel4.Show()
            Form1.MetroComboBox2.Show()
            Form1.MaterialRaisedButton7.Text = "Editar"
            Form1.SkinManager.ColorScheme = New ColorScheme(Primary.Green800, Primary.Green900, Primary.BlueGrey900, Accent.Indigo700, TextShade.WHITE)
            Form1.Refresh()
            whereiam = 1
            actualizatipoingresos()
            leertarjetas()
        Catch ex As Exception
            If ex.ToString.Contains("La conversión de la cadena") Then 'si puchas cancelar
                If Form1.Panel2.Location.X = 54 Then 'si se ve animalo
                    regresacase()
                Else 'si no mejor que ni salga
                    regresaforce()
                End If
            Else
                MsgBox(ex.Message)
                End If
        End Try
    End Sub
    Public Sub actualizatipoingresos()
        Form1.MetroComboBox1.Items.Clear()
        Try
            Dim tiposdeintgreso As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt")
            Do While Not tiposdeintgreso.EndOfStream
                Form1.MetroComboBox1.Items.Add(tiposdeintgreso.ReadLine)
            Loop
            FileClose()
            tiposdeintgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub actualizatipoingresos2() 'paraeleltiposde
        Tiposde.ListBox1.Items.Clear()
        Try
            Dim tiposdeintgreso As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt")
            Do While Not tiposdeintgreso.EndOfStream
                Tiposde.ListBox1.Items.Add(tiposdeintgreso.ReadLine)
            Loop
            FileClose()
            tiposdeintgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub editatipodeingreso()
        If Not Tiposde.MaterialSingleLineTextField1.Text = "" Or Tiposde.MaterialSingleLineTextField1.Text = " " Then
            My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt", Tiposde.MaterialSingleLineTextField1.Text & vbCrLf, True)
            Tiposde.ListBox1.Items.Add(Tiposde.MaterialSingleLineTextField1.Text)
            Tiposde.MaterialSingleLineTextField1.Clear()
        End If
        actualizatipoingresos()
    End Sub
    Public Sub eliminatipodeingreso()
        Tiposde.ListBox1.Items.Remove(Tiposde.ListBox1.SelectedItem)
        Kill(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt")
        Dim sw As New System.IO.StreamWriter(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt")
        sw.Close()
        If Tiposde.ListBox1.Items.Count > 0 Then
            Tiposde.ListBox1.SelectedIndex = 0
            y = 0
            While y < (Tiposde.ListBox1.Items.Count)
                Tiposde.ListBox1.SelectedIndex = y
                My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt", Tiposde.ListBox1.GetItemText(Tiposde.ListBox1.SelectedItem) + vbCrLf, True)
                y = y + 1
            End While
        End If
        actualizatipoingresos()
    End Sub
    '=====================================Gastos=========================================================================================
    Public Sub gastoscase()
        limpiartodo()
        Try
            dinero = InputBox("Nuevo Gasto: ", "InMyPocket Gastos", "0.00")
            depliegacases()
            Form1.Label16.Text = "Gastos"
            Form1.Text = "           In My Pocket Gastos"
            Form1.Label13.Text = "Tipo de Gastos"
            Form1.Label14.Text = "Descripción"
            Form1.Label15.Text = "$" & dinero
            Form1.MaterialSingleLineTextField1.Hint = "Breve descripción del gasto"
            Form1.Label11.Text = DateTime.Now
            Form1.Panel3.BackColor = ColorTranslator.FromHtml("#E64A19")
            Form1.MetroComboBox1.Style = MetroFramework.MetroColorStyle.Orange
            Form1.MetroComboBox2.Style = MetroFramework.MetroColorStyle.Orange
            Form1.Panel4.Show()
            Form1.MetroComboBox2.Show()
            Form1.MaterialRaisedButton7.Text = "Editar"
            Form1.SkinManager.ColorScheme = New ColorScheme(Primary.DeepOrange800, Primary.DeepOrange900, Primary.BlueGrey900, Accent.Indigo700, TextShade.WHITE)
            Form1.Refresh()
            whereiam = 2
            actualizatipogastos()
        Catch ex As Exception
            If ex.ToString.Contains("La conversión de la cadena") Then 'si puchas cancelar
                If Form1.Panel2.Location.X = 54 Then 'si se ve animalo
                    regresacase()
                Else 'si no mejor que ni salga
                    regresaforce()
                End If
            Else
                MsgBox(ex.Message)
            End If
        End Try

    End Sub
    Public Sub actualizatipogastos()
        Form1.MetroComboBox1.Items.Clear()
        Try
            Dim tiposdeintgreso As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdegasto.txt")
            Do While Not tiposdeintgreso.EndOfStream
                Form1.MetroComboBox1.Items.Add(tiposdeintgreso.ReadLine)
            Loop
            FileClose()
            tiposdeintgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub actualizatipogastos2() 'para el tipos de
        Tiposde.ListBox1.Items.Clear()
        Try
            Dim tiposdegasto As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdegasto.txt")
            Do While Not tiposdegasto.EndOfStream
                Tiposde.ListBox1.Items.Add(tiposdegasto.ReadLine)
            Loop
            FileClose()
            tiposdegasto.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub editatipodegastos()
        If Not Tiposde.MaterialSingleLineTextField1.Text = "" Or Tiposde.MaterialSingleLineTextField1.Text = " " Then
            My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdegasto.txt", Tiposde.MaterialSingleLineTextField1.Text & vbCrLf, True)
            Tiposde.ListBox1.Items.Add(Tiposde.MaterialSingleLineTextField1.Text)
            Tiposde.MaterialSingleLineTextField1.Clear()
        End If
        actualizatipogastos()
    End Sub
    Public Sub eliminatipodegasto()
        Tiposde.ListBox1.Items.Remove(Tiposde.ListBox1.SelectedItem)
        Kill(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdegasto.txt")
        Dim sw As New System.IO.StreamWriter(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdegasto.txt")
        sw.Close()
        If Tiposde.ListBox1.Items.Count > 0 Then
            Tiposde.ListBox1.SelectedIndex = 0
            y = 0
            While y < (Tiposde.ListBox1.Items.Count)
                Tiposde.ListBox1.SelectedIndex = y
                My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdegasto.txt", Tiposde.ListBox1.GetItemText(Tiposde.ListBox1.SelectedItem) + vbCrLf, True)
                y = y + 1
            End While
        End If
        actualizatipogastos()
    End Sub
    '=============================================Presupuesto=====================================================================
    Public Sub presupuestocase()
        limpiartodo()
        depliegacases()
        Form1.Text = "           In My Pocket Presupuesto"
        Form1.Label14.Text = "Nuevo"
        Form1.Label16.Text = "Presupuesto"
        Form1.Label15.Text = "Presupuesto actual: " ' cambir en el limpuiartodo()
        Form1.Label13.Text = DateTime.Now
        Form1.MaterialSingleLineTextField1.Hint = "123456"
        Form1.Panel3.BackColor = ColorTranslator.FromHtml("#E91E63")
        Form1.Panel4.Hide()
        Form1.MaterialRaisedButton7.Text = "Fijar"
        Form1.SkinManager.ColorScheme = New ColorScheme(Primary.Pink700, Primary.Pink900, Primary.BlueGrey900, Accent.Indigo700, TextShade.WHITE)
        Form1.Refresh()
        whereiam = 3
        actualizapresupuesto()
    End Sub
    Public Sub actualizapresupuesto()
        'read en acces
    End Sub
    Public Sub cambiapresupuesto()
        If IsNumeric(Form1.MaterialSingleLineTextField1.Text) Then
            'update en accews
        End If
    End Sub
    '===============================================tarjetas=========================================================================
    Public Sub tarjetacase()
        limpiartodo()
        depliegacases()
        Form1.Text = "           In My Pocket Tarjetas"
        Form1.Label14.Text = "Nombre: "
        Form1.Label16.Text = "Tarjetas"
        Form1.Label13.Text = "Tipo de Tarjeta"
        Form1.MaterialRaisedButton7.Text = "Editar"
        Form1.Label11.Text = DateTime.Now
        Form1.Label15.Text = "$"
        Form1.Label12.Text = ""
        Form1.MaterialSingleLineTextField1.Hint = "Breve descripción de la tarjeta"
        Form1.Panel3.BackColor = ColorTranslator.FromHtml("#5E35B1")
        Form1.MetroComboBox1.Style = MetroFramework.MetroColorStyle.Purple
        Form1.Panel4.Show()
        Form1.MetroComboBox2.Hide()
        Form1.SkinManager.ColorScheme = New ColorScheme(Primary.DeepPurple600, Primary.DeepPurple900, Primary.BlueGrey900, Accent.Indigo700, TextShade.WHITE)
        Form1.Refresh()
        whereiam = 4
        actualizatipostarjetas()
    End Sub
    Public Sub actualizatipostarjetas()
        Form1.MetroComboBox1.Items.Clear()
        Try
            Dim tiposdetarjeta As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdetarjeta.txt")
            Do While Not tiposdetarjeta.EndOfStream
                Form1.MetroComboBox1.Items.Add(tiposdetarjeta.ReadLine)
            Loop
            FileClose()
            tiposdetarjeta.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub actualizatipotarjetas2() 'para el tipos de
        Tiposde.ListBox1.Items.Clear()
        Try
            Dim tiposdetarjeta As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdetarjeta.txt")
            Do While Not tiposdetarjeta.EndOfStream
                Tiposde.ListBox1.Items.Add(tiposdetarjeta.ReadLine)
            Loop
            FileClose()
            tiposdetarjeta.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub editatipodetrarjetas()
        If Not Tiposde.MaterialSingleLineTextField1.Text = "" Or Tiposde.MaterialSingleLineTextField1.Text = " " Then
            My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdetarjeta.txt", Tiposde.MaterialSingleLineTextField1.Text & vbCrLf, True)
            Tiposde.ListBox1.Items.Add(Tiposde.MaterialSingleLineTextField1.Text)
            Tiposde.MaterialSingleLineTextField1.Clear()
        End If
        actualizatipostarjetas()
    End Sub
    Public Sub eliminatipodetarjetas()
        Tiposde.ListBox1.Items.Remove(Tiposde.ListBox1.SelectedItem)
        Kill(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdetarjeta.txt")
        Dim sw As New System.IO.StreamWriter(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdetarjeta.txt")
        sw.Close()
        If Tiposde.ListBox1.Items.Count > 0 Then
            Tiposde.ListBox1.SelectedIndex = 0
            y = 0
            While y < (Tiposde.ListBox1.Items.Count)
                Tiposde.ListBox1.SelectedIndex = y
                My.Computer.FileSystem.WriteAllText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdetarjeta.txt", Tiposde.ListBox1.GetItemText(Tiposde.ListBox1.SelectedItem) + vbCrLf, True)
                y = y + 1
            End While
        End If
        actualizatipostarjetas()
    End Sub
    'Limpiatodo========================================================================================/////////////////////////////////////
    Public Sub limpiartodo()
        Form1.Label11.Text = ""
        Form1.Label15.Text = "$"
        Form1.MaterialSingleLineTextField1.Clear()
        Form1.MetroComboBox1.SelectedIndex = -1
        Form1.MetroComboBox2.SelectedIndex = -1
        Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, Nothing)
    End Sub
End Module
