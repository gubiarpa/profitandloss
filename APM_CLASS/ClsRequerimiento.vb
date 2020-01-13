Imports System.Data.SqlClient
Imports APM_DATOS
Imports System.Data.OleDb
Imports ClosedXML.Excel
Imports System.IO

Public Class ClsRequerimiento
    Private Property cmd As SqlCommand
    Private Property cnx As Connect
    Public Function Listar_Requerimiento(ByVal flag As Integer) As DataTable
        Try
            Dim da As SqlDataAdapter
            Dim cadena As String
            Dim dt As DataTable

            If flag = 1 Then 'IMPORTAR/CARGAR
                cadena = "SELECT Requerimiento, Descripcion FROM TB_Requerimiento WHERE Importar = 1"
            ElseIf flag = 2 Then 'EXPORTAR
                cadena = "SELECT Requerimiento, Descripcion FROM TB_Requerimiento WHERE Exportar = 1"
            ElseIf flag = 3 Then 'ELIMINAR
                cadena = "SELECT Requerimiento, Descripcion FROM TB_Requerimiento WHERE Eliminar = 1"
            Else
                cadena = "SELECT Requerimiento, Descripcion FROM TB_Requerimiento"
            End If

            cnx = New Connect()
            cnx.conectar()

            da = New SqlDataAdapter(cadena, cnx.cnDB)
            dt = New DataTable
            da.Fill(dt)

            cnx.desconectar()

            Return dt
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Function

    Private Function ValidaExcel(ByVal excel_con As OleDbConnection, ByVal tabla As String) As Integer
        Try
            Dim dtExcelData As DataTable
            Dim hojasExcel As List(Of SheetName)
            Dim hoja1 As String
            Dim sheetRet As New SheetRetriever

            hojasExcel = sheetRet.GetSheetNames(excel_con)
            excel_con.Open()

            If hojasExcel.Count > 1 Then
                excel_con.Close()
                Return 2 'EXISTE MAS DE UNA HOJA EN EL EXCEL
            Else
                'AHORA VALIDO QUE LAS COLUMNAS SEAN IGUAL A LAS DE LA BD
                hoja1 = hojasExcel(0).sheetName
                dtExcelData = New DataTable()

                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & hoja1) + "]", excel_con)
                    oda.Fill(dtExcelData)
                    excel_con.Close()

                    Dim numColumnas As Integer = dtExcelData.Columns.Count
                    Dim columnasExc(numColumnas - 1) As String
                    Dim i As Integer
                    Dim cslServ As New ClsServicios
                    Dim columnasBD As List(Of String)

                    For i = 0 To numColumnas - 1
                        columnasExc(i) = dtExcelData.Columns(i).ToString()
                    Next

                    columnasBD = cslServ.ListarColumnas(tabla)

                    'VERIFICO QUE SEA EL MISMO NUMERO DE COLUMNAS
                    If numColumnas = columnasBD.Count Then
                        'SI EN NUMERO SON IGUALES, AHORA VERIFICO QUE LOS NOMBRES TAMBIEN
                        Dim flagCol As Boolean = True
                        For i = 0 To numColumnas - 1
                            If columnasExc(i) <> columnasBD(i) Then
                                flagCol = False
                                Exit For
                            End If
                        Next
                        If Not flagCol Then
                            Return 3
                        Else
                            Return 1
                        End If
                    Else
                        Return 3 'LAS COLUMNAS DEL EXCEL NO COINCIDE CON LAS DE LA BD
                    End If
                End Using
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarRequerimiento(ByVal RutaArch As String, ByVal Tabla As String, ByVal ExtEx As String, ByRef mensajes As DataTable) As Integer
        Try
            Dim cadenaConexion As String = String.Empty
            Dim cadenaConexionNH As String = String.Empty
            Dim resultado As Integer = 3
            Dim excel_con As OleDbConnection

            Select Case ExtEx
                Case ".xlsx"
                    cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RutaArch + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
                    cadenaConexionNH = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RutaArch + ";Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'"
                    Exit Select
                Case ".xlsm"
                    cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RutaArch + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
                    cadenaConexionNH = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RutaArch + ";Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'"
                    Exit Select
                Case ".xls"
                    cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RutaArch + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
                    cadenaConexionNH = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RutaArch + ";Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'"
            End Select

            excel_con = New OleDbConnection(cadenaConexion)

            Dim validate As Integer = ValidaExcel(excel_con, Tabla)

            If (validate = 1) Then 'EXCEL "OK"
                Dim tablaTemp As String
                Dim sheet1 As String
                Dim dtExcelData As New DataTable()

                excel_con = New OleDbConnection(cadenaConexionNH)
                excel_con.Open()
                sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()

                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & sheet1) + "]", excel_con)
                    oda.Fill(dtExcelData)
                End Using

                excel_con.Close()

                'ME CONECTO AL SQL SERVER PARA GUARDAR LA INFORMACION QUE TENGO EN MEMORIA (EXCEL) A UNA TABLA
                cnx = New Connect()
                cmd = New SqlCommand()
                cnx.conectar()
                cmd.Connection = cnx.cnDB
                cmd.CommandTimeout = 1200

                'PRIMERA PARTE
                'ALMACENO EN UNA TABLA TEMPORAL

                'If flagTemp Then
                '    tablaTemp = Tabla + "_temp"
                'Else
                '    tablaTemp = Tabla
                'End If

                tablaTemp = Tabla + "_temp"

                cmd.CommandText = "TRUNCATE TABLE dbo." + tablaTemp
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()

                Using sqlBulkCopy As New SqlBulkCopy(cnx.cnDB)
                    sqlBulkCopy.DestinationTableName = "dbo." + tablaTemp
                    sqlBulkCopy.WriteToServer(dtExcelData)
                End Using

                cmd.CommandText = "WITH q AS (SELECT TOP 1 * FROM dbo." + tablaTemp + ") DELETE FROM q"
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()

                cnx.desconectar()

                'AQUI DEBO VALIDAR
                Try
                    Dim dt As DataTable = Valida_Requerimiento_V2(tablaTemp)
                    mensajes = dt

                    cnx = New Connect()
                    cnx.conectar()
                Catch ex As Exception
                    resultado = 1
                End Try


                If (mensajes Is Nothing OrElse mensajes.Rows.Count > 0) Then 'HAY ERRORES EN EL REQUERIMIENTO
                    'If Not flagTemp Then
                    '    cmd = New SqlCommand()
                    '    cmd.CommandText = "TRUNCATE TABLE dbo." + tablaTemp
                    '    cmd.CommandType = CommandType.Text
                    '    cmd.Connection = cnx.cnDB
                    '    cmd.ExecuteNonQuery()
                    'End If
                    'cnx.desconectar()
                    resultado = 4
                Else 'NO HAY ERRORES, INSERTO EN LA TABLA FINAL
                    Dim clsServicio As New ClsServicios

                    If (Not clsServicio.EsHistorico(Tabla)) Then
                        cmd = New SqlCommand()
                        cmd.CommandText = "TRUNCATE TABLE dbo." + Tabla
                        cmd.CommandType = CommandType.Text
                        cmd.Connection = cnx.cnDB
                        cmd.CommandTimeout = 1200
                        cmd.ExecuteNonQuery()
                    End If

                    cmd = New SqlCommand()
                    cmd.CommandText = "SP_Carga_RequerimientoFinal"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = cnx.cnDB
                    cmd.CommandTimeout = 1200
                    cmd.Parameters.AddWithValue("TABLA", Tabla)
                    cmd.ExecuteNonQuery()
                    'If flagTemp Then
                    '    'SEGUNDA PARTE
                    '    'LO GUARDO EN LA TABLA FINAL
                    '    cmd = New SqlCommand()
                    '    cmd.CommandText = "SP_CARGAR_REQUERIMIENTO"
                    '    cmd.CommandType = CommandType.StoredProcedure
                    '    cmd.Connection = cnx.cnDB
                    '    cmd.Parameters.AddWithValue("TABLA", Tabla)
                    '    cmd.ExecuteNonQuery()
                    'End If
                    'cnx.desconectar()
                    resultado = 1
                End If

                cmd = New SqlCommand()
                cmd.CommandText = "TRUNCATE TABLE dbo." + tablaTemp
                cmd.CommandType = CommandType.Text
                cmd.Connection = cnx.cnDB
                cmd.CommandTimeout = 1200
                cmd.ExecuteNonQuery()
                cnx.desconectar()
            ElseIf (validate = 2) Then
                resultado = 2
            ElseIf (validate = 3) Then
                resultado = 3
            End If
            Return resultado
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Function

    Private Function Valida_Requerimiento_V2(ByRef Tabla As String) As DataTable
        Try
            Dim cadena As String
            Dim dt As New DataTable
            Dim tablaRev As String
            Dim rutaErrores As String
            Dim archErrores As String

            cnx = New Connect()
            cnx.conectar()
            'PASO 1: LLAMO AL PROCEDIMIENTO PASANDO COMO PARAMETRO EL NOMBRE DE LA TABLA      
            cmd = New SqlCommand()
            cmd.CommandText = "SP_Ejecuta_Validaciones"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Tabla", SqlDbType.VarChar, 100).Value = Tabla
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 1200
            cmd.ExecuteNonQuery()
            cnx.desconectar()

            'PASO 2: AHORA CONSULTO LA TABLA DE MENSAJE DE ERRORES PARA VER SI ESTA LLENA

            'If Tabla.Contains("_temp") Then
            '    tablaRev = Tabla.Remove(Tabla.Length - 5, 5) + "_review"
            'Else
            '    tablaRev = Tabla + "_review"
            'End If

            tablaRev = Tabla.Remove(Tabla.Length - 5, 5) + "_review"
            cadena = "SELECT * FROM " + tablaRev

            Using cmd As New SqlCommand(cadena)
                Using sda As New SqlDataAdapter()
                    cnx = New Connect()
                    cnx.conectar()
                    cmd.Connection = cnx.cnDB
                    cmd.CommandTimeout = 1200
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                    cnx.desconectar()

                    If dt.Rows.Count > 0 Then
                        rutaErrores = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        rutaErrores = Path.Combine(rutaErrores, "APM Terminals")
                        If Not Directory.Exists(rutaErrores) Then
                            Directory.CreateDirectory(rutaErrores)
                        End If
                        rutaErrores = Path.Combine(rutaErrores, "Carga - Errores")
                        If Not Directory.Exists(rutaErrores) Then
                            Directory.CreateDirectory(rutaErrores)
                        End If
                        archErrores = rutaErrores + "\" + tablaRev + DateTime.Now.ToString("_ddMMyyyy") + ".xlsx"
                        If System.IO.File.Exists(archErrores) = True Then
                            System.IO.File.Delete(archErrores)
                        End If
                        Dim wb As New XLWorkbook()
                        wb.Worksheets.Add(dt, tablaRev)
                        wb.SaveAs(archErrores)
                    End If
                End Using
            End Using

            'PASO 3: TRUNCO LA TABLA DE LOS MENSAJES DE ERROR
            cnx = New Connect()
            cnx.conectar()
            cmd = New SqlCommand()
            cmd.CommandText = "TRUNCATE TABLE " + tablaRev
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 1200
            cmd.ExecuteNonQuery()
            cnx.desconectar()
            Return dt
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Function

    Private Function Valida_Requerimiento(ByVal Tabla As String) As DataTable
        Try
            cnx = New Connect()
            cnx.conectar()

            'PASO 1: LLAMO AL PROCEDIMIENTO PASANDO COMO PARAMETRO EL NOMBRE DE LA TABLA      
            cmd = New SqlCommand()
            cmd.CommandText = "SP_Valida_CargaInformacion"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Tabla", SqlDbType.VarChar, 100).Value = Tabla
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

    Public Sub EliminarRequerimiento(ByVal requerimiento As String, ByVal anio As Integer, ByVal mes As Integer)
        Try
            cmd = New SqlCommand()
            cnx = New Connect()
            cnx.conectar()

            Dim clsServ As New ClsServicios
            Dim flagTemp As Boolean = clsServ.NoNecesitaTemporal(requerimiento.ToUpper)

            If Not flagTemp Then 'NECESITO MES Y AÑO
                cmd.CommandText = "DELETE FROM " & requerimiento & " WHERE [Año] = " & anio.ToString & " AND [Mes] = " & mes.ToString
            Else 'COUNT DE TODA LA TABLA
                cmd.CommandText = "DELETE FROM " & requerimiento
            End If

            cmd.CommandType = CommandType.Text
            cmd.Connection = cnx.cnDB
            cmd.CommandTimeout = 1200
            cmd.ExecuteNonQuery()
            cnx.desconectar()
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Sub


End Class
