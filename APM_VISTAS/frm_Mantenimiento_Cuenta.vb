Imports APM_CLASS
Imports APM_DATOS

Imports System.Data.SqlClient
Imports System.Data
Public Class frm_Mantenimiento_Cuenta
    Dim apm As New Connect
    Dim oCuentas As New ClsCuentas
    Dim sql As String
    Dim da As SqlDataAdapter
    Dim opt As Byte

    Private Sub tsbAgregar_Click(sender As Object, e As EventArgs) Handles tsbAgregar.Click
        apm.xflag = True
        'frm_AgregarCuenta.MdiParent = Me.MdiParent
        frm_AgregarCuenta.lbl_Tipo.Text = cmBox_Tipo.SelectedItem
        frm_AgregarCuenta.ShowDialog()
        frm_AgregarCuenta.Dispose()
    End Sub

    Private Sub frm_Mantenimiento_Cuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializa_Controles()
        If cmBox_Tipo.SelectedIndex = -1 Then
            ToolStrip1.Enabled = False
        End If
        ''MostrarCuentas()
        'apm.conectar()
        ''Conexion.conectar()
        'Me.dgvListaCuentas.DataSource = oCuentas.ConsultarCuenta(apm, 0)
        'apm.desconectar()
    End Sub

    Private Sub Inicializa_Controles()
        Try
            cmBox_Tipo.Items.Add("Buques")
            cmBox_Tipo.Items.Add("Servicios")
            cmBox_Tipo.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
        Try
            Dim xIdCuenta As Double
            Dim dt As New DataTable

            If (cmBox_Tipo.SelectedIndex <> -1) And (dgvListaCuentas.RowCount > 0) Then
                xIdCuenta = Me.dgvListaCuentas.Item(0, Me.dgvListaCuentas.CurrentRow.Index).Value
                apm.conectar()
                apm.xflag = False
                dt = oCuentas.ConsultarCuenta(apm, 1, cmBox_Tipo.SelectedIndex, xIdCuenta)

                frm_ModificarCuenta.ID = dt.Rows.Item(0).Item(0)
                frm_ModificarCuenta.Cuenta = dt.Rows.Item(0).Item(1)
                frm_ModificarCuenta.Driver = dt.Rows.Item(0).Item(2)
                frm_ModificarCuenta.Tipo = cmBox_Tipo.SelectedItem

                'frm_ModificarCuenta.txtIdCuenta.Text = dt.Rows.Item(0).Item(0)
                'frm_ModificarCuenta.txtCuenta.Text = dt.Rows.Item(0).Item(1)
                'frm_ModificarCuenta.txtDriver.Text = dt.Rows.Item(0).Item(2)
                'frm_ModificarCuenta.lbl_Tipo.Text = cmBox_Tipo.SelectedItem

                apm.desconectar()
                'frm_ModificarCuenta.MdiParent = Me.MdiParent
                frm_ModificarCuenta.ShowDialog()
                frm_ModificarCuenta.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
        Try
            If (cmBox_Tipo.SelectedIndex <> -1) And (dgvListaCuentas.RowCount > 0) Then
                Dim result As Integer = MessageBox.Show("¿Está seguro que desea eliminar la cuenta seleccionada?", "APM Terminals - Eliminar Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim xIdcuenta As Integer
                    Dim oCuenta As New ClsCuentas

                    xIdcuenta = Me.dgvListaCuentas.Item(0, Me.dgvListaCuentas.CurrentRow.Index).Value
                    apm.conectar()

                    If oCuenta.EliminarCuenta(apm, xIdcuenta, cmBox_Tipo.SelectedIndex) Then
                        MessageBox.Show("Se eliminó la cuenta con éxito", "APM Terminals - Eliminar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'MsgBox("Cuenta Eliminada correctamente!!", MsgBoxStyle.OkOnly, "APM TERMINALS")
                    Else
                        MessageBox.Show("No se pudo eliminar la cuenta correctamente", "APM Terminals - Eliminar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'MsgBox("Error al Eliminar cuenta!!", MsgBoxStyle.OkOnly, "APM TERMINALS")
                    End If

                    Me.dgvListaCuentas.DataSource = oCuenta.ConsultarCuenta(apm, 0, cmBox_Tipo.SelectedIndex)
                    apm.desconectar()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            apm.conectar()
            If cmBox_Tipo.SelectedIndex = 0 Then 'BUQUES
                Me.dgvListaCuentas.DataSource = oCuentas.ConsultarCuenta(apm, 0, 0)
            ElseIf cmBox_Tipo.SelectedIndex = 1 Then
                Me.dgvListaCuentas.DataSource = oCuentas.ConsultarCuenta(apm, 0, 1)
            End If
            apm.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmBox_Tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBox_Tipo.SelectedIndexChanged
        dgvListaCuentas.DataSource = Nothing
        If cmBox_Tipo.SelectedIndex <> -1 Then
            ToolStrip1.Enabled = True
        Else
            ToolStrip1.Enabled = False
        End If
    End Sub
End Class