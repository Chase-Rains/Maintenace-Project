Public Class StudentInfo

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox4.Visible = True
        ElseIf checkbox1.Checked = False Then
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub mailingAddressCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mailingAddressCheckBox.CheckedChanged
        If mailingAddressCheckBox.Checked = True Then
            mailingGroupBox.Visible = True
        ElseIf mailingAddressCheckBox.Checked = False Then
            mailingGroupBox.Visible = False
        End If
    End Sub
End Class