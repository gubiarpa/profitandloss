Imports System
Imports System.IO
Imports System.Text

Imports System.Collections
Public Class ClsArchivo
    Public Function Escribir_Archivo(ByVal xTipoConex As String, ByVal xServerName As String, ByVal xServerIP As String,
                             ByVal xDataName As String, ByVal xUsuario As String, ByVal xPassword As String) As Boolean
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter

        Try
            Dim FolderPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            FolderPath = Path.Combine(FolderPath, "APM Terminals")
            If Not Directory.Exists(FolderPath) Then
                Directory.CreateDirectory(FolderPath)
            End If

            Dim FilePath As String = FolderPath + "\Conexion_BD.txt"
            'Dim FilePath As String = "C:\Users\Cristhian.Yesquen\Documents\APM\Proyectos\APM_TERMINALS\Archivo Conexion\conexion.txt"

            If System.IO.File.Exists(FilePath) = True Then
                System.IO.File.Delete(FilePath)
            End If

            'Se abre el archivo y si este no existe se crea
            strStreamW = File.OpenWrite(FilePath)
            strStreamWriter = New StreamWriter(strStreamW, _
                                System.Text.Encoding.UTF8)

            'Escribimos la línea en el achivo de texto
            strStreamWriter.WriteLine(xServerName)
            strStreamWriter.WriteLine(xServerIP)
            strStreamWriter.WriteLine(xDataName)
            strStreamWriter.WriteLine(xTipoConex)
            strStreamWriter.WriteLine(xUsuario)
            strStreamWriter.WriteLine(xPassword)

            strStreamWriter.Close()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function Leer_Archivo() As ArrayList
        Try
            Dim FilePath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            FilePath = Path.Combine(FilePath, "APM Terminals")
            FilePath = FilePath + "\Conexion_BD.txt"

            Dim objReader As New StreamReader(FilePath)
            Dim sLine As String = ""
            Dim arrText As New ArrayList()

            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    arrText.Add(sLine)
                End If
            Loop Until sLine Is Nothing

            objReader.Close()

            Return arrText
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
