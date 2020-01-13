Imports APM_CLASS
Imports APM_DATOS
Imports System.IO

Public Class frm_CargarRequerimiento
    Private flag As Boolean
    Private ruta_Carpeta As String
    Private requerimiento As String
    Private extension As String

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_CargarRequerimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            flag = False
            ruta_Carpeta = String.Empty
            requerimiento = String.Empty
            extension = String.Empty
            Inicializa_Controles()
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar la aplicación." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWork_Carga.DoWork
        Try
            Dim clsReq As New ClsRequerimiento
            Dim clsServ As New ClsServicios
            'Dim flagTemp As Boolean = True
            Dim resultado As Integer
            Dim mensajesError As New DataTable
            Dim mensajeShow As String = String.Empty

            flag = False

            'If clsServ.NoNecesitaTemporal(requerimiento.ToUpper) Then
            '    flagTemp = False
            'End If

            resultado = clsReq.CargarRequerimiento(ruta_Carpeta, requerimiento, extension, mensajesError)

            If resultado = 1 Then 'Se cargó correctamente
                flag = True
            ElseIf resultado = 2 Then 'Existe mas de una Hoja en el excel
                flag = False
                MessageBox.Show("El archivo Excel debe contener sólo una hoja." + Environment.NewLine + "Tener en cuenta que tampoco pueden existir hojas ocultas.", "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf resultado = 3 Then 'La estructura no es la correcta
                flag = False
                MessageBox.Show("Las columnas del archivo Excel no coinciden con las columnas de la tabla en la base de datos." + Environment.NewLine + "El orden y nombre de las columnas deben ser iguales.", "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf resultado = 4 Then 'Error en la validacion de la informacion del requerimiento
                MessageBox.Show("No se pudo cargar el archivo correctamente." + Environment.NewLine + "Para ver el detalle por favor abrir el documento Excel guardado en \Documents\APM Terminals\Carga - Errores.", "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            'Throw ex
            MessageBox.Show("No se pudo cargar el archivo correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWork_Carga.RunWorkerCompleted
        Try
            pgBar_Carga.Visible = False
            If flag Then
                MessageBox.Show("Se llevó a cabo el proceso con éxito", "APM Terminals - Cargar Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Show()
                'MessageBox.Show("No se pudo cargar el archivo correctamente.", "APM Terminals - Exportación de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.btn_Cargar.Enabled = True
            Me.btn_Cancelar.Enabled = True
            Me.cBox_Req.Enabled = True
            Me.btn_SelecArch.Enabled = True
            Me.txtBox_RutaArch.Text = String.Empty
            lbl_ExtEx.Text = String.Empty
            lbl_VerEx.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar el archivo correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Inicializa_Controles()
        Try
            Cargar_Requerimientos()
            lbl_VerEx.Text = String.Empty
            lbl_ExtEx.Text = String.Empty
            pgBar_Carga.Style = ProgressBarStyle.Marquee
            pgBar_Carga.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cargar_Requerimientos()
        Try
            cBox_Req.DataSource = New ClsRequerimiento().Listar_Requerimiento(1)
            cBox_Req.DisplayMember = "Descripcion"
            cBox_Req.ValueMember = "Requerimiento"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_SelecArch_Click(sender As Object, e As EventArgs) Handles btn_SelecArch.Click
        Try
            Dim ofd_BuscarReque As OpenFileDialog
            Dim extension As String
            ofd_BuscarReque = New OpenFileDialog()
            ofd_BuscarReque.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            ofd_BuscarReque.Title = "Seleccione el archivo"

            If (ofd_BuscarReque.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                txtBox_RutaArch.Text = ofd_BuscarReque.FileName.ToString
                extension = Path.GetExtension(ofd_BuscarReque.FileName)

                Select Case extension
                    Case ".xls"
                        lbl_VerEx.Text = "Excel 97-03"
                        Exit Select
                    Case ".xlsx"
                        lbl_VerEx.Text = "Excel 2007 o posterior"
                        Exit Select
                    Case ".xlsm"
                        lbl_VerEx.Text = "Excel 2007 o posterior"
                        Exit Select
                End Select
                lbl_ExtEx.Text = extension
            Else
                txtBox_RutaArch.Text = String.Empty
                lbl_ExtEx.Text = String.Empty
                lbl_VerEx.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar el archivo." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Cargar_Click(sender As Object, e As EventArgs) Handles btn_Cargar.Click
        Dim clsReq_DA As New ClsRequerimiento(), dt As DataTable
        Try
            If ValidaInputs() Then
                ruta_Carpeta = txtBox_RutaArch.Text
                requerimiento = cBox_Req.SelectedValue.ToString
                extension = lbl_ExtEx.Text
                pgBar_Carga.Visible = True
                btn_Cargar.Enabled = False
                btn_Cancelar.Enabled = False
                cBox_Req.Enabled = False
                btn_SelecArch.Enabled = False

                'bgWork_Carga.RunWorkerAsync()
                clsReq_DA.CargarRequerimiento(txtBox_RutaArch.Text, cBox_Req.SelectedValue.ToString, lbl_ExtEx.Text, dt)
                'MessageBox.Show("Se llevó a cabo el proceso con exito", "APM Terminals - Proceso de carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Catch ex As Exception
            MessageBox.Show("No se pudo cargar el archivo correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidaInputs() As Boolean
        If (cBox_Req.SelectedValue.ToString.Trim.Length > 0) And (lbl_ExtEx.Text.Trim.Length > 0) And (txtBox_RutaArch.Text.Trim.Length > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class