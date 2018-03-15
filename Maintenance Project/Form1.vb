Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles studInfoButton.Click
        StudentInfo.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles LoginButton.Click
        reportsButton.Visible = True
        studInfoButton.Visible = True
        advisingButton.Visible = True

    End Sub

    Private Sub reportsButton_Click(sender As Object, e As EventArgs) Handles reportsButton.Click
        reports.Show()
    End Sub

    Private Sub advisingButton_Click(sender As Object, e As EventArgs) Handles advisingButton.Click
        Advising.Show()
    End Sub
End Class
