<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selectGraphType
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.rbtnRank = New System.Windows.Forms.RadioButton()
        Me.rbtnReviewScore = New System.Windows.Forms.RadioButton()
        Me.rbtnNumOfReviews = New System.Windows.Forms.RadioButton()
        Me.rbtnBookPrice = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(87, 181)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(110, 43)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'rbtnRank
        '
        Me.rbtnRank.AutoSize = True
        Me.rbtnRank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnRank.Location = New System.Drawing.Point(27, 46)
        Me.rbtnRank.Name = "rbtnRank"
        Me.rbtnRank.Size = New System.Drawing.Size(65, 24)
        Me.rbtnRank.TabIndex = 1
        Me.rbtnRank.TabStop = True
        Me.rbtnRank.Text = "Rank"
        Me.rbtnRank.UseVisualStyleBackColor = True
        '
        'rbtnReviewScore
        '
        Me.rbtnReviewScore.AutoSize = True
        Me.rbtnReviewScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnReviewScore.Location = New System.Drawing.Point(27, 76)
        Me.rbtnReviewScore.Name = "rbtnReviewScore"
        Me.rbtnReviewScore.Size = New System.Drawing.Size(124, 24)
        Me.rbtnReviewScore.TabIndex = 2
        Me.rbtnReviewScore.TabStop = True
        Me.rbtnReviewScore.Text = "Review Score"
        Me.rbtnReviewScore.UseVisualStyleBackColor = True
        '
        'rbtnNumOfReviews
        '
        Me.rbtnNumOfReviews.AutoSize = True
        Me.rbtnNumOfReviews.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnNumOfReviews.Location = New System.Drawing.Point(27, 106)
        Me.rbtnNumOfReviews.Name = "rbtnNumOfReviews"
        Me.rbtnNumOfReviews.Size = New System.Drawing.Size(164, 24)
        Me.rbtnNumOfReviews.TabIndex = 3
        Me.rbtnNumOfReviews.TabStop = True
        Me.rbtnNumOfReviews.Text = "Number of Reviews"
        Me.rbtnNumOfReviews.UseVisualStyleBackColor = True
        '
        'rbtnBookPrice
        '
        Me.rbtnBookPrice.AutoSize = True
        Me.rbtnBookPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnBookPrice.Location = New System.Drawing.Point(27, 136)
        Me.rbtnBookPrice.Name = "rbtnBookPrice"
        Me.rbtnBookPrice.Size = New System.Drawing.Size(62, 24)
        Me.rbtnBookPrice.TabIndex = 4
        Me.rbtnBookPrice.TabStop = True
        Me.rbtnBookPrice.Text = "Price"
        Me.rbtnBookPrice.UseVisualStyleBackColor = True
        '
        'selectGraphType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 249)
        Me.Controls.Add(Me.rbtnBookPrice)
        Me.Controls.Add(Me.rbtnNumOfReviews)
        Me.Controls.Add(Me.rbtnReviewScore)
        Me.Controls.Add(Me.rbtnRank)
        Me.Controls.Add(Me.btnSubmit)
        Me.Name = "selectGraphType"
        Me.Text = "selectGraphType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSubmit As Button
    Friend WithEvents rbtnRank As RadioButton
    Friend WithEvents rbtnReviewScore As RadioButton
    Friend WithEvents rbtnNumOfReviews As RadioButton
    Friend WithEvents rbtnBookPrice As RadioButton
End Class
