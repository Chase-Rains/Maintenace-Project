Public Class summary_report
    ''Calling the db class
    Protected db As New db



    ''What happens when the page loads
    Private Sub summary_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Setting datagrid to select entire rows of data
        SumReportDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ''Filling datagridview with students table when the page loads
        db.sql = "Select * From Students"
        db.fill(SumReportDGV)







    End Sub


    ''When any text is changed in the search box we want to search the table for values like the text the user entered
    Private Sub SearchTextbox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextbox.TextChanged

        ''We are using a like statement to search every column for a value like whatever is typed in the textbox. When the text box is blank it automatically selects all values so this works out good.
        db.sql = "Select * From Students Where StudentID like '%" & SearchTextbox.Text & "%' OR FirstName like '%" & SearchTextbox.Text & "%' OR LastName like '%" & SearchTextbox.Text & "%' "
        db.fill(SumReportDGV)

    End Sub


    ''Add Student Button
    Private Sub AddStudentButton_Click(sender As Object, e As EventArgs) Handles AddStudentButton.Click
        MessageBox.Show("Are you sure you want to add this student?", "Add Student", MessageBoxButtons.YesNo)
    End Sub

    Private Sub SumReportDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SumReportDGV.CellClick

        ''If statement to test whether or not the cells are seleceted and if they are it fills them into the matching textbox
        If (SumReportDGV.SelectedRows.Count > 0) Then



            StudentIDTextbox.Text = SumReportDGV.SelectedRows(0).Cells(0).Value
            FirstnameTExtBox.Text = SumReportDGV.SelectedRows(0).Cells(1).Value
            middlenameTextBox.Text = SumReportDGV.SelectedRows(0).Cells(2).Value
            LastnameTextBox.Text = SumReportDGV.SelectedRows(0).Cells(3).Value
            SSNTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            AddressTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            CityTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            StateTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            ZipCodeTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            EmailTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            BirthDateTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            TextBoxEthnicity.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            SexComboBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            UndergradInstitutionTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            CampusTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            UGPATextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            WorkTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value
            UndergradMajorTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value



        End If

    End Sub




End Class