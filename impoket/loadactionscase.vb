Imports System.IO

Module loadactionscase
    Dim gastos, ingresos As Double
    Public Sub gastostotatles()
        Form1.ListBox1.Items.Clear()
        gastos = 0
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT CANTIDAD FROM GASTOS "
        Try
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    Form1.ListBox1.Items.Add(dr(0))
                End While
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim it As Integer
        If Form1.ListBox1.Items.Count > 0 Then
            Form1.ListBox1.SelectedIndex = 0
            it = 0
            While it < (Form1.ListBox1.Items.Count)
                Form1.ListBox1.SelectedIndex = it
                gastos += Form1.ListBox1.GetItemText(Form1.ListBox1.SelectedItem)
                it = it + 1
            End While
        End If
        Form1.Label7.Text = gastos
    End Sub
    Public Sub graficagastos()
        Form1.Chart2.Series("gastos").Points.Clear()
        Dim it As Integer
        If Form1.ListBox1.Items.Count > 0 Then
            Form1.ListBox1.SelectedIndex = 0
            it = 0
            While it < (Form1.ListBox1.Items.Count)
                Form1.ListBox1.SelectedIndex = it
                Form1.Chart2.Series("gastos").Points.AddY(Form1.ListBox1.GetItemText(Form1.ListBox1.SelectedItem))
                it = it + 1
            End While
        End If

    End Sub
    Public Sub ingresostotales()
        Form1.ListBox4.Items.Clear()
        Form1.ListBox2.Items.Clear()
        ingresos = 0
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT CANTIDAD, TIPO FROM INGRESOS "
        Try
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    Form1.ListBox2.Items.Add(dr(0))
                    Form1.ListBox4.Items.Add(dr(1))
                End While
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim it As Integer
        If Form1.ListBox2.Items.Count > 0 Then
            Form1.ListBox2.SelectedIndex = 0
            it = 0
            While it < (Form1.ListBox2.Items.Count)
                Form1.ListBox2.SelectedIndex = it
                ingresos += Form1.ListBox2.GetItemText(Form1.ListBox2.SelectedItem)
                it = it + 1
            End While
        End If
        Form1.Label17.Text = ingresos
    End Sub
    Public Sub graficaringresos()
        Form1.ListBox3.Items.Clear()
        Form1.Chart1.Series("ingresos").Points.Clear()
        ''Try
        ''Dim tiposdeintgreso As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt")
        ''    Do While Not tiposdeintgreso.EndOfStream
        ''        Form1.ListBox3.Items.Add(tiposdeintgreso.ReadLine)
        ''    Loop
        ''    FileClose()
        ''    tiposdeintgreso.Close()
        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try
        Dim it As Integer
        If Form1.ListBox2.Items.Count > 0 Then
            Form1.ListBox2.SelectedIndex = 0
            it = 0
            While it < (Form1.ListBox4.Items.Count)
                Form1.ListBox2.SelectedIndex = it
                Form1.Chart1.Series("ingresos").Points.AddY(Form1.ListBox2.GetItemText(Form1.ListBox2.SelectedItem))
                it = it + 1
            End While
        End If

        'Dim it2 As Integer
        'If Form1.ListBox4.Items.Count > 0 Then
        '    Form1.ListBox4.SelectedIndex = 0
        '    it2 = 0
        '    While it2 < (Form1.ListBox4.Items.Count)
        '        Form1.ListBox4.SelectedIndex = it2
        '        'Form1.Chart1.Series("ingresos").Points(it2).Label = (Form1.ListBox4.GetItemText(Form1.ListBox4.SelectedItem))
        '        it = it + 1
        '    End While
        'End If



        'Dim it, it2 As Integer
        'If Form1.ListBox4.Items.Count > 0 Then
        '    Form1.ListBox3.SelectedIndex = 0
        '    it = 0
        '    While it < (Form1.ListBox3.Items.Count)
        '        Form1.ListBox3.SelectedIndex = it
        '        ' MsgBox("3 tiene" & Form1.ListBox3.GetItemText(Form1.ListBox3.SelectedItem))****************************
        '        Form1.ListBox4.SelectedIndex = 0
        '        Form1.ListBox2.SelectedIndex = 0
        '        it2 = 0
        '        While it2 < (Form1.ListBox4.Items.Count)
        '            Form1.ListBox4.SelectedIndex = it2
        '            Form1.ListBox2.SelectedIndex = it2
        '            'MsgBox("4 tiene a" & Form1.ListBox4.GetItemText(Form1.ListBox4.SelectedItem))////////////////////////
        '            If ((Form1.ListBox3.GetItemText(Form1.ListBox3.SelectedItem)) = (Form1.ListBox4.GetItemText(Form1.ListBox4.SelectedItem))) Then
        '                'MsgBox("Iguales en" & Form1.ListBox4.GetItemText(Form1.ListBox4.SelectedItem))
        '                'MsgBox("El val es: " & (Form1.ListBox2.GetItemText(Form1.ListBox2.SelectedItem)))
        '                Form1.ListBox5.Items.Add(Form1.ListBox2.GetItemText(Form1.ListBox2.SelectedItem))
        '            End If
        '            it2 = it2 + 1
        '        End While
        '        it = it + 1
        '    End While
        'End If
        ''Form1.Chart1.Series("ingresos").Points.AddY(20)
        ''Form1.Chart1.Series("ingresos").Points(it).Label = (Form1.ListBox3.GetItemText(Form1.ListBox3.SelectedItem)).ToString
    End Sub
    Public Sub barrapresupusto()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select PRESUPUESTO FROM PRESUPUESTOS "
        Try
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    Form1.Label6.Text = dr(0)
                End While
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If Form1.Label6.Text <> 0 Then
            Form1.MetroProgressBar1.ProgressBarStyle = ProgressBarStyle.Continuous
            Dim avanzar As Integer = ((gastos * 100) / Form1.Label6.Text)
            'MsgBox(avanzar)
            Select Case avanzar
                Case 0 To 20
                    Form1.MetroProgressBar1.Value = avanzar
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Green
                    Form1.Label4.Text = "Presupuesto de gastos para este mes"
                Case 21 To 49
                    Form1.MetroProgressBar1.Value = avanzar
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Blue
                    Form1.Label4.Text = "Presupuesto de gastos para este mes"
                Case 50 To 84
                    Form1.MetroProgressBar1.Value = avanzar
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Yellow
                    Form1.Label4.Text = "Presupuesto de gastos para este mes"
                Case 85 To 100
                    Form1.MetroProgressBar1.Value = avanzar
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Red
                    Form1.Label4.Text = "Presupuesto de gastos para este mes"
                Case Else
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Red
                    Form1.MetroProgressBar1.Value = 100
                    Form1.Label4.Text = "Presupuesto Excedido!"
            End Select
            Form1.Refresh()
        End If
    End Sub
    Public Sub actualizar()
        gastostotatles()
        ingresostotales()
        graficaringresos()
        graficagastos()
        barrapresupusto()
        Dim dif As Double = ingresos - gastos
        If dif >= 0 Then
            Select Case dif
                Case 0
                    Form1.Label1.Text = "Estatus: Desconocido"
                    Form1.PictureBox1.Image = My.Resources.duda
                Case 1 To 200
                    Form1.Label1.Text = "Estatus: Riesgoso"
                    Form1.PictureBox1.Image = My.Resources.llorar
                Case 201 To 500
                    Form1.Label1.Text = "Estatus: Precaucion"
                    Form1.PictureBox1.Image = My.Resources.enojo
                Case 501 To 1500
                    Form1.Label1.Text = "Estatus: Esta bien"
                    Form1.PictureBox1.Image = My.Resources.isok
                Case 1501 To 3000
                    Form1.Label1.Text = "Estatus: De acuerdo"
                    Form1.PictureBox1.Image = My.Resources.bien
                Case 3001 To 7000
                    Form1.Label1.Text = "Estatus: Perfecto"
                    Form1.PictureBox1.Image = My.Resources.angtel
                Case Else
                    Form1.Label1.Text = "Estatus: Exelentemente bueno"
                    Form1.PictureBox1.Image = My.Resources.feliz
            End Select
        Else
            Form1.Label1.Text = "Estatus: Peligro"
            Form1.PictureBox1.Image = My.Resources.no
        End If
    End Sub
End Module
