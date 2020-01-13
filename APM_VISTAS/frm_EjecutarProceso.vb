Imports APM_CLASS
Imports APM_DATOS
Imports System.Data.SqlClient
Imports System.Data
Public Class frm_EjecutarProceso
    Dim apm As New Connect
    Dim oServicios As New ClsServicios
    Private Property anio As Integer
    Private Property mes As Integer
    Private Property flag As Boolean

    Private Sub frm_EjecutarProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            flag = False
            anio = Date.Today.Year
            mes = Date.Today.Month
            Inicializa_Controles()
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar la aplicación." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidaInputs() As Boolean
        If cboAño.SelectedIndex >= 0 And cboMes.SelectedIndex >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            If ValidaInputs() Then
                anio = cboAño.SelectedItem
                mes = Convert.ToDateTime("01-" + cboMes.SelectedItem + "-2011").Month
                cboAño.Enabled = False
                cboMes.Enabled = False
                btnGenerar.Enabled = False
                btnCancelar.Enabled = False
                pgBar_Generar.Visible = True
                bgWork_Generar.RunWorkerAsync()
            Else
                MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo ejecutar el proceso correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWork_Generar.DoWork
        Try
            Dim clsServ As New ClsServicios
            Dim mensajesError As New DataTable
            Dim mensajeShow As String = String.Empty

            flag = False

            'EJECUTO LAS VALIDACIONES
            mensajesError = clsServ.Validar_Proceso(anio, mes)
            If mensajesError.Rows.Count > 0 Then ' Hay error
                'MUESTRO EL MENSAJE DE ERROR
                mensajeShow = "¿Está seguro que desea proseguir?" + Environment.NewLine
                For Each row As DataRow In mensajesError.Rows
                    mensajeShow = mensajeShow + Environment.NewLine + row.Item("MensajeError")
                Next row

                Dim result As Integer = MessageBox.Show(mensajeShow, "APM Terminals - Proceso GyP", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    clsServ.Ejecutar_Proceso(anio, mes)
                    flag = True
                End If
            Else
                clsServ.Ejecutar_Proceso(anio, mes)
                flag = True
            End If

            'clsServ.Ejecutar_Proceso(anio, mes)
            'flag = True
        Catch ex As Exception
            MessageBox.Show("No se pudo ejecutar el proceso correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWork_Generar.RunWorkerCompleted
        Try
            pgBar_Generar.Visible = False
            If flag Then
                MessageBox.Show("Se llevó a cabo el proceso con éxito", "APM Terminals - Proceso GyP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Show()
                'MessageBox.Show("No se pudo realizar la ejecución del proceso", "APM Terminals - Proceso GyP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.btnCancelar.Enabled = True
            Me.btnGenerar.Enabled = True
            Me.cboMes.Enabled = True
            Me.cboAño.Enabled = True
        Catch ex As Exception
            MessageBox.Show("No se pudo ejecutar el proceso correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Inicializa_Controles()
        Try
            Cargar_MesAnio()
            pgBar_Generar.Style = ProgressBarStyle.Marquee
            pgBar_Generar.Visible = False
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
            cboMes.DataSource = meses
            cboMes.SelectedIndex = -1

            'CARGO LOS AÑOS
            Dim cant As Integer = 15
            Dim anios(cant) As Integer
            For i = 0 To cant
                anios(i) = i + 2010
            Next
            cboAño.DataSource = anios
            cboAño.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class