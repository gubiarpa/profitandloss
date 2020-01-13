Imports APM_CLASS

Public Class frm_EliminarRequerimiento
    Private Property requerimiento As String
    Private Property anio As Integer
    Private Property mes As Integer
    Private Property flag As Boolean

    Private Sub frm_EliminarRequerimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            flag = False
            requerimiento = String.Empty
            anio = Date.Today.Year
            mes = Date.Today.Month
            Inicializa_Controles()
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar la aplicación." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Inicializa_Controles()
        Try
            Cargar_Requerimientos()
            Cargar_MesAnio()
            pgBar_Eli.Style = ProgressBarStyle.Marquee
            pgBar_Eli.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cargar_Requerimientos()
        Try
            cBox_Req.DataSource = New ClsRequerimiento().Listar_Requerimiento(3)
            cBox_Req.DisplayMember = "Descripcion"
            cBox_Req.ValueMember = "Requerimiento"
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

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Function ValidaInputs(ByRef flagReq As Boolean) As Boolean
        Try
            Dim req As String = cBox_Req.SelectedValue.ToString.ToUpper
            Dim clsServ As New ClsServicios
            Dim flagTemp As Boolean = clsServ.NoNecesitaTemporal(req)

            If (cBox_Anio.SelectedIndex >= 0) And (cBox_Mes.SelectedIndex >= 0) And (Not flagTemp) Then
                flagReq = True
                Return True
            Else
                If (cBox_Anio.SelectedIndex = -1) And (cBox_Mes.SelectedIndex = -1) And (flagTemp) Then
                    flagReq = False
                    Return True
                Else
                    Return False
                End If
            End If

            'If (cBox_Anio.SelectedIndex >= 0) And (cBox_Mes.SelectedIndex >= 0) And (req <> "CASE2CUENTAS") And (req <> "CODIGOSERVICIO") Then
            '    flagReq = True
            '    Return True
            'Else
            '    If (cBox_Anio.SelectedIndex = -1) And (cBox_Mes.SelectedIndex = -1) And ((req = "CASE2CUENTAS") Or (req = "CODIGOSERVICIO")) Then
            '        flagReq = False
            '        Return True
            '    Else
            '        Return False
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try    
    End Function

    Public Function ExisteInformacion(ByVal anio As Integer, ByVal mes As Integer, ByVal requerimiento As String, ByVal flagReq As Boolean) As Boolean
        Try
            Dim clsServicio As New ClsServicios
            Dim cantReg As Integer

            cantReg = clsServicio.CalculaCount(requerimiento, anio, mes, flagReq)
            If cantReg > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        Try
            Dim flagReq As Boolean = False
            If ValidaInputs(flagReq) Then
                If flagReq Then
                    anio = cBox_Anio.SelectedItem
                    mes = Convert.ToDateTime("01-" + cBox_Mes.SelectedItem + "-2011").Month
                Else
                    anio = Date.Today.Year
                    mes = Date.Today.Month
                End If
                requerimiento = cBox_Req.SelectedValue.ToString

                If ExisteInformacion(anio, mes, requerimiento, flagReq) Then
                    'ELIMINO
                    cBox_Req.Enabled = False
                    cBox_Mes.Enabled = False
                    cBox_Anio.Enabled = False
                    btn_Eliminar.Enabled = False
                    btn_Cancelar.Enabled = False
                    pgBar_Eli.Visible = True
                    bgWork_Elim.RunWorkerAsync()
                Else
                    If flagReq Then
                        MessageBox.Show("No existe información en la base de datos para el año y mes seleccionados.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("No existe información en la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    'MANO MENSAJE DICIENDO QUE NO HAY NADA QUE ELIMINAR
                End If
                'cBox_Req.Enabled = False
                'cBox_Mes.Enabled = False
                'cBox_Anio.Enabled = False
                'btn_Eliminar.Enabled = False
                'btn_Cancelar.Enabled = False
                'pgBar_Eli.Visible = True
                'bgWork_Elim.RunWorkerAsync()
                'Dim req As New ClsRequerimiento
                'Dim iMonthNo = Convert.ToDateTime("01-" + cBox_Mes.SelectedItem + "-2011").Month
                'req.EliminarRequerimiento(requerimiento, anio, mes)
            Else
                MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar el Requerimiento correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWork_Elim.DoWork
        Try
            Dim clsReq As New ClsRequerimiento

            flag = False
            clsReq.EliminarRequerimiento(requerimiento, anio, mes)
            flag = True
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar el Requerimiento correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWork_Elim.RunWorkerCompleted
        Try
            pgBar_Eli.Visible = False
            If flag Then
                MessageBox.Show("Se llevó a cabo el proceso con éxito", "APM Terminals - Eliminar Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Show()
                'MessageBox.Show("No se pudo realizar la eliminación del Requerimiento", "APM Terminals - Eliminar Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.btn_Eliminar.Enabled = True
            Me.btn_Cancelar.Enabled = True
            Me.cBox_Req.Enabled = True
            Me.cBox_Anio.Enabled = True
            Me.cBox_Mes.Enabled = True
            cBox_Req.SelectedIndex = 0
            cBox_Anio.SelectedIndex = -1
            cBox_Mes.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar el Requerimiento correctamente." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cBox_Req_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBox_Req.SelectedIndexChanged
        Try
            Dim clsServ As New ClsServicios
            Dim req As String = cBox_Req.SelectedValue.ToString.ToUpper
            Dim flagTemp As Boolean = clsServ.NoNecesitaTemporal(req)

            If (flagTemp) Then
                cBox_Anio.Enabled = False
                cBox_Mes.Enabled = False
                cBox_Anio.SelectedIndex = -1
                cBox_Mes.SelectedIndex = -1
            Else
                cBox_Anio.Enabled = True
                cBox_Mes.Enabled = True
            End If

            'If (cBox_Req.SelectedValue.ToString.ToUpper = "CASE2CUENTAS") Or (cBox_Req.SelectedValue.ToString.ToUpper = "CODIGOSERVICIO") Then
            '    cBox_Anio.Enabled = False
            '    cBox_Mes.Enabled = False
            '    cBox_Anio.SelectedIndex = -1
            '    cBox_Mes.SelectedIndex = -1
            'Else
            '    cBox_Anio.Enabled = True
            '    cBox_Mes.Enabled = True
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class