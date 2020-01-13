Imports APM_CLASS

Public Class frm_Mantenimiento_Buque

    Private Sub frm_Mantenimiento_Buque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsBuque As New ClsBuque
            dgv_Buque.DataSource = clsBuque.ConsultarBuque_V2(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
        Try
            If dgv_Buque.RowCount > 0 Then
                Dim result As Integer = MessageBox.Show("¿Está seguro que desea eliminar el buque seleccionado?", "APM Terminals - Eliminar Buque", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim nombreBuque = dgv_Buque.Item(0, dgv_Buque.CurrentRow.Index).Value
                    'Dim tipoBuque = dgv_Buque.Item(1, dgv_Buque.CurrentRow.Index).Value
                    Dim clsBuque As New ClsBuque

                    clsBuque.EliminarBuque_V2(nombreBuque)
                    dgv_Buque.DataSource = clsBuque.ConsultarBuque_V2(0)
                    MessageBox.Show("Se eliminó el buque con éxito.", "APM Terminals - Eliminar Buque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbAgregar_Click(sender As Object, e As EventArgs) Handles tsbAgregar.Click
        Try
            Dim frmAB As New frm_AgregarBuque_V2

            frmAB.tipoAccion = 1 'AGREGAR

            frmAB.NombreBuque = String.Empty
            'frmAB.TipoBuque = String.Empty
            frmAB.Apoyo = String.Empty

            frmAB.BuqueOrig = String.Empty
            'frmAB.TipoOrig = String.Empty
            frmAB.ApoyoOrig = String.Empty

            'frmAB.MdiParent = Me.MdiParent
            frmAB.Text = "APM - Agregar Buque"
            frmAB.ShowDialog()
            frmAB.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
        Try
            Dim frmAB As New frm_AgregarBuque_V2

            frmAB.tipoAccion = 2 'MODIFICAR

            frmAB.NombreBuque = dgv_Buque.Item(0, dgv_Buque.CurrentRow.Index).Value
            'frmAB.TipoBuque = dgv_Buque.Item(1, dgv_Buque.CurrentRow.Index).Value

            'frmAB.MdiParent = Me.MdiParent
            frmAB.Text = "APM - Modificar Buque"
            frmAB.ShowDialog()
            frmAB.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class