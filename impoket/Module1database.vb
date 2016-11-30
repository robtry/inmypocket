Imports System.IO
Imports MetroFramework
Module Module1database
    Dim ao As Integer
    Dim mesdvd As String
    Public usertoconect As String
    'se crea la variable de conexion de datos
    Public conn As New System.Data.OleDb.OleDbConnection()
    Public cmd As New OleDb.OleDbCommand
    Public dr As OleDb.OleDbDataReader
    Public sql As String = ""
    Public Sub ConnectToAccess()
        Dim userubication As String = Login.MetroComboBox1.Text
        usertoconect = userubication
        Dim boy1 As String
        Try
            Dim avatar As StreamReader = File.OpenText(CurDir() + "\basededatos\users\" + usertoconect + "\avatar.dll")
            boy1 = avatar.ReadToEnd
            Form1.PictureBox10.Image = My.Resources.boy1
            FileClose()
            avatar.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' TODO: Modify the connection string and include any
        ' additional required properties for your database.
        'conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & CurDir() + "\basededatos\users\asq\noviembre2016.accdb"
        'conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" & CurDir() + "\basededatos\users\hi\noviembre2016.accdb"
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" & CurDir() + "\basededatos\users\" + userubication + "\" & mesdvd & ao & ".accdb"
        'se crea en bin debug re requiere de un archivo de instalacion
        Try
            conn.Open()
            ' Insert code to process data.
            ' MsgBox("Conectado con exito")
            Login.Close()
            Form1.Label5.Text = "Mes: " & mesdvd
            Form1.Label9.Text = "Año: " & ao
            Form1.Label8.Text = "Bienvenido: " & userubication
        Catch ex As Exception
            ' MessageBox.Show("Failed to connect to data source")
            MsgBox(ex.Message)
            MsgBox("Cerrado por la fuerza")
            End
            'Finally
            '    conn.Close()
        End Try
    End Sub
    Public Sub ConnectToAccessTry()
        Dim userubicationforty As String = Login.MetroComboBox1.Text
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" & CurDir() + "\basededatos\users\" + userubicationforty + "\plantilla.accdb"
        'se crea en bin debug re requiere de un archivo de instalacion
        Try
            conn.Open()
            ' Insert code to process data.
            'MsgBox("Si funcionaria")
            conn.Close()
            ao = DateTime.Now.Year.ToString
            Select Case DateTime.Now.Month.ToString
                Case 1
                    mesdvd = "enero"
                Case 2
                    mesdvd = "febrero"
                Case 3
                    mesdvd = "marzo"
                Case 4
                    mesdvd = "abril"
                Case 5
                    mesdvd = "mayo"
                Case 6
                    mesdvd = "junio"
                Case 7
                    mesdvd = "julio"
                Case 8
                    mesdvd = "agosto"
                Case 9
                    mesdvd = "septiembre"
                Case 10
                    mesdvd = "octubre"
                Case 11
                    mesdvd = "noviembre"
                Case 12
                    mesdvd = "diciembre"
            End Select
            If Not System.IO.File.Exists(CurDir() + "\basededatos\users\" + userubicationforty + "\" & mesdvd & ao & ".accdb") Then
                System.IO.File.Copy(CurDir() + "\basededatos\users\" + userubicationforty + "\plantilla.accdb", CurDir() + "\basededatos\users\" + userubicationforty + "\" & mesdvd & ao & ".accdb", True)
            End If
            Form1.Show()
        Catch ex As Exception
            If ex.ToString.Contains("El proveedor 'Microsoft.ACE.OLEDB.12.") Then
                MetroMessageBox.Show(Login, "Disponible en recursos" + vbCr + "Error 1xx0x69", "Debes instalar AccessDatabaseEngine", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Login.MetroTabControl1.SelectedIndex = 3
            Else
                MsgBox(ex.Message)
            End If
            'Finally
            'conn.Close()
        End Try
    End Sub
    '===========================================Ingresos======================================================
    Public Sub agregaingresos()
        'Dim identificacion As String
        Dim descripcion, fechaexacta, tarjetaasociada, howmanymony, tipo As String
        fechaexacta = Form1.Label11.Text.ToString
        descripcion = Form1.MaterialSingleLineTextField1.Text
        tarjetaasociada = Form1.MetroComboBox2.Text
        howmanymony = Form1.Label15.Text
        tipo = Form1.MetroComboBox1.Text
        If howmanymony <> "$" Then
            If tipo <> "" Then
                Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, Nothing)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conn
                sql = "INSERT INTO INGRESOS(CANTIDAD, DESCRIPCION, TIPO, ASOCIADO, AGREGADO) "
                sql += "VALUES('" & howmanymony & "','" & descripcion & "','" & tipo & "','" & tarjetaasociada & "','" & fechaexacta & "')"
                'sql += "'" & tipo & "')"
                ' MsgBox(sql)
                cmd.CommandText = sql
                Try
                    'insertar
                    cmd.ExecuteNonQuery()
                    MsgBox("Insertado correctamente")
                    limpiartodo()
                Catch ex As Exception
                    If ex.ToString.Contains("No coinciden los tipos de datos en la expresi") Then
                        ingtresocase()
                    ElseIf ex.ToString.Contains("valores duplicados") Then
                        MsgBox("ya esta el regtistro")
                    Else
                        MsgBox(ex.Message)
                    End If
                End Try
            Else
                Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, "Debes elegir un tipo")
            End If
        Else
            Form1.ErrorProvider1.SetError(Form1.Label15, "Da clic a nuevo")
        End If
    End Sub
    '===============================================Gastos============================================================
    Public Sub agregagastos()
        'Dim identificacion As String
        Dim descripcion, fechaexacta, tarjetaasociada, howmanymony, tipo As String
        fechaexacta = Form1.Label11.Text.ToString
        descripcion = Form1.MaterialSingleLineTextField1.Text
        tarjetaasociada = Form1.MetroComboBox2.Text
        howmanymony = Form1.Label15.Text
        tipo = Form1.MetroComboBox1.Text
        If howmanymony <> "$" Then
            If tipo <> "" Then
                Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, Nothing)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conn
                sql = "INSERT INTO GASTOS(CANTIDAD, DESCRIPCION, TIPO, ASOCIADO, AGREGADO) "
                sql += "VALUES('" & howmanymony & "','" & descripcion & "','" & tipo & "','" & tarjetaasociada & "','" & fechaexacta & "')"
                'sql += "'" & tipo & "')"
                ' MsgBox(sql)
                cmd.CommandText = sql
                Try
                    'insertar
                    cmd.ExecuteNonQuery()
                    MsgBox("Insertado correctamente")
                    limpiartodo()
                Catch ex As Exception
                    If ex.ToString.Contains("No coinciden los tipos de datos en la expresi") Then
                        ingtresocase()
                    ElseIf ex.ToString.Contains("valores duplicados") Then
                        MsgBox("ya esta el regtistro")
                    Else
                        MsgBox(ex.Message)
                    End If
                End Try
            Else
                Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, "Debes elegir un tipo")
            End If
        Else
            Form1.ErrorProvider1.SetError(Form1.Label15, "Da clic a nuevo")
        End If
    End Sub
    '==================================================Presupuesto===================================================
    Public Sub cambiapresupuesto()
        If IsNumeric(Form1.MaterialSingleLineTextField1.Text) Then
            'update en accews
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            sql = "UPDATE PRESUPUESTOS SET PRESUPUESTO ='" & Form1.MaterialSingleLineTextField1.Text & "',MODIFICADO = '" & Form1.Label13.Text.ToString & "' WHERE ID = 1 "
            ' MsgBox(sql)
            cmd.CommandText = sql
            Try
                'insertar
                cmd.ExecuteNonQuery()
                MsgBox("Insertado correctamente")
                limpiartodo()
                dr.Close()
                leerpresupusto()
            Catch ex As Exception
                If ex.ToString.Contains("No coinciden los tipos de datos en la expresi") Then
                    ingtresocase()
                Else
                    MsgBox(ex.Message)
                End If
            End Try
        Else
        Form1.ErrorProvider1.SetError(Form1.MaterialSingleLineTextField1, "Solo Números")
        End If
    End Sub
    Public Sub leerpresupusto()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select PRESUPUESTO FROM PRESUPUESTOS "
        Try
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    Form1.Label15.Text = "Presupuesto actual: " & dr(0)
                End While
            Else
                Form1.Label15.Text = "Presupuesto actual: ---"
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '=================================================Tarjetas========================================================
    Public Sub agregatarjetas()
        Dim tipo, descripcion, fechaexacta As String
        descripcion = Form1.MaterialSingleLineTextField1.Text
        fechaexacta = Form1.Label11.Text.ToString
        tipo = Form1.MetroComboBox1.Text
        If descripcion <> "" Then
            Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, Nothing)
            If tipo <> "" Then
                Form1.ErrorProvider1.SetError(Form1.MaterialSingleLineTextField1, Nothing)
                cmd.CommandType = CommandType.Text
                cmd.Connection = conn
                sql = "INSERT INTO TARJETAS(DESCRIPCION, TIPO, AGREGADO) "
                sql += "VALUES('" & descripcion & "','" & tipo & "','" & fechaexacta & "')"
                ' MsgBox(sql)
                cmd.CommandText = sql
                Try
                    'insertar
                    cmd.ExecuteNonQuery()
                    MsgBox("Insertado correctamente")
                    limpiartodo()
                Catch ex As Exception
                    If ex.ToString.Contains("No coinciden los tipos de datos en la expresi") Then
                        ingtresocase()
                    ElseIf ex.ToString.Contains("valores duplicados") Then
                        MsgBox("ya esta el regtistro")
                    Else
                        MsgBox(ex.Message)
                    End If
                End Try
            Else
                Form1.ErrorProvider1.SetError(Form1.MetroComboBox1, "Debes elegir el tipo")
            End If
        Else
            Form1.ErrorProvider1.SetError(Form1.MaterialSingleLineTextField1, "Debes agregar una descripción")
        End If
    End Sub
    Public Sub leertarjetas()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT DESCRIPCION FROM TARJETAS "
        Form1.MetroComboBox2.Items.Clear()
        Try
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    'MsgBox(dr(0).ToString)
                    Form1.MetroComboBox2.Items.Add(dr(0).ToString)
                End While
                'Else
                'MsgBox("No hay tarjetas")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '========================================================Login======================================================
    Public Sub usuariosiniciar()
        Login.MetroComboBox1.Items.Clear()
        Try
            Dim listusers As StreamReader = File.OpenText(CurDir() + "\basededatos\users.txt")
            Do While Not listusers.EndOfStream
                Login.MetroComboBox1.Items.Add(listusers.ReadLine)
            Loop
            FileClose()
            listusers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub usuarioseliminar()
        Login.MetroComboBox2.Items.Clear()
        Try
            Dim listusers As StreamReader = File.OpenText(CurDir() + "\basededatos\users.txt")
            Do While Not listusers.EndOfStream
                Login.MetroComboBox2.Items.Add(listusers.ReadLine)
            Loop
            FileClose()
            listusers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
