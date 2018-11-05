Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Module ModuleTest
    Public Value As String
End Module

Public Class Form1


    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If e.Data = "" Then
        Else
            Value = e.Data
        End If
    End Sub

    Dim con As New MySqlConnection
    Dim listOfResultIDGraph As New List(Of String)
    Dim listOfResultOnGraph As New List(Of resultOnGraph)
    Public YAxis As String

    'used to store the results on the graph to allow persistence when changing the y axis
    'takes the ASIN of the book and the result id of the result as parameters for constructor
    Class resultOnGraph
        Private resultID As String
        Private bookASIN As String

        'constructor
        Public Sub New(ByVal rID As String, ByVal asin As String)
            Me.resultID = rID
            Me.bookASIN = asin
        End Sub

        Function getResultID()
            Return resultID
        End Function

        Function getBookASIN()
            Return bookASIN
        End Function
    End Class

    'change the database here
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set default YAxis
        YAxis = "Rank"
        'change the database connected to here
        Dim constr As String = "server=localhost;uid=root;pwd=password;database=webscrape2"
        Try
            con.ConnectionString = constr
            con.Open()
            MsgBox("connected to database")
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub ClearResultsLabels()
        'just clear all the labels associated with results
        ResultIDLabel.Text = ""
        ResultASINLabel.Text = ""
        ResultRankLabel.Text = ""
        ResultReviewScoreLabel.Text = ""
        ResultNumOfReviewsLabel.Text = ""
        ResultPriceLabel.Text = ""
        ResultDateOfScanLabel.Text = ""
        ResultTimeOfScanLabel.Text = ""
    End Sub

    Private Sub ClearBooksLabels()
        'clear all labels associated with the books
        BookNameLabel.Text = ""
        BookIDLabel.Text = ""
        BookASINLabel.Text = ""
        BookAuthorLabel.Text = ""
        BookURLLabel.Text = ""
        BookLengthLabel.Text = ""
        BookFileSizeLabel.Text = ""
        BookLanguageLabel.Text = ""
        BookPublisherLabel.Text = ""
    End Sub

    'code to fill the book list box with ASINs from the books table of the database
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim ListOfASINs As New List(Of String)


        Dim getASINS As New MySqlCommand("SELECT * FROM books", con)
        Dim readASINS As MySqlDataReader
        readASINS = getASINS.ExecuteReader()
        While readASINS.Read()
            'ListBox1.Items.Add(readASINS("BookTitle").ToString)
            'change "ASIN" to whatever column you want
            'currently will only work with ASIN as values are being used directly from list box later in program
            'change this in future versions
            ListOfASINs.Add(readASINS("ASIN").ToString)
        End While
        'close reader and clear the form
        readASINS.Close()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        listBoxAverages.Items.Clear()
        ClearBooksLabels()
        ClearResultsLabels()
        Dim testString As String
        'add the asins to the list box
        For Each testString In ListOfASINs
            ListBox1.Items.Add(testString)
        Next
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    'code to change the results list box contents depending on the selection made in the books list box
    Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'user has selected a new value in the books list box, so we need to display the relevant information and create a new results list

        'get the currently selected item
        Dim curItem As String = ListBox1.SelectedItem.ToString()
        'first change the labels, so we need to open a new reader
        Dim getBOOKS As New MySqlCommand("SELECT * FROM books WHERE ASIN = @ASIN", con)
        getBOOKS.Prepare()
        getBOOKS.Parameters.AddWithValue("@ASIN", curItem)
        Dim readBOOKS As MySqlDataReader
        readBOOKS = getBOOKS.ExecuteReader()
        While readBOOKS.Read()
            'update the labels with new values
            BookNameLabel.Text = readBOOKS("BookTitle").ToString
            BookIDLabel.Text = readBOOKS("BOOKID").ToString
            BookASINLabel.Text = readBOOKS("ASIN").ToString
            BookAuthorLabel.Text = readBOOKS("BookAuthor").ToString
            BookURLLabel.Text = readBOOKS("BookURL").ToString
            BookLengthLabel.Text = readBOOKS("BookLength").ToString
            BookFileSizeLabel.Text = readBOOKS("BookFileSize").ToString
            BookLanguageLabel.Text = readBOOKS("BookLanguage").ToString
            BookPublisherLabel.Text = readBOOKS("BookPublisher").ToString
        End While
        readBOOKS.Close()


        'now get the results and put them in list box 2
        Dim ListOfResultID As New List(Of String)
        Dim getResults As New MySqlCommand("SELECT * FROM results WHERE BookASIN = @BookASIN", con)
        getResults.Prepare()
        getResults.Parameters.AddWithValue("@BookASIN", curItem)
        Dim readResults As MySqlDataReader
        readResults = getResults.ExecuteReader()
        While readResults.Read()
            'get IDs
            ListOfResultID.Add(readResults("ResultID").ToString)
        End While
        ListBox2.Items.Clear()
        Dim testString As String
        For Each testString In ListOfResultID
            'add to list box 2
            ListBox2.Items.Add(testString)
        Next
        'close reader
        readResults.Close()
        'force select the first new result in the list box (if there are any)
        If ListBox2.Items.Count > 0 Then
            ListBox2.SelectedIndex = 0
        End If
        listBoxAverages.Items.Clear()
    End Sub

    'code to change the results labels
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        'user has selected a new result, so we must set the results labels accordingly
        Dim curItem As String = ListBox2.SelectedItem.ToString()
        Dim ListOfResultID As New List(Of String)
        Dim getResults As New MySqlCommand("SELECT * FROM results WHERE ResultID = @ResultID", con)
        getResults.Prepare()
        getResults.Parameters.AddWithValue("@ResultID", curItem)
        Dim readResults As MySqlDataReader
        readResults = getResults.ExecuteReader()
        While readResults.Read()
            'get values and write them to correct labels
            ResultIDLabel.Text = readResults("ResultID").ToString
            ResultASINLabel.Text = readResults("BookASIN").ToString
            ResultRankLabel.Text = readResults("Rank").ToString
            ResultReviewScoreLabel.Text = readResults("ReviewScore").ToString
            ResultNumOfReviewsLabel.Text = readResults("NumOfReviews").ToString
            ResultPriceLabel.Text = readResults("BookPrice").ToString
            ResultDateOfScanLabel.Text = readResults("DateOfScan").ToShortDateString
            ResultTimeOfScanLabel.Text = readResults("TimeOfScan").ToString
        End While
        'close reader
        readResults.Close()
    End Sub

    'code to add the currently selected book to the graph
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim currentASIN As String
        'new result IDs are stored in the list box. Add them to the global list to allow persistence
        For Each id In ListBox2.Items
            'listOfResultIDGraph.Add(id)
            listOfResultOnGraph.Add(New resultOnGraph(id, ResultASINLabel.Text))
        Next

        'need to loop through each element in the list box to add all results to graph
        'first create the new series by using the ASIN
        currentASIN = BookASINLabel.Text()
        If Me.Chart1.Series.IsUniqueName(currentASIN) Then
            Me.Chart1.Series.Add(currentASIN)
            Me.Chart1.Series(currentASIN).BorderWidth = 2
        Else
            MsgBox("already exists on graph")
            Exit Sub
        End If
        'set up the reader

        Dim ListOfResultID As New List(Of String)
        Dim readResults As MySqlDataReader
        For Each i In ListBox2.Items
            Dim getResults As New MySqlCommand("SELECT * FROM results WHERE ResultID = @ResultID", con)
            getResults.Prepare()
            getResults.Parameters.AddWithValue("@ResultID", i)
            readResults = getResults.ExecuteReader()
            While readResults.Read()
                'get needed values from the query and plot them on the graph
                'needed values will change depending on what the user selects, do this later
                'default is ranking
                Me.Chart1.Series(currentASIN).ChartType = SeriesChartType.Line
                Me.Chart1.Series(currentASIN).Points.AddXY(readResults("DateOfScan").ToShortDateString + " " + readResults("TimeOfScan").ToString, readResults(YAxis).ToString)
            End While
            readResults.Close()
        Next
    End Sub

    'code to clear the graph
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Chart1.Series.Clear()
        listOfResultOnGraph.Clear()
    End Sub

    'code to change the Y axis and regenerate the graph afterwards
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'change the Y axis to what the user wants
        Dim previousYAxis As String
        Dim currentASIN = ""
        previousYAxis = YAxis
        'first get the user input by using the selectGraphType form
        selectGraphType.ShowDialog()
        'YAxis is now set to the value required
        If Not previousYAxis = YAxis Then
            'YAxis has changed so we need to redraw the graph
            Me.Chart1.Series.Clear()
            Dim readResults As MySqlDataReader
            'we should be able to regenerate the graph by using the list of resultIDs
            'go through each of the resultIDs in the list, retrieve their ASIN, and assign their ASIN
            For Each i In listOfResultOnGraph
                'now we need to go through each element in the list and check the ASIN
                'if the asin has not already been found then we need to create a new series and start adding the next results to that series
                If Not i.getBookASIN = currentASIN Then
                    'new ASIN has been found. Create a new series and set currentASIN
                    currentASIN = i.getBookASIN
                    Me.Chart1.Series.Add(currentASIN)
                    Me.Chart1.Series(currentASIN).BorderWidth = 2
                End If
                'retrieve the result
                Dim getResults As New MySqlCommand("SELECT * FROM results WHERE ResultID = @ResultID", con)
                getResults.Prepare()
                getResults.Parameters.AddWithValue("@ResultID", i.getResultID)
                readResults = getResults.ExecuteReader()
                'now add it to the graph
                While readResults.Read()
                    'get needed values from the query and plot them on the graph
                    'needed values will change depending on what the user selects, do this later
                    'default is ranking
                    Me.Chart1.Series(currentASIN).ChartType = SeriesChartType.Line
                    Me.Chart1.Series(currentASIN).Points.AddXY(readResults("DateOfScan").ToShortDateString + " " + readResults("TimeOfScan").ToString, readResults(YAxis).ToString)
                End While
                readResults.Close()
            Next
        End If
    End Sub

    'code to calculate averages of results and display in a text box
    Private Sub btnCalculateAverages_Click(sender As Object, e As EventArgs) Handles btnCalculateAverages.Click
        Dim avgPrice As Decimal
        Dim avgRank As Decimal
        Dim avgReviewScore As Decimal
        Dim avgNumOfReviews As Decimal
        Dim numOfResults As Integer
        Dim dateFirstSeen As String = ""
        Dim timeFirstSeen As String = ""
        Dim dateLastSeen As String = ""
        Dim timeLastSeen As String = ""
        Dim currentNum As Integer = 0
        'check if user has selected a book
        If ListBox2.Items.Count = 0 Then
            MsgBox("No book selected")
        Else
            listBoxAverages.Items.Clear()
            numOfResults = ListBox2.Items.Count()
            'calculate the averages over the results for the book currently selected
            For Each i In ListBox2.Items
                Dim readResults As MySqlDataReader
                Dim getResults As New MySqlCommand("SELECT * FROM results WHERE ResultID = @ResultID", con)
                getResults.Prepare()
                getResults.Parameters.AddWithValue("@ResultID", i)
                readResults = getResults.ExecuteReader()
                'add the needed values to the variables
                While readResults.Read()
                    If currentNum = 0 Then
                        dateFirstSeen = readResults("DateOfScan").ToShortDateString
                        timeFirstSeen = readResults("TimeOfScan").ToString
                    End If
                    If currentNum = (ListBox2.Items.Count - 1) Then
                        dateLastSeen = readResults("DateOfScan").ToShortDateString
                        timeLastSeen = readResults("TimeOfScan").ToString
                    End If
                    avgPrice += Convert.ToDecimal(readResults("BookPrice"))
                    avgRank += Convert.ToDecimal(readResults("Rank"))
                    avgReviewScore += Convert.ToDecimal(readResults("ReviewScore"))
                    avgNumOfReviews += Convert.ToDecimal(readResults("NumOfReviews"))
                End While
                readResults.Close()
                currentNum += 1
            Next
            'calculate the averages and output to the list box
            avgPrice = Math.Round(avgPrice / numOfResults, 2)
            avgRank = Math.Round(avgRank / numOfResults, 2)
            avgReviewScore = Math.Round(avgReviewScore / numOfResults, 2)
            avgNumOfReviews = Math.Round(avgNumOfReviews / numOfResults, 2)
            listBoxAverages.Items.Add("Over " + numOfResults.ToString + " results:")
            listBoxAverages.Items.Add("First Seen:  " + dateFirstSeen + " " + timeFirstSeen)
            listBoxAverages.Items.Add("Last Seen:  " + dateLastSeen + " " + timeLastSeen)
            listBoxAverages.Items.Add("Price: " + avgPrice.ToString)
            listBoxAverages.Items.Add("Rank: " + avgRank.ToString)
            listBoxAverages.Items.Add("Review Score: " + avgReviewScore.ToString)
            listBoxAverages.Items.Add("Num of Reviews: " + avgNumOfReviews.ToString)

        End If
    End Sub

    'code below here is to do with the scrape itself
    'currently only set up to work with the saved webpages
    'needs to be fixed when Amazon finalise their top 100 webpage

    'should really be changed to all call the same method, and pass in the arguments
    'also has hardcoded paths to python.exe and the python code to be run, need to find a better way to do this

    'add a book to the database
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'first get the ASIN, update this later to allow webpage too
        Dim asin As String
        Dim argumentsString As String
        asin = InputBox("Insert ASIN")
        If asin = "" Then
            'no input
            Exit Sub
        End If
        'no validation for purpose of demonstration, needs to be added later
        Dim proc As Process = New Process
        proc.StartInfo.FileName = "C:\Users\Dave\AppData\Local\Programs\Python\Python36\python.exe" 'Default Python Installation
        argumentsString = "C:\Users\Dave\PycharmProjects\test\addBookDemo.py " + asin
        proc.StartInfo.Arguments = argumentsString
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        proc.StartInfo.RedirectStandardError = True
        proc.Start()
        While Not proc.StandardOutput.EndOfStream
            Value = proc.StandardOutput.ReadLine()
            TextBox1.AppendText((TextBox1.Text + Value) & Environment.NewLine)
        End While
        'proc.WaitForExit()

    End Sub

    'do a new top 100 scan
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim proc As Process = New Process
        Dim i As Integer = 0
        proc.StartInfo.FileName = "C:\Users\Dave\AppData\Local\Programs\Python\Python36\python.exe" 'Default Python Installation
        proc.StartInfo.Arguments = "C:\Users\Dave\PycharmProjects\test\top100ScrapeDemo.py "
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        proc.StartInfo.CreateNoWindow = False
        'proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        'proc.StartInfo.RedirectStandardError = True
        proc.Start()
        proc.WaitForExit()
    End Sub

    'delete a book from the database
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim asin As String
        Dim argumentsString As String
        If ListBox1.SelectedIndex >= 0 Then
            Dim result As Integer = MessageBox.Show("Remove book " + ListBox1.SelectedItem, "Delete", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                Dim proc As Process = New Process
                asin = ListBox1.SelectedItem
                proc.StartInfo.FileName = "C:\Users\Dave\AppData\Local\Programs\Python\Python36\python.exe" 'Default Python Installation
                argumentsString = "C:\Users\Dave\PycharmProjects\test\deleteBookDemo.py " + asin
                proc.StartInfo.Arguments = argumentsString
                proc.StartInfo.UseShellExecute = False
                proc.StartInfo.CreateNoWindow = False
                proc.Start()
                proc.WaitForExit()
                'now need to refresh the list box
                Me.Button7.PerformClick()
                'also delete the graph
                Me.Chart1.Series.Clear()
            End If
        End If
    End Sub

    'update a book in the database
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim asin As String
        Dim currentIndex As Integer
        Dim argumentsString As String
        asin = ListBox1.SelectedItem
        currentIndex = ListBox1.SelectedIndex
        If currentIndex >= 0 Then
            'no validation for purpose of demonstration, needs to be added later
            Dim proc As Process = New Process
            proc.StartInfo.FileName = "C:\Users\Dave\AppData\Local\Programs\Python\Python36\python.exe" 'Default Python Installation
            argumentsString = "C:\Users\Dave\PycharmProjects\test\updateBookDemo.py " + asin
            proc.StartInfo.Arguments = argumentsString
            proc.StartInfo.UseShellExecute = False 'required for redirect.
            'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
            proc.StartInfo.CreateNoWindow = False
            'proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
            'proc.StartInfo.RedirectStandardError = True
            proc.Start()
            proc.WaitForExit()
        End If
        ListBox1.SelectedIndex = currentIndex

    End Sub

    'scan for a specific book
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'first get the ASIN, update this later to allow webpage too
        Dim asin As String
        Dim argumentsString As String
        asin = InputBox("Insert ASIN")
        'no validation for purpose of demonstration, needs to be added later
        Dim proc As Process = New Process
        proc.StartInfo.FileName = "C:\Users\Dave\AppData\Local\Programs\Python\Python36\python.exe" 'Default Python Installation
        argumentsString = "C:\Users\Dave\PycharmProjects\test\specificBookScrapeDemo.py " + asin
        proc.StartInfo.Arguments = argumentsString
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        'proc.StartInfo.CreateNoWindow = True
        'proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        'proc.StartInfo.RedirectStandardError = True
        proc.Start()
        'While Not proc.StandardOutput.EndOfStream
        'Value = proc.StandardOutput.ReadLine()
        'TextBox1.AppendText((TextBox1.Text + Value) & Environment.NewLine)
        'End While
        'proc.WaitForExit()
    End Sub

    Private Sub automatedScrapeTimer_Tick(sender As Object, e As EventArgs) Handles automatedScrapeTimer.Tick
        Dim proc As Process = New Process
        Dim i As Integer = 0
        proc.StartInfo.FileName = "C:\Users\Dave\AppData\Local\Programs\Python\Python36\python.exe" 'Default Python Installation
        proc.StartInfo.Arguments = "C:\Users\Dave\PycharmProjects\test\top100ScrapeDemo.py "
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        'proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        proc.StartInfo.CreateNoWindow = False
        'proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        'proc.StartInfo.RedirectStandardError = True
        proc.Start()
        proc.WaitForExit()
    End Sub
End Class
