<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BookNameLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BookIDLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BookASINLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BookAuthorLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BookURLLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ResultIDLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BookLengthLabel = New System.Windows.Forms.Label()
        Me.BookFileSizeLabel = New System.Windows.Forms.Label()
        Me.BookLanguageLabel = New System.Windows.Forms.Label()
        Me.BookPublisherLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ResultASINLabel = New System.Windows.Forms.Label()
        Me.ResultRankLabel = New System.Windows.Forms.Label()
        Me.ResultReviewScoreLabel = New System.Windows.Forms.Label()
        Me.ResultNumOfReviewsLabel = New System.Windows.Forms.Label()
        Me.ResultPriceLabel = New System.Windows.Forms.Label()
        Me.ResultDateOfScanLabel = New System.Windows.Forms.Label()
        Me.ResultTimeOfScanLabel = New System.Windows.Forms.Label()
        Me.btnCalculateAverages = New System.Windows.Forms.Button()
        Me.listBoxAverages = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.automatedScrapeTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(23, 45)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(303, 407)
        Me.ListBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(124, 515)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 49)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Update Book"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(23, 515)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 49)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Add Book"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(371, 45)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(304, 199)
        Me.ListBox2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(368, 267)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Book Name:"
        '
        'BookNameLabel
        '
        Me.BookNameLabel.AutoSize = True
        Me.BookNameLabel.Location = New System.Drawing.Point(452, 267)
        Me.BookNameLabel.Name = "BookNameLabel"
        Me.BookNameLabel.Size = New System.Drawing.Size(59, 13)
        Me.BookNameLabel.TabIndex = 5
        Me.BookNameLabel.Text = "bookName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(368, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "BookID:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(225, 515)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(95, 49)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Delete Book"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BookIDLabel
        '
        Me.BookIDLabel.AutoSize = True
        Me.BookIDLabel.Location = New System.Drawing.Point(452, 280)
        Me.BookIDLabel.Name = "BookIDLabel"
        Me.BookIDLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookIDLabel.TabIndex = 8
        Me.BookIDLabel.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(368, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "ASIN:"
        '
        'BookASINLabel
        '
        Me.BookASINLabel.AutoSize = True
        Me.BookASINLabel.Location = New System.Drawing.Point(452, 293)
        Me.BookASINLabel.Name = "BookASINLabel"
        Me.BookASINLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookASINLabel.TabIndex = 10
        Me.BookASINLabel.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(368, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Author:"
        '
        'BookAuthorLabel
        '
        Me.BookAuthorLabel.AutoSize = True
        Me.BookAuthorLabel.Location = New System.Drawing.Point(452, 306)
        Me.BookAuthorLabel.Name = "BookAuthorLabel"
        Me.BookAuthorLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookAuthorLabel.TabIndex = 12
        Me.BookAuthorLabel.Text = "..."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(368, 319)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "URL:"
        '
        'BookURLLabel
        '
        Me.BookURLLabel.AutoSize = True
        Me.BookURLLabel.Location = New System.Drawing.Point(452, 319)
        Me.BookURLLabel.Name = "BookURLLabel"
        Me.BookURLLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookURLLabel.TabIndex = 14
        Me.BookURLLabel.Text = "..."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Books:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(368, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Results:"
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(694, 45)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(526, 509)
        Me.Chart1.TabIndex = 17
        Me.Chart1.Text = "Chart1"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(70, 571)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(95, 49)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "New Scan"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1061, 571)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(95, 49)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "Reset Graph"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(919, 571)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(95, 49)
        Me.Button6.TabIndex = 20
        Me.Button6.Text = "Change Y axis"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(773, 571)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(95, 49)
        Me.Button8.TabIndex = 22
        Me.Button8.Text = "Show Current Book Results on Graph"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(124, 460)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(95, 49)
        Me.Button7.TabIndex = 23
        Me.Button7.Text = "Fill List Boxes"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(368, 428)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "ResultID:"
        '
        'ResultIDLabel
        '
        Me.ResultIDLabel.AutoSize = True
        Me.ResultIDLabel.Location = New System.Drawing.Point(452, 428)
        Me.ResultIDLabel.Name = "ResultIDLabel"
        Me.ResultIDLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultIDLabel.TabIndex = 25
        Me.ResultIDLabel.Text = "..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 332)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Length:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(368, 345)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "File Size:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(368, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Language:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(368, 371)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Publisher:"
        '
        'BookLengthLabel
        '
        Me.BookLengthLabel.AutoSize = True
        Me.BookLengthLabel.Location = New System.Drawing.Point(452, 332)
        Me.BookLengthLabel.Name = "BookLengthLabel"
        Me.BookLengthLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookLengthLabel.TabIndex = 31
        Me.BookLengthLabel.Text = "..."
        '
        'BookFileSizeLabel
        '
        Me.BookFileSizeLabel.AutoSize = True
        Me.BookFileSizeLabel.Location = New System.Drawing.Point(452, 345)
        Me.BookFileSizeLabel.Name = "BookFileSizeLabel"
        Me.BookFileSizeLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookFileSizeLabel.TabIndex = 32
        Me.BookFileSizeLabel.Text = "..."
        '
        'BookLanguageLabel
        '
        Me.BookLanguageLabel.AutoSize = True
        Me.BookLanguageLabel.Location = New System.Drawing.Point(452, 358)
        Me.BookLanguageLabel.Name = "BookLanguageLabel"
        Me.BookLanguageLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookLanguageLabel.TabIndex = 34
        Me.BookLanguageLabel.Text = "..."
        '
        'BookPublisherLabel
        '
        Me.BookPublisherLabel.AutoSize = True
        Me.BookPublisherLabel.Location = New System.Drawing.Point(452, 371)
        Me.BookPublisherLabel.Name = "BookPublisherLabel"
        Me.BookPublisherLabel.Size = New System.Drawing.Size(16, 13)
        Me.BookPublisherLabel.TabIndex = 35
        Me.BookPublisherLabel.Text = "..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 441)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "ASIN:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(368, 454)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Rank:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(368, 467)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Review Score:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(368, 480)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "# of Reviews:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(368, 493)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Price:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(368, 506)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Date of Scan:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(368, 519)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Time of Scan:"
        '
        'ResultASINLabel
        '
        Me.ResultASINLabel.AutoSize = True
        Me.ResultASINLabel.Location = New System.Drawing.Point(452, 441)
        Me.ResultASINLabel.Name = "ResultASINLabel"
        Me.ResultASINLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultASINLabel.TabIndex = 43
        Me.ResultASINLabel.Text = "..."
        '
        'ResultRankLabel
        '
        Me.ResultRankLabel.AutoSize = True
        Me.ResultRankLabel.Location = New System.Drawing.Point(452, 454)
        Me.ResultRankLabel.Name = "ResultRankLabel"
        Me.ResultRankLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultRankLabel.TabIndex = 44
        Me.ResultRankLabel.Text = "..."
        '
        'ResultReviewScoreLabel
        '
        Me.ResultReviewScoreLabel.AutoSize = True
        Me.ResultReviewScoreLabel.Location = New System.Drawing.Point(452, 467)
        Me.ResultReviewScoreLabel.Name = "ResultReviewScoreLabel"
        Me.ResultReviewScoreLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultReviewScoreLabel.TabIndex = 45
        Me.ResultReviewScoreLabel.Text = "..."
        '
        'ResultNumOfReviewsLabel
        '
        Me.ResultNumOfReviewsLabel.AutoSize = True
        Me.ResultNumOfReviewsLabel.Location = New System.Drawing.Point(452, 480)
        Me.ResultNumOfReviewsLabel.Name = "ResultNumOfReviewsLabel"
        Me.ResultNumOfReviewsLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultNumOfReviewsLabel.TabIndex = 46
        Me.ResultNumOfReviewsLabel.Text = "..."
        '
        'ResultPriceLabel
        '
        Me.ResultPriceLabel.AutoSize = True
        Me.ResultPriceLabel.Location = New System.Drawing.Point(452, 493)
        Me.ResultPriceLabel.Name = "ResultPriceLabel"
        Me.ResultPriceLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultPriceLabel.TabIndex = 47
        Me.ResultPriceLabel.Text = "..."
        '
        'ResultDateOfScanLabel
        '
        Me.ResultDateOfScanLabel.AutoSize = True
        Me.ResultDateOfScanLabel.Location = New System.Drawing.Point(452, 506)
        Me.ResultDateOfScanLabel.Name = "ResultDateOfScanLabel"
        Me.ResultDateOfScanLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultDateOfScanLabel.TabIndex = 48
        Me.ResultDateOfScanLabel.Text = "..."
        '
        'ResultTimeOfScanLabel
        '
        Me.ResultTimeOfScanLabel.AutoSize = True
        Me.ResultTimeOfScanLabel.Location = New System.Drawing.Point(452, 519)
        Me.ResultTimeOfScanLabel.Name = "ResultTimeOfScanLabel"
        Me.ResultTimeOfScanLabel.Size = New System.Drawing.Size(16, 13)
        Me.ResultTimeOfScanLabel.TabIndex = 49
        Me.ResultTimeOfScanLabel.Text = "..."
        '
        'btnCalculateAverages
        '
        Me.btnCalculateAverages.Location = New System.Drawing.Point(474, 728)
        Me.btnCalculateAverages.Name = "btnCalculateAverages"
        Me.btnCalculateAverages.Size = New System.Drawing.Size(95, 49)
        Me.btnCalculateAverages.TabIndex = 50
        Me.btnCalculateAverages.Text = "Calculate Averages"
        Me.btnCalculateAverages.UseVisualStyleBackColor = True
        '
        'listBoxAverages
        '
        Me.listBoxAverages.FormattingEnabled = True
        Me.listBoxAverages.Location = New System.Drawing.Point(401, 571)
        Me.listBoxAverages.Name = "listBoxAverages"
        Me.listBoxAverages.Size = New System.Drawing.Size(248, 147)
        Me.listBoxAverages.TabIndex = 51
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 636)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(368, 141)
        Me.TextBox1.TabIndex = 52
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(171, 570)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(95, 49)
        Me.Button9.TabIndex = 53
        Me.Button9.Text = "Specific Book Scan"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'automatedScrapeTimer
        '
        Me.automatedScrapeTimer.Interval = 3600000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1242, 789)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.listBoxAverages)
        Me.Controls.Add(Me.btnCalculateAverages)
        Me.Controls.Add(Me.ResultTimeOfScanLabel)
        Me.Controls.Add(Me.ResultDateOfScanLabel)
        Me.Controls.Add(Me.ResultPriceLabel)
        Me.Controls.Add(Me.ResultNumOfReviewsLabel)
        Me.Controls.Add(Me.ResultReviewScoreLabel)
        Me.Controls.Add(Me.ResultRankLabel)
        Me.Controls.Add(Me.ResultASINLabel)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BookPublisherLabel)
        Me.Controls.Add(Me.BookLanguageLabel)
        Me.Controls.Add(Me.BookFileSizeLabel)
        Me.Controls.Add(Me.BookLengthLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ResultIDLabel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BookURLLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BookAuthorLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BookASINLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BookIDLabel)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BookNameLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BookNameLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents BookIDLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BookASINLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BookAuthorLabel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents BookURLLabel As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents ResultIDLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents BookLengthLabel As Label
    Friend WithEvents BookFileSizeLabel As Label
    Friend WithEvents BookLanguageLabel As Label
    Friend WithEvents BookPublisherLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents ResultASINLabel As Label
    Friend WithEvents ResultRankLabel As Label
    Friend WithEvents ResultReviewScoreLabel As Label
    Friend WithEvents ResultNumOfReviewsLabel As Label
    Friend WithEvents ResultPriceLabel As Label
    Friend WithEvents ResultDateOfScanLabel As Label
    Friend WithEvents ResultTimeOfScanLabel As Label
    Friend WithEvents btnCalculateAverages As Button
    Friend WithEvents listBoxAverages As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents automatedScrapeTimer As Timer
End Class
