Public Class StudentInfo
    Protected db As New db 'call db.vb to connect to database.
    '<---------------------------------------------------------------------------Create Student---------------------------------------------------------------------------------------------->
    Private Sub submit_Click_1(sender As Object, e As EventArgs) Handles submit.Click
        If IsDate(txtBirthday1.Text) = False Then 'validates birthdate textbox
            MsgBox("Please enter a valid birthdate", vbOK)
            Exit Sub
        End If
        If txtSSN.Text = "" Then 'validates SSN masked textbox
            MsgBox("Please enter the student's SSN", vbOK)
            Exit Sub
        End If
        If GenderDropDown.Text = "" Then 'validates gender drop down
            MsgBox("Please enter the student's Gender", vbOK)
            Exit Sub
        End If

        If Me.ValidateChildren() Then 'validates rquired textboxes using textbox validation else message
            MsgBox("Are you sure you want to do this?", vbOKCancel, "Create Student") 'ask if they want to proceed with the student addition
            If MsgBoxResult.Ok Then
                'inserts the textbox information into the database
                db.sql = "Insert into Students (FirstName, MiddleName, Lastname, SSN, LocalAddress, LocalCity, LocalStateOrProvince, LocalZipcode, LocalHomePhone, PermAddress, PermCity, PermStateOrProvince, PermZipCode, PermHomePhone, MailingAddress, MailingCity, MailingStateOrProvince, MailingZip, email2, PrimaryEmail, Birthdate, CitizenshipStatus, OriginCountry, EthnicBackground, Sex) Values (@FirstName, @MiddleName, @Lastname, @SSN, @LocalAddress, @LocalCity, @LocalStateOrProvince, @LocalZipcode, @LocalHomePhone, @PermAddress, @PermCity, @PermStateOrProvince, @PermZipCode, @PermHomePhone, @MailingAddress, @MailingCity, @MailingStateOrProvince, @MailingZip,@email2, @PrimaryEmail, @Birthdate, @CitizenshipStatus, @OriginCountry, @EthnicBackground, @Sex)"
                db.bind("@firstName", txtFirstName.Text)
                db.bind("@MiddleName", txtMiddleName.Text)
                db.bind("@LastName", txtLastName.Text)
                db.bind("@SSN", txtSSN.Text)
                db.bind("@LocalAddress", txtPAddress.Text)
                db.bind("@LocalCity", txtPCity.Text)
                db.bind("@localstateorprovince", cbxPState.Text)
                db.bind("@LocalZipcode", txtPZipCode.Text)
                db.bind("@LocalHomePhone", txtCurrentPhone.Text)
                db.bind("@PermAddress", Paddress.Text)
                db.bind("@PermCity", Pcity.Text)
                db.bind("@PermStateOrProvince", PState.Text)
                db.bind("@PermZipCode", PZip.Text)
                db.bind("@PermHomePhone", txtPPhone.Text)
                db.bind("@MailingAddress", Maddress.Text)
                db.bind("@MailingCity", Mcity.Text)
                db.bind("@MailingStateOrProvince", Mstate.Text)
                db.bind("@MailingZip", MZip.Text)
                db.bind("@PrimaryEmail", txtEmail.Text)
                db.bind("@email2", SecondEmailtxtbox.Text)
                db.bind("@Birthdate", txtBirthday1.Text)
                db.bind("@CitizenshipStatus", CitizenshipDropDown.Text)
                db.bind("@OriginCountry", OriginDropDown.Text)
                db.bind("@EthnicBackground", EthnicDropDown.Text)
                db.bind("@Sex", GenderDropDown.Text)
                db.execute()
                db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex From Students order by studentid"
                db.fill(SumReportDGV)
            End If
        Else
            MsgBox("please enter all required fields", vbOK)
        End If
    End Sub
    ' validates required textbox fields
    Private Sub TextBoxes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFirstName.Validating, txtLastName.Validating
        Dim field = DirectCast(sender, TextBox)
        If String.IsNullOrWhiteSpace(field.Text) Then
            field.HideSelection = False
            field.SelectAll()
            field.HideSelection = True
            e.Cancel = True
        End If
    End Sub
    '<---------------------------------------------------------------------------------Update Student----------------------------------------------------------------------------------------------->
    Private Sub summary_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Setting datagrid to select entire rows of data
        SumReportDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ''Filling datagridview with students table when the page loads
        db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex From Students order by studentid"
        db.fill(SumReportDGV)
        SumReportDGV.ClearSelection()
    End Sub
    ''When any text is changed in the search box we want to search the table for values like the text the user entered
    Private Sub SearchTextbox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextbox.TextChanged
        ''We are using a like statement to search every column for a value like whatever is typed in the textbox. When the text box is blank it automatically selects all values so this works out good.
        db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex From Students Where StudentID like '%" & SearchTextbox.Text & "%' OR FirstName like '%" & SearchTextbox.Text & "%' OR LastName like '%" & SearchTextbox.Text & "%' "
        db.fill(SumReportDGV)
    End Sub
    Private Sub AddStudentButton_Click(sender As Object, e As EventArgs) Handles AddStudentButton.Click
        'Update Record
        MessageBox.Show("Are you sure you want to update this student record?", "Add Student", MessageBoxButtons.YesNo)
    End Sub
    Private Sub SumReportDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SumReportDGV.CellClick
        ''If statement to test whether or not the cells are seleceted and if they are it fills them into the matching textbox
        If (SumReportDGV.SelectedRows.Count > 0) Then
            StudentIDTxtBox.Text = SumReportDGV.SelectedRows(0).Cells(0).Value.ToString()
            FirstnameTExtBox.Text = SumReportDGV.SelectedRows(0).Cells(1).Value.ToString()
            middlenameTextBox.Text = SumReportDGV.SelectedRows(0).Cells(2).Value.ToString()
            LastnameTextBox.Text = SumReportDGV.SelectedRows(0).Cells(3).Value.ToString()
            SSNTextBox.Text = SumReportDGV.SelectedRows(0).Cells(4).Value.ToString()
            AddressTextBox.Text = SumReportDGV.SelectedRows(0).Cells(5).Value.ToString()
            CityTextBox.Text = SumReportDGV.SelectedRows(0).Cells(6).Value.ToString()
            StateTextBox.Text = SumReportDGV.SelectedRows(0).Cells(7).Value.ToString()
            ZipCodeTextBox.Text = SumReportDGV.SelectedRows(0).Cells(8).Value.ToString()
            EmailTextBox.Text = SumReportDGV.SelectedRows(0).Cells(9).Value.ToString()
            BirthDateTextBox.Text = SumReportDGV.SelectedRows(0).Cells(10).Value.ToString()
            SexComboBox.Text = SumReportDGV.SelectedRows(0).Cells(11).Value.ToString()
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Maddress.Text = txtPAddress.Text
            Mcity.Text = txtPCity.Text
            Mstate.Text = cbxPState.Text
            MZip.Text = txtPZipCode.Text
        Else
            Maddress.Text = ""
            Mcity.Text = ""
            Mstate.Text = ""
            MZip.Text = ""
        End If
    End Sub
    '<-------------------------------------------------------------------------------ADVISING---------------------------------------------------------------------------------------------------
    ''When the page is loaded
    Private Sub Advising_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Setting the max calendar selection to 1 day 
        AdvisingCalendar.MaxSelectionCount = 1
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

