Imports APM_DATOS
Imports System.Data.SqlClient
Public Class ClsCuentas
    Dim xCadena As String
    Dim da As SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim apm As New Connect

    Function ConsultarCuenta(ByVal xcn As Connect, ByVal xTipoPar As Byte, ByVal xTipo As Byte, Optional ByVal xId As String = "") As DataTable
        Try
            cmd = New SqlCommand()

            If xTipo = 0 Then 'ES BUQUES
                If xTipoPar = 0 Then 'ES SIN PARAMETRO
                    cmd.CommandText = "Select Id as '#',Account as 'Cuenta', Tipo as 'Driver'  From  [dbo].[Maestrocuentas]"
                Else
                    cmd.CommandText = "Select Id as '#',Account as 'Cuenta', Tipo as 'Driver'  From  [dbo].[Maestrocuentas] where Id=" & xId
                End If
            Else 'ES SERVICIOS
                If xTipoPar = 0 Then 'ES SIN PARAMETRO
                    cmd.CommandText = "Select Id as '#',Account as 'Cuenta', Tipo as 'Driver'  From  [dbo].[MaestroCuentasServicio]"
                Else
                    cmd.CommandText = "Select Id as '#',Account as 'Cuenta', Tipo as 'Driver'  From  [dbo].[MaestroCuentasServicio] where Id=" & xId
                End If
            End If

            cmd.CommandType = CommandType.Text
            cmd.Connection = xcn.cnDB

            da = New SqlDataAdapter(cmd.CommandText, cmd.Connection)
            Dim dt As New DataTable
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Function InsertarCuenta(ByVal xcn As Connect, ByVal xCuenta As Integer, ByVal xDriver As Integer, ByVal xTipo As Integer) As Integer
        Try
            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Inserta_CuentaGasto"
            cmd.Parameters.Add("@Cuenta", SqlDbType.Int, 10).Value = xCuenta
            cmd.Parameters.Add("@Driver", SqlDbType.Int, 5).Value = xDriver
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = xTipo
            cmd.Connection = xcn.cnDB
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Function EliminarCuenta(ByVal xcn As Connect, ByVal xIdCuenta As Integer, ByVal xTipo As Byte) As Boolean
        Try
            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Elimina_CuentaGasto"
            cmd.Parameters.Add("@IdCuenta", SqlDbType.Float, 20).Value = xIdCuenta
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = xTipo
            cmd.Connection = xcn.cnDB
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function ModificarCuenta(ByVal xcn As Connect, ByVal xIdCuenta As Double, ByVal xCuenta As Double, ByVal xDriver As Integer, ByVal xTipo As Integer) As Boolean
        Try
            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Modifica_CuentaGasto"
            cmd.Parameters.Add("@IdCuenta", SqlDbType.Float, 20).Value = xIdCuenta
            cmd.Parameters.Add("@Cuenta", SqlDbType.Float, 20).Value = xCuenta
            cmd.Parameters.Add("@Driver", SqlDbType.Int, 5).Value = xDriver
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = xTipo
            cmd.Connection = xcn.cnDB
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function BuscarCuenta(ByVal xcn As Connect, ByVal xCuenta As Double, ByVal xTipo As Integer) As Integer
        Dim valor As Integer = 0
        Try
            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Busca_CuentaGasto"
            cmd.Parameters.Add("@Cuenta", SqlDbType.Float, 20).Value = xCuenta
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = xTipo
            cmd.Connection = xcn.cnDB
            valor = Integer.Parse(cmd.ExecuteScalar)
            Return valor
        Catch ex As Exception
            Return valor
        End Try
    End Function
    Function ListarDrivers(ByVal xTipo As Integer) As DataTable
        Try
            Dim dt As New DataTable
            dt.Columns.Add("Driver")
            dt.Columns.Add("Num")

            Dim dr As DataRow
            Dim i As Integer

            If xTipo = 0 Then 'BUQUES
                For i = 1 To 23
                    dr = dt.NewRow
                    dr("Driver") = i
                    dr("Num") = i
                    dt.Rows.Add(dr)
                Next
            Else 'SERVICIOS
                For i = 1 To 25
                    dr = dt.NewRow
                    dr("Driver") = i
                    dr("Num") = i
                    dt.Rows.Add(dr)
                Next
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
        'Try
        '    If xTipo = 0 Then 'BUQUES
        '        xCadena = "select T1.Tipo as Driver ,ROW_NUMBER() OVER (ORDER BY  T1.Tipo) AS 'Num' from (SELECT distinct Tipo from MaestroCuentas) as T1"
        '    Else 'SERVICIOS
        '        xCadena = "select T1.Tipo as Driver ,ROW_NUMBER() OVER (ORDER BY  T1.Tipo) AS 'Num' from (SELECT distinct Tipo from MaestroCuentasServicio) as T1"
        '    End If

        '    da = New SqlDataAdapter(xCadena, xcn.cnDB)
        '    Dim dt As New DataTable
        '    da.Fill(dt)

        '    Return dt
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function
End Class
