Imports APM_CLASS

Public Class frm_Mantenimiento_CuentasContables
    'Public Function ObtieneCuentaSeleccionada() As String
    '    Try
    '        Return
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Private Sub tsb_Salir_Click(sender As Object, e As EventArgs) Handles tsb_Salir.Click
        Me.Close()
    End Sub

    Private Sub tsb_Agregar_Click(sender As Object, e As EventArgs) Handles tsb_Agregar.Click
        Try
            Dim frmAgregar As New frm_AgregarCuentaContable
            frmAgregar.tipoAccion = 1
            'frmAgregar.MdiParent = Me.MdiParent
            frmAgregar.ShowDialog()
            frmAgregar.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Try
            Dim cuenta As String
            Dim tipoConcepto As String
            Dim concepto As String
            Dim año As Integer
            Dim mes As Integer
            Dim clsCta As New ClsCuentaContable
            Dim cantParam As Integer = 0

            cuenta = txt_Cuenta.Text.Trim
            cantParam = cantParam + 1

            If cbo_TipConcep.SelectedIndex >= 0 Then
                tipoConcepto = cbo_TipConcep.SelectedValue.ToString.Trim
                cantParam = cantParam + 1
            Else
                tipoConcepto = String.Empty
            End If

            If cbo_Concep.SelectedIndex >= 0 Then
                concepto = cbo_Concep.SelectedValue.ToString.Trim
                cantParam = cantParam + 1
            Else
                concepto = String.Empty
            End If

            If cbo_Año.SelectedIndex >= 0 Then
                año = cbo_Año.SelectedValue
                cantParam = cantParam + 1
            Else
                año = 0
            End If

            If cbo_Mes.SelectedIndex >= 0 Then
                mes = Convert.ToDateTime("01-" + cbo_Mes.SelectedItem + "-2011").Month
                cantParam = cantParam + 1
            Else
                mes = 0
            End If

            dgv_CtasContables.DataSource = clsCta.BuscaCuentasContables(cuenta, tipoConcepto, concepto, año, mes, cantParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgv_CtasContables_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgv_CtasContables.DataBindingComplete
        With dgv_CtasContables
            .Columns("SubConcepto").Visible = False
            .Columns("Descripción").Visible = False
        End With
    End Sub

    Private Sub frm_Mantenimiento_CuentasContables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cargar_TipoConcepto()
            Cargar_MesAnio()
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar la aplicación." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            cbo_Mes.DataSource = meses
            cbo_Mes.SelectedIndex = -1

            'CARGO LOS AÑOS
            Dim cant As Integer = 15
            Dim anios(cant) As Integer
            For i = 0 To cant
                anios(i) = i + 2010
            Next
            cbo_Año.DataSource = anios
            cbo_Año.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Cargar_TipoConcepto()
        Try
            Dim clsCta As New ClsCuentaContable
            cbo_TipConcep.DataSource = clsCta.Obtiene_TiposConcepto()
            cbo_TipConcep.DisplayMember = "TipoConcepto"
            cbo_TipConcep.ValueMember = "TipoConcepto"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbo_TipConcep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_TipConcep.SelectedIndexChanged
        Try
            Dim clsCta As New ClsCuentaContable
            Dim tipoConcepto As String

            tipoConcepto = cbo_TipConcep.SelectedValue.ToString.Trim
            cbo_Concep.DataSource = clsCta.Obtiene_Conceptos(tipoConcepto)
            cbo_Concep.DisplayMember = "Concepto"
            cbo_Concep.ValueMember = "Concepto"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsb_Eliminar_Click(sender As Object, e As EventArgs) Handles tsb_Eliminar.Click
        Try
            If dgv_CtasContables.RowCount > 0 Then
                Dim result As Integer = MessageBox.Show("¿Está seguro que desea eliminar la cuenta seleccionada?", "APM Terminals - Eliminar Cuenta Contable", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim clsCta As New ClsCuentaContable
                    Dim año = dgv_CtasContables.Item(0, dgv_CtasContables.CurrentRow.Index).Value
                    Dim mes = dgv_CtasContables.Item(1, dgv_CtasContables.CurrentRow.Index).Value
                    Dim cuenta = dgv_CtasContables.Item(2, dgv_CtasContables.CurrentRow.Index).Value
                    'Dim tipo = dgv_CtasContables.Item(3, dgv_CtasContables.CurrentRow.Index).Value
                    'Dim concepto = dgv_CtasContables.Item(4, dgv_CtasContables.CurrentRow.Index).Value
                    'Dim subConcepto = dgv_CtasContables.Item(5, dgv_CtasContables.CurrentRow.Index).Value
                    'Dim descripcion = dgv_CtasContables.Item(6, dgv_CtasContables.CurrentRow.Index).Value

                    clsCta.EliminaCuentaContable(año, mes, cuenta)

                    MessageBox.Show("Se eliminó la cuenta con éxito.", "APM Terminals - Eliminar Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btn_Buscar.PerformClick()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsb_Modificar_Click(sender As Object, e As EventArgs) Handles tsb_Modificar.Click
        Try
            If (dgv_CtasContables.RowCount > 0) Then
                Dim frmAgregar As New frm_AgregarCuentaContable
                frmAgregar.tipoAccion = 2
                'frmAgregar.MdiParent = Me.MdiParent

                frmAgregar.Año = dgv_CtasContables.Item(0, dgv_CtasContables.CurrentRow.Index).Value
                frmAgregar.Mes = dgv_CtasContables.Item(1, dgv_CtasContables.CurrentRow.Index).Value
                frmAgregar.Cuenta = dgv_CtasContables.Item(2, dgv_CtasContables.CurrentRow.Index).Value
                frmAgregar.TipoConcepto = dgv_CtasContables.Item(3, dgv_CtasContables.CurrentRow.Index).Value
                frmAgregar.Concepto = dgv_CtasContables.Item(4, dgv_CtasContables.CurrentRow.Index).Value
                frmAgregar.SubConcepto = dgv_CtasContables.Item(5, dgv_CtasContables.CurrentRow.Index).Value
                frmAgregar.Descripcion = dgv_CtasContables.Item(6, dgv_CtasContables.CurrentRow.Index).Value

                frmAgregar.ShowDialog()
                frmAgregar.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Function tsb_Seleccionar_Click() As String Handles tsb_Seleccionar.Click
    '    'Try
    '    '    If parametro = 1 Then
    '    '        MessageBox.Show("Se seleccionó la cuenta con éxito." + Environment.NewLine + "Si no desea buscar otra cuenta, por favor cierre la ventana para regresar al menú anterior.", "APM Terminals - Seleccionar Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    '        Return dgv_CtasContables.Item(2, dgv_CtasContables.CurrentRow.Index).Value.ToString
    '    '    Else
    '    '        Return dgv_CtasContables.Item(2, dgv_CtasContables.CurrentRow.Index).Value.ToString
    '    '    End If
    '    'Catch ex As Exception
    '    '    Throw ex
    '    'End Try
    'End Function


    Public Function tsb_Seleccionar_Click(sender As Object, e As EventArgs) As String Handles tsb_Seleccionar.Click
        Try
            If sender.ToString = "Seleccionar" Then
                MessageBox.Show("Se seleccionó la cuenta con éxito." + Environment.NewLine + "Si no desea buscar otra cuenta, por favor cierre la ventana para regresar al menú anterior.", "APM Terminals - Seleccionar Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return dgv_CtasContables.Item(2, dgv_CtasContables.CurrentRow.Index).Value.ToString
            Else
                Return dgv_CtasContables.Item(2, dgv_CtasContables.CurrentRow.Index).Value.ToString
            End If
            Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class