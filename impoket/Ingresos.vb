Imports MaterialSkin
Public Class Ingresos
    Private Sub Ingresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SkinManager.ColorScheme = New ColorScheme(Primary.Green800, Primary.Green900, Primary.BlueGrey900, Accent.Indigo700, TextShade.WHITE)
        Dim dinero As Double
        Try
            dinero = Val(InputBox("Ingresa la cantidad", "Ingresos InMyPocket", "0.00"))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Label1.Text = "$" & dinero
        Label5.Text = Form1.Label10.Text
    End Sub
    Private Sub Ingresos_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.SkinManager.ColorScheme = New ColorScheme(Primary.Green800, Primary.Green900, Primary.BlueGrey900, Accent.Indigo700, TextShade.WHITE)
        Me.Refresh()
    End Sub
    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        Dim dinero As Double
        dinero = InputBox("Ingresa la cantidad", "Ingresos InMyPocket", "0.00")
        Label1.Text = "$" & dinero
        Label5.Text = Form1.Label10.Text
        MaterialSingleLineTextField1.Clear()
    End Sub
    Private Sub MaterialFlatButton2_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton2.Click
        Dim identificacion As String
        Dim descripcion As String = ""
        Dim tipo As String
        identificacion = Label5.Text.ToString
        descripcion = MaterialSingleLineTextField1.Text
        tipo = MetroComboBox1.Text

        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        sql = "INSERT INTO INGRESOS(ID, CANTIDAD, DESCRIPCION, TIPO) "
        sql += "VALUES('" & identificacion & "','" & Label1.Text & "','" & descripcion & "',"
        sql += "'" & tipo & "')"
        MsgBox(sql)
        cmd.CommandText = sql
        Try
            'insertar
            cmd.ExecuteNonQuery()
            MsgBox("Insertado correctamente")
        Catch ex As Exception
            If ex.ToString.Contains("valores duplicados") Then
                MsgBox("ya esta el regtistro")
            Else
                MsgBox(ex.Message)
            End If
        End Try

    End Sub
End Class