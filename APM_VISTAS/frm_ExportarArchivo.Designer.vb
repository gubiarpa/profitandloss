<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ExportarArchivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ExportarArchivo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cBox_Mes = New System.Windows.Forms.ComboBox()
        Me.cBox_Anio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pgBar_Exp = New System.Windows.Forms.ProgressBar()
        Me.btn_Ruta = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.txtBox_Carpeta = New System.Windows.Forms.TextBox()
        Me.btn_Exportar = New System.Windows.Forms.Button()
        Me.cmBox_Req = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgWork_Exp = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cBox_Mes)
        Me.GroupBox1.Controls.Add(Me.cBox_Anio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.pgBar_Exp)
        Me.GroupBox1.Controls.Add(Me.btn_Ruta)
        Me.GroupBox1.Controls.Add(Me.btn_Cancelar)
        Me.GroupBox1.Controls.Add(Me.txtBox_Carpeta)
        Me.GroupBox1.Controls.Add(Me.btn_Exportar)
        Me.GroupBox1.Controls.Add(Me.cmBox_Req)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 239)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exportar Tabla"
        '
        'cBox_Mes
        '
        Me.cBox_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBox_Mes.FormattingEnabled = True
        Me.cBox_Mes.Location = New System.Drawing.Point(196, 134)
        Me.cBox_Mes.Name = "cBox_Mes"
        Me.cBox_Mes.Size = New System.Drawing.Size(121, 23)
        Me.cBox_Mes.TabIndex = 23
        '
        'cBox_Anio
        '
        Me.cBox_Anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBox_Anio.FormattingEnabled = True
        Me.cBox_Anio.Location = New System.Drawing.Point(196, 105)
        Me.cBox_Anio.Name = "cBox_Anio"
        Me.cBox_Anio.Size = New System.Drawing.Size(121, 23)
        Me.cBox_Anio.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(113, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(111, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Seleccione el mes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 15)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Seleccione el año"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(143, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(172, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "*"
        '
        'pgBar_Exp
        '
        Me.pgBar_Exp.Location = New System.Drawing.Point(196, 174)
        Me.pgBar_Exp.Name = "pgBar_Exp"
        Me.pgBar_Exp.Size = New System.Drawing.Size(217, 23)
        Me.pgBar_Exp.TabIndex = 1
        '
        'btn_Ruta
        '
        Me.btn_Ruta.Location = New System.Drawing.Point(418, 73)
        Me.btn_Ruta.Name = "btn_Ruta"
        Me.btn_Ruta.Size = New System.Drawing.Size(24, 21)
        Me.btn_Ruta.TabIndex = 4
        Me.btn_Ruta.Text = "..."
        Me.btn_Ruta.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(313, 203)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(100, 26)
        Me.btn_Cancelar.TabIndex = 2
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'txtBox_Carpeta
        '
        Me.txtBox_Carpeta.Enabled = False
        Me.txtBox_Carpeta.Location = New System.Drawing.Point(196, 73)
        Me.txtBox_Carpeta.Name = "txtBox_Carpeta"
        Me.txtBox_Carpeta.Size = New System.Drawing.Size(217, 21)
        Me.txtBox_Carpeta.TabIndex = 3
        '
        'btn_Exportar
        '
        Me.btn_Exportar.Location = New System.Drawing.Point(207, 203)
        Me.btn_Exportar.Name = "btn_Exportar"
        Me.btn_Exportar.Size = New System.Drawing.Size(100, 26)
        Me.btn_Exportar.TabIndex = 1
        Me.btn_Exportar.Text = "Exportar"
        Me.btn_Exportar.UseVisualStyleBackColor = True
        '
        'cmBox_Req
        '
        Me.cmBox_Req.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmBox_Req.FormattingEnabled = True
        Me.cmBox_Req.Location = New System.Drawing.Point(196, 41)
        Me.cmBox_Req.Name = "cmBox_Req"
        Me.cmBox_Req.Size = New System.Drawing.Size(217, 23)
        Me.cmBox_Req.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Seleccione una carpeta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione una Tabla"
        '
        'bgWork_Exp
        '
        Me.bgWork_Exp.WorkerReportsProgress = True
        '
        'frm_ExportarArchivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 259)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_ExportarArchivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APM - Exportar Tabla"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmBox_Req As System.Windows.Forms.ComboBox
    Friend WithEvents txtBox_Carpeta As System.Windows.Forms.TextBox
    Friend WithEvents btn_Exportar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Ruta As System.Windows.Forms.Button
    Friend WithEvents pgBar_Exp As System.Windows.Forms.ProgressBar
    Friend WithEvents bgWork_Exp As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cBox_Mes As System.Windows.Forms.ComboBox
    Friend WithEvents cBox_Anio As System.Windows.Forms.ComboBox
End Class
