Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Directory
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop
Imports APM_DATOS
Imports System.Windows.Forms.FolderBrowserDialog
Imports ClosedXML
Imports ClosedXML.Excel
Imports System.IO
Imports System.Configuration

Public Class ClsExportar
    Private Property cmd As SqlCommand
    Private Property cnx As Connect

    'Public Sub Exportar3()
    '    Using cmd As New SqlCommand("SELECT * FROM Requerimiento0")
    '        Using sda As New SqlDataAdapter()
    '            cnx = New Connect()
    '            cnx.conectar2()
    '            cmd.Connection = cnx.cnDB
    '            sda.SelectCommand = cmd
    '            Using dt As New System.Data.DataTable()
    '                sda.Fill(dt)
    '                Using wb As New XLWorkbook("C:\Users\Cristhian.Yesquen\Documents\APM\Proyectos\APM_TERMINALS\prueba.xlsx")
    '                    wb.Worksheets.Add(dt, "Customers")
    '                    wb.Save()
    '                    'Response.Clear()
    '                    'Response.Buffer = True
    '                    'Response.Charset = ""
    '                    'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '                    'Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx")
    '                    'Using MyMemoryStream As New MemoryStream()
    '                    '    wb.SaveAs(MyMemoryStream)
    '                    '    'MyMemoryStream.WriteTo(Response.OutputStream)
    '                    '    'Response.Flush()
    '                    '    'Response.End()
    '                    'End Using
    '                End Using
    '            End Using
    '        End Using
    '    End Using
    'End Sub

    Public Sub Exportar_Requerimiento(ByVal ruta As String, ByVal requerimiento As String, ByVal anio As Integer, ByVal mes As Integer)
        Dim cmdString As String
        Dim archOut As String
        Dim req As String
        Dim clsServ As New ClsServicios
        Dim flagTemp As Boolean
        Try
            req = requerimiento.ToUpper
            flagTemp = clsServ.NoNecesitaTemporal(req)

            If flagTemp Then
                cmdString = "SELECT * FROM " + requerimiento
            Else
                cmdString = "SELECT * FROM " + requerimiento + " WHERE Año=" + anio.ToString + " AND Mes=" + mes.ToString
            End If

            'If (requerimiento.ToUpper = "CASE2CUENTAS") Or (requerimiento.ToUpper = "CODIGOSERVICIO") Then
            '    cmdString = "SELECT * FROM " + requerimiento
            'Else
            '    cmdString = "SELECT * FROM " + requerimiento + " WHERE Año=" + anio.ToString + " AND Mes=" + mes.ToString
            'End If

            Using cmd As New SqlCommand(cmdString)
                Using sda As New SqlDataAdapter()
                    cnx = New Connect()
                    cnx.conectar()
                    cmd.Connection = cnx.cnDB
                    sda.SelectCommand = cmd
                    Using dt As New System.Data.DataTable()
                        sda.Fill(dt)
                        archOut = ruta + "\" + requerimiento + DateTime.Now.ToString("_ddMMyyyy") + ".xlsx"
                        If System.IO.File.Exists(archOut) = True Then
                            System.IO.File.Delete(archOut)
                        End If
                        Dim wb As New XLWorkbook()
                        wb.Worksheets.Add(dt, requerimiento)
                        wb.SaveAs(archOut)
                        Modifica_Cabecera(archOut, requerimiento)
                    End Using
                End Using
            End Using
            cnx.desconectar()
        Catch ex As Exception
            cnx.desconectar()
            Throw ex
        End Try
    End Sub

    Private Sub Modifica_Cabecera(ByVal rutaArchivo As String, ByVal hoja As String)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlWorkBooks As Microsoft.Office.Interop.Excel.Workbooks = Nothing
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim xlWorkSheets As Microsoft.Office.Interop.Excel.Sheets = Nothing
        Dim xlCells As Microsoft.Office.Interop.Excel.Range = Nothing
        Dim Proceed As Boolean = False
        Dim columnasBD As List(Of String)
        Dim cslServ As New ClsServicios
        Dim numColumnas As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlApp.DisplayAlerts = False
        xlWorkBooks = xlApp.Workbooks
        xlWorkBook = xlWorkBooks.Open(rutaArchivo)
        'xlApp.Visible = True
        xlWorkSheets = xlWorkBook.Sheets

        For x As Integer = 1 To xlWorkSheets.Count
            xlWorkSheet = CType(xlWorkSheets(x), Microsoft.Office.Interop.Excel.Worksheet)
            If xlWorkSheet.Name = hoja Then
                Proceed = True
                'AQUI DEBO MODIFICAR
                columnasBD = cslServ.ListarColumnas(hoja)
                numColumnas = columnasBD.Count()

                If cslServ.ReqTieneID(hoja) Then
                    For i As Integer = 0 To numColumnas - 1
                        xlWorkSheet.Cells(1, i + 2) = columnasBD(i).ToString
                    Next
                Else
                    For i As Integer = 0 To numColumnas - 1
                        xlWorkSheet.Cells(1, i + 1) = columnasBD(i).ToString
                    Next
                End If
                
                xlWorkSheet.SaveAs(rutaArchivo)
                xlWorkBook.Close()
                xlApp.Quit()
                ReleaseComObject(xlCells)
                ReleaseComObject(xlWorkSheets)
                ReleaseComObject(xlWorkSheet)
                ReleaseComObject(xlWorkBook)
                ReleaseComObject(xlWorkBooks)
                ReleaseComObject(xlApp)
                Exit For
            End If
            Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
            xlWorkSheet = Nothing
        Next
        'If Proceed Then
        '    xlWorkSheet.Activate()
        'End If
    End Sub

    Public Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

    'Public Sub Exportar()
    '    Dim dataAdapter As New SqlClient.SqlDataAdapter()
    '    Dim datatableMain As New System.Data.DataTable()

    '    cmd = New SqlCommand()
    '    cnx = New Connect()
    '    cnx.conectar2()
    '    cmd.CommandText = "SELECT * FROM Requerimiento0"
    '    cmd.CommandType = CommandType.Text
    '    cmd.Connection = cnx.cnDB
    '    dataAdapter.SelectCommand = cmd

    '    Dim oExcel As Excel.Application
    '    Dim oBook As Excel.Workbook
    '    Dim oSheet As Excel.Worksheet
    '    oExcel = CreateObject("Excel.Application")
    '    oBook = oExcel.Workbooks.Add(Type.Missing)
    '    oSheet = oBook.Worksheets(1)

    '    Dim dc As System.Data.DataColumn
    '    Dim dr As System.Data.DataRow
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0

    '    'Fill data to datatable
    '    cnx.conectar2()
    '    dataAdapter.Fill(datatableMain)
    '    cnx.desconectar()

    '    'Export the Columns to excel file
    '    For Each dc In datatableMain.Columns
    '        colIndex = colIndex + 1
    '        oSheet.Cells(1, colIndex) = dc.ColumnName
    '    Next

    '    'Export the rows to excel file
    '    For Each dr In datatableMain.Rows
    '        rowIndex = rowIndex + 1
    '        colIndex = 0
    '        For Each dc In datatableMain.Columns
    '            colIndex = colIndex + 1
    '            oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
    '        Next
    '    Next

    '    'Set final path
    '    Dim fileName As String = "\Requerimiento0_Export" + ".xlsx"
    '    Dim finalPath = "C:\Users\Cristhian.Yesquen\Documents\APM\Proyectos\APM_TERMINALS" + fileName
    '    'txtPath.Text = finalPath
    '    oSheet.Columns.AutoFit()
    '    'Save file in final path
    '    oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing, _
    '    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
    '    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

    '    'Release the objects
    '    ReleaseObject(oSheet)
    '    oBook.Close(False, Type.Missing, Type.Missing)
    '    ReleaseObject(oBook)
    '    oExcel.Quit()
    '    ReleaseObject(oExcel)
    '    'Some time Office application does not quit after automation: 
    '    'so i am calling GC.Collect method.
    '    GC.Collect()
    'End Sub

    'Public Sub Exportar2()
    '    Dim oExcel As Excel.Application

    '    Dim dataAdapter As New SqlClient.SqlDataAdapter()
    '    Dim datatableMain As New DataSet

    '    cmd = New SqlCommand()
    '    cnx = New Connect()
    '    cnx.conectar2()
    '    cmd.CommandText = "SELECT * FROM Requerimiento0"
    '    cmd.CommandType = CommandType.Text
    '    cmd.Connection = cnx.cnDB
    '    dataAdapter.SelectCommand = cmd

    '    Dim oBook As Excel.Workbook
    '    Dim oSheet As Excel.Worksheet
    '    oExcel = CreateObject("Excel.Application")
    '    oBook = oExcel.Workbooks.Add(Type.Missing)
    '    oSheet = oBook.Worksheets(1)

    '    Dim dc As System.Data.DataColumn
    '    Dim dr As System.Data.DataRow
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0

    '    'Fill data to datatable
    '    cnx.conectar2()
    '    dataAdapter.Fill(datatableMain)
    '    cnx.desconectar()

    '    With oExcel
    '        .SheetsInNewWorkbook = 1
    '        .Workbooks.Add()
    '        .Worksheets(1).Select()

    '        Dim i As Integer = 1
    '        For col = 0 To datatableMain.Tables(0).Columns.Count - 1
    '            .Cells(1, i).value = datatableMain.Tables(0).Columns(col).ColumnName
    '            .Cells(1, i).EntireRow.Font.Bold = True
    '            i += 1
    '        Next

    '        i = 2

    '        Dim k As Integer = 1
    '        For col = 0 To datatableMain.Tables(0).Columns.Count - 1
    '            i = 2
    '            For row = 0 To datatableMain.Tables(0).Rows.Count - 1
    '                .Cells(i, k).Value = datatableMain.Tables(0).Rows(row).ItemArray(col)
    '                i += 1
    '            Next
    '            k += 1
    '        Next
    '        Dim fileName As String = "\Requerimiento_Export" + ".xlsx"
    '        Dim finalPath = "C:\Users\Cristhian.Yesquen\Documents\APM\Proyectos\APM_TERMINALS" + fileName
    '        .ActiveCell.Worksheet.SaveAs(finalPath)
    '    End With
    'End Sub

    'Private Sub ReleaseObject(ByVal o As Object)
    '    Try
    '        While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
    '        End While
    '    Catch
    '    Finally
    '        o = Nothing
    '    End Try
    'End Sub
End Class
