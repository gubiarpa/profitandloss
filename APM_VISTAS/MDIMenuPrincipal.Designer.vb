<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMenuPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMenuPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.OperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConexiónADatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CargarRequerimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarRequerimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EjecutarProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasContablesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CuentasContablesIngresosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CuentasContablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuquesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeerArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.staAuth = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesToolStripMenuItem, Me.MaToolStripMenuItem, Me.SalirToolStripMenuItem, Me.LeerArchivoToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1084, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'OperacionesToolStripMenuItem
        '
        Me.OperacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConexiónADatosToolStripMenuItem, Me.ToolStripSeparator2, Me.CargarRequerimientosToolStripMenuItem, Me.EliminarRequerimientoToolStripMenuItem, Me.ExportarAExcelToolStripMenuItem, Me.ToolStripSeparator3, Me.EjecutarProcesoToolStripMenuItem})
        Me.OperacionesToolStripMenuItem.Name = "OperacionesToolStripMenuItem"
        Me.OperacionesToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.OperacionesToolStripMenuItem.Text = "Operaciones"
        '
        'ConexiónADatosToolStripMenuItem
        '
        Me.ConexiónADatosToolStripMenuItem.Name = "ConexiónADatosToolStripMenuItem"
        Me.ConexiónADatosToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ConexiónADatosToolStripMenuItem.Text = "Conexión a Datos"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'CargarRequerimientosToolStripMenuItem
        '
        Me.CargarRequerimientosToolStripMenuItem.Name = "CargarRequerimientosToolStripMenuItem"
        Me.CargarRequerimientosToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CargarRequerimientosToolStripMenuItem.Text = "Cargar Tabla"
        '
        'EliminarRequerimientoToolStripMenuItem
        '
        Me.EliminarRequerimientoToolStripMenuItem.Name = "EliminarRequerimientoToolStripMenuItem"
        Me.EliminarRequerimientoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EliminarRequerimientoToolStripMenuItem.Text = "Eliminar Tabla"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar Tabla"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(163, 6)
        '
        'EjecutarProcesoToolStripMenuItem
        '
        Me.EjecutarProcesoToolStripMenuItem.Name = "EjecutarProcesoToolStripMenuItem"
        Me.EjecutarProcesoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EjecutarProcesoToolStripMenuItem.Text = "Ejecutar Proceso"
        '
        'MaToolStripMenuItem
        '
        Me.MaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CuentasContablesToolStripMenuItem1, Me.ToolStripSeparator4, Me.CuentasContablesIngresosToolStripMenuItem, Me.ToolStripSeparator5, Me.CuentasContablesToolStripMenuItem, Me.ToolStripSeparator1, Me.BuquesToolStripMenuItem})
        Me.MaToolStripMenuItem.Name = "MaToolStripMenuItem"
        Me.MaToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.MaToolStripMenuItem.Text = "Mantenimientos"
        '
        'CuentasContablesToolStripMenuItem1
        '
        Me.CuentasContablesToolStripMenuItem1.Name = "CuentasContablesToolStripMenuItem1"
        Me.CuentasContablesToolStripMenuItem1.Size = New System.Drawing.Size(324, 22)
        Me.CuentasContablesToolStripMenuItem1.Text = "Cuentas Contables"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(321, 6)
        '
        'CuentasContablesIngresosToolStripMenuItem
        '
        Me.CuentasContablesIngresosToolStripMenuItem.Name = "CuentasContablesIngresosToolStripMenuItem"
        Me.CuentasContablesIngresosToolStripMenuItem.Size = New System.Drawing.Size(324, 22)
        Me.CuentasContablesIngresosToolStripMenuItem.Text = "Asociación Driver Ingresos – Cuentas Contables"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(321, 6)
        '
        'CuentasContablesToolStripMenuItem
        '
        Me.CuentasContablesToolStripMenuItem.Name = "CuentasContablesToolStripMenuItem"
        Me.CuentasContablesToolStripMenuItem.Size = New System.Drawing.Size(324, 22)
        Me.CuentasContablesToolStripMenuItem.Text = "Asociación Driver Gastos – Cuentas Contables"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(321, 6)
        '
        'BuquesToolStripMenuItem
        '
        Me.BuquesToolStripMenuItem.Name = "BuquesToolStripMenuItem"
        Me.BuquesToolStripMenuItem.Size = New System.Drawing.Size(324, 22)
        Me.BuquesToolStripMenuItem.Text = "Buques"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'LeerArchivoToolStripMenuItem
        '
        Me.LeerArchivoToolStripMenuItem.Name = "LeerArchivoToolStripMenuItem"
        Me.LeerArchivoToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.LeerArchivoToolStripMenuItem.Text = "LeerArchivo"
        Me.LeerArchivoToolStripMenuItem.Visible = False
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.staAuth})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 760)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1084, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'staAuth
        '
        Me.staAuth.Name = "staAuth"
        Me.staAuth.Size = New System.Drawing.Size(39, 17)
        Me.staAuth.Text = "Status"
        '
        'MDIMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.APM_VISTAS.My.Resources.Resources.APM_Backgroud4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1084, 782)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "MDIMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APM TERMINALS"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents staAuth As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents OperacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConexiónADatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CargarRequerimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EjecutarProcesoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentasContablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeerArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarRequerimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentasContablesIngresosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BuquesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentasContablesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
