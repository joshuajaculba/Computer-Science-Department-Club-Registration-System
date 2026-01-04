Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class Database
    Inherits Component

    Private ReadOnly connectionString As String =
        "Data Source=DESKTOP-V172LMH\SQLEXPRESS;Initial Catalog=CLUB;Integrated Security=True;TrustServerCertificate=True"

    ' Returns ready-to-use SqlConnection
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    ' Executes INSERT / UPDATE / DELETE
    Public Sub ExecuteNonQuery(query As String)
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Executes SELECT and returns DataTable
    Public Function ExecuteQuery(query As String) As DataTable
        Dim dt As New DataTable()
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

End Class
