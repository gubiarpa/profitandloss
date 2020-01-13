Imports APM_CLASS

Public Class frm_ExportarArchivo
    Private flag As Boolean
    Private ruta_Carpeta As String
    Private requerimiento As String
    Private Property anio As Integer
    Private Property mes As Integer
    Private Sub frm_ExportarArchivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            flag = False
            ruta_Carpeta = String.Empty
            requerimiento = String.Empty
            anio = Date.Today.Year
            mes = Date.Today.Month
            Inicializa_Controles()
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar la aplicación." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWork_Exp.DoWork
        Try
            Dim clsExp As New ClsExportar
            flag = False
            clsExp.Exportar_Requerimiento(ruta_Carpeta, requerimiento, anio, mes)
            flag = True
        Catch ex As Exception
            MessageBox.Show("No se pudo exportar el Requerimiento correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWork_Exp.RunWorkerCompleted
        Try
            pgBar_Exp.Visible = False
            If flag Then
                MessageBox.Show("Se llevó a cabo el proceso con éxito", "APM Terminals - Exportación de requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Show()
                ' MessageBox.Show("No se pudo realizar la epxortación", "APM Terminals - Exportación de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.btn_Exportar.Enabled = True
            Me.btn_Cancelar.Enabled = True
            Me.cmBox_Req.Enabled = True
            Me.btn_Ruta.Enabled = True
            txtBox_Carpeta.Text = String.Empty
            cBox_Anio.SelectedIndex = -1
            cBox_Mes.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("No se pudo exportar el Requerimiento correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Inicializa_Controles()
        Try
            Cargar_Requerimientos()
            Cargar_MesAnio()
            txtBox_Carpeta.Text = String.Empty
            pgBar_Exp.Style = ProgressBarStyle.Marquee
            pgBar_Exp.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cargar_MesAnio()
        Try
            'CARGO LOS MESES
            Dim datetimeFormat = Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat
            Dim meses_aux() As String
            Dim meses(11) As String
            Dim anioAct = Date.Today.Year
            Dim mesAct = Date.Today.Month
            meses_aux = datetimeFormat.MonthNames()
            For i = 0 To 11
                meses(i) = meses_aux(i).ToUpper
            Next
            cBox_Mes.DataSource = meses
            cBox_Mes.SelectedIndex = -1

            'CARGO LOS AÑOS
            Dim cant As Integer = 15
            Dim anios(cant) As Integer
            For i = 0 To cant
                anios(i) = i + 2010
            Next
            cBox_Anio.DataSource = anios
            cBox_Anio.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cargar_Requerimientos()
        Try
            cmBox_Req.DataSource = New ClsRequerimiento().Listar_Requerimiento(2)
            cmBox_Req.DisplayMember = "Descripcion"
            cmBox_Req.ValueMember = "Requerimiento"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_Ruta_Click(sender As Object, e As EventArgs) Handles btn_Ruta.Click
        Try
            Dim ofd_BuscarRuta As FolderBrowserDialog

            ofd_BuscarRuta = New FolderBrowserDialog()
            If (ofd_BuscarRuta.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                txtBox_Carpeta.Text = ofd_BuscarRuta.SelectedPath.ToString
            Else
                txtBox_Carpeta.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar la carpeta." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Exportar_Click(sender As Object, e As EventArgs) Handles btn_Exportar.Click
        'Dim clsExp As New ClsExportar
        Try
            If ValidaInputs() Then
                ruta_Carpeta = txtBox_Carpeta.Text
                requerimiento = cmBox_Req.SelectedValue.ToString
                Dim req As String = cmBox_Req.SelectedValue.ToString.ToUpper
                Dim clsServ As New ClsServicios
                Dim flagTemp As Boolean = clsServ.NoNecesitaTemporal(req)

                If (Not flagTemp) Then
                    anio = cBox_Anio.SelectedItem
                    mes = Convert.ToDateTime("01-" + cBox_Mes.SelectedItem + "-2011").Month
                End If

                'If (req <> "CASE2CUENTAS") And (req <> "CODIGOSERVICIO") Then
                '    anio = cBox_Anio.SelectedItem
                '    mes = Convert.ToDateTime("01-" + cBox_Mes.SelectedItem + "-2011").Month
                'End If

                pgBar_Exp.Visible = True
                Me.btn_Exportar.Enabled = False
                Me.btn_Cancelar.Enabled = False
                Me.cmBox_Req.Enabled = False
                Me.btn_Ruta.Enabled = False
                bgWork_Exp.RunWorkerAsync()
                'clsExp.Exportar_Requerimiento(txtBox_Carpeta.Text, cmBox_Req.SelectedValue.ToString)
            Else
                MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo exportar el Requerimiento correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidaInputs() As Boolean
        Dim result As Boolean = False
        Dim req As String = cmBox_Req.SelectedValue.ToString.ToUpper
        Dim flagMA As Boolean = True
        Dim clsServ As New ClsServicios
        Dim flagTemp As Boolean = clsServ.NoNecesitaTemporal(req)

        If (flagTemp) Then
            flagMA = False
        End If

        'If (req = "CASE2CUENTAS") Or (req = "CODIGOSERVICIO") Then
        '    flagMA = False
        'End If

        If ((cmBox_Req.SelectedValue.ToString.Length > 0) And (txtBox_Carpeta.Text.Length > 0) And (cBox_Anio.SelectedIndex >= 0) And (cBox_Mes.SelectedIndex >= 0) And (flagMA)) _
            Or ((cmBox_Req.SelectedValue.ToString.Length > 0) And (txtBox_Carpeta.Text.Length > 0) And (Not flagMA)) Then
            result = True
        End If

        Return result
    End Function

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub cmBox_Req_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBox_Req.SelectedIndexChanged
        Dim req As String
        req = cmBox_Req.SelectedValue.ToString.ToUpper()
        Dim clsServ As New ClsServicios
        Dim flagTemp As Boolean = clsServ.NoNecesitaTemporal(req)

        If (flagTemp) Then
            cBox_Anio.Enabled = False
            cBox_Anio.SelectedIndex = -1
            cBox_Mes.Enabled = False
            cBox_Mes.SelectedIndex = -1
        Else
            cBox_Anio.Enabled = True
            cBox_Anio.SelectedIndex = -1
            cBox_Mes.Enabled = True
            cBox_Mes.SelectedIndex = -1
        End If

        'If (req = "CASE2CUENTAS") Or (req = "CODIGOSERVICIO") Then
        '    cBox_Anio.Enabled = False
        '    cBox_Anio.SelectedIndex = -1
        '    cBox_Mes.Enabled = False
        '    cBox_Mes.SelectedIndex = -1
        'Else
        '    cBox_Anio.Enabled = True
        '    cBox_Anio.SelectedIndex = -1
        '    cBox_Mes.Enabled = True
        '    cBox_Mes.SelectedIndex = -1
        'End If
    End Sub
End Class