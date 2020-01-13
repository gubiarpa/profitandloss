Imports APM_CLASS
Public Class frm_Mantenimiento_Cuenta_Ingreso

    Private Sub frm_Mantenimiento_Cuenta_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsCuentaIng As New clsCuentasIngreso
            dgv_Cuentas.DataSource = clsCuentaIng.ConsultarCuenta(0)
        Catch ex As Exception
            Throw ex
        End Try      
    End Sub

    Private Sub tsb_Modificar_Click(sender As Object, e As EventArgs) Handles tsb_Modificar.Click
        Try
            Dim frmAC As New frm_AgregarCuentaIngreso

            frmAC.tipoAccion = 2 'MODIFICAR
            frmAC.IDCuenta = dgv_Cuentas.Item(0, dgv_Cuentas.CurrentRow.Index).Value
            'frmAC.MdiParent = Me.MdiParent
            frmAC.Text = "APM - Modificar Cuenta"
            frmAC.ShowDialog()
            frmAC.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsb_Agregar_Click(sender As Object, e As EventArgs) Handles tsb_Agregar.Click
        Try
            Dim frmAC As New frm_AgregarCuentaIngreso

            frmAC.tipoAccion = 1 'AGREGAR
            frmAC.IDCuenta = 0
            frmAC.CuentaOrig = String.Empty
            frmAC.DriverOrig = 0
            'frmAC.MdiParent = Me.MdiParent
            frmAC.Text = "APM - Agregar Cuenta"
            frmAC.ShowDialog()
            frmAC.Dispose()
        Catch ex As Exception
            Throw ex
        End Try   
    End Sub

    Private Sub tsb_Eliminar_Click(sender As Object, e As EventArgs) Handles tsb_Eliminar.Click
        Try
            If dgv_Cuentas.RowCount > 0 Then
                Dim result As Integer = MessageBox.Show("¿Está seguro que desea eliminar la cuenta seleccionada?", "APM Terminals - Eliminar Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim IDCuenta = dgv_Cuentas.Item(0, dgv_Cuentas.CurrentRow.Index).Value
                    Dim clsCta As New clsCuentasIngreso

                    clsCta.EliminarCuenta(IDCuenta)
                    dgv_Cuentas.DataSource = clsCta.ConsultarCuenta(0)
                    MessageBox.Show("Se eliminó la cuenta con éxito.", "APM Terminals - Eliminar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try      
    End Sub

    Private Sub tsb_Salir_Click(sender As Object, e As EventArgs) Handles tsb_Salir.Click
        Me.Close()
    End Sub
End Class