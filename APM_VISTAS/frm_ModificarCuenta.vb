Imports APM_CLASS
Imports APM_DATOS
Public Class frm_ModificarCuenta
    Dim apm As New Connect
    Dim oCuenta As New ClsCuentas
    Public Property Cuenta As Double
    Public Property Driver As Integer
    Public Property ID As Integer
    Public Property Tipo As String

    Private Function ValidaInputs() As Boolean
        If (cboDriver.SelectedIndex >= 0) And (txtCuenta.Text.Trim.Length = 8) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim xTipo As Integer
            If ValidaInputs() Then
                Dim xDriver As Integer = cboDriver.SelectedValue
                If lbl_Tipo.Text = "Buques" Then
                    xTipo = 0
                Else
                    xTipo = 1
                End If

                apm.conectar()

                If oCuenta.ModificarCuenta(apm, ID, Cuenta, xDriver, xTipo) Then
                    MessageBox.Show("Se modificó la cuenta con éxito", "APM Terminals - Modificar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_Mantenimiento_Cuenta.dgvListaCuentas.DataSource = oCuenta.ConsultarCuenta(apm, 0, xTipo)
                    apm.desconectar()
                    Me.Close()
                Else
                    MessageBox.Show("No se pudo modificar la cuenta correctamente", "APM Terminals - Modificar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    apm.desconectar()
                End If
            Else
                MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_ModificarCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsCta As New ClsCuentas
            Dim dt As New DataTable
            Dim xTipo As Integer

            If Tipo = "Buques" Then
                xTipo = 0
            Else
                xTipo = 1
            End If

            cboDriver.DataSource = clsCta.ListarDrivers(xTipo)
            cboDriver.DisplayMember = "Driver"
            cboDriver.ValueMember = "Num"

            txtCuenta.Text = Cuenta.ToString()
            txtCuenta.Enabled = False
            lbl_Tipo.Text = Tipo
            cboDriver.SelectedIndex = cboDriver.FindString(Driver)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class