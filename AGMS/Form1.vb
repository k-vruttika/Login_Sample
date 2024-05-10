Imports System.Data.SqlClient
Public Class Form1
    Dim connectionString As String = "Server='local';Database=Gallery;"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Connect to the database
        Using connection As New SqlConnection(Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False)
            connection.Open()

            ' Query to check if the username and password exist in the Login table
            Dim queryString As String = "SELECT COUNT(*) FROM Login WHERE Username = @Username AND Password = @Password;"
            Using command As New SqlCommand(queryString, connection)
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Password", password)

                ' Execute the query
                Dim result As Integer = DirectCast(command.ExecuteScalar(), Integer)

                If result > 0 Then
                    ' Authentication successful
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Authentication failed
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub
End Class
