Public Class selectGraphType
    Dim selectedType As String
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If rbtnBookPrice.Checked Then
            selectedType = "BookPrice"
        End If
        If rbtnRank.Checked Then
            selectedType = "Rank"
        End If
        If rbtnNumOfReviews.Checked Then
            selectedType = "NumOfReviews"
        End If
        If rbtnReviewScore.Checked Then
            selectedType = "ReviewScore"
        End If
        Form1.YAxis = selectedType
        Me.TopMost = False
        Me.Close()
    End Sub

    Private Sub selectGraphType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        rbtnRank.Checked = True
    End Sub
    Private Sub selectGraphType_Close(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class