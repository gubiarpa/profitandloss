Imports APM_DATOS
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ClsServicios
    Dim xcadena As String
    Dim da As SqlDataAdapter
    Private Property cmd As SqlCommand
    Private Property cnx As Connect

    'Function Ejecutar_Ingresos_Servicios(ByVal xAño As Integer, ByVal xMes As Integer) As Boolean
    '    Try
    '        cmd = New SqlCommand()
    '        cnx = New Connect()
    '        cnx.conectar()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        ''cmd.CommandText = "SP_Distribucion_Ingresos_Servicios"
    '        cmd.CommandText = "Ejecutar_Servicio"
    '        cmd.Parameters.Add("@Año", SqlDbType.Int, 5).Value = xAño
    '        cmd.Parameters.Add("@Mes", SqlDbType.Int, 3).Value = xMes
    '        cmd.Connection = cnx.cnDB
    '        cmd.ExecuteNonQuery()
    '        cnx.desconectar()
    '        Return True
    '    Catch ex As Exception
    '        cnx.desconectar()
    '        Throw ex
    '    End Try
    'End Function

    Public Sub Ejecutar_Proceso(ByVal anio As Integer, ByVal mes As Integer)
        Try
            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Ejecuta_ProcesoIngresos" 'INGRESOS
            cmd.Parameters.Add("@Año", SqlDbType.Int).Value = anio
            cmd.Parameters.Add("@Mes", SqlDbType.Int).Value = mes
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 7200
            cmd.ExecuteNonQuery()
            cnx.desconectar()

            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Ejecuta_ProcesoGastos_Nave" 'GASTOS POR BUQUE
            cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = anio
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = mes
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 7200
            cmd.ExecuteNonQuery()
            cnx.desconectar()

            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Ejecuta_ProcesoGastos_Servicio" 'GASTOS POR SERVICIOS
            cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = anio
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = mes
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 7200
            cmd.ExecuteNonQuery()
            cnx.desconectar()

            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Ejecuta_Proceso_CuentaNaveCliente" 'CUENTA NAVE CLIENTE
            cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = anio
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = mes
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 7200
            cmd.ExecuteNonQuery()
            cnx.desconectar()

            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "TABLAS TABLEAU" 'TABLAS TABLEAU
            cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = anio
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = mes
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 7200
            cmd.ExecuteNonQuery()
            cnx.desconectar()

            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar_Tableau()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "EJECUTAR_MAIN" 'MAIN TABLEAU
            cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = anio
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 7200
            cmd.ExecuteNonQuery()
            cnx.desconectar_Tableau()
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Sub

    Public Function NoNecesitaTemporal(ByVal tabla As String) As Boolean
        Try
            Dim dt As DataTable
            Dim resultado As Boolean = False

            dt = ObtieneReqNotTemp()

            For Each row As DataRow In dt.Rows
                If row(0).ToString.ToUpper = tabla.ToUpper Then
                    resultado = True
                    Exit For
                End If
            Next

            Return resultado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EsHistorico(ByVal tabla As String) As Boolean
        Try
            Dim dt As DataTable
            Dim resultado As Boolean = False

            dt = ObtieneHistoricos()

            For Each row As DataRow In dt.Rows
                If row(0).ToString.ToUpper = tabla.ToUpper Then
                    resultado = True
                    Exit For
                End If
            Next

            Return resultado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EsMaestro(ByVal tabla As String) As Boolean
        Try
            Dim dt As DataTable
            Dim resultado As Boolean = False

            dt = ObtieneMaestros()

            For Each row As DataRow In dt.Rows
                If row(0).ToString.ToUpper = tabla.ToUpper Then
                    resultado = True
                    Exit For
                End If
            Next

            Return resultado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReqTieneID(ByVal tabla As String) As Boolean
        Try
            Dim dt As DataTable
            Dim resultado As Boolean = False

            dt = ObtieneReqConID()

            For Each row As DataRow In dt.Rows
                If row(0).ToString.ToUpper = tabla.ToUpper Then
                    resultado = True
                    Exit For
                End If
            Next

            Return resultado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtieneReqNotTemp() As DataTable
        'ME DEVUELVE LOS REQUERIMIENTOS QUE NO NECESITAN TEMPORAL PERO QUE SE DESEAN IMPORTAR
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            cmd.CommandText = "SELECT Requerimiento FROM TB_Requerimiento WHERE Historica = 0"
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

    Public Function ObtieneReqConID() As DataTable
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            cmd.CommandText = "SELECT Requerimiento FROM TB_Requerimiento WHERE TieneID = 1"
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

    Public Function ObtieneHistoricos() As DataTable
        'ME DEVUELVE LOS REQUERIMIENTOS QUE NO NECESITAN TEMPORAL PERO QUE SE DESEAN IMPORTAR
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            cmd.CommandText = "SELECT Requerimiento FROM TB_Requerimiento WHERE Historica = 1"
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

    Public Function ObtieneMaestros() As DataTable
        'ME DEVUELVE LOS REQUERIMIENTOS QUE NO NECESITAN TEMPORAL PERO QUE SE DESEAN IMPORTAR
        Try
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim conAPM As New Connect

            conAPM.conectar()

            cmd.CommandText = "SELECT Requerimiento FROM TB_Requerimiento WHERE Maestro = 1"
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

    Public Function ListarColumnas(ByVal tabla As String) As List(Of String)
        Dim sqlReader As SqlDataReader
        Dim listaColumnas As New List(Of String)

        cmd = New SqlCommand()
        cnx = New Connect()
        cnx.conectar()

        'VERSION INICIAL
        'CONSULTABA DIRECTAMENTE ESQUEMA PARA OBTENER LAS TABLAS DE LA BD
        'cmd.CommandText = "SELECT COLUMN_NAME FROM [" + cnx.cnDB.Database.ToString + "].INFORMATION_SCHEMA.COLUMNS"
        'cmd.CommandText = cmd.CommandText + " WHERE TABLE_NAME = '" + tabla + "' AND ORDINAL_POSITION > 1 ORDER BY ORDINAL_POSITION ASC"

        'VERSION FINAL
        'CONSULTA A LA TABLA Mapeo_Excel PARA OBTENER LOS NUEVOS NOMBRES DE LAS COLUMNAS
        cmd.CommandText = "SELECT Columna_Excel FROM Mapeo_Excel WHERE Tabla_BD = '" + tabla + "' ORDER BY Posicion_BD ASC"

        cmd.CommandType = CommandType.Text
        cmd.Connection = cnx.cnDB
        sqlReader = cmd.ExecuteReader()

        While (sqlReader.Read())
            listaColumnas.Add(sqlReader.Item(0).ToString())
        End While

        cnx.desconectar()

        Return listaColumnas
    End Function

    Public Function Validar_Proceso(ByVal anio As Integer, ByVal mes As Integer) As DataTable
        Try
            cnx = New Connect()
            cnx.conectar()

            'PASO 1: LLAMO AL PROCEDIMIENTO PASANDO COMO PARAMETRO EL AÑO Y EL MES     
            cmd = New SqlCommand()
            cmd.CommandText = "SP_Valida_EjecucionProceso"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = anio
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = mes
            cmd.Connection = cnx.cnDB
            cmd.ExecuteNonQuery()

            'PASO 2: AHORA CONSULTO LA TABLA DE MENSAJE DE ERRORES PARA VER SI ESTA LLENA
            Dim da As SqlDataAdapter
            Dim cadena As String
            Dim dt As DataTable

            cadena = "SELECT MensajeError FROM Validacion_Errores"
            da = New SqlDataAdapter(cadena, cnx.cnDB)
            dt = New DataTable
            da.Fill(dt)

            'PASO 3: TRUNCO LA TABLA DE LOS MENSAJES DE ERROR
            cmd = New SqlCommand()
            cmd.CommandText = "TRUNCATE TABLE Validacion_Errores"
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnx.cnDB
            cmd.ExecuteNonQuery()

            cnx.desconectar()
            Return dt
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Function

    Public Function CalculaCount(requerimiento As String, anio As Integer, mes As Integer, flagReq As Boolean) As Integer
        Try
            Try
                Dim cmd As New SqlCommand
                Dim conAPM As New Connect
                Dim valor As Integer

                conAPM.conectar()
                If flagReq Then 'NECESITO MES Y AÑO
                    cmd.CommandText = "SELECT COUNT(*) FROM " & requerimiento & " WHERE [Año] = " & anio.ToString & " AND [Mes] = " & mes.ToString
                Else 'COUNT DE TODA LA TABLA
                    cmd.CommandText = "SELECT COUNT(*) FROM " & requerimiento
                End If
                cmd.CommandType = CommandType.Text
                cmd.Connection = conAPM.cnDB
                valor = Integer.Parse(cmd.ExecuteScalar)
                'cmd.ExecuteNonQuery()
                conAPM.desconectar()
                Return valor
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PruebaConexion() As Boolean
        Try
            Dim cnDB As New Connect
            cnDB.conectar()
            If cnDB.cnDB.State = ConnectionState.Open Then
                cnDB.desconectar()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
