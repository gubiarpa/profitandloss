<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AgregarCuentaContable
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_AgregarCuentaContable))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cbo_Año = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Cuenta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_TipConcep = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_Concep = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_Mes = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.cbo_SubConcep = New System.Windows.Forms.ComboBox()
        Me.txt_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.btnCargarArchivo = New System.Windows.Forms.Button()
        Me.btnBuscarArchivo = New System.Windows.Forms.Button()
        Me.chkHaveHeader = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboMesMasivo = New System.Windows.Forms.ComboBox()
        Me.btnCargarMasivo = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboAnioMasivo = New System.Windows.Forms.ComboBox()
        Me.dgvCuentas = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblCantidadCuentas = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboMesNow = New System.Windows.Forms.ComboBox()
        Me.btnReplicar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboAnioNow = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnVerPeriodoPrev = New System.Windows.Forms.Button()
        Me.cboMesPrev = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboAnioPrev = New System.Windows.Forms.ComboBox()
        Me.dgvPeriodoPrev = New System.Windows.Forms.DataGridView()
        Me.pgbCargaMasiva = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPeriodoPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(579, 477)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agregar Cuenta"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(6, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(566, 452)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.cbo_Año)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txt_Cuenta)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cbo_TipConcep)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cbo_Concep)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btn_Cancelar)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cbo_Mes)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btn_Guardar)
        Me.TabPage1.Controls.Add(Me.cbo_SubConcep)
        Me.TabPage1.Controls.Add(Me.txt_Descripcion)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(558, 424)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Carga Unitaria"
        '
        'cbo_Año
        '
        Me.cbo_Año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Año.FormattingEnabled = True
        Me.cbo_Año.Location = New System.Drawing.Point(138, 55)
        Me.cbo_Año.Name = "cbo_Año"
        Me.cbo_Año.Size = New System.Drawing.Size(81, 23)
        Me.cbo_Año.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(92, 200)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 15)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(98, 172)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 15)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "*"
        '
        'txt_Cuenta
        '
        Me.txt_Cuenta.Location = New System.Drawing.Point(138, 28)
        Me.txt_Cuenta.MaxLength = 8
        Me.txt_Cuenta.Name = "txt_Cuenta"
        Me.txt_Cuenta.Size = New System.Drawing.Size(96, 21)
        Me.txt_Cuenta.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(77, 145)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 15)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tipo de concepto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(118, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 15)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Concepto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(64, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 15)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "*"
        '
        'cbo_TipConcep
        '
        Me.cbo_TipConcep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_TipConcep.FormattingEnabled = True
        Me.cbo_TipConcep.Location = New System.Drawing.Point(138, 113)
        Me.cbo_TipConcep.Name = "cbo_TipConcep"
        Me.cbo_TipConcep.Size = New System.Drawing.Size(247, 23)
        Me.cbo_TipConcep.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(43, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 15)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "*"
        '
        'cbo_Concep
        '
        Me.cbo_Concep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Concep.FormattingEnabled = True
        Me.cbo_Concep.Location = New System.Drawing.Point(138, 140)
        Me.cbo_Concep.Name = "cbo_Concep"
        Me.cbo_Concep.Size = New System.Drawing.Size(247, 23)
        Me.cbo_Concep.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(46, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 15)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Año"
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(422, 338)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(100, 26)
        Me.btn_Cancelar.TabIndex = 23
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Mes"
        '
        'cbo_Mes
        '
        Me.cbo_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Mes.FormattingEnabled = True
        Me.cbo_Mes.Location = New System.Drawing.Point(138, 84)
        Me.cbo_Mes.Name = "cbo_Mes"
        Me.cbo_Mes.Size = New System.Drawing.Size(122, 23)
        Me.cbo_Mes.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Subconcepto"
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Location = New System.Drawing.Point(316, 338)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(100, 26)
        Me.btn_Guardar.TabIndex = 22
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'cbo_SubConcep
        '
        Me.cbo_SubConcep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_SubConcep.FormattingEnabled = True
        Me.cbo_SubConcep.Location = New System.Drawing.Point(138, 166)
        Me.cbo_SubConcep.Name = "cbo_SubConcep"
        Me.cbo_SubConcep.Size = New System.Drawing.Size(247, 23)
        Me.cbo_SubConcep.TabIndex = 19
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.Location = New System.Drawing.Point(138, 195)
        Me.txt_Descripcion.Multiline = True
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Size = New System.Drawing.Size(384, 137)
        Me.txt_Descripcion.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Descripción"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.pgbCargaMasiva)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.dgvCuentas)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(558, 424)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Carga Masiva"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtArchivo)
        Me.GroupBox5.Controls.Add(Me.btnCargarArchivo)
        Me.GroupBox5.Controls.Add(Me.btnBuscarArchivo)
        Me.GroupBox5.Controls.Add(Me.chkHaveHeader)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 75)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(543, 80)
        Me.GroupBox5.TabIndex = 45
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Archivo de Carga"
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(21, 27)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(364, 21)
        Me.txtArchivo.TabIndex = 31
        '
        'btnCargarArchivo
        '
        Me.btnCargarArchivo.Enabled = False
        Me.btnCargarArchivo.Location = New System.Drawing.Point(425, 24)
        Me.btnCargarArchivo.Name = "btnCargarArchivo"
        Me.btnCargarArchivo.Size = New System.Drawing.Size(100, 26)
        Me.btnCargarArchivo.TabIndex = 22
        Me.btnCargarArchivo.Text = "Vista Previa"
        Me.btnCargarArchivo.UseVisualStyleBackColor = True
        '
        'btnBuscarArchivo
        '
        Me.btnBuscarArchivo.Location = New System.Drawing.Point(391, 26)
        Me.btnBuscarArchivo.Name = "btnBuscarArchivo"
        Me.btnBuscarArchivo.Size = New System.Drawing.Size(28, 23)
        Me.btnBuscarArchivo.TabIndex = 22
        Me.btnBuscarArchivo.Text = "..."
        Me.btnBuscarArchivo.UseVisualStyleBackColor = True
        '
        'chkHaveHeader
        '
        Me.chkHaveHeader.AutoSize = True
        Me.chkHaveHeader.Checked = True
        Me.chkHaveHeader.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHaveHeader.Location = New System.Drawing.Point(21, 49)
        Me.chkHaveHeader.Name = "chkHaveHeader"
        Me.chkHaveHeader.Size = New System.Drawing.Size(129, 19)
        Me.chkHaveHeader.TabIndex = 32
        Me.chkHaveHeader.Text = "Contiene cabecera"
        Me.chkHaveHeader.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.cboMesMasivo)
        Me.GroupBox4.Controls.Add(Me.btnCargarMasivo)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.cboAnioMasivo)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(543, 63)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Período Actual"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(18, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 15)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = "Año"
        '
        'cboMesMasivo
        '
        Me.cboMesMasivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesMasivo.FormattingEnabled = True
        Me.cboMesMasivo.Location = New System.Drawing.Point(211, 22)
        Me.cboMesMasivo.Name = "cboMesMasivo"
        Me.cboMesMasivo.Size = New System.Drawing.Size(172, 23)
        Me.cboMesMasivo.TabIndex = 38
        '
        'btnCargarMasivo
        '
        Me.btnCargarMasivo.Enabled = False
        Me.btnCargarMasivo.Location = New System.Drawing.Point(425, 19)
        Me.btnCargarMasivo.Name = "btnCargarMasivo"
        Me.btnCargarMasivo.Size = New System.Drawing.Size(100, 26)
        Me.btnCargarMasivo.TabIndex = 41
        Me.btnCargarMasivo.Text = "Cargar Masivamente"
        Me.btnCargarMasivo.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(159, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 15)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "Mes"
        '
        'cboAnioMasivo
        '
        Me.cboAnioMasivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnioMasivo.FormattingEnabled = True
        Me.cboAnioMasivo.Location = New System.Drawing.Point(52, 23)
        Me.cboAnioMasivo.Name = "cboAnioMasivo"
        Me.cboAnioMasivo.Size = New System.Drawing.Size(81, 23)
        Me.cboAnioMasivo.TabIndex = 37
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCuentas.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCuentas.Location = New System.Drawing.Point(6, 161)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ReadOnly = True
        Me.dgvCuentas.RowHeadersVisible = False
        Me.dgvCuentas.Size = New System.Drawing.Size(546, 236)
        Me.dgvCuentas.TabIndex = 33
        Me.dgvCuentas.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.lblCantidadCuentas)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.dgvPeriodoPrev)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(558, 424)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Replicación de Períodos Anteriores"
        '
        'lblCantidadCuentas
        '
        Me.lblCantidadCuentas.Location = New System.Drawing.Point(217, 394)
        Me.lblCantidadCuentas.Name = "lblCantidadCuentas"
        Me.lblCantidadCuentas.Size = New System.Drawing.Size(335, 27)
        Me.lblCantidadCuentas.TabIndex = 44
        Me.lblCantidadCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.cboMesNow)
        Me.GroupBox3.Controls.Add(Me.btnReplicar)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.cboAnioNow)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(546, 63)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Período Actual"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(18, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 15)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Año"
        '
        'cboMesNow
        '
        Me.cboMesNow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesNow.FormattingEnabled = True
        Me.cboMesNow.Location = New System.Drawing.Point(211, 22)
        Me.cboMesNow.Name = "cboMesNow"
        Me.cboMesNow.Size = New System.Drawing.Size(172, 23)
        Me.cboMesNow.TabIndex = 38
        '
        'btnReplicar
        '
        Me.btnReplicar.Enabled = False
        Me.btnReplicar.Location = New System.Drawing.Point(416, 19)
        Me.btnReplicar.Name = "btnReplicar"
        Me.btnReplicar.Size = New System.Drawing.Size(110, 26)
        Me.btnReplicar.TabIndex = 41
        Me.btnReplicar.Text = "Replicar"
        Me.btnReplicar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(159, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 15)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Mes"
        '
        'cboAnioNow
        '
        Me.cboAnioNow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnioNow.FormattingEnabled = True
        Me.cboAnioNow.Location = New System.Drawing.Point(52, 23)
        Me.cboAnioNow.Name = "cboAnioNow"
        Me.cboAnioNow.Size = New System.Drawing.Size(81, 23)
        Me.cboAnioNow.TabIndex = 37
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.btnVerPeriodoPrev)
        Me.GroupBox2.Controls.Add(Me.cboMesPrev)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.cboAnioPrev)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(546, 63)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Período Anterior"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(28, 15)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Año"
        '
        'btnVerPeriodoPrev
        '
        Me.btnVerPeriodoPrev.Enabled = False
        Me.btnVerPeriodoPrev.Location = New System.Drawing.Point(416, 21)
        Me.btnVerPeriodoPrev.Name = "btnVerPeriodoPrev"
        Me.btnVerPeriodoPrev.Size = New System.Drawing.Size(110, 26)
        Me.btnVerPeriodoPrev.TabIndex = 41
        Me.btnVerPeriodoPrev.Text = "Ver"
        Me.btnVerPeriodoPrev.UseVisualStyleBackColor = True
        '
        'cboMesPrev
        '
        Me.cboMesPrev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesPrev.FormattingEnabled = True
        Me.cboMesPrev.Location = New System.Drawing.Point(211, 24)
        Me.cboMesPrev.Name = "cboMesPrev"
        Me.cboMesPrev.Size = New System.Drawing.Size(172, 23)
        Me.cboMesPrev.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(159, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 15)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "Mes"
        '
        'cboAnioPrev
        '
        Me.cboAnioPrev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnioPrev.FormattingEnabled = True
        Me.cboAnioPrev.Location = New System.Drawing.Point(52, 24)
        Me.cboAnioPrev.Name = "cboAnioPrev"
        Me.cboAnioPrev.Size = New System.Drawing.Size(81, 23)
        Me.cboAnioPrev.TabIndex = 37
        '
        'dgvPeriodoPrev
        '
        Me.dgvPeriodoPrev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPeriodoPrev.Location = New System.Drawing.Point(6, 144)
        Me.dgvPeriodoPrev.Name = "dgvPeriodoPrev"
        Me.dgvPeriodoPrev.ReadOnly = True
        Me.dgvPeriodoPrev.Size = New System.Drawing.Size(546, 247)
        Me.dgvPeriodoPrev.TabIndex = 34
        '
        'pgbCargaMasiva
        '
        Me.pgbCargaMasiva.Location = New System.Drawing.Point(9, 403)
        Me.pgbCargaMasiva.Name = "pgbCargaMasiva"
        Me.pgbCargaMasiva.Size = New System.Drawing.Size(543, 15)
        Me.pgbCargaMasiva.TabIndex = 46
        '
        'frm_AgregarCuentaContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 497)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_AgregarCuentaContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APM - Agregar Cuenta"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvPeriodoPrev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Cuenta As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Concep As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_TipConcep As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_Mes As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Año As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_SubConcep As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents btnBuscarArchivo As Button
    Friend WithEvents btnCargarArchivo As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents chkHaveHeader As CheckBox
    Friend WithEvents dgvCuentas As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents cboAnioPrev As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cboMesPrev As ComboBox
    Friend WithEvents dgvPeriodoPrev As DataGridView
    Friend WithEvents btnReplicar As Button
    Friend WithEvents btnVerPeriodoPrev As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cboMesNow As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cboAnioNow As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cboMesMasivo As ComboBox
    Friend WithEvents btnCargarMasivo As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents cboAnioMasivo As ComboBox
    Friend WithEvents lblCantidadCuentas As Label
    Friend WithEvents pgbCargaMasiva As ProgressBar
End Class
