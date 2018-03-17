Public Class Advising
    Protected db As New db


    ''When the page is loaded
    Private Sub Advising_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Setting the max calendar selection to 1 day 
        AdvisingCalendar.MaxSelectionCount = 1

        ''AdvisingDataGridView


    End Sub



    Private Sub AdvisingCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles AdvisingCalendar.DateChanged
        ''We want to be able to load available times into a datagrid view so that the user can easily see convient times 
        Dim SelectedDate As Int32

        ''Sunday = 0 Monday = 1 Tuesday = 2 Wednesday = 3 Thursday = 4 Friday = 5 Saturday = 6 
        SelectedDate = AdvisingCalendar.SelectionStart.DayOfWeek

        If SelectedDate = 0 Then
            MessageBox.Show("There is no one available on Sunday", "Unable to Schedule", MessageBoxButtons.OK)
        ElseIf SelectedDate = 1 Then

        ElseIf SelectedDate = 2 Then

        ElseIf SelectedDate = 3 Then

        ElseIf SelectedDate = 4 Then

        ElseIf SelectedDate = 5 Then

        ElseIf SelectedDate = 6 Then
            MessageBox.Show("There is no one available on Saturday", "Unable to Schedule", MessageBoxButtons.OK)
        End If






    End Sub


End Class