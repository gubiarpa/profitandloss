Imports System.Data.SqlClient
Imports APM_DATOS

Public Class ClsBuque
    Public Function ConsultarBuque_V2(ByVal tipoPar As Integer, Optional ByVal nombre As String = "") As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            If tipoPar = 0 Then 'ES SIN PARAMETROS
                cmd.CommandText = "Select [Nombre de Buque] as 'Buque', case when Flag_Buque = 1 then 'No' else 'Sí' end 'Es Apoyo' From MaestroBuque"
            Else
                cmd.CommandText = "Select [Nombre de Buque] as 'Buque', case when Flag_Buque = 1 then 'No' else 'Sí' end 'Es Apoyo' From MaestroBuque where [Nombre de Buque] ='" & nombre & "'"
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

    Public Function ConsultarBuque(ByVal tipoPar As Integer, Optional ByVal nombre As String = "", Optional ByVal tipo As String = "") As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            If tipoPar = 0 Then 'ES SIN PARAMETROS
                cmd.CommandText = "Select [Nombre de Buque] as 'Buque', [Tipo Buque] as 'Tipo', case when Flag_Buque = 1 then 'No' else 'Sí' end 'Es Apoyo' From MaestroBuque"
            Else
                cmd.CommandText = "Select [Nombre de Buque] as 'Buque', [Tipo Buque] as 'Tipo', case when Flag_Buque = 1 then 'No' else 'Sí' end 'Es Apoyo' From MaestroBuque where [Nombre de Buque] ='" & nombre & "' AND [Tipo Buque] = '" & tipo & "'"
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

    Public Function ListarTiposApoyo() As DataTable
        Try
            Dim dt As New DataTable
            dt.Columns.Add("Nombre")
            dt.Columns.Add("Flag")

            Dim dr As DataRow = dt.NewRow
            dr("Nombre") = "Sí"
            dr("Flag") = "0"
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Nombre") = "No"
            dr("Flag") = "1"
            dt.Rows.Add(dr)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarTipos() As DataTable
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect
            Dim dt As New DataTable
            Dim da As SqlDataAdapter

            conAPM.conectar()
            cmd.CommandText = "SELECT [Tipo Buque] as 'Tipo' FROM MaestroTipo"
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

    Public Sub EliminarBuque_V2(ByVal nombreBuque As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "DELETE FROM MaestroBuque WHERE [Nombre de Buque] = '" + nombreBuque + "'"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarBuque(ByVal nombreBuque As String, ByVal tipoBuque As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "DELETE FROM MaestroBuque WHERE [Nombre de Buque] = '" + nombreBuque + "' AND [Tipo Buque] = '" + tipoBuque + "'"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ExisteBuque_V2(ByVal nombre As String) As Integer
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect
            Dim valor As Integer

            conAPM.conectar()
            cmd.CommandText = "SELECT COUNT(*) FROM MaestroBuque WHERE [Nombre de Buque] = '" + nombre + "'"
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

    Public Function ExisteBuque(ByVal nombre As String, ByVal tipo As String) As Integer
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect
            Dim valor As Integer

            conAPM.conectar()
            cmd.CommandText = "SELECT COUNT(*) FROM MaestroBuque WHERE [Nombre de Buque] = '" + nombre + "' AND [Tipo Buque] = '" + tipo + "'"
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

    Public Sub AgregarBuque_V2(ByVal nombre As String, flag As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "INSERT INTO MaestroBuque([Nombre de Buque],[Flag_Buque]) VALUES('" + nombre + "','" + flag + "')"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AgregarBuque(ByVal nombre As String, ByVal tipo As String, flag As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "INSERT INTO MaestroBuque([Nombre de Buque],[Tipo Buque],[Flag_Buque]) VALUES('" + nombre + "','" + tipo + "','" + flag + "')"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ModificarBuque_V2(ByVal nombre As String, ByVal flag As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "UPDATE MaestroBuque SET [Flag_Buque] = '" + flag + "' WHERE [Nombre de Buque] = '" + nombre + "'"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ModificarBuque(ByVal nombre As String, ByVal tipo As String, ByVal flag As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "UPDATE MaestroBuque SET [Tipo Buque] = '" + tipo + "', [Flag_Buque] = '" + flag + "' WHERE [Nombre de Buque] = '" + nombre + "'"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
