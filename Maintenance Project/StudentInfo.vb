Imports System.Data.SqlClient 'required to ensure unique advising date sub class
Public Class StudentInfo
    Dim SID As Integer 'stores student id
    Protected db As New db 'call db.vb to connect to database.
    Dim SelectedDate As Int32 'selected date on the advising calender
    Private Sub summary_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Setting datagrid to select entire rows of data
        SumReportDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        AdvisingDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ''Filling datagridview with students table when the page loads
        db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex, GMATVerbal, GMATQuant, GMATTotal, GMATPercent, UndergradInst, UndergradGPA, UndergradMajor, Degree, YearsWorkExp, Status, DateAccepted From Students order by studentid"
        db.fill(SumReportDGV)
        'students for advising
        db.sql = "Select studentID, firstname, middlename, lastname, ssn From Students order by studentid"
        db.fill(AdvisingDataGridView)
        'advising appointments
        db.sql = "declare @yesterday datetime declare @now datetime set @now = getdate() set @yesterday = dateadd(day,-1,@now) select CONCAT( advisors.firstname, ' ', advisors.lastname) as Advisor, [date], [time], CONCAT(students.firstname, ' ', students.lastname) as Student from scheduling right join advisors on scheduling.advisorid = [advisors].advisorid right join students on scheduling.studentid = students.studentid where  scheduling.AppointmentID is not null and [date] >=@yesterday order by date"
        db.fill(DataGridView1)
        'sets the maximum advising scheduling to 60 days in the future
        AdvisingCalendar.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        AdvisingCalendar.MaxDate = AdvisingCalendar.MinDate.AddDays(60)
        ' Enable fullscreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Protected Sub loadstudents()
        db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex, GMATVerbal, GMATQuant, GMATTotal, GMATPercent, UndergradInst, UndergradGPA, UndergradMajor, Degree, YearsWorkExp, Status, DateAccepted From Students order by studentid"
        ' db.bind("@StudentID", SID)
        db.fill(SumReportDGV)
    End Sub
    '<---------------------------------------------------------------------------Create Student---------------------------------------------------------------------------------------------->
    Private Sub submit_Click_1(sender As Object, e As EventArgs) Handles submit.Click
        If txtFirstName.Text = "" Then
            MsgBox("Please enter the student's First Name", vbOK)
            Exit Sub
        End If
        If txtLastName.Text = "" Then
            MsgBox("Please enter the student's Last Name", vbOK)
            Exit Sub
        End If
        If txtSSN.MaskCompleted = False Then 'validates SSN masked textbox
            MsgBox("Please enter the student's SSN", vbOK)
            Exit Sub
        End If
        If IsDate(txtBirthday1.Text) = False Then 'validates birthdate textbox
            MsgBox("Please enter a valid birthdate", vbOK)
            Exit Sub
        End If
        If GenderDropDown.Text = "" Then 'validates gender drop down
            MsgBox("Please enter the student's Gender", vbOK)
            Exit Sub
        End If
        If txtEmail.Text = "" Then 'validates gender drop down
            MsgBox("Please enter the student's Email", vbOK)
            Exit Sub
        End If


        Dim Answer As MsgBoxResult = MsgBox("Are you sure you want to do this?", vbYesNo, "Create Student") 'ask if they want to proceed with the student addition
            Select Case Answer
                Case MsgBoxResult.Yes
                    'inserts the textbox information into the database
                    db.sql = "Insert into Students (DateAccepted, DegreeSeeking, Degree, FirstName, MiddleName, Lastname, SSN, LocalAddress, LocalCity, LocalStateOrProvince, LocalZipcode, LocalHomePhone, PermAddress, PermCity, PermStateOrProvince, PermZipCode, PermHomePhone, MailingAddress, MailingCity, MailingStateOrProvince, MailingZip, email2, PrimaryEmail, Birthdate, CitizenshipStatus, OriginCountry, EthnicBackground, Sex) Values (@DateAccepted, @DegreeSeeking, @Degree, @FirstName, @MiddleName, @Lastname, @SSN, @LocalAddress, @LocalCity, @LocalStateOrProvince, @LocalZipcode, @LocalHomePhone, @PermAddress, @PermCity, @PermStateOrProvince, @PermZipCode, @PermHomePhone, @MailingAddress, @MailingCity, @MailingStateOrProvince, @MailingZip,@email2, @PrimaryEmail, @Birthdate, @CitizenshipStatus, @OriginCountry, @EthnicBackground, @Sex)"
                    db.bind("@DateAccepted", DateAcceptedMaskedTextBox.Text)
                    db.bind("@DegreeSeeking", DegreeSeekingcombobox.Text)
                    db.bind("@degree", UndergraduateDegreecombobox.Text)
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
                    MsgBox("Action Completed", vbOK)
                db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex From Students order by studentid"
                db.fill(SumReportDGV)
                Me.Dispose()
                helper.Show()


            Case MsgBoxResult.No
                    Exit Sub
            End Select

    End Sub
    '<---------------------------------------------------------------------------------Update Student----------------------------------------------------------------------------------------------->

    ''When any text is changed in the search box we want to search the table for values like the text the user entered
    Private Sub SearchTextbox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextbox.TextChanged
        ''We are using a like statement to search every column for a value like whatever is typed in the textbox. When the text box is blank it automatically selects all values so this works out good.
        db.sql = "Select studentID, firstname, middlename, lastname, ssn, localaddress, localcity, localstateorprovince, localzipcode, primaryemail, birthdate, sex, GMATVerbal, GMATQuant, GMATTotal, GMATPercent, UndergradInst, UndergradGPA, UndergradMajor, Degree, YearsWorkExp, Status, DateAccepted From Students Where StudentID like '%" & SearchTextbox.Text & "%' OR FirstName like '%" & SearchTextbox.Text & "%' OR LastName like '%" & SearchTextbox.Text & "%' "
        db.fill(SumReportDGV)
    End Sub
    Private Sub UpdateStudentButton_Click(sender As Object, e As EventArgs) Handles UpdateStudentButton.Click
        'Update Record
        MessageBox.Show("Are you sure you want to update this student record?", "Add Student", MessageBoxButtons.YesNo)
        db.sql = "UPDATE students SET firstname = @firstname, middlename = @middlename, lastname = @lastname, localaddress = @localaddress, localcity = @localcity, localstateorprovince = @localstateorprovince, localzipcode = @localzipcode, primaryemail = @primaryemail, GMATVerbal = @GMATVerbal, GMATQuant = @GMATQuant, GMATTotal = @GMATTotal, GMATPercent = @GMATPercent, UndergradInst = @UndergradInst, UndergradGPA = @UndergradGPA, UndergradMajor = @UndergradMajor, Degree = @Degree, YearsWorkExp = @YearsWorkExp, Status = @Status, DateAccepted = @DateAccepted WHERE studentid = @studentID"
        db.bind("@StudentID", StudentIDTxtBox.Text)
        db.bind("@firstname", FirstnameTExtBox.Text)
        db.bind("@middlename", middlenameTextBox.Text)
        db.bind("@lastname", LastnameTextBox.Text)
        db.bind("@localaddress", AddressTextBox.Text)
        db.bind("@localcity", CityTextBox.Text)
        db.bind("@localstateorprovince", StateTextBox.Text)
        db.bind("@localzipcode", ZipCodeTextBox.Text)
        db.bind("@primaryemail", EmailTextBox.Text)
        db.bind("@GMATVerbal", verbalTextBox.Text)
        db.bind("@GMATQuant", QuantTextBox.Text)
        db.bind("@GMATTotal", TotalTextBox.Text)
        db.bind("@GMATPercent", AvgGMATTextBox1.Text)
        db.bind("@UndergradInst", UndergradInstitutionTextBox.Text)
        db.bind("@UndergradGPA", UGPATextBox.Text)
        db.bind("@UndergradMajor", UndergradMajorTextBox.Text)
        db.bind("@Degree", DegreeTextBox.Text)
        db.bind("@Status", ApplicationStatusComboBox.Text)
        db.bind("@DateAccepted", DateAcceptedComboBox2.Text)
        db.bind("@YearsWorkExp", WorkExperienceTextBox.Text)
        db.execute()
        MessageBox.Show("Student Updated", "Updated!", MessageBoxButtons.OK)
        loadstudents()

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
            ApplicationStatusComboBox.Text = SumReportDGV.SelectedRows(0).Cells(11).Value.ToString()
            verbalTextBox.Text = SumReportDGV.SelectedRows(0).Cells(12).Value.ToString()
            QuantTextBox.Text = SumReportDGV.SelectedRows(0).Cells(13).Value.ToString()
            TotalTextBox.Text = SumReportDGV.SelectedRows(0).Cells(14).Value.ToString()
            AvgGMATTextBox1.Text = SumReportDGV.SelectedRows(0).Cells(15).Value.ToString()
            UndergradInstitutionTextBox.Text = SumReportDGV.SelectedRows(0).Cells(16).Value.ToString()
            UGPATextBox.Text = SumReportDGV.SelectedRows(0).Cells(17).Value.ToString()
            UndergradMajorTextBox.Text = SumReportDGV.SelectedRows(0).Cells(18).Value.ToString()
            DegreeTextBox.Text = SumReportDGV.SelectedRows(0).Cells(19).Value.ToString()
            WorkExperienceTextBox.Text = SumReportDGV.SelectedRows(0).Cells(20).Value.ToString()
            ApplicationStatusComboBox.Text = SumReportDGV.SelectedRows(0).Cells(21).Value.ToString()
            DateAcceptedComboBox2.Text = SumReportDGV.SelectedRows(0).Cells(22).Value.ToString()

        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'shortcut for mailing address same as local
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
        'sunday = 0 Monday = 1 Tuesday = 2 Wednesday = 3 Thursday = 4 Friday = 5 Saturday = 6 
        SelectedDate = AdvisingCalendar.SelectionStart.DayOfWeek
        If SelectedDate = 0 Or SelectedDate = 6 Then
            TextBox3.Text = ""
        Else
            TextBox3.Text = AdvisingCalendar.SelectionRange.Start.ToShortDateString()
        End If
        If SelectedDate = 0 Then
            MessageBox.Show("There is no one available on Sunday", "Unable to Schedule", MessageBoxButtons.OK)
        ElseIf SelectedDate = 6 Then
            MessageBox.Show("There is no one available on Saturday", "Unable to Schedule", MessageBoxButtons.OK)
        Else
            TextBox3.Text = AdvisingCalendar.SelectionRange.Start.ToShortDateString()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ''We are using a like statement to search every column for a value like whatever is typed in the textbox. When the text box is blank it automatically selects all values so this works out good.
        db.sql = "Select studentID, firstname, middlename, lastname from Students Where StudentID like '%" & TextBox2.Text & "%' OR FirstName like '%" & TextBox2.Text & "%' OR LastName like '%" & TextBox2.Text & "%' "
        db.fill(AdvisingDataGridView)
    End Sub
    Private Sub advisingdatagridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdvisingDataGridView.CellClick
        ''If statement to test whether or not the cells are seleceted and if they are it fills them into the matching textbox
        If (AdvisingDataGridView.SelectedRows.Count > 0) Then
            TextBox4.Text = AdvisingDataGridView.SelectedRows(0).Cells(0).Value.ToString()
        End If
    End Sub
    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        If ComboBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Please fill out all fields", vbOK)
            Exit Sub
        End If

        Dim connection As New SqlConnection("Server=essql1.walton.uark.edu;Database=xanadu;Trusted_Connection=yes")
        Dim command As New SqlCommand("Select * from scheduling where advisorid = @advisorid and date = @date and time = @time", connection)
        ' looks to see if the database advising id, date and time are unique
        command.Parameters.Add("@advisorid", SqlDbType.VarChar).Value = TextBox5.Text
        command.Parameters.Add("@date", SqlDbType.VarChar).Value = TextBox3.Text
        command.Parameters.Add("@time", SqlDbType.VarChar).Value = ComboBox1.Text
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        'if there isnt a match error schedules advising appointment
        If table.Rows.Count() <= 0 Then
            Dim confirmed As Integer = MsgBox("Are you sure you want to do this?", vbOKCancel, "Create Student") 'ask if they want to proceed with the appointment creation
            If confirmed = DialogResult.OK Then
                db.sql = "insert into scheduling (studentid, advisorid, date, time) values (@studentId, @AdvisorId, @date, @time)"
                db.bind("@studentid", TextBox4.Text)
                db.bind("@advisorID", TextBox5.Text)
                db.bind("@date", TextBox3.Text)
                db.bind("@time", ComboBox1.Text)
                db.execute()
                MsgBox("Advising apointment created!", vbOK)
                db.sql = "declare @yesterday datetime declare @now datetime set @now = getdate() set @yesterday = dateadd(day,-1,@now)
                            select CONCAT( advisors.firstname, ' ', advisors.lastname) as Advisor, [date], [time], CONCAT(students.firstname, ' ', students.lastname) as Student from scheduling right join advisors on scheduling.advisorid = [advisors].advisorid right join students on scheduling.studentid = students.studentid where  scheduling.AppointmentID is not null and [date] >=@yesterday order by date"
                db.fill(DataGridView1)
            End If
        Else
            MessageBox.Show("Advising apointment time slot is full", "Unable to Schedule", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' selects the correct primary key to assign the advisor from
        If ComboBox2.Text = "Steve Nolan" Then
            TextBox5.Text = "2"
        ElseIf ComboBox2.Text = "Rhonda Syler" Then
            TextBox5.Text = "3"
        Else
            TextBox5.Text = ""
        End If
    End Sub
    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        ' allows deletion of student records
        Dim confirmed As Integer = MessageBox.Show("Are you sure you want to completely delete this record?", "WARNING", MessageBoxButtons.YesNoCancel)
        If confirmed = DialogResult.Yes Then
            db.sql = "DELETE FROM students WHERE studentid = @studentid"
            db.bind("@studentid", StudentIDTxtBox.Text)
            db.execute()
            loadstudents()
        End If
    End Sub
    Private Sub Logoutbutton1_Click(sender As Object, e As EventArgs) Handles Logoutbutton1.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class


