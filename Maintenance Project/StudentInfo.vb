Public Class StudentInfo
    Protected db As New db 'call db.vb to connect to database.
    'Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
    '    If CheckBox1.Checked = True Then
    '        GroupBox4.Visible = True
    '    ElseIf checkbox1.Checked = False Then
    '        GroupBox4.Visible = False
    '    End If
    'End Sub
    'Private Sub mailingAddressCheckBox_CheckedChanged(sender As Object, e As EventArgs)
    '    If mailingAddressCheckBox.Checked = True Then
    '        mailingGroupBox.Visible = True
    '    ElseIf mailingAddressCheckBox.Checked = False Then
    '        mailingGroupBox.Visible = False
    '    End If
    'End Sub
    Private Sub submit_Click_1(sender As Object, e As EventArgs) Handles submit.Click
        MsgBox("Are you sure you want to do this?", vbOKCancel, "Create Student") 'ask if they want to proceed with the addition
        If MsgBoxResult.Ok Then
            db.sql = "Insert into Students (FirstName, MiddleName, Lastname, SSN, LocalAddress, LocalCity, LocalStateOrProvince, LocalZipcode, LocalHomePhone, PermAddress, PermCity, PermStateOrProvince, PermZipCode, PermHomePhone, MailingAddress, MailingCity, MailingStateOrProvince, MailingZip, PrimaryEmail, Birthdate, CitizenshipStatus, OriginCountry, EthnicBackground, Sex) Values (@FirstName, @MiddleName, @Lastname, @SSN, @LocalAddress, @LocalCity, @LocalStateOrProvince, @LocalZipcode, @LocalHomePhone, @PermAddress, @PermCity, @PermStateOrProvince, @PermZipCode, @PermHomePhone, @MailingAddress, @MailingCity, @MailingStateOrProvince, @MailingZip, @PrimaryEmail, @Birthdate, @CitizenshipStatus, @OriginCountry, @EthnicBackground, @Sex)"
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
            db.bind("@Birthdate", txtBirthday1.Text)
            db.bind("@CitizenshipStatus", CitizenshipDropDown.Text)
            db.bind("@OriginCountry", OriginDropDown.Text)
            db.bind("@EthnicBackground", EthnicDropDown.Text)
            db.bind("@Sex", GenderDropDown.Text)
            db.execute()
        End If
    End Sub
End Class

