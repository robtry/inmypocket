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
    Public Sub tiposdegatos()

    End Sub
    Public Sub ingresostotales()
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
        Try
            Dim tiposdeintgreso As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + (Module1database.usertoconect) + "\tiposdeingreso.txt")
            Do While Not tiposdeintgreso.EndOfStream
                Form1.ListBox3.Items.Add(tiposdeintgreso.ReadLine)
            Loop
            FileClose()
            tiposdeintgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim it, it2 As Integer
        If Form1.ListBox3.Items.Count > 0 Then
            Form1.ListBox3.SelectedIndex = 0
            it = 0
            While it < (Form1.ListBox4.Items.Count)
                Form1.ListBox4.SelectedIndex = it
                If Form1.ListBox4.Items.Count > 0 Then
                    Form1.ListBox4.SelectedIndex = 0
                    it2 = 0
                    While it2 < (Form1.ListBox4.Items.Count)
                        If ((Form1.ListBox3.GetItemText(Form1.ListBox3.SelectedItem)) = (Form1.ListBox4.GetItemText(Form1.ListBox4.SelectedItem))) Then
                            MsgBox(Form1.ListBox4.GetItemText(Form1.ListBox4.SelectedItem))
                        End If
                        it2 = it2 + 1
                    End While
                End If

                Form1.Chart1.Series("ingresos").Points.AddY(20)
                'Form1.Chart1.Series("ingresos").Points(it).Label = (Form1.ListBox3.GetItemText(Form1.ListBox3.SelectedItem)).ToString
                it = it + 1
            End While
        End If
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
            Select Case avanzar
                Case 1 To 20
                    Form1.MetroProgressBar1.Value = avanzar
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Green
                    Form1.Label4.Text = "Presupuesto de gastos para este mes"
                Case 21 To 50
                    Form1.MetroProgressBar1.Value = avanzar
                    Form1.MetroProgressBar1.Style = MetroFramework.MetroColorStyle.Blue
                    Form1.Label4.Text = "Presupuesto de gastos para este mes"
                Case 51 To 85
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


        End If
    End Sub
End Module
