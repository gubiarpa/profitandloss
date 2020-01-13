Imports System.Data.SqlClient
Imports APM_DATOS

Public Class clsCuentasIngreso
    Public Sub ModificarCuenta(ByVal cta As String, ByVal driver As String, ByVal ID As Integer)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "UPDATE IngresoCuentasServicios SET Account = " + cta + ", Tipo = " + driver + " WHERE Id = " + ID.ToString
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AgregarCuenta(ByVal cta As String, ByVal driver As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "INSERT INTO IngresoCuentasServicios(Account,Tipo) VALUES(" + cta + "," + driver + ")"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ExisteCuenta(ByVal cta As String, ByVal driver As String) As Integer
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect
            Dim valor As Integer

            conAPM.conectar()
            cmd.CommandText = "SELECT COUNT(*) FROM IngresoCuentasServicios WHERE Account = " + cta + " AND Tipo = " + driver
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            valor = Integer.Parse(cmd.ExecuteScalar)
            'cmd.ExecuteNonQuery()
            conAPM.desconectar()

            Return valor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EliminarCuenta(ByVal IDCuenta As Integer)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "DELETE FROM IngresoCuentasServicios WHERE Id = " + IDCuenta.ToString
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListarDrivers() As DataTable
        Try
            Dim dt As New DataTable
            dt.Columns.Add("Driver")
            dt.Columns.Add("Num")

            Dim dr As DataRow
            Dim i As Integer

            For i = 1 To 3
                dr = dt.NewRow
                dr("Driver") = i
                dr("Num") = i
                dt.Rows.Add(dr)
            Next

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarCuenta(ByVal tipoPar As Integer, Optional ByVal id As String = "") As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            If tipoPar = 0 Then 'ES SIN PARAMETROS
                cmd.CommandText = "Select Id as '#', Account as 'Cuenta', Tipo as 'Driver' From IngresoCuentasServicios"
            Else
                cmd.CommandText = "Select Id as '#', Account as 'Cuenta', Tipo as 'Driver' From IngresoCuentasServicios WHERE Id =" & id
            End If

            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB

            da = New SqlDataAdapter(cmd.CommandText, cmd.Connection)
            da.Fill(dt)

            conAPM.desconectar()

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarCuentasIngreso() As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()



            'If tipoPar = 0 Then 'ES SIN PARAMETROS
            '    cmd.CommandText = "Select Id as '#', Account as 'Cuenta', Tipo as 'Driver' From IngresoCuentasServicios"
            'Else
            '    cmd.CommandText = "Select Id as '#', Account as 'Cuenta', Tipo as 'Driver' From IngresoCuentasServicios WHERE Id =" & id
            'End If

            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB

            da = New SqlDataAdapter(cmd.CommandText, cmd.Connection)
            da.Fill(dt)

            conAPM.desconectar()

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
