Imports System.Data.OleDb

Public Class SheetRetriever
    Public Function GetSheetNames(ByVal conn As OleDbConnection) As List(Of SheetName)
        Dim sheetNames As New List(Of SheetName)

        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If

        Dim excelSchema As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim sheet As SheetName

        For Each row As DataRow In excelSchema.Rows
            If Not row("TABLE_NAME").ToString().Contains("FilterDatabase") Then
                sheet = New SheetName
                sheet.sheetName = row("TABLE_NAME").ToString()
                sheet.sheetType = row("TABLE_TYPE").ToString()
                sheet.sheetCatalog = row("TABLE_CATALOG").ToString()
                sheet.sheetSchema = row("TABLE_SCHEMA").ToString()
                sheetNames.Add(sheet)
            End If
        Next

        conn.Close()
        Return sheetNames
    End Function

End Class
