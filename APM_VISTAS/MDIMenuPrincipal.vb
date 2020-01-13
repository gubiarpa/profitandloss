Imports APM_CLASS
Imports APM_DATOS

Imports System.Windows.Forms
Imports System.IO

Public Class MDIMenuPrincipal

    Public guardarCredenciales As Boolean = True
    Public textoAuth As String = String.Empty

    Private Sub ConexiónADatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexiónADatosToolStripMenuItem.Click
        'frm_ConfiguracionConexion.MdiParent = Me
        frm_ConfiguracionConexion.ShowDialog()
        frm_ConfiguracionConexion.Dispose()
    End Sub

    Private Sub CargarRequerimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarRequerimientosToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            'frm_CargarRequerimiento.MdiParent = Me
            frm_CargarRequerimiento.ShowDialog()
            frm_CargarRequerimiento.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub EjecutarProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EjecutarProcesoToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            'frm_EjecutarProceso.MdiParent = Me
            frm_EjecutarProceso.ShowDialog()
            frm_EjecutarProceso.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CuentasContablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasContablesToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            'frm_Mantenimiento_Cuenta.MdiParent = Me
            frm_Mantenimiento_Cuenta.ShowDialog()
            frm_Mantenimiento_Cuenta.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            Dim frm_ExArch As New frm_ExportarArchivo
            'frm_ExArch.MdiParent = Me
            frm_ExArch.ShowDialog()
            frm_ExArch.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub EliminarRequerimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarRequerimientoToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            Dim frm_ElimReq As New frm_EliminarRequerimiento
            'frm_ElimReq.MdiParent = Me
            frm_ElimReq.ShowDialog()
            frm_ElimReq.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CuentasContablesIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasContablesIngresosToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            'frm_Mantenimiento_Cuenta_Ingreso.MdiParent = Me
            frm_Mantenimiento_Cuenta_Ingreso.ShowDialog()
            frm_Mantenimiento_Cuenta_Ingreso.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BuquesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuquesToolStripMenuItem.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            'frm_Mantenimiento_Buque.MdiParent = Me
            frm_Mantenimiento_Buque.ShowDialog()
            frm_Mantenimiento_Buque.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CuentasContablesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CuentasContablesToolStripMenuItem1.Click
        Dim clsServ As New ClsServicios

        If clsServ.PruebaConexion() Then
            'frm_Mantenimiento_CuentasContables.MdiParent = Me
            frm_Mantenimiento_CuentasContables.ShowDialog()
            frm_Mantenimiento_CuentasContables.Dispose()
        Else
            MessageBox.Show("Debe configurar la conexión a la base de datos.", "APM Terminals - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub MDIMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If (Not guardarCredenciales) Then
            Try
                Dim FolderPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                FolderPath = Path.Combine(FolderPath, "APM Terminals")
                If Directory.Exists(FolderPath) Then
                    Dim FilePath As String = FolderPath + "\Conexion_BD.txt"
                    If System.IO.File.Exists(FilePath) = True Then
                        System.IO.File.Delete(FilePath)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub
End Class
