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
    Public Sub delingreso()
        'MsgBox(ListBox1.SelectedIndex) index
        'MsgBox(ListBox1.SelectedItem) valor
        'MsgBox(ListBox1.Items(4)) valor en el index
        Dim i As Integer
        For Each i In Detashes.MaterialListView1.SelectedIndices
            'MsgBox(i)
            ' MsgBox(Detashes.ListBox1.Items(i))
        Next i
        Try
            cmd.CommandText = "DELETE FROM INGRESOS WHERE ID = " & Detashes.ListBox1.Items(i) & " "
            'MsgBox("DELETE FROM INGRESOS WHERE ID = " & Detashes.ListBox1.Items(i) & " ")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            ' MsgBox("borrado")
            llenarlistingresos()
        Catch ex As Exception
            If ex.ToString.Contains("El valor de '0' no es válido para 'index'") Then
                'ps nda
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
    Public Sub llenarlistgastos()
        Detashes.MaterialListView1.Columns.Clear()
        Detashes.MaterialListView1.Items.Clear()
        Detashes.Text = "Gastos"
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT ID, CANTIDAD, DESCRIPCION, TIPO, ASOCIADO, AGREGADO FROM GASTOS "
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
    Public Sub delgasto()
        Dim i As Integer
        For Each i In Detashes.MaterialListView1.SelectedIndices
            'MsgBox(i)
            'MsgBox(Detashes.ListBox1.Items(i))
        Next i
        Try
            cmd.CommandText = "DELETE FROM GASTOS WHERE ID = " & Detashes.ListBox1.Items(i) & " "
            'MsgBox("DELETE FROM INGRESOS WHERE ID = " & Detashes.ListBox1.Items(i) & " ")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            'MsgBox("borrado")
            llenarlistgastos()
        Catch ex As Exception
            If ex.ToString.Contains("El valor de '0' no es válido para 'index'") Then
                'ps nda
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
    Public Sub llenarlisttarjeta()
        Detashes.MaterialListView1.Columns.Clear()
        Detashes.MaterialListView1.Items.Clear()
        Detashes.Text = "Tarjetas"
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT ID, DESCRIPCION, TIPO, AGREGADO FROM TARJETAS "
        'Detashes.MaterialListView1.View = View.Details
        Detashes.MaterialListView1.Scrollable = True
        'Detashes.MaterialListView1.AllowColumnReorder = True
        Detashes.MaterialListView1.Columns.Add("Descripción", 170)
        Detashes.MaterialListView1.Columns.Add("Tipo", 150)
        Detashes.MaterialListView1.Columns.Add("Fecha", 210)
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
                    End With
                End While
            End If
            dr.Close()
            Detashes.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub deltarjeta()
        Dim i As Integer
        For Each i In Detashes.MaterialListView1.SelectedIndices
            'MsgBox(i)
            'MsgBox(Detashes.ListBox1.Items(i))
        Next i
        Try
            cmd.CommandText = "DELETE FROM TARJETAS WHERE ID = " & Detashes.ListBox1.Items(i) & " "
            'MsgBox("DELETE FROM INGRESOS WHERE ID = " & Detashes.ListBox1.Items(i) & " ")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            'MsgBox("borrado")
            llenarlisttarjeta()
        Catch ex As Exception
            If ex.ToString.Contains("El valor de '0' no es válido para 'index'") Then
                'ps nda
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
End Module
