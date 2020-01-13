Imports APM_CLASS

Public Class frm_AgregarBuque
    Public Property tipoAccion As Integer
    Public Property NombreBuque As String
    Public Property TipoBuque As String
    Public Property Apoyo As String
    Public Property BuqueOrig As String
    Public Property TipoOrig As String
    Public Property ApoyoOrig As String

    Private Sub frm_AgregarBuque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsBuque As New ClsBuque
            Dim clsServicio As New ClsServicios
            Dim dt As New DataTable

            cboTipo.DataSource = clsBuque.ListarTipos()
            cboTipo.DisplayMember = "Tipo"
            cboTipo.ValueMember = "Tipo"

            cboApoyo.DataSource = clsBuque.ListarTiposApoyo()
            cboApoyo.DisplayMember = "Nombre"
            cboApoyo.ValueMember = "Flag"
            'cboApoyo.Items.Add("Sí")
            'cboApoyo.Items.Add("No")

            If tipoAccion = 2 Then 'MODIFICAR
                txtNombre.Enabled = False
                dt = clsBuque.ConsultarBuque(1, NombreBuque, TipoBuque)

                NombreBuque = dt.Rows.Item(0).Item(0)
                TipoBuque = dt.Rows.Item(0).Item(1)
                Apoyo = dt.Rows.Item(0).Item(2)

                txtNombre.Text = dt.Rows.Item(0).Item(0)
                cboTipo.SelectedIndex = cboTipo.FindString(TipoBuque)
                cboApoyo.SelectedIndex = cboApoyo.FindString(Apoyo)

                BuqueOrig = dt.Rows.Item(0).Item(0)
                TipoOrig = dt.Rows.Item(0).Item(1)
                ApoyoOrig = dt.Rows.Item(0).Item(2)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Function ValidaInputs() As Boolean
        If (txtNombre.Text.Trim.Length > 0) And (cboTipo.SelectedIndex >= 0) And (cboApoyo.SelectedIndex >= 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim clsBuque As New ClsBuque
            Dim var_buque As String
            Dim var_tipo As String
            Dim var_apoyo As String
            Dim cabecera As String
            Dim mensajeExito, mensajeExiste As String
            Dim flag As Boolean = False

            If tipoAccion = 1 Then
                cabecera = "APM Terminals - Agregar Buque"
                mensajeExito = "Se agregó el buque con éxito."
            Else
                cabecera = "APM Terminals - Modificar Buque"
                mensajeExito = "Se modificó el buque con éxito."
            End If

            mensajeExiste = "El buque y tipo ingresado ya existe."

            If ValidaInputs() Then
                var_buque = txtNombre.Text.Trim
                var_tipo = cboTipo.SelectedValue
                var_apoyo = cboApoyo.SelectedValue

                'AGREGAR
                If tipoAccion = 1 Then
                    'BUSCO SI EXISTE EL BUQUE CON ESE TIPO
                    'SI NO EXISTE
                    If (clsBuque.ExisteBuque(var_buque, var_tipo) = 0) Then
                        'AGREGRO EL BUQUE
                        clsBuque.AgregarBuque(var_buque, var_tipo, var_apoyo)
                        flag = True
                    Else
                        'MENSAJE INDICANDO QUE YA EXISTE
                        MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    'MODIFICAR
                Else
                    Dim esta As Integer = clsBuque.ExisteBuque(var_buque, var_tipo)
                    'SI EL BUQUE+TIPO YA EXISTE PERO LOS DATOS INGRESADOS SON LOS MISMOS
                    'O SI EL BUQUE+TIPO NO EXISTE

                    If ApoyoOrig = "Sí" Then
                        ApoyoOrig = "0"
                    ElseIf ApoyoOrig = "No" Then
                        ApoyoOrig = "1"
                    End If

                    If ((esta > 0) And (var_buque = BuqueOrig) And (var_tipo = TipoOrig)) Or
                        (esta = 0) Then
                        'MODIFICO EL BUQUE
                        clsBuque.ModificarBuque(var_buque, var_tipo, var_apoyo)
                        flag = True
                    Else
                        'MENSAJE INDICANDO QUE YA EXISTE
                        MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

                If flag Then
                    frm_Mantenimiento_Buque.dgv_Buque.DataSource = clsBuque.ConsultarBuque(0)
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
End Class