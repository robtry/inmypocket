Module vertodocases
    Public Sub llenarlistingresos()
        Detashes.MaterialListView1.Columns.Clear()
        Detashes.MaterialListView1.Items.Clear()
        Detashes.Text = "Ingresos"
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT ID, CANTIDAD, DESCRIPCION, TIPO, ASOCIADO, AGREGADO FROM INGRESOS "
        'Detashes.MaterialListView1.View = View.Details
        Detashes.MaterialListView1.Scrollable = True
        'Detashes.MaterialListView1.AllowColumnReorder = True
        Detashes.MaterialListView1.Columns.Add("Cantidad", 100)
        Detashes.MaterialListView1.Columns.Add("Descripción", 130)
        Detashes.MaterialListView1.Columns.Add("Tipo", 100)
        Detashes.MaterialListView1.Columns.Add("Tarjeta", 110)
        Detashes.MaterialListView1.Columns.Add("Fecha", 200)
        Try
            Detashes.ListBox1.Items.Clear()
            dr = cmd.ExecuteReader()
            'recorrido del dr
            If dr.HasRows Then
                While dr.Read()
                    Detashes.ListBox1.Items.Add(dr(0))
                    Dim fila As ListViewItem
                    fila = Detashes.MaterialListView1.Items.Add(dr(1)) ' cabecera del listview-ItemPrincipal
                    With fila
                        .SubItems.Add(dr(2)) '1 los subItem o el resto de las columas
                        .SubItems.Add(dr(3))
                        .SubItems.Add(dr(4))
                        .SubItems.Add(dr(5))
                    End With
                End While
            End If
            dr.Close()
            Detashes.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
