Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles studInfoButton.Click
        StudentInfo.Show()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles LoginButton.Click
        ' connects to xanadu databse and looks at the credentials table
        Dim connection As New SqlConnection("Server=essql1.walton.uark.edu;Database=xanadu;Trusted_Connection=yes")
        Dim command As New SqlCommand("Select * from credentials where username = @Username and password = @Password", connection)
        ' looks to see if the database username and password match the databse
        command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBox2.Text
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        'if there isnt a match error message else authenticate and show buttons
        If table.Rows.Count() <= 0 Then
            MsgBox("Quit Guessing!", MsgBoxStyle.OkOnly, "Come on Professor Nolan...")
            reportsButton.Visible = False
            studInfoButton.Visible = False
            advisingButton.Visible = False
        Else
            reportsButton.Visible = True
            studInfoButton.Visible = True
            advisingButton.Visible = True
        End If
    End Sub
    Private Sub reportsButton_Click(sender As Object, e As EventArgs) Handles reportsButton.Click
        reports.Show()
    End Sub
    Private Sub advisingButton_Click(sender As Object, e As EventArgs) Handles advisingButton.Click
        Advising.Show()
    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        'skip button for testing
        reportsButton.Visible = True
        studInfoButton.Visible = True
        advisingButton.Visible = True
    End Sub
End Class
