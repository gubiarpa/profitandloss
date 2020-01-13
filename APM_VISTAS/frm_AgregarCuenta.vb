Imports APM_CLASS
Imports APM_DATOS

Imports System.Data.SqlClient
Imports System.Data

Public Class frm_AgregarCuenta
    Dim oCuenta As New ClsCuentas
    Dim apm As New Connect
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim xCuenta As Integer
        Dim xDriver As Integer
        Dim xTipo As Integer
        Dim flag As Integer = 0

        Try
            If (txtCuenta.Text.Trim.Length = 8) And (cboDriver.SelectedValue.ToString.Length > 0) Then
                xCuenta = Me.txtCuenta.Text
                xDriver = Me.cboDriver.SelectedValue
                If lbl_Tipo.Text = "Buques" Then
                    xTipo = 0
                Else
                    xTipo = 1
                End If
                apm = New Connect()
                apm.conectar()

                If oCuenta.BuscarCuenta(apm, xCuenta, xTipo) = 0 Then
                    If oCuenta.InsertarCuenta(apm, xCuenta, xDriver, xTipo) = 1 Then
                        MessageBox.Show("Se agregó la cuenta con éxito.", "APM Terminals - Agregar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        flag = 1
                    Else
                        MessageBox.Show("No se pudo agregar la cuenta.", "APM Terminals - Agregar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("La cuenta ingresada ya existe.", "APM Terminals - Agregar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                If flag = 1 Then
                    frm_Mantenimiento_Cuenta.dgvListaCuentas.DataSource = oCuenta.ConsultarCuenta(apm, 0, xTipo)
                    Me.Close()
                End If

                apm.desconectar()
            Else
                MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_AgregarCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xTipo As Integer

        If lbl_Tipo.Text = "Buques" Then
            xTipo = 0
        Else
            xTipo = 1
        End If

        Me.cboDriver.DataSource = oCuenta.ListarDrivers(xTipo)
        Me.cboDriver.DisplayMember = "Driver"
        Me.cboDriver.ValueMember = "Num"
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