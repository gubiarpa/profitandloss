Imports System.Data.SqlClient
Imports APM_DATOS

Public Class ClsCuentaContable
    Public Sub AgregarCuentaContable(ByVal cuenta As String, ByVal año As Integer, ByVal mes As Integer, ByVal tipoConc As String, _
                                     ByVal concepto As String, ByVal subConc As String, descripcion As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "INSERT INTO TIPO_CUENTA VALUES(" + año.ToString + ", " + mes.ToString + ", " + cuenta + ", '" + tipoConc + "', '"
            cmd.CommandText = cmd.CommandText + concepto + "', '" + subConc + "', '" + descripcion + "')"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExisteCuentaContable(ByVal cuenta As String, ByVal año As Integer, ByVal mes As Integer) As Integer
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect
            Dim valor As Integer

            conAPM.conectar()
            cmd.CommandText = "SELECT COUNT(*) FROM TIPO_CUENTA WHERE ACCOUNT = " + cuenta + " AND AÑO = " + año.ToString + " AND MES = " + mes.ToString
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
    Public Function Obtiene_TiposConcepto() As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "SELECT DISTINCT(Tipo_Concepto) TipoConcepto FROM TB_Cuenta_Atributo ORDER BY 1 ASC"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            da = New SqlDataAdapter(cmd.CommandText, cmd.Connection)
            da.Fill(dt)
            conAPM.desconectar()

            Dim dr As DataRow = dt.NewRow
            dr("TipoConcepto") = ""
            dt.Rows.InsertAt(dr, 0)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Obtiene_Conceptos(ByVal tipoConcepto As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "SELECT DISTINCT(Concepto) Concepto FROM TB_Cuenta_Atributo WHERE Tipo_Concepto = '" + tipoConcepto + "' ORDER BY 1 ASC"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            da = New SqlDataAdapter(cmd.CommandText, cmd.Connection)
            da.Fill(dt)
            conAPM.desconectar()

            Dim dr As DataRow = dt.NewRow
            dr("Concepto") = ""
            dt.Rows.InsertAt(dr, 0)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Obtiene_SubConceptos(ByVal tipoConcepto As String, ByVal concepto As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "SELECT DISTINCT(SubConcepto) SubConcepto FROM TB_Cuenta_Atributo WHERE Tipo_Concepto = '" + tipoConcepto + "' "
            cmd.CommandText = cmd.CommandText + " AND Concepto = '" + concepto + "' ORDER BY 1 ASC"
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            da = New SqlDataAdapter(cmd.CommandText, cmd.Connection)
            da.Fill(dt)
            conAPM.desconectar()

            Dim dr As DataRow = dt.NewRow
            dr("SubConcepto") = ""
            dt.Rows.InsertAt(dr, 0)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BuscaCuentasContables(ByVal cuenta As String, ByVal tipoConcepto As String, ByVal concepto As String, ByVal año As Integer, _
                                     ByVal mes As Integer, ByVal cantParam As Integer) As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "SELECT AÑO as 'Año', MES as 'Mes', ACCOUNT as 'Cuenta', [TYPE CONCEPT] as 'Tipo', CONCEPT as 'Concepto', SUBCONCEPT AS 'SubConcepto', DESCRIPTION AS 'Descripción' FROM TIPO_CUENTA"

            If cantParam > 0 Then
                cmd.CommandText = cmd.CommandText + " WHERE "
                cmd.CommandText = cmd.CommandText + " (CONVERT(INT,ACCOUNT) LIKE '%" + cuenta.ToUpper + "%') "
                If (tipoConcepto.Length > 0) Then
                    cmd.CommandText = cmd.CommandText + " AND ([TYPE CONCEPT] = '" + tipoConcepto + "')"
                End If
                If (concepto.Length > 0) Then
                    cmd.CommandText = cmd.CommandText + " AND (CONCEPT = '" + concepto + "')"
                End If
                If (año > 0) Then
                    cmd.CommandText = cmd.CommandText + " AND (AÑO = " + año.ToString + ")"
                End If
                If (mes > 0) Then
                    cmd.CommandText = cmd.CommandText + " AND (MES = " + mes.ToString + ")"
                End If
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

    Public Sub EliminaCuentaContable(ByVal año As Integer, ByVal mes As Integer, ByVal cuenta As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "DELETE FROM TIPO_CUENTA WHERE AÑO = " + año.ToString + " AND MES = " + mes.ToString + " AND ACCOUNT = " + cuenta
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ModificarCuentaContable(ByVal l_cuenta As String, ByVal l_año As Integer, ByVal l_mes As Integer, ByVal l_tipoConcepto As String, ByVal l_concepto As String, ByVal l_subConcepto As String, ByVal l_descripcion As String)
        Try
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()
            cmd.CommandText = "UPDATE TIPO_CUENTA SET [ACCOUNT] = " & l_cuenta & ", AÑO = " & l_año & ", MES = " & l_mes & ", [TYPE CONCEPT] = '" & l_tipoConcepto & "', "
            cmd.CommandText = cmd.CommandText & "CONCEPT = '" & l_concepto + "', SUBCONCEPT = '" & l_subConcepto & "', DESCRIPTION = '" & l_descripcion & "'"
            cmd.CommandText = cmd.CommandText & " WHERE ACCOUNT = " & l_cuenta & "AND AÑO = " & l_año & " AND MES = " & l_mes
            cmd.CommandType = CommandType.Text
            cmd.Connection = conAPM.cnDB
            cmd.ExecuteNonQuery()
            conAPM.desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
