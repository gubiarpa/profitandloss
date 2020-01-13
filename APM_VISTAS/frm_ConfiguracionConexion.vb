Imports APM_CLASS
Imports APM_DATOS

Imports System
Imports System.IO
Imports System.Text
Public Class frm_ConfiguracionConexion
    Dim apm As New Connect
    Dim oArchivo As New ClsArchivo

    Private Sub btnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click

        Dim xTipoConex As Integer
        Dim xServerName As String
        Dim xServerIP As String
        Dim xDataName As String
        Dim xUsuario As String
        Dim xPassword As String

        If ValidaInputs() Then

            xTipoConex = Me.cboTipoConex.SelectedValue
            xServerName = Me.txtNombreServidor.Text
            xServerIP = Me.txtIPServidor.Text
            xDataName = Me.txtBaseDatos.Text
            xUsuario = IIf(Me.txtUsuario.Text = " ", 0, Me.txtUsuario.Text)
            xPassword = IIf(Me.txtPassword.Text = " ", 0, Me.txtPassword.Text)
            MDIMenuPrincipal.guardarCredenciales = chkMantenerSesion.Checked

            Dim cnDB As New SqlClient.SqlConnection
            If xTipoConex = 1 Then ''CADENA CON SEGURIDAD INTEGRADA DE WINDOWS
                'cnDB = New SqlClient.SqlConnection
                cnDB.ConnectionString = "Initial Catalog=" & xDataName & ";Data Source=" & xServerName & " ;Integrated Security=SSPI;"
            ElseIf xTipoConex = 2 Then ''CADENA CON SEGURIDAD  DE SQL
                'cnDB = New SqlClient.SqlConnection
                cnDB.ConnectionString = "Initial Catalog=" & xDataName & ";Data Source=" & xServerName & " ;User ID=" & xUsuario & ";Password=" & xPassword & ";"
            End If

            Try
                cnDB.Open()
                If cnDB.State = ConnectionState.Open Then
                    If oArchivo.Escribir_Archivo(xTipoConex, xServerName, xServerIP, xDataName, xUsuario, xPassword) Then
                        MessageBox.Show("Se guardaron los datos correctamente", "APM Terminals - Guardar conexión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    Else
                        MessageBox.Show("No se pudo guardar los datos.", "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    cnDB.Close()
                End If
            Catch ex As Exception
                MessageBox.Show("No se pudo guardar los datos, se presentó el siguiente error:" + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Throw ex
            End Try

            'If oArchivo.Escribir_Archivo(xTipoConex, xServerName, xServerIP, xDataName, xUsuario, xPassword) Then
            '    '    Try
            '    '        Dim conAPM As New Connect
            '    '        conAPM.conectar()
            '    '        If conAPM.cnDB.State = ConnectionState.Open Then
            '    '            conAPM.desconectar()
            '    '            MessageBox.Show("Se guardaron los datos correctamente", "APM Terminals - Guardar conexión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    '            Me.Close()
            '    '        Else
            '    '            MessageBox.Show("Los datos ingresados no son correctos. Existe problemas con la conexión.", "APM Terminals - Guardar conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    '        End If
            '    '    Catch ex As Exception
            '    '        MessageBox.Show("Los datos ingresados no son correctos. Existe problemas con la conexión.", "APM Terminals - Guardar conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    '    End Try
            '    'Else
            '    '    MessageBox.Show("No se pudo guardar los datos.", "APM Terminals - Guardar conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Else
            MessageBox.Show("Por favor, complete todos los campos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ValidaInputs() As Boolean
        Dim result As Boolean = False

        If cboTipoConex.SelectedValue = 1 Then 'WINDOWS
            If (txtNombreServidor.Text.Trim.Length > 0) And (txtBaseDatos.Text.Trim.Length > 0) Then
                result = True
            End If
        Else 'SQL
            If (txtNombreServidor.Text.Trim.Length > 0) And (txtBaseDatos.Text.Trim.Length > 0) And (txtUsuario.Text.Trim.Length > 0) And (txtPassword.Text.Trim.Length > 0) Then
                result = True
            End If
        End If

        Return result
    End Function

    Private Sub frm_ConfiguracionConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Descripcion")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr("Codigo") = "1"
        dr("Descripcion") = "Autenticación de Windows"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "2"
        dr("Descripcion") = "Autenticación de SQL"
        dt.Rows.Add(dr)

        Me.cboTipoConex.DataSource = dt
        Me.cboTipoConex.ValueMember = "Codigo"
        Me.cboTipoConex.DisplayMember = "Descripcion"
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cboTipoConex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoConex.SelectedIndexChanged
        If cboTipoConex.SelectedValue.ToString.Equals("1") Then
            txtUsuario.Enabled = False
            txtPassword.Enabled = False
            txtUsuario.Clear()
            txtPassword.Clear()
        Else
            txtUsuario.Enabled = True
            txtPassword.Enabled = True
            txtUsuario.Clear()
            txtPassword.Clear()
        End If
    End Sub
End Class