
Imports System.Data.SqlClient
Imports System.Data
Public Class Connect
    Public cnDB As SqlClient.SqlConnection
    Public xflag As Boolean
    Dim cmDB As SqlClient.SqlCommand
    Dim dsDB As DataSet
    Dim oArchivo As New ClsArchivo
    Public Sub conectar()

        Dim arrText As New ArrayList()

        arrText = oArchivo.Leer_Archivo()

        If arrText(3) = 1 Then ''CADENA CON SEGURIDAD INTEGRADA DE WINDOWS
            cnDB = New SqlClient.SqlConnection
            cnDB.ConnectionString = "Initial Catalog=" & arrText(2) & ";Data Source=" & arrText(0) & " ;Integrated Security=SSPI;"
        ElseIf arrText(3) = 2 Then ''CADENA CON SEGURIDAD  DE SQL
            cnDB = New SqlClient.SqlConnection
            cnDB.ConnectionString = "Initial Catalog=" & arrText(2) & ";Data Source=" & arrText(0) & " ;User ID=" & arrText(4) & ";Password=" & arrText(5) & ";"
        End If

        Try
            cnDB.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub conectar_Tableau()
        Dim arrText As New ArrayList()

        arrText = oArchivo.Leer_Archivo()

        If arrText(3) = 1 Then ''CADENA CON SEGURIDAD INTEGRADA DE WINDOWS
            cnDB = New SqlClient.SqlConnection
            cnDB.ConnectionString = "Initial Catalog= APM_TABLEAU" & ";Data Source=" & arrText(0) & " ;Integrated Security=SSPI;"
        ElseIf arrText(3) = 2 Then ''CADENA CON SEGURIDAD  DE SQL
            cnDB = New SqlClient.SqlConnection
            cnDB.ConnectionString = "Initial Catalog= APM_TABLEAU" & ";Data Source=" & arrText(0) & " ;User ID=" & arrText(4) & ";Password=" & arrText(5) & ";"
        End If

        Try
            cnDB.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Public Sub conectar2()
    '    cnDB = New SqlClient.SqlConnection
    '    ''cnDB.ConnectionString = CadConectarSql
    '    cnDB.ConnectionString = "Initial Catalog=APM;Data Source=localhost ;Integrated Security=SSPI;"
    '    ''cnDB.ConnectionString = "Initial Catalog=model;Data Source=SRV-SERVIDOR\INSTANCIASQL2005;User ID=sa;Password=xxxxxxx"
    '    ''cnDB.ConnectionString = "Initial Catalog=" & xBaseDatos & ";Data Source=" & xServidor & " ;Integrated Security=SSPI;"
    '    Try
    '        cnDB.Open()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Sub desconectar()
        cnDB.Close()
    End Sub

    Public Sub desconectar_Tableau()
        cnDB.Close()
    End Sub
    'Public Function conSelect(ByVal cadConsul As String) As DataTable
    '    Dim dtTabla As New DataTable
    '    Try
    '        cmDB = New SqlClient.SqlCommand(cadConsul, cnDB)
    '        dtTabla = New DataTable()

    '    Catch
    '        ' // MessageBox.Show(ex.Message);
    '    End Try
    '    Return dtTabla
    'End Function

    'Public Function conInsert(ByVal cadInsert As String) As DataTable
    '    Dim dtTabla As New DataTable
    '    Try
    '        cmDB = New SqlClient.SqlCommand(cadInsert, cnDB)
    '        cmDB.ExecuteNonQuery()
    '    Catch
    '        ' // MessageBox.Show(ex.Message);
    '    End Try
    '    Return dtTabla
    'End Function
End Class
