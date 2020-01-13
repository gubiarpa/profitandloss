<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mantenimiento_Cuenta_Ingreso
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mantenimiento_Cuenta_Ingreso))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsb_Agregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Modificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Eliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Salir = New System.Windows.Forms.ToolStripButton()
        Me.dgv_Cuentas = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgv_Cuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Agregar, Me.ToolStripSeparator1, Me.tsb_Modificar, Me.ToolStripSeparator2, Me.tsb_Eliminar, Me.ToolStripSeparator3, Me.tsb_Salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(384, 26)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_Agregar
        '
        Me.tsb_Agregar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsb_Agregar.Image = Global.APM_VISTAS.My.Resources.Resources.Ico_Agregar
        Me.tsb_Agregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Agregar.Name = "tsb_Agregar"
        Me.tsb_Agregar.Size = New System.Drawing.Size(78, 23)
        Me.tsb_Agregar.Text = "Agregar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 26)
        '
        'tsb_Modificar
        '
        Me.tsb_Modificar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsb_Modificar.Image = Global.APM_VISTAS.My.Resources.Resources.Ico_Modificar
        Me.tsb_Modificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Modificar.Name = "tsb_Modificar"
        Me.tsb_Modificar.Size = New System.Drawing.Size(86, 23)
        Me.tsb_Modificar.Text = "Modificar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 26)
        '
        'tsb_Eliminar
        '
        Me.tsb_Eliminar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsb_Eliminar.Image = Global.APM_VISTAS.My.Resources.Resources.Ico_Eliminar
        Me.tsb_Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Eliminar.Name = "tsb_Eliminar"
        Me.tsb_Eliminar.Size = New System.Drawing.Size(77, 23)
        Me.tsb_Eliminar.Text = "Eliminar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 26)
        '
        'tsb_Salir
        '
        Me.tsb_Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tsb_Salir.Image = Global.APM_VISTAS.My.Resources.Resources.Ico_Salir
        Me.tsb_Salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Salir.Name = "tsb_Salir"
        Me.tsb_Salir.Size = New System.Drawing.Size(54, 23)
        Me.tsb_Salir.Text = "Salir"
        '
        'dgv_Cuentas
        '
        Me.dgv_Cuentas.AllowUserToAddRows = False
        Me.dgv_Cuentas.AllowUserToDeleteRows = False
        Me.dgv_Cuentas.AllowUserToResizeColumns = False
        Me.dgv_Cuentas.AllowUserToResizeRows = False
        Me.dgv_Cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Cuentas.Location = New System.Drawing.Point(12, 45)
        Me.dgv_Cuentas.Name = "dgv_Cuentas"
        Me.dgv_Cuentas.ReadOnly = True
        Me.dgv_Cuentas.Size = New System.Drawing.Size(360, 603)
        Me.dgv_Cuentas.TabIndex = 7
        '
        'frm_Mantenimiento_Cuenta_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 660)
        Me.Controls.Add(Me.dgv_Cuentas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_Mantenimiento_Cuenta_Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APM - Cuentas de Ingresos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgv_Cuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsb_Agregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Modificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgv_Cuentas As System.Windows.Forms.DataGridView
End Class
