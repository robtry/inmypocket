<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Detashes
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.MaterialListView1 = New MaterialSkin.Controls.MaterialListView()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton2 = New MaterialSkin.Controls.MaterialRaisedButton()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox9.Image = Global.impoket.My.Resources.Resources.leftroundarrow_izquierda_redondo_3456
        Me.PictureBox9.Location = New System.Drawing.Point(505, 27)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(48, 50)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox9.TabIndex = 36
        Me.PictureBox9.TabStop = False
        '
        'MaterialListView1
        '
        Me.MaterialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaterialListView1.Depth = 0
        Me.MaterialListView1.Font = New System.Drawing.Font("Roboto", 24.0!)
        Me.MaterialListView1.FullRowSelect = True
        Me.MaterialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.MaterialListView1.Location = New System.Drawing.Point(1, 64)
        Me.MaterialListView1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.MaterialListView1.MouseState = MaterialSkin.MouseState.OUT
        Me.MaterialListView1.Name = "MaterialListView1"
        Me.MaterialListView1.OwnerDraw = True
        Me.MaterialListView1.Size = New System.Drawing.Size(552, 357)
        Me.MaterialListView1.TabIndex = 37
        Me.MaterialListView1.UseCompatibleStateImageBehavior = False
        Me.MaterialListView1.View = System.Windows.Forms.View.Details
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(143, 427)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(97, 33)
        Me.MaterialRaisedButton1.TabIndex = 38
        Me.MaterialRaisedButton1.Text = "Añadir"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton2
        '
        Me.MaterialRaisedButton2.Depth = 0
        Me.MaterialRaisedButton2.Location = New System.Drawing.Point(314, 427)
        Me.MaterialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton2.Name = "MaterialRaisedButton2"
        Me.MaterialRaisedButton2.Primary = True
        Me.MaterialRaisedButton2.Size = New System.Drawing.Size(97, 33)
        Me.MaterialRaisedButton2.TabIndex = 39
        Me.MaterialRaisedButton2.Text = "Eliminar"
        Me.MaterialRaisedButton2.UseVisualStyleBackColor = True
        '
        'Detashes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 470)
        Me.Controls.Add(Me.MaterialRaisedButton2)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.MaterialListView1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(555, 470)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(555, 470)
        Me.Name = "Detashes"
        Me.Sizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detashes"
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents MaterialListView1 As MaterialSkin.Controls.MaterialListView
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton2 As MaterialSkin.Controls.MaterialRaisedButton
End Class
