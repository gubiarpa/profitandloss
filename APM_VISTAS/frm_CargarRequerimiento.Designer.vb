<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CargarRequerimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CargarRequerimiento))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pgBar_Carga = New System.Windows.Forms.ProgressBar()
        Me.lbl_ExtEx = New System.Windows.Forms.Label()
        Me.lbl_VerEx = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_SelecArch = New System.Windows.Forms.Button()
        Me.txtBox_RutaArch = New System.Windows.Forms.TextBox()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Cargar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cBox_Req = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgWork_Carga = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.pgBar_Carga)
        Me.GroupBox1.Controls.Add(Me.lbl_ExtEx)
        Me.GroupBox1.Controls.Add(Me.lbl_VerEx)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btn_SelecArch)
        Me.GroupBox1.Controls.Add(Me.txtBox_RutaArch)
        Me.GroupBox1.Controls.Add(Me.btn_Cancelar)
        Me.GroupBox1.Controls.Add(Me.btn_Cargar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cBox_Req)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 213)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cargar Tabla"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(132, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(170, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "*"
        '
        'pgBar_Carga
        '
        Me.pgBar_Carga.Location = New System.Drawing.Point(196, 147)
        Me.pgBar_Carga.Name = "pgBar_Carga"
        Me.pgBar_Carga.Size = New System.Drawing.Size(206, 23)
        Me.pgBar_Carga.TabIndex = 8
        '
        'lbl_ExtEx
        '
        Me.lbl_ExtEx.AutoSize = True
        Me.lbl_ExtEx.Location = New System.Drawing.Point(193, 129)
        Me.lbl_ExtEx.Name = "lbl_ExtEx"
        Me.lbl_ExtEx.Size = New System.Drawing.Size(0, 15)
        Me.lbl_ExtEx.TabIndex = 7
        '
        'lbl_VerEx
        '
        Me.lbl_VerEx.AutoSize = True
        Me.lbl_VerEx.Location = New System.Drawing.Point(193, 105)
        Me.lbl_VerEx.Name = "lbl_VerEx"
        Me.lbl_VerEx.Size = New System.Drawing.Size(0, 15)
        Me.lbl_VerEx.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Version de Excel"
        '
        'btn_SelecArch
        '
        Me.btn_SelecArch.Location = New System.Drawing.Point(419, 73)
        Me.btn_SelecArch.Name = "btn_SelecArch"
        Me.btn_SelecArch.Size = New System.Drawing.Size(24, 21)
        Me.btn_SelecArch.TabIndex = 4
        Me.btn_SelecArch.Text = "..."
        Me.btn_SelecArch.UseVisualStyleBackColor = True
        '
        'txtBox_RutaArch
        '
        Me.txtBox_RutaArch.Enabled = False
        Me.txtBox_RutaArch.Location = New System.Drawing.Point(196, 73)
        Me.txtBox_RutaArch.Name = "txtBox_RutaArch"
        Me.txtBox_RutaArch.Size = New System.Drawing.Size(217, 21)
        Me.txtBox_RutaArch.TabIndex = 3
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(302, 176)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(100, 26)
        Me.btn_Cancelar.TabIndex = 10
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'btn_Cargar
        '
        Me.btn_Cargar.Location = New System.Drawing.Point(196, 176)
        Me.btn_Cargar.Name = "btn_Cargar"
        Me.btn_Cargar.Size = New System.Drawing.Size(100, 26)
        Me.btn_Cargar.TabIndex = 9
        Me.btn_Cargar.Text = "Cargar"
        Me.btn_Cargar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Seleccione un archivo"
        '
        'cBox_Req
        '
        Me.cBox_Req.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBox_Req.FormattingEnabled = True
        Me.cBox_Req.Location = New System.Drawing.Point(196, 41)
        Me.cBox_Req.Name = "cBox_Req"
        Me.cBox_Req.Size = New System.Drawing.Size(217, 23)
        Me.cBox_Req.TabIndex = 1
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
        'bgWork_Carga
        '
        Me.bgWork_Carga.WorkerReportsProgress = True
        '
        'frm_CargarRequerimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 230)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_CargarRequerimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APM - Cargar Tabla"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cBox_Req As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_ExtEx As System.Windows.Forms.Label
    Friend WithEvents lbl_VerEx As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_SelecArch As System.Windows.Forms.Button
    Friend WithEvents txtBox_RutaArch As System.Windows.Forms.TextBox
    Friend WithEvents pgBar_Carga As System.Windows.Forms.ProgressBar
    Friend WithEvents bgWork_Carga As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
