Module vertodocases
    Public Sub llenarlistingresos()
        'Dim ds As New DataSet
        'Dim dt As New DataTable
        'Dim ssql As String = "SELECT CANTIDAD, DESCRIPCION, TIPO, ASOCIADO FROM INGRESOS"
        'Dim apd As New OleDb.OleDbDataAdapter(ssql, conn)
        'ds.Tables.Add("tabla")
        'apd.Fill(ds.Tables("tabla"))
        'Detashes.MetroGrid1.DataSource = ds.Tables("tabla")
        'Detashes.MetroGrid1.Columns(0).HeaderText = "akdfsi"
        'Detashes.MetroGrid1.Style = MetroFramework.MetroColorStyle.Green
        Detashes.Text = "Ingresos"
        Detashes.Refresh()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT CANTIDAD, DESCRIPCION, TIPO, ASOCIADO, AGREGADO FROM INGRESOS "
        Detashes.MaterialListView1.Columns.Clear()
        Detashes.MaterialListView1.Items.Clear()
        Detashes.MaterialListView1.View = View.Details
        Detashes.MaterialListView1.Scrollable = True
        Detashes.MaterialListView1.Columns.Add("Cantidad", 100)
        Detashes.MaterialListView1.Columns.Add("Descripción", 150)
        Detashes.MaterialListView1.Columns.Add("Tipo", 150)
        Detashes.MaterialListView1.Columns.Add("Fecha", 150)
        Try
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    Detashes.MaterialListView1.Items.Add("$" & dr(0).ToString).SubItems.Add("donde estoy?")
                End While
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
