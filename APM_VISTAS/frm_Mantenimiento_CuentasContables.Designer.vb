<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mantenimiento_CuentasContables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mantenimiento_CuentasContables))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsb_Agregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Modificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Eliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Salir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsb_Seleccionar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.cbo_Concep = New System.Windows.Forms.ComboBox()
        Me.cbo_TipConcep = New System.Windows.Forms.ComboBox()
        Me.txt_Cuenta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_Mes = New System.Windows.Forms.ComboBox()
        Me.cbo_Año = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_CtasContables = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_CtasContables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Agregar, Me.ToolStripSeparator1, Me.tsb_Modificar, Me.ToolStripSeparator2, Me.tsb_Eliminar, Me.ToolStripSeparator3, Me.tsb_Salir, Me.ToolStripSeparator4, Me.tsb_Seleccionar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(590, 26)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_Agregar
        '
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
        Me.tsb_Salir.Image = Global.APM_VISTAS.My.Resources.Resources.Ico_Salir
        Me.tsb_Salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Salir.Name = "tsb_Salir"
        Me.tsb_Salir.Size = New System.Drawing.Size(54, 23)
        Me.tsb_Salir.Text = "Salir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 26)
        '
        'tsb_Seleccionar
        '
        Me.tsb_Seleccionar.Image = Global.APM_VISTAS.My.Resources.Resources.Ico_Seleccionar
        Me.tsb_Seleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Seleccionar.Name = "tsb_Seleccionar"
        Me.tsb_Seleccionar.Size = New System.Drawing.Size(96, 23)
        Me.tsb_Seleccionar.Text = "Seleccionar"
        Me.tsb_Seleccionar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Buscar)
        Me.GroupBox1.Controls.Add(Me.cbo_Concep)
        Me.GroupBox1.Controls.Add(Me.cbo_TipConcep)
        Me.GroupBox1.Controls.Add(Me.txt_Cuenta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_Mes)
        Me.GroupBox1.Controls.Add(Me.cbo_Año)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(36, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 152)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(353, 109)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(96, 26)
        Me.btn_Buscar.TabIndex = 10
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'cbo_Concep
        '
        Me.cbo_Concep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Concep.FormattingEnabled = True
        Me.cbo_Concep.Location = New System.Drawing.Point(353, 51)
        Me.cbo_Concep.Name = "cbo_Concep"
        Me.cbo_Concep.Size = New System.Drawing.Size(154, 23)
        Me.cbo_Concep.TabIndex = 9
        '
        'cbo_TipConcep
        '
        Me.cbo_TipConcep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_TipConcep.FormattingEnabled = True
        Me.cbo_TipConcep.Location = New System.Drawing.Point(117, 51)
        Me.cbo_TipConcep.Name = "cbo_TipConcep"
        Me.cbo_TipConcep.Size = New System.Drawing.Size(154, 23)
        Me.cbo_TipConcep.TabIndex = 8
        '
        'txt_Cuenta
        '
        Me.txt_Cuenta.Location = New System.Drawing.Point(117, 24)
        Me.txt_Cuenta.Name = "txt_Cuenta"
        Me.txt_Cuenta.Size = New System.Drawing.Size(96, 21)
        Me.txt_Cuenta.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(288, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Concepto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Tipo de concepto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cuenta"
        '
        'cbo_Mes
        '
        Me.cbo_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Mes.FormattingEnabled = True
        Me.cbo_Mes.Location = New System.Drawing.Point(353, 80)
        Me.cbo_Mes.Name = "cbo_Mes"
        Me.cbo_Mes.Size = New System.Drawing.Size(96, 23)
        Me.cbo_Mes.TabIndex = 3
        '
        'cbo_Año
        '
        Me.cbo_Año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Año.FormattingEnabled = True
        Me.cbo_Año.Location = New System.Drawing.Point(117, 80)
        Me.cbo_Año.Name = "cbo_Año"
        Me.cbo_Año.Size = New System.Drawing.Size(96, 23)
        Me.cbo_Año.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(288, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año"
        '
        'dgv_CtasContables
        '
        Me.dgv_CtasContables.AllowUserToAddRows = False
        Me.dgv_CtasContables.AllowUserToDeleteRows = False
        Me.dgv_CtasContables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_CtasContables.Location = New System.Drawing.Point(13, 188)
        Me.dgv_CtasContables.Name = "dgv_CtasContables"
        Me.dgv_CtasContables.ReadOnly = True
        Me.dgv_CtasContables.Size = New System.Drawing.Size(560, 398)
        Me.dgv_CtasContables.TabIndex = 2
        '
        'frm_Mantenimiento_CuentasContables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 598)
        Me.Controls.Add(Me.dgv_CtasContables)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_Mantenimiento_CuentasContables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APM - Cuentas Contables"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_CtasContables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Agregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Modificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_Mes As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Año As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Concep As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_TipConcep As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_CtasContables As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents tsb_Seleccionar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
