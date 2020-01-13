Imports APM_CLASS
Imports APM_DATOS
Public Class frm_AgregarCuentaIngreso
    Public Property tipoAccion As Integer
    Public Property IDCuenta As Integer
    Public Property CuentaOrig As String
    Public Property DriverOrig As Integer

    Private Sub frm_AgregarCuentaIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsCta As New clsCuentasIngreso
            Dim dt As New DataTable

            cboDriver.DataSource = clsCta.ListarDrivers()
            cboDriver.DisplayMember = "Driver"
            cboDriver.ValueMember = "Num"

            If tipoAccion = 2 Then 'MODIFICAR
                btn_BuscarCuenta.Visible = False
                txtCuenta.Enabled = False
                dt = clsCta.ConsultarCuenta(1, IDCuenta)
                IDCuenta = dt.Rows.Item(0).Item(0)
                txtCuenta.Text = dt.Rows.Item(0).Item(1)
                cboDriver.SelectedIndex = (dt.Rows.Item(0).Item(2) - 1)
                CuentaOrig = dt.Rows.Item(0).Item(1)
                DriverOrig = dt.Rows.Item(0).Item(2)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ValidaInputs() As Boolean
        If (cboDriver.SelectedIndex >= 0) And (txtCuenta.Text.Trim.Length = 8) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim clsCta As New clsCuentasIngreso
            Dim cta As String = txtCuenta.Text.Trim
            Dim cabecera As String
            Dim mensajeExito, mensajeExiste As String
            Dim flag As Boolean = False

            If tipoAccion = 1 Then
                cabecera = "APM Terminals - Agregar Cuenta"
                mensajeExito = "Se agregó la cuenta con éxito."
            Else
                cabecera = "APM Terminals - Modificar Cuenta"
                mensajeExito = "Se modificó la cuenta con éxito."
            End If
            mensajeExiste = "La cuenta ingresada ya existe."

            If ValidaInputs() Then 'VALIDACION OK
                If tipoAccion = 1 Then 'AGREGAR
                    'BUSCO SI EXISTE LA CUENTA CON ESE DRIVER
                    If clsCta.ExisteCuenta(cta, cboDriver.SelectedValue) = 0 Then
                        'Agrego la cuenta
                        clsCta.AgregarCuenta(cta, cboDriver.SelectedValue)
                        flag = True
                    Else
                        'Mensaje indicando que ya existe
                        MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else 'MODIFICAR
                    Dim esta As Integer = clsCta.ExisteCuenta(cta, cboDriver.SelectedValue)
                    If ((esta > 0) And (cta = CuentaOrig) And (cboDriver.SelectedValue = DriverOrig)) Or
                        (esta = 0) Then
                        'Modifico la cuenta
                        clsCta.ModificarCuenta(cta, cboDriver.SelectedValue, IDCuenta)
                        flag = True
                    Else
                        'Mensaje indicando que ya existe
                        MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

                If flag Then
                    frm_Mantenimiento_Cuenta_Ingreso.dgv_Cuentas.DataSource = clsCta.ConsultarCuenta(0)
                    MessageBox.Show(mensajeExito, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                MessageBox.Show("Ingrese todos los datos correctamente.", cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_BuscarCuenta_Click(sender As Object, e As EventArgs) Handles btn_BuscarCuenta.Click
        Try
            Dim frmBuscaCta As New frm_Mantenimiento_CuentasContables

            frmBuscaCta.tsb_Agregar.Enabled = False
            frmBuscaCta.tsb_Eliminar.Enabled = False
            frmBuscaCta.tsb_Modificar.Enabled = False
            frmBuscaCta.tsb_Seleccionar.Visible = True
            frmBuscaCta.ShowDialog()
            txtCuenta.Text = frmBuscaCta.tsb_Seleccionar_Click("1", Nothing)
            frmBuscaCta.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class